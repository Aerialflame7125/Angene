@echo off
setlocal enabledelayedexpansion

echo ================================
echo   Angene Package Compiler
echo ================================
echo.

REM Prompt for input folder
set /p INPUT_FOLDER="Enter the folder path to pack: "

REM Remove quotes if user added them
set INPUT_FOLDER=%INPUT_FOLDER:"=%

REM Check if folder exists
if not exist "%INPUT_FOLDER%" (
    echo.
    echo ERROR: Folder does not exist: %INPUT_FOLDER%
    echo.
    pause
    exit /b 1
)

REM Generate output filename based on folder name
for %%I in ("%INPUT_FOLDER%") do set FOLDER_NAME=%%~nxI
set OUTPUT_FILE=%FOLDER_NAME%.angpkg

echo.
echo Input Folder: %INPUT_FOLDER%
echo Output File:  %OUTPUT_FILE%
echo.

REM Ask for compression
set /p USE_COMPRESS="Enable compression? (Y/N, default=Y): "
if /i "%USE_COMPRESS%"=="" set USE_COMPRESS=Y

REM Ask for encryption
set /p USE_ENCRYPT="Enable encryption? (Y/N, default=N): "
if /i "%USE_ENCRYPT%"=="" set USE_ENCRYPT=N

REM Build command
set COMMAND=AngeneCompiler.exe pack "%INPUT_FOLDER%" "%OUTPUT_FILE%"

if /i "%USE_COMPRESS%"=="Y" (
    set COMMAND=!COMMAND! --compress
)

if /i "%USE_ENCRYPT%"=="Y" (
    set /p ENCRYPTION_KEY="Enter encryption key (hex, 16/24/32 bytes): "
    set COMMAND=!COMMAND! --encrypt --key !ENCRYPTION_KEY!
)

echo.
echo ================================
echo Executing:
echo !COMMAND!
echo ================================
echo.

REM Execute the command
!COMMAND!

echo.
if %ERRORLEVEL% EQU 0 (
    echo ================================
    echo   Packing completed successfully!
    echo ================================
) else (
    echo ================================
    echo   Packing failed with error code: %ERRORLEVEL%
    echo ================================
)

echo.
pause