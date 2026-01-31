# Angene/__init__.py
# Angene Game Engine - VR Edition

"""
Angene Game Engine

A lightweight game engine with OpenXR VR support.

Quick VR Example:
    from Angene.Custom import openxr
    
    class MyVRGame:
        def render_eye(self, eye_index, texture, width, height, view, proj):
            pass  # Your VR rendering here
    
    openxr.quick_start(MyVRGame, "My VR App")

For 2D games:
    from Angene.Main import engine, painter
    
    # Use the traditional Angene engine
"""

# Version
__version__ = "2.0.0-vr"

# Main engine modules
from Angene.Main import painter, engine, definitions

# Renderer modules
from Angene.Renderers import d3d11, d3d11_vr, opengl3d

# VR/OpenXR modules
from Angene.Custom import openxr, openxr_ctypes

# Convenience imports for common usage
try:
    # Optional: make VR super easy to access
    VRSession = openxr.VRSession
    quick_start_vr = openxr.quick_start
except:
    # VR not available or dependencies missing
    VRSession = None
    quick_start_vr = None

# Public API
__all__ = [
    # Core engine
    'engine',
    'definitions',
    'painter',
    
    # Renderers
    'd3d11',
    'd3d11_vr',
    'opengl3d',
    
    # VR/OpenXR
    'openxr',
    'openxr_ctypes',
    'VRSession',
    'quick_start_vr',
    
    # Meta
    '__version__',
]


# Print helpful info when imported
def _show_welcome():
    """Show welcome message with usage hints"""
    import sys
    
    # Only show in interactive mode
    if hasattr(sys, 'ps1'):
        print("Angene Game Engine v" + __version__)
        print("-------------------------------------------")
        print("""
Angene Game Engine

A lightweight game engine with OpenXR VR support.

Quick VR Example:
    from Angene.Custom import openxr
    
    class MyVRGame:
        def render_eye(self, eye_index, texture, width, height, view, proj):
            pass  # Your VR rendering here
    
    openxr.quick_start(MyVRGame, "My VR App")

For 2D games:
    from Angene.Main import engine, painter
    
    # Use the traditional Angene engine
""")

# Optionally show welcome (can be disabled)
try:
    import os
    if os.environ.get('ANGENE_QUIET') != '1':
        _show_welcome()
except:
    pass