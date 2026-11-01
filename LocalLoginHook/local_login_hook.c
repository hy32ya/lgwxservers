/* Copyright (c) 2026 星海游戏HY32 */
typedef unsigned char u8;
typedef unsigned int u32;
typedef unsigned int size_t;
typedef unsigned long pthread_t;
typedef unsigned long long u64;
extern int open(const char *,int,...),close(int),write(int,const void *,size_t);
extern int read(int,void *,size_t),snprintf(char *,size_t,const char *,...);
extern int mprotect(void *,size_t,int),getpagesize(void),usleep(u32);
extern int pthread_create(pthread_t *,const void *,void *(*)(void *),void *);
extern int pthread_detach(pthread_t);
extern void *dlopen(const char *,int),*dlsym(void *,const char *);
extern void *fopen(const char *,const char *);
extern char *fgets(char *,int,void *);
extern int fclose(void *),sscanf(const char *,const char *,...);
extern int __android_log_write(int,const char *,const char *);
#include "harness_bytes.h"
#define EXPORT __attribute__((visibility("default")))
static volatile int started,mono_ready,login_busy;
static void *game_image,*bridge;
static void *resolve_method,*prepare_method,*complete_method,*tree_method;
static u32 account_handle;
static char log_path[512];
static int secondary_ready,bridge_ready;

static void *(*root_domain)(void),*(*current_domain)(void);
static void (*assemblies)(void (*)(void *,void *),void *);
static void *(*assembly_image)(void *);
static const char *(*image_name)(void *);
static void *(*class_name)(void *,const char *,const char *);
static void *(*method_name)(void *,const char *,int);
static void *(*compile_method)(void *);
static void *(*invoke_method)(void *,void *,void **,void **);
static void *(*image_data)(char *,u32,int,int *,int);
static void *(*load_assembly)(void *,const char *,int *,int);
static u32 (*handle_new)(void *,int);
static void *(*handle_target)(u32);
static void (*handle_free)(u32);
static void (*barrier_store)(void *,void *);
static void *(*object_string)(void *,void **);
static char *(*string_utf8)(void *);
static void (*mono_free)(void *);

static void copy(void *dst,const void *src,u32 count){u8 *d=dst;const u8 *s=src;while(count--)*d++=*s++;}
static int same(const char *a,const char *b){while(*a&&*a==*b){++a;++b;}return *a==*b;}
static void log_text(const char *s){
    __android_log_write(4,"LGWXLocalLogin",s);
    if(!log_path[0])return;
    int fd=open(log_path,1|0x40|0x400|0x80000,0600);
    if(fd<0)return;u32 n=0;while(s[n])++n;
    write(fd,s,n);write(fd,"\n",1);close(fd);
}
static void exception_log(const char *stage,void *exception){
    log_text(stage);
    if(!exception||!object_string||!string_utf8||!mono_free)return;
    void *nested=(void *)0,*str=object_string(exception,&nested);
    if(!str||nested)return;
    char *text=string_utf8(str);if(text){log_text(text);mono_free(text);}
}
static void *call(void *method,void **args,const char *stage,int *ok){
    void *exception=(void *)0;
    void *result=invoke_method(method,(void *)0,args,&exception);
    *ok=!exception;if(exception)exception_log(stage,exception);return result;
}
static int ensure_secondary_hooks(void);
static int ensure_bridge(void);

/* 替换完整入口。 */
static int get_record_hook(void *self,void **out){
    (void)self;
    void *account=account_handle?handle_target(account_handle):(void *)0;
    if(!account||!out)return 7;
    barrier_store(out,account);return 0;
}
static void dns_hook(void *self,void *address){(void)self;(void)address;}
static void *tree_hook(void *holder,int platform){
    void *args[2]={holder,&platform};int ok=0;
    void *result=call(tree_method,args,"Tree callback failed",&ok);
    if(ok)log_text("Original CreateConnect called by the local tree callback");
    return result;
}

/* 只接管登录入口，其他导入沿用原库。 */
EXPORT void lgwx_apollo_account_login(u64 object_id,int platform){
    char message[192];
    snprintf(message,sizeof(message),"v1.0.0.0 Native SDK Login intercepted; platform=%d object=%llu",platform,object_id);
    log_text(message);
    if(!__atomic_load_n(&mono_ready,__ATOMIC_ACQUIRE)){log_text("Mono binding is not ready; SDK login suppressed");return;}
    if(__atomic_exchange_n(&login_busy,1,__ATOMIC_ACQ_REL)){log_text("A local login callback is already running");return;}
    u32 holder_handle=0,next=0;
    int ok=0;
    if(!current_domain()){log_text("Login caller has no current Mono domain");goto done;}
    if(!ensure_bridge())goto done;
    void *resolve_args[1]={&object_id};
    void *holder=call(resolve_method,resolve_args,"ResolveHolder failed",&ok);
    if(!ok||!holder)goto done;
    holder_handle=handle_new(holder,0);
    if(!holder_handle){log_text("Holder GC handle allocation failed");goto done;}
    void *args[2]={handle_target(holder_handle),&platform};
    void *account=call(prepare_method,args,"Prepare failed",&ok);
    if(!ok||!account){if(ok)log_text("No cached local identity; select QQ or WeChat manually");goto done;}
    next=handle_new(account,0);
    if(!next){log_text("Account GC handle allocation failed");goto done;}
    if(!ensure_secondary_hooks()){log_text("Secondary hook installation failed; login callback was not sent");goto done;}
    u32 previous=account_handle;account_handle=next;next=0;if(previous)handle_free(previous);
    void *complete_args[2]={handle_target(holder_handle),handle_target(account_handle)};
    call(complete_method,complete_args,"Login callback failed",&ok);
    if(ok)log_text("Local platform callback dispatched; real server response is still required");
done:
    if(next)handle_free(next);
    if(holder_handle)handle_free(holder_handle);
    __atomic_store_n(&login_busy,0,__ATOMIC_RELEASE);
}

struct Patch {void *code;u32 length;u8 saved[12];int installed;};
static struct Patch patches[4];
static int page_permissions(u32 address){
    void *file=fopen("/proc/self/maps","r");if(!file)return -1;
    char line[512],flags[5];u32 begin,end;int permissions=-1;
    while(fgets(line,sizeof(line),file)){
        if(sscanf(line,"%x-%x %4s",&begin,&end,flags)==3&&address>=begin&&address<end){
            permissions=(flags[0]=='r'?1:0)|(flags[1]=='w'?2:0)|(flags[2]=='x'?4:0);break;
        }
    }fclose(file);return permissions;
}
static void cache_flush(void *start,void *end){
    register u32 a __asm__("r0")=(u32)start;
    register u32 b __asm__("r1")=(u32)end;
    register u32 c __asm__("r2")=0;
    register u32 nr __asm__("r7")=0x0f0002;
    __asm__ volatile("svc 0" : "+r"(a) : "r"(b),"r"(c),"r"(nr) : "memory","cc");
}
static int overwrite(void *address,const u8 *bytes,u32 size){
    u32 start=(u32)address,page_size=(u32)getpagesize();if(!page_size)return 0;
    u32 page=start&~(page_size-1),end=(start+size+page_size-1)&~(page_size-1);
    int original=page_permissions(start);if(original<0)return 0;
    if(mprotect((void *)page,end-page,original|7)!=0)return 0;
    copy(address,bytes,size);cache_flush(address,(u8 *)address+size);
    if(mprotect((void *)page,end-page,original)!=0)log_text("Could not restore code page permissions");
    return 1;
}
static int patch_code(struct Patch *patch,u32 entry,void *replacement){
    if(!entry)return 0;
    u32 address=entry&~1U;u8 jump[12]={0};u32 offset=0;
    if(entry&1){
        if(address&2){jump[0]=0x00;jump[1]=0xbf;offset=2;}
        jump[offset]=0xdf;jump[offset+1]=0xf8;jump[offset+2]=0;jump[offset+3]=0xf0;
    }else{u32 instruction=0xe51ff004;copy(jump,&instruction,4);}
    u32 target=(u32)replacement;copy(jump+offset+4,&target,4);
    patch->code=(void *)address;patch->length=offset+8;
    copy(patch->saved,patch->code,patch->length);
    if(!overwrite(patch->code,jump,patch->length))return 0;
    patch->installed=1;return 1;
}
static int patch_method(struct Patch *patch,void *method,void *replacement){
    return patch_code(patch,(u32)compile_method(method),replacement);
}
static void rollback_secondary(void){
    for(int i=2;i>=0;--i)if(patches[i].installed){
        if(overwrite(patches[i].code,patches[i].saved,patches[i].length))patches[i].installed=0;
        else log_text("Could not restore a secondary hook");
    }
}
/* 在原登录线程安装。 */
static int ensure_secondary_hooks(void){
    if(secondary_ready)return 1;
    log_text("Installing account/tree/DNS hooks on the original login thread");
    void *holder=class_name(game_image,"","NetworkHolder");
    void *service=class_name(game_image,"Apollo","ApolloAccountService");
    if(!holder||!service){log_text("NetworkHolder or ApolloAccountService metadata missing");return 0;}
    void *record=method_name(service,"GetRecord",1),*tree=method_name(holder,"GetPlatTreeInfo",1);
    void *dns=method_name(holder,"OnServerDnsBack",1);
    if(!record||!tree||!dns){log_text("Account/tree/DNS method metadata missing");return 0;}
    if(!patch_method(&patches[0],record,(void *)get_record_hook)||
       !patch_method(&patches[1],tree,(void *)tree_hook)||
       !patch_method(&patches[2],dns,(void *)dns_hook)){
        rollback_secondary();return 0;
    }
    secondary_ready=1;log_text("Account/tree/DNS hooks installed");return 1;
}
static void find_game(void *assembly,void *unused){
    (void)unused;
    void *image=assembly_image(assembly);if(!image)return;
    const char *name=image_name(image);
    if(name&&(same(name,"Assembly-CSharp")||same(name,"Assembly-CSharp.dll")))game_image=image;
}
static int ensure_bridge(void){
    if(bridge_ready)return 1;
    assemblies(find_game,(void *)0);
    if(!game_image){log_text("Loaded Assembly-CSharp image not found");return 0;}
    int status=0;
    void *helper_image=image_data((char *)harness_bytes,sizeof(harness_bytes),1,&status,0);
    if(!helper_image||status){log_text("Cannot load embedded helper image");return 0;}
    if(!load_assembly(helper_image,"LocalLoginHarness.dll",&status,0)||status){log_text("Cannot load embedded helper assembly");return 0;}
    bridge=class_name(helper_image,"LocalLoginHarness","Bridge");
    if(!bridge){log_text("Embedded Bridge class unavailable");return 0;}
    resolve_method=method_name(bridge,"ResolveHolder",1);
    prepare_method=method_name(bridge,"Prepare",2);complete_method=method_name(bridge,"Complete",2);tree_method=method_name(bridge,"Tree",2);
    if(!resolve_method||!prepare_method||!complete_method||!tree_method){log_text("Embedded helper methods are missing");return 0;}
    bridge_ready=1;log_text("Embedded helper loaded on the original login thread");return 1;
}
static int make_log(void){
    char package[256];int fd=open("/proc/self/cmdline",0x80000);if(fd<0)return 0;
    int n=read(fd,package,sizeof(package)-1);close(fd);if(n<=0)return 0;package[n]=0;
    for(u32 i=0;package[i];++i){
        char c=package[i];if(c==':'){package[i]=0;break;}
        if(!((c>='a'&&c<='z')||(c>='A'&&c<='Z')||(c>='0'&&c<='9')||c=='.'||c=='_'))return 0;
    }
    if(!same(package,"com.tencent.LEGOCUBEPreview"))return 0;
    snprintf(log_path,sizeof(log_path),"/data/data/%s/files/local_login_hook.log",package);
    return 1;
}
static int bind_mono(void *library){
#define BIND(variable,name) variable=(__typeof__(variable))dlsym(library,name);if(!variable)return 0
    BIND(root_domain,"mono_get_root_domain");BIND(current_domain,"mono_domain_get");
    BIND(assemblies,"mono_assembly_foreach");BIND(assembly_image,"mono_assembly_get_image");
    BIND(image_name,"mono_image_get_name");BIND(class_name,"mono_class_from_name");
    BIND(method_name,"mono_class_get_method_from_name");BIND(compile_method,"mono_compile_method");
    BIND(invoke_method,"mono_runtime_invoke");
    BIND(image_data,"mono_image_open_from_data_full");BIND(load_assembly,"mono_assembly_load_from_full");
    BIND(handle_new,"mono_gchandle_new");BIND(handle_target,"mono_gchandle_get_target");
    BIND(handle_free,"mono_gchandle_free");BIND(barrier_store,"mono_gc_wbarrier_generic_store");
    object_string=(__typeof__(object_string))dlsym(library,"mono_object_to_string");
    string_utf8=(__typeof__(string_utf8))dlsym(library,"mono_string_to_utf8");
    mono_free=(__typeof__(mono_free))dlsym(library,"mono_free");return 1;
#undef BIND
}
static void *worker(void *unused){
    (void)unused;if(!make_log())return (void *)0;
    log_text("Starting v1.0.0.0 ARMv7 native local login hook; endpoint from local_server.txt");
    log_text("v1.0.0.0 DllImport mappings are unchanged; SDK startup and UI account lookup use the original library");
    void *library=(void *)0;
    int bound=0;
    for(u32 i=0;i<3000;++i){
        if(!library)library=dlopen("libmono.so",2|4);
        if(library&&bind_mono(library)&&root_domain()){bound=1;break;}
        usleep(100000);
    }
    if(!bound){log_text("Mono or required exports were not available within 300 seconds");return (void *)0;}
    __atomic_store_n(&mono_ready,1,__ATOMIC_RELEASE);
    log_text("v1.0.0.0 Waiting for an already loaded libMsdkAdapter.so; no game method is compiled on this worker");
    for(u32 i=0;i<30000;++i){
        void *sdk=dlopen("libMsdkAdapter.so",2|4);
        if(sdk){
            void *entry=dlsym(sdk,"apollo_account_login");
            if(!entry){log_text("libMsdkAdapter.so has no apollo_account_login export");return (void *)0;}
            if(!patch_code(&patches[3],(u32)entry,(void *)lgwx_apollo_account_login)){
                log_text("Could not patch native login entry; Login hook is not installed");return (void *)0;
            }
            log_text("v1.0.0.0 Native login hook installed; SDK imports remain directed to the original library");
            return (void *)0;
        }
        usleep(10000);
    }
    log_text("Native SDK was not loaded within 300 seconds; Login hook is not installed");
    return (void *)0;
}
EXPORT int local_login_hook_start(void){
    if(__atomic_exchange_n(&started,1,__ATOMIC_ACQ_REL))return 1;
    pthread_t thread;if(pthread_create(&thread,(void *)0,worker,(void *)0)!=0){__atomic_store_n(&started,0,__ATOMIC_RELEASE);return -1;}
    pthread_detach(thread);return 0;
}
__attribute__((constructor))static void initialize(void){local_login_hook_start();}
EXPORT int JNI_OnLoad(void *vm,void *reserved){(void)vm;(void)reserved;local_login_hook_start();return 0x10006;}
