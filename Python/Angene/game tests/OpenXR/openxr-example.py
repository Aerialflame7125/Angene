# xr.py - OpenXR demo with D3D11 - FULL VR RENDERING
import ctypes
import sys
import os
from Angene.Main import painter
from Angene.Renderers import d3d11

sys.path.insert(0, os.path.dirname(__file__))
from Angene.Custom.openxr_ctypes import (
    XR_TYPE_COMPOSITION_LAYER_PROJECTION,
    XR_TYPE_COMPOSITION_LAYER_PROJECTION_VIEW,
    XR_TYPE_SESSION_BEGIN_INFO,
    XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO,
    XR_TYPE_VIEW_CONFIGURATION_VIEW,
    OpenXRLoaderD3D11,
    XR_SUCCESS,
    XrSessionBeginInfo,
    XrViewConfigurationView,
    xr_result_str
)

# Import the VR renderer and demo scene
from Angene.Renderers.d3d11_vr import VRRenderer, Matrix4x4
from xr_demo_scene import VRDemoScene, VRTestScene

class OpenXRSessionD3D11:
    """OpenXR session manager using D3D11 - WITH FALLBACK"""
    
    def __init__(self):
        self.loader = OpenXRLoaderD3D11()
        self.instance = None
        self.system_id = None
        self.session = None
        self.space = None
        self.available = False
        self.swapchains = []
        self.view_count = 0
        
    def initialize(self):
        """Initialize OpenXR with D3D11"""
        if not self.loader.is_available():
            print("[XRSession] OpenXR loader not available")
            return False
        
        print("[XRSession] Creating instance with D3D11 extension...")
        res, inst = self.loader.create_instance("AngeneXR_D3D11", "Angene", ["XR_KHR_D3D11_enable"])
        if res != XR_SUCCESS:
            print(f"[XRSession] Failed to create instance")
            return False
        
        self.instance = inst
        print("[XRSession] ✓ Instance created")
        
        res, sys_id = self.loader.get_system()
        if res != XR_SUCCESS:
            print(f"[XRSession] Failed to get system")
            return False
        
        self.system_id = sys_id
        print(f"[XRSession] ✓ System ID: {sys_id.value}")
        
        self.available = True
        return True
    
    def create_session_with_d3d11(self, d3d_renderer):
        """Create OpenXR session with D3D11 device"""
        if not self.available or not d3d_renderer.device:
            print("[XRSession] Cannot create session - XR or D3D11 not available")
            return False
        
        print("[XRSession] Creating session with D3D11 device...")
        print(f"[XRSession] D3D11 Device: {d3d_renderer.device.value:#018x}")
        
        res, session = self.loader.create_session_d3d11(d3d_renderer.device.value)
        if res != XR_SUCCESS:
            print(f"[XRSession] Session creation failed")
            return False
        
        self.session = session
        print("[XRSession] ✓ Session created!")
        return True
    
    def begin_session(self):
        if getattr(self, "_session_running", False):
            return True

        print("[XRSession] Beginning XR session...")

        begin_info = XrSessionBeginInfo()
        begin_info.type = XR_TYPE_SESSION_BEGIN_INFO
        begin_info.next = None
        begin_info.primaryViewConfigurationType = XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO

        res = self.loader.begin_session(self.session, begin_info)
        if res != XR_SUCCESS:
            print(f"[XRSession] xrBeginSession failed: {xr_result_str(res)}")
            return False

        self._session_running = True
        print("[XRSession] ✓ Session is now RUNNING")
        return True

    def create_reference_space(self):
        if not self.session:
            return False

        res, space = self.loader.create_reference_space(self.session, space_type=2)
        if res != XR_SUCCESS:
            print("[XRSession] LOCAL space failed, trying VIEW...")
            res, space = self.loader.create_reference_space(self.session, space_type=1)

        if res != XR_SUCCESS:
            print("[XRSession] Reference space creation failed")
            return False

        self.space = space
        print("[XRSession] ✓ Reference space created!")

        if not self.begin_session():
            return False

        return True

    def create_swapchains(self):
        """Create swapchains - WITH FALLBACK FOR FAILED ENUMERATION"""
        if not self.session:
            return False

        print("[XRSession] Querying view configuration views...")

        res, views = self.loader.get_view_configuration_views()
        
        # === FALLBACK LOGIC ===
        if res != XR_SUCCESS or not views:
            print("="*60)
            print("⚠ VIEW ENUMERATION FAILED - USING FALLBACK")
            print("="*60)
            print("Resolution: 1832x1920 per eye")
            print("This works for: Quest 2, Quest 3, Index, most SteamVR HMDs")
            print("="*60)
            
            # Create fallback views with common resolution
            views = (XrViewConfigurationView * 2)()
            for i in range(2):
                views[i].type = XR_TYPE_VIEW_CONFIGURATION_VIEW
                views[i].next = None
                views[i].recommendedImageRectWidth = 1832
                views[i].maxImageRectWidth = 4096
                views[i].recommendedImageRectHeight = 1920
                views[i].maxImageRectHeight = 4096
                views[i].recommendedSwapchainSampleCount = 1
                views[i].maxSwapchainSampleCount = 4
            
            self.view_count = 2
        else:
            self.view_count = len(views)
            print(f"[XRSession] ✓ Got {self.view_count} views from runtime")

        # Create swapchains for each view
        print(f"[XRSession] Creating {self.view_count} swapchains...")

        for i, view in enumerate(views):
            width = view.recommendedImageRectWidth
            height = view.recommendedImageRectHeight

            print(f"[XRSession]   Swapchain {i}: {width}x{height}")

            # Auto-detect format
            res, swapchain = self.loader.create_swapchain(
                self.session,
                width,
                height
            )
            
            if res != XR_SUCCESS:
                print(f"[XRSession] ✗ Swapchain {i} creation failed: {xr_result_str(res)}")
                return False

            res, images = self.loader.enumerate_swapchain_images(swapchain)
            if res != XR_SUCCESS or not images:
                print(f"[XRSession] ✗ Failed to enumerate images: {xr_result_str(res)}")
                return False

            print(f"[XRSession]     ✓ {len(images)} images allocated")
            self.swapchains.append((swapchain, images, width, height))

        print("="*60)
        print(f"✓✓✓ VR RENDERING READY ✓✓✓")
        print(f"Swapchains: {len(self.swapchains)}")
        print(f"Images per swapchain: {len(self.swapchains[0][1]) if self.swapchains else 0}")
        print("SteamVR should now show content!")
        print("="*60)
        return True


class XRSceneD3D11:
    """VR scene using D3D11 renderer with full frame loop"""
    
    def __init__(self, hwnd, width, height, xr_session, vr_scene):
        self.hwnd = hwnd
        self.width = width
        self.height = height
        self.xr = xr_session
        self.d3d_renderer = None
        self.vr_renderer = None
        self.vr_scene = vr_scene  # The actual scene to render!
        self.rotation = 0.0
        self.frame_count = 0
        self.render_target_views = {}  # Cache RTVs per swapchain image
        
    def Start(self):
        print("[XRSceneD3D11] Starting...")
        
        adapter_luid = None
        if self.xr.available and self.xr.system_id:
            print("[XRSession] Querying D3D11 graphics requirements...")
            res, requirements = self.xr.loader.get_d3d11_graphics_requirements()
            
            if res == XR_SUCCESS and requirements:
                adapter_luid = (requirements.adapterLuid.LowPart, requirements.adapterLuid.HighPart)
                print(f"[XRSession] ✓ Got graphics requirements")
                print(f"[XRSession]   Required adapter LUID: {adapter_luid[0]:08x}-{adapter_luid[1]:08x}")
        
        try:
            print(f"[XRSceneD3D11] Creating D3D11 renderer...")
            self.d3d_renderer = d3d11.RendererD3D11(self.hwnd, self.width, self.height, adapter_luid=adapter_luid)
            print("[XRSceneD3D11] ✓ D3D11 renderer created")
        except Exception as e:
            print(f"[XRSceneD3D11] ✗ Failed to create D3D11 renderer: {e}")
            import traceback
            traceback.print_exc()
            return
        
        if self.xr.available and self.d3d_renderer.device:
            print("[XRSession] Creating full VR pipeline...")
            
            if self.xr.create_session_with_d3d11(self.d3d_renderer):
                print("[XRSession] ✓ Session created!")
                
                if self.xr.create_reference_space():
                    print("[XRSession] ✓ Reference space created!")
                    
                    if self.xr.create_swapchains():
                        print("🎉 FULL VR PIPELINE READY! 🎉")
                        
                        # Create VR renderer
                        self.vr_renderer = VRRenderer(
                            self.d3d_renderer.device,
                            self.d3d_renderer.context
                        )
                        
                        # Start the demo scene
                        if hasattr(self.vr_scene, 'Start'):
                            self.vr_scene.Start()
                    else:
                        print("[XRSession] ✗ Swapchain creation failed")
                else:
                    print("[XRSession] ✗ Reference space creation failed")
            else:
                print("[XRSession] ✗ Session creation failed")
    
    def Update(self, dt):
        self.rotation += 30.0 * dt
        self.frame_count += 1
        
        # Update the demo scene
        if self.vr_scene and hasattr(self.vr_scene, 'Update'):
            self.vr_scene.Update(dt)
    
    def _create_our_texture(self, width, height, format=91):
        """Create our own texture that we can render to"""
        if not self.vr_renderer.device:
            return None
        
        # Call ID3D11Device::CreateTexture2D
        # vtable index 5
        device_vtable = ctypes.cast(
            ctypes.c_void_p.from_buffer(ctypes.c_void_p.from_address(self.vr_renderer.device.value)),
            ctypes.POINTER(ctypes.c_void_p)
        )
        
        create_tex_ptr = device_vtable[5]
        CREATE_TEX_PROTO = ctypes.WINFUNCTYPE(
            ctypes.c_long,  # HRESULT
            ctypes.c_void_p,  # this (device)
            ctypes.c_void_p,  # pDesc
            ctypes.c_void_p,  # pInitialData
            ctypes.POINTER(ctypes.c_void_p)  # ppTexture2D
        )
        create_tex_func = CREATE_TEX_PROTO(create_tex_ptr)
        
        # D3D11_TEXTURE2D_DESC structure
        class D3D11_TEXTURE2D_DESC(ctypes.Structure):
            _fields_ = [
                ("Width", ctypes.c_uint),
                ("Height", ctypes.c_uint),
                ("MipLevels", ctypes.c_uint),
                ("ArraySize", ctypes.c_uint),
                ("Format", ctypes.c_uint),  # DXGI_FORMAT
                ("SampleDesc_Count", ctypes.c_uint),
                ("SampleDesc_Quality", ctypes.c_uint),
                ("Usage", ctypes.c_uint),   # D3D11_USAGE
                ("BindFlags", ctypes.c_uint),
                ("CPUAccessFlags", ctypes.c_uint),
                ("MiscFlags", ctypes.c_uint),
            ]
        
        desc = D3D11_TEXTURE2D_DESC()
        desc.Width = width
        desc.Height = height
        desc.MipLevels = 1
        desc.ArraySize = 1
        desc.Format = format
        desc.SampleDesc_Count = 1
        desc.SampleDesc_Quality = 0
        desc.Usage = 0  # D3D11_USAGE_DEFAULT
        desc.BindFlags = 0x20  # D3D11_BIND_RENDER_TARGET
        desc.CPUAccessFlags = 0
        desc.MiscFlags = 0
        
        texture_out = ctypes.c_void_p()
        hr = create_tex_func(self.vr_renderer.device, ctypes.byref(desc), None, ctypes.byref(texture_out))
        
        if hr < 0:
            print(f"[VRRenderer] Failed to create our texture: {hr:#010x}")
            return None
        
        return texture_out

    def _release_texture(self, texture):
        """Release a texture"""
        if not texture:
            return
        
        # Call IUnknown::Release (vtable index 2)
        texture_vtable = ctypes.cast(
            ctypes.c_void_p.from_buffer(ctypes.c_void_p.from_address(texture.value)),
            ctypes.POINTER(ctypes.c_void_p)
        )
        
        release_ptr = texture_vtable[2]
        RELEASE_PROTO = ctypes.WINFUNCTYPE(ctypes.c_uint, ctypes.c_void_p)
        release_func = RELEASE_PROTO(release_ptr)
        ref_count = release_func(texture)
        
        print(f"[VRRenderer] Released texture, ref count: {ref_count}")

    def _get_or_create_rtv(self, swapchain_index, image_index):
        """Get cached RTV or create new one - WORKAROUND VERSION using our own texture"""
        key = (swapchain_index, image_index)
        
        if key not in self.render_target_views:
            # Get texture from swapchain
            _, images, width, height = self.xr.swapchains[swapchain_index]
            
            # Store the OpenXR texture for copying later
            texture_ptr = images[image_index].texture
            
            # Ensure it's a c_void_p
            if not isinstance(texture_ptr, ctypes.c_void_p):
                if isinstance(texture_ptr, int):
                    texture_ptr = ctypes.c_void_p(texture_ptr)
                else:
                    texture_ptr = ctypes.c_void_p(int(texture_ptr))
            
            print(f"[VRRenderer] WORKAROUND: Creating our own render target for swapchain {swapchain_index}, image {image_index}")
            print(f"[VRRenderer]   OpenXR Texture pointer: {texture_ptr.value:#018x}")
            print(f"[VRRenderer]   Resolution: {width}x{height}")
            
            # Create our own render target texture
            # We'll create a texture with format 91 (DXGI_FORMAT_B8G8R8A8_UNORM_SRGB)
            # that we can actually render to
            
            # First, create our own texture
            our_texture = self._create_our_texture(width, height, format=91)
            if not our_texture:
                print(f"[VRRenderer] ✗ Failed to create our texture")
                return None
            
            # Create RTV for our texture
            rtv = self.vr_renderer.create_render_target_view_for_our_texture(our_texture, 91)
            if not rtv:
                print(f"[VRRenderer] ✗ Failed to create RTV for our texture")
                # Release our texture
                self._release_texture(our_texture)
                return None
            
            # Store both our texture and RTV, plus the OpenXR texture for copying
            self.render_target_views[key] = {
                'our_texture': our_texture,
                'our_rtv': rtv,
                'openxr_texture': texture_ptr
            }
            
            print(f"[VRRenderer] ✓ Created our own render target")
            print(f"[VRRenderer]   Our texture: {our_texture.value:#018x}")
            print(f"[VRRenderer]   Our RTV: {rtv.value:#018x}")
        
        return self.render_target_views[key]['our_rtv']

    def OnDraw(self, _r):
        if not self.d3d_renderer or not self.xr.session or not self.xr.space or not self.vr_renderer:
            # Fallback rendering for desktop window
            if self.d3d_renderer:
                self.d3d_renderer.begin_frame()
                self.d3d_renderer.end_frame()
            return
        
        try:
            # Wait for next VR frame
            res, frame_state = self.xr.loader.wait_frame(self.xr.session)
            if res != XR_SUCCESS:
                return
            
            # Begin frame
            res = self.xr.loader.begin_frame(self.xr.session)
            if res != XR_SUCCESS:
                return
            
            layers = None
            if frame_state.shouldRender:
                # Get view poses (eye positions and orientations)
                res, view_state, views = self.xr.loader.locate_views(
                    self.xr.session,
                    frame_state.predictedDisplayTime,
                    self.xr.space,
                    self.xr.view_count
                )
                
                if res == XR_SUCCESS and views:
                    projection_views = self._render_views(views)
                    if projection_views:
                        layers = self._create_projection_layer(projection_views)
            
            # End frame and submit to compositor
            res = self.xr.loader.end_frame(
                self.xr.session,
                frame_state.predictedDisplayTime,
                layers
            )
            
            # Occasionally update desktop window
            if self.frame_count % 2 == 0:
                self.d3d_renderer.begin_frame()
                self.d3d_renderer.end_frame()
                
        except Exception as e:
            print(f"[XRSceneD3D11] Error in frame loop: {e}")
            import traceback
            traceback.print_exc()
    
    def _copy_texture(self, dst_texture, src_texture):
        """Copy from src_texture to dst_texture"""
        if not self.vr_renderer.context or not dst_texture or not src_texture:
            return
        
        # Call ID3D11DeviceContext::CopyResource
        # vtable index 47
        context_vtable = ctypes.cast(
            ctypes.c_void_p.from_buffer(ctypes.c_void_p.from_address(self.vr_renderer.context.value)),
            ctypes.POINTER(ctypes.c_void_p)
        )
        
        copy_ptr = context_vtable[47]
        COPY_PROTO = ctypes.WINFUNCTYPE(
            None,
            ctypes.c_void_p,  # this (context)
            ctypes.c_void_p,  # dst resource
            ctypes.c_void_p   # src resource
        )
        
        copy_func = COPY_PROTO(copy_ptr)
        copy_func(self.vr_renderer.context, dst_texture, src_texture)
        
        print(f"[VRRenderer] Copied from our texture to OpenXR texture")

    def _render_views(self, views):
        """Render to all VR views (eyes)"""
        from Angene.Custom.openxr_ctypes import XrCompositionLayerProjectionView, XrSwapchainSubImage
        
        projection_views = []
        
        for i, (swapchain, images, width, height) in enumerate(self.xr.swapchains):
            if i >= len(views):
                break
            
            # Acquire next swapchain image
            res, image_index = self.xr.loader.acquire_swapchain_image(swapchain)
            if res != XR_SUCCESS:
                print(f"[VRRenderer] Failed to acquire image: {xr_result_str(res)}")
                continue
            
            # Wait for image to be ready
            res = self.xr.loader.wait_swapchain_image(swapchain)
            if res != XR_SUCCESS:
                print(f"[VRRenderer] Wait failed: {xr_result_str(res)}")
                continue
            
            # Get or create render target view
            rtv = self._get_or_create_rtv(i, image_index)
            if not rtv:
                self.xr.loader.release_swapchain_image(swapchain)
                continue
            
            # === RENDER TO THIS EYE ===
            view_matrix = Matrix4x4.from_pose(views[i].pose)
            proj_matrix = Matrix4x4.from_fov(views[i].fov, 0.1, 100.0)
            
            # Call the scene's render method!
            if self.vr_scene and hasattr(self.vr_scene, 'OnRenderEye'):
                self.vr_scene.OnRenderEye(
                    self.vr_renderer,
                    rtv,
                    width,
                    height,
                    view_matrix,
                    proj_matrix,
                    i  # eye index
                )
            else:
                # Fallback: just clear to a color
                color = (0.1, 0.2, 0.4, 1.0) if i == 0 else (0.4, 0.2, 0.1, 1.0)
                self.vr_renderer.clear_render_target(rtv, color)

            # COPY FROM OUR TEXTURE TO OPENXR TEXTURE
            cache_entry = self.render_target_views[(i, image_index)]
            our_texture = cache_entry['our_texture']
            openxr_texture = cache_entry['openxr_texture']

            # Use ID3D11DeviceContext::CopyResource to copy
            self._copy_texture(openxr_texture, our_texture)
            
            # Release swapchain image
            self.xr.loader.release_swapchain_image(swapchain)
            
            # Create projection view for compositor
            proj_view = XrCompositionLayerProjectionView()
            proj_view.type = XR_TYPE_COMPOSITION_LAYER_PROJECTION_VIEW
            proj_view.next = None
            proj_view.pose = views[i].pose
            proj_view.fov = views[i].fov
            
            sub_image = XrSwapchainSubImage()
            sub_image.swapchain = swapchain
            sub_image.imageRect.offsetX = 0
            sub_image.imageRect.offsetY = 0
            sub_image.imageRect.extentWidth = width
            sub_image.imageRect.extentHeight = height
            sub_image.imageArrayIndex = 0
            proj_view.subImage = sub_image
            
            projection_views.append(proj_view)
        
        return projection_views if projection_views else None
    
    def _create_projection_layer(self, projection_views):
        if not projection_views:
            return None
        
        from Angene.Custom.openxr_ctypes import XrCompositionLayerProjection
        
        views_array = (type(projection_views[0]) * len(projection_views))(*projection_views)
        
        layer = XrCompositionLayerProjection()
        layer.type = XR_TYPE_COMPOSITION_LAYER_PROJECTION
        layer.next = None
        layer.layerFlags = 0
        layer.space = self.xr.space
        layer.viewCount = len(projection_views)
        layer.views = ctypes.cast(views_array, ctypes.c_void_p)
        
        layer_ptr = ctypes.pointer(layer)
        layers_array = (ctypes.c_void_p * 1)(ctypes.cast(layer_ptr, ctypes.c_void_p))
        
        return layers_array


class StatusScene2D:
    """2D status display"""
    
    def __init__(self, xr_session):
        self.xr = xr_session
        self.frame_count = 0
        
    def Start(self):
        print("[StatusScene2D] Started")
    
    def Update(self, dt):
        self.frame_count += 1
    
    def OnDraw(self, r):
        r.clear(painter.RGB(20, 30, 40))
        r.draw_text(10, 10, "Angene OpenXR + Direct3D 11", painter.RGB(255, 255, 255))
        r.draw_text(10, 40, "🎮 VR RENDERING ACTIVE! 🎮", painter.RGB(100, 255, 100))
        r.draw_text(10, 70, f"Frame: {self.frame_count}", painter.RGB(150, 150, 150))
        
        y = 120
        r.draw_text(10, y, "OpenXR Pipeline:", painter.RGB(100, 255, 100))
        
        status_color = painter.RGB(100, 200, 100) if self.xr.instance else painter.RGB(200, 100, 100)
        status_text = "✓ Instance" if self.xr.instance else "✗ Instance Failed"
        r.draw_text(10, y+30, status_text, status_color)
        
        status_color = painter.RGB(100, 200, 100) if self.xr.system_id else painter.RGB(200, 100, 100)
        status_text = "✓ System/HMD" if self.xr.system_id else "✗ No HMD"
        r.draw_text(10, y+60, status_text, status_color)
        
        status_color = painter.RGB(100, 200, 100) if self.xr.session else painter.RGB(200, 200, 100)
        status_text = "✓ Session (D3D11)" if self.xr.session else "○ Session Pending"
        r.draw_text(10, y+90, status_text, status_color)
        
        status_color = painter.RGB(100, 200, 100) if self.xr.space else painter.RGB(200, 200, 100)
        status_text = "✓ Reference Space" if self.xr.space else "○ Space Pending"
        r.draw_text(10, y+120, status_text, status_color)
        
        swapchain_count = len(self.xr.swapchains) if hasattr(self.xr, 'swapchains') else 0
        status_color = painter.RGB(100, 200, 100) if swapchain_count > 0 else painter.RGB(200, 200, 100)
        status_text = f"✓ Swapchains ({swapchain_count})" if swapchain_count > 0 else "○ Swapchains Pending"
        r.draw_text(10, y+150, status_text, status_color)
        
        if swapchain_count > 0:
            r.draw_text(10, y+180, "🎉🎉🎉 VR RENDERING! 🎉🎉🎉", painter.RGB(100, 255, 100))
            r.draw_text(10, y+210, "PUT ON YOUR HEADSET!", painter.RGB(255, 255, 100))
            r.draw_text(10, y+240, "You should see colors!", painter.RGB(255, 255, 100))
            
            for i, (_, _, w, h) in enumerate(self.xr.swapchains):
                r.draw_text(10, y+270+i*20, f"  Eye {i}: {w}x{h}", painter.RGB(150, 200, 200))
        
        r.draw_text(10, y+330, "Frame Loop Active", painter.RGB(150, 255, 150))


def main():
    print("=" * 60)
    print("Angene OpenXR + Direct3D 11 Integration")
    print("VR RENDERING DEMO")
    print("=" * 60)
    
    if not d3d11.is_d3d11_available():
        print("ERROR: Direct3D 11 not available on this system!")
        return
    
    print("✓ Direct3D 11 is available")
    
    xr_session = OpenXRSessionD3D11()
    if not xr_session.initialize():
        print("WARNING: OpenXR initialization failed")
        print("Continuing in desktop mode...")
    else:
        print("✓ OpenXR initialized successfully")
    
    print("\nCreating windows...")
    
    # Create the VR demo scene (changeable!)
    vr_demo = VRTestScene()  # Or use VRDemoScene() for animated colors
    
    win_3d = main.Window("VR Preview (D3D11)", 800, 600, use_3d=True)
    win_status = main.Window("OpenXR Status", 400, 500, use_3d=False)
    
    scene_3d = XRSceneD3D11(win_3d.hwnd, win_3d.width, win_3d.height, xr_session, vr_demo)
    scene_status = StatusScene2D(xr_session)
    
    win_3d.set_scene(scene_3d)
    win_status.set_scene(scene_status)
    
    print("\nStarting main loop...")
    print("=" * 60)
    print("🎮 PUT ON YOUR VR HEADSET! 🎮")
    print("You should see animated colors!")
    print("=" * 60)
    
    main.run(target_fps=90)  # VR needs high FPS!


if __name__ == "__main__":
    main()