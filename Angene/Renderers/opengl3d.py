# Angene\opengl3d.py
import ctypes
import math

# Load OpenGL and GDI libraries
opengl32 = ctypes.WinDLL('opengl32')
gdi32 = ctypes.WinDLL('gdi32')
user32 = ctypes.WinDLL('user32')
glu32 = ctypes.WinDLL('glu32')  # Load the GLU library

# OpenGL function definitions
glClear = opengl32.glClear
glClearColor = opengl32.glClearColor
glMatrixMode = opengl32.glMatrixMode
glLoadIdentity = opengl32.glLoadIdentity
glTranslatef = opengl32.glTranslatef
glRotatef = opengl32.glRotatef
glBegin = opengl32.glBegin
glEnd = opengl32.glEnd
glVertex3f = opengl32.glVertex3f
glColor3f = opengl32.glColor3f
glViewport = opengl32.glViewport
glEnable = opengl32.glEnable
glDepthFunc = opengl32.glDepthFunc
gluPerspective = glu32.gluPerspective

# Set function signatures
glClearColor.argtypes = [ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float]
glTranslatef.argtypes = [ctypes.c_float, ctypes.c_float, ctypes.c_float]
glRotatef.argtypes = [ctypes.c_float, ctypes.c_float, ctypes.c_float, ctypes.c_float]
glVertex3f.argtypes = [ctypes.c_float, ctypes.c_float, ctypes.c_float]
glColor3f.argtypes = [ctypes.c_float, ctypes.c_float, ctypes.c_float]
glViewport.argtypes = [ctypes.c_int, ctypes.c_int, ctypes.c_int, ctypes.c_int]
gluPerspective.argtypes = [ctypes.c_double, ctypes.c_double, ctypes.c_double, ctypes.c_double]

# OpenGL constants
GL_COLOR_BUFFER_BIT = 0x00004000
GL_DEPTH_BUFFER_BIT = 0x00000100
GL_PROJECTION = 0x1701
GL_MODELVIEW = 0x1700
GL_DEPTH_TEST = 0x0B71
GL_LESS = 0x0201
GL_QUADS = 0x0007
GL_TRIANGLES = 0x0004
GL_LINES = 0x0001
gluPerspective.restype = None

# Pixel format descriptor for OpenGL
class PIXELFORMATDESCRIPTOR(ctypes.Structure):
    _fields_ = [
        ('nSize', ctypes.c_ushort),
        ('nVersion', ctypes.c_ushort),
        ('dwFlags', ctypes.c_ulong),
        ('iPixelType', ctypes.c_ubyte),
        ('cColorBits', ctypes.c_ubyte),
        ('cRedBits', ctypes.c_ubyte),
        ('cRedShift', ctypes.c_ubyte),
        ('cGreenBits', ctypes.c_ubyte),
        ('cGreenShift', ctypes.c_ubyte),
        ('cBlueBits', ctypes.c_ubyte),
        ('cBlueShift', ctypes.c_ubyte),
        ('cAlphaBits', ctypes.c_ubyte),
        ('cAlphaShift', ctypes.c_ubyte),
        ('cAccumBits', ctypes.c_ubyte),
        ('cAccumRedBits', ctypes.c_ubyte),
        ('cAccumGreenBits', ctypes.c_ubyte),
        ('cAccumBlueBits', ctypes.c_ubyte),
        ('cAccumAlphaBits', ctypes.c_ubyte),
        ('cDepthBits', ctypes.c_ubyte),
        ('cStencilBits', ctypes.c_ubyte),
        ('cAuxBuffers', ctypes.c_ubyte),
        ('iLayerType', ctypes.c_ubyte),
        ('bReserved', ctypes.c_ubyte),
        ('dwLayerMask', ctypes.c_ulong),
        ('dwVisibleMask', ctypes.c_ulong),
        ('dwDamageMask', ctypes.c_ulong),
    ]

# GDI functions for OpenGL context
ChoosePixelFormat = gdi32.ChoosePixelFormat
ChoosePixelFormat.argtypes = [ctypes.c_void_p, ctypes.POINTER(PIXELFORMATDESCRIPTOR)]
ChoosePixelFormat.restype = ctypes.c_int

SetPixelFormat = gdi32.SetPixelFormat
SetPixelFormat.argtypes = [ctypes.c_void_p, ctypes.c_int, ctypes.POINTER(PIXELFORMATDESCRIPTOR)]
SetPixelFormat.restype = ctypes.c_bool

SwapBuffers = gdi32.SwapBuffers
SwapBuffers.argtypes = [ctypes.c_void_p]
SwapBuffers.restype = ctypes.c_bool

# OpenGL context functions
wglCreateContext = opengl32.wglCreateContext
wglCreateContext.argtypes = [ctypes.c_void_p]
wglCreateContext.restype = ctypes.c_void_p

wglMakeCurrent = opengl32.wglMakeCurrent
wglMakeCurrent.argtypes = [ctypes.c_void_p, ctypes.c_void_p]
wglMakeCurrent.restype = ctypes.c_bool

wglDeleteContext = opengl32.wglDeleteContext
wglDeleteContext.argtypes = [ctypes.c_void_p]
wglDeleteContext.restype = ctypes.c_bool

# Pixel format flags
PFD_DRAW_TO_WINDOW = 0x00000004
PFD_SUPPORT_OPENGL = 0x00000020
PFD_DOUBLEBUFFER = 0x00000001
PFD_TYPE_RGBA = 0
PFD_MAIN_PLANE = 0

def setup_opengl(hwnd):
    """Setup OpenGL context for a window"""
    hdc = user32.GetDC(hwnd)
    
    # Setup pixel format
    pfd = PIXELFORMATDESCRIPTOR()
    pfd.nSize = ctypes.sizeof(PIXELFORMATDESCRIPTOR)
    pfd.nVersion = 1
    pfd.dwFlags = PFD_DRAW_TO_WINDOW | PFD_SUPPORT_OPENGL | PFD_DOUBLEBUFFER
    pfd.iPixelType = PFD_TYPE_RGBA
    pfd.cColorBits = 24
    pfd.cDepthBits = 16
    pfd.iLayerType = PFD_MAIN_PLANE
    
    pixel_format = ChoosePixelFormat(hdc, ctypes.byref(pfd))
    if not pixel_format:
        print("Failed to choose pixel format")
        return None, None
    
    if not SetPixelFormat(hdc, pixel_format, ctypes.byref(pfd)):
        print("Failed to set pixel format")
        return None, None
    
    # Create OpenGL context
    hglrc = wglCreateContext(hdc)
    if not hglrc:
        print("Failed to create OpenGL context")
        return None, None
    
    if not wglMakeCurrent(hdc, hglrc):
        print("Failed to make OpenGL context current")
        return None, None
    
    # Setup OpenGL state
    glEnable(GL_DEPTH_TEST)
    glDepthFunc(GL_LESS)
    glClearColor(0.1, 0.1, 0.1, 1.0)
    
    return hdc, hglrc

def setup_perspective(width, height):
    """Setup perspective projection"""
    glViewport(0, 0, width, height)
    glMatrixMode(GL_PROJECTION)
    glLoadIdentity()
    
    aspect = width / height if height > 0 else 1.0

    # Load GLU library for gluPerspective
    glu32 = ctypes.WinDLL('glu32')
    gluPerspective = glu32.gluPerspective
    gluPerspective.argtypes = [ctypes.c_double, ctypes.c_double, ctypes.c_double, ctypes.c_double]
    gluPerspective.restype = None

    gluPerspective(45.0, aspect, 0.1, 100.0)
    
    glMatrixMode(GL_MODELVIEW)
    glLoadIdentity()

def draw_cube():
    """Draw a colored 3D cube"""
    glBegin(GL_QUADS)
    
    # Front face (red)
    glColor3f(1.0, 0.0, 0.0)
    glVertex3f(-1.0, -1.0, 1.0)
    glVertex3f(1.0, -1.0, 1.0)
    glVertex3f(1.0, 1.0, 1.0)
    glVertex3f(-1.0, 1.0, 1.0)
    
    # Back face (green)
    glColor3f(0.0, 1.0, 0.0)
    glVertex3f(-1.0, -1.0, -1.0)
    glVertex3f(-1.0, 1.0, -1.0)
    glVertex3f(1.0, 1.0, -1.0)
    glVertex3f(1.0, -1.0, -1.0)
    
    # Top face (blue)
    glColor3f(0.0, 0.0, 1.0)
    glVertex3f(-1.0, 1.0, -1.0)
    glVertex3f(-1.0, 1.0, 1.0)
    glVertex3f(1.0, 1.0, 1.0)
    glVertex3f(1.0, 1.0, -1.0)
    
    # Bottom face (yellow)
    glColor3f(1.0, 1.0, 0.0)
    glVertex3f(-1.0, -1.0, -1.0)
    glVertex3f(1.0, -1.0, -1.0)
    glVertex3f(1.0, -1.0, 1.0)
    glVertex3f(-1.0, -1.0, 1.0)
    
    # Right face (cyan)
    glColor3f(0.0, 1.0, 1.0)
    glVertex3f(1.0, -1.0, -1.0)
    glVertex3f(1.0, 1.0, -1.0)
    glVertex3f(1.0, 1.0, 1.0)
    glVertex3f(1.0, -1.0, 1.0)
    
    # Left face (magenta)
    glColor3f(1.0, 0.0, 1.0)
    glVertex3f(-1.0, -1.0, -1.0)
    glVertex3f(-1.0, -1.0, 1.0)
    glVertex3f(-1.0, 1.0, 1.0)
    glVertex3f(-1.0, 1.0, -1.0)
    
    glEnd()

class Renderer3D:
    """3D OpenGL renderer"""
    def __init__(self, hwnd, width, height):
        self.hwnd = hwnd
        self.width = width
        self.height = height
        self.hdc, self.hglrc = setup_opengl(hwnd)
        if self.hdc and self.hglrc:
            setup_perspective(width, height)
            print(f"OpenGL initialized successfully")

    def begin_frame(self):
        """Start rendering a frame"""
        if self.hdc and self.hglrc:
            # MUST make context current every frame
            if not wglMakeCurrent(self.hdc, self.hglrc):
                print("Failed to make OpenGL context current!")
            glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT)
            glLoadIdentity()

    def end_frame(self):
        """Finish rendering and present"""
        if self.hdc:
            SwapBuffers(self.hdc)
    
    def cleanup(self):
        """Clean up OpenGL resources"""
        if self.hglrc:
            wglDeleteContext(self.hglrc)
            self.hglrc = None