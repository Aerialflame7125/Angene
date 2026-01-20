"""
VR Test Scene - Shows head tracking with visible test pattern
"""

import math
import ctypes
from Angene.Custom import openxr
from Angene.Renderers import d3d11_vr


class VRTestPattern:
    """
    Simple VR test scene that shows:
    - Head tracking (colors change as you move/rotate)
    - Stereo rendering (different colors per eye)
    - Frame updates (animated gradient)
    """
    
    def __init__(self):
        self.rotation = 0.0
        self.time = 0.0
        self.renderer = None
        self.vr_renderer = None
        self.render_target_cache = {}
        self.frame_count = 0
    
    def start(self):
        """Initialize VR renderer"""
        print("[VRTestPattern] Initializing...")
        
        if not self.renderer:
            print("[VRTestPattern] Error: No renderer available")
            return
        
        self.vr_renderer = d3d11_vr.VRRenderer(
            self.renderer.device,
            self.renderer.context
        )
        
        print("[VRTestPattern] ✓ Ready!")
        print("[VRTestPattern] Move your head to see colors change!")
        print("[VRTestPattern] Left eye = warmer colors, Right eye = cooler colors")
    
    def update(self, dt):
        """Update animation"""
        self.time += dt
        self.rotation += 45.0 * dt  # Rotate 45 degrees per second
    
    def _create_intermediate_texture(self, width, height, format=91):
        """Create renderable texture"""
        if not self.vr_renderer.device:
            return None
        
        device_vtable = ctypes.cast(
            ctypes.c_void_p.from_buffer(ctypes.c_void_p.from_address(self.vr_renderer.device.value)),
            ctypes.POINTER(ctypes.c_void_p)
        )
        
        create_tex_ptr = device_vtable[5]
        CREATE_TEX_PROTO = ctypes.WINFUNCTYPE(
            ctypes.c_long, ctypes.c_void_p, ctypes.c_void_p, ctypes.c_void_p, ctypes.POINTER(ctypes.c_void_p)
        )
        create_tex_func = CREATE_TEX_PROTO(create_tex_ptr)
        
        class D3D11_TEXTURE2D_DESC(ctypes.Structure):
            _fields_ = [
                ("Width", ctypes.c_uint), ("Height", ctypes.c_uint), ("MipLevels", ctypes.c_uint),
                ("ArraySize", ctypes.c_uint), ("Format", ctypes.c_uint), ("SampleDesc_Count", ctypes.c_uint),
                ("SampleDesc_Quality", ctypes.c_uint), ("Usage", ctypes.c_uint), ("BindFlags", ctypes.c_uint),
                ("CPUAccessFlags", ctypes.c_uint), ("MiscFlags", ctypes.c_uint),
            ]
        
        desc = D3D11_TEXTURE2D_DESC()
        desc.Width = width
        desc.Height = height
        desc.MipLevels = 1
        desc.ArraySize = 1
        desc.Format = format
        desc.SampleDesc_Count = 1
        desc.SampleDesc_Quality = 0
        desc.Usage = 0
        desc.BindFlags = 0x20
        desc.CPUAccessFlags = 0
        desc.MiscFlags = 0
        
        texture_out = ctypes.c_void_p()
        hr = create_tex_func(self.vr_renderer.device, ctypes.byref(desc), None, ctypes.byref(texture_out))
        
        return texture_out if hr >= 0 else None
    
    def _copy_texture(self, dst_texture, src_texture):
        """Copy texture"""
        if not self.vr_renderer.context or not dst_texture or not src_texture:
            return
        
        if isinstance(dst_texture, int):
            dst_texture = ctypes.c_void_p(dst_texture)
        if isinstance(src_texture, int):
            src_texture = ctypes.c_void_p(src_texture)
        
        context_vtable = ctypes.cast(
            ctypes.c_void_p.from_buffer(ctypes.c_void_p.from_address(self.vr_renderer.context.value)),
            ctypes.POINTER(ctypes.c_void_p)
        )
        
        copy_ptr = context_vtable[47]
        COPY_PROTO = ctypes.WINFUNCTYPE(None, ctypes.c_void_p, ctypes.c_void_p, ctypes.c_void_p)
        copy_func = COPY_PROTO(copy_ptr)
        copy_func(self.vr_renderer.context, dst_texture, src_texture)
    
    def _get_or_create_rtv_with_workaround(self, texture_ptr, width, height, cache_key):
        """Get or create RTV"""
        if cache_key in self.render_target_cache:
            return self.render_target_cache[cache_key]
        
        our_texture = self._create_intermediate_texture(width, height, format=91)
        if not our_texture:
            return None
        
        our_rtv = self.vr_renderer.create_render_target_view_for_our_texture(our_texture, format=91)
        if not our_rtv:
            return None
        
        self.render_target_cache[cache_key] = {
            'our_texture': our_texture,
            'our_rtv': our_rtv,
            'openxr_texture': texture_ptr
        }
        
        return self.render_target_cache[cache_key]
    
    def render_eye(self, eye_index, texture, width, height, view_matrix, proj_matrix):
        """Render test pattern with head tracking"""
        if not self.vr_renderer:
            return
        
        # Normalize texture pointer
        if isinstance(texture, ctypes.c_void_p):
            texture_ptr = texture.value
        elif hasattr(texture, 'value'):
            texture_ptr = texture.value
        else:
            texture_ptr = texture
        
        cache_key = f"eye_{eye_index}_{texture_ptr}"
        rtv_info = self._get_or_create_rtv_with_workaround(texture_ptr, width, height, cache_key)
        
        if not rtv_info:
            return
        
        # Extract camera position from view matrix for head tracking
        cam_x = view_matrix[12] if len(view_matrix) > 12 else 0.0
        cam_y = view_matrix[13] if len(view_matrix) > 13 else 0.0
        cam_z = view_matrix[14] if len(view_matrix) > 14 else 0.0
        
        # Create dynamic colors based on head position and rotation
        # Base colors
        r = 0.2 + abs(math.sin(cam_x * 2.0)) * 0.5
        g = 0.2 + abs(math.sin(cam_y * 2.0 + 2.0)) * 0.5
        b = 0.2 + abs(math.sin(cam_z * 2.0 + 4.0)) * 0.5
        
        # Add time-based animation
        time_offset = self.time * 0.5
        r += math.sin(time_offset) * 0.2
        g += math.sin(time_offset + 2.0) * 0.2
        b += math.sin(time_offset + 4.0) * 0.2
        
        # Clamp to valid range
        r = max(0.0, min(1.0, r))
        g = max(0.0, min(1.0, g))
        b = max(0.0, min(1.0, b))
        
        # Different colors per eye (stereo test)
        if eye_index == 0:
            # Left eye: warmer colors
            r += 0.2
            g += 0.1
        else:
            # Right eye: cooler colors
            b += 0.2
            g += 0.1
        
        # Clamp again after eye offset
        r = max(0.0, min(1.0, r))
        g = max(0.0, min(1.0, g))
        b = max(0.0, min(1.0, b))
        
        # Clear with dynamic color
        self.vr_renderer.clear_render_target(rtv_info['our_rtv'], (r, g, b, 1.0))
        
        # Copy to OpenXR texture
        self._copy_texture(rtv_info['openxr_texture'], rtv_info['our_texture'])
        
        # Debug output (once per second for left eye)
        if self.frame_count % 90 == 0 and eye_index == 0:
            print(f"[VRTest] Head: ({cam_x:.2f}, {cam_y:.2f}, {cam_z:.2f}) | Color: R={r:.2f} G={g:.2f} B={b:.2f}")
        
        if eye_index == 1:
            self.frame_count += 1


# Quick test
if __name__ == "__main__":
    print("=" * 60)
    print("VR Test Pattern - Head Tracking Demo")
    print("=" * 60)
    print()
    print("What you should see:")
    print("  - Colors change as you move your head")
    print("  - Left eye = warmer tones (more red)")
    print("  - Right eye = cooler tones (more blue)")
    print("  - Animated gradient pulsing")
    print()
    print("=" * 60)
    
    vr = openxr.VRSession(app_name="VR Test Pattern")
    vr.create_session()
    
    scene = VRTestPattern()
    scene.renderer = vr.renderer
    
    vr.run(scene, fps=120)