#!/bin/sh
clear
dotnet clean "Angene.sln"
dotnet publish "Angene.sln" -c Release -r linux-x64 -p:AngenePlatform=Linux -o "..\..\Build\Angene\Lin" -p:WarningLevel=0
dotnet publish "Angene.sln" -c Release -r win-x64 -p:AngenePlatform=Windows -o "..\..\Build\Angene\Win" -p:WarningLevel=0
python3 treegen.py ./* --one-file --gfm --outdir ../