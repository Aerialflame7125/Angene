@echo off
cls
dotnet clean "Angene.sln"
dotnet clean "AngeneEditor\AngeneEditor.sln"
dotnet publish "Angene.sln" -c Release -o "..\Build\Angene"
dotnet publish "AngeneEditor\AngeneEditor.sln" -c Release -r win-x64 -o "..\Build\win-x64\AngeneEditor"
