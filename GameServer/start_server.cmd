@echo off
setlocal
cd /d "%~dp0"
if not exist "v1.0.0.0\LocalGameServer.exe" (
  echo Missing v1.0.0.0\LocalGameServer.exe. Run build.ps1 first.
  pause
  exit /b 1
)
"v1.0.0.0\LocalGameServer.exe" --config "%~dp0server.json"
set "game_server_exit=%errorlevel%"
if not "%game_server_exit%"=="0" pause
exit /b %game_server_exit%
