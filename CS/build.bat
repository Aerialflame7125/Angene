@echo off
dotnet publish "Angene.sln" -c Release -o "..\Build\"
dotnet publish "AngeneEditor\AngeneEditor.sln" -c Release -o "..\Build\"