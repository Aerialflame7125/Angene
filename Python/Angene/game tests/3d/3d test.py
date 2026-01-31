# 3d test
import time
import ctypes
from Angene import painter, opengl3d, engine

# Load GLU
glu32 = ctypes.WinDLL("glu32")
gluPerspective = glu32.gluPerspective
gluPerspective.argtypes = [ctypes.c_double, ctypes.c_double, ctypes.c_double, ctypes.c_double]
gluPerspective.restype = None

# Aliases
glMatrixMode = opengl3d.glMatrixMode
glLoadIdentity = opengl3d.glLoadIdentity
glTranslatef = opengl3d.glTranslatef
glRotatef = opengl3d.glRotatef
glClear = opengl3d.glClear
glViewport = opengl3d.glViewport
glEnable = opengl3d.glEnable
glDepthFunc = opengl3d.glDepthFunc
glGetError = opengl3d.opengl32.glGetError
glGetError.restype = ctypes.c_uint

GL_COLOR_BUFFER_BIT = opengl3d.GL_COLOR_BUFFER_BIT
GL_DEPTH_BUFFER_BIT = opengl3d.GL_DEPTH_BUFFER_BIT
GL_PROJECTION = opengl3d.GL_PROJECTION
GL_MODELVIEW = opengl3d.GL_MODELVIEW
GL_DEPTH_TEST = opengl3d.GL_DEPTH_TEST
GL_LESS = opengl3d.GL_LESS
SRCCOPY = 0x00CC0020

# Helper to check GL errors
def check_gl_error(msg=""):
    err = glGetError()
    if err != 0:
        print(f"[GL ERROR] {msg}: {err}")

# Initialize OpenGL state
def init_gl_state(width, height):
    print(f"[GL INIT] Setting viewport and perspective: {width}x{height}")
    glViewport(0, 0, width, height)
    check_gl_error("glViewport")
    glMatrixMode(GL_PROJECTION)
    check_gl_error("glMatrixMode(PROJECTION)")
    glLoadIdentity()
    check_gl_error("glLoadIdentity(PROJECTION)")
    aspect = width / height if height > 0 else 1.0
    gluPerspective(45.0, aspect, 0.1, 100.0)
    check_gl_error("gluPerspective")
    glMatrixMode(GL_MODELVIEW)
    check_gl_error("glMatrixMode(MODELVIEW)")
    glLoadIdentity()
    check_gl_error("glLoadIdentity(MODELVIEW)")
    glEnable(GL_DEPTH_TEST)
    check_gl_error("glEnable(GL_DEPTH_TEST)")
    glDepthFunc(GL_LESS)
    check_gl_error("glDepthFunc(GL_LESS)")
    opengl3d.glClearColor(0.1, 0.1, 0.1, 1.0)
    check_gl_error("glClearColor")

# Rotating cube
def draw_cube():
    opengl3d.draw_cube()
    check_gl_error("draw_cube")

class Scene3D:
    def __init__(self, hwnd, width, height):
        self.hwnd = hwnd
        self.width = width
        self.height = height
        self.rot_x = self.rot_y = self.rot_z = 0.0
        self.renderer_3d = None

    def Start(self):
        print("[Scene3D] Started")

    def OnDraw(self, _r):
        if not self.renderer_3d:
            print("[Scene3D] Creating 3D renderer now...")
            self.renderer_3d = opengl3d.Renderer3D(self.hwnd, self.width, self.height)
            if not self.renderer_3d or not self.renderer_3d.hdc:
                print("[Scene3D] Failed to create renderer!")
                return
            
            # Make context current and initialize GL state
            if not opengl3d.wglMakeCurrent(self.renderer_3d.hdc, self.renderer_3d.hglrc):
                print("[Scene3D] Failed to make context current")
                return
            
            # Initialize projection and depth test
            init_gl_state(self.width, self.height)

        # Make context current
        if not opengl3d.wglMakeCurrent(self.renderer_3d.hdc, self.renderer_3d.hglrc):
            print("[Scene3D] Failed to make context current")
            return

        # Clear color + depth buffer
        glClear(GL_COLOR_BUFFER_BIT | GL_DEPTH_BUFFER_BIT)

        # Reset modelview
        glMatrixMode(GL_MODELVIEW)
        glLoadIdentity()

        # Move camera back
        glTranslatef(0.0, 0.0, -6.0)

        # Apply rotations
        glRotatef(self.rot_x, 1.0, 0.0, 0.0)
        glRotatef(self.rot_y, 0.0, 1.0, 0.0)
        glRotatef(self.rot_z, 0.0, 0.0, 1.0)

        # Draw the cube
        draw_cube()

        # Present
        opengl3d.SwapBuffers(self.renderer_3d.hdc)

        # Update rotation
        dt = 1 / 60.0
        self.rot_x += 50.0 * dt
        self.rot_y += 30.0 * dt
        self.rot_z += 20.0 * dt


# 2D Scene
class Scene2D:
    def Start(self):
        self.x = 50
        print("[Scene2D] Started")
    def Update(self, dt):
        self.x += 100 * dt
        if self.x > 400:
            self.x = 0
    def OnDraw(self, r):
        r.clear(painter.RGB(30,30,30))
        r.draw_rect(int(self.x), 100, 200, 100, painter.RGB(200,50,50))
        r.draw_text(60, 50, "2D Window", painter.RGB(255,255,255))
        r.draw_text(60, 350, "OpenGL in other window!", painter.RGB(100,255,100))

# --- Main ---
print("Creating windows...")
win3 = engine.Window("3D OpenGL Window", 600, 600, use_3d=True)
win2 = engine.Window("2D GDI Window", 400, 300, use_3d=False)

scene_3d = Scene3D(win3.hwnd, win3.width, win3.height)
scene2 = Scene2D()

win3.set_scene(scene_3d)
win2.set_scene(scene2)

print("Starting engine with direct rendering...")
engine.run(target_fps=60)
