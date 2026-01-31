Windows:
cl.exe /EHsc /W3 /std:c++17 /D UNICODE /D _UNICODE .\AngeneHostWin.cpp /link mscoree.lib /OUT:AngeneHost.exe

Linux:
./build.sh