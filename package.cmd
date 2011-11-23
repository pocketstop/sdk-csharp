nuget.exe update -self

if not exist download mkdir download
if not exist download\package mkdir download\package
if not exist download\package\pocketstop mkdir download\package\pocketstop

if not exist download\package\pocketstop\lib mkdir download\package\pocketstop\lib
if not exist download\package\pocketstop\lib\3.5 mkdir download\package\pocketstop\lib\3.5
if not exist download\package\pocketstop\lib\4.0 mkdir download\package\pocketstop\lib\4.0

tools\ilmerge.exe /lib:src\Pocketstop.Api\bin\Release /internalize /ndebug /v2 /out:download\Pocketstop.Api.dll Pocketstop.Api.dll RestSharp.dll

copy src\Pocketstop.Api\bin\Release\*.* download
copy LICENSE.txt download

copy src\Pocketstop.Api\bin\Release\Pocketstop.Api.* download\package\pocketstop\lib\3.5\
copy src\Pocketstop.Api.Net4\bin\Release\Pocketstop.Api.* download\package\pocketstop\lib\4.0\

nuget.exe pack Pocketstop.nuspec -BasePath download\package\pocketstop -o download