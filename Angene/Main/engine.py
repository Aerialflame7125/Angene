# Angene\window.py
import threading
import sys
import ctypes
from Angene.Main import painter
import time
import traceback
from Angene.Main.definitions import *

# hook into dlls with definitions
user32 = ctypes.WinDLL('user32', use_last_error=True)
gdi32 = ctypes.WinDLL('gdi32', use_last_error=True)
kernel32 = ctypes.WinDLL('kernel32', use_last_error=True)

# Add crash handler
def exception_hook(exctype, value, tb):
    """Custom exception handler to catch crashes"""
    print("=" * 60)
    print("Angene Crash Traceback:")
    print("=" * 60)
    print(f"Exception type: {exctype}")
    print(f"Exception value: {value}")
    print("Traceback:")
    traceback.print_tb(tb)

sys.excepthook = exception_hook

current_scene = None
scene_started = False

last_time = time.perf_counter()

class Window:
    hwnd = None
    scene = None
    width = 0
    height = 0
    mem_dc = None
    bmp = None
    old_bmp = None
    scene_started = False
    is_3d = False  # Flag to determine rendering mode

    def __init__(self, title, width, height, use_3d=False):
        self.hwnd = create_new_window(title, width, height)
        self.width = width
        self.height = height
        self.scene_started = False
        self.is_3d = use_3d
        window_map[self.hwnd] = self

        # Only create memory DC for 2D rendering
        if not use_3d:
            hdc = user32.GetDC(self.hwnd)
            self.mem_dc = gdi32.CreateCompatibleDC(hdc)
            self.bmp = gdi32.CreateCompatibleBitmap(hdc, width, height)
            self.old_bmp = gdi32.SelectObject(self.mem_dc, self.bmp)
            user32.ReleaseDC(self.hwnd, hdc)

    def cleanup(self):
        # Only cleanup memory DC if 2D
        if not self.is_3d:
            if self.old_bmp:
                gdi32.SelectObject(self.mem_dc, self.old_bmp)
            if self.bmp:
                gdi32.DeleteObject(self.bmp)
            if self.mem_dc:
                gdi32.DeleteDC(self.mem_dc)
        
        # Cleanup 3D renderer if present
        if self.scene and hasattr(self.scene, 'renderer_3d') and self.scene.renderer_3d:
            self.scene.renderer_3d.cleanup()
    
    def set_scene(self, scene):
        self.scene = scene
        self.scene_started = False

# Define GetGuiResources for monitoring GDI objects
user32.GetGuiResources = user32.GetGuiResources
user32.GetGuiResources.argtypes = [ctypes.c_void_p, ctypes.c_uint]
user32.GetGuiResources.restype = ctypes.c_ulong

GR_GDIOBJECTS = 0
GR_USEROBJECTS = 1

def get_gdi_object_count():
    """Get current GDI object count for this process"""
    process = kernel32.GetCurrentProcess()
    return user32.GetGuiResources(process, GR_GDIOBJECTS)

kernel32.GetCurrentProcess.argtypes = []
kernel32.GetCurrentProcess.restype = ctypes.c_void_p

# GDI fixes for x64 compatibility
SelectObject = gdi32.SelectObject
SelectObject.argtypes = [ctypes.c_void_p, ctypes.c_void_p]
SelectObject.restype = ctypes.c_void_p

CreateSolidBrush = gdi32.CreateSolidBrush
CreateSolidBrush.argtypes = [ctypes.c_ulong]
CreateSolidBrush.restype = ctypes.c_void_p

DeleteObject = gdi32.DeleteObject
DeleteObject.argtypes = [ctypes.c_void_p]
DeleteObject.restype = ctypes.c_bool

# Define GetDC and ReleaseDC properly
user32.GetDC.argtypes = [ctypes.c_void_p]
user32.GetDC.restype = ctypes.c_void_p

user32.ReleaseDC.argtypes = [ctypes.c_void_p, ctypes.c_void_p]
user32.ReleaseDC.restype = ctypes.c_int

# Define CreateCompatibleDC and CreateCompatibleBitmap
gdi32.CreateCompatibleDC.argtypes = [ctypes.c_void_p]
gdi32.CreateCompatibleDC.restype = ctypes.c_void_p

gdi32.CreateCompatibleBitmap.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.c_int]
gdi32.CreateCompatibleBitmap.restype = ctypes.c_void_p

gdi32.DeleteDC.argtypes = [ctypes.c_void_p]
gdi32.DeleteDC.restype = ctypes.c_bool

# Define BitBlt properly
gdi32.BitBlt.argtypes = [
    ctypes.c_void_p,  # hdcDest
    ctypes.c_int,     # nXDest
    ctypes.c_int,     # nYDest
    ctypes.c_int,     # nWidth
    ctypes.c_int,     # nHeight
    ctypes.c_void_p,  # hdcSrc
    ctypes.c_int,     # nXSrc
    ctypes.c_int,     # nYSrc
    ctypes.c_ulong    # dwRop
]
gdi32.BitBlt.restype = ctypes.c_bool


# Define WndProc with CORRECT signature
WNDPROC = ctypes.WINFUNCTYPE(
    ctypes.c_longlong,      # LRESULT (return type)
    ctypes.c_void_p,        # HWND
    ctypes.c_uint,          # UINT (message)
    ctypes.c_ulonglong,     # WPARAM (64-bit)
    ctypes.c_longlong       # LPARAM (64-bit)
)

# Classes
class RECT(ctypes.Structure):
    _fields_ = [("left", ctypes.c_long),
                ("top", ctypes.c_long),
                ("right", ctypes.c_long),
                ("bottom", ctypes.c_long)]


class PAINTSTRUCT(ctypes.Structure):
    _fields_ = [
        ("hdc", ctypes.c_void_p),
        ("fErase", ctypes.c_bool),
        ("rcPaint", RECT),
        ("fRestore", ctypes.c_bool),
        ("fIncUpdate", ctypes.c_bool),
        ("rgbReserved", ctypes.c_byte * 32),
    ]

CreateWindowExW = user32.CreateWindowExW
GetMessage = user32.GetMessageW
TranslateMessage = user32.TranslateMessage
DispatchMessage = user32.DispatchMessageW
PeekMessageW = user32.PeekMessageW

# Properly define DefWindowProcW FIRST
DefWindowProcW = user32.DefWindowProcW
DefWindowProcW.argtypes = [
    ctypes.c_void_p,        # HWND
    ctypes.c_uint,          # UINT (message)
    ctypes.c_ulonglong,     # WPARAM
    ctypes.c_longlong       # LPARAM
]
DefWindowProcW.restype = ctypes.c_longlong

BeginPaint = user32.BeginPaint
BeginPaint.argtypes = [ctypes.c_void_p, ctypes.POINTER(PAINTSTRUCT)]
BeginPaint.restype = ctypes.c_void_p

EndPaint = user32.EndPaint
EndPaint.argtypes = [ctypes.c_void_p, ctypes.POINTER(PAINTSTRUCT)]
EndPaint.restype = ctypes.c_bool

window_map = {}

# Window message loop
def WndProc(hwnd, msg, wParam, lParam):
    window_instance = window_map.get(hwnd)
    if not window_instance:
        return DefWindowProcW(hwnd, msg, wParam, lParam)

    # Only handle window lifecycle messages
    # NOT WM_PAINT - we'll render directly
    if msg == WM_CLOSE:
        if window_instance:
            if (window_instance.scene and window_instance.scene_started and hasattr(window_instance.scene, 'OnApplicationQuit')):
                window_instance.scene.OnApplicationQuit()
            window_instance.cleanup()
        user32.DestroyWindow(hwnd)
        return 0

    if msg == WM_DESTROY:
        user32.PostQuitMessage(0)
        return 0
    
    if msg == WM_ERASEBKGND:
        return 1  # Indicate background erased

    # Let Windows handle WM_PAINT with default behavior
    # We'll render directly in the main loop instead
    return DefWindowProcW(hwnd, msg, wParam, lParam)

wndproc_pointer = WNDPROC(WndProc)
_g_references = [wndproc_pointer]

class WndClassEx(ctypes.Structure):
    _fields_ = [
        ("cbSize", ctypes.c_uint),
        ("style", ctypes.c_uint),
        ("lpfnWndProc", WNDPROC),
        ("cbClsExtra", ctypes.c_int),
        ("cbWndExtra", ctypes.c_int),
        ("hInstance", ctypes.c_void_p),
        ("hIcon", ctypes.c_void_p),
        ("hCursor", ctypes.c_void_p),
        ("hbrBackground", ctypes.c_void_p),
        ("lpszMenuName", ctypes.c_wchar_p),
        ("lpszClassName", ctypes.c_wchar_p),
        ("hIconSm", ctypes.c_void_p)
    ]

# Get hInstance ONCE at module level
hInstance = kernel32.GetModuleHandleW(None)

# Register Window Class
wc = WndClassEx()
wc.cbSize = ctypes.sizeof(WndClassEx)
wc.style = 0x0003  # CS_HREDRAW | CS_VREDRAW
wc.lpfnWndProc = wndproc_pointer
wc.cbClsExtra = 0
wc.cbWndExtra = 0
wc.hInstance = hInstance
wc.hIcon = None
wc.hCursor = user32.LoadCursorW(None, 32512)
wc.hbrBackground = None  # We handle our own background
wc.lpszMenuName = None
wc.lpszClassName = "AngeneClass"
wc.hIconSm = None

atom = user32.RegisterClassExW(ctypes.byref(wc))
if not atom:
    raise ctypes.WinError(ctypes.get_last_error())

print("Window class registered successfully")

# Types
class tagMSG(ctypes.Structure):
    _fields_ = [
        ("hwnd", ctypes.c_void_p),
        ("message", ctypes.c_uint),
        ("wParam", ctypes.c_ulonglong),
        ("lParam", ctypes.c_longlong),
        ("time", ctypes.c_ulong),
        ("pt_x", ctypes.c_long),
        ("pt_y", ctypes.c_long)
    ]

# Set up CreateWindowExW properly
CreateWindowExW.restype = ctypes.c_void_p
CreateWindowExW.argtypes = [
    ctypes.c_ulong,        # dwExStyle
    ctypes.c_wchar_p,      # lpClassName
    ctypes.c_wchar_p,      # lpWindowName
    ctypes.c_ulong,        # dwStyle
    ctypes.c_int,          # X
    ctypes.c_int,          # Y
    ctypes.c_int,          # nWidth
    ctypes.c_int,          # nHeight
    ctypes.c_void_p,       # hWndParent
    ctypes.c_void_p,       # hMenu
    ctypes.c_void_p,       # hInstance
    ctypes.c_void_p        # lpParam
]

GetMessage.argtypes = [
    ctypes.POINTER(tagMSG),
    ctypes.c_void_p,
    ctypes.c_uint,
    ctypes.c_uint
]
GetMessage.restype = ctypes.c_int

TranslateMessage.argtypes = [ctypes.POINTER(tagMSG)]
TranslateMessage.restype = ctypes.c_bool

DispatchMessage.argtypes = [ctypes.POINTER(tagMSG)]
DispatchMessage.restype = ctypes.c_longlong

# Painting functions
BeginPaint = user32.BeginPaint
BeginPaint.argtypes = [ctypes.c_void_p, ctypes.POINTER(PAINTSTRUCT)]
BeginPaint.restype = ctypes.c_void_p

EndPaint = user32.EndPaint
EndPaint.argtypes = [ctypes.c_void_p, ctypes.POINTER(PAINTSTRUCT)]
EndPaint.restype = ctypes.c_bool

PeekMessageW.argtypes = [
    ctypes.POINTER(tagMSG),
    ctypes.c_void_p,
    ctypes.c_uint,
    ctypes.c_uint,
    ctypes.c_uint
]
PeekMessageW.restype = ctypes.c_bool

user32.InvalidateRect.argtypes = [ctypes.c_void_p, ctypes.c_void_p, ctypes.c_bool]
user32.InvalidateRect.restype = ctypes.c_bool

PM_REMOVE = 0x0001

# Window constants
WS_OVERLAPPEDWINDOW = 0x00CF0000
CW_USEDEFAULT = ctypes.c_int(0x80000000).value
SW_SHOW = 5

ShowWindow = user32.ShowWindow
ShowWindow.argtypes = [ctypes.c_void_p, ctypes.c_int]
ShowWindow.restype = ctypes.c_bool

UpdateWindow = user32.UpdateWindow
UpdateWindow.argtypes = [ctypes.c_void_p]
UpdateWindow.restype = ctypes.c_bool

# Functions
def create_new_window(title="New Window", width=500, height=400, style=0):
    hwnd = CreateWindowExW(
        style,
        "AngeneClass",
        f"Angene | {title}",
        WS_OVERLAPPEDWINDOW,
        CW_USEDEFAULT,
        CW_USEDEFAULT,
        width,
        height,
        None,
        None,
        ctypes.c_void_p(hInstance),
        None
    )
    
    if not hwnd:
        raise ctypes.WinError(ctypes.get_last_error())
    
    ShowWindow(hwnd, SW_SHOW)
    UpdateWindow(hwnd)
    return hwnd

window = None

def init(title="Angene Window", width=800, height=600, style=0):
    global window
    window = create_new_window(title, width=width, height=height, style=style)

def run(target_fps=60):
    """
    Main engine loop with direct rendering (game engine style)
    
    Args:
        target_fps: Target frames per second (default: 60)
    """
    global last_time

    if not window_map:
        raise RuntimeError("Angene Logic Error | No windows created. Create a Window instance first.")

    msg = tagMSG()
    frame_count = 0
    frame_time = 1.0 / target_fps if target_fps > 0 else 0
    accumulator = 0.0
    last_gdi_check = time.perf_counter()
    
    print(f"Initial GDI objects: {get_gdi_object_count()}")
    print("Using DIRECT RENDERING (game engine mode)")
    
    # SRCCOPY constant for BitBlt
    SRCCOPY = 0x00CC0020
    
    try:
        while True:
            frame_start = time.perf_counter()
            
            # Process all pending messages (non-blocking)
            while PeekMessageW(ctypes.byref(msg), None, 0, 0, PM_REMOVE):
                if msg.message == WM_QUIT:
                    # Cleanup all windows
                    for w in window_map.values():
                        w.cleanup()
                    painter.Renderer.cleanup()
                    print(f"Final GDI objects: {get_gdi_object_count()}")
                    return
                
                if w.scene:
                    if hasattr(w.scene, "OnWindowMessage"):
                        w.scene.OnMessage(msg.hwnd, msg.message, msg.wParam, msg.lParam)
                TranslateMessage(ctypes.byref(msg))
                DispatchMessage(ctypes.byref(msg))

            # Calculate delta time
            now = time.perf_counter()
            dt = now - last_time
            last_time = now
            
            # Cap delta time
            if dt > 0.1:
                dt = 0.1

            accumulator += dt

            # Fixed timestep updates
            while accumulator >= frame_time:
                # UPDATE PHASE
                for w in window_map.values():
                    if w.scene:
                        # Call Start only once
                        if not w.scene_started:
                            if hasattr(w.scene, "Start"):
                                w.scene.Start()
                            w.scene_started = True

                        if hasattr(w.scene, "Update"):
                            w.scene.Update(frame_time)
                                
                        if hasattr(w.scene, "LateUpdate"):
                            w.scene.LateUpdate(frame_time)
                
                accumulator -= frame_time
                frame_count += 1
                
                # Monitor every 10 seconds
                if now - last_gdi_check >= 10.0:
                    gdi_count = get_gdi_object_count()
                    print(f"Frame {frame_count} | GDI: {gdi_count}")
                    last_gdi_check = now
            
            # RENDER PHASE - Direct rendering
            for w in window_map.values():
                if w.scene:
                    if w.is_3d:
                        # 3D OpenGL rendering - scene handles it directly
                        w.scene.OnDraw(None)
                    else:
                        # 2D GDI rendering
                        hdc = user32.GetDC(w.hwnd)
                        if hdc:
                            # Render to memory DC
                            renderer = painter.Renderer(w.mem_dc)
                            w.scene.OnDraw(renderer)
                            
                            # Blit memory DC to screen
                            gdi32.BitBlt(
                                hdc,
                                0, 0,
                                w.width, w.height,
                                w.mem_dc,
                                0, 0,
                                SRCCOPY
                            )
                            
                            # Release DC
                            user32.ReleaseDC(w.hwnd, hdc)
            
            # Sleep to maintain target FPS
            if target_fps > 0:
                frame_elapsed = time.perf_counter() - frame_start
                sleep_time = frame_time - frame_elapsed
                if sleep_time > 0:
                    time.sleep(sleep_time * 0.95)
    
    except KeyboardInterrupt:
        print("\nKeyboard interrupt received, shutting down...")
        for w in window_map.values():
            w.cleanup()
        painter.Renderer.cleanup()
    except Exception as e:
        print("=" * 60)
        print("FATAL ERROR IN MAIN LOOP!")
        print("=" * 60)
        print(f"Exception: {e}")
        traceback.print_exc()
        print("=" * 60)
        for w in window_map.values():
            try:
                w.cleanup()
            except:
                pass
        painter.Renderer.cleanup()

def set_resolution(hwnd, width, height):
    user32.SetWindowPos(
        hwnd,
        None,
        0, 0,
        width, height,
        0x0002  # SWP_NOMOVE
    )

def run_async(fn):
    threading.Thread(target=fn, daemon=True).start()
