#!/bin/bash

# Build script for AngeneHost on Linux/macOS

echo "Building AngeneHost with Mono..."

# Detect platform
if [[ "$OSTYPE" == "linux-gnu"* ]]; then
    PLATFORM="Linux"
    PKG_CONFIG="pkg-config"
elif [[ "$OSTYPE" == "darwin"* ]]; then
    PLATFORM="macOS"
    PKG_CONFIG="pkg-config"
else
    echo "Unsupported platform: $OSTYPE"
    exit 1
fi

echo "Platform: $PLATFORM"

# Check if Mono is installed
if ! command -v mono &> /dev/null; then
    echo "ERROR: Mono is not installed!"
    echo ""
    if [[ "$PLATFORM" == "Linux" ]]; then
        echo "Install Mono on Ubuntu/Debian:"
        echo "  sudo apt-get install mono-devel"
        echo ""
        echo "Install Mono on Fedora:"
        echo "  sudo dnf install mono-devel"
    else
        echo "Install Mono on macOS:"
        echo "  brew install mono"
    fi
    exit 1
fi

# Check if pkg-config can find mono-2
if ! $PKG_CONFIG --exists mono-2; then
    echo "ERROR: Mono development libraries not found!"
    echo "Make sure mono-devel is installed"
    exit 1
fi

echo "Mono version: $(mono --version | head -n1)"

# Get Mono compiler flags
MONO_CFLAGS=$($PKG_CONFIG --cflags mono-2)
MONO_LIBS=$($PKG_CONFIG --libs mono-2)

echo "Compiling..."

# Compile with g++
g++ -std=c++17 -Wall -O2 \
    $MONO_CFLAGS \
    AngeneHostLin.cpp \
    $MONO_LIBS \
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
else
    echo ""
    echo "Build failed!"
    exit 1
fi