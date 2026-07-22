@echo off
cls
dotnet publish "Angene.sln" -c Release -r win-x64 -o "..\Build\win-x64\Angene"
dotnet publish "AngeneEditor\AngeneEditor.sln" -c Release -r win-x64 -o "..\Build\win-x64\AngeneEditor"