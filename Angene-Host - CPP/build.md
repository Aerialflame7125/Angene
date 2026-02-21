Windows:
cl.exe /EHsc /W3 /std:c++17 /D UNICODE /D _UNICODE /favor:amd64 .\AngeneHostWinCPP.cpp /link mscoree.lib nethost.lib /OUT:AngeneHost.exe

Linux:
./build.sh