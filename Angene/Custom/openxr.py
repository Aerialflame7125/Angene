"""
Angene OpenXR Integration - FIXED VERSION
Properly submits frames to the compositor
"""

import ctypes
from ctypes import wintypes, c_void_p, c_uint, c_int, c_float
import sys
import os

sys.path.insert(0, os.path.join(os.path.dirname(__file__)))

import Angene.Custom.openxr_ctypes
from Angene.Renderers import d3d11_vr


class VRSession:
    """High-level OpenXR session manager - FIXED to submit frames"""
    
    def __init__(self, app_name="Angene VR App", graphics_api="D3D11"):
        self.app_name = app_name
        self.graphics_api = graphics_api
        
        self.instance = None
        self.system_id = None
        self.session = None
        self.space = None
        self.swapchains = []
        
        self.renderer = None
        self.running = False
        self.frame_count = 0
        
        print(f"[VRSession] Initializing {app_name}...")
        self._initialize()
    
    def _initialize(self):
        """Initialize OpenXR instance and system"""
        print("[VRSession] Creating OpenXR instance...")
        
        self.loader = Angene.Custom.openxr_ctypes.OpenXRLoaderD3D11()

        if self.graphics_api == "D3D11":
            graphics_ext = "XR_KHR_D3D11_enable"
        else:
            raise ValueError(f"Graphics API '{self.graphics_api}' not supported yet")
        
        res, inst = self.loader.create_instance(
            application_name=self.app_name,
            extensions=[graphics_ext]
        )
        
        if res != 0 or not inst:
            raise RuntimeError(f"Failed to create OpenXR instance. Result: {res}")
        
        self.instance = inst
        print(f"[VRSession] ✓ Instance created")

        res, sys_id = self.loader.get_system()
        
        if res != 0 or not sys_id:
            raise RuntimeError(f"Failed to get OpenXR system. Result: {res}")
        
        self.system_id = sys_id
        print(f"[VRSession] ✓ System ID: {self.system_id}")
        
        if self.graphics_api == "D3D11":
            res, reqs = self.loader.get_d3d11_graphics_requirements()
            
            if res != 0 or not reqs:
                raise RuntimeError("Failed to get D3D11 graphics requirements")

            self.graphics_requirements = reqs 
            print(f"[VRSession] ✓ Graphics requirements ready")
    
    def create_session(self, hwnd=None, width=1280, height=720):
        """Create OpenXR session and initialize graphics"""
        print("[VRSession] Creating graphics device and session...")
        
        if self.graphics_api == "D3D11":
            from Angene.Renderers.d3d11 import RendererD3D11
            
            luid_low = self.graphics_requirements.adapterLuid.LowPart
            luid_high = self.graphics_requirements.adapterLuid.HighPart
            
            self.renderer = RendererD3D11(
                hwnd=hwnd,
                width=width,
                height=height,
                adapter_luid=(luid_low, luid_high)
            )
            
            if not self.renderer or not self.renderer.device:
                raise RuntimeError("Failed to create D3D11 device")
            
            print(f"[VRSession] ✓ D3D11 device created")
            
            # FIXED: create_session_d3d11 returns just the session, not a tuple
            self.session = self.loader.create_session_d3d11(
                self.renderer.device
            )
            
            if not self.session:
                raise RuntimeError("Failed to create OpenXR session")
            
            print("[VRSession] ✓ Session created")
        
        # FIXED: Unpack the tuple from create_reference_space
        res, self.space = self.loader.create_reference_space(self.session)
        if res != 0 or not self.space:
            raise RuntimeError("Failed to create reference space")

        print("[VRSession] ✓ Reference space created")

        res = self.loader.begin_session(self.session)
        if res != 0:
            raise RuntimeError(f"Failed to begin session. Result: {res}")

        print("[VRSession] ✓ Session running")

        self._create_swapchains()
        return True

    def _create_swapchains(self):
        """Create swapchains for each view (eye)"""
        print("[VRSession] Creating swapchains...")
        
        res, views_struct = self.loader.get_view_configuration_views()
        
        if res != 0 or not views_struct:
            print("[VRSession] Warning: Could not get views, using fallback")
            views = [(1832, 1920), (1832, 1920)]
        else:
            views = []
            for i in range(len(views_struct)):
                width = views_struct[i].recommendedImageRectWidth
                height = views_struct[i].recommendedImageRectHeight
                views.append((width, height))
            print(f"[VRSession] Got {len(views)} view configurations from OpenXR")
        
        num_views = len(views)
        print(f"[VRSession] Creating {num_views} swapchains...")
        
        for i, (width, height) in enumerate(views):
            print(f"[VRSession]   Swapchain {i}: {width}x{height}")
            
            res, swapchain = self.loader.create_swapchain(
                self.session,
                width,
                height,
                format=None
            )
            
            if res != 0 or not swapchain:
                raise RuntimeError(f"Failed to create swapchain {i}. Result: {res}")
            
            res, images = self.loader.enumerate_swapchain_images(swapchain)
            
            if res != 0 or not images:
                raise RuntimeError(f"Failed to enumerate swapchain images for swapchain {i}")
            
            print(f"[VRSession]     ✓ {len(images)} images allocated")
            
            self.swapchains.append({
                'handle': swapchain,
                'images': images,
                'width': width,
                'height': height,
                'index': i
            })
        
        print("[VRSession] ✓ All swapchains ready")

    def run(self, scene, fps=90):
        """Run the VR frame loop - FIXED to properly submit frames"""
        import time
        
        print(f"[VRSession] Starting frame loop at {fps} FPS...")
        print("[VRSession] Put on your VR headset!")
        
        self.running = True
        frame_time = 1.0 / fps
        last_time = time.time()
        
        if hasattr(scene, 'start'):
            scene.start()
        
        if hasattr(scene, 'renderer'):
            scene.renderer = self.renderer
        
        # Import composition layer structures
        from Angene.Custom.openxr_ctypes import (
            XrCompositionLayerProjection,
            XrCompositionLayerProjectionView,
            XrSwapchainSubImage,
            XR_TYPE_COMPOSITION_LAYER_PROJECTION,
            XR_TYPE_COMPOSITION_LAYER_PROJECTION_VIEW,
        )
        
        try:
            while self.running:
                current_time = time.time()
                dt = current_time - last_time
                last_time = current_time
                
                if hasattr(scene, 'update'):
                    scene.update(dt)
                
                # === CRITICAL: PROPER FRAME SUBMISSION ===
                
                # Wait for next frame
                res, frame_state = self.loader.wait_frame(self.session)
                if res != 0 or not frame_state:
                    continue
                
                # Begin frame
                res = self.loader.begin_frame(self.session)
                if res != 0:
                    continue
                
                layers = None
                
                # Only render if OpenXR says we should
                if frame_state.shouldRender:
                    # Get view poses (eye positions)
                    res, view_state, views = self.loader.locate_views(
                        self.session,
                        frame_state.predictedDisplayTime,
                        self.space,
                        len(self.swapchains)
                    )
                    
                    if res == 0 and views:
                        # Render each eye and collect projection views
                        projection_views = []
                        
                        for swapchain_info in self.swapchains:
                            eye_index = swapchain_info['index']
                            swapchain = swapchain_info['handle']
                            images = swapchain_info['images']
                            width = swapchain_info['width']
                            height = swapchain_info['height']
                            
                            # Acquire image
                            res, image_index = self.loader.acquire_swapchain_image(swapchain)
                            if res != 0 or image_index is None:
                                continue
                            
                            # Wait for image
                            res = self.loader.wait_swapchain_image(swapchain)
                            if res != 0:
                                continue
                            
                            # Get texture
                            texture = images[image_index].texture
                            
                            # Get matrices from OpenXR
                            view_matrix = self._pose_to_matrix(views[eye_index].pose)
                            proj_matrix = self._fov_to_matrix(views[eye_index].fov, 0.1, 100.0)
                            
                            # RENDER!
                            if hasattr(scene, 'render_eye'):
                                scene.render_eye(
                                    eye_index,
                                    texture,
                                    width,
                                    height,
                                    view_matrix,
                                    proj_matrix
                                )
                            
                            # Release image
                            self.loader.release_swapchain_image(swapchain)
                            
                            # Create projection view for this eye
                            proj_view = XrCompositionLayerProjectionView()
                            proj_view.type = XR_TYPE_COMPOSITION_LAYER_PROJECTION_VIEW
                            proj_view.next = None
                            proj_view.pose = views[eye_index].pose
                            proj_view.fov = views[eye_index].fov
                            
                            # Create sub-image
                            sub_image = XrSwapchainSubImage()
                            sub_image.swapchain = swapchain
                            sub_image.imageRect.offsetX = 0
                            sub_image.imageRect.offsetY = 0
                            sub_image.imageRect.extentWidth = width
                            sub_image.imageRect.extentHeight = height
                            sub_image.imageArrayIndex = 0
                            
                            proj_view.subImage = sub_image
                            projection_views.append(proj_view)
                        
                        # Create projection layer
                        if projection_views:
                            views_array = (type(projection_views[0]) * len(projection_views))(*projection_views)
                            
                            layer = XrCompositionLayerProjection()
                            layer.type = XR_TYPE_COMPOSITION_LAYER_PROJECTION
                            layer.next = None
                            layer.layerFlags = 0
                            layer.space = self.space
                            layer.viewCount = len(projection_views)
                            layer.views = ctypes.cast(views_array, ctypes.c_void_p)
                            
                            layer_ptr = ctypes.pointer(layer)
                            layers = (ctypes.c_void_p * 1)(ctypes.cast(layer_ptr, ctypes.c_void_p))
                
                # End frame - SUBMIT TO COMPOSITOR
                res = self.loader.end_frame(
                    self.session,
                    frame_state.predictedDisplayTime,
                    layers
                )
                
                if res != 0:
                    print(f"[VRSession] Warning: end_frame failed with result {res}")
                
                self.frame_count += 1
        
        except KeyboardInterrupt:
            print("\n[VRSession] Interrupted by user")
        finally:
            self.stop()

    def stop(self):
        """Stop the VR session and cleanup"""
        print("[VRSession] Shutting down...")
        self.running = False
        print("[VRSession] ✓ Shutdown complete")
    
    def _pose_to_matrix(self, pose):
        """Convert OpenXR pose to view matrix - PROPER IMPLEMENTATION"""
        import math
        
        # Extract quaternion and position
        qx, qy, qz, qw = pose.orientation[0], pose.orientation[1], pose.orientation[2], pose.orientation[3]
        px, py, pz = pose.position[0], pose.position[1], pose.position[2]
        
        # Convert quaternion to rotation matrix
        # Row 0
        m00 = 1.0 - 2.0 * (qy * qy + qz * qz)
        m01 = 2.0 * (qx * qy + qw * qz)
        m02 = 2.0 * (qx * qz - qw * qy)
        
        # Row 1
        m10 = 2.0 * (qx * qy - qw * qz)
        m11 = 1.0 - 2.0 * (qx * qx + qz * qz)
        m12 = 2.0 * (qy * qz + qw * qx)
        
        # Row 2
        m20 = 2.0 * (qx * qz + qw * qy)
        m21 = 2.0 * (qy * qz - qw * qx)
        m22 = 1.0 - 2.0 * (qx * qx + qy * qy)
        
        # Create view matrix (inverse of camera transform)
        # This inverts the rotation and position
        matrix = [
            m00, m10, m20, 0.0,
            m01, m11, m21, 0.0,
            m02, m12, m22, 0.0,
            -(m00 * px + m01 * py + m02 * pz),
            -(m10 * px + m11 * py + m12 * pz),
            -(m20 * px + m21 * py + m22 * pz),
            1.0
        ]
        
        return matrix
    
    def _fov_to_matrix(self, fov, near, far):
        """Convert OpenXR FOV to projection matrix - PROPER IMPLEMENTATION"""
        import math
        
        tan_left = math.tan(fov.angleLeft)
        tan_right = math.tan(fov.angleRight)
        tan_up = math.tan(fov.angleUp)
        tan_down = math.tan(fov.angleDown)
        
        tan_width = tan_right - tan_left
        tan_height = tan_up - tan_down
        
        # Asymmetric projection matrix for VR
        matrix = [0.0] * 16
        matrix[0] = 2.0 / tan_width
        matrix[5] = 2.0 / tan_height
        matrix[8] = (tan_right + tan_left) / tan_width
        matrix[9] = (tan_up + tan_down) / tan_height
        matrix[10] = far / (far - near)
        matrix[11] = 1.0
        matrix[14] = -(far * near) / (far - near)
        
        return matrix


def quick_start(scene_class, app_name="Angene VR"):
    """Quick start a VR application"""
    vr = VRSession(app_name=app_name)
    vr.create_session()
    
    scene = scene_class()
    vr.run(scene)
    
    return vr


__all__ = ['VRSession', 'quick_start']