@pushd %~dp0

%windir%\Microsoft.NET\Framework\v4.0.30319\MSBuild.exe "Par_Automation.csproj"

@if ERRORLEVEL 1 goto end

@cd ..\packages\SpecRun.Runner.*\tools

@set profile=%1
@if "%profile%" == "" set profile=Default

SpecRun.exe register KDtcgzKQi5gXdIcss+qAWuXycZpOgSVQVLe4LX+U4vv+13JzjHZA8qQBAbH0AAAAAA== "mrench@xpanxion.com"
SpecRun.exe run %profile%.srprofile "/baseFolder:%~dp0\bin\Debug" /log:specrun.log %2 %3 %4 %5

:end

@popd