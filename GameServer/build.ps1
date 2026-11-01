param([string]$Runtime = 'win-x64')
$ErrorActionPreference = 'Stop'
$projectRoot = $PSScriptRoot
$project = Join-Path $projectRoot 'src\LocalGameServer.csproj'
$output = Join-Path $projectRoot 'v1.0.0.0'
$artifacts = Join-Path $projectRoot '..\.build\server'
# 仅编译发布，不启动服务端。
& dotnet publish $project -c Release -r $Runtime --self-contained true -o $output --nologo -v minimal -p:DebugType=None -p:DebugSymbols=false -p:UseArtifactsOutput=true "-p:ArtifactsPath=$artifacts"
if ($LASTEXITCODE -ne 0) { throw 'dotnet publish failed.' }
Write-Host "Published to $output. Start with start_server.cmd."
