# vr_demo_scene.py - Demo scene for VR rendering
import ctypes
import math
import time

class VRDemoScene:
    """
    Demo scene for VR - renders a colorful environment.
    This class is completely separate from the engine logic!
    """
    
    def __init__(self):
        self.rotation = 0.0
        self.time_elapsed = 0.0
        self.colors = [
            (0.8, 0.2, 0.2, 1.0),  # Red
            (0.2, 0.8, 0.2, 1.0),  # Green
            (0.2, 0.2, 0.8, 1.0),  # Blue
            (0.8, 0.8, 0.2, 1.0),  # Yellow
            (0.8, 0.2, 0.8, 1.0),  # Magenta
            (0.2, 0.8, 0.8, 1.0),  # Cyan
        ]
        self.color_index = 0
        self.last_color_change = 0.0
        
        print("[VRDemoScene] Created - Ready to render!")
    
    def Start(self):
        """Called once when scene starts"""
        print("[VRDemoScene] Scene started!")
        print("[VRDemoScene] Put on your headset - you should see colors!")
    
    def Update(self, dt):
        """Update scene state"""
        self.rotation += 30.0 * dt  # 30 degrees per second
        self.time_elapsed += dt
        
        # Change colors every 2 seconds
        if self.time_elapsed - self.last_color_change > 2.0:
            self.color_index = (self.color_index + 1) % len(self.colors)
            self.last_color_change = self.time_elapsed
    
    def get_current_color(self, eye_index):
        """
        Get the color for the current eye.
        Left eye = current color, Right eye = next color (for fun!)
        """
        if eye_index == 0:
            return self.colors[self.color_index]
        else:
            next_index = (self.color_index + 1) % len(self.colors)
            return self.colors[next_index]
    
    def OnRenderEye(self, vr_renderer, rtv, width, height, view, proj, eye_index):
        """
        Render to one eye.
        
        Args:
            vr_renderer: VRRenderer instance
            rtv: Render target view for this eye
            width: Viewport width
            height: Viewport height
            view: View matrix from VR pose
            proj: Projection matrix from VR FOV
            eye_index: 0 = left eye, 1 = right eye
        """
        # Get animated color
        color = self.get_current_color(eye_index)
        
        # Render the scene
        vr_renderer.render_scene(
            rtv,
            width,
            height,
            view,
            proj,
            self.rotation
        )


class VRTestScene:
    """
    Simple test scene - just flashing colors to verify rendering works
    """
    
    def __init__(self):
        self.time = 0.0
        print("[VRTestScene] Test scene created")
    
    def Start(self):
        print("[VRTestScene] Test scene started!")
        print("[VRTestScene] You should see pulsing colors in your headset")
    
    def Update(self, dt):
        self.time += dt
    
    def OnRenderEye(self, vr_renderer, rtv, width, height, view, proj, eye_index):
        """Render simple animated colors"""
        # Pulsing color based on time
        r = 0.5 + 0.5 * math.sin(self.time * 2.0)
        g = 0.5 + 0.5 * math.sin(self.time * 2.0 + 2.0)
        b = 0.5 + 0.5 * math.sin(self.time * 2.0 + 4.0)
        
        # Different color per eye
        if eye_index == 1:
            r, g, b = g, b, r
        
        vr_renderer.clear_render_target(rtv, (r, g, b, 1.0))


print("[vr_demo_scene] Scene classes loaded - Ready to use!")