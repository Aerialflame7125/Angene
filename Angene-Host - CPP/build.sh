#!/bin/bash

# Build script for AngeneHost on Linux using CoreCLR/hostfxr

echo "Building AngeneHost (CoreCLR)..."

if [[ "$OSTYPE" != "linux-gnu"* ]]; then
    echo "This build script targets Linux only."
    exit 1
fi

# Locate a .NET SDK/runtime install to find the hostfxr headers.
# hostfxr.h and coreclr_delegates.h are plain, dependency-free headers from
# the dotnet/runtime repo. If you don't already have local copies (e.g. from
# your Windows host project), place them next to this script or point
# HOSTFXR_HEADERS at a directory containing them.

HEADER_DIR="${HOSTFXR_HEADERS:-.}"

if [[ ! -f "$HEADER_DIR/hostfxr.h" || ! -f "$HEADER_DIR/coreclr_delegates.h" ]]; then
    echo "ERROR: hostfxr.h / coreclr_delegates.h not found in $HEADER_DIR"
    echo "Copy them from your Windows host project, or download from:"
    echo "  https://github.com/dotnet/runtime/blob/main/src/native/corehost/hostfxr.h"
    echo "  https://github.com/dotnet/runtime/blob/main/src/native/corehost/coreclr_delegates.h"
    echo "Then set HOSTFXR_HEADERS=/path/to/dir and rerun, or copy them into this directory."
    exit 1
fi

echo "Using headers from: $HEADER_DIR"
echo "Compiling..."

g++ -std=c++17 -Wall -O2 \
    -I"$HEADER_DIR" \
    AngeneHostLinCPP.cpp \
    -ldl \
    -o AngeneHost

if [ $? -eq 0 ]; then
    echo ""
    echo "=========================================="
    echo "Build successful!"
    echo "=========================================="
    echo "Output: ./AngeneHost"
    echo ""
    echo "Run with:"
    echo "  ./AngeneHost [arguments]"
    echo ""
    echo "Note: requires a .NET 8 runtime installed and discoverable via"
    echo "DOTNET_ROOT, or in /usr/lib/dotnet, /usr/share/dotnet, or ~/.dotnet"
else
    echo ""
    echo "Build failed!"
    exit 1
fi
