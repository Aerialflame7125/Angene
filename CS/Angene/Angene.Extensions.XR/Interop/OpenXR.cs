using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Angene.Graphics.DX11;
using Angene.Windows.D3D11;
using Angene.Windows.Dxgi;
using Angene.Essentials;
using static Angene.Extensions.XR.Interop.OpenXR;

[assembly: GeneratedCode("ClangSharp", "21.1.8.4")]

namespace Angene.Extensions.XR.Interop
{
    public unsafe class OpenXR
    {
        public struct XrGraphicsRequirementsD3D11KHR {
            public Types.XrStructureType type;
            public void* next;
            public DxgiStructs.LUID adapterLuid;
            public D3D11.D3D_FEATURE_LEVEL minFeatureLevel;
        }
        public struct XrGraphicsBindingVulkanKHR {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr instance;
            public IntPtr physicalDevice;
            public IntPtr device;
            public uint queueFamilyIndex;
            public uint queueIndex;
        }
        
        public enum XrFormFactor : uint
        {
            XR_FORM_FACTOR_HEAD_MOUNTED_DISPLAY = 1,
            XR_FORM_FACTOR_HANDHELD_DISPLAY = 2,
            XR_FORM_FACTOR_MAX_ENUM = 0x7FFFFFFF,
        }
        public enum XrEnvironmentBlendMode : uint
        {
            XR_ENVIRONMENT_BLEND_MODE_OPAQUE = 1,
            XR_ENVIRONMENT_BLEND_MODE_ADDITIVE = 2,
            XR_ENVIRONMENT_BLEND_MODE_ALPHA_BLEND = 3,
            XR_ENVIRONMENT_BLEND_MODE_MAX_ENUM = 0x7FFFFFFF,
        }
        public enum XrViewConfigurationType : uint
        {
            XR_VIEW_CONFIGURATION_TYPE_PRIMARY_MONO = 1,
            XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO = 2,
            XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO_WITH_FOVEATED_INSET = 1000037000,
            XR_VIEW_CONFIGURATION_TYPE_SECONDARY_MONO_FIRST_PERSON_OBSERVER_MSFT = 1000054000,
            XR_VIEW_CONFIGURATION_TYPE_PRIMARY_QUAD_VARJO = XR_VIEW_CONFIGURATION_TYPE_PRIMARY_STEREO_WITH_FOVEATED_INSET,
            XR_VIEW_CONFIGURATION_TYPE_MAX_ENUM = 0x7FFFFFFF,
        }
        public enum XrReferenceSpaceType : uint
        {
            XR_REFERENCE_SPACE_TYPE_VIEW = 1,
            XR_REFERENCE_SPACE_TYPE_LOCAL = 2,
            XR_REFERENCE_SPACE_TYPE_STAGE = 3,
            XR_REFERENCE_SPACE_TYPE_LOCAL_FLOOR = 1000426000,
            XR_REFERENCE_SPACE_TYPE_UNBOUNDED_MSFT = 1000038000,
            XR_REFERENCE_SPACE_TYPE_COMBINED_EYE_VARJO = 1000121000,
            XR_REFERENCE_SPACE_TYPE_LOCALIZATION_MAP_ML = 1000139000,
            XR_REFERENCE_SPACE_TYPE_UNBOUNDED_ANDROID = 1000467000,
            XR_REFERENCE_SPACE_TYPE_STATIONARY_EXT = 1000742000,
            XR_REFERENCE_SPACE_TYPE_LOCAL_FLOOR_EXT = XR_REFERENCE_SPACE_TYPE_LOCAL_FLOOR,
            XR_REFERENCE_SPACE_TYPE_MAX_ENUM = 0x7FFFFFFF,
        }
        public enum XrEyeVisibility : uint
        {
            XR_EYE_VISIBILITY_BOTH = 0,
            XR_EYE_VISIBILITY_LEFT = 1,
            XR_EYE_VISIBILITY_RIGHT = 2,
            XR_EYE_VISIBILITY_MAX_ENUM = 0x7FFFFFFF,
        }
        public enum XrActionType : uint
        {
            XR_ACTION_TYPE_BOOLEAN_INPUT = 1,
            XR_ACTION_TYPE_FLOAT_INPUT = 2,
            XR_ACTION_TYPE_VECTOR2F_INPUT = 3,
            XR_ACTION_TYPE_POSE_INPUT = 4,
            XR_ACTION_TYPE_VIBRATION_OUTPUT = 100,
            XR_ACTION_TYPE_MAX_ENUM = 0x7FFFFFFF,
        }
        public enum XrSessionState : uint
        {
            XR_SESSION_STATE_UNKNOWN = 0,
            XR_SESSION_STATE_IDLE = 1,
            XR_SESSION_STATE_READY = 2,
            XR_SESSION_STATE_SYNCHRONIZED = 3,
            XR_SESSION_STATE_VISIBLE = 4,
            XR_SESSION_STATE_FOCUSED = 5,
            XR_SESSION_STATE_STOPPING = 6,
            XR_SESSION_STATE_LOSS_PENDING = 7,
            XR_SESSION_STATE_EXITING = 8,
            XR_SESSION_STATE_MAX_ENUM = 0x7FFFFFFF,
        }
        public enum XrObjectType : uint
        {
            XR_OBJECT_TYPE_UNKNOWN = 0,
            XR_OBJECT_TYPE_INSTANCE = 1,
            XR_OBJECT_TYPE_SESSION = 2,
            XR_OBJECT_TYPE_SWAPCHAIN = 3,
            XR_OBJECT_TYPE_SPACE = 4,
            XR_OBJECT_TYPE_ACTION_SET = 5,
            XR_OBJECT_TYPE_ACTION = 6,
            XR_OBJECT_TYPE_DEBUG_UTILS_MESSENGER_EXT = 1000019000,
            XR_OBJECT_TYPE_SPATIAL_ANCHOR_MSFT = 1000039000,
            XR_OBJECT_TYPE_SPATIAL_GRAPH_NODE_BINDING_MSFT = 1000049000,
            XR_OBJECT_TYPE_HAND_TRACKER_EXT = 1000051000,
            XR_OBJECT_TYPE_BODY_TRACKER_FB = 1000076000,
            XR_OBJECT_TYPE_SCENE_OBSERVER_MSFT = 1000097000,
            XR_OBJECT_TYPE_SCENE_MSFT = 1000097001,
            XR_OBJECT_TYPE_FACIAL_TRACKER_HTC = 1000104000,
            XR_OBJECT_TYPE_FOVEATION_PROFILE_FB = 1000114000,
            XR_OBJECT_TYPE_TRIANGLE_MESH_FB = 1000117000,
            XR_OBJECT_TYPE_PASSTHROUGH_FB = 1000118000,
            XR_OBJECT_TYPE_PASSTHROUGH_LAYER_FB = 1000118002,
            XR_OBJECT_TYPE_GEOMETRY_INSTANCE_FB = 1000118004,
            XR_OBJECT_TYPE_MARKER_DETECTOR_ML = 1000138000,
            XR_OBJECT_TYPE_EXPORTED_LOCALIZATION_MAP_ML = 1000139000,
            XR_OBJECT_TYPE_SPATIAL_ANCHORS_STORAGE_ML = 1000141000,
            XR_OBJECT_TYPE_SPATIAL_ANCHOR_STORE_CONNECTION_MSFT = 1000142000,
            XR_OBJECT_TYPE_FACE_TRACKER_FB = 1000201000,
            XR_OBJECT_TYPE_EYE_TRACKER_FB = 1000202000,
            XR_OBJECT_TYPE_VIRTUAL_KEYBOARD_META = 1000219000,
            XR_OBJECT_TYPE_SPACE_USER_FB = 1000241000,
            XR_OBJECT_TYPE_PASSTHROUGH_COLOR_LUT_META = 1000266000,
            XR_OBJECT_TYPE_FACE_TRACKER2_FB = 1000287012,
            XR_OBJECT_TYPE_ENVIRONMENT_DEPTH_PROVIDER_META = 1000291000,
            XR_OBJECT_TYPE_ENVIRONMENT_DEPTH_SWAPCHAIN_META = 1000291001,
            XR_OBJECT_TYPE_RENDER_MODEL_EXT = 1000300000,
            XR_OBJECT_TYPE_RENDER_MODEL_ASSET_EXT = 1000300001,
            XR_OBJECT_TYPE_PASSTHROUGH_HTC = 1000317000,
            XR_OBJECT_TYPE_BODY_TRACKER_HTC = 1000320000,
            XR_OBJECT_TYPE_BODY_TRACKER_BD = 1000385000,
            XR_OBJECT_TYPE_FACE_TRACKER_BD = 1000386000,
            XR_OBJECT_TYPE_SENSE_DATA_PROVIDER_BD = 1000389000,
            XR_OBJECT_TYPE_SENSE_DATA_SNAPSHOT_BD = 1000389001,
            XR_OBJECT_TYPE_ANCHOR_BD = 1000389002,
            XR_OBJECT_TYPE_SPATIAL_AUDIO_RENDERER_BD = 1000409000,
            XR_OBJECT_TYPE_SOUND_FIELD_BD = 1000409001,
            XR_OBJECT_TYPE_SOUND_OBJECT_BD = 1000409002,
            XR_OBJECT_TYPE_SOUND_OBSTACLE_BD = 1000409003,
            XR_OBJECT_TYPE_SOUND_OBSTACLE_MATERIAL_BD = 1000409004,
            XR_OBJECT_TYPE_PLANE_DETECTOR_EXT = 1000429000,
            XR_OBJECT_TYPE_TRACKABLE_TRACKER_ANDROID = 1000455001,
            XR_OBJECT_TYPE_EYE_TRACKER_ANDROID = 1000456000,
            XR_OBJECT_TYPE_DEVICE_ANCHOR_PERSISTENCE_ANDROID = 1000457000,
            XR_OBJECT_TYPE_FACE_TRACKER_ANDROID = 1000458000,
            XR_OBJECT_TYPE_PASSTHROUGH_LAYER_ANDROID = 1000462000,
            XR_OBJECT_TYPE_WORLD_MESH_DETECTOR_ML = 1000474000,
            XR_OBJECT_TYPE_FACIAL_EXPRESSION_CLIENT_ML = 1000482000,
            XR_OBJECT_TYPE_ENVIRONMENT_RAYCASTER_META = 1000592000,
            XR_OBJECT_TYPE_LIGHT_ESTIMATOR_ANDROID = 1000700000,
            XR_OBJECT_TYPE_TRACKABLE_IMAGE_DATABASE_ANDROID = 1000709000,
            XR_OBJECT_TYPE_SCENE_MESHING_TRACKER_ANDROID = 1000718000,
            XR_OBJECT_TYPE_SCENE_MESH_SNAPSHOT_ANDROID = 1000718001,
            XR_OBJECT_TYPE_SPATIAL_ENTITY_EXT = 1000740000,
            XR_OBJECT_TYPE_SPATIAL_CONTEXT_EXT = 1000740001,
            XR_OBJECT_TYPE_SPATIAL_SNAPSHOT_EXT = 1000740002,
            XR_OBJECT_TYPE_CAMERA_DEVICE_BD = 1000755000,
            XR_OBJECT_TYPE_CAMERA_CAPTURE_SESSION_BD = 1000755001,
            XR_OBJECT_TYPE_SPATIAL_PERSISTENCE_CONTEXT_EXT = 1000763000,
            XR_OBJECT_TYPE_SPATIAL_IMAGE_TRACKING_DATABASE_EXT = 1000782000,
            XR_OBJECT_TYPE_GEOSPATIAL_TRACKER_ANDROID = 1000789000,
            XR_OBJECT_TYPE_SPATIAL_CONTAINER_EXT = 1000810000,
            XR_OBJECT_TYPE_MAX_ENUM = 0x7FFFFFFF,
        }

        public unsafe partial struct XrApiLayerProperties
        {
            public Types.XrStructureType type;

            public void* next;
            public _layerName_e__FixedBuffer layerName;
            public ulong specVersion;
            public uint layerVersion;
            public _description_e__FixedBuffer description;

            [InlineArray(256)]
            public partial struct _layerName_e__FixedBuffer
            {
                public byte e0;
            }

            [InlineArray(256)]
            public partial struct _description_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrExtensionProperties
        {
            public Types.XrStructureType type;

            public void* next;
            public _extensionName_e__FixedBuffer extensionName;
            public uint extensionVersion;

            [InlineArray(128)]
            public partial struct _extensionName_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public partial struct XrApplicationInfo
        {
            public _applicationName_e__FixedBuffer applicationName;
            public uint applicationVersion;
            public _engineName_e__FixedBuffer engineName;
            public uint engineVersion;
            public ulong apiVersion;

            [InlineArray(128)]
            public partial struct _applicationName_e__FixedBuffer
            {
                public byte e0;
            }

            [InlineArray(128)]
            public partial struct _engineName_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrInstanceCreateInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong createFlags;

            public XrApplicationInfo applicationInfo;
            public uint enabledApiLayerCount;
            public byte** enabledApiLayerNames;
            public uint enabledExtensionCount;
            public byte** enabledExtensionNames;
        }

        public unsafe partial struct XrInstanceProperties
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong runtimeVersion;
            public _runtimeName_e__FixedBuffer runtimeName;

            [InlineArray(128)]
            public partial struct _runtimeName_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrEventDataBuffer
        {
            public Types.XrStructureType type;
            public void* next;
            public _varying_e__FixedBuffer varying;

            [InlineArray(4000)]
            public partial struct _varying_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrSystemGetInfo
        {
            public Types.XrStructureType type;
            public void* next;

            public XrFormFactor formFactor;
        }

        public partial struct XrSystemGraphicsProperties
        {
            public uint maxSwapchainImageHeight;
            public uint maxSwapchainImageWidth;
            public uint maxLayerCount;
        }

        public partial struct XrSystemTrackingProperties
        {
            public uint orientationTracking;
            public uint positionTracking;
        }

        public unsafe partial struct XrSystemProperties
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong systemId;
            public uint vendorId;
            public _systemName_e__FixedBuffer systemName;

            public XrSystemGraphicsProperties graphicsProperties;

            public XrSystemTrackingProperties trackingProperties;

            [InlineArray(256)]
            public partial struct _systemName_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrSessionCreateInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong createFlags;
            public ulong systemId;
        }

        public partial struct XrQuaternionf
        {
            public float x;

            public float y;

            public float z;

            public float w;
        }

        public partial struct XrVector3f
        {
            public float x;

            public float y;

            public float z;
        }

        public partial struct XrPosef
        {
            public XrQuaternionf orientation;

            public XrVector3f position;
        }

        public unsafe partial struct XrReferenceSpaceCreateInfo
        {
            public Types.XrStructureType type;
            public void* next;

            public XrReferenceSpaceType referenceSpaceType;

            public XrPosef poseInReferenceSpace;
        }

        public unsafe partial struct XrActionSpaceCreateInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr action;
            public ulong subactionPath;

            public XrPosef poseInActionSpace;
        }

        public unsafe partial struct XrSpaceLocation
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong locationFlags;

            public XrPosef pose;
        }

        public unsafe partial struct XrSpaceVelocity
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong velocityFlags;

            public XrVector3f linearVelocity;

            public XrVector3f angularVelocity;
        }

        public partial struct XrExtent2Df
        {
            public float width;

            public float height;
        }

        public unsafe partial struct XrViewConfigurationProperties
        {
            public Types.XrStructureType type;

            public void* next;

            public XrViewConfigurationType viewConfigurationType;
            public uint fovMutable;
        }

        public unsafe partial struct XrViewConfigurationView
        {
            public Types.XrStructureType type;

            public void* next;
            public uint recommendedImageRectWidth;
            public uint maxImageRectWidth;
            public uint recommendedImageRectHeight;
            public uint maxImageRectHeight;
            public uint recommendedSwapchainSampleCount;
            public uint maxSwapchainSampleCount;
        }

        public unsafe partial struct XrSwapchainCreateInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong createFlags;
            public ulong usageFlags;
            public long format;
            public uint sampleCount;
            public uint width;
            public uint height;
            public uint faceCount;
            public uint arraySize;
            public uint mipCount;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public unsafe partial struct XrSwapchainImageBaseHeader
        {
            public Types.XrStructureType type;

            public void* next;
        }

        public unsafe partial struct XrSwapchainImageAcquireInfo
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSwapchainImageWaitInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public long timeout;
        }

        public unsafe partial struct XrSwapchainImageReleaseInfo
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSessionBeginInfo
        {
            public Types.XrStructureType type;
            public void* next;

            public XrViewConfigurationType primaryViewConfigurationType;
        }

        public unsafe partial struct XrFrameState
        {
            public Types.XrStructureType type;

            public void* next;
            public long predictedDisplayTime;
            public long predictedDisplayPeriod;
            public uint shouldRender;
        }

        public unsafe partial struct XrFrameWaitInfo
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrFrameBeginInfo
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrCompositionLayerBaseHeader
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;
            public IntPtr space;
        }

        public unsafe partial struct XrFrameEndInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public long displayTime;

            public XrEnvironmentBlendMode environmentBlendMode;
            public uint layerCount;
            public XrCompositionLayerBaseHeader** layers;
        }

        public unsafe partial struct XrViewState
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong viewStateFlags;
        }

        public unsafe partial struct XrViewLocateInfo
        {
            public Types.XrStructureType type;
            public void* next;

            public XrViewConfigurationType viewConfigurationType;
            public long displayTime;
            public IntPtr space;
        }

        public partial struct XrFovf
        {
            public float angleLeft;

            public float angleRight;

            public float angleUp;

            public float angleDown;
        }

        public unsafe partial struct XrView
        {
            public Types.XrStructureType type;

            public void* next;

            public XrPosef pose;

            public XrFovf fov;
        }

        public unsafe partial struct XrActionSetCreateInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public _actionSetName_e__FixedBuffer actionSetName;
            public _localizedActionSetName_e__FixedBuffer localizedActionSetName;
            public uint priority;

            [InlineArray(64)]
            public partial struct _actionSetName_e__FixedBuffer
            {
                public byte e0;
            }

            [InlineArray(128)]
            public partial struct _localizedActionSetName_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrActionCreateInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public _actionName_e__FixedBuffer actionName;

            public XrActionType actionType;
            public uint countSubactionPaths;
            public ulong* subactionPaths;
            public _localizedActionName_e__FixedBuffer localizedActionName;

            [InlineArray(64)]
            public partial struct _actionName_e__FixedBuffer
            {
                public byte e0;
            }

            [InlineArray(128)]
            public partial struct _localizedActionName_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrActionSuggestedBinding
        {
            public IntPtr action;
            public ulong binding;
        }

        public unsafe partial struct XrInteractionProfileSuggestedBinding
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong interactionProfile;
            public uint countSuggestedBindings;
            public XrActionSuggestedBinding* suggestedBindings;
        }

        public unsafe partial struct XrSessionActionSetsAttachInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public uint countActionSets;
            public IntPtr* actionSets;
        }

        public unsafe partial struct XrInteractionProfileState
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong interactionProfile;
        }

        public unsafe partial struct XrActionStateGetInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr action;
            public ulong subactionPath;
        }

        public unsafe partial struct XrActionStateBoolean
        {
            public Types.XrStructureType type;

            public void* next;
            public uint currentState;
            public uint changedSinceLastSync;
            public long lastChangeTime;
            public uint isActive;
        }

        public unsafe partial struct XrActionStateFloat
        {
            public Types.XrStructureType type;

            public void* next;

            public float currentState;
            public uint changedSinceLastSync;
            public long lastChangeTime;
            public uint isActive;
        }

        public partial struct XrVector2f
        {
            public float x;

            public float y;
        }

        public unsafe partial struct XrActionStateVector2f
        {
            public Types.XrStructureType type;

            public void* next;

            public XrVector2f currentState;
            public uint changedSinceLastSync;
            public long lastChangeTime;
            public uint isActive;
        }

        public unsafe partial struct XrActionStatePose
        {
            public Types.XrStructureType type;

            public void* next;
            public uint isActive;
        }

        public unsafe partial struct XrActiveActionSet
        {
            public IntPtr actionSet;
            public ulong subactionPath;
        }

        public unsafe partial struct XrActionsSyncInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public uint countActiveActionSets;
            public XrActiveActionSet* activeActionSets;
        }

        public unsafe partial struct XrBoundSourcesForActionEnumerateInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr action;
        }

        public unsafe partial struct XrInputSourceLocalizedNameGetInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong sourcePath;
            public ulong whichComponents;
        }

        public unsafe partial struct XrHapticBaseHeader
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrHapticActionInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr action;
            public ulong subactionPath;
        }

        public unsafe partial struct XrBaseInStructure
        {
            public Types.XrStructureType type;
            public XrBaseInStructure* next;
        }

        public unsafe partial struct XrBaseOutStructure
        {
            public Types.XrStructureType type;
            public XrBaseOutStructure* next;
        }

        public partial struct XrOffset2Di
        {
            public int x;
            public int y;
        }

        public partial struct XrExtent2Di
        {
            public int width;
            public int height;
        }

        public partial struct XrRect2Di
        {
            public XrOffset2Di offset;

            public XrExtent2Di extent;
        }

        public unsafe partial struct XrSwapchainSubImage
        {
            public IntPtr swapchain;

            public XrRect2Di imageRect;
            public uint imageArrayIndex;
        }

        public unsafe partial struct XrCompositionLayerProjectionView
        {
            public Types.XrStructureType type;
            public void* next;

            public XrPosef pose;

            public XrFovf fov;

            public XrSwapchainSubImage subImage;
        }

        public unsafe partial struct XrCompositionLayerProjection
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;
            public IntPtr space;
            public uint viewCount;
            public XrCompositionLayerProjectionView* views;
        }

        public unsafe partial struct XrCompositionLayerQuad
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;
            public IntPtr space;

            public XrEyeVisibility eyeVisibility;

            public XrSwapchainSubImage subImage;

            public XrPosef pose;

            public XrExtent2Df size;
        }

        public unsafe partial struct XrEventDataBaseHeader
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrEventDataEventsLost
        {
            public Types.XrStructureType type;
            public void* next;
            public uint lostEventCount;
        }

        public unsafe partial struct XrEventDataInstanceLossPending
        {
            public Types.XrStructureType type;
            public void* next;
            public long lossTime;
        }

        public unsafe partial struct XrEventDataSessionStateChanged
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr session;

            public XrSessionState state;
            public long time;
        }

        public unsafe partial struct XrEventDataReferenceSpaceChangePending
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr session;

            public XrReferenceSpaceType referenceSpaceType;
            public long changeTime;
            public uint poseValid;

            public XrPosef poseInPreviousSpace;
        }

        public unsafe partial struct XrEventDataInteractionProfileChanged
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr session;
        }

        public unsafe partial struct XrHapticVibration
        {
            public Types.XrStructureType type;
            public void* next;
            public long duration;

            public float frequency;

            public float amplitude;
        }

        public partial struct XrOffset2Df
        {
            public float x;

            public float y;
        }

        public partial struct XrRect2Df
        {
            public XrOffset2Df offset;

            public XrExtent2Df extent;
        }

        public partial struct XrVector4f
        {
            public float x;

            public float y;

            public float z;

            public float w;
        }

        public partial struct XrColor4f
        {
            public float r;

            public float g;

            public float b;

            public float a;
        }

        public partial struct XrColor3f
        {
            public float r;

            public float g;

            public float b;
        }

        public partial struct XrExtent3Df
        {
            public float width;

            public float height;

            public float depth;
        }

        public partial struct XrSpheref
        {
            public XrPosef center;

            public float radius;
        }

        public partial struct XrBoxf
        {
            public XrPosef center;

            public XrExtent3Df extents;
        }

        public partial struct XrFrustumf
        {
            public XrPosef pose;

            public XrFovf fov;

            public float nearZ;

            public float farZ;
        }

        public partial struct XrUuid
        {
            public _data_e__FixedBuffer data;

            [InlineArray(16)]
            public partial struct _data_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrSpacesLocateInfo
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;
            public uint spaceCount;
            public IntPtr* spaces;
        }

        public partial struct XrSpaceLocationData
        {
            public ulong locationFlags;

            public XrPosef pose;
        }

        public unsafe partial struct XrSpaceLocations
        {
            public Types.XrStructureType type;

            public void* next;
            public uint locationCount;

            public XrSpaceLocationData* locations;
        }

        public partial struct XrSpaceVelocityData
        {
            public ulong velocityFlags;

            public XrVector3f linearVelocity;

            public XrVector3f angularVelocity;
        }

        public unsafe partial struct XrSpaceVelocities
        {
            public Types.XrStructureType type;

            public void* next;
            public uint velocityCount;

            public XrSpaceVelocityData* velocities;
        }

        public unsafe partial struct XrCompositionLayerCubeKHR
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;
            public IntPtr space;

            public XrEyeVisibility eyeVisibility;
            public IntPtr swapchain;
            public uint imageArrayIndex;

            public XrQuaternionf orientation;
        }

        public unsafe partial struct XrCompositionLayerDepthInfoKHR
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSwapchainSubImage subImage;

            public float minDepth;

            public float maxDepth;

            public float nearZ;

            public float farZ;
        }

        public unsafe partial struct XrCompositionLayerCylinderKHR
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;
            public IntPtr space;

            public XrEyeVisibility eyeVisibility;

            public XrSwapchainSubImage subImage;

            public XrPosef pose;

            public float radius;

            public float centralAngle;

            public float aspectRatio;
        }

        public unsafe partial struct XrCompositionLayerEquirectKHR
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;
            public IntPtr space;

            public XrEyeVisibility eyeVisibility;

            public XrSwapchainSubImage subImage;

            public XrPosef pose;

            public float radius;

            public XrVector2f scale;

            public XrVector2f bias;
        }
        public enum XrVisibilityMaskTypeKHR : uint
        {
            XR_VISIBILITY_MASK_TYPE_HIDDEN_TRIANGLE_MESH_KHR = 1,
            XR_VISIBILITY_MASK_TYPE_VISIBLE_TRIANGLE_MESH_KHR = 2,
            XR_VISIBILITY_MASK_TYPE_LINE_LOOP_KHR = 3,
            XR_VISIBILITY_MASK_TYPE_MAX_ENUM_KHR = 0x7FFFFFFF,
        }

        public unsafe partial struct XrVisibilityMaskKHR
        {
            public Types.XrStructureType type;

            public void* next;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrVector2f* vertices;
            public uint indexCapacityInput;
            public uint indexCountOutput;
            public uint* indices;
        }

        public unsafe partial struct XrEventDataVisibilityMaskChangedKHR
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr session;

            public XrViewConfigurationType viewConfigurationType;
            public uint viewIndex;
        }

        public unsafe partial struct XrCompositionLayerColorScaleBiasKHR
        {
            public Types.XrStructureType type;
            public void* next;

            public XrColor4f colorScale;

            public XrColor4f colorBias;
        }

        public unsafe partial struct XrLoaderInitInfoBaseHeaderKHR
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrCompositionLayerEquirect2KHR
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;
            public IntPtr space;

            public XrEyeVisibility eyeVisibility;

            public XrSwapchainSubImage subImage;

            public XrPosef pose;

            public float radius;

            public float centralHorizontalAngle;

            public float upperVerticalAngle;

            public float lowerVerticalAngle;
        }

        public unsafe partial struct XrBindingModificationBaseHeaderKHR
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrBindingModificationsKHR
        {
            public Types.XrStructureType type;
            public void* next;
            public uint bindingModificationCount;
            public XrBindingModificationBaseHeaderKHR** bindingModifications;
        }
        public enum XrPerfSettingsDomainEXT : uint
        {
            XR_PERF_SETTINGS_DOMAIN_CPU_EXT = 1,
            XR_PERF_SETTINGS_DOMAIN_GPU_EXT = 2,
            XR_PERF_SETTINGS_DOMAIN_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrPerfSettingsSubDomainEXT : uint
        {
            XR_PERF_SETTINGS_SUB_DOMAIN_COMPOSITING_EXT = 1,
            XR_PERF_SETTINGS_SUB_DOMAIN_RENDERING_EXT = 2,
            XR_PERF_SETTINGS_SUB_DOMAIN_THERMAL_EXT = 3,
            XR_PERF_SETTINGS_SUB_DOMAIN_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrPerfSettingsLevelEXT : uint
        {
            XR_PERF_SETTINGS_LEVEL_POWER_SAVINGS_EXT = 0,
            XR_PERF_SETTINGS_LEVEL_SUSTAINED_LOW_EXT = 25,
            XR_PERF_SETTINGS_LEVEL_SUSTAINED_HIGH_EXT = 50,
            XR_PERF_SETTINGS_LEVEL_BOOST_EXT = 75,
            XR_PERF_SETTINGS_LEVEL_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrPerfSettingsNotificationLevelEXT : uint
        {
            XR_PERF_SETTINGS_NOTIF_LEVEL_NORMAL_EXT = 0,
            XR_PERF_SETTINGS_NOTIF_LEVEL_WARNING_EXT = 25,
            XR_PERF_SETTINGS_NOTIF_LEVEL_IMPAIRED_EXT = 75,
            XR_PERF_SETTINGS_NOTIFICATION_LEVEL_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrEventDataPerfSettingsEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrPerfSettingsDomainEXT domain;

            public XrPerfSettingsSubDomainEXT subDomain;

            public XrPerfSettingsNotificationLevelEXT fromLevel;

            public XrPerfSettingsNotificationLevelEXT toLevel;
        }

        public partial struct XrDebugUtilsMessengerEXT
        {
        }

        public unsafe partial struct XrDebugUtilsObjectNameInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrObjectType objectType;
            public ulong objectHandle;
            public byte* objectName;
        }

        public unsafe partial struct XrDebugUtilsLabelEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public byte* labelName;
        }

        public unsafe partial struct XrDebugUtilsMessengerCallbackDataEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public byte* messageId;
            public byte* functionName;
            public byte* message;
            public uint objectCount;

            public XrDebugUtilsObjectNameInfoEXT* objects;
            public uint sessionLabelCount;

            public XrDebugUtilsLabelEXT* sessionLabels;
        }

        public unsafe partial struct XrDebugUtilsMessengerCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong messageSeverities;
            public ulong messageTypes;
            public delegate* unmanaged[Cdecl]<ulong, ulong, XrDebugUtilsMessengerCallbackDataEXT*, void*, uint> userCallback;

            public void* userData;
        }

        public unsafe partial struct XrSystemEyeGazeInteractionPropertiesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsEyeGazeInteraction;
        }

        public unsafe partial struct XrEyeGazeSampleTimeEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public long time;
        }

        public unsafe partial struct XrSessionCreateInfoOverlayEXTX
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong createFlags;
            public uint sessionLayersPlacement;
        }

        public unsafe partial struct XrEventDataMainSessionVisibilityChangedEXTX
        {
            public Types.XrStructureType type;
            public void* next;
            public uint visible;
            public ulong flags;
        }

        public partial struct XrSpatialAnchorMSFT
        {
        }

        public unsafe partial struct XrSpatialAnchorCreateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;

            public XrPosef pose;
            public long time;
        }

        public unsafe partial struct XrSpatialAnchorSpaceCreateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialAnchorMSFT* anchor;

            public XrPosef poseInAnchorSpace;
        }

        public unsafe partial struct XrCompositionLayerImageLayoutFB
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong flags;
        }
        public enum XrBlendFactorFB : uint
        {
            XR_BLEND_FACTOR_ZERO_FB = 0,
            XR_BLEND_FACTOR_ONE_FB = 1,
            XR_BLEND_FACTOR_SRC_ALPHA_FB = 2,
            XR_BLEND_FACTOR_ONE_MINUS_SRC_ALPHA_FB = 3,
            XR_BLEND_FACTOR_DST_ALPHA_FB = 4,
            XR_BLEND_FACTOR_ONE_MINUS_DST_ALPHA_FB = 5,
            XR_BLEND_FACTOR_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrCompositionLayerAlphaBlendFB
        {
            public Types.XrStructureType type;

            public void* next;

            public XrBlendFactorFB srcFactorColor;

            public XrBlendFactorFB dstFactorColor;

            public XrBlendFactorFB srcFactorAlpha;

            public XrBlendFactorFB dstFactorAlpha;
        }

        public unsafe partial struct XrViewConfigurationDepthRangeEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public float recommendedNearZ;

            public float minNearZ;

            public float recommendedFarZ;

            public float maxFarZ;
        }

        public partial struct XrSpatialGraphNodeBindingMSFT
        {
        }
        public enum XrSpatialGraphNodeTypeMSFT : uint
        {
            XR_SPATIAL_GRAPH_NODE_TYPE_STATIC_MSFT = 1,
            XR_SPATIAL_GRAPH_NODE_TYPE_DYNAMIC_MSFT = 2,
            XR_SPATIAL_GRAPH_NODE_TYPE_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpatialGraphNodeSpaceCreateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialGraphNodeTypeMSFT nodeType;
            public _nodeId_e__FixedBuffer nodeId;

            public XrPosef pose;

            [InlineArray(16)]
            public partial struct _nodeId_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrSpatialGraphStaticNodeBindingCreateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;

            public XrPosef poseInSpace;
            public long time;
        }

        public unsafe partial struct XrSpatialGraphNodeBindingPropertiesGetInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpatialGraphNodeBindingPropertiesMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public _nodeId_e__FixedBuffer nodeId;

            public XrPosef poseInNodeSpace;

            [InlineArray(16)]
            public partial struct _nodeId_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public partial struct XrHandTrackerEXT
        {
        }
        public enum XrHandEXT : uint
        {
            XR_HAND_LEFT_EXT = 1,
            XR_HAND_RIGHT_EXT = 2,
            XR_HAND_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrHandJointEXT : uint
        {
            XR_HAND_JOINT_PALM_EXT = 0,
            XR_HAND_JOINT_WRIST_EXT = 1,
            XR_HAND_JOINT_THUMB_METACARPAL_EXT = 2,
            XR_HAND_JOINT_THUMB_PROXIMAL_EXT = 3,
            XR_HAND_JOINT_THUMB_DISTAL_EXT = 4,
            XR_HAND_JOINT_THUMB_TIP_EXT = 5,
            XR_HAND_JOINT_INDEX_METACARPAL_EXT = 6,
            XR_HAND_JOINT_INDEX_PROXIMAL_EXT = 7,
            XR_HAND_JOINT_INDEX_INTERMEDIATE_EXT = 8,
            XR_HAND_JOINT_INDEX_DISTAL_EXT = 9,
            XR_HAND_JOINT_INDEX_TIP_EXT = 10,
            XR_HAND_JOINT_MIDDLE_METACARPAL_EXT = 11,
            XR_HAND_JOINT_MIDDLE_PROXIMAL_EXT = 12,
            XR_HAND_JOINT_MIDDLE_INTERMEDIATE_EXT = 13,
            XR_HAND_JOINT_MIDDLE_DISTAL_EXT = 14,
            XR_HAND_JOINT_MIDDLE_TIP_EXT = 15,
            XR_HAND_JOINT_RING_METACARPAL_EXT = 16,
            XR_HAND_JOINT_RING_PROXIMAL_EXT = 17,
            XR_HAND_JOINT_RING_INTERMEDIATE_EXT = 18,
            XR_HAND_JOINT_RING_DISTAL_EXT = 19,
            XR_HAND_JOINT_RING_TIP_EXT = 20,
            XR_HAND_JOINT_LITTLE_METACARPAL_EXT = 21,
            XR_HAND_JOINT_LITTLE_PROXIMAL_EXT = 22,
            XR_HAND_JOINT_LITTLE_INTERMEDIATE_EXT = 23,
            XR_HAND_JOINT_LITTLE_DISTAL_EXT = 24,
            XR_HAND_JOINT_LITTLE_TIP_EXT = 25,
            XR_HAND_JOINT_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrHandJointSetEXT : uint
        {
            XR_HAND_JOINT_SET_DEFAULT_EXT = 0,
            XR_HAND_JOINT_SET_HAND_WITH_FOREARM_ULTRALEAP = 1000149000,
            XR_HAND_JOINT_SET_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemHandTrackingPropertiesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsHandTracking;
        }

        public unsafe partial struct XrHandTrackerCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrHandEXT hand;

            public XrHandJointSetEXT handJointSet;
        }

        public unsafe partial struct XrHandJointsLocateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;
        }

        public partial struct XrHandJointLocationEXT
        {
            public ulong locationFlags;

            public XrPosef pose;

            public float radius;
        }

        public partial struct XrHandJointVelocityEXT
        {
            public ulong velocityFlags;

            public XrVector3f linearVelocity;

            public XrVector3f angularVelocity;
        }

        public unsafe partial struct XrHandJointLocationsEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint isActive;
            public uint jointCount;

            public XrHandJointLocationEXT* jointLocations;
        }

        public unsafe partial struct XrHandJointVelocitiesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint jointCount;

            public XrHandJointVelocityEXT* jointVelocities;
        }
        public enum XrHandPoseTypeMSFT : uint
        {
            XR_HAND_POSE_TYPE_TRACKED_MSFT = 0,
            XR_HAND_POSE_TYPE_REFERENCE_OPEN_PALM_MSFT = 1,
            XR_HAND_POSE_TYPE_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemHandTrackingMeshPropertiesMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsHandTrackingMesh;
            public uint maxHandMeshIndexCount;
            public uint maxHandMeshVertexCount;
        }

        public unsafe partial struct XrHandMeshSpaceCreateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrHandPoseTypeMSFT handPoseType;

            public XrPosef poseInHandMeshSpace;
        }

        public unsafe partial struct XrHandMeshUpdateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public long time;

            public XrHandPoseTypeMSFT handPoseType;
        }

        public unsafe partial struct XrHandMeshIndexBufferMSFT
        {
            public uint indexBufferKey;
            public uint indexCapacityInput;
            public uint indexCountOutput;
            public uint* indices;
        }

        public partial struct XrHandMeshVertexMSFT
        {
            public XrVector3f position;

            public XrVector3f normal;
        }

        public unsafe partial struct XrHandMeshVertexBufferMSFT
        {
            public long vertexUpdateTime;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrHandMeshVertexMSFT* vertices;
        }

        public unsafe partial struct XrHandMeshMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint isActive;
            public uint indexBufferChanged;
            public uint vertexBufferChanged;

            public XrHandMeshIndexBufferMSFT indexBuffer;

            public XrHandMeshVertexBufferMSFT vertexBuffer;
        }

        public unsafe partial struct XrHandPoseTypeInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrHandPoseTypeMSFT handPoseType;
        }

        public unsafe partial struct XrSecondaryViewConfigurationSessionBeginInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint viewConfigurationCount;
            public XrViewConfigurationType* enabledViewConfigurationTypes;
        }

        public unsafe partial struct XrSecondaryViewConfigurationStateMSFT
        {
            public Types.XrStructureType type;

            public void* next;

            public XrViewConfigurationType viewConfigurationType;
            public uint active;
        }

        public unsafe partial struct XrSecondaryViewConfigurationFrameStateMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint viewConfigurationCount;

            public XrSecondaryViewConfigurationStateMSFT* viewConfigurationStates;
        }

        public unsafe partial struct XrSecondaryViewConfigurationLayerInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrViewConfigurationType viewConfigurationType;

            public XrEnvironmentBlendMode environmentBlendMode;
            public uint layerCount;
            public XrCompositionLayerBaseHeader** layers;
        }

        public unsafe partial struct XrSecondaryViewConfigurationFrameEndInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint viewConfigurationCount;
            public XrSecondaryViewConfigurationLayerInfoMSFT* viewConfigurationLayersInfo;
        }

        public unsafe partial struct XrSecondaryViewConfigurationSwapchainCreateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrViewConfigurationType viewConfigurationType;
        }

        public unsafe partial struct XrControllerModelKeyStateMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong modelKey;
        }

        public unsafe partial struct XrControllerModelNodePropertiesMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public _parentNodeName_e__FixedBuffer parentNodeName;
            public _nodeName_e__FixedBuffer nodeName;

            [InlineArray(64)]
            public partial struct _parentNodeName_e__FixedBuffer
            {
                public byte e0;
            }

            [InlineArray(64)]
            public partial struct _nodeName_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrControllerModelPropertiesMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint nodeCapacityInput;
            public uint nodeCountOutput;

            public XrControllerModelNodePropertiesMSFT* nodeProperties;
        }

        public unsafe partial struct XrControllerModelNodeStateMSFT
        {
            public Types.XrStructureType type;

            public void* next;

            public XrPosef nodePose;
        }

        public unsafe partial struct XrControllerModelStateMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint nodeCapacityInput;
            public uint nodeCountOutput;

            public XrControllerModelNodeStateMSFT* nodeStates;
        }

        public unsafe partial struct XrViewConfigurationViewFovEPIC
        {
            public Types.XrStructureType type;
            public void* next;

            public XrFovf recommendedFov;

            public XrFovf maxMutableFov;
        }
        public enum XrReprojectionModeMSFT : uint
        {
            XR_REPROJECTION_MODE_DEPTH_MSFT = 1,
            XR_REPROJECTION_MODE_PLANAR_FROM_DEPTH_MSFT = 2,
            XR_REPROJECTION_MODE_PLANAR_MANUAL_MSFT = 3,
            XR_REPROJECTION_MODE_ORIENTATION_ONLY_MSFT = 4,
            XR_REPROJECTION_MODE_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrCompositionLayerReprojectionInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrReprojectionModeMSFT reprojectionMode;
        }

        public unsafe partial struct XrCompositionLayerReprojectionPlaneOverrideMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrVector3f position;

            public XrVector3f normal;

            public XrVector3f velocity;
        }

        public unsafe partial struct XrSwapchainStateBaseHeaderFB
        {
            public Types.XrStructureType type;

            public void* next;
        }

        public unsafe partial struct XrCompositionLayerSecureContentFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;
        }

        public partial struct XrBodyTrackerFB
        {
        }

        public enum XrBodyJointFB
        {
            XR_BODY_JOINT_ROOT_FB = 0,
            XR_BODY_JOINT_HIPS_FB = 1,
            XR_BODY_JOINT_SPINE_LOWER_FB = 2,
            XR_BODY_JOINT_SPINE_MIDDLE_FB = 3,
            XR_BODY_JOINT_SPINE_UPPER_FB = 4,
            XR_BODY_JOINT_CHEST_FB = 5,
            XR_BODY_JOINT_NECK_FB = 6,
            XR_BODY_JOINT_HEAD_FB = 7,
            XR_BODY_JOINT_LEFT_SHOULDER_FB = 8,
            XR_BODY_JOINT_LEFT_SCAPULA_FB = 9,
            XR_BODY_JOINT_LEFT_ARM_UPPER_FB = 10,
            XR_BODY_JOINT_LEFT_ARM_LOWER_FB = 11,
            XR_BODY_JOINT_LEFT_HAND_WRIST_TWIST_FB = 12,
            XR_BODY_JOINT_RIGHT_SHOULDER_FB = 13,
            XR_BODY_JOINT_RIGHT_SCAPULA_FB = 14,
            XR_BODY_JOINT_RIGHT_ARM_UPPER_FB = 15,
            XR_BODY_JOINT_RIGHT_ARM_LOWER_FB = 16,
            XR_BODY_JOINT_RIGHT_HAND_WRIST_TWIST_FB = 17,
            XR_BODY_JOINT_LEFT_HAND_PALM_FB = 18,
            XR_BODY_JOINT_LEFT_HAND_WRIST_FB = 19,
            XR_BODY_JOINT_LEFT_HAND_THUMB_METACARPAL_FB = 20,
            XR_BODY_JOINT_LEFT_HAND_THUMB_PROXIMAL_FB = 21,
            XR_BODY_JOINT_LEFT_HAND_THUMB_DISTAL_FB = 22,
            XR_BODY_JOINT_LEFT_HAND_THUMB_TIP_FB = 23,
            XR_BODY_JOINT_LEFT_HAND_INDEX_METACARPAL_FB = 24,
            XR_BODY_JOINT_LEFT_HAND_INDEX_PROXIMAL_FB = 25,
            XR_BODY_JOINT_LEFT_HAND_INDEX_INTERMEDIATE_FB = 26,
            XR_BODY_JOINT_LEFT_HAND_INDEX_DISTAL_FB = 27,
            XR_BODY_JOINT_LEFT_HAND_INDEX_TIP_FB = 28,
            XR_BODY_JOINT_LEFT_HAND_MIDDLE_METACARPAL_FB = 29,
            XR_BODY_JOINT_LEFT_HAND_MIDDLE_PROXIMAL_FB = 30,
            XR_BODY_JOINT_LEFT_HAND_MIDDLE_INTERMEDIATE_FB = 31,
            XR_BODY_JOINT_LEFT_HAND_MIDDLE_DISTAL_FB = 32,
            XR_BODY_JOINT_LEFT_HAND_MIDDLE_TIP_FB = 33,
            XR_BODY_JOINT_LEFT_HAND_RING_METACARPAL_FB = 34,
            XR_BODY_JOINT_LEFT_HAND_RING_PROXIMAL_FB = 35,
            XR_BODY_JOINT_LEFT_HAND_RING_INTERMEDIATE_FB = 36,
            XR_BODY_JOINT_LEFT_HAND_RING_DISTAL_FB = 37,
            XR_BODY_JOINT_LEFT_HAND_RING_TIP_FB = 38,
            XR_BODY_JOINT_LEFT_HAND_LITTLE_METACARPAL_FB = 39,
            XR_BODY_JOINT_LEFT_HAND_LITTLE_PROXIMAL_FB = 40,
            XR_BODY_JOINT_LEFT_HAND_LITTLE_INTERMEDIATE_FB = 41,
            XR_BODY_JOINT_LEFT_HAND_LITTLE_DISTAL_FB = 42,
            XR_BODY_JOINT_LEFT_HAND_LITTLE_TIP_FB = 43,
            XR_BODY_JOINT_RIGHT_HAND_PALM_FB = 44,
            XR_BODY_JOINT_RIGHT_HAND_WRIST_FB = 45,
            XR_BODY_JOINT_RIGHT_HAND_THUMB_METACARPAL_FB = 46,
            XR_BODY_JOINT_RIGHT_HAND_THUMB_PROXIMAL_FB = 47,
            XR_BODY_JOINT_RIGHT_HAND_THUMB_DISTAL_FB = 48,
            XR_BODY_JOINT_RIGHT_HAND_THUMB_TIP_FB = 49,
            XR_BODY_JOINT_RIGHT_HAND_INDEX_METACARPAL_FB = 50,
            XR_BODY_JOINT_RIGHT_HAND_INDEX_PROXIMAL_FB = 51,
            XR_BODY_JOINT_RIGHT_HAND_INDEX_INTERMEDIATE_FB = 52,
            XR_BODY_JOINT_RIGHT_HAND_INDEX_DISTAL_FB = 53,
            XR_BODY_JOINT_RIGHT_HAND_INDEX_TIP_FB = 54,
            XR_BODY_JOINT_RIGHT_HAND_MIDDLE_METACARPAL_FB = 55,
            XR_BODY_JOINT_RIGHT_HAND_MIDDLE_PROXIMAL_FB = 56,
            XR_BODY_JOINT_RIGHT_HAND_MIDDLE_INTERMEDIATE_FB = 57,
            XR_BODY_JOINT_RIGHT_HAND_MIDDLE_DISTAL_FB = 58,
            XR_BODY_JOINT_RIGHT_HAND_MIDDLE_TIP_FB = 59,
            XR_BODY_JOINT_RIGHT_HAND_RING_METACARPAL_FB = 60,
            XR_BODY_JOINT_RIGHT_HAND_RING_PROXIMAL_FB = 61,
            XR_BODY_JOINT_RIGHT_HAND_RING_INTERMEDIATE_FB = 62,
            XR_BODY_JOINT_RIGHT_HAND_RING_DISTAL_FB = 63,
            XR_BODY_JOINT_RIGHT_HAND_RING_TIP_FB = 64,
            XR_BODY_JOINT_RIGHT_HAND_LITTLE_METACARPAL_FB = 65,
            XR_BODY_JOINT_RIGHT_HAND_LITTLE_PROXIMAL_FB = 66,
            XR_BODY_JOINT_RIGHT_HAND_LITTLE_INTERMEDIATE_FB = 67,
            XR_BODY_JOINT_RIGHT_HAND_LITTLE_DISTAL_FB = 68,
            XR_BODY_JOINT_RIGHT_HAND_LITTLE_TIP_FB = 69,
            XR_BODY_JOINT_COUNT_FB = 70,
            XR_BODY_JOINT_NONE_FB = -1,
            XR_BODY_JOINT_MAX_ENUM_FB = 0x7FFFFFFF,
        }
        public enum XrBodyJointSetFB : uint
        {
            XR_BODY_JOINT_SET_DEFAULT_FB = 0,
            XR_BODY_JOINT_SET_FULL_BODY_META = 1000274000,
            XR_BODY_JOINT_SET_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public partial struct XrBodyJointLocationFB
        {
            public ulong locationFlags;

            public XrPosef pose;
        }

        public unsafe partial struct XrSystemBodyTrackingPropertiesFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsBodyTracking;
        }

        public unsafe partial struct XrBodyTrackerCreateInfoFB
        {
            public Types.XrStructureType type;
            public void* next;

            public XrBodyJointSetFB bodyJointSet;
        }

        public partial struct XrBodySkeletonJointFB
        {
            public int joint;
            public int parentJoint;

            public XrPosef pose;
        }

        public unsafe partial struct XrBodySkeletonFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint jointCount;

            public XrBodySkeletonJointFB* joints;
        }

        public unsafe partial struct XrBodyJointsLocateInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;
        }

        public unsafe partial struct XrBodyJointLocationsFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint isActive;

            public float confidence;
            public uint jointCount;

            public XrBodyJointLocationFB* jointLocations;
            public uint skeletonChangedCount;
            public long time;
        }

        public unsafe partial struct XrInteractionProfileDpadBindingEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong binding;
            public IntPtr actionSet;

            public float forceThreshold;

            public float forceThresholdReleased;

            public float centerRegion;

            public float wedgeAngle;
            public uint isSticky;
            public XrHapticBaseHeader* onHaptic;
            public XrHapticBaseHeader* offHaptic;
        }

        public unsafe partial struct XrInteractionProfileAnalogThresholdVALVE
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr action;
            public ulong binding;

            public float onThreshold;

            public float offThreshold;
            public XrHapticBaseHeader* onHaptic;
            public XrHapticBaseHeader* offHaptic;
        }
        public enum XrHandJointsMotionRangeEXT : uint
        {
            XR_HAND_JOINTS_MOTION_RANGE_UNOBSTRUCTED_EXT = 1,
            XR_HAND_JOINTS_MOTION_RANGE_CONFORMING_TO_CONTROLLER_EXT = 2,
            XR_HAND_JOINTS_MOTION_RANGE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrHandJointsMotionRangeInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrHandJointsMotionRangeEXT handJointsMotionRange;
        }

        public partial struct XrSceneMSFT
        {
        }

        public partial struct XrSceneObserverMSFT
        {
        }
        public enum XrSceneComputeFeatureMSFT : uint
        {
            XR_SCENE_COMPUTE_FEATURE_PLANE_MSFT = 1,
            XR_SCENE_COMPUTE_FEATURE_PLANE_MESH_MSFT = 2,
            XR_SCENE_COMPUTE_FEATURE_VISUAL_MESH_MSFT = 3,
            XR_SCENE_COMPUTE_FEATURE_COLLIDER_MESH_MSFT = 4,
            XR_SCENE_COMPUTE_FEATURE_SERIALIZE_SCENE_MSFT = 1000098000,
            XR_SCENE_COMPUTE_FEATURE_MARKER_MSFT = 1000147000,
            XR_SCENE_COMPUTE_FEATURE_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }
        public enum XrSceneComputeConsistencyMSFT : uint
        {
            XR_SCENE_COMPUTE_CONSISTENCY_SNAPSHOT_COMPLETE_MSFT = 1,
            XR_SCENE_COMPUTE_CONSISTENCY_SNAPSHOT_INCOMPLETE_FAST_MSFT = 2,
            XR_SCENE_COMPUTE_CONSISTENCY_OCCLUSION_OPTIMIZED_MSFT = 3,
            XR_SCENE_COMPUTE_CONSISTENCY_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }
        public enum XrMeshComputeLodMSFT : uint
        {
            XR_MESH_COMPUTE_LOD_COARSE_MSFT = 1,
            XR_MESH_COMPUTE_LOD_MEDIUM_MSFT = 2,
            XR_MESH_COMPUTE_LOD_FINE_MSFT = 3,
            XR_MESH_COMPUTE_LOD_UNLIMITED_MSFT = 4,
            XR_MESH_COMPUTE_LOD_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }

        public enum XrSceneComponentTypeMSFT
        {
            XR_SCENE_COMPONENT_TYPE_INVALID_MSFT = -1,
            XR_SCENE_COMPONENT_TYPE_OBJECT_MSFT = 1,
            XR_SCENE_COMPONENT_TYPE_PLANE_MSFT = 2,
            XR_SCENE_COMPONENT_TYPE_VISUAL_MESH_MSFT = 3,
            XR_SCENE_COMPONENT_TYPE_COLLIDER_MESH_MSFT = 4,
            XR_SCENE_COMPONENT_TYPE_SERIALIZED_SCENE_FRAGMENT_MSFT = 1000098000,
            XR_SCENE_COMPONENT_TYPE_MARKER_MSFT = 1000147000,
            XR_SCENE_COMPONENT_TYPE_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }

        public enum XrSceneObjectTypeMSFT
        {
            XR_SCENE_OBJECT_TYPE_UNCATEGORIZED_MSFT = -1,
            XR_SCENE_OBJECT_TYPE_BACKGROUND_MSFT = 1,
            XR_SCENE_OBJECT_TYPE_WALL_MSFT = 2,
            XR_SCENE_OBJECT_TYPE_FLOOR_MSFT = 3,
            XR_SCENE_OBJECT_TYPE_CEILING_MSFT = 4,
            XR_SCENE_OBJECT_TYPE_PLATFORM_MSFT = 5,
            XR_SCENE_OBJECT_TYPE_INFERRED_MSFT = 6,
            XR_SCENE_OBJECT_TYPE_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }
        public enum XrScenePlaneAlignmentTypeMSFT : uint
        {
            XR_SCENE_PLANE_ALIGNMENT_TYPE_NON_ORTHOGONAL_MSFT = 0,
            XR_SCENE_PLANE_ALIGNMENT_TYPE_HORIZONTAL_MSFT = 1,
            XR_SCENE_PLANE_ALIGNMENT_TYPE_VERTICAL_MSFT = 2,
            XR_SCENE_PLANE_ALIGNMENT_TYPE_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }
        public enum XrSceneComputeStateMSFT : uint
        {
            XR_SCENE_COMPUTE_STATE_NONE_MSFT = 0,
            XR_SCENE_COMPUTE_STATE_UPDATING_MSFT = 1,
            XR_SCENE_COMPUTE_STATE_COMPLETED_MSFT = 2,
            XR_SCENE_COMPUTE_STATE_COMPLETED_WITH_ERROR_MSFT = 3,
            XR_SCENE_COMPUTE_STATE_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }

        public partial struct XrUuidMSFT
        {
            public _bytes_e__FixedBuffer bytes;

            [InlineArray(16)]
            public partial struct _bytes_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrSceneObserverCreateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSceneCreateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public partial struct XrSceneSphereBoundMSFT
        {
            public XrVector3f center;

            public float radius;
        }

        public partial struct XrSceneOrientedBoxBoundMSFT
        {
            public XrPosef pose;

            public XrVector3f extents;
        }

        public partial struct XrSceneFrustumBoundMSFT
        {
            public XrPosef pose;

            public XrFovf fov;

            public float farDistance;
        }

        public unsafe partial struct XrSceneBoundsMSFT
        {
            public IntPtr space;
            public long time;
            public uint sphereCount;
            public XrSceneSphereBoundMSFT* spheres;
            public uint boxCount;
            public XrSceneOrientedBoxBoundMSFT* boxes;
            public uint frustumCount;
            public XrSceneFrustumBoundMSFT* frustums;
        }

        public unsafe partial struct XrNewSceneComputeInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint requestedFeatureCount;
            public XrSceneComputeFeatureMSFT* requestedFeatures;

            public XrSceneComputeConsistencyMSFT consistency;

            public XrSceneBoundsMSFT bounds;
        }

        public unsafe partial struct XrVisualMeshComputeLodInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrMeshComputeLodMSFT lod;
        }

        public partial struct XrSceneComponentMSFT
        {
            public XrSceneComponentTypeMSFT componentType;

            public XrUuidMSFT id;

            public XrUuidMSFT parentId;
            public long updateTime;
        }

        public unsafe partial struct XrSceneComponentsMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint componentCapacityInput;
            public uint componentCountOutput;

            public XrSceneComponentMSFT* components;
        }

        public unsafe partial struct XrSceneComponentsGetInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSceneComponentTypeMSFT componentType;
        }

        public partial struct XrSceneComponentLocationMSFT
        {
            public ulong flags;

            public XrPosef pose;
        }

        public unsafe partial struct XrSceneComponentLocationsMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint locationCount;

            public XrSceneComponentLocationMSFT* locations;
        }

        public unsafe partial struct XrSceneComponentsLocateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;
            public uint componentIdCount;
            public XrUuidMSFT* componentIds;
        }

        public partial struct XrSceneObjectMSFT
        {
            public XrSceneObjectTypeMSFT objectType;
        }

        public unsafe partial struct XrSceneObjectsMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint sceneObjectCount;

            public XrSceneObjectMSFT* sceneObjects;
        }

        public unsafe partial struct XrSceneComponentParentFilterInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrUuidMSFT parentId;
        }

        public unsafe partial struct XrSceneObjectTypesFilterInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint objectTypeCount;
            public XrSceneObjectTypeMSFT* objectTypes;
        }

        public partial struct XrScenePlaneMSFT
        {
            public XrScenePlaneAlignmentTypeMSFT alignment;

            public XrExtent2Df size;
            public ulong meshBufferId;
            public uint supportsIndicesUint16;
        }

        public unsafe partial struct XrScenePlanesMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint scenePlaneCount;

            public XrScenePlaneMSFT* scenePlanes;
        }

        public unsafe partial struct XrScenePlaneAlignmentFilterInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint alignmentCount;
            public XrScenePlaneAlignmentTypeMSFT* alignments;
        }

        public partial struct XrSceneMeshMSFT
        {
            public ulong meshBufferId;
            public uint supportsIndicesUint16;
        }

        public unsafe partial struct XrSceneMeshesMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint sceneMeshCount;

            public XrSceneMeshMSFT* sceneMeshes;
        }

        public unsafe partial struct XrSceneMeshBuffersGetInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong meshBufferId;
        }

        public unsafe partial struct XrSceneMeshBuffersMSFT
        {
            public Types.XrStructureType type;

            public void* next;
        }

        public unsafe partial struct XrSceneMeshVertexBufferMSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrVector3f* vertices;
        }

        public unsafe partial struct XrSceneMeshIndicesUint32MSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint indexCapacityInput;
            public uint indexCountOutput;
            public uint* indices;
        }

        public unsafe partial struct XrSceneMeshIndicesUint16MSFT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint indexCapacityInput;
            public uint indexCountOutput;
            public ushort* indices;
        }

        public unsafe partial struct XrSerializedSceneFragmentDataGetInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrUuidMSFT sceneFragmentId;
        }

        public unsafe partial struct XrDeserializeSceneFragmentMSFT
        {
            public uint bufferSize;
            public byte* buffer;
        }

        public unsafe partial struct XrSceneDeserializeInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint fragmentCount;
            public XrDeserializeSceneFragmentMSFT* fragments;
        }

        public unsafe partial struct XrEventDataDisplayRefreshRateChangedFB
        {
            public Types.XrStructureType type;
            public void* next;

            public float fromDisplayRefreshRate;

            public float toDisplayRefreshRate;
        }

        public unsafe partial struct XrViveTrackerPathsHTCX
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong persistentPath;
            public ulong rolePath;
        }

        public unsafe partial struct XrEventDataViveTrackerConnectedHTCX
        {
            public Types.XrStructureType type;
            public void* next;

            public XrViveTrackerPathsHTCX* paths;
        }

        public partial struct XrFacialTrackerHTC
        {
        }
        public enum XrEyeExpressionHTC : uint
        {
            XR_EYE_EXPRESSION_LEFT_BLINK_HTC = 0,
            XR_EYE_EXPRESSION_LEFT_WIDE_HTC = 1,
            XR_EYE_EXPRESSION_RIGHT_BLINK_HTC = 2,
            XR_EYE_EXPRESSION_RIGHT_WIDE_HTC = 3,
            XR_EYE_EXPRESSION_LEFT_SQUEEZE_HTC = 4,
            XR_EYE_EXPRESSION_RIGHT_SQUEEZE_HTC = 5,
            XR_EYE_EXPRESSION_LEFT_DOWN_HTC = 6,
            XR_EYE_EXPRESSION_RIGHT_DOWN_HTC = 7,
            XR_EYE_EXPRESSION_LEFT_OUT_HTC = 8,
            XR_EYE_EXPRESSION_RIGHT_IN_HTC = 9,
            XR_EYE_EXPRESSION_LEFT_IN_HTC = 10,
            XR_EYE_EXPRESSION_RIGHT_OUT_HTC = 11,
            XR_EYE_EXPRESSION_LEFT_UP_HTC = 12,
            XR_EYE_EXPRESSION_RIGHT_UP_HTC = 13,
            XR_EYE_EXPRESSION_MAX_ENUM_HTC = 0x7FFFFFFF,
        }
        public enum XrLipExpressionHTC : uint
        {
            XR_LIP_EXPRESSION_JAW_RIGHT_HTC = 0,
            XR_LIP_EXPRESSION_JAW_LEFT_HTC = 1,
            XR_LIP_EXPRESSION_JAW_FORWARD_HTC = 2,
            XR_LIP_EXPRESSION_JAW_OPEN_HTC = 3,
            XR_LIP_EXPRESSION_MOUTH_APE_SHAPE_HTC = 4,
            XR_LIP_EXPRESSION_MOUTH_UPPER_RIGHT_HTC = 5,
            XR_LIP_EXPRESSION_MOUTH_UPPER_LEFT_HTC = 6,
            XR_LIP_EXPRESSION_MOUTH_LOWER_RIGHT_HTC = 7,
            XR_LIP_EXPRESSION_MOUTH_LOWER_LEFT_HTC = 8,
            XR_LIP_EXPRESSION_MOUTH_UPPER_OVERTURN_HTC = 9,
            XR_LIP_EXPRESSION_MOUTH_LOWER_OVERTURN_HTC = 10,
            XR_LIP_EXPRESSION_MOUTH_POUT_HTC = 11,
            XR_LIP_EXPRESSION_MOUTH_RAISER_RIGHT_HTC = 12,
            XR_LIP_EXPRESSION_MOUTH_RAISER_LEFT_HTC = 13,
            XR_LIP_EXPRESSION_MOUTH_STRETCHER_RIGHT_HTC = 14,
            XR_LIP_EXPRESSION_MOUTH_STRETCHER_LEFT_HTC = 15,
            XR_LIP_EXPRESSION_CHEEK_PUFF_RIGHT_HTC = 16,
            XR_LIP_EXPRESSION_CHEEK_PUFF_LEFT_HTC = 17,
            XR_LIP_EXPRESSION_CHEEK_SUCK_HTC = 18,
            XR_LIP_EXPRESSION_MOUTH_UPPER_UPRIGHT_HTC = 19,
            XR_LIP_EXPRESSION_MOUTH_UPPER_UPLEFT_HTC = 20,
            XR_LIP_EXPRESSION_MOUTH_LOWER_DOWNRIGHT_HTC = 21,
            XR_LIP_EXPRESSION_MOUTH_LOWER_DOWNLEFT_HTC = 22,
            XR_LIP_EXPRESSION_MOUTH_UPPER_INSIDE_HTC = 23,
            XR_LIP_EXPRESSION_MOUTH_LOWER_INSIDE_HTC = 24,
            XR_LIP_EXPRESSION_MOUTH_LOWER_OVERLAY_HTC = 25,
            XR_LIP_EXPRESSION_TONGUE_LONGSTEP1_HTC = 26,
            XR_LIP_EXPRESSION_TONGUE_LEFT_HTC = 27,
            XR_LIP_EXPRESSION_TONGUE_RIGHT_HTC = 28,
            XR_LIP_EXPRESSION_TONGUE_UP_HTC = 29,
            XR_LIP_EXPRESSION_TONGUE_DOWN_HTC = 30,
            XR_LIP_EXPRESSION_TONGUE_ROLL_HTC = 31,
            XR_LIP_EXPRESSION_TONGUE_LONGSTEP2_HTC = 32,
            XR_LIP_EXPRESSION_TONGUE_UPRIGHT_MORPH_HTC = 33,
            XR_LIP_EXPRESSION_TONGUE_UPLEFT_MORPH_HTC = 34,
            XR_LIP_EXPRESSION_TONGUE_DOWNRIGHT_MORPH_HTC = 35,
            XR_LIP_EXPRESSION_TONGUE_DOWNLEFT_MORPH_HTC = 36,
            XR_LIP_EXPRESSION_MOUTH_SMILE_RIGHT_HTC = XR_LIP_EXPRESSION_MOUTH_RAISER_RIGHT_HTC,
            XR_LIP_EXPRESSION_MOUTH_SMILE_LEFT_HTC = XR_LIP_EXPRESSION_MOUTH_RAISER_LEFT_HTC,
            XR_LIP_EXPRESSION_MOUTH_SAD_RIGHT_HTC = XR_LIP_EXPRESSION_MOUTH_STRETCHER_RIGHT_HTC,
            XR_LIP_EXPRESSION_MOUTH_SAD_LEFT_HTC = XR_LIP_EXPRESSION_MOUTH_STRETCHER_LEFT_HTC,
            XR_LIP_EXPRESSION_MAX_ENUM_HTC = 0x7FFFFFFF,
        }
        public enum XrFacialTrackingTypeHTC : uint
        {
            XR_FACIAL_TRACKING_TYPE_EYE_DEFAULT_HTC = 1,
            XR_FACIAL_TRACKING_TYPE_LIP_DEFAULT_HTC = 2,
            XR_FACIAL_TRACKING_TYPE_MAX_ENUM_HTC = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemFacialTrackingPropertiesHTC
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportEyeFacialTracking;
            public uint supportLipFacialTracking;
        }

        public unsafe partial struct XrFacialExpressionsHTC
        {
            public Types.XrStructureType type;
            public void* next;
            public uint isActive;
            public long sampleTime;
            public uint expressionCount;

            public float* expressionWeightings;
        }

        public unsafe partial struct XrFacialTrackerCreateInfoHTC
        {
            public Types.XrStructureType type;
            public void* next;

            public XrFacialTrackingTypeHTC facialTrackingType;
        }
        public enum XrColorSpaceFB : uint
        {
            XR_COLOR_SPACE_UNMANAGED_FB = 0,
            XR_COLOR_SPACE_REC2020_FB = 1,
            XR_COLOR_SPACE_REC709_FB = 2,
            XR_COLOR_SPACE_RIFT_CV1_FB = 3,
            XR_COLOR_SPACE_RIFT_S_FB = 4,
            XR_COLOR_SPACE_QUEST_FB = 5,
            XR_COLOR_SPACE_P3_FB = 6,
            XR_COLOR_SPACE_ADOBE_RGB_FB = 7,
            XR_COLOR_SPACE_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemColorSpacePropertiesFB
        {
            public Types.XrStructureType type;

            public void* next;

            public XrColorSpaceFB colorSpace;
        }

        public partial struct XrVector4sFB
        {
            public short x;
            public short y;
            public short z;
            public short w;
        }

        public unsafe partial struct XrHandTrackingMeshFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint jointCapacityInput;
            public uint jointCountOutput;

            public XrPosef* jointBindPoses;

            public float* jointRadii;

            public XrHandJointEXT* jointParents;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrVector3f* vertexPositions;

            public XrVector3f* vertexNormals;

            public XrVector2f* vertexUVs;

            public XrVector4sFB* vertexBlendIndices;

            public XrVector4f* vertexBlendWeights;
            public uint indexCapacityInput;
            public uint indexCountOutput;
            public short* indices;
        }

        public unsafe partial struct XrHandTrackingScaleFB
        {
            public Types.XrStructureType type;

            public void* next;

            public float sensorOutput;

            public float currentOutput;
            public uint overrideHandScale;

            public float overrideValueInput;
        }

        public unsafe partial struct XrHandTrackingAimStateFB
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong status;

            public XrPosef aimPose;

            public float pinchStrengthIndex;

            public float pinchStrengthMiddle;

            public float pinchStrengthRing;

            public float pinchStrengthLittle;
        }

        public partial struct XrHandCapsuleFB
        {
            public _points_e__FixedBuffer points;

            public float radius;

            public XrHandJointEXT joint;

            [InlineArray(2)]
            public partial struct _points_e__FixedBuffer
            {
                public XrVector3f e0;
            }
        }

        public unsafe partial struct XrHandTrackingCapsulesStateFB
        {
            public Types.XrStructureType type;

            public void* next;
            public _capsules_e__FixedBuffer capsules;

            [InlineArray(19)]
            public partial struct _capsules_e__FixedBuffer
            {
                public XrHandCapsuleFB e0;
            }
        }
        public enum XrSpaceComponentTypeFB : uint
        {
            XR_SPACE_COMPONENT_TYPE_LOCATABLE_FB = 0,
            XR_SPACE_COMPONENT_TYPE_STORABLE_FB = 1,
            XR_SPACE_COMPONENT_TYPE_SHARABLE_FB = 2,
            XR_SPACE_COMPONENT_TYPE_BOUNDED_2D_FB = 3,
            XR_SPACE_COMPONENT_TYPE_BOUNDED_3D_FB = 4,
            XR_SPACE_COMPONENT_TYPE_SEMANTIC_LABELS_FB = 5,
            XR_SPACE_COMPONENT_TYPE_ROOM_LAYOUT_FB = 6,
            XR_SPACE_COMPONENT_TYPE_SPACE_CONTAINER_FB = 7,
            XR_SPACE_COMPONENT_TYPE_TRIANGLE_MESH_META = 1000269000,
            XR_SPACE_COMPONENT_TYPE_ROOM_MESH_META = 1000553000,
            XR_SPACE_COMPONENT_TYPE_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemSpatialEntityPropertiesFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint supportsSpatialEntity;
        }

        public unsafe partial struct XrSpatialAnchorCreateInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;

            public XrPosef poseInSpace;
            public long time;
        }

        public unsafe partial struct XrSpaceComponentStatusSetInfoFB
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpaceComponentTypeFB componentType;
            public uint enabled;
            public long timeout;
        }

        public unsafe partial struct XrSpaceComponentStatusFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint enabled;
            public uint changePending;
        }

        public unsafe partial struct XrEventDataSpatialAnchorCreateCompleteFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
            public IntPtr space;
            public XrUuid uuid;
        }

        public unsafe partial struct XrEventDataSpaceSetStatusCompleteFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
            public IntPtr space;
            public XrUuid uuid;

            public XrSpaceComponentTypeFB componentType;
            public uint enabled;
        }

        public partial struct XrFoveationProfileFB
        {
        }

        public unsafe partial struct XrFoveationProfileCreateInfoFB
        {
            public Types.XrStructureType type;

            public void* next;
        }

        public unsafe partial struct XrSwapchainCreateInfoFoveationFB
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong flags;
        }

        public unsafe partial struct XrSwapchainStateFoveationFB
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong flags;
            public XrFoveationProfileFB* profile;
        }
        public enum XrFoveationLevelFB : uint
        {
            XR_FOVEATION_LEVEL_NONE_FB = 0,
            XR_FOVEATION_LEVEL_LOW_FB = 1,
            XR_FOVEATION_LEVEL_MEDIUM_FB = 2,
            XR_FOVEATION_LEVEL_HIGH_FB = 3,
            XR_FOVEATION_LEVEL_MAX_ENUM_FB = 0x7FFFFFFF,
        }
        public enum XrFoveationDynamicFB : uint
        {
            XR_FOVEATION_DYNAMIC_DISABLED_FB = 0,
            XR_FOVEATION_DYNAMIC_LEVEL_ENABLED_FB = 1,
            XR_FOVEATION_DYNAMIC_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrFoveationLevelProfileCreateInfoFB
        {
            public Types.XrStructureType type;

            public void* next;

            public XrFoveationLevelFB level;

            public float verticalOffset;

            public XrFoveationDynamicFB dynamic;
        }

        public unsafe partial struct XrSystemKeyboardTrackingPropertiesFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsKeyboardTracking;
        }

        public partial struct XrKeyboardTrackingDescriptionFB
        {
            public ulong trackedKeyboardId;

            public XrVector3f size;
            public ulong flags;
            public _name_e__FixedBuffer name;

            [InlineArray(128)]
            public partial struct _name_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrKeyboardSpaceCreateInfoFB
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong trackedKeyboardId;
        }

        public unsafe partial struct XrKeyboardTrackingQueryFB
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong flags;
        }

        public partial struct XrTriangleMeshFB
        {
        }
        public enum XrWindingOrderFB : uint
        {
            XR_WINDING_ORDER_UNKNOWN_FB = 0,
            XR_WINDING_ORDER_CW_FB = 1,
            XR_WINDING_ORDER_CCW_FB = 2,
            XR_WINDING_ORDER_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrTriangleMeshCreateInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;

            public XrWindingOrderFB windingOrder;
            public uint vertexCount;
            public XrVector3f* vertexBuffer;
            public uint triangleCount;
            public uint* indexBuffer;
        }

        public partial struct XrPassthroughFB
        {
        }

        public partial struct XrPassthroughLayerFB
        {
        }

        public partial struct XrGeometryInstanceFB
        {
        }
        public enum XrPassthroughLayerPurposeFB : uint
        {
            XR_PASSTHROUGH_LAYER_PURPOSE_RECONSTRUCTION_FB = 0,
            XR_PASSTHROUGH_LAYER_PURPOSE_PROJECTED_FB = 1,
            XR_PASSTHROUGH_LAYER_PURPOSE_TRACKED_KEYBOARD_HANDS_FB = 1000203001,
            XR_PASSTHROUGH_LAYER_PURPOSE_TRACKED_KEYBOARD_MASKED_HANDS_FB = 1000203002,
            XR_PASSTHROUGH_LAYER_PURPOSE_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemPassthroughPropertiesFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint supportsPassthrough;
        }

        public unsafe partial struct XrSystemPassthroughProperties2FB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong capabilities;
        }

        public unsafe partial struct XrPassthroughCreateInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;
        }

        public unsafe partial struct XrPassthroughLayerCreateInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public XrPassthroughFB* passthrough;
            public ulong flags;

            public XrPassthroughLayerPurposeFB purpose;
        }

        public unsafe partial struct XrCompositionLayerPassthroughFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;
            public IntPtr space;
            public XrPassthroughLayerFB* layerHandle;
        }

        public unsafe partial struct XrGeometryInstanceCreateInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public XrPassthroughLayerFB* layer;
            public XrTriangleMeshFB* mesh;
            public IntPtr baseSpace;

            public XrPosef pose;

            public XrVector3f scale;
        }

        public unsafe partial struct XrGeometryInstanceTransformFB
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;

            public XrPosef pose;

            public XrVector3f scale;
        }

        public unsafe partial struct XrPassthroughStyleFB
        {
            public Types.XrStructureType type;
            public void* next;

            public float textureOpacityFactor;

            public XrColor4f edgeColor;
        }

        public unsafe partial struct XrPassthroughColorMapMonoToRgbaFB
        {
            public Types.XrStructureType type;
            public void* next;
            public _textureColorMap_e__FixedBuffer textureColorMap;

            [InlineArray(256)]
            public partial struct _textureColorMap_e__FixedBuffer
            {
                public XrColor4f e0;
            }
        }

        public unsafe partial struct XrPassthroughColorMapMonoToMonoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public _textureColorMap_e__FixedBuffer textureColorMap;

            [InlineArray(256)]
            public partial struct _textureColorMap_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrPassthroughBrightnessContrastSaturationFB
        {
            public Types.XrStructureType type;
            public void* next;

            public float brightness;

            public float contrast;

            public float saturation;
        }

        public unsafe partial struct XrEventDataPassthroughStateChangedFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;
        }

        public unsafe partial struct XrRenderModelPathInfoFB
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong path;
        }

        public unsafe partial struct XrRenderModelPropertiesFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint vendorId;
            public _modelName_e__FixedBuffer modelName;
            public ulong modelKey;
            public uint modelVersion;
            public ulong flags;

            [InlineArray(64)]
            public partial struct _modelName_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrRenderModelBufferFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint bufferCapacityInput;
            public uint bufferCountOutput;
            public byte* buffer;
        }

        public unsafe partial struct XrRenderModelLoadInfoFB
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong modelKey;
        }

        public unsafe partial struct XrSystemRenderModelPropertiesFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsRenderModelLoading;
        }

        public unsafe partial struct XrRenderModelCapabilitiesRequestFB
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong flags;
        }

        public unsafe partial struct XrViewLocateFoveatedRenderingVARJO
        {
            public Types.XrStructureType type;
            public void* next;
            public uint foveatedRenderingActive;
        }

        public unsafe partial struct XrFoveatedViewConfigurationViewVARJO
        {
            public Types.XrStructureType type;

            public void* next;
            public uint foveatedRenderingActive;
        }

        public unsafe partial struct XrSystemFoveatedRenderingPropertiesVARJO
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsFoveatedRendering;
        }

        public unsafe partial struct XrCompositionLayerDepthTestVARJO
        {
            public Types.XrStructureType type;
            public void* next;

            public float depthTestRangeNearZ;

            public float depthTestRangeFarZ;
        }

        public unsafe partial struct XrSystemMarkerTrackingPropertiesVARJO
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsMarkerTracking;
        }

        public unsafe partial struct XrEventDataMarkerTrackingUpdateVARJO
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong markerId;
            public uint isActive;
            public uint isPredicted;
            public long time;
        }

        public unsafe partial struct XrMarkerSpaceCreateInfoVARJO
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong markerId;

            public XrPosef poseInMarkerSpace;
        }

        public unsafe partial struct XrFrameEndInfoML
        {
            public Types.XrStructureType type;
            public void* next;

            public float focusDistance;
            public ulong flags;
        }

        public unsafe partial struct XrGlobalDimmerFrameEndInfoML
        {
            public Types.XrStructureType type;
            public void* next;

            public float dimmerValue;
            public ulong flags;
        }

        public partial struct XrMarkerDetectorML
        {
        }
        public enum XrMarkerDetectorProfileML : uint
        {
            XR_MARKER_DETECTOR_PROFILE_DEFAULT_ML = 0,
            XR_MARKER_DETECTOR_PROFILE_SPEED_ML = 1,
            XR_MARKER_DETECTOR_PROFILE_ACCURACY_ML = 2,
            XR_MARKER_DETECTOR_PROFILE_SMALL_TARGETS_ML = 3,
            XR_MARKER_DETECTOR_PROFILE_LARGE_FOV_ML = 4,
            XR_MARKER_DETECTOR_PROFILE_CUSTOM_ML = 5,
            XR_MARKER_DETECTOR_PROFILE_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrMarkerTypeML : uint
        {
            XR_MARKER_TYPE_ARUCO_ML = 0,
            XR_MARKER_TYPE_APRIL_TAG_ML = 1,
            XR_MARKER_TYPE_QR_ML = 2,
            XR_MARKER_TYPE_EAN_13_ML = 3,
            XR_MARKER_TYPE_UPC_A_ML = 4,
            XR_MARKER_TYPE_CODE_128_ML = 5,
            XR_MARKER_TYPE_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrMarkerArucoDictML : uint
        {
            XR_MARKER_ARUCO_DICT_4X4_50_ML = 0,
            XR_MARKER_ARUCO_DICT_4X4_100_ML = 1,
            XR_MARKER_ARUCO_DICT_4X4_250_ML = 2,
            XR_MARKER_ARUCO_DICT_4X4_1000_ML = 3,
            XR_MARKER_ARUCO_DICT_5X5_50_ML = 4,
            XR_MARKER_ARUCO_DICT_5X5_100_ML = 5,
            XR_MARKER_ARUCO_DICT_5X5_250_ML = 6,
            XR_MARKER_ARUCO_DICT_5X5_1000_ML = 7,
            XR_MARKER_ARUCO_DICT_6X6_50_ML = 8,
            XR_MARKER_ARUCO_DICT_6X6_100_ML = 9,
            XR_MARKER_ARUCO_DICT_6X6_250_ML = 10,
            XR_MARKER_ARUCO_DICT_6X6_1000_ML = 11,
            XR_MARKER_ARUCO_DICT_7X7_50_ML = 12,
            XR_MARKER_ARUCO_DICT_7X7_100_ML = 13,
            XR_MARKER_ARUCO_DICT_7X7_250_ML = 14,
            XR_MARKER_ARUCO_DICT_7X7_1000_ML = 15,
            XR_MARKER_ARUCO_DICT_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrMarkerAprilTagDictML : uint
        {
            XR_MARKER_APRIL_TAG_DICT_16H5_ML = 0,
            XR_MARKER_APRIL_TAG_DICT_25H9_ML = 1,
            XR_MARKER_APRIL_TAG_DICT_36H10_ML = 2,
            XR_MARKER_APRIL_TAG_DICT_36H11_ML = 3,
            XR_MARKER_APRIL_TAG_DICT_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrMarkerDetectorFpsML : uint
        {
            XR_MARKER_DETECTOR_FPS_LOW_ML = 0,
            XR_MARKER_DETECTOR_FPS_MEDIUM_ML = 1,
            XR_MARKER_DETECTOR_FPS_HIGH_ML = 2,
            XR_MARKER_DETECTOR_FPS_MAX_ML = 3,
            XR_MARKER_DETECTOR_FPS_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrMarkerDetectorResolutionML : uint
        {
            XR_MARKER_DETECTOR_RESOLUTION_LOW_ML = 0,
            XR_MARKER_DETECTOR_RESOLUTION_MEDIUM_ML = 1,
            XR_MARKER_DETECTOR_RESOLUTION_HIGH_ML = 2,
            XR_MARKER_DETECTOR_RESOLUTION_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrMarkerDetectorCameraML : uint
        {
            XR_MARKER_DETECTOR_CAMERA_RGB_CAMERA_ML = 0,
            XR_MARKER_DETECTOR_CAMERA_WORLD_CAMERAS_ML = 1,
            XR_MARKER_DETECTOR_CAMERA_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrMarkerDetectorCornerRefineMethodML : uint
        {
            XR_MARKER_DETECTOR_CORNER_REFINE_METHOD_NONE_ML = 0,
            XR_MARKER_DETECTOR_CORNER_REFINE_METHOD_SUBPIX_ML = 1,
            XR_MARKER_DETECTOR_CORNER_REFINE_METHOD_CONTOUR_ML = 2,
            XR_MARKER_DETECTOR_CORNER_REFINE_METHOD_APRIL_TAG_ML = 3,
            XR_MARKER_DETECTOR_CORNER_REFINE_METHOD_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrMarkerDetectorFullAnalysisIntervalML : uint
        {
            XR_MARKER_DETECTOR_FULL_ANALYSIS_INTERVAL_MAX_ML = 0,
            XR_MARKER_DETECTOR_FULL_ANALYSIS_INTERVAL_FAST_ML = 1,
            XR_MARKER_DETECTOR_FULL_ANALYSIS_INTERVAL_MEDIUM_ML = 2,
            XR_MARKER_DETECTOR_FULL_ANALYSIS_INTERVAL_SLOW_ML = 3,
            XR_MARKER_DETECTOR_FULL_ANALYSIS_INTERVAL_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrMarkerDetectorStatusML : uint
        {
            XR_MARKER_DETECTOR_STATUS_PENDING_ML = 0,
            XR_MARKER_DETECTOR_STATUS_READY_ML = 1,
            XR_MARKER_DETECTOR_STATUS_ERROR_ML = 2,
            XR_MARKER_DETECTOR_STATUS_MAX_ENUM_ML = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemMarkerUnderstandingPropertiesML
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsMarkerUnderstanding;
        }

        public unsafe partial struct XrMarkerDetectorCreateInfoML
        {
            public Types.XrStructureType type;
            public void* next;

            public XrMarkerDetectorProfileML profile;

            public XrMarkerTypeML markerType;
        }

        public unsafe partial struct XrMarkerDetectorArucoInfoML
        {
            public Types.XrStructureType type;
            public void* next;

            public XrMarkerArucoDictML arucoDict;
        }

        public unsafe partial struct XrMarkerDetectorSizeInfoML
        {
            public Types.XrStructureType type;
            public void* next;

            public float markerLength;
        }

        public unsafe partial struct XrMarkerDetectorAprilTagInfoML
        {
            public Types.XrStructureType type;
            public void* next;

            public XrMarkerAprilTagDictML aprilTagDict;
        }

        public unsafe partial struct XrMarkerDetectorCustomProfileInfoML
        {
            public Types.XrStructureType type;
            public void* next;

            public XrMarkerDetectorFpsML fpsHint;

            public XrMarkerDetectorResolutionML resolutionHint;

            public XrMarkerDetectorCameraML cameraHint;

            public XrMarkerDetectorCornerRefineMethodML cornerRefineMethod;
            public uint useEdgeRefinement;

            public XrMarkerDetectorFullAnalysisIntervalML fullAnalysisIntervalHint;
        }

        public unsafe partial struct XrMarkerDetectorSnapshotInfoML
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrMarkerDetectorStateML
        {
            public Types.XrStructureType type;

            public void* next;

            public XrMarkerDetectorStatusML state;
        }

        public unsafe partial struct XrMarkerSpaceCreateInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public XrMarkerDetectorML* markerDetector;
            public ulong marker;

            public XrPosef poseInMarkerSpace;
        }

        public partial struct XrExportedLocalizationMapML
        {
        }
        public enum XrLocalizationMapStateML : uint
        {
            XR_LOCALIZATION_MAP_STATE_NOT_LOCALIZED_ML = 0,
            XR_LOCALIZATION_MAP_STATE_LOCALIZED_ML = 1,
            XR_LOCALIZATION_MAP_STATE_LOCALIZATION_PENDING_ML = 2,
            XR_LOCALIZATION_MAP_STATE_LOCALIZATION_SLEEPING_BEFORE_RETRY_ML = 3,
            XR_LOCALIZATION_MAP_STATE_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrLocalizationMapTypeML : uint
        {
            XR_LOCALIZATION_MAP_TYPE_ON_DEVICE_ML = 0,
            XR_LOCALIZATION_MAP_TYPE_CLOUD_ML = 1,
            XR_LOCALIZATION_MAP_TYPE_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrLocalizationMapConfidenceML : uint
        {
            XR_LOCALIZATION_MAP_CONFIDENCE_POOR_ML = 0,
            XR_LOCALIZATION_MAP_CONFIDENCE_FAIR_ML = 1,
            XR_LOCALIZATION_MAP_CONFIDENCE_GOOD_ML = 2,
            XR_LOCALIZATION_MAP_CONFIDENCE_EXCELLENT_ML = 3,
            XR_LOCALIZATION_MAP_CONFIDENCE_MAX_ENUM_ML = 0x7FFFFFFF,
        }

        public unsafe partial struct XrLocalizationMapML
        {
            public Types.XrStructureType type;

            public void* next;
            public _name_e__FixedBuffer name;
            public XrUuid mapUuid;

            public XrLocalizationMapTypeML mapType;

            [InlineArray(64)]
            public partial struct _name_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrEventDataLocalizationChangedML
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr session;

            public XrLocalizationMapStateML state;

            public XrLocalizationMapML map;

            public XrLocalizationMapConfidenceML confidence;
            public ulong errorFlags;
        }

        public unsafe partial struct XrLocalizationMapQueryInfoBaseHeaderML
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrMapLocalizationRequestInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public XrUuid mapUuid;
        }

        public unsafe partial struct XrLocalizationMapImportInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public uint size;
            public byte* data;
        }

        public unsafe partial struct XrLocalizationEnableEventsInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public uint enabled;
        }

        public partial struct XrFutureEXT
        {
        }
        public enum XrSpatialAnchorConfidenceML : uint
        {
            XR_SPATIAL_ANCHOR_CONFIDENCE_LOW_ML = 0,
            XR_SPATIAL_ANCHOR_CONFIDENCE_MEDIUM_ML = 1,
            XR_SPATIAL_ANCHOR_CONFIDENCE_HIGH_ML = 2,
            XR_SPATIAL_ANCHOR_CONFIDENCE_MAX_ENUM_ML = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpatialAnchorsCreateInfoBaseHeaderML
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpatialAnchorsCreateInfoFromPoseML
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;

            public XrPosef poseInBaseSpace;
            public long time;
        }

        public unsafe partial struct XrCreateSpatialAnchorsCompletionML
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public uint spaceCount;
            public IntPtr* spaces;
        }

        public unsafe partial struct XrSpatialAnchorStateML
        {
            public Types.XrStructureType type;

            public void* next;

            public XrSpatialAnchorConfidenceML confidence;
        }

        public partial struct XrSpatialAnchorsStorageML
        {
        }

        public unsafe partial struct XrSpatialAnchorsCreateStorageInfoML
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpatialAnchorsQueryInfoBaseHeaderML
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpatialAnchorsQueryInfoRadiusML
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;

            public XrVector3f center;
            public long time;

            public float radius;
        }

        public unsafe partial struct XrSpatialAnchorsQueryCompletionML
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public uint uuidCapacityInput;
            public uint uuidCountOutput;
            public XrUuid* uuids;
        }

        public unsafe partial struct XrSpatialAnchorsCreateInfoFromUuidsML
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialAnchorsStorageML* storage;
            public uint uuidCount;
            public XrUuid* uuids;
        }

        public unsafe partial struct XrSpatialAnchorsPublishInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public uint anchorCount;
            public IntPtr* anchors;
            public ulong expiration;
        }

        public unsafe partial struct XrSpatialAnchorsPublishCompletionML
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public uint uuidCount;
            public XrUuid* uuids;
        }

        public unsafe partial struct XrSpatialAnchorsDeleteInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public uint uuidCount;
            public XrUuid* uuids;
        }

        public unsafe partial struct XrSpatialAnchorsDeleteCompletionML
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
        }

        public unsafe partial struct XrSpatialAnchorsUpdateExpirationInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public uint uuidCount;
            public XrUuid* uuids;
            public ulong expiration;
        }

        public unsafe partial struct XrSpatialAnchorsUpdateExpirationCompletionML
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
        }

        public partial struct XrSpatialAnchorCompletionResultML
        {
            public XrUuid uuid;

            public Types.XrResult result;
        }

        public unsafe partial struct XrSpatialAnchorsPublishCompletionDetailsML
        {
            public Types.XrStructureType type;

            public void* next;
            public uint resultCount;

            public XrSpatialAnchorCompletionResultML* results;
        }

        public unsafe partial struct XrSpatialAnchorsDeleteCompletionDetailsML
        {
            public Types.XrStructureType type;

            public void* next;
            public uint resultCount;

            public XrSpatialAnchorCompletionResultML* results;
        }

        public unsafe partial struct XrSpatialAnchorsUpdateExpirationCompletionDetailsML
        {
            public Types.XrStructureType type;

            public void* next;
            public uint resultCount;

            public XrSpatialAnchorCompletionResultML* results;
        }

        public partial struct XrSpatialAnchorStoreConnectionMSFT
        {
        }

        public partial struct XrSpatialAnchorPersistenceNameMSFT
        {
            public _name_e__FixedBuffer name;

            [InlineArray(256)]
            public partial struct _name_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrSpatialAnchorPersistenceInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialAnchorPersistenceNameMSFT spatialAnchorPersistenceName;
            public XrSpatialAnchorMSFT* spatialAnchor;
        }

        public unsafe partial struct XrSpatialAnchorFromPersistedAnchorCreateInfoMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialAnchorStoreConnectionMSFT* spatialAnchorStore;

            public XrSpatialAnchorPersistenceNameMSFT spatialAnchorPersistenceName;
        }
        public enum XrSceneMarkerTypeMSFT : uint
        {
            XR_SCENE_MARKER_TYPE_QR_CODE_MSFT = 1,
            XR_SCENE_MARKER_TYPE_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }
        public enum XrSceneMarkerQRCodeSymbolTypeMSFT : uint
        {
            XR_SCENE_MARKER_QR_CODE_SYMBOL_TYPE_QR_CODE_MSFT = 1,
            XR_SCENE_MARKER_QR_CODE_SYMBOL_TYPE_MICRO_QR_CODE_MSFT = 2,
            XR_SCENE_MARKER_QRCODE_SYMBOL_TYPE_MAX_ENUM_MSFT = 0x7FFFFFFF,
        }

        public partial struct XrSceneMarkerMSFT
        {
            public XrSceneMarkerTypeMSFT markerType;
            public long lastSeenTime;

            public XrOffset2Df center;

            public XrExtent2Df size;
        }

        public unsafe partial struct XrSceneMarkersMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint sceneMarkerCapacityInput;

            public XrSceneMarkerMSFT* sceneMarkers;
        }

        public unsafe partial struct XrSceneMarkerTypeFilterMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint markerTypeCount;

            public XrSceneMarkerTypeMSFT* markerTypes;
        }

        public partial struct XrSceneMarkerQRCodeMSFT
        {
            public XrSceneMarkerQRCodeSymbolTypeMSFT symbolType;
            public byte version;
        }

        public unsafe partial struct XrSceneMarkerQRCodesMSFT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint qrCodeCapacityInput;

            public XrSceneMarkerQRCodeMSFT* qrCodes;
        }
        public enum XrHandForearmJointULTRALEAP : uint
        {
            XR_HAND_FOREARM_JOINT_PALM_ULTRALEAP = 0,
            XR_HAND_FOREARM_JOINT_WRIST_ULTRALEAP = 1,
            XR_HAND_FOREARM_JOINT_THUMB_METACARPAL_ULTRALEAP = 2,
            XR_HAND_FOREARM_JOINT_THUMB_PROXIMAL_ULTRALEAP = 3,
            XR_HAND_FOREARM_JOINT_THUMB_DISTAL_ULTRALEAP = 4,
            XR_HAND_FOREARM_JOINT_THUMB_TIP_ULTRALEAP = 5,
            XR_HAND_FOREARM_JOINT_INDEX_METACARPAL_ULTRALEAP = 6,
            XR_HAND_FOREARM_JOINT_INDEX_PROXIMAL_ULTRALEAP = 7,
            XR_HAND_FOREARM_JOINT_INDEX_INTERMEDIATE_ULTRALEAP = 8,
            XR_HAND_FOREARM_JOINT_INDEX_DISTAL_ULTRALEAP = 9,
            XR_HAND_FOREARM_JOINT_INDEX_TIP_ULTRALEAP = 10,
            XR_HAND_FOREARM_JOINT_MIDDLE_METACARPAL_ULTRALEAP = 11,
            XR_HAND_FOREARM_JOINT_MIDDLE_PROXIMAL_ULTRALEAP = 12,
            XR_HAND_FOREARM_JOINT_MIDDLE_INTERMEDIATE_ULTRALEAP = 13,
            XR_HAND_FOREARM_JOINT_MIDDLE_DISTAL_ULTRALEAP = 14,
            XR_HAND_FOREARM_JOINT_MIDDLE_TIP_ULTRALEAP = 15,
            XR_HAND_FOREARM_JOINT_RING_METACARPAL_ULTRALEAP = 16,
            XR_HAND_FOREARM_JOINT_RING_PROXIMAL_ULTRALEAP = 17,
            XR_HAND_FOREARM_JOINT_RING_INTERMEDIATE_ULTRALEAP = 18,
            XR_HAND_FOREARM_JOINT_RING_DISTAL_ULTRALEAP = 19,
            XR_HAND_FOREARM_JOINT_RING_TIP_ULTRALEAP = 20,
            XR_HAND_FOREARM_JOINT_LITTLE_METACARPAL_ULTRALEAP = 21,
            XR_HAND_FOREARM_JOINT_LITTLE_PROXIMAL_ULTRALEAP = 22,
            XR_HAND_FOREARM_JOINT_LITTLE_INTERMEDIATE_ULTRALEAP = 23,
            XR_HAND_FOREARM_JOINT_LITTLE_DISTAL_ULTRALEAP = 24,
            XR_HAND_FOREARM_JOINT_LITTLE_TIP_ULTRALEAP = 25,
            XR_HAND_FOREARM_JOINT_ELBOW_ULTRALEAP = 26,
            XR_HAND_FOREARM_JOINT_MAX_ENUM_ULTRALEAP = 0x7FFFFFFF,
        }
        public enum XrSpaceQueryActionFB : uint
        {
            XR_SPACE_QUERY_ACTION_LOAD_FB = 0,
            XR_SPACE_QUERY_ACTION_MAX_ENUM_FB = 0x7FFFFFFF,
        }
        public enum XrSpaceStorageLocationFB : uint
        {
            XR_SPACE_STORAGE_LOCATION_INVALID_FB = 0,
            XR_SPACE_STORAGE_LOCATION_LOCAL_FB = 1,
            XR_SPACE_STORAGE_LOCATION_CLOUD_FB = 2,
            XR_SPACE_STORAGE_LOCATION_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpaceQueryInfoBaseHeaderFB
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpaceFilterInfoBaseHeaderFB
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpaceQueryInfoFB
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpaceQueryActionFB queryAction;
            public uint maxResultCount;
            public long timeout;
            public XrSpaceFilterInfoBaseHeaderFB* filter;
            public XrSpaceFilterInfoBaseHeaderFB* excludeFilter;
        }

        public unsafe partial struct XrSpaceStorageLocationFilterInfoFB
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpaceStorageLocationFB location;
        }

        public unsafe partial struct XrSpaceUuidFilterInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint uuidCount;
            public XrUuid* uuids;
        }

        public unsafe partial struct XrSpaceComponentFilterInfoFB
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpaceComponentTypeFB componentType;
        }

        public unsafe partial struct XrSpaceQueryResultFB
        {
            public IntPtr space;
            public XrUuid uuid;
        }

        public unsafe partial struct XrSpaceQueryResultsFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint resultCapacityInput;
            public uint resultCountOutput;

            public XrSpaceQueryResultFB* results;
        }

        public unsafe partial struct XrEventDataSpaceQueryResultsAvailableFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;
        }

        public unsafe partial struct XrEventDataSpaceQueryCompleteFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
        }
        public enum XrSpacePersistenceModeFB : uint
        {
            XR_SPACE_PERSISTENCE_MODE_INVALID_FB = 0,
            XR_SPACE_PERSISTENCE_MODE_INDEFINITE_FB = 1,
            XR_SPACE_PERSISTENCE_MODE_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpaceSaveInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;

            public XrSpaceStorageLocationFB location;

            public XrSpacePersistenceModeFB persistenceMode;
        }

        public unsafe partial struct XrSpaceEraseInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;

            public XrSpaceStorageLocationFB location;
        }

        public unsafe partial struct XrEventDataSpaceSaveCompleteFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
            public IntPtr space;
            public XrUuid uuid;

            public XrSpaceStorageLocationFB location;
        }

        public unsafe partial struct XrEventDataSpaceEraseCompleteFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
            public IntPtr space;
            public XrUuid uuid;

            public XrSpaceStorageLocationFB location;
        }

        public partial struct XrSpaceUserFB
        {
        }

        public unsafe partial struct XrSpaceShareInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint spaceCount;
            public IntPtr* spaces;
            public uint userCount;
            public XrSpaceUserFB** users;
        }

        public unsafe partial struct XrEventDataSpaceShareCompleteFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
        }

        public unsafe partial struct XrCompositionLayerSpaceWarpInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;

            public XrSwapchainSubImage motionVectorSubImage;

            public XrPosef appSpaceDeltaPose;

            public XrSwapchainSubImage depthSubImage;

            public float minDepth;

            public float maxDepth;

            public float nearZ;

            public float farZ;
        }

        public unsafe partial struct XrSystemSpaceWarpPropertiesFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint recommendedMotionVectorImageRectWidth;
            public uint recommendedMotionVectorImageRectHeight;
        }

        public unsafe partial struct XrHapticAmplitudeEnvelopeVibrationFB
        {
            public Types.XrStructureType type;
            public void* next;
            public long duration;
            public uint amplitudeCount;
            public float* amplitudes;
        }

        public partial struct XrOffset3DfFB
        {
            public float x;

            public float y;

            public float z;
        }

        public partial struct XrRect3DfFB
        {
            public XrOffset3DfFB offset;
            public XrExtent3Df extent;
        }

        public unsafe partial struct XrSemanticLabelsFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint bufferCapacityInput;
            public uint bufferCountOutput;
            public byte* buffer;
        }

        public unsafe partial struct XrRoomLayoutFB
        {
            public Types.XrStructureType type;
            public void* next;
            public XrUuid floorUuid;
            public XrUuid ceilingUuid;
            public uint wallUuidCapacityInput;
            public uint wallUuidCountOutput;
            public XrUuid* wallUuids;
        }

        public unsafe partial struct XrBoundary2DFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrVector2f* vertices;
        }

        public unsafe partial struct XrSemanticLabelsSupportInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;
            public byte* recognizedLabels;
        }

        public unsafe partial struct XrDigitalLensControlALMALENCE
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;
        }

        public unsafe partial struct XrEventDataSceneCaptureCompleteFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
        }

        public unsafe partial struct XrSceneCaptureRequestInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint requestByteCount;
            public byte* request;
        }

        public unsafe partial struct XrSpaceContainerFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint uuidCapacityInput;
            public uint uuidCountOutput;
            public XrUuid* uuids;
        }

        public unsafe partial struct XrFoveationEyeTrackedProfileCreateInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;
        }

        public unsafe partial struct XrFoveationEyeTrackedStateMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public _foveationCenter_e__FixedBuffer foveationCenter;
            public ulong flags;

            [InlineArray(2)]
            public partial struct _foveationCenter_e__FixedBuffer
            {
                public XrVector2f e0;
            }
        }

        public unsafe partial struct XrSystemFoveationEyeTrackedPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsFoveationEyeTracked;
        }

        public partial struct XrFaceTrackerFB
        {
        }
        public enum XrFaceExpressionFB : uint
        {
            XR_FACE_EXPRESSION_BROW_LOWERER_L_FB = 0,
            XR_FACE_EXPRESSION_BROW_LOWERER_R_FB = 1,
            XR_FACE_EXPRESSION_CHEEK_PUFF_L_FB = 2,
            XR_FACE_EXPRESSION_CHEEK_PUFF_R_FB = 3,
            XR_FACE_EXPRESSION_CHEEK_RAISER_L_FB = 4,
            XR_FACE_EXPRESSION_CHEEK_RAISER_R_FB = 5,
            XR_FACE_EXPRESSION_CHEEK_SUCK_L_FB = 6,
            XR_FACE_EXPRESSION_CHEEK_SUCK_R_FB = 7,
            XR_FACE_EXPRESSION_CHIN_RAISER_B_FB = 8,
            XR_FACE_EXPRESSION_CHIN_RAISER_T_FB = 9,
            XR_FACE_EXPRESSION_DIMPLER_L_FB = 10,
            XR_FACE_EXPRESSION_DIMPLER_R_FB = 11,
            XR_FACE_EXPRESSION_EYES_CLOSED_L_FB = 12,
            XR_FACE_EXPRESSION_EYES_CLOSED_R_FB = 13,
            XR_FACE_EXPRESSION_EYES_LOOK_DOWN_L_FB = 14,
            XR_FACE_EXPRESSION_EYES_LOOK_DOWN_R_FB = 15,
            XR_FACE_EXPRESSION_EYES_LOOK_LEFT_L_FB = 16,
            XR_FACE_EXPRESSION_EYES_LOOK_LEFT_R_FB = 17,
            XR_FACE_EXPRESSION_EYES_LOOK_RIGHT_L_FB = 18,
            XR_FACE_EXPRESSION_EYES_LOOK_RIGHT_R_FB = 19,
            XR_FACE_EXPRESSION_EYES_LOOK_UP_L_FB = 20,
            XR_FACE_EXPRESSION_EYES_LOOK_UP_R_FB = 21,
            XR_FACE_EXPRESSION_INNER_BROW_RAISER_L_FB = 22,
            XR_FACE_EXPRESSION_INNER_BROW_RAISER_R_FB = 23,
            XR_FACE_EXPRESSION_JAW_DROP_FB = 24,
            XR_FACE_EXPRESSION_JAW_SIDEWAYS_LEFT_FB = 25,
            XR_FACE_EXPRESSION_JAW_SIDEWAYS_RIGHT_FB = 26,
            XR_FACE_EXPRESSION_JAW_THRUST_FB = 27,
            XR_FACE_EXPRESSION_LID_TIGHTENER_L_FB = 28,
            XR_FACE_EXPRESSION_LID_TIGHTENER_R_FB = 29,
            XR_FACE_EXPRESSION_LIP_CORNER_DEPRESSOR_L_FB = 30,
            XR_FACE_EXPRESSION_LIP_CORNER_DEPRESSOR_R_FB = 31,
            XR_FACE_EXPRESSION_LIP_CORNER_PULLER_L_FB = 32,
            XR_FACE_EXPRESSION_LIP_CORNER_PULLER_R_FB = 33,
            XR_FACE_EXPRESSION_LIP_FUNNELER_LB_FB = 34,
            XR_FACE_EXPRESSION_LIP_FUNNELER_LT_FB = 35,
            XR_FACE_EXPRESSION_LIP_FUNNELER_RB_FB = 36,
            XR_FACE_EXPRESSION_LIP_FUNNELER_RT_FB = 37,
            XR_FACE_EXPRESSION_LIP_PRESSOR_L_FB = 38,
            XR_FACE_EXPRESSION_LIP_PRESSOR_R_FB = 39,
            XR_FACE_EXPRESSION_LIP_PUCKER_L_FB = 40,
            XR_FACE_EXPRESSION_LIP_PUCKER_R_FB = 41,
            XR_FACE_EXPRESSION_LIP_STRETCHER_L_FB = 42,
            XR_FACE_EXPRESSION_LIP_STRETCHER_R_FB = 43,
            XR_FACE_EXPRESSION_LIP_SUCK_LB_FB = 44,
            XR_FACE_EXPRESSION_LIP_SUCK_LT_FB = 45,
            XR_FACE_EXPRESSION_LIP_SUCK_RB_FB = 46,
            XR_FACE_EXPRESSION_LIP_SUCK_RT_FB = 47,
            XR_FACE_EXPRESSION_LIP_TIGHTENER_L_FB = 48,
            XR_FACE_EXPRESSION_LIP_TIGHTENER_R_FB = 49,
            XR_FACE_EXPRESSION_LIPS_TOWARD_FB = 50,
            XR_FACE_EXPRESSION_LOWER_LIP_DEPRESSOR_L_FB = 51,
            XR_FACE_EXPRESSION_LOWER_LIP_DEPRESSOR_R_FB = 52,
            XR_FACE_EXPRESSION_MOUTH_LEFT_FB = 53,
            XR_FACE_EXPRESSION_MOUTH_RIGHT_FB = 54,
            XR_FACE_EXPRESSION_NOSE_WRINKLER_L_FB = 55,
            XR_FACE_EXPRESSION_NOSE_WRINKLER_R_FB = 56,
            XR_FACE_EXPRESSION_OUTER_BROW_RAISER_L_FB = 57,
            XR_FACE_EXPRESSION_OUTER_BROW_RAISER_R_FB = 58,
            XR_FACE_EXPRESSION_UPPER_LID_RAISER_L_FB = 59,
            XR_FACE_EXPRESSION_UPPER_LID_RAISER_R_FB = 60,
            XR_FACE_EXPRESSION_UPPER_LIP_RAISER_L_FB = 61,
            XR_FACE_EXPRESSION_UPPER_LIP_RAISER_R_FB = 62,
            XR_FACE_EXPRESSION_COUNT_FB = 63,
            XR_FACE_EXPRESSION_MAX_ENUM_FB = 0x7FFFFFFF,
        }
        public enum XrFaceExpressionSetFB : uint
        {
            XR_FACE_EXPRESSION_SET_DEFAULT_FB = 0,
            XR_FACE_EXPRESSION_SET_MAX_ENUM_FB = 0x7FFFFFFF,
        }
        public enum XrFaceConfidenceFB : uint
        {
            XR_FACE_CONFIDENCE_LOWER_FACE_FB = 0,
            XR_FACE_CONFIDENCE_UPPER_FACE_FB = 1,
            XR_FACE_CONFIDENCE_COUNT_FB = 2,
            XR_FACE_CONFIDENCE_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemFaceTrackingPropertiesFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsFaceTracking;
        }

        public unsafe partial struct XrFaceTrackerCreateInfoFB
        {
            public Types.XrStructureType type;
            public void* next;

            public XrFaceExpressionSetFB faceExpressionSet;
        }

        public unsafe partial struct XrFaceExpressionInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public long time;
        }

        public partial struct XrFaceExpressionStatusFB
        {
            public uint isValid;
            public uint isEyeFollowingBlendshapesValid;
        }

        public unsafe partial struct XrFaceExpressionWeightsFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint weightCount;

            public float* weights;
            public uint confidenceCount;

            public float* confidences;

            public XrFaceExpressionStatusFB status;
            public long time;
        }

        public partial struct XrEyeTrackerFB
        {
        }
        public enum XrEyePositionFB : uint
        {
            XR_EYE_POSITION_LEFT_FB = 0,
            XR_EYE_POSITION_RIGHT_FB = 1,
            XR_EYE_POSITION_COUNT_FB = 2,
            XR_EYE_POSITION_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public partial struct XrEyeGazeFB
        {
            public uint isValid;

            public XrPosef gazePose;

            public float gazeConfidence;
        }

        public unsafe partial struct XrEyeTrackerCreateInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrEyeGazesInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;
        }

        public unsafe partial struct XrSystemEyeTrackingPropertiesFB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsEyeTracking;
        }

        public unsafe partial struct XrEyeGazesFB
        {
            public Types.XrStructureType type;

            public void* next;
            public _gaze_e__FixedBuffer gaze;
            public long time;

            [InlineArray(2)]
            public partial struct _gaze_e__FixedBuffer
            {
                public XrEyeGazeFB e0;
            }
        }

        public unsafe partial struct XrPassthroughKeyboardHandsIntensityFB
        {
            public Types.XrStructureType type;
            public void* next;

            public float leftHandIntensity;

            public float rightHandIntensity;
        }

        public unsafe partial struct XrCompositionLayerSettingsFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;
        }

        public unsafe partial struct XrHapticPcmVibrationFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint bufferSize;
            public float* buffer;

            public float sampleRate;
            public uint append;
            public uint* samplesConsumed;
        }

        public unsafe partial struct XrDevicePcmSampleRateStateFB
        {
            public Types.XrStructureType type;

            public void* next;

            public float sampleRate;
        }

        public unsafe partial struct XrFrameSynthesisInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;

            public XrSwapchainSubImage motionVectorSubImage;

            public XrVector4f motionVectorScale;

            public XrVector4f motionVectorOffset;

            public XrPosef appSpaceDeltaPose;

            public XrSwapchainSubImage depthSubImage;

            public float minDepth;

            public float maxDepth;

            public float nearZ;

            public float farZ;
        }

        public unsafe partial struct XrFrameSynthesisConfigViewEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint recommendedMotionVectorImageRectWidth;
            public uint recommendedMotionVectorImageRectHeight;
        }
        public enum XrCompareOpFB : uint
        {
            XR_COMPARE_OP_NEVER_FB = 0,
            XR_COMPARE_OP_LESS_FB = 1,
            XR_COMPARE_OP_EQUAL_FB = 2,
            XR_COMPARE_OP_LESS_OR_EQUAL_FB = 3,
            XR_COMPARE_OP_GREATER_FB = 4,
            XR_COMPARE_OP_NOT_EQUAL_FB = 5,
            XR_COMPARE_OP_GREATER_OR_EQUAL_FB = 6,
            XR_COMPARE_OP_ALWAYS_FB = 7,
            XR_COMPARE_OP_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrCompositionLayerDepthTestFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint depthMask;

            public XrCompareOpFB compareOp;
        }
        public enum XrLocalDimmingModeMETA : uint
        {
            XR_LOCAL_DIMMING_MODE_OFF_META = 0,
            XR_LOCAL_DIMMING_MODE_ON_META = 1,
            XR_LOCAL_DIMMING_MODE_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public unsafe partial struct XrLocalDimmingFrameEndInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrLocalDimmingModeMETA localDimmingMode;
        }

        public unsafe partial struct XrPassthroughPreferencesMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;
        }

        public partial struct XrVirtualKeyboardMETA
        {
        }
        public enum XrVirtualKeyboardLocationTypeMETA : uint
        {
            XR_VIRTUAL_KEYBOARD_LOCATION_TYPE_CUSTOM_META = 0,
            XR_VIRTUAL_KEYBOARD_LOCATION_TYPE_FAR_META = 1,
            XR_VIRTUAL_KEYBOARD_LOCATION_TYPE_DIRECT_META = 2,
            XR_VIRTUAL_KEYBOARD_LOCATION_TYPE_MAX_ENUM_META = 0x7FFFFFFF,
        }
        public enum XrVirtualKeyboardInputSourceMETA : uint
        {
            XR_VIRTUAL_KEYBOARD_INPUT_SOURCE_CONTROLLER_RAY_LEFT_META = 1,
            XR_VIRTUAL_KEYBOARD_INPUT_SOURCE_CONTROLLER_RAY_RIGHT_META = 2,
            XR_VIRTUAL_KEYBOARD_INPUT_SOURCE_HAND_RAY_LEFT_META = 3,
            XR_VIRTUAL_KEYBOARD_INPUT_SOURCE_HAND_RAY_RIGHT_META = 4,
            XR_VIRTUAL_KEYBOARD_INPUT_SOURCE_CONTROLLER_DIRECT_LEFT_META = 5,
            XR_VIRTUAL_KEYBOARD_INPUT_SOURCE_CONTROLLER_DIRECT_RIGHT_META = 6,
            XR_VIRTUAL_KEYBOARD_INPUT_SOURCE_HAND_DIRECT_INDEX_TIP_LEFT_META = 7,
            XR_VIRTUAL_KEYBOARD_INPUT_SOURCE_HAND_DIRECT_INDEX_TIP_RIGHT_META = 8,
            XR_VIRTUAL_KEYBOARD_INPUT_SOURCE_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemVirtualKeyboardPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsVirtualKeyboard;
        }

        public unsafe partial struct XrVirtualKeyboardCreateInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrVirtualKeyboardSpaceCreateInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrVirtualKeyboardLocationTypeMETA locationType;
            public IntPtr space;

            public XrPosef poseInSpace;
        }

        public unsafe partial struct XrVirtualKeyboardLocationInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrVirtualKeyboardLocationTypeMETA locationType;
            public IntPtr space;

            public XrPosef poseInSpace;

            public float scale;
        }

        public unsafe partial struct XrVirtualKeyboardModelVisibilitySetInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint visible;
        }

        public unsafe partial struct XrVirtualKeyboardAnimationStateMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public int animationIndex;

            public float fraction;
        }

        public unsafe partial struct XrVirtualKeyboardModelAnimationStatesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint stateCapacityInput;
            public uint stateCountOutput;

            public XrVirtualKeyboardAnimationStateMETA* states;
        }

        public unsafe partial struct XrVirtualKeyboardTextureDataMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint textureWidth;
            public uint textureHeight;
            public uint bufferCapacityInput;
            public uint bufferCountOutput;
            public byte* buffer;
        }

        public unsafe partial struct XrVirtualKeyboardInputInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrVirtualKeyboardInputSourceMETA inputSource;
            public IntPtr inputSpace;

            public XrPosef inputPoseInSpace;
            public ulong inputState;
        }

        public unsafe partial struct XrVirtualKeyboardTextContextChangeInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public byte* textContext;
        }

        public unsafe partial struct XrEventDataVirtualKeyboardCommitTextMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public XrVirtualKeyboardMETA* keyboard;
            public _text_e__FixedBuffer text;

            [InlineArray(3992)]
            public partial struct _text_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrEventDataVirtualKeyboardBackspaceMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public XrVirtualKeyboardMETA* keyboard;
        }

        public unsafe partial struct XrEventDataVirtualKeyboardEnterMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public XrVirtualKeyboardMETA* keyboard;
        }

        public unsafe partial struct XrEventDataVirtualKeyboardShownMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public XrVirtualKeyboardMETA* keyboard;
        }

        public unsafe partial struct XrEventDataVirtualKeyboardHiddenMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public XrVirtualKeyboardMETA* keyboard;
        }
        public enum XrExternalCameraAttachedToDeviceOCULUS : uint
        {
            XR_EXTERNAL_CAMERA_ATTACHED_TO_DEVICE_NONE_OCULUS = 0,
            XR_EXTERNAL_CAMERA_ATTACHED_TO_DEVICE_HMD_OCULUS = 1,
            XR_EXTERNAL_CAMERA_ATTACHED_TO_DEVICE_LTOUCH_OCULUS = 2,
            XR_EXTERNAL_CAMERA_ATTACHED_TO_DEVICE_RTOUCH_OCULUS = 3,
            XR_EXTERNAL_CAMERA_ATTACHED_TO_DEVICE_MAX_ENUM_OCULUS = 0x7FFFFFFF,
        }

        public partial struct XrExternalCameraIntrinsicsOCULUS
        {
            public long lastChangeTime;

            public XrFovf fov;

            public float virtualNearPlaneDistance;

            public float virtualFarPlaneDistance;

            public XrExtent2Di imageSensorPixelResolution;
        }

        public partial struct XrExternalCameraExtrinsicsOCULUS
        {
            public long lastChangeTime;
            public ulong cameraStatusFlags;

            public XrExternalCameraAttachedToDeviceOCULUS attachedToDevice;

            public XrPosef relativePose;
        }

        public unsafe partial struct XrExternalCameraOCULUS
        {
            public Types.XrStructureType type;
            public void* next;
            public _name_e__FixedBuffer name;

            public XrExternalCameraIntrinsicsOCULUS intrinsics;

            public XrExternalCameraExtrinsicsOCULUS extrinsics;

            [InlineArray(32)]
            public partial struct _name_e__FixedBuffer
            {
                public byte e0;
            }
        }
        public enum XrPerformanceMetricsCounterUnitMETA : uint
        {
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_GENERIC_META = 0,
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_PERCENTAGE_META = 1,
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_MILLISECONDS_META = 2,
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_BYTES_META = 3,
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_HERTZ_META = 4,
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public unsafe partial struct XrPerformanceMetricsStateMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint enabled;
        }

        public unsafe partial struct XrPerformanceMetricsCounterMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong counterFlags;

            public XrPerformanceMetricsCounterUnitMETA counterUnit;
            public uint uintValue;

            public float floatValue;
        }

        public unsafe partial struct XrSpaceListSaveInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public uint spaceCount;
            public IntPtr* spaces;

            public XrSpaceStorageLocationFB location;
        }

        public unsafe partial struct XrEventDataSpaceListSaveCompleteFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
        }

        public unsafe partial struct XrSpaceUserCreateInfoFB
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong userId;
        }

        public unsafe partial struct XrSystemHeadsetIdPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public XrUuid id;
        }

        public unsafe partial struct XrSystemSpaceDiscoveryPropertiesMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint supportsSpaceDiscovery;
        }

        public unsafe partial struct XrSpaceFilterBaseHeaderMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpaceDiscoveryInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint filterCount;
            public XrSpaceFilterBaseHeaderMETA** filters;
        }

        public unsafe partial struct XrSpaceFilterUuidMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint uuidCount;
            public XrUuid* uuids;
        }

        public unsafe partial struct XrSpaceFilterComponentMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpaceComponentTypeFB componentType;
        }

        public unsafe partial struct XrSpaceDiscoveryResultMETA
        {
            public IntPtr space;
            public XrUuid uuid;
        }

        public unsafe partial struct XrSpaceDiscoveryResultsMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint resultCapacityInput;
            public uint resultCountOutput;

            public XrSpaceDiscoveryResultMETA* results;
        }

        public unsafe partial struct XrEventDataSpaceDiscoveryResultsAvailableMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;
        }

        public unsafe partial struct XrEventDataSpaceDiscoveryCompleteMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
        }

        public unsafe partial struct XrRecommendedLayerResolutionMETA
        {
            public Types.XrStructureType type;

            public void* next;

            public XrExtent2Di recommendedImageDimensions;
            public uint isValid;
        }

        public unsafe partial struct XrRecommendedLayerResolutionGetInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public XrCompositionLayerBaseHeader* layer;
            public long predictedDisplayTime;
        }

        public unsafe partial struct XrSystemSpacePersistencePropertiesMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint supportsSpacePersistence;
        }

        public unsafe partial struct XrSpacesSaveInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint spaceCount;
            public IntPtr* spaces;
        }

        public unsafe partial struct XrEventDataSpacesSaveResultMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
        }

        public unsafe partial struct XrSpacesEraseInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint spaceCount;
            public IntPtr* spaces;
            public uint uuidCount;
            public XrUuid* uuids;
        }

        public unsafe partial struct XrEventDataSpacesEraseResultMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
        }

        public partial struct XrPassthroughColorLutMETA
        {
        }
        public enum XrPassthroughColorLutChannelsMETA : uint
        {
            XR_PASSTHROUGH_COLOR_LUT_CHANNELS_RGB_META = 1,
            XR_PASSTHROUGH_COLOR_LUT_CHANNELS_RGBA_META = 2,
            XR_PASSTHROUGH_COLOR_LUT_CHANNELS_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public unsafe partial struct XrPassthroughColorLutDataMETA
        {
            public uint bufferSize;
            public byte* buffer;
        }

        public unsafe partial struct XrPassthroughColorLutCreateInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrPassthroughColorLutChannelsMETA channels;
            public uint resolution;

            public XrPassthroughColorLutDataMETA data;
        }

        public unsafe partial struct XrPassthroughColorLutUpdateInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrPassthroughColorLutDataMETA data;
        }

        public unsafe partial struct XrPassthroughColorMapLutMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public XrPassthroughColorLutMETA* colorLut;

            public float weight;
        }

        public unsafe partial struct XrPassthroughColorMapInterpolatedLutMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public XrPassthroughColorLutMETA* sourceColorLut;
            public XrPassthroughColorLutMETA* targetColorLut;

            public float weight;
        }

        public unsafe partial struct XrSystemPassthroughColorLutPropertiesMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint maxColorLutResolution;
        }

        public unsafe partial struct XrSpaceTriangleMeshGetInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpaceTriangleMeshMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrVector3f* vertices;
            public uint indexCapacityInput;
            public uint indexCountOutput;
            public uint* indices;
        }
        public enum XrFullBodyJointMETA : uint
        {
            XR_FULL_BODY_JOINT_ROOT_META = 0,
            XR_FULL_BODY_JOINT_HIPS_META = 1,
            XR_FULL_BODY_JOINT_SPINE_LOWER_META = 2,
            XR_FULL_BODY_JOINT_SPINE_MIDDLE_META = 3,
            XR_FULL_BODY_JOINT_SPINE_UPPER_META = 4,
            XR_FULL_BODY_JOINT_CHEST_META = 5,
            XR_FULL_BODY_JOINT_NECK_META = 6,
            XR_FULL_BODY_JOINT_HEAD_META = 7,
            XR_FULL_BODY_JOINT_LEFT_SHOULDER_META = 8,
            XR_FULL_BODY_JOINT_LEFT_SCAPULA_META = 9,
            XR_FULL_BODY_JOINT_LEFT_ARM_UPPER_META = 10,
            XR_FULL_BODY_JOINT_LEFT_ARM_LOWER_META = 11,
            XR_FULL_BODY_JOINT_LEFT_HAND_WRIST_TWIST_META = 12,
            XR_FULL_BODY_JOINT_RIGHT_SHOULDER_META = 13,
            XR_FULL_BODY_JOINT_RIGHT_SCAPULA_META = 14,
            XR_FULL_BODY_JOINT_RIGHT_ARM_UPPER_META = 15,
            XR_FULL_BODY_JOINT_RIGHT_ARM_LOWER_META = 16,
            XR_FULL_BODY_JOINT_RIGHT_HAND_WRIST_TWIST_META = 17,
            XR_FULL_BODY_JOINT_LEFT_HAND_PALM_META = 18,
            XR_FULL_BODY_JOINT_LEFT_HAND_WRIST_META = 19,
            XR_FULL_BODY_JOINT_LEFT_HAND_THUMB_METACARPAL_META = 20,
            XR_FULL_BODY_JOINT_LEFT_HAND_THUMB_PROXIMAL_META = 21,
            XR_FULL_BODY_JOINT_LEFT_HAND_THUMB_DISTAL_META = 22,
            XR_FULL_BODY_JOINT_LEFT_HAND_THUMB_TIP_META = 23,
            XR_FULL_BODY_JOINT_LEFT_HAND_INDEX_METACARPAL_META = 24,
            XR_FULL_BODY_JOINT_LEFT_HAND_INDEX_PROXIMAL_META = 25,
            XR_FULL_BODY_JOINT_LEFT_HAND_INDEX_INTERMEDIATE_META = 26,
            XR_FULL_BODY_JOINT_LEFT_HAND_INDEX_DISTAL_META = 27,
            XR_FULL_BODY_JOINT_LEFT_HAND_INDEX_TIP_META = 28,
            XR_FULL_BODY_JOINT_LEFT_HAND_MIDDLE_METACARPAL_META = 29,
            XR_FULL_BODY_JOINT_LEFT_HAND_MIDDLE_PROXIMAL_META = 30,
            XR_FULL_BODY_JOINT_LEFT_HAND_MIDDLE_INTERMEDIATE_META = 31,
            XR_FULL_BODY_JOINT_LEFT_HAND_MIDDLE_DISTAL_META = 32,
            XR_FULL_BODY_JOINT_LEFT_HAND_MIDDLE_TIP_META = 33,
            XR_FULL_BODY_JOINT_LEFT_HAND_RING_METACARPAL_META = 34,
            XR_FULL_BODY_JOINT_LEFT_HAND_RING_PROXIMAL_META = 35,
            XR_FULL_BODY_JOINT_LEFT_HAND_RING_INTERMEDIATE_META = 36,
            XR_FULL_BODY_JOINT_LEFT_HAND_RING_DISTAL_META = 37,
            XR_FULL_BODY_JOINT_LEFT_HAND_RING_TIP_META = 38,
            XR_FULL_BODY_JOINT_LEFT_HAND_LITTLE_METACARPAL_META = 39,
            XR_FULL_BODY_JOINT_LEFT_HAND_LITTLE_PROXIMAL_META = 40,
            XR_FULL_BODY_JOINT_LEFT_HAND_LITTLE_INTERMEDIATE_META = 41,
            XR_FULL_BODY_JOINT_LEFT_HAND_LITTLE_DISTAL_META = 42,
            XR_FULL_BODY_JOINT_LEFT_HAND_LITTLE_TIP_META = 43,
            XR_FULL_BODY_JOINT_RIGHT_HAND_PALM_META = 44,
            XR_FULL_BODY_JOINT_RIGHT_HAND_WRIST_META = 45,
            XR_FULL_BODY_JOINT_RIGHT_HAND_THUMB_METACARPAL_META = 46,
            XR_FULL_BODY_JOINT_RIGHT_HAND_THUMB_PROXIMAL_META = 47,
            XR_FULL_BODY_JOINT_RIGHT_HAND_THUMB_DISTAL_META = 48,
            XR_FULL_BODY_JOINT_RIGHT_HAND_THUMB_TIP_META = 49,
            XR_FULL_BODY_JOINT_RIGHT_HAND_INDEX_METACARPAL_META = 50,
            XR_FULL_BODY_JOINT_RIGHT_HAND_INDEX_PROXIMAL_META = 51,
            XR_FULL_BODY_JOINT_RIGHT_HAND_INDEX_INTERMEDIATE_META = 52,
            XR_FULL_BODY_JOINT_RIGHT_HAND_INDEX_DISTAL_META = 53,
            XR_FULL_BODY_JOINT_RIGHT_HAND_INDEX_TIP_META = 54,
            XR_FULL_BODY_JOINT_RIGHT_HAND_MIDDLE_METACARPAL_META = 55,
            XR_FULL_BODY_JOINT_RIGHT_HAND_MIDDLE_PROXIMAL_META = 56,
            XR_FULL_BODY_JOINT_RIGHT_HAND_MIDDLE_INTERMEDIATE_META = 57,
            XR_FULL_BODY_JOINT_RIGHT_HAND_MIDDLE_DISTAL_META = 58,
            XR_FULL_BODY_JOINT_RIGHT_HAND_MIDDLE_TIP_META = 59,
            XR_FULL_BODY_JOINT_RIGHT_HAND_RING_METACARPAL_META = 60,
            XR_FULL_BODY_JOINT_RIGHT_HAND_RING_PROXIMAL_META = 61,
            XR_FULL_BODY_JOINT_RIGHT_HAND_RING_INTERMEDIATE_META = 62,
            XR_FULL_BODY_JOINT_RIGHT_HAND_RING_DISTAL_META = 63,
            XR_FULL_BODY_JOINT_RIGHT_HAND_RING_TIP_META = 64,
            XR_FULL_BODY_JOINT_RIGHT_HAND_LITTLE_METACARPAL_META = 65,
            XR_FULL_BODY_JOINT_RIGHT_HAND_LITTLE_PROXIMAL_META = 66,
            XR_FULL_BODY_JOINT_RIGHT_HAND_LITTLE_INTERMEDIATE_META = 67,
            XR_FULL_BODY_JOINT_RIGHT_HAND_LITTLE_DISTAL_META = 68,
            XR_FULL_BODY_JOINT_RIGHT_HAND_LITTLE_TIP_META = 69,
            XR_FULL_BODY_JOINT_LEFT_UPPER_LEG_META = 70,
            XR_FULL_BODY_JOINT_LEFT_LOWER_LEG_META = 71,
            XR_FULL_BODY_JOINT_LEFT_FOOT_ANKLE_TWIST_META = 72,
            XR_FULL_BODY_JOINT_LEFT_FOOT_ANKLE_META = 73,
            XR_FULL_BODY_JOINT_LEFT_FOOT_SUBTALAR_META = 74,
            XR_FULL_BODY_JOINT_LEFT_FOOT_TRANSVERSE_META = 75,
            XR_FULL_BODY_JOINT_LEFT_FOOT_BALL_META = 76,
            XR_FULL_BODY_JOINT_RIGHT_UPPER_LEG_META = 77,
            XR_FULL_BODY_JOINT_RIGHT_LOWER_LEG_META = 78,
            XR_FULL_BODY_JOINT_RIGHT_FOOT_ANKLE_TWIST_META = 79,
            XR_FULL_BODY_JOINT_RIGHT_FOOT_ANKLE_META = 80,
            XR_FULL_BODY_JOINT_RIGHT_FOOT_SUBTALAR_META = 81,
            XR_FULL_BODY_JOINT_RIGHT_FOOT_TRANSVERSE_META = 82,
            XR_FULL_BODY_JOINT_RIGHT_FOOT_BALL_META = 83,
            XR_FULL_BODY_JOINT_COUNT_META = 84,
            XR_FULL_BODY_JOINT_NONE_META = 85,
            XR_FULL_BODY_JOINT_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemPropertiesBodyTrackingFullBodyMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsFullBodyTracking;
        }

        public unsafe partial struct XrEventDataPassthroughLayerResumedMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public XrPassthroughLayerFB* layer;
        }
        public enum XrBodyTrackingCalibrationStateMETA : uint
        {
            XR_BODY_TRACKING_CALIBRATION_STATE_VALID_META = 1,
            XR_BODY_TRACKING_CALIBRATION_STATE_CALIBRATING_META = 2,
            XR_BODY_TRACKING_CALIBRATION_STATE_INVALID_META = 3,
            XR_BODY_TRACKING_CALIBRATION_STATE_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public unsafe partial struct XrBodyTrackingCalibrationStatusMETA
        {
            public Types.XrStructureType type;

            public void* next;

            public XrBodyTrackingCalibrationStateMETA status;
        }

        public unsafe partial struct XrBodyTrackingCalibrationInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public float bodyHeight;
        }

        public unsafe partial struct XrSystemPropertiesBodyTrackingCalibrationMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsHeightOverride;
        }
        public enum XrBodyTrackingFidelityMETA : uint
        {
            XR_BODY_TRACKING_FIDELITY_LOW_META = 1,
            XR_BODY_TRACKING_FIDELITY_HIGH_META = 2,
            XR_BODY_TRACKING_FIDELITY_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemPropertiesBodyTrackingFidelityMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsBodyTrackingFidelity;
        }

        public unsafe partial struct XrBodyTrackingFidelityStatusMETA
        {
            public Types.XrStructureType type;

            public void* next;

            public XrBodyTrackingFidelityMETA fidelity;
        }

        public partial struct XrFaceTracker2FB
        {
        }
        public enum XrFaceExpression2FB : uint
        {
            XR_FACE_EXPRESSION2_BROW_LOWERER_L_FB = 0,
            XR_FACE_EXPRESSION2_BROW_LOWERER_R_FB = 1,
            XR_FACE_EXPRESSION2_CHEEK_PUFF_L_FB = 2,
            XR_FACE_EXPRESSION2_CHEEK_PUFF_R_FB = 3,
            XR_FACE_EXPRESSION2_CHEEK_RAISER_L_FB = 4,
            XR_FACE_EXPRESSION2_CHEEK_RAISER_R_FB = 5,
            XR_FACE_EXPRESSION2_CHEEK_SUCK_L_FB = 6,
            XR_FACE_EXPRESSION2_CHEEK_SUCK_R_FB = 7,
            XR_FACE_EXPRESSION2_CHIN_RAISER_B_FB = 8,
            XR_FACE_EXPRESSION2_CHIN_RAISER_T_FB = 9,
            XR_FACE_EXPRESSION2_DIMPLER_L_FB = 10,
            XR_FACE_EXPRESSION2_DIMPLER_R_FB = 11,
            XR_FACE_EXPRESSION2_EYES_CLOSED_L_FB = 12,
            XR_FACE_EXPRESSION2_EYES_CLOSED_R_FB = 13,
            XR_FACE_EXPRESSION2_EYES_LOOK_DOWN_L_FB = 14,
            XR_FACE_EXPRESSION2_EYES_LOOK_DOWN_R_FB = 15,
            XR_FACE_EXPRESSION2_EYES_LOOK_LEFT_L_FB = 16,
            XR_FACE_EXPRESSION2_EYES_LOOK_LEFT_R_FB = 17,
            XR_FACE_EXPRESSION2_EYES_LOOK_RIGHT_L_FB = 18,
            XR_FACE_EXPRESSION2_EYES_LOOK_RIGHT_R_FB = 19,
            XR_FACE_EXPRESSION2_EYES_LOOK_UP_L_FB = 20,
            XR_FACE_EXPRESSION2_EYES_LOOK_UP_R_FB = 21,
            XR_FACE_EXPRESSION2_INNER_BROW_RAISER_L_FB = 22,
            XR_FACE_EXPRESSION2_INNER_BROW_RAISER_R_FB = 23,
            XR_FACE_EXPRESSION2_JAW_DROP_FB = 24,
            XR_FACE_EXPRESSION2_JAW_SIDEWAYS_LEFT_FB = 25,
            XR_FACE_EXPRESSION2_JAW_SIDEWAYS_RIGHT_FB = 26,
            XR_FACE_EXPRESSION2_JAW_THRUST_FB = 27,
            XR_FACE_EXPRESSION2_LID_TIGHTENER_L_FB = 28,
            XR_FACE_EXPRESSION2_LID_TIGHTENER_R_FB = 29,
            XR_FACE_EXPRESSION2_LIP_CORNER_DEPRESSOR_L_FB = 30,
            XR_FACE_EXPRESSION2_LIP_CORNER_DEPRESSOR_R_FB = 31,
            XR_FACE_EXPRESSION2_LIP_CORNER_PULLER_L_FB = 32,
            XR_FACE_EXPRESSION2_LIP_CORNER_PULLER_R_FB = 33,
            XR_FACE_EXPRESSION2_LIP_FUNNELER_LB_FB = 34,
            XR_FACE_EXPRESSION2_LIP_FUNNELER_LT_FB = 35,
            XR_FACE_EXPRESSION2_LIP_FUNNELER_RB_FB = 36,
            XR_FACE_EXPRESSION2_LIP_FUNNELER_RT_FB = 37,
            XR_FACE_EXPRESSION2_LIP_PRESSOR_L_FB = 38,
            XR_FACE_EXPRESSION2_LIP_PRESSOR_R_FB = 39,
            XR_FACE_EXPRESSION2_LIP_PUCKER_L_FB = 40,
            XR_FACE_EXPRESSION2_LIP_PUCKER_R_FB = 41,
            XR_FACE_EXPRESSION2_LIP_STRETCHER_L_FB = 42,
            XR_FACE_EXPRESSION2_LIP_STRETCHER_R_FB = 43,
            XR_FACE_EXPRESSION2_LIP_SUCK_LB_FB = 44,
            XR_FACE_EXPRESSION2_LIP_SUCK_LT_FB = 45,
            XR_FACE_EXPRESSION2_LIP_SUCK_RB_FB = 46,
            XR_FACE_EXPRESSION2_LIP_SUCK_RT_FB = 47,
            XR_FACE_EXPRESSION2_LIP_TIGHTENER_L_FB = 48,
            XR_FACE_EXPRESSION2_LIP_TIGHTENER_R_FB = 49,
            XR_FACE_EXPRESSION2_LIPS_TOWARD_FB = 50,
            XR_FACE_EXPRESSION2_LOWER_LIP_DEPRESSOR_L_FB = 51,
            XR_FACE_EXPRESSION2_LOWER_LIP_DEPRESSOR_R_FB = 52,
            XR_FACE_EXPRESSION2_MOUTH_LEFT_FB = 53,
            XR_FACE_EXPRESSION2_MOUTH_RIGHT_FB = 54,
            XR_FACE_EXPRESSION2_NOSE_WRINKLER_L_FB = 55,
            XR_FACE_EXPRESSION2_NOSE_WRINKLER_R_FB = 56,
            XR_FACE_EXPRESSION2_OUTER_BROW_RAISER_L_FB = 57,
            XR_FACE_EXPRESSION2_OUTER_BROW_RAISER_R_FB = 58,
            XR_FACE_EXPRESSION2_UPPER_LID_RAISER_L_FB = 59,
            XR_FACE_EXPRESSION2_UPPER_LID_RAISER_R_FB = 60,
            XR_FACE_EXPRESSION2_UPPER_LIP_RAISER_L_FB = 61,
            XR_FACE_EXPRESSION2_UPPER_LIP_RAISER_R_FB = 62,
            XR_FACE_EXPRESSION2_TONGUE_TIP_INTERDENTAL_FB = 63,
            XR_FACE_EXPRESSION2_TONGUE_TIP_ALVEOLAR_FB = 64,
            XR_FACE_EXPRESSION2_TONGUE_FRONT_DORSAL_PALATE_FB = 65,
            XR_FACE_EXPRESSION2_TONGUE_MID_DORSAL_PALATE_FB = 66,
            XR_FACE_EXPRESSION2_TONGUE_BACK_DORSAL_VELAR_FB = 67,
            XR_FACE_EXPRESSION2_TONGUE_OUT_FB = 68,
            XR_FACE_EXPRESSION2_TONGUE_RETREAT_FB = 69,
            XR_FACE_EXPRESSION2_COUNT_FB = 70,
            XR_FACE_EXPRESSION_2FB_MAX_ENUM_FB = 0x7FFFFFFF,
        }
        public enum XrFaceExpressionSet2FB : uint
        {
            XR_FACE_EXPRESSION_SET2_DEFAULT_FB = 0,
            XR_FACE_EXPRESSION_SET_2FB_MAX_ENUM_FB = 0x7FFFFFFF,
        }
        public enum XrFaceTrackingDataSource2FB : uint
        {
            XR_FACE_TRACKING_DATA_SOURCE2_VISUAL_FB = 0,
            XR_FACE_TRACKING_DATA_SOURCE2_AUDIO_FB = 1,
            XR_FACE_TRACKING_DATA_SOURCE_2FB_MAX_ENUM_FB = 0x7FFFFFFF,
        }
        public enum XrFaceConfidence2FB : uint
        {
            XR_FACE_CONFIDENCE2_LOWER_FACE_FB = 0,
            XR_FACE_CONFIDENCE2_UPPER_FACE_FB = 1,
            XR_FACE_CONFIDENCE2_COUNT_FB = 2,
            XR_FACE_CONFIDENCE_2FB_MAX_ENUM_FB = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemFaceTrackingProperties2FB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsVisualFaceTracking;
            public uint supportsAudioFaceTracking;
        }

        public unsafe partial struct XrFaceTrackerCreateInfo2FB
        {
            public Types.XrStructureType type;
            public void* next;

            public XrFaceExpressionSet2FB faceExpressionSet;
            public uint requestedDataSourceCount;

            public XrFaceTrackingDataSource2FB* requestedDataSources;
        }

        public unsafe partial struct XrFaceExpressionInfo2FB
        {
            public Types.XrStructureType type;
            public void* next;
            public long time;
        }

        public unsafe partial struct XrFaceExpressionWeights2FB
        {
            public Types.XrStructureType type;

            public void* next;
            public uint weightCount;

            public float* weights;
            public uint confidenceCount;

            public float* confidences;
            public uint isValid;
            public uint isEyeFollowingBlendshapesValid;

            public XrFaceTrackingDataSource2FB dataSource;
            public long time;
        }

        public unsafe partial struct XrSystemSpatialEntitySharingPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsSpatialEntitySharing;
        }

        public unsafe partial struct XrShareSpacesRecipientBaseHeaderMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrShareSpacesInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint spaceCount;
            public IntPtr* spaces;
            public XrShareSpacesRecipientBaseHeaderMETA* recipientInfo;
        }

        public unsafe partial struct XrEventDataShareSpacesCompleteMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
        }

        public partial struct XrEnvironmentDepthProviderMETA
        {
        }

        public partial struct XrEnvironmentDepthSwapchainMETA
        {
        }

        public unsafe partial struct XrEnvironmentDepthProviderCreateInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong createFlags;
        }

        public unsafe partial struct XrEnvironmentDepthSwapchainCreateInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong createFlags;
        }

        public unsafe partial struct XrEnvironmentDepthSwapchainStateMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint width;
            public uint height;
        }

        public unsafe partial struct XrEnvironmentDepthImageAcquireInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;
            public long displayTime;
        }

        public unsafe partial struct XrEnvironmentDepthImageViewMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrFovf fov;

            public XrPosef pose;
        }

        public unsafe partial struct XrEnvironmentDepthImageMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint swapchainIndex;

            public float nearZ;

            public float farZ;
            public _views_e__FixedBuffer views;

            [InlineArray(2)]
            public partial struct _views_e__FixedBuffer
            {
                public XrEnvironmentDepthImageViewMETA e0;
            }
        }

        public unsafe partial struct XrEnvironmentDepthImageTimestampMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public long captureTime;
        }

        public unsafe partial struct XrEnvironmentDepthHandRemovalSetInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint enabled;
        }

        public unsafe partial struct XrSystemEnvironmentDepthPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsEnvironmentDepth;
            public uint supportsHandRemoval;
        }

        public partial struct XrRenderModelEXT
        {
        }

        public partial struct XrRenderModelAssetEXT
        {
        }

        public unsafe partial struct XrRenderModelCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong renderModelId;
            public uint gltfExtensionCount;
            public byte** gltfExtensions;
        }

        public unsafe partial struct XrRenderModelPropertiesGetInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrRenderModelPropertiesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public XrUuid cacheId;
            public uint animatableNodeCount;
        }

        public unsafe partial struct XrRenderModelSpaceCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrRenderModelEXT* renderModel;
        }

        public unsafe partial struct XrRenderModelStateGetInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public long displayTime;
        }

        public partial struct XrRenderModelNodeStateEXT
        {
            public XrPosef nodePose;
            public uint isVisible;
        }

        public unsafe partial struct XrRenderModelStateEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint nodeStateCount;

            public XrRenderModelNodeStateEXT* nodeStates;
        }

        public unsafe partial struct XrRenderModelAssetCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrUuid cacheId;
        }

        public unsafe partial struct XrRenderModelAssetDataGetInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrRenderModelAssetDataEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint bufferCapacityInput;
            public uint bufferCountOutput;
            public byte* buffer;
        }

        public unsafe partial struct XrRenderModelAssetPropertiesGetInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public partial struct XrRenderModelAssetNodePropertiesEXT
        {
            public _uniqueName_e__FixedBuffer uniqueName;

            [InlineArray(64)]
            public partial struct _uniqueName_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrRenderModelAssetPropertiesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint nodePropertyCount;

            public XrRenderModelAssetNodePropertiesEXT* nodeProperties;
        }

        public unsafe partial struct XrInteractionRenderModelIdsEnumerateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrInteractionRenderModelSubactionPathInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrInteractionRenderModelTopLevelUserPathGetInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint topLevelUserPathCount;
            public ulong* topLevelUserPaths;
        }

        public unsafe partial struct XrEventDataInteractionRenderModelsChangedEXT
        {
            public Types.XrStructureType type;
            public void* next;
        }
        public enum XrTrackingOptimizationSettingsDomainQCOM : uint
        {
            XR_TRACKING_OPTIMIZATION_SETTINGS_DOMAIN_ALL_QCOM = 1,
            XR_TRACKING_OPTIMIZATION_SETTINGS_DOMAIN_MAX_ENUM_QCOM = 0x7FFFFFFF,
        }
        public enum XrTrackingOptimizationSettingsHintQCOM : uint
        {
            XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_NONE_QCOM = 0,
            XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_LONG_RANGE_PRIORITIZATION_QCOM = 1,
            XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_CLOSE_RANGE_PRIORITIZATION_QCOM = 2,
            XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_LOW_POWER_PRIORITIZATION_QCOM = 3,
            XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_HIGH_POWER_PRIORITIZATION_QCOM = 4,
            XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_LONG_RANGE_PRIORIZATION_QCOM = XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_LONG_RANGE_PRIORITIZATION_QCOM,
            XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_CLOSE_RANGE_PRIORIZATION_QCOM = XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_CLOSE_RANGE_PRIORITIZATION_QCOM,
            XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_LOW_POWER_PRIORIZATION_QCOM = XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_LOW_POWER_PRIORITIZATION_QCOM,
            XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_HIGH_POWER_PRIORIZATION_QCOM = XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_HIGH_POWER_PRIORITIZATION_QCOM,
            XR_TRACKING_OPTIMIZATION_SETTINGS_HINT_MAX_ENUM_QCOM = 0x7FFFFFFF,
        }

        public enum XrHandGestureTypeQCOM
        {
            XR_HAND_GESTURE_TYPE_UNKNOWN_QCOM = -1,
            XR_HAND_GESTURE_TYPE_OPEN_HAND_QCOM = 0,
            XR_HAND_GESTURE_TYPE_GRAB_QCOM = 2,
            XR_HAND_GESTURE_TYPE_PINCH_QCOM = 7,
            XR_HAND_GESTURE_TYPE_MAX_ENUM_QCOM = 0x7FFFFFFF,
        }

        public partial struct XrHandGestureQCOM
        {
            public XrHandGestureTypeQCOM gesture;

            public float gestureRatio;

            public float flipRatio;
        }

        public partial struct XrPassthroughHTC
        {
        }
        public enum XrPassthroughFormHTC : uint
        {
            XR_PASSTHROUGH_FORM_PLANAR_HTC = 0,
            XR_PASSTHROUGH_FORM_PROJECTED_HTC = 1,
            XR_PASSTHROUGH_FORM_MAX_ENUM_HTC = 0x7FFFFFFF,
        }

        public unsafe partial struct XrPassthroughCreateInfoHTC
        {
            public Types.XrStructureType type;
            public void* next;

            public XrPassthroughFormHTC form;
        }

        public unsafe partial struct XrPassthroughColorHTC
        {
            public Types.XrStructureType type;
            public void* next;

            public float alpha;
        }

        public unsafe partial struct XrPassthroughMeshTransformInfoHTC
        {
            public Types.XrStructureType type;
            public void* next;
            public uint vertexCount;
            public XrVector3f* vertices;
            public uint indexCount;
            public uint* indices;
            public IntPtr baseSpace;
            public long time;

            public XrPosef pose;

            public XrVector3f scale;
        }

        public unsafe partial struct XrCompositionLayerPassthroughHTC
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;
            public IntPtr space;
            public XrPassthroughHTC* passthrough;

            public XrPassthroughColorHTC color;
        }
        public enum XrFoveationModeHTC : uint
        {
            XR_FOVEATION_MODE_DISABLE_HTC = 0,
            XR_FOVEATION_MODE_FIXED_HTC = 1,
            XR_FOVEATION_MODE_DYNAMIC_HTC = 2,
            XR_FOVEATION_MODE_CUSTOM_HTC = 3,
            XR_FOVEATION_MODE_MAX_ENUM_HTC = 0x7FFFFFFF,
        }
        public enum XrFoveationLevelHTC : uint
        {
            XR_FOVEATION_LEVEL_NONE_HTC = 0,
            XR_FOVEATION_LEVEL_LOW_HTC = 1,
            XR_FOVEATION_LEVEL_MEDIUM_HTC = 2,
            XR_FOVEATION_LEVEL_HIGH_HTC = 3,
            XR_FOVEATION_LEVEL_MAX_ENUM_HTC = 0x7FFFFFFF,
        }

        public unsafe partial struct XrFoveationApplyInfoHTC
        {
            public Types.XrStructureType type;
            public void* next;

            public XrFoveationModeHTC mode;
            public uint subImageCount;

            public XrSwapchainSubImage* subImages;
        }

        public partial struct XrFoveationConfigurationHTC
        {
            public XrFoveationLevelHTC level;

            public float clearFovDegree;

            public XrVector2f focalCenterOffset;
        }

        public unsafe partial struct XrFoveationDynamicModeInfoHTC
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong dynamicFlags;
        }

        public unsafe partial struct XrFoveationCustomModeInfoHTC
        {
            public Types.XrStructureType type;
            public void* next;
            public uint configCount;
            public XrFoveationConfigurationHTC* configs;
        }

        public unsafe partial struct XrSystemAnchorPropertiesHTC
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsAnchor;
        }

        public partial struct XrSpatialAnchorNameHTC
        {
            public _name_e__FixedBuffer name;

            [InlineArray(256)]
            public partial struct _name_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrSpatialAnchorCreateInfoHTC
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;

            public XrPosef poseInSpace;

            public XrSpatialAnchorNameHTC name;
        }

        public partial struct XrBodyTrackerHTC
        {
        }
        public enum XrBodyJointHTC : uint
        {
            XR_BODY_JOINT_PELVIS_HTC = 0,
            XR_BODY_JOINT_LEFT_HIP_HTC = 1,
            XR_BODY_JOINT_LEFT_KNEE_HTC = 2,
            XR_BODY_JOINT_LEFT_ANKLE_HTC = 3,
            XR_BODY_JOINT_LEFT_FEET_HTC = 4,
            XR_BODY_JOINT_RIGHT_HIP_HTC = 5,
            XR_BODY_JOINT_RIGHT_KNEE_HTC = 6,
            XR_BODY_JOINT_RIGHT_ANKLE_HTC = 7,
            XR_BODY_JOINT_RIGHT_FEET_HTC = 8,
            XR_BODY_JOINT_WAIST_HTC = 9,
            XR_BODY_JOINT_SPINE_LOWER_HTC = 10,
            XR_BODY_JOINT_SPINE_MIDDLE_HTC = 11,
            XR_BODY_JOINT_SPINE_HIGH_HTC = 12,
            XR_BODY_JOINT_CHEST_HTC = 13,
            XR_BODY_JOINT_NECK_HTC = 14,
            XR_BODY_JOINT_HEAD_HTC = 15,
            XR_BODY_JOINT_LEFT_CLAVICLE_HTC = 16,
            XR_BODY_JOINT_LEFT_SCAPULA_HTC = 17,
            XR_BODY_JOINT_LEFT_ARM_HTC = 18,
            XR_BODY_JOINT_LEFT_ELBOW_HTC = 19,
            XR_BODY_JOINT_LEFT_WRIST_HTC = 20,
            XR_BODY_JOINT_RIGHT_CLAVICLE_HTC = 21,
            XR_BODY_JOINT_RIGHT_SCAPULA_HTC = 22,
            XR_BODY_JOINT_RIGHT_ARM_HTC = 23,
            XR_BODY_JOINT_RIGHT_ELBOW_HTC = 24,
            XR_BODY_JOINT_RIGHT_WRIST_HTC = 25,
            XR_BODY_JOINT_MAX_ENUM_HTC = 0x7FFFFFFF,
        }
        public enum XrBodyJointSetHTC : uint
        {
            XR_BODY_JOINT_SET_FULL_HTC = 0,
            XR_BODY_JOINT_SET_MAX_ENUM_HTC = 0x7FFFFFFF,
        }
        public enum XrBodyJointConfidenceHTC : uint
        {
            XR_BODY_JOINT_CONFIDENCE_NONE_HTC = 0,
            XR_BODY_JOINT_CONFIDENCE_LOW_HTC = 1,
            XR_BODY_JOINT_CONFIDENCE_HIGH_HTC = 2,
            XR_BODY_JOINT_CONFIDENCE_MAX_ENUM_HTC = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemBodyTrackingPropertiesHTC
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsBodyTracking;
        }

        public unsafe partial struct XrBodyTrackerCreateInfoHTC
        {
            public Types.XrStructureType type;
            public void* next;

            public XrBodyJointSetHTC bodyJointSet;
        }

        public unsafe partial struct XrBodyJointsLocateInfoHTC
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;
        }

        public partial struct XrBodyJointLocationHTC
        {
            public ulong locationFlags;

            public XrPosef pose;
        }

        public unsafe partial struct XrBodyJointLocationsHTC
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong combinedLocationFlags;

            public XrBodyJointConfidenceHTC confidenceLevel;
            public uint jointLocationCount;

            public XrBodyJointLocationHTC* jointLocations;
            public uint skeletonGenerationId;
        }

        public partial struct XrBodySkeletonJointHTC
        {
            public XrPosef pose;
        }

        public unsafe partial struct XrBodySkeletonHTC
        {
            public Types.XrStructureType type;

            public void* next;
            public uint jointCount;

            public XrBodySkeletonJointHTC* joints;
        }

        public unsafe partial struct XrActiveActionSetPriorityEXT
        {
            public IntPtr actionSet;
            public uint priorityOverride;
        }

        public unsafe partial struct XrActiveActionSetPrioritiesEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint actionSetPriorityCount;
            public XrActiveActionSetPriorityEXT* actionSetPriorities;
        }
        public enum XrForceFeedbackCurlLocationMNDX : uint
        {
            XR_FORCE_FEEDBACK_CURL_LOCATION_THUMB_CURL_MNDX = 0,
            XR_FORCE_FEEDBACK_CURL_LOCATION_INDEX_CURL_MNDX = 1,
            XR_FORCE_FEEDBACK_CURL_LOCATION_MIDDLE_CURL_MNDX = 2,
            XR_FORCE_FEEDBACK_CURL_LOCATION_RING_CURL_MNDX = 3,
            XR_FORCE_FEEDBACK_CURL_LOCATION_LITTLE_CURL_MNDX = 4,
            XR_FORCE_FEEDBACK_CURL_LOCATION_MAX_ENUM_MNDX = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemForceFeedbackCurlPropertiesMNDX
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsForceFeedbackCurl;
        }

        public partial struct XrForceFeedbackCurlApplyLocationMNDX
        {
            public XrForceFeedbackCurlLocationMNDX location;

            public float value;
        }

        public unsafe partial struct XrForceFeedbackCurlApplyLocationsMNDX
        {
            public Types.XrStructureType type;
            public void* next;
            public uint locationCount;

            public XrForceFeedbackCurlApplyLocationMNDX* locations;
        }

        public partial struct XrBodyTrackerBD
        {
        }
        public enum XrBodyJointBD : uint
        {
            XR_BODY_JOINT_PELVIS_BD = 0,
            XR_BODY_JOINT_LEFT_HIP_BD = 1,
            XR_BODY_JOINT_RIGHT_HIP_BD = 2,
            XR_BODY_JOINT_SPINE1_BD = 3,
            XR_BODY_JOINT_LEFT_KNEE_BD = 4,
            XR_BODY_JOINT_RIGHT_KNEE_BD = 5,
            XR_BODY_JOINT_SPINE2_BD = 6,
            XR_BODY_JOINT_LEFT_ANKLE_BD = 7,
            XR_BODY_JOINT_RIGHT_ANKLE_BD = 8,
            XR_BODY_JOINT_SPINE3_BD = 9,
            XR_BODY_JOINT_LEFT_FOOT_BD = 10,
            XR_BODY_JOINT_RIGHT_FOOT_BD = 11,
            XR_BODY_JOINT_NECK_BD = 12,
            XR_BODY_JOINT_LEFT_COLLAR_BD = 13,
            XR_BODY_JOINT_RIGHT_COLLAR_BD = 14,
            XR_BODY_JOINT_HEAD_BD = 15,
            XR_BODY_JOINT_LEFT_SHOULDER_BD = 16,
            XR_BODY_JOINT_RIGHT_SHOULDER_BD = 17,
            XR_BODY_JOINT_LEFT_ELBOW_BD = 18,
            XR_BODY_JOINT_RIGHT_ELBOW_BD = 19,
            XR_BODY_JOINT_LEFT_WRIST_BD = 20,
            XR_BODY_JOINT_RIGHT_WRIST_BD = 21,
            XR_BODY_JOINT_LEFT_HAND_BD = 22,
            XR_BODY_JOINT_RIGHT_HAND_BD = 23,
            XR_BODY_JOINT_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrBodyJointSetBD : uint
        {
            XR_BODY_JOINT_SET_BODY_WITHOUT_ARM_BD = 1,
            XR_BODY_JOINT_SET_FULL_BODY_JOINTS_BD = 2,
            XR_BODY_JOINT_SET_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemBodyTrackingPropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsBodyTracking;
        }

        public unsafe partial struct XrBodyTrackerCreateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrBodyJointSetBD jointSet;
        }

        public unsafe partial struct XrBodyJointsLocateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;
        }

        public partial struct XrBodyJointLocationBD
        {
            public ulong locationFlags;

            public XrPosef pose;
        }

        public unsafe partial struct XrBodyJointLocationsBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint allJointPosesTracked;
            public uint jointLocationCount;

            public XrBodyJointLocationBD* jointLocations;
        }

        public partial struct XrFaceTrackerBD
        {
        }
        public enum XrFacialSimulationModeBD : uint
        {
            XR_FACIAL_SIMULATION_MODE_DEFAULT_BD = 0,
            XR_FACIAL_SIMULATION_MODE_COMBINED_AUDIO_BD = 1,
            XR_FACIAL_SIMULATION_MODE_COMBINED_AUDIO_WITH_LIP_BD = 2,
            XR_FACIAL_SIMULATION_MODE_ONLY_AUDIO_WITH_LIP_BD = 3,
            XR_FACIAL_SIMULATION_MODE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrFaceExpressionBD : uint
        {
            XR_FACE_EXPRESSION_BROW_DROP_L_BD = 0,
            XR_FACE_EXPRESSION_BROW_DROP_R_BD = 1,
            XR_FACE_EXPRESSION_BROW_INNER_UPWARDS_BD = 2,
            XR_FACE_EXPRESSION_BROW_OUTER_UPWARDS_L_BD = 3,
            XR_FACE_EXPRESSION_BROW_OUTER_UPWARDS_R_BD = 4,
            XR_FACE_EXPRESSION_EYE_BLINK_L_BD = 5,
            XR_FACE_EXPRESSION_EYE_LOOK_DROP_L_BD = 6,
            XR_FACE_EXPRESSION_EYE_LOOK_IN_L_BD = 7,
            XR_FACE_EXPRESSION_EYE_LOOK_OUT_L_BD = 8,
            XR_FACE_EXPRESSION_EYE_LOOK_UPWARDS_L_BD = 9,
            XR_FACE_EXPRESSION_EYE_LOOK_SQUINT_L_BD = 10,
            XR_FACE_EXPRESSION_EYE_LOOK_WIDE_L_BD = 11,
            XR_FACE_EXPRESSION_EYE_BLINK_R_BD = 12,
            XR_FACE_EXPRESSION_EYE_LOOK_DROP_R_BD = 13,
            XR_FACE_EXPRESSION_EYE_LOOK_IN_R_BD = 14,
            XR_FACE_EXPRESSION_EYE_LOOK_OUT_R_BD = 15,
            XR_FACE_EXPRESSION_EYE_LOOK_UPWARDS_R_BD = 16,
            XR_FACE_EXPRESSION_EYE_LOOK_SQUINT_R_BD = 17,
            XR_FACE_EXPRESSION_EYE_LOOK_WIDE_R_BD = 18,
            XR_FACE_EXPRESSION_NOSE_SNEER_L_BD = 19,
            XR_FACE_EXPRESSION_NOSE_SNEER_R_BD = 20,
            XR_FACE_EXPRESSION_CHEEK_PUFF_BD = 21,
            XR_FACE_EXPRESSION_CHEEK_SQUINT_L_BD = 22,
            XR_FACE_EXPRESSION_CHEEK_SQUINT_R_BD = 23,
            XR_FACE_EXPRESSION_MOUTH_CLOSE_BD = 24,
            XR_FACE_EXPRESSION_MOUTH_FUNNEL_BD = 25,
            XR_FACE_EXPRESSION_MOUTH_PUCKER_BD = 26,
            XR_FACE_EXPRESSION_MOUTH_L_BD = 27,
            XR_FACE_EXPRESSION_MOUTH_R_BD = 28,
            XR_FACE_EXPRESSION_MOUTH_SMILE_L_BD = 29,
            XR_FACE_EXPRESSION_MOUTH_SMILE_R_BD = 30,
            XR_FACE_EXPRESSION_MOUTH_FROWN_L_BD = 31,
            XR_FACE_EXPRESSION_MOUTH_FROWN_R_BD = 32,
            XR_FACE_EXPRESSION_MOUTH_DIMPLE_L_BD = 33,
            XR_FACE_EXPRESSION_MOUTH_DIMPLE_R_BD = 34,
            XR_FACE_EXPRESSION_MOUTH_STRETCH_L_BD = 35,
            XR_FACE_EXPRESSION_MOUTH_STRETCH_R_BD = 36,
            XR_FACE_EXPRESSION_MOUTH_ROLL_LOWER_BD = 37,
            XR_FACE_EXPRESSION_MOUTH_ROLL_UPPER_BD = 38,
            XR_FACE_EXPRESSION_MOUTH_SHRUG_LOWER_BD = 39,
            XR_FACE_EXPRESSION_MOUTH_SHRUG_UPPER_BD = 40,
            XR_FACE_EXPRESSION_MOUTH_PRESS_L_BD = 41,
            XR_FACE_EXPRESSION_MOUTH_PRESS_R_BD = 42,
            XR_FACE_EXPRESSION_MOUTH_LOWER_DROP_L_BD = 43,
            XR_FACE_EXPRESSION_MOUTH_LOWER_DROP_R_BD = 44,
            XR_FACE_EXPRESSION_MOUTH_UPPER_UPWARDS_L_BD = 45,
            XR_FACE_EXPRESSION_MOUTH_UPPER_UPWARDS_R_BD = 46,
            XR_FACE_EXPRESSION_JAW_FORWARD_BD = 47,
            XR_FACE_EXPRESSION_JAW_L_BD = 48,
            XR_FACE_EXPRESSION_JAW_R_BD = 49,
            XR_FACE_EXPRESSION_JAW_OPEN_BD = 50,
            XR_FACE_EXPRESSION_TONGUE_OUT_BD = 51,
            XR_FACE_EXPRESSION_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrLipExpressionBD : uint
        {
            XR_LIP_EXPRESSION_PP_BD = 0,
            XR_LIP_EXPRESSION_CH_BD = 1,
            XR_LIP_EXPRESSION_LO_BD = 2,
            XR_LIP_EXPRESSION_O_BD = 3,
            XR_LIP_EXPRESSION_I_BD = 4,
            XR_LIP_EXPRESSION_LU_BD = 5,
            XR_LIP_EXPRESSION_RR_BD = 6,
            XR_LIP_EXPRESSION_XX_BD = 7,
            XR_LIP_EXPRESSION_LAA_BD = 8,
            XR_LIP_EXPRESSION_LI_BD = 9,
            XR_LIP_EXPRESSION_FF_BD = 10,
            XR_LIP_EXPRESSION_U_BD = 11,
            XR_LIP_EXPRESSION_TH_BD = 12,
            XR_LIP_EXPRESSION_LKK_BD = 13,
            XR_LIP_EXPRESSION_SS_BD = 14,
            XR_LIP_EXPRESSION_LE_BD = 15,
            XR_LIP_EXPRESSION_DD_BD = 16,
            XR_LIP_EXPRESSION_E_BD = 17,
            XR_LIP_EXPRESSION_LNN_BD = 18,
            XR_LIP_EXPRESSION_SIL_BD = 19,
            XR_LIP_EXPRESSION_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemFacialSimulationPropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsFaceTracking;
        }

        public unsafe partial struct XrFaceTrackerCreateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrFacialSimulationModeBD mode;
        }

        public unsafe partial struct XrFacialSimulationDataGetInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public long time;
        }

        public unsafe partial struct XrFacialSimulationDataBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint faceExpressionWeightCount;

            public float* faceExpressionWeights;
            public uint isUpperFaceDataValid;
            public uint isLowerFaceDataValid;
            public long time;
        }

        public unsafe partial struct XrLipExpressionDataBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint lipsyncExpressionWeightCount;

            public float* lipsyncExpressionWeights;
        }

        public partial struct XrSenseDataProviderBD
        {
        }

        public partial struct XrSenseDataSnapshotBD
        {
        }

        public partial struct XrAnchorBD
        {
        }
        public enum XrSpatialEntityComponentTypeBD : uint
        {
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_LOCATION_BD = 0,
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_SEMANTIC_BD = 1,
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_BOUNDING_BOX_2D_BD = 2,
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_POLYGON_BD = 3,
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_BOUNDING_BOX_3D_BD = 4,
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_TRIANGLE_MESH_BD = 5,
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_SPHERE_BD = 6,
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_PLANE_ORIENTATION_BD = 1000396000,
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_LIGHT_ESTIMATION_BD = 1000397000,
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_DYNAMIC_OBJECT_BD = 1000746000,
            XR_SPATIAL_ENTITY_COMPONENT_TYPE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrSemanticLabelBD : uint
        {
            XR_SEMANTIC_LABEL_UNKNOWN_BD = 0,
            XR_SEMANTIC_LABEL_FLOOR_BD = 1,
            XR_SEMANTIC_LABEL_CEILING_BD = 2,
            XR_SEMANTIC_LABEL_WALL_BD = 3,
            XR_SEMANTIC_LABEL_DOOR_BD = 4,
            XR_SEMANTIC_LABEL_WINDOW_BD = 5,
            XR_SEMANTIC_LABEL_OPENING_BD = 6,
            XR_SEMANTIC_LABEL_TABLE_BD = 7,
            XR_SEMANTIC_LABEL_SOFA_BD = 8,
            XR_SEMANTIC_LABEL_CHAIR_BD = 9,
            XR_SEMANTIC_LABEL_HUMAN_BD = 10,
            XR_SEMANTIC_LABEL_BEAM_BD = 11,
            XR_SEMANTIC_LABEL_COLUMN_BD = 12,
            XR_SEMANTIC_LABEL_CURTAIN_BD = 13,
            XR_SEMANTIC_LABEL_CABINET_BD = 14,
            XR_SEMANTIC_LABEL_BED_BD = 15,
            XR_SEMANTIC_LABEL_PLANT_BD = 16,
            XR_SEMANTIC_LABEL_SCREEN_BD = 17,
            XR_SEMANTIC_LABEL_VIRTUAL_WALL_BD = 18,
            XR_SEMANTIC_LABEL_REFRIGERATOR_BD = 19,
            XR_SEMANTIC_LABEL_WASHING_MACHINE_BD = 20,
            XR_SEMANTIC_LABEL_AIR_CONDITIONER_BD = 21,
            XR_SEMANTIC_LABEL_LAMP_BD = 22,
            XR_SEMANTIC_LABEL_WALL_ART_BD = 23,
            XR_SEMANTIC_LABEL_STAIRWAY_BD = 24,
            XR_SEMANTIC_LABEL_KEYBOARD_BD = 25,
            XR_SEMANTIC_LABEL_MOUSE_BD = 26,
            XR_SEMANTIC_LABEL_LAPTOP_BD = 27,
            XR_SEMANTIC_LABEL_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrSenseDataProviderTypeBD : uint
        {
            XR_SENSE_DATA_PROVIDER_TYPE_ANCHOR_BD = 1000390000,
            XR_SENSE_DATA_PROVIDER_TYPE_SCENE_BD = 1000392000,
            XR_SENSE_DATA_PROVIDER_TYPE_MESH_BD = 1000393000,
            XR_SENSE_DATA_PROVIDER_TYPE_PLANE_BD = 1000396000,
            XR_SENSE_DATA_PROVIDER_TYPE_LIGHT_ESTIMATION_BD = 1000397000,
            XR_SENSE_DATA_PROVIDER_TYPE_DYNAMIC_OBJECT_BD = 1000746000,
            XR_SENSE_DATA_PROVIDER_TYPE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrSenseDataProviderStateBD : uint
        {
            XR_SENSE_DATA_PROVIDER_STATE_INITIALIZED_BD = 0,
            XR_SENSE_DATA_PROVIDER_STATE_RUNNING_BD = 1,
            XR_SENSE_DATA_PROVIDER_STATE_STOPPED_BD = 2,
            XR_SENSE_DATA_PROVIDER_STATE_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemSpatialSensingPropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsSpatialSensing;
        }

        public unsafe partial struct XrSpatialEntityComponentGetInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong entityId;

            public XrSpatialEntityComponentTypeBD componentType;
        }

        public unsafe partial struct XrSpatialEntityComponentDataBaseHeaderBD
        {
            public Types.XrStructureType type;

            public void* next;
        }

        public unsafe partial struct XrSpatialEntityLocationGetInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
        }

        public unsafe partial struct XrSpatialEntityComponentDataLocationBD
        {
            public Types.XrStructureType type;

            public void* next;

            public XrSpaceLocation location;
        }

        public unsafe partial struct XrSpatialEntityComponentDataSemanticBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint labelCapacityInput;
            public uint labelCountOutput;

            public XrSemanticLabelBD* labels;
        }

        public unsafe partial struct XrSpatialEntityComponentDataBoundingBox2DBD
        {
            public Types.XrStructureType type;

            public void* next;

            public XrRect2Df boundingBox2D;
        }

        public unsafe partial struct XrSpatialEntityComponentDataPolygonBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrVector2f* vertices;
        }

        public unsafe partial struct XrSpatialEntityComponentDataBoundingBox3DBD
        {
            public Types.XrStructureType type;

            public void* next;

            public XrBoxf boundingBox3D;
        }

        public unsafe partial struct XrSpatialEntityComponentDataTriangleMeshBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrVector3f* vertices;
            public uint indexCapacityInput;
            public uint indexCountOutput;
            public ushort* indices;
        }

        public unsafe partial struct XrSpatialEntityComponentDataSphereBD
        {
            public Types.XrStructureType type;

            public void* next;

            public XrSpheref sphere;
        }

        public unsafe partial struct XrSenseDataProviderCreateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSenseDataProviderTypeBD providerType;
        }

        public unsafe partial struct XrSenseDataProviderStartInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrEventDataSenseDataProviderStateChangedBD
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSenseDataProviderBD* provider;

            public XrSenseDataProviderStateBD newState;
        }

        public unsafe partial struct XrEventDataSenseDataUpdatedBD
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSenseDataProviderBD* provider;
        }

        public unsafe partial struct XrSenseDataQueryInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSenseDataQueryCompletionBD
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public XrSenseDataSnapshotBD* snapshot;
        }

        public unsafe partial struct XrQueriedSenseDataGetInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpatialEntityStateBD
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong entityId;
            public long lastUpdateTime;
            public XrUuid uuid;
        }

        public unsafe partial struct XrQueriedSenseDataBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint stateCapacityInput;
            public uint stateCountOutput;

            public XrSpatialEntityStateBD* states;
        }

        public unsafe partial struct XrSenseDataFilterUuidBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint uuidCount;
            public XrUuid* uuids;
        }

        public unsafe partial struct XrSenseDataFilterSemanticBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint labelCount;
            public XrSemanticLabelBD* labels;
        }

        public unsafe partial struct XrSpatialEntityAnchorCreateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSenseDataSnapshotBD* snapshot;
            public ulong entityId;
        }

        public unsafe partial struct XrAnchorSpaceCreateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public XrAnchorBD* anchor;

            public XrPosef poseInAnchorSpace;
        }

        public unsafe partial struct XrFutureCompletionEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
        }
        public enum XrPersistenceLocationBD : uint
        {
            XR_PERSISTENCE_LOCATION_LOCAL_BD = 0,
            XR_PERSISTENCE_LOCATION_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemSpatialAnchorPropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsSpatialAnchor;
        }

        public unsafe partial struct XrSpatialAnchorCreateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;

            public XrPosef pose;
            public long time;
        }

        public unsafe partial struct XrSpatialAnchorCreateCompletionBD
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public XrUuid uuid;
            public XrAnchorBD* anchor;
        }

        public unsafe partial struct XrSpatialAnchorPersistInfoBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrPersistenceLocationBD location;
            public XrAnchorBD* anchor;
        }

        public unsafe partial struct XrSpatialAnchorUnpersistInfoBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrPersistenceLocationBD location;
            public XrAnchorBD* anchor;
        }

        public unsafe partial struct XrSystemSpatialAnchorSharingPropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsSpatialAnchorSharing;
        }

        public unsafe partial struct XrSpatialAnchorShareInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public XrAnchorBD* anchor;
        }

        public unsafe partial struct XrSharedSpatialAnchorDownloadInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public XrUuid uuid;
        }

        public unsafe partial struct XrSystemSpatialScenePropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsSpatialScene;
        }

        public unsafe partial struct XrSceneCaptureInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
        }
        public enum XrSpatialMeshLodBD : uint
        {
            XR_SPATIAL_MESH_LOD_COARSE_BD = 0,
            XR_SPATIAL_MESH_LOD_MEDIUM_BD = 1,
            XR_SPATIAL_MESH_LOD_FINE_BD = 2,
            XR_SPATIAL_MESH_LOD_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemSpatialMeshPropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsSpatialMesh;
        }

        public unsafe partial struct XrSenseDataProviderCreateInfoSpatialMeshBD
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong configFlags;

            public XrSpatialMeshLodBD lod;
        }

        public unsafe partial struct XrFuturePollResultProgressBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint isSupported;
            public uint progressPercentage;
        }
        public enum XrBodyTrackingPostureBD : uint
        {
            XR_BODY_TRACKING_POSTURE_STOMP_BD = 1,
            XR_BODY_TRACKING_POSTURE_STATIC_BD = 2,
            XR_BODY_TRACKING_POSTURE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrBodyTrackingStatusBD : uint
        {
            XR_BODY_TRACKING_STATUS_INVALID_BD = 0,
            XR_BODY_TRACKING_STATUS_VALID_BD = 1,
            XR_BODY_TRACKING_STATUS_LIMITED_BD = 2,
            XR_BODY_TRACKING_STATUS_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrBodyTrackingMessageBD : uint
        {
            XR_BODY_TRACKING_MESSAGE_NO_ERROR_BD = 0,
            XR_BODY_TRACKING_MESSAGE_TRACKER_NOT_CALIBRATED_BD = 1,
            XR_BODY_TRACKING_MESSAGE_TRACKER_NUM_NOT_ENOUGH_BD = 2,
            XR_BODY_TRACKING_MESSAGE_TRACKER_STATE_NOT_SATISFIED_BD = 3,
            XR_BODY_TRACKING_MESSAGE_TRACKER_PERSISTENT_INVISIBILITY_BD = 4,
            XR_BODY_TRACKING_MESSAGE_TRACKER_DATA_ERROR_BD = 5,
            XR_BODY_TRACKING_MESSAGE_USER_CHANGE_BD = 6,
            XR_BODY_TRACKING_MESSAGE_TRACKING_POSE_ERROR_BD = 7,
            XR_BODY_TRACKING_MESSAGE_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrBodyTrackingPostureDataBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint postureCount;

            public XrBodyTrackingPostureBD* postureData;
        }

        public partial struct XrBodyJointVelocityBD
        {
            public ulong velocityFlags;

            public XrVector3f linearVelocity;

            public XrVector3f angularVelocity;
        }

        public unsafe partial struct XrBodyJointVelocitiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint velocityCount;

            public XrBodyJointVelocityBD* velocities;
        }

        public partial struct XrBodyJointAccelerationBD
        {
            public ulong accelerationFlags;

            public XrVector3f linearAcceleration;

            public XrVector3f angularAcceleration;
        }

        public unsafe partial struct XrBodyJointAccelerationsBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint accelerationCount;

            public XrBodyJointAccelerationBD* accelerations;
        }

        public unsafe partial struct XrBodyTrackingStateBD
        {
            public Types.XrStructureType type;

            public void* next;

            public XrBodyTrackingStatusBD status;

            public XrBodyTrackingMessageBD message;
        }
        public enum XrPlaneOrientationBD : uint
        {
            XR_PLANE_ORIENTATION_HORIZONTAL_UPWARD_BD = 0,
            XR_PLANE_ORIENTATION_HORIZONTAL_DOWNWARD_BD = 1,
            XR_PLANE_ORIENTATION_VERTICAL_BD = 2,
            XR_PLANE_ORIENTATION_ARBITRARY_BD = 3,
            XR_PLANE_ORIENTATION_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemSpatialPlanePropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsSpatialPlane;
        }

        public unsafe partial struct XrSpatialEntityComponentDataPlaneOrientationBD
        {
            public Types.XrStructureType type;

            public void* next;

            public XrPlaneOrientationBD orientation;
        }

        public unsafe partial struct XrSenseDataFilterPlaneOrientationBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint orientationCount;

            public XrPlaneOrientationBD* orientations;
        }
        public enum XrEnvironmentTexturePixelFormatBD : uint
        {
            XR_ENVIRONMENT_TEXTURE_PIXEL_FORMAT_RGB_16FLOAT_BD = 0,
            XR_ENVIRONMENT_TEXTURE_PIXEL_FORMAT_RGBA_16FLOAT_BD = 1,
            XR_ENVIRONMENT_TEXTURE_PIXEL_FORMAT_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrEnvironmentTextureResolutionBD : uint
        {
            XR_ENVIRONMENT_TEXTURE_RESOLUTION_8_8_BD = 0,
            XR_ENVIRONMENT_TEXTURE_RESOLUTION_16_16_BD = 1,
            XR_ENVIRONMENT_TEXTURE_RESOLUTION_32_32_BD = 2,
            XR_ENVIRONMENT_TEXTURE_RESOLUTION_64_64_BD = 3,
            XR_ENVIRONMENT_TEXTURE_RESOLUTION_128_128_BD = 4,
            XR_ENVIRONMENT_TEXTURE_RESOLUTION_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrEnvironmentTextureTransferTypeBD : uint
        {
            XR_ENVIRONMENT_TEXTURE_TRANSFER_TYPE_RAW_BD = 0,
            XR_ENVIRONMENT_TEXTURE_TRANSFER_TYPE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrSphericalHarmonicsKindBD : uint
        {
            XR_SPHERICAL_HARMONICS_KIND_TOTAL_BD = 0,
            XR_SPHERICAL_HARMONICS_KIND_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemLightEstimationPropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsLightEstimation;
            public uint supportsEnvironmentTexture;
            public uint supportsSphericalHarmonics;
        }

        public unsafe partial struct XrSenseDataProviderCreateInfoLightEstimationBD
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong createFlags;
        }

        public unsafe partial struct XrEnvironmentTextureCreateConfigInfoBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrEnvironmentTexturePixelFormatBD pixelFormat;

            public XrEnvironmentTextureResolutionBD resolution;

            public XrEnvironmentTextureTransferTypeBD transferType;
        }

        public unsafe partial struct XrLightEstimationDataEnvironmentTextureRawBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrEnvironmentTexturePixelFormatBD pixelFormat;
            public uint cubemapFaceBufferSize;
            public byte* rightCubemapFaceBuffer;
            public byte* leftCubemapFaceBuffer;
            public byte* topCubemapFaceBuffer;
            public byte* bottomCubemapFaceBuffer;
            public byte* frontCubemapFaceBuffer;
            public byte* backCubemapFaceBuffer;
        }

        public unsafe partial struct XrLightEstimationDataSphericalHarmonicsBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSphericalHarmonicsKindBD kind;
            public uint coefficientCapacityInput;
            public uint coefficientCountOutput;

            public float* coefficients;
        }

        public unsafe partial struct XrSpatialEntityComponentDataLightEstimationBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint isValid;
        }

        public partial struct XrSpatialAudioRendererBD
        {
        }

        public partial struct XrSoundFieldBD
        {
        }

        public partial struct XrSoundObjectBD
        {
        }

        public partial struct XrSoundObstacleBD
        {
        }

        public partial struct XrSoundObstacleMaterialBD
        {
        }
        public enum XrAudioSampleRateBD : uint
        {
            XR_AUDIO_SAMPLE_RATE_192000_HZ_BD = 1,
            XR_AUDIO_SAMPLE_RATE_96000_HZ_BD = 2,
            XR_AUDIO_SAMPLE_RATE_48000_HZ_BD = 3,
            XR_AUDIO_SAMPLE_RATE_44100_HZ_BD = 4,
            XR_AUDIO_SAMPLE_RATE_32000_HZ_BD = 5,
            XR_AUDIO_SAMPLE_RATE_24000_HZ_BD = 6,
            XR_AUDIO_SAMPLE_RATE_22050_HZ_BD = 7,
            XR_AUDIO_SAMPLE_RATE_16000_HZ_BD = 8,
            XR_AUDIO_SAMPLE_RATE_12000_HZ_BD = 9,
            XR_AUDIO_SAMPLE_RATE_11025_HZ_BD = 10,
            XR_AUDIO_SAMPLE_RATE_8000_HZ_BD = 11,
            XR_AUDIO_SAMPLE_RATE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrAudioBufferChannelLayoutBD : uint
        {
            XR_AUDIO_BUFFER_CHANNEL_LAYOUT_INTERLEAVED_BD = 0,
            XR_AUDIO_BUFFER_CHANNEL_LAYOUT_PLANAR_BD = 1,
            XR_AUDIO_BUFFER_CHANNEL_LAYOUT_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrSoundObjectDistanceAttenuationTypeBD : uint
        {
            XR_SOUND_OBJECT_DISTANCE_ATTENUATION_TYPE_NONE_BD = 0,
            XR_SOUND_OBJECT_DISTANCE_ATTENUATION_TYPE_INVERSE_SQUARE_BD = 1,
            XR_SOUND_OBJECT_DISTANCE_ATTENUATION_TYPE_ROLLOFF_BD = 2,
            XR_SOUND_OBJECT_DISTANCE_ATTENUATION_TYPE_CUSTOMIZED_BD = 100,
            XR_SOUND_OBJECT_DISTANCE_ATTENUATION_TYPE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrSoundFieldChannelMaskSurroundBD : uint
        {
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_FRONT_LEFT_BD = 1,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_FRONT_RIGHT_BD = 2,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_FRONT_CENTER_BD = 4,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_LOW_FREQUENCY_BD = 8,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_BACK_LEFT_BD = 16,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_BACK_RIGHT_BD = 32,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SIDE_LEFT_BD = 64,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SIDE_RIGHT_BD = 128,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_TOP_FRONT_LEFT_BD = 256,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_TOP_FRONT_RIGHT_BD = 512,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_TOP_BACK_LEFT_BD = 1024,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_TOP_BACK_RIGHT_BD = 2048,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_BACK_CENTER_BD = 4096,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_TOP_SIDE_LEFT_BD = 8192,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_TOP_SIDE_RIGHT_BD = 16384,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_STEREO_BD = 3,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_2_1_BD = 11,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_3_0_BD = 7,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_4_0_BD = 4099,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_BACK_SURROUND_BD = 48,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_QUAD_BD = 51,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_3_1_BD = 15,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_5_0_BD = 55,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_SIDE_SURROUND_BD = 192,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_5_0_SIDE_BD = 199,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_5_1_BD = 63,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_5_1_SIDE_BD = 207,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_7_0_BD = 247,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_7_1_BD = 255,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_5_1_2_BD = 831,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_5_1_4_BD = 3903,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_7_1_2_BD = 24831,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_SETUP_7_1_4_BD = 4095,
            XR_SOUND_FIELD_CHANNEL_MASK_SURROUND_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrSoundFieldChannelMaskAmbixBD : uint
        {
            XR_SOUND_FIELD_CHANNEL_MASK_AMBIX_1ST_ORDER_BD = 1,
            XR_SOUND_FIELD_CHANNEL_MASK_AMBIX_2ND_ORDER_BD = 2,
            XR_SOUND_FIELD_CHANNEL_MASK_AMBIX_3RD_ORDER_BD = 3,
            XR_SOUND_FIELD_CHANNEL_MASK_AMBIX_4TH_ORDER_BD = 4,
            XR_SOUND_FIELD_CHANNEL_MASK_AMBIX_5TH_ORDER_BD = 5,
            XR_SOUND_FIELD_CHANNEL_MASK_AMBIX_6TH_ORDER_BD = 6,
            XR_SOUND_FIELD_CHANNEL_MASK_AMBIX_7TH_ORDER_BD = 7,
            XR_SOUND_FIELD_CHANNEL_MASK_AMBIX_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrSoundFieldChannelMaskFumaBD : uint
        {
            XR_SOUND_FIELD_CHANNEL_MASK_FUMA_1ST_ORDER_BD = 1,
            XR_SOUND_FIELD_CHANNEL_MASK_FUMA_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrSoundObstacleMaterialTypeBD : uint
        {
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_ACOUSTIC_TILE_BD = 0,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_BRICK_BD = 1,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_BRICK_PAINTED_BD = 2,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_CARPET_BD = 3,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_CARPET_HEAVY_BD = 4,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_CARPET_HEAVY_PADDED_BD = 5,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_CERAMIC_TILE_BD = 6,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_CONCRETE_BD = 7,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_CONCRETE_ROUGH_BD = 8,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_CONCRETE_BLOCK_BD = 9,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_CONCRETE_BLOCK_PAINTED_BD = 10,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_CURTAIN_BD = 11,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_FOLIAGE_BD = 12,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_GLASS_BD = 13,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_GLASS_HEAVY_BD = 14,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_GRASS_BD = 15,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_GRAVEL_BD = 16,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_GYPSUM_BOARD_BD = 17,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_PLASTER_ON_BRICK_BD = 18,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_PLASTER_ON_CONCRETE_BLOCK_BD = 19,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_SOIL_BD = 20,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_SOUND_PROOF_BD = 21,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_SNOW_BD = 22,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_STEEL_BD = 23,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_WATER_BD = 24,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_WOOD_THIN_BD = 25,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_WOOD_THICK_BD = 26,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_WOOD_FLOOR_BD = 27,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_WOOD_ON_CONCRETE_BD = 28,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_CUSTOM_BD = 29,
            XR_SOUND_OBSTACLE_MATERIAL_TYPE_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpatialAudioRendererCreateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint framesPerBuffer;

            public XrAudioSampleRateBD sampleRate;
        }

        public unsafe partial struct XrAudioBufferBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrAudioBufferChannelLayoutBD channelLayout;
            public uint bufferChannels;
            public uint bufferLength;

            public float* buffer;
        }

        public unsafe partial struct XrSoundObjectDirectivityCardioidBD
        {
            public Types.XrStructureType type;
            public void* next;

            public float alpha;

            public float order;
        }

        public unsafe partial struct XrSoundObjectShapeSphereBD
        {
            public Types.XrStructureType type;
            public void* next;

            public float radius;
        }

        public partial struct XrAttenuationCurvePointBD
        {
            public float distance;

            public float gain;
        }

        public unsafe partial struct XrSoundObjectDistanceAttenuationCurveBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint curvePointCount;

            public XrAttenuationCurvePointBD* curvePoints;
        }

        public unsafe partial struct XrSoundObjectDistanceAttenuationBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSoundObjectDistanceAttenuationTypeBD distanceAttenuationType;

            public float minAttenuationRange;

            public float maxAttenuationRange;

            public float referenceDistance;

            public float rolloffFactor;

            public XrSoundObjectDistanceAttenuationCurveBD* customDistanceAttenuationCurve;
        }

        public unsafe partial struct XrSoundObjectConfigBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint enabled;

            public XrPosef pose;
            public IntPtr baseSpace;

            public float mainVolume;

            public float reflectionGain;
            public uint enableDoppler;
            public XrSoundObjectDistanceAttenuationBD* directSoundAttenuation;
            public XrSoundObjectDistanceAttenuationBD* indirectSoundAttenuation;
        }

        public unsafe partial struct XrSoundFieldConfigBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint enabled;

            public XrQuaternionf orientation;
            public IntPtr baseSpace;

            public float mainVolume;

            public float lfeGain;
        }

        public unsafe partial struct XrSoundFieldChannelDefinitionSurroundBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSoundFieldChannelMaskSurroundBD channelMask;
        }

        public unsafe partial struct XrSoundFieldChannelDefinitionAmbixBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSoundFieldChannelMaskAmbixBD channelMask;
        }

        public unsafe partial struct XrSoundFieldChannelDefinitionFumaBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSoundFieldChannelMaskFumaBD channelMask;
        }

        public unsafe partial struct XrSoundTriangleMeshBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint vertexCount;

            public XrVector3f* vertices;
            public uint indexCount;
            public uint* indices;
        }

        public unsafe partial struct XrSoundObstacleConfigBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint enabled;

            public XrPosef pose;
            public IntPtr baseSpace;
            public uint materialCount;
            public XrSoundObstacleMaterialBD** materials;
        }

        public unsafe partial struct XrSoundObstacleMaterialConfigBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSoundObstacleMaterialTypeBD materialType;
            public uint bandCount;

            public float* bandFrequencies;

            public float* bandAbsorptions;

            public float* bandScatterings;

            public float* bandTransmissions;
        }
        public enum XrHandTrackingDataSourceEXT : uint
        {
            XR_HAND_TRACKING_DATA_SOURCE_UNOBSTRUCTED_EXT = 1,
            XR_HAND_TRACKING_DATA_SOURCE_CONTROLLER_EXT = 2,
            XR_HAND_TRACKING_DATA_SOURCE_UNOBSTRUCTED_WIDE_MOTION_META = 1000695000,
            XR_HAND_TRACKING_DATA_SOURCE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrHandTrackingDataSourceInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint requestedDataSourceCount;

            public XrHandTrackingDataSourceEXT* requestedDataSources;
        }

        public unsafe partial struct XrHandTrackingDataSourceStateEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint isActive;

            public XrHandTrackingDataSourceEXT dataSource;
        }

        public partial struct XrPlaneDetectorEXT
        {
        }
        public enum XrPlaneDetectorOrientationEXT : uint
        {
            XR_PLANE_DETECTOR_ORIENTATION_HORIZONTAL_UPWARD_EXT = 0,
            XR_PLANE_DETECTOR_ORIENTATION_HORIZONTAL_DOWNWARD_EXT = 1,
            XR_PLANE_DETECTOR_ORIENTATION_VERTICAL_EXT = 2,
            XR_PLANE_DETECTOR_ORIENTATION_ARBITRARY_EXT = 3,
            XR_PLANE_DETECTOR_ORIENTATION_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrPlaneDetectorSemanticTypeEXT : uint
        {
            XR_PLANE_DETECTOR_SEMANTIC_TYPE_UNDEFINED_EXT = 0,
            XR_PLANE_DETECTOR_SEMANTIC_TYPE_CEILING_EXT = 1,
            XR_PLANE_DETECTOR_SEMANTIC_TYPE_FLOOR_EXT = 2,
            XR_PLANE_DETECTOR_SEMANTIC_TYPE_WALL_EXT = 3,
            XR_PLANE_DETECTOR_SEMANTIC_TYPE_PLATFORM_EXT = 4,
            XR_PLANE_DETECTOR_SEMANTIC_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrPlaneDetectionStateEXT : uint
        {
            XR_PLANE_DETECTION_STATE_NONE_EXT = 0,
            XR_PLANE_DETECTION_STATE_PENDING_EXT = 1,
            XR_PLANE_DETECTION_STATE_DONE_EXT = 2,
            XR_PLANE_DETECTION_STATE_ERROR_EXT = 3,
            XR_PLANE_DETECTION_STATE_FATAL_EXT = 4,
            XR_PLANE_DETECTION_STATE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemPlaneDetectionPropertiesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong supportedFeatures;
        }

        public unsafe partial struct XrPlaneDetectorCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;
        }

        public unsafe partial struct XrPlaneDetectorBeginInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;
            public uint orientationCount;
            public XrPlaneDetectorOrientationEXT* orientations;
            public uint semanticTypeCount;
            public XrPlaneDetectorSemanticTypeEXT* semanticTypes;
            public uint maxPlanes;

            public float minArea;

            public XrPosef boundingBoxPose;
            public XrExtent3Df boundingBoxExtent;
        }

        public unsafe partial struct XrPlaneDetectorGetInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;
        }

        public unsafe partial struct XrPlaneDetectorLocationEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong planeId;
            public ulong locationFlags;

            public XrPosef pose;

            public XrExtent2Df extents;

            public XrPlaneDetectorOrientationEXT orientation;

            public XrPlaneDetectorSemanticTypeEXT semanticType;
            public uint polygonBufferCount;
        }

        public unsafe partial struct XrPlaneDetectorLocationsEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint planeLocationCapacityInput;
            public uint planeLocationCountOutput;

            public XrPlaneDetectorLocationEXT* planeLocations;
        }

        public unsafe partial struct XrPlaneDetectorPolygonBufferEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrVector2f* vertices;
        }

        public partial struct XrTrackableTrackerANDROID
        {
        }
        public enum XrTrackingStateANDROID : uint
        {
            XR_TRACKING_STATE_PAUSED_ANDROID = 0,
            XR_TRACKING_STATE_STOPPED_ANDROID = 1,
            XR_TRACKING_STATE_TRACKING_ANDROID = 2,
            XR_TRACKING_STATE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrTrackableTypeANDROID : uint
        {
            XR_TRACKABLE_TYPE_NOT_VALID_ANDROID = 0,
            XR_TRACKABLE_TYPE_PLANE_ANDROID = 1,
            XR_TRACKABLE_TYPE_DEPTH_ANDROID = 1000463000,
            XR_TRACKABLE_TYPE_OBJECT_ANDROID = 1000466000,
            XR_TRACKABLE_TYPE_MARKER_ANDROID = 1000707000,
            XR_TRACKABLE_TYPE_QR_CODE_ANDROID = 1000708000,
            XR_TRACKABLE_TYPE_IMAGE_ANDROID = 1000709000,
            XR_TRACKABLE_TYPE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrPlaneTypeANDROID : uint
        {
            XR_PLANE_TYPE_HORIZONTAL_DOWNWARD_FACING_ANDROID = 0,
            XR_PLANE_TYPE_HORIZONTAL_UPWARD_FACING_ANDROID = 1,
            XR_PLANE_TYPE_VERTICAL_ANDROID = 2,
            XR_PLANE_TYPE_ARBITRARY_ANDROID = 3,
            XR_PLANE_TYPE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrPlaneLabelANDROID : uint
        {
            XR_PLANE_LABEL_UNKNOWN_ANDROID = 0,
            XR_PLANE_LABEL_WALL_ANDROID = 1,
            XR_PLANE_LABEL_FLOOR_ANDROID = 2,
            XR_PLANE_LABEL_CEILING_ANDROID = 3,
            XR_PLANE_LABEL_TABLE_ANDROID = 4,
            XR_PLANE_LABEL_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrTrackableTrackerCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;

            public XrTrackableTypeANDROID trackableType;
        }

        public unsafe partial struct XrTrackableGetInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong trackable;
            public IntPtr baseSpace;
            public long time;
        }

        public unsafe partial struct XrTrackablePlaneANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrTrackingStateANDROID trackingState;

            public XrPosef centerPose;

            public XrExtent2Df extents;

            public XrPlaneTypeANDROID planeType;

            public XrPlaneLabelANDROID planeLabel;
            public ulong subsumedByPlane;
            public long lastUpdatedTime;
            public uint vertexCapacityInput;
            public uint* vertexCountOutput;

            public XrVector2f* vertices;
        }

        public unsafe partial struct XrAnchorSpaceCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;
            public long time;

            public XrPosef pose;
            public ulong trackable;
        }

        public unsafe partial struct XrSystemTrackablesPropertiesANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public uint supportsAnchor;
            public uint maxAnchors;
        }

        public partial struct XrEyeTrackerANDROID
        {
        }
        public enum XrEyeIndexANDROID : uint
        {
            XR_EYE_INDEX_LEFT_ANDROID = 0,
            XR_EYE_INDEX_RIGHT_ANDROID = 1,
            XR_EYE_INDEX_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrEyeStateANDROID : uint
        {
            XR_EYE_STATE_INVALID_ANDROID = 0,
            XR_EYE_STATE_GAZING_ANDROID = 1,
            XR_EYE_STATE_SHUT_ANDROID = 2,
            XR_EYE_STATE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrEyeTrackingModeANDROID : uint
        {
            XR_EYE_TRACKING_MODE_NOT_TRACKING_ANDROID = 0,
            XR_EYE_TRACKING_MODE_RIGHT_ANDROID = 1,
            XR_EYE_TRACKING_MODE_LEFT_ANDROID = 2,
            XR_EYE_TRACKING_MODE_BOTH_ANDROID = 3,
            XR_EYE_TRACKING_MODE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemEyeTrackingPropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsEyeTracking;
        }

        public partial struct XrEyeANDROID
        {
            public XrEyeStateANDROID eyeState;

            public XrPosef eyePose;
        }

        public unsafe partial struct XrEyesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public _eyes_e__FixedBuffer eyes;

            public XrEyeTrackingModeANDROID mode;

            [InlineArray(2)]
            public partial struct _eyes_e__FixedBuffer
            {
                public XrEyeANDROID e0;
            }
        }

        public unsafe partial struct XrEyesGetInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public long time;
            public IntPtr baseSpace;
        }

        public unsafe partial struct XrEyeTrackerCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public partial struct XrDeviceAnchorPersistenceANDROID
        {
        }
        public enum XrAnchorPersistStateANDROID : uint
        {
            XR_ANCHOR_PERSIST_STATE_PERSIST_NOT_REQUESTED_ANDROID = 0,
            XR_ANCHOR_PERSIST_STATE_PERSIST_PENDING_ANDROID = 1,
            XR_ANCHOR_PERSIST_STATE_PERSISTED_ANDROID = 2,
            XR_ANCHOR_PERSIST_STATE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrDeviceAnchorPersistenceCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrPersistedAnchorSpaceCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public XrUuid anchorId;
        }

        public unsafe partial struct XrPersistedAnchorSpaceInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr anchor;
        }

        public unsafe partial struct XrSystemDeviceAnchorPersistencePropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsAnchorPersistence;
        }

        public partial struct XrFaceTrackerANDROID
        {
        }
        public enum XrFaceParameterIndicesANDROID : uint
        {
            XR_FACE_PARAMETER_INDICES_BROW_LOWERER_L_ANDROID = 0,
            XR_FACE_PARAMETER_INDICES_BROW_LOWERER_R_ANDROID = 1,
            XR_FACE_PARAMETER_INDICES_CHEEK_PUFF_L_ANDROID = 2,
            XR_FACE_PARAMETER_INDICES_CHEEK_PUFF_R_ANDROID = 3,
            XR_FACE_PARAMETER_INDICES_CHEEK_RAISER_L_ANDROID = 4,
            XR_FACE_PARAMETER_INDICES_CHEEK_RAISER_R_ANDROID = 5,
            XR_FACE_PARAMETER_INDICES_CHEEK_SUCK_L_ANDROID = 6,
            XR_FACE_PARAMETER_INDICES_CHEEK_SUCK_R_ANDROID = 7,
            XR_FACE_PARAMETER_INDICES_CHIN_RAISER_B_ANDROID = 8,
            XR_FACE_PARAMETER_INDICES_CHIN_RAISER_T_ANDROID = 9,
            XR_FACE_PARAMETER_INDICES_DIMPLER_L_ANDROID = 10,
            XR_FACE_PARAMETER_INDICES_DIMPLER_R_ANDROID = 11,
            XR_FACE_PARAMETER_INDICES_EYES_CLOSED_L_ANDROID = 12,
            XR_FACE_PARAMETER_INDICES_EYES_CLOSED_R_ANDROID = 13,
            XR_FACE_PARAMETER_INDICES_EYES_LOOK_DOWN_L_ANDROID = 14,
            XR_FACE_PARAMETER_INDICES_EYES_LOOK_DOWN_R_ANDROID = 15,
            XR_FACE_PARAMETER_INDICES_EYES_LOOK_LEFT_L_ANDROID = 16,
            XR_FACE_PARAMETER_INDICES_EYES_LOOK_LEFT_R_ANDROID = 17,
            XR_FACE_PARAMETER_INDICES_EYES_LOOK_RIGHT_L_ANDROID = 18,
            XR_FACE_PARAMETER_INDICES_EYES_LOOK_RIGHT_R_ANDROID = 19,
            XR_FACE_PARAMETER_INDICES_EYES_LOOK_UP_L_ANDROID = 20,
            XR_FACE_PARAMETER_INDICES_EYES_LOOK_UP_R_ANDROID = 21,
            XR_FACE_PARAMETER_INDICES_INNER_BROW_RAISER_L_ANDROID = 22,
            XR_FACE_PARAMETER_INDICES_INNER_BROW_RAISER_R_ANDROID = 23,
            XR_FACE_PARAMETER_INDICES_JAW_DROP_ANDROID = 24,
            XR_FACE_PARAMETER_INDICES_JAW_SIDEWAYS_LEFT_ANDROID = 25,
            XR_FACE_PARAMETER_INDICES_JAW_SIDEWAYS_RIGHT_ANDROID = 26,
            XR_FACE_PARAMETER_INDICES_JAW_THRUST_ANDROID = 27,
            XR_FACE_PARAMETER_INDICES_LID_TIGHTENER_L_ANDROID = 28,
            XR_FACE_PARAMETER_INDICES_LID_TIGHTENER_R_ANDROID = 29,
            XR_FACE_PARAMETER_INDICES_LIP_CORNER_DEPRESSOR_L_ANDROID = 30,
            XR_FACE_PARAMETER_INDICES_LIP_CORNER_DEPRESSOR_R_ANDROID = 31,
            XR_FACE_PARAMETER_INDICES_LIP_CORNER_PULLER_L_ANDROID = 32,
            XR_FACE_PARAMETER_INDICES_LIP_CORNER_PULLER_R_ANDROID = 33,
            XR_FACE_PARAMETER_INDICES_LIP_FUNNELER_LB_ANDROID = 34,
            XR_FACE_PARAMETER_INDICES_LIP_FUNNELER_LT_ANDROID = 35,
            XR_FACE_PARAMETER_INDICES_LIP_FUNNELER_RB_ANDROID = 36,
            XR_FACE_PARAMETER_INDICES_LIP_FUNNELER_RT_ANDROID = 37,
            XR_FACE_PARAMETER_INDICES_LIP_PRESSOR_L_ANDROID = 38,
            XR_FACE_PARAMETER_INDICES_LIP_PRESSOR_R_ANDROID = 39,
            XR_FACE_PARAMETER_INDICES_LIP_PUCKER_L_ANDROID = 40,
            XR_FACE_PARAMETER_INDICES_LIP_PUCKER_R_ANDROID = 41,
            XR_FACE_PARAMETER_INDICES_LIP_STRETCHER_L_ANDROID = 42,
            XR_FACE_PARAMETER_INDICES_LIP_STRETCHER_R_ANDROID = 43,
            XR_FACE_PARAMETER_INDICES_LIP_SUCK_LB_ANDROID = 44,
            XR_FACE_PARAMETER_INDICES_LIP_SUCK_LT_ANDROID = 45,
            XR_FACE_PARAMETER_INDICES_LIP_SUCK_RB_ANDROID = 46,
            XR_FACE_PARAMETER_INDICES_LIP_SUCK_RT_ANDROID = 47,
            XR_FACE_PARAMETER_INDICES_LIP_TIGHTENER_L_ANDROID = 48,
            XR_FACE_PARAMETER_INDICES_LIP_TIGHTENER_R_ANDROID = 49,
            XR_FACE_PARAMETER_INDICES_LIPS_TOWARD_ANDROID = 50,
            XR_FACE_PARAMETER_INDICES_LOWER_LIP_DEPRESSOR_L_ANDROID = 51,
            XR_FACE_PARAMETER_INDICES_LOWER_LIP_DEPRESSOR_R_ANDROID = 52,
            XR_FACE_PARAMETER_INDICES_MOUTH_LEFT_ANDROID = 53,
            XR_FACE_PARAMETER_INDICES_MOUTH_RIGHT_ANDROID = 54,
            XR_FACE_PARAMETER_INDICES_NOSE_WRINKLER_L_ANDROID = 55,
            XR_FACE_PARAMETER_INDICES_NOSE_WRINKLER_R_ANDROID = 56,
            XR_FACE_PARAMETER_INDICES_OUTER_BROW_RAISER_L_ANDROID = 57,
            XR_FACE_PARAMETER_INDICES_OUTER_BROW_RAISER_R_ANDROID = 58,
            XR_FACE_PARAMETER_INDICES_UPPER_LID_RAISER_L_ANDROID = 59,
            XR_FACE_PARAMETER_INDICES_UPPER_LID_RAISER_R_ANDROID = 60,
            XR_FACE_PARAMETER_INDICES_UPPER_LIP_RAISER_L_ANDROID = 61,
            XR_FACE_PARAMETER_INDICES_UPPER_LIP_RAISER_R_ANDROID = 62,
            XR_FACE_PARAMETER_INDICES_TONGUE_OUT_ANDROID = 63,
            XR_FACE_PARAMETER_INDICES_TONGUE_LEFT_ANDROID = 64,
            XR_FACE_PARAMETER_INDICES_TONGUE_RIGHT_ANDROID = 65,
            XR_FACE_PARAMETER_INDICES_TONGUE_UP_ANDROID = 66,
            XR_FACE_PARAMETER_INDICES_TONGUE_DOWN_ANDROID = 67,
            XR_FACE_PARAMETER_INDICES_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrFaceTrackingStateANDROID : uint
        {
            XR_FACE_TRACKING_STATE_PAUSED_ANDROID = 0,
            XR_FACE_TRACKING_STATE_STOPPED_ANDROID = 1,
            XR_FACE_TRACKING_STATE_TRACKING_ANDROID = 2,
            XR_FACE_TRACKING_STATE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrFaceConfidenceRegionsANDROID : uint
        {
            XR_FACE_CONFIDENCE_REGIONS_LOWER_ANDROID = 0,
            XR_FACE_CONFIDENCE_REGIONS_LEFT_UPPER_ANDROID = 1,
            XR_FACE_CONFIDENCE_REGIONS_RIGHT_UPPER_ANDROID = 2,
            XR_FACE_CONFIDENCE_REGIONS_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrFaceTrackerCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrFaceStateGetInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public long time;
        }

        public unsafe partial struct XrFaceStateANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint parametersCapacityInput;
            public uint parametersCountOutput;

            public float* parameters;

            public XrFaceTrackingStateANDROID faceTrackingState;
            public long sampleTime;
            public uint isValid;
            public uint regionConfidencesCapacityInput;
            public uint regionConfidencesCountOutput;

            public float* regionConfidences;
        }

        public unsafe partial struct XrSystemFaceTrackingPropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsFaceTracking;
        }
        public enum XrPassthroughCameraStateANDROID : uint
        {
            XR_PASSTHROUGH_CAMERA_STATE_DISABLED_ANDROID = 0,
            XR_PASSTHROUGH_CAMERA_STATE_INITIALIZING_ANDROID = 1,
            XR_PASSTHROUGH_CAMERA_STATE_READY_ANDROID = 2,
            XR_PASSTHROUGH_CAMERA_STATE_ERROR_ANDROID = 3,
            XR_PASSTHROUGH_CAMERA_STATE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemPassthroughCameraStatePropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsPassthroughCameraState;
        }

        public unsafe partial struct XrPassthroughCameraStateGetInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrEventDataRecommendedResolutionChangedANDROID
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public partial struct XrPassthroughLayerANDROID
        {
        }
        public enum XrWindingOrderANDROID : uint
        {
            XR_WINDING_ORDER_UNKNOWN_ANDROID = 0,
            XR_WINDING_ORDER_CW_ANDROID = 1,
            XR_WINDING_ORDER_CCW_ANDROID = 2,
            XR_WINDING_ORDER_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrPassthroughLayerCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public uint vertexCapacity;
            public uint indexCapacity;
        }

        public unsafe partial struct XrPassthroughLayerMeshANDROID
        {
            public Types.XrStructureType type;
            public void* next;

            public XrWindingOrderANDROID windingOrder;
            public uint vertexCount;
            public XrVector3f* vertices;
            public uint indexCount;
            public ushort* indices;
        }

        public unsafe partial struct XrCompositionLayerPassthroughANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong layerFlags;
            public IntPtr space;

            public XrPosef pose;

            public XrVector3f scale;

            public float opacity;
            public XrPassthroughLayerANDROID* layer;
        }

        public unsafe partial struct XrSystemPassthroughLayerPropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsPassthroughLayer;
            public uint maxMeshIndexCount;
            public uint maxMeshVertexCount;
        }

        public unsafe partial struct XrRaycastInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public uint maxResults;
            public uint trackerCount;
            public XrTrackableTrackerANDROID** trackers;

            public XrVector3f origin;

            public XrVector3f trajectory;
            public IntPtr space;
            public long time;
        }

        public partial struct XrRaycastHitResultANDROID
        {
            public XrTrackableTypeANDROID type;
            public ulong trackable;

            public XrPosef pose;
        }

        public unsafe partial struct XrRaycastHitResultsANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint resultsCapacityInput;
            public uint resultsCountOutput;

            public XrRaycastHitResultANDROID* results;
        }
        public enum XrPerformanceMetricsCounterUnitANDROID : uint
        {
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_GENERIC_ANDROID = 0,
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_PERCENTAGE_ANDROID = 1,
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_MILLISECONDS_ANDROID = 2,
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_BYTES_ANDROID = 3,
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_HERTZ_ANDROID = 4,
            XR_PERFORMANCE_METRICS_COUNTER_UNIT_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrPerformanceMetricsStateANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint enabled;
        }

        public unsafe partial struct XrPerformanceMetricsCounterANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong counterFlags;

            public XrPerformanceMetricsCounterUnitANDROID counterUnit;
            public uint uintValue;

            public float floatValue;
        }
        public enum XrObjectLabelANDROID : uint
        {
            XR_OBJECT_LABEL_UNKNOWN_ANDROID = 0,
            XR_OBJECT_LABEL_KEYBOARD_ANDROID = 1,
            XR_OBJECT_LABEL_MOUSE_ANDROID = 2,
            XR_OBJECT_LABEL_LAPTOP_ANDROID = 3,
            XR_OBJECT_LABEL_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrTrackableObjectANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrTrackingStateANDROID trackingState;

            public XrPosef centerPose;
            public XrExtent3Df extents;

            public XrObjectLabelANDROID objectLabel;
            public long lastUpdatedTime;
        }

        public unsafe partial struct XrTrackableObjectConfigurationANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint labelCount;
            public XrObjectLabelANDROID* activeLabels;
        }
        public enum XrFutureStateEXT : uint
        {
            XR_FUTURE_STATE_PENDING_EXT = 1,
            XR_FUTURE_STATE_READY_EXT = 2,
            XR_FUTURE_STATE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrFutureCancelInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrFutureEXT* future;
        }

        public unsafe partial struct XrFuturePollInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrFutureEXT* future;
        }

        public unsafe partial struct XrFutureCompletionBaseHeaderEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
        }

        public unsafe partial struct XrFuturePollResultEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public XrFutureStateEXT state;
        }

        public unsafe partial struct XrEventDataUserPresenceChangedEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr session;
            public uint isUserPresent;
        }

        public unsafe partial struct XrSystemUserPresencePropertiesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsUserPresence;
        }
        public enum XrHeadsetFitStatusML : uint
        {
            XR_HEADSET_FIT_STATUS_UNKNOWN_ML = 0,
            XR_HEADSET_FIT_STATUS_NOT_WORN_ML = 1,
            XR_HEADSET_FIT_STATUS_GOOD_FIT_ML = 2,
            XR_HEADSET_FIT_STATUS_BAD_FIT_ML = 3,
            XR_HEADSET_FIT_STATUS_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrEyeCalibrationStatusML : uint
        {
            XR_EYE_CALIBRATION_STATUS_UNKNOWN_ML = 0,
            XR_EYE_CALIBRATION_STATUS_NONE_ML = 1,
            XR_EYE_CALIBRATION_STATUS_COARSE_ML = 2,
            XR_EYE_CALIBRATION_STATUS_FINE_ML = 3,
            XR_EYE_CALIBRATION_STATUS_MAX_ENUM_ML = 0x7FFFFFFF,
        }

        public unsafe partial struct XrEventDataHeadsetFitChangedML
        {
            public Types.XrStructureType type;
            public void* next;

            public XrHeadsetFitStatusML status;
            public long time;
        }

        public unsafe partial struct XrEventDataEyeCalibrationChangedML
        {
            public Types.XrStructureType type;
            public void* next;

            public XrEyeCalibrationStatusML status;
        }

        public unsafe partial struct XrUserCalibrationEnableEventsInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public uint enabled;
        }

        public unsafe partial struct XrSystemNotificationsSetInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public uint suppressNotifications;
        }

        public partial struct XrWorldMeshDetectorML
        {
        }
        public enum XrWorldMeshDetectorLodML : uint
        {
            XR_WORLD_MESH_DETECTOR_LOD_MINIMUM_ML = 0,
            XR_WORLD_MESH_DETECTOR_LOD_MEDIUM_ML = 1,
            XR_WORLD_MESH_DETECTOR_LOD_MAXIMUM_ML = 2,
            XR_WORLD_MESH_DETECTOR_LOD_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrWorldMeshBlockStatusML : uint
        {
            XR_WORLD_MESH_BLOCK_STATUS_NEW_ML = 0,
            XR_WORLD_MESH_BLOCK_STATUS_UPDATED_ML = 1,
            XR_WORLD_MESH_BLOCK_STATUS_DELETED_ML = 2,
            XR_WORLD_MESH_BLOCK_STATUS_UNCHANGED_ML = 3,
            XR_WORLD_MESH_BLOCK_STATUS_MAX_ENUM_ML = 0x7FFFFFFF,
        }
        public enum XrWorldMeshBlockResultML : uint
        {
            XR_WORLD_MESH_BLOCK_RESULT_SUCCESS_ML = 0,
            XR_WORLD_MESH_BLOCK_RESULT_FAILED_ML = 1,
            XR_WORLD_MESH_BLOCK_RESULT_PENDING_ML = 2,
            XR_WORLD_MESH_BLOCK_RESULT_PARTIAL_UPDATE_ML = 3,
            XR_WORLD_MESH_BLOCK_RESULT_MAX_ENUM_ML = 0x7FFFFFFF,
        }

        public unsafe partial struct XrWorldMeshDetectorCreateInfoML
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrWorldMeshBlockStateML
        {
            public Types.XrStructureType type;

            public void* next;
            public XrUuid uuid;

            public XrPosef meshBoundingBoxCenter;
            public XrExtent3Df meshBoundingBoxExtents;
            public long lastUpdateTime;

            public XrWorldMeshBlockStatusML status;
        }

        public unsafe partial struct XrWorldMeshStateRequestInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;

            public XrPosef boundingBoxCenter;
            public XrExtent3Df boundingBoxExtents;
        }

        public unsafe partial struct XrWorldMeshStateRequestCompletionML
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public long timestamp;
            public uint meshBlockStateCapacityInput;
            public uint meshBlockStateCountOutput;

            public XrWorldMeshBlockStateML* meshBlockStates;
        }

        public unsafe partial struct XrWorldMeshBufferRecommendedSizeInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public uint maxBlockCount;
        }

        public unsafe partial struct XrWorldMeshBufferSizeML
        {
            public Types.XrStructureType type;

            public void* next;
            public uint size;
        }

        public unsafe partial struct XrWorldMeshBufferML
        {
            public Types.XrStructureType type;

            public void* next;
            public uint bufferSize;

            public void* buffer;
        }

        public unsafe partial struct XrWorldMeshBlockRequestML
        {
            public Types.XrStructureType type;

            public void* next;
            public XrUuid uuid;

            public XrWorldMeshDetectorLodML lod;
        }

        public unsafe partial struct XrWorldMeshGetInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong flags;

            public float fillHoleLength;

            public float disconnectedComponentArea;
            public uint blockCount;

            public XrWorldMeshBlockRequestML* blocks;
        }

        public unsafe partial struct XrWorldMeshBlockML
        {
            public Types.XrStructureType type;

            public void* next;
            public XrUuid uuid;

            public XrWorldMeshBlockResultML blockResult;

            public XrWorldMeshDetectorLodML lod;
            public ulong flags;
            public uint indexCount;
            public ushort* indexBuffer;
            public uint vertexCount;

            public XrVector3f* vertexBuffer;
            public uint normalCount;

            public XrVector3f* normalBuffer;
            public uint confidenceCount;

            public float* confidenceBuffer;
        }

        public unsafe partial struct XrWorldMeshRequestCompletionInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr meshSpace;
            public long meshSpaceLocateTime;
        }

        public unsafe partial struct XrWorldMeshRequestCompletionML
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public uint blockCount;

            public XrWorldMeshBlockML* blocks;
        }

        public partial struct XrFacialExpressionClientML
        {
        }
        public enum XrFacialBlendShapeML : uint
        {
            XR_FACIAL_BLEND_SHAPE_BROW_LOWERER_L_ML = 0,
            XR_FACIAL_BLEND_SHAPE_BROW_LOWERER_R_ML = 1,
            XR_FACIAL_BLEND_SHAPE_CHEEK_RAISER_L_ML = 2,
            XR_FACIAL_BLEND_SHAPE_CHEEK_RAISER_R_ML = 3,
            XR_FACIAL_BLEND_SHAPE_CHIN_RAISER_ML = 4,
            XR_FACIAL_BLEND_SHAPE_DIMPLER_L_ML = 5,
            XR_FACIAL_BLEND_SHAPE_DIMPLER_R_ML = 6,
            XR_FACIAL_BLEND_SHAPE_EYES_CLOSED_L_ML = 7,
            XR_FACIAL_BLEND_SHAPE_EYES_CLOSED_R_ML = 8,
            XR_FACIAL_BLEND_SHAPE_INNER_BROW_RAISER_L_ML = 9,
            XR_FACIAL_BLEND_SHAPE_INNER_BROW_RAISER_R_ML = 10,
            XR_FACIAL_BLEND_SHAPE_JAW_DROP_ML = 11,
            XR_FACIAL_BLEND_SHAPE_LID_TIGHTENER_L_ML = 12,
            XR_FACIAL_BLEND_SHAPE_LID_TIGHTENER_R_ML = 13,
            XR_FACIAL_BLEND_SHAPE_LIP_CORNER_DEPRESSOR_L_ML = 14,
            XR_FACIAL_BLEND_SHAPE_LIP_CORNER_DEPRESSOR_R_ML = 15,
            XR_FACIAL_BLEND_SHAPE_LIP_CORNER_PULLER_L_ML = 16,
            XR_FACIAL_BLEND_SHAPE_LIP_CORNER_PULLER_R_ML = 17,
            XR_FACIAL_BLEND_SHAPE_LIP_FUNNELER_LB_ML = 18,
            XR_FACIAL_BLEND_SHAPE_LIP_FUNNELER_LT_ML = 19,
            XR_FACIAL_BLEND_SHAPE_LIP_FUNNELER_RB_ML = 20,
            XR_FACIAL_BLEND_SHAPE_LIP_FUNNELER_RT_ML = 21,
            XR_FACIAL_BLEND_SHAPE_LIP_PRESSOR_L_ML = 22,
            XR_FACIAL_BLEND_SHAPE_LIP_PRESSOR_R_ML = 23,
            XR_FACIAL_BLEND_SHAPE_LIP_PUCKER_L_ML = 24,
            XR_FACIAL_BLEND_SHAPE_LIP_PUCKER_R_ML = 25,
            XR_FACIAL_BLEND_SHAPE_LIP_STRETCHER_L_ML = 26,
            XR_FACIAL_BLEND_SHAPE_LIP_STRETCHER_R_ML = 27,
            XR_FACIAL_BLEND_SHAPE_LIP_SUCK_LB_ML = 28,
            XR_FACIAL_BLEND_SHAPE_LIP_SUCK_LT_ML = 29,
            XR_FACIAL_BLEND_SHAPE_LIP_SUCK_RB_ML = 30,
            XR_FACIAL_BLEND_SHAPE_LIP_SUCK_RT_ML = 31,
            XR_FACIAL_BLEND_SHAPE_LIP_TIGHTENER_L_ML = 32,
            XR_FACIAL_BLEND_SHAPE_LIP_TIGHTENER_R_ML = 33,
            XR_FACIAL_BLEND_SHAPE_LIPS_TOWARD_ML = 34,
            XR_FACIAL_BLEND_SHAPE_LOWER_LIP_DEPRESSOR_L_ML = 35,
            XR_FACIAL_BLEND_SHAPE_LOWER_LIP_DEPRESSOR_R_ML = 36,
            XR_FACIAL_BLEND_SHAPE_NOSE_WRINKLER_L_ML = 37,
            XR_FACIAL_BLEND_SHAPE_NOSE_WRINKLER_R_ML = 38,
            XR_FACIAL_BLEND_SHAPE_OUTER_BROW_RAISER_L_ML = 39,
            XR_FACIAL_BLEND_SHAPE_OUTER_BROW_RAISER_R_ML = 40,
            XR_FACIAL_BLEND_SHAPE_UPPER_LID_RAISER_L_ML = 41,
            XR_FACIAL_BLEND_SHAPE_UPPER_LID_RAISER_R_ML = 42,
            XR_FACIAL_BLEND_SHAPE_UPPER_LIP_RAISER_L_ML = 43,
            XR_FACIAL_BLEND_SHAPE_UPPER_LIP_RAISER_R_ML = 44,
            XR_FACIAL_BLEND_SHAPE_TONGUE_OUT_ML = 45,
            XR_FACIAL_BLEND_SHAPE_MAX_ENUM_ML = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemFacialExpressionPropertiesML
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsFacialExpression;
        }

        public unsafe partial struct XrFacialExpressionClientCreateInfoML
        {
            public Types.XrStructureType type;
            public void* next;
            public uint requestedCount;
            public XrFacialBlendShapeML* requestedFacialBlendShapes;
        }

        public unsafe partial struct XrFacialExpressionBlendShapeGetInfoML
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrFacialExpressionBlendShapePropertiesML
        {
            public Types.XrStructureType type;

            public void* next;

            public XrFacialBlendShapeML requestedFacialBlendShape;

            public float weight;
            public ulong flags;
            public long time;
        }
        public enum XrBoundaryVisibilityMETA : uint
        {
            XR_BOUNDARY_VISIBILITY_NOT_SUPPRESSED_META = 1,
            XR_BOUNDARY_VISIBILITY_SUPPRESSED_META = 2,
            XR_BOUNDARY_VISIBILITY_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemBoundaryVisibilityPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsBoundaryVisibility;
        }

        public unsafe partial struct XrEventDataBoundaryVisibilityChangedMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrBoundaryVisibilityMETA boundaryVisibility;
        }

        public unsafe partial struct XrSystemSimultaneousHandsAndControllersPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsSimultaneousHandsAndControllers;
        }

        public unsafe partial struct XrSimultaneousHandsAndControllersTrackingResumeInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSimultaneousHandsAndControllersTrackingPauseInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }
        public enum XrFaceTrackingVisemeMETA : uint
        {
            XR_FACE_TRACKING_VISEME_SIL_META = 0,
            XR_FACE_TRACKING_VISEME_PP_META = 1,
            XR_FACE_TRACKING_VISEME_FF_META = 2,
            XR_FACE_TRACKING_VISEME_TH_META = 3,
            XR_FACE_TRACKING_VISEME_DD_META = 4,
            XR_FACE_TRACKING_VISEME_KK_META = 5,
            XR_FACE_TRACKING_VISEME_CH_META = 6,
            XR_FACE_TRACKING_VISEME_SS_META = 7,
            XR_FACE_TRACKING_VISEME_NN_META = 8,
            XR_FACE_TRACKING_VISEME_RR_META = 9,
            XR_FACE_TRACKING_VISEME_AA_META = 10,
            XR_FACE_TRACKING_VISEME_E_META = 11,
            XR_FACE_TRACKING_VISEME_IH_META = 12,
            XR_FACE_TRACKING_VISEME_OH_META = 13,
            XR_FACE_TRACKING_VISEME_OU_META = 14,
            XR_FACE_TRACKING_VISEME_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public unsafe partial struct XrFaceTrackingVisemesMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint isValid;
            public _visemes_e__FixedBuffer visemes;

            [InlineArray(15)]
            public partial struct _visemes_e__FixedBuffer
            {
                public float e0;
            }
        }

        public unsafe partial struct XrSystemFaceTrackingVisemesPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsVisemes;
        }
        public enum XrSemanticLabelMETA : uint
        {
            XR_SEMANTIC_LABEL_UNKNOWN_META = 0,
            XR_SEMANTIC_LABEL_FLOOR_META = 1,
            XR_SEMANTIC_LABEL_CEILING_META = 2,
            XR_SEMANTIC_LABEL_WALL_FACE_META = 3,
            XR_SEMANTIC_LABEL_INNER_WALL_FACE_META = 4,
            XR_SEMANTIC_LABEL_INVISIBLE_WALL_FACE_META = 5,
            XR_SEMANTIC_LABEL_DOOR_FRAME_META = 6,
            XR_SEMANTIC_LABEL_WINDOW_FRAME_META = 7,
            XR_SEMANTIC_LABEL_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public partial struct XrRoomMeshFaceMETA
        {
            public XrUuid uuid;

            public XrUuid parentUuid;

            public XrSemanticLabelMETA semanticLabel;
        }

        public unsafe partial struct XrRoomMeshFaceIndicesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint indexCapacityInput;
            public uint indexCountOutput;
            public uint* indices;
        }

        public unsafe partial struct XrSpaceRoomMeshGetInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint recognizedSemanticLabelCount;
            public XrSemanticLabelMETA* recognizedSemanticLabels;
        }

        public unsafe partial struct XrRoomMeshMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrVector3f* vertices;
            public uint faceCapacityInput;
            public uint faceCountOutput;

            public XrRoomMeshFaceMETA* faces;
        }

        public unsafe partial struct XrColocationDiscoveryStartInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrColocationDiscoveryStopInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrColocationAdvertisementStartInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint bufferSize;
            public byte* buffer;
        }

        public unsafe partial struct XrColocationAdvertisementStopInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrEventDataStartColocationAdvertisementCompleteMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong advertisementRequestId;

            public Types.XrResult result;

            public XrUuid advertisementUuid;
        }

        public unsafe partial struct XrEventDataStopColocationAdvertisementCompleteMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
        }

        public unsafe partial struct XrEventDataColocationAdvertisementCompleteMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong advertisementRequestId;

            public Types.XrResult result;
        }

        public unsafe partial struct XrEventDataStartColocationDiscoveryCompleteMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong discoveryRequestId;

            public Types.XrResult result;
        }

        public unsafe partial struct XrEventDataColocationDiscoveryResultMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong discoveryRequestId;

            public XrUuid advertisementUuid;
            public uint bufferSize;
            public _buffer_e__FixedBuffer buffer;

            [InlineArray(1024)]
            public partial struct _buffer_e__FixedBuffer
            {
                public byte e0;
            }
        }

        public unsafe partial struct XrEventDataColocationDiscoveryCompleteMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong discoveryRequestId;

            public Types.XrResult result;
        }

        public unsafe partial struct XrEventDataStopColocationDiscoveryCompleteMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong requestId;

            public Types.XrResult result;
        }

        public unsafe partial struct XrSystemColocationDiscoveryPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsColocationDiscovery;
        }

        public unsafe partial struct XrSystemSpatialEntityGroupSharingPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsSpatialEntityGroupSharing;
        }

        public unsafe partial struct XrShareSpacesRecipientGroupsMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public uint groupCount;

            public XrUuid* groups;
        }

        public unsafe partial struct XrSpaceGroupUuidFilterInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrUuid groupUuid;
        }

        public partial struct XrEnvironmentRaycasterMETA
        {
        }
        public enum XrEnvironmentRaycastHitStatusMETA : uint
        {
            XR_ENVIRONMENT_RAYCAST_HIT_STATUS_HIT_META = 1,
            XR_ENVIRONMENT_RAYCAST_HIT_STATUS_NO_HIT_META = 2,
            XR_ENVIRONMENT_RAYCAST_HIT_STATUS_HIT_POINT_OCCLUDED_META = 3,
            XR_ENVIRONMENT_RAYCAST_HIT_STATUS_HIT_POINT_OUTSIDE_OF_FOV_META = 4,
            XR_ENVIRONMENT_RAYCAST_HIT_STATUS_RAY_OCCLUDED_META = 5,
            XR_ENVIRONMENT_RAYCAST_HIT_STATUS_HIT_INVALID_ORIENTATION_META = 6,
            XR_ENVIRONMENT_RAYCAST_HIT_STATUS_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemEnvironmentRaycastPropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsEnvironmentRaycast;
        }

        public unsafe partial struct XrEnvironmentRaycasterCreateInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrEnvironmentRaycasterCreateCompletionMETA
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public XrEnvironmentRaycasterMETA* environmentRaycaster;
        }

        public unsafe partial struct XrEnvironmentRaycastFilterBaseHeaderMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrEnvironmentRaycastHitGetInfoMETA
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;

            public XrVector3f origin;

            public XrVector3f direction;
            public uint filterCount;
            public XrEnvironmentRaycastFilterBaseHeaderMETA** filters;
        }

        public unsafe partial struct XrEnvironmentRaycastHitMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public XrEnvironmentRaycastHitStatusMETA status;

            public XrPosef pose;
        }

        public unsafe partial struct XrEnvironmentRaycastFilterDistanceMETA
        {
            public Types.XrStructureType type;
            public void* next;

            public float maxDistance;
        }

        public partial struct XrExtent3DiMETA
        {
            public int width;
            public int height;
            public int depth;
        }

        public unsafe partial struct XrTilePropertiesMETA
        {
            public Types.XrStructureType type;

            public void* next;

            public XrExtent3DiMETA tileDimensions;

            public XrExtent2Di apronDimensions;

            public XrOffset2Di origin;
        }

        public unsafe partial struct XrTilePropertiesHintMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public uint propertiesCount;
            public XrTilePropertiesMETA* properties;
        }

        public unsafe partial struct XrHandTrackingUnextrapolatedPosesRequestMETA
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrHandTrackingUnextrapolatedPosesMETA
        {
            public Types.XrStructureType type;

            public void* next;
            public long captureTime;
        }
        public enum XrHandTrackingFrequencyHintMETA : uint
        {
            XR_HAND_TRACKING_FREQUENCY_HINT_DEFAULT_META = 1,
            XR_HAND_TRACKING_FREQUENCY_HINT_HIGH_META = 2,
            XR_HAND_TRACKING_FREQUENCY_HINT_MAX_ENUM_META = 0x7FFFFFFF,
        }

        public partial struct XrLightEstimatorANDROID
        {
        }
        public enum XrLightEstimateStateANDROID : uint
        {
            XR_LIGHT_ESTIMATE_STATE_VALID_ANDROID = 0,
            XR_LIGHT_ESTIMATE_STATE_INVALID_ANDROID = 1,
            XR_LIGHT_ESTIMATE_STATE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrSphericalHarmonicsKindANDROID : uint
        {
            XR_SPHERICAL_HARMONICS_KIND_TOTAL_ANDROID = 0,
            XR_SPHERICAL_HARMONICS_KIND_AMBIENT_ANDROID = 1,
            XR_SPHERICAL_HARMONICS_KIND_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemLightEstimationPropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsLightEstimation;
        }

        public unsafe partial struct XrLightEstimatorCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrLightEstimateGetInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;
            public long time;
        }

        public unsafe partial struct XrLightEstimateANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrLightEstimateStateANDROID state;
            public long lastUpdatedTime;
        }

        public unsafe partial struct XrDirectionalLightANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrLightEstimateStateANDROID state;

            public XrVector3f intensity;

            public XrVector3f direction;
        }

        public unsafe partial struct XrAmbientLightANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrLightEstimateStateANDROID state;

            public XrVector3f intensity;

            public XrVector3f colorCorrection;
        }

        public unsafe partial struct XrSphericalHarmonicsANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrLightEstimateStateANDROID state;

            public XrSphericalHarmonicsKindANDROID kind;
            public _coefficients_e__FixedBuffer coefficients;

            [InlineArray(9 * 3)]
            public partial struct _coefficients_e__FixedBuffer
            {
                public float e0_0;
            }
        }
        public enum XrTrackableMarkerTrackingModeANDROID : uint
        {
            XR_TRACKABLE_MARKER_TRACKING_MODE_DYNAMIC_ANDROID = 0,
            XR_TRACKABLE_MARKER_TRACKING_MODE_STATIC_ANDROID = 1,
            XR_TRACKABLE_MARKER_TRACKING_MODE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrTrackableMarkerDictionaryANDROID : uint
        {
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_4X4_50_ANDROID = 0,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_4X4_100_ANDROID = 1,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_4X4_250_ANDROID = 2,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_4X4_1000_ANDROID = 3,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_5X5_50_ANDROID = 4,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_5X5_100_ANDROID = 5,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_5X5_250_ANDROID = 6,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_5X5_1000_ANDROID = 7,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_6X6_50_ANDROID = 8,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_6X6_100_ANDROID = 9,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_6X6_250_ANDROID = 10,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_6X6_1000_ANDROID = 11,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_7X7_50_ANDROID = 12,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_7X7_100_ANDROID = 13,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_7X7_250_ANDROID = 14,
            XR_TRACKABLE_MARKER_DICTIONARY_ARUCO_7X7_1000_ANDROID = 15,
            XR_TRACKABLE_MARKER_DICTIONARY_APRILTAG_16H5_ANDROID = 16,
            XR_TRACKABLE_MARKER_DICTIONARY_APRILTAG_25H9_ANDROID = 17,
            XR_TRACKABLE_MARKER_DICTIONARY_APRILTAG_36H10_ANDROID = 18,
            XR_TRACKABLE_MARKER_DICTIONARY_APRILTAG_36H11_ANDROID = 19,
            XR_TRACKABLE_MARKER_DICTIONARY_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemMarkerTrackingPropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsMarkerTracking;
            public uint supportsMarkerSizeEstimation;
            public ushort maxMarkerCount;
        }

        public partial struct XrTrackableMarkerDatabaseEntryANDROID
        {
            public int id;

            public float edgeSize;
        }

        public unsafe partial struct XrTrackableMarkerDatabaseANDROID
        {
            public XrTrackableMarkerDictionaryANDROID dictionary;
            public uint entryCount;
            public XrTrackableMarkerDatabaseEntryANDROID* entries;
        }

        public unsafe partial struct XrTrackableMarkerConfigurationANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrTrackableMarkerTrackingModeANDROID trackingMode;
            public uint databaseCount;
            public XrTrackableMarkerDatabaseANDROID* databases;
        }

        public unsafe partial struct XrTrackableMarkerANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrTrackingStateANDROID trackingState;
            public long lastUpdatedTime;

            public XrTrackableMarkerDictionaryANDROID dictionary;
            public int markerId;

            public XrPosef centerPose;

            public XrExtent2Df extents;
        }
        public enum XrQrCodeTrackingModeANDROID : uint
        {
            XR_QR_CODE_TRACKING_MODE_DYNAMIC_ANDROID = 0,
            XR_QR_CODE_TRACKING_MODE_STATIC_ANDROID = 1,
            XR_QR_CODE_TRACKING_MODE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemQrCodeTrackingPropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsQrCodeTracking;
            public uint supportsQrCodeSizeEstimation;
            public ushort maxQrCodeCount;
        }

        public unsafe partial struct XrTrackableQrCodeConfigurationANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrQrCodeTrackingModeANDROID trackingMode;

            public float qrCodeEdgeSize;
        }

        public unsafe partial struct XrTrackableQrCodeANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrTrackingStateANDROID trackingState;
            public long lastUpdatedTime;

            public XrPosef centerPose;

            public XrExtent2Df extents;
            public uint bufferCapacityInput;
            public uint bufferCountOutput;
            public byte* buffer;
        }

        public partial struct XrTrackableImageDatabaseANDROID
        {
        }
        public enum XrTrackableImageTrackingModeANDROID : uint
        {
            XR_TRACKABLE_IMAGE_TRACKING_MODE_DYNAMIC_ANDROID = 1,
            XR_TRACKABLE_IMAGE_TRACKING_MODE_STATIC_ANDROID = 2,
            XR_TRACKABLE_IMAGE_TRACKING_MODE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrTrackableImageFormatANDROID : uint
        {
            XR_TRACKABLE_IMAGE_FORMAT_R8G8B8A8_ANDROID = 1,
            XR_TRACKABLE_IMAGE_FORMAT_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemImageTrackingPropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsImageTracking;
            public uint supportsPhysicalSizeEstimation;
            public uint maxTrackedImageCount;
            public uint maxLoadedImageCount;
        }

        public unsafe partial struct XrTrackableImageDatabaseEntryANDROID
        {
            public Types.XrStructureType type;
            public void* next;

            public XrTrackableImageTrackingModeANDROID trackingMode;

            public float physicalWidth;
            public uint imageWidth;
            public uint imageHeight;

            public XrTrackableImageFormatANDROID format;
            public uint bufferSize;
            public byte* buffer;
        }

        public unsafe partial struct XrTrackableImageDatabaseCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public uint entryCount;
            public XrTrackableImageDatabaseEntryANDROID* entries;
        }

        public unsafe partial struct XrCreateTrackableImageDatabaseCompletionANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public XrTrackableImageDatabaseANDROID* database;
        }

        public unsafe partial struct XrTrackableImageConfigurationANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public uint databaseCount;
            public XrTrackableImageDatabaseANDROID** databases;
        }

        public unsafe partial struct XrTrackableImageANDROID
        {
            public Types.XrStructureType type;
            public void* next;

            public XrTrackingStateANDROID trackingState;
            public long lastUpdatedTime;
            public XrTrackableImageDatabaseANDROID* database;
            public uint databaseEntryIndex;

            public XrPosef centerPose;

            public XrExtent2Df extents;
        }

        public unsafe partial struct XrEventDataImageTrackingLostANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public long time;
        }

        public partial struct XrSceneMeshingTrackerANDROID
        {
        }

        public partial struct XrSceneMeshSnapshotANDROID
        {
        }
        public enum XrSceneMeshSemanticLabelSetANDROID : uint
        {
            XR_SCENE_MESH_SEMANTIC_LABEL_SET_NONE_ANDROID = 0,
            XR_SCENE_MESH_SEMANTIC_LABEL_SET_DEFAULT_ANDROID = 1,
            XR_SCENE_MESH_SEMANTIC_LABEL_SET_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrSceneMeshTrackingStateANDROID : uint
        {
            XR_SCENE_MESH_TRACKING_STATE_INITIALIZING_ANDROID = 0,
            XR_SCENE_MESH_TRACKING_STATE_TRACKING_ANDROID = 1,
            XR_SCENE_MESH_TRACKING_STATE_WAITING_ANDROID = 2,
            XR_SCENE_MESH_TRACKING_STATE_ERROR_ANDROID = 3,
            XR_SCENE_MESH_TRACKING_STATE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrSceneMeshSemanticLabelANDROID : uint
        {
            XR_SCENE_MESH_SEMANTIC_LABEL_OTHER_ANDROID = 0,
            XR_SCENE_MESH_SEMANTIC_LABEL_FLOOR_ANDROID = 1,
            XR_SCENE_MESH_SEMANTIC_LABEL_CEILING_ANDROID = 2,
            XR_SCENE_MESH_SEMANTIC_LABEL_WALL_ANDROID = 3,
            XR_SCENE_MESH_SEMANTIC_LABEL_TABLE_ANDROID = 4,
            XR_SCENE_MESH_SEMANTIC_LABEL_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemSceneMeshingPropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsSceneMeshing;
        }

        public unsafe partial struct XrSceneMeshingTrackerCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSceneMeshSemanticLabelSetANDROID semanticLabelSet;
            public uint enableNormals;
        }

        public unsafe partial struct XrSceneMeshSnapshotCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;

            public XrBoxf boundingBox;
        }

        public unsafe partial struct XrSceneMeshSnapshotCreationResultANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSceneMeshSnapshotANDROID* snapshot;

            public XrSceneMeshTrackingStateANDROID trackingState;
        }

        public unsafe partial struct XrSceneSubmeshStateANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrUuid submeshId;
            public long lastUpdatedTime;

            public XrPosef submeshPoseInBaseSpace;

            public XrExtent3Df bounds;
        }

        public unsafe partial struct XrSceneSubmeshDataANDROID
        {
            public Types.XrStructureType type;
            public void* next;

            public XrUuid submeshId;
            public uint vertexCapacityInput;
            public uint vertexCountOutput;

            public XrVector3f* vertexPositions;

            public XrVector3f* vertexNormals;
            public byte* vertexSemantics;
            public uint indexCapacityInput;
            public uint indexCountOutput;
            public uint* indices;
        }

        public partial struct XrSpatialEntityEXT
        {
        }

        public partial struct XrSpatialContextEXT
        {
        }

        public partial struct XrSpatialSnapshotEXT
        {
        }
        public enum XrSpatialCapabilityEXT : uint
        {
            XR_SPATIAL_CAPABILITY_PLANE_TRACKING_EXT = 1000741000,
            XR_SPATIAL_CAPABILITY_MARKER_TRACKING_QR_CODE_EXT = 1000743000,
            XR_SPATIAL_CAPABILITY_MARKER_TRACKING_MICRO_QR_CODE_EXT = 1000743001,
            XR_SPATIAL_CAPABILITY_MARKER_TRACKING_ARUCO_MARKER_EXT = 1000743002,
            XR_SPATIAL_CAPABILITY_MARKER_TRACKING_APRIL_TAG_EXT = 1000743003,
            XR_SPATIAL_CAPABILITY_ANCHOR_EXT = 1000762000,
            XR_SPATIAL_CAPABILITY_IMAGE_TRACKING_EXT = 1000782000,
            XR_SPATIAL_CAPABILITY_OBJECT_TRACKING_ANDROID = 1000785000,
            XR_SPATIAL_CAPABILITY_DEPTH_RAYCAST_ANDROID = 1000786000,
            XR_SPATIAL_CAPABILITY_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrSpatialCapabilityFeatureEXT : uint
        {
            XR_SPATIAL_CAPABILITY_FEATURE_MARKER_TRACKING_FIXED_SIZE_MARKERS_EXT = 1000743000,
            XR_SPATIAL_CAPABILITY_FEATURE_MARKER_TRACKING_STATIC_MARKERS_EXT = 1000743001,
            XR_SPATIAL_CAPABILITY_FEATURE_SPHERE_BOUNDS_FILTER_ANDROID = 1000761000,
            XR_SPATIAL_CAPABILITY_FEATURE_BOX_BOUNDS_FILTER_ANDROID = 1000761001,
            XR_SPATIAL_CAPABILITY_FEATURE_FRUSTUM_BOUNDS_FILTER_ANDROID = 1000761002,
            XR_SPATIAL_CAPABILITY_FEATURE_IMAGE_TRACKING_AUTOMATIC_SIZE_IMAGES_EXT = 1000782000,
            XR_SPATIAL_CAPABILITY_FEATURE_IMAGE_TRACKING_STATIC_IMAGES_EXT = 1000782001,
            XR_SPATIAL_CAPABILITY_FEATURE_IMAGE_TRACKING_FIXED_SIZE_IMAGES_EXT = 1000782002,
            XR_SPATIAL_CAPABILITY_FEATURE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrSpatialComponentTypeEXT : uint
        {
            XR_SPATIAL_COMPONENT_TYPE_BOUNDED_2D_EXT = 1,
            XR_SPATIAL_COMPONENT_TYPE_BOUNDED_3D_EXT = 2,
            XR_SPATIAL_COMPONENT_TYPE_PARENT_EXT = 3,
            XR_SPATIAL_COMPONENT_TYPE_MESH_3D_EXT = 4,
            XR_SPATIAL_COMPONENT_TYPE_PLANE_ALIGNMENT_EXT = 1000741000,
            XR_SPATIAL_COMPONENT_TYPE_MESH_2D_EXT = 1000741001,
            XR_SPATIAL_COMPONENT_TYPE_POLYGON_2D_EXT = 1000741002,
            XR_SPATIAL_COMPONENT_TYPE_PLANE_SEMANTIC_LABEL_EXT = 1000741003,
            XR_SPATIAL_COMPONENT_TYPE_MARKER_EXT = 1000743000,
            XR_SPATIAL_COMPONENT_TYPE_ANCHOR_EXT = 1000762000,
            XR_SPATIAL_COMPONENT_TYPE_PERSISTENCE_EXT = 1000763000,
            XR_SPATIAL_COMPONENT_TYPE_IMAGE_2D_EXT = 1000782000,
            XR_SPATIAL_COMPONENT_TYPE_OBJECT_SEMANTIC_LABEL_ANDROID = 1000785000,
            XR_SPATIAL_COMPONENT_TYPE_RAYCAST_RESULT_ANDROID = 1000786000,
            XR_SPATIAL_COMPONENT_TYPE_SUBSUMED_BY_ANDROID = 1000791000,
            XR_SPATIAL_COMPONENT_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrSpatialEntityTrackingStateEXT : uint
        {
            XR_SPATIAL_ENTITY_TRACKING_STATE_STOPPED_EXT = 1,
            XR_SPATIAL_ENTITY_TRACKING_STATE_PAUSED_EXT = 2,
            XR_SPATIAL_ENTITY_TRACKING_STATE_TRACKING_EXT = 3,
            XR_SPATIAL_ENTITY_TRACKING_STATE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrSpatialBufferTypeEXT : uint
        {
            XR_SPATIAL_BUFFER_TYPE_UNKNOWN_EXT = 0,
            XR_SPATIAL_BUFFER_TYPE_STRING_EXT = 1,
            XR_SPATIAL_BUFFER_TYPE_UINT8_EXT = 2,
            XR_SPATIAL_BUFFER_TYPE_UINT16_EXT = 3,
            XR_SPATIAL_BUFFER_TYPE_UINT32_EXT = 4,
            XR_SPATIAL_BUFFER_TYPE_FLOAT_EXT = 5,
            XR_SPATIAL_BUFFER_TYPE_VECTOR2F_EXT = 6,
            XR_SPATIAL_BUFFER_TYPE_VECTOR3F_EXT = 7,
            XR_SPATIAL_BUFFER_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpatialCapabilityComponentTypesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint componentTypeCapacityInput;
            public uint componentTypeCountOutput;

            public XrSpatialComponentTypeEXT* componentTypes;
        }

        public unsafe partial struct XrSpatialCapabilityConfigurationBaseHeaderEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialCapabilityEXT capability;
            public uint enabledComponentCount;
            public XrSpatialComponentTypeEXT* enabledComponents;
        }

        public unsafe partial struct XrSpatialContextCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint capabilityConfigCount;
            public XrSpatialCapabilityConfigurationBaseHeaderEXT** capabilityConfigs;
        }

        public unsafe partial struct XrCreateSpatialContextCompletionEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public XrSpatialContextEXT* spatialContext;
        }

        public unsafe partial struct XrSpatialDiscoverySnapshotCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint componentTypeCount;
            public XrSpatialComponentTypeEXT* componentTypes;
        }

        public unsafe partial struct XrCreateSpatialDiscoverySnapshotCompletionInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;
            public XrFutureEXT* future;
        }

        public unsafe partial struct XrCreateSpatialDiscoverySnapshotCompletionEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public XrSpatialSnapshotEXT* snapshot;
        }

        public unsafe partial struct XrSpatialComponentDataQueryConditionEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint componentTypeCount;
            public XrSpatialComponentTypeEXT* componentTypes;
        }

        public unsafe partial struct XrSpatialComponentDataQueryResultEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint entityIdCapacityInput;
            public uint entityIdCountOutput;
            public ulong* entityIds;
            public uint entityStateCapacityInput;
            public uint entityStateCountOutput;

            public XrSpatialEntityTrackingStateEXT* entityStates;
        }

        public partial struct XrSpatialBufferEXT
        {
            public ulong bufferId;

            public XrSpatialBufferTypeEXT bufferType;
        }

        public unsafe partial struct XrSpatialBufferGetInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong bufferId;
        }

        public partial struct XrSpatialBounded2DDataEXT
        {
            public XrPosef center;

            public XrExtent2Df extents;
        }

        public unsafe partial struct XrSpatialComponentBounded2DListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint boundCount;

            public XrSpatialBounded2DDataEXT* bounds;
        }

        public unsafe partial struct XrSpatialComponentBounded3DListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint boundCount;

            public XrBoxf* bounds;
        }

        public unsafe partial struct XrSpatialComponentParentListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint parentCount;
            public ulong* parents;
        }

        public partial struct XrSpatialMeshDataEXT
        {
            public XrPosef origin;

            public XrSpatialBufferEXT vertexBuffer;

            public XrSpatialBufferEXT indexBuffer;
        }

        public unsafe partial struct XrSpatialComponentMesh3DListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint meshCount;

            public XrSpatialMeshDataEXT* meshes;
        }

        public unsafe partial struct XrSpatialEntityFromIdCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong entityId;
        }

        public unsafe partial struct XrSpatialUpdateSnapshotCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint entityCount;
            public XrSpatialEntityEXT** entities;
            public uint componentTypeCount;
            public XrSpatialComponentTypeEXT* componentTypes;
            public IntPtr baseSpace;
            public long time;
        }

        public unsafe partial struct XrEventDataSpatialDiscoveryRecommendedEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContextEXT* spatialContext;
        }

        public unsafe partial struct XrSpatialFilterTrackingStateEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialEntityTrackingStateEXT trackingState;
        }
        public enum XrSpatialPlaneAlignmentEXT : uint
        {
            XR_SPATIAL_PLANE_ALIGNMENT_HORIZONTAL_UPWARD_EXT = 0,
            XR_SPATIAL_PLANE_ALIGNMENT_HORIZONTAL_DOWNWARD_EXT = 1,
            XR_SPATIAL_PLANE_ALIGNMENT_VERTICAL_EXT = 2,
            XR_SPATIAL_PLANE_ALIGNMENT_ARBITRARY_EXT = 3,
            XR_SPATIAL_PLANE_ALIGNMENT_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrSpatialPlaneSemanticLabelEXT : uint
        {
            XR_SPATIAL_PLANE_SEMANTIC_LABEL_UNCATEGORIZED_EXT = 1,
            XR_SPATIAL_PLANE_SEMANTIC_LABEL_FLOOR_EXT = 2,
            XR_SPATIAL_PLANE_SEMANTIC_LABEL_WALL_EXT = 3,
            XR_SPATIAL_PLANE_SEMANTIC_LABEL_CEILING_EXT = 4,
            XR_SPATIAL_PLANE_SEMANTIC_LABEL_TABLE_EXT = 5,
            XR_SPATIAL_PLANE_SEMANTIC_LABEL_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpatialCapabilityConfigurationPlaneTrackingEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialCapabilityEXT capability;
            public uint enabledComponentCount;
            public XrSpatialComponentTypeEXT* enabledComponents;
        }

        public unsafe partial struct XrSpatialComponentPlaneAlignmentListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint planeAlignmentCount;

            public XrSpatialPlaneAlignmentEXT* planeAlignments;
        }

        public unsafe partial struct XrSpatialComponentMesh2DListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint meshCount;

            public XrSpatialMeshDataEXT* meshes;
        }

        public partial struct XrSpatialPolygon2DDataEXT
        {
            public XrPosef origin;

            public XrSpatialBufferEXT vertexBuffer;
        }

        public unsafe partial struct XrSpatialComponentPolygon2DListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint polygonCount;

            public XrSpatialPolygon2DDataEXT* polygons;
        }

        public unsafe partial struct XrSpatialComponentPlaneSemanticLabelListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint semanticLabelCount;

            public XrSpatialPlaneSemanticLabelEXT* semanticLabels;
        }

        public unsafe partial struct XrStationaryReferenceSpaceGenerationIdGetInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrStationaryReferenceSpaceGenerationIdResultEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public XrUuid generationId;
        }
        public enum XrSpatialMarkerArucoDictEXT : uint
        {
            XR_SPATIAL_MARKER_ARUCO_DICT_4X4_50_EXT = 1,
            XR_SPATIAL_MARKER_ARUCO_DICT_4X4_100_EXT = 2,
            XR_SPATIAL_MARKER_ARUCO_DICT_4X4_250_EXT = 3,
            XR_SPATIAL_MARKER_ARUCO_DICT_4X4_1000_EXT = 4,
            XR_SPATIAL_MARKER_ARUCO_DICT_5X5_50_EXT = 5,
            XR_SPATIAL_MARKER_ARUCO_DICT_5X5_100_EXT = 6,
            XR_SPATIAL_MARKER_ARUCO_DICT_5X5_250_EXT = 7,
            XR_SPATIAL_MARKER_ARUCO_DICT_5X5_1000_EXT = 8,
            XR_SPATIAL_MARKER_ARUCO_DICT_6X6_50_EXT = 9,
            XR_SPATIAL_MARKER_ARUCO_DICT_6X6_100_EXT = 10,
            XR_SPATIAL_MARKER_ARUCO_DICT_6X6_250_EXT = 11,
            XR_SPATIAL_MARKER_ARUCO_DICT_6X6_1000_EXT = 12,
            XR_SPATIAL_MARKER_ARUCO_DICT_7X7_50_EXT = 13,
            XR_SPATIAL_MARKER_ARUCO_DICT_7X7_100_EXT = 14,
            XR_SPATIAL_MARKER_ARUCO_DICT_7X7_250_EXT = 15,
            XR_SPATIAL_MARKER_ARUCO_DICT_7X7_1000_EXT = 16,
            XR_SPATIAL_MARKER_ARUCO_DICT_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrSpatialMarkerAprilTagDictEXT : uint
        {
            XR_SPATIAL_MARKER_APRIL_TAG_DICT_16H5_EXT = 1,
            XR_SPATIAL_MARKER_APRIL_TAG_DICT_25H9_EXT = 2,
            XR_SPATIAL_MARKER_APRIL_TAG_DICT_36H10_EXT = 3,
            XR_SPATIAL_MARKER_APRIL_TAG_DICT_36H11_EXT = 4,
            XR_SPATIAL_MARKER_APRIL_TAG_DICT_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpatialCapabilityConfigurationQrCodeEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialCapabilityEXT capability;
            public uint enabledComponentCount;
            public XrSpatialComponentTypeEXT* enabledComponents;
        }

        public unsafe partial struct XrSpatialCapabilityConfigurationMicroQrCodeEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialCapabilityEXT capability;
            public uint enabledComponentCount;
            public XrSpatialComponentTypeEXT* enabledComponents;
        }

        public unsafe partial struct XrSpatialCapabilityConfigurationArucoMarkerEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialCapabilityEXT capability;
            public uint enabledComponentCount;
            public XrSpatialComponentTypeEXT* enabledComponents;

            public XrSpatialMarkerArucoDictEXT arUcoDict;
        }

        public unsafe partial struct XrSpatialCapabilityConfigurationAprilTagEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialCapabilityEXT capability;
            public uint enabledComponentCount;
            public XrSpatialComponentTypeEXT* enabledComponents;

            public XrSpatialMarkerAprilTagDictEXT aprilDict;
        }

        public unsafe partial struct XrSpatialMarkerSizeEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public float markerSideLength;
        }

        public unsafe partial struct XrSpatialMarkerStaticOptimizationEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint optimizeForStaticMarker;
        }

        public partial struct XrSpatialMarkerDataEXT
        {
            public XrSpatialCapabilityEXT capability;
            public uint markerId;

            public XrSpatialBufferEXT data;
        }

        public unsafe partial struct XrSpatialComponentMarkerListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint markerCount;

            public XrSpatialMarkerDataEXT* markers;
        }
        public enum XrDynamicObjectTypeBD : uint
        {
            XR_DYNAMIC_OBJECT_TYPE_UNKNOWN_BD = 0,
            XR_DYNAMIC_OBJECT_TYPE_KEYBOARD_BD = 1000747000,
            XR_DYNAMIC_OBJECT_TYPE_MOUSE_BD = 1000748000,
            XR_DYNAMIC_OBJECT_TYPE_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemDynamicObjectTrackingPropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsDynamicObjectTracking;
        }

        public unsafe partial struct XrSenseDataProviderCreateInfoDynamicObjectBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint trackingTypeCount;
            public XrDynamicObjectTypeBD* trackingTypes;
        }

        public unsafe partial struct XrDynamicObjectDataBD
        {
            public Types.XrStructureType type;

            public void* next;

            public XrDynamicObjectTypeBD objectType;
        }

        public unsafe partial struct XrSpatialEntityComponentDataDynamicObjectBD
        {
            public Types.XrStructureType type;

            public void* next;

            public XrDynamicObjectDataBD data;
        }

        public unsafe partial struct XrSenseDataFilterDynamicObjectTypeBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint typeCount;
            public XrDynamicObjectTypeBD* types;
        }

        public unsafe partial struct XrSystemDynamicObjectKeyboardPropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsDynamicObjectKeyboard;
        }

        public unsafe partial struct XrSystemDynamicObjectMousePropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsDynamicObjectMouse;
        }

        public partial struct XrCameraDeviceBD
        {
        }

        public partial struct XrCameraCaptureSessionBD
        {
        }
        public enum XrCameraPropertyTypeBD : uint
        {
            XR_CAMERA_PROPERTY_TYPE_FACING_BD = 1,
            XR_CAMERA_PROPERTY_TYPE_POSITION_BD = 2,
            XR_CAMERA_PROPERTY_TYPE_CAMERA_TYPE_BD = 3,
            XR_CAMERA_PROPERTY_TYPE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrCameraFacingBD : uint
        {
            XR_CAMERA_FACING_WORLD_BD = 1,
            XR_CAMERA_FACING_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrCameraPositionBD : uint
        {
            XR_CAMERA_POSITION_UNSPECIFIED_BD = 1,
            XR_CAMERA_POSITION_LEFT_BD = 2,
            XR_CAMERA_POSITION_RIGHT_BD = 3,
            XR_CAMERA_POSITION_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrCameraTypeBD : uint
        {
            XR_CAMERA_TYPE_PASSTHROUGH_COLOR_BD = 1,
            XR_CAMERA_TYPE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrCameraCapabilityTypeBD : uint
        {
            XR_CAMERA_CAPABILITY_TYPE_IMAGE_RESOLUTION_AND_FRAME_RATE_BD = 1,
            XR_CAMERA_CAPABILITY_TYPE_IMAGE_FORMAT_BD = 2,
            XR_CAMERA_CAPABILITY_TYPE_DATA_TRANSFER_TYPE_BD = 3,
            XR_CAMERA_CAPABILITY_TYPE_CAMERA_MODEL_BD = 4,
            XR_CAMERA_CAPABILITY_TYPE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrCameraDataTransferTypeBD : uint
        {
            XR_CAMERA_DATA_TRANSFER_TYPE_RAW_BUFFER_BD = 1,
            XR_CAMERA_DATA_TRANSFER_TYPE_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrCameraImageFormatBD : uint
        {
            XR_CAMERA_IMAGE_FORMAT_RGBA_8888_BD = 1,
            XR_CAMERA_IMAGE_FORMAT_MAX_ENUM_BD = 0x7FFFFFFF,
        }
        public enum XrCameraModelBD : uint
        {
            XR_CAMERA_MODEL_PINHOLE_BD = 1,
            XR_CAMERA_MODEL_MAX_ENUM_BD = 0x7FFFFFFF,
        }

        public unsafe partial struct XrCameraPropertyBaseHeaderBD
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrCameraPropertiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint propertyCount;

            public XrCameraPropertyBaseHeaderBD** properties;
        }

        public unsafe partial struct XrCameraCapabilityBaseHeaderBD
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrCameraCapabilitiesBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint capabilityCount;

            public XrCameraCapabilityBaseHeaderBD** capabilities;
        }

        public unsafe partial struct XrAvailableCamerasEnumerateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public XrCameraPropertiesBD* properties;
            public XrCameraCapabilitiesBD* capabilities;
        }

        public unsafe partial struct XrAvailableCameraBD
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong cameraId;
        }

        public unsafe partial struct XrCameraPropertyTypesEnumerateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong cameraId;
        }

        public unsafe partial struct XrCameraPropertyTypesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint propertyTypeCapacityInput;
            public uint propertyTypeCountOutput;

            public XrCameraPropertyTypeBD* propertyTypes;
        }

        public unsafe partial struct XrCameraPropertiesGetInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong cameraId;
        }

        public unsafe partial struct XrCameraPropertyFacingBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrCameraFacingBD facing;
        }

        public unsafe partial struct XrCameraPropertyPositionBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrCameraPositionBD position;
        }

        public unsafe partial struct XrCameraPropertyCameraTypeBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrCameraTypeBD cameraType;
        }

        public unsafe partial struct XrCameraCapabilityTypesEnumerateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong cameraId;
        }

        public unsafe partial struct XrCameraCapabilityTypesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint capabilityTypeCapacityInput;
            public uint capabilityTypeCountOutput;

            public XrCameraCapabilityTypeBD* capabilityTypes;
        }

        public unsafe partial struct XrCameraSupportedCapabilitiesGetInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong id;
        }

        public unsafe partial struct XrCameraSupportedCapabilityBaseHeaderBD
        {
            public Types.XrStructureType type;

            public void* next;
        }

        public unsafe partial struct XrCameraSupportedCapabilitiesBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint capabilityCount;

            public XrCameraSupportedCapabilityBaseHeaderBD** capabilities;
        }

        public partial struct XrCameraImageResolutionAndFrameRateBD
        {
            public XrExtent2Di resolution;
            public uint frameRate;
        }

        public unsafe partial struct XrCameraSupportedCapabilityImageResolutionAndFrameRateBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint resolutionAndFrameRateCapacityInput;
            public uint resolutionAndFrameRateCountOutput;

            public XrCameraImageResolutionAndFrameRateBD* resolutionAndFrameRates;
        }

        public unsafe partial struct XrCameraCapabilityImageResolutionAndFrameRateBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrExtent2Di resolution;
            public uint frameRate;
        }

        public unsafe partial struct XrCameraSupportedCapabilityDataTransferTypeBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint transferTypeCapacityInput;
            public uint transferTypeCountOutput;

            public XrCameraDataTransferTypeBD* transferTypes;
        }

        public unsafe partial struct XrCameraCapabilityDataTransferTypeBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrCameraDataTransferTypeBD transferType;
        }

        public unsafe partial struct XrCameraSupportedCapabilityImageFormatBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint formatCapacityInput;
            public uint formatCountOutput;

            public XrCameraImageFormatBD* formats;
        }

        public unsafe partial struct XrCameraCapabilityImageFormatBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrCameraImageFormatBD format;
        }

        public unsafe partial struct XrCameraSupportedCapabilityCameraModelBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint modelCapacityInput;
            public uint modelCountOutput;

            public XrCameraModelBD* models;
        }

        public unsafe partial struct XrCameraCapabilityCameraModelBD
        {
            public Types.XrStructureType type;
            public void* next;

            public XrCameraModelBD model;
        }

        public unsafe partial struct XrCameraDeviceCreateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong cameraId;
        }

        public unsafe partial struct XrCreateCameraDeviceCompletionBD
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public XrCameraDeviceBD* device;
        }

        public unsafe partial struct XrCameraCaptureSessionCreateInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public XrCameraDeviceBD* camera;
            public uint configCount;
            public XrCameraCapabilityBaseHeaderBD** configs;
        }

        public unsafe partial struct XrCreateCameraCaptureSessionCompletionBD
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public XrCameraCaptureSessionBD* captureSession;
        }

        public unsafe partial struct XrCameraIntrinsicsBD
        {
            public Types.XrStructureType type;

            public void* next;

            public XrVector2f focalLength;

            public XrVector2f principalPoint;

            public XrVector2f fov;
        }

        public unsafe partial struct XrCameraExtrinsicsBD
        {
            public Types.XrStructureType type;

            public void* next;

            public XrPosef pose;
        }

        public unsafe partial struct XrCameraCaptureBeginInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrCameraImageAcquireInfoBD
        {
            public Types.XrStructureType type;
            public void* next;
            public long lastCaptureTime;
        }

        public unsafe partial struct XrCameraImageBD
        {
            public Types.XrStructureType type;
            public void* next;
            public uint available;
            public long captureTime;
            public ulong imageId;
        }

        public unsafe partial struct XrCameraImageDataBaseHeaderBD
        {
            public Types.XrStructureType type;

            public void* next;
        }

        public unsafe partial struct XrCameraImageDataRawBufferBD
        {
            public Types.XrStructureType type;

            public void* next;
            public uint width;
            public uint height;
            public uint stride;
            public uint bytesPerPixel;
            public uint pixelStride;
            public uint bufferSize;
            public byte* buffer;
        }

        public unsafe partial struct XrSpatialBoundsSpherefANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;
            public long time;

            public XrSpheref sphere;
        }

        public unsafe partial struct XrSpatialBoundsBoxfANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;
            public long time;

            public XrBoxf box;
        }

        public unsafe partial struct XrSpatialBoundsFrustumfANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;
            public long time;

            public XrFrustumf frustum;
        }

        public unsafe partial struct XrSpatialCapabilityConfigurationAnchorEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialCapabilityEXT capability;
            public uint enabledComponentCount;
            public XrSpatialComponentTypeEXT* enabledComponents;
        }

        public unsafe partial struct XrSpatialComponentAnchorListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint locationCount;

            public XrPosef* locations;
        }

        public unsafe partial struct XrSpatialAnchorCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr baseSpace;
            public long time;

            public XrPosef pose;
        }

        public partial struct XrSpatialPersistenceContextEXT
        {
        }
        public enum XrSpatialPersistenceScopeEXT : uint
        {
            XR_SPATIAL_PERSISTENCE_SCOPE_SYSTEM_MANAGED_EXT = 1,
            XR_SPATIAL_PERSISTENCE_SCOPE_LOCAL_ANCHORS_EXT = 1000781000,
            XR_SPATIAL_PERSISTENCE_SCOPE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public enum XrSpatialPersistenceContextResultEXT
        {
            XR_SPATIAL_PERSISTENCE_CONTEXT_RESULT_SUCCESS_EXT = 0,
            XR_SPATIAL_PERSISTENCE_CONTEXT_RESULT_ENTITY_NOT_TRACKING_EXT = -1000781001,
            XR_SPATIAL_PERSISTENCE_CONTEXT_RESULT_PERSIST_UUID_NOT_FOUND_EXT = -1000781002,
            XR_SPATIAL_PERSISTENCE_CONTEXT_RESULT_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrSpatialPersistenceStateEXT : uint
        {
            XR_SPATIAL_PERSISTENCE_STATE_LOADED_EXT = 1,
            XR_SPATIAL_PERSISTENCE_STATE_NOT_FOUND_EXT = 2,
            XR_SPATIAL_PERSISTENCE_STATE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpatialPersistenceContextCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialPersistenceScopeEXT scope;
        }

        public unsafe partial struct XrCreateSpatialPersistenceContextCompletionEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;

            public XrSpatialPersistenceContextResultEXT createResult;
            public XrSpatialPersistenceContextEXT* persistenceContext;
        }

        public unsafe partial struct XrSpatialContextPersistenceConfigEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint persistenceContextCount;
            public XrSpatialPersistenceContextEXT** persistenceContexts;
        }

        public unsafe partial struct XrSpatialDiscoveryPersistenceUuidFilterEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint persistedUuidCount;
            public XrUuid* persistedUuids;
        }

        public partial struct XrSpatialPersistenceDataEXT
        {
            public XrUuid persistUuid;

            public XrSpatialPersistenceStateEXT persistState;
        }

        public unsafe partial struct XrSpatialComponentPersistenceListEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint persistDataCount;

            public XrSpatialPersistenceDataEXT* persistData;
        }
        public enum XrHapticParametricStreamFrameTypeEXT : uint
        {
            XR_HAPTIC_PARAMETRIC_STREAM_FRAME_TYPE_NONE_EXT = 0,
            XR_HAPTIC_PARAMETRIC_STREAM_FRAME_TYPE_FIRST_FRAME_EXT = 1,
            XR_HAPTIC_PARAMETRIC_STREAM_FRAME_TYPE_INTERMEDIATE_FRAME_EXT = 2,
            XR_HAPTIC_PARAMETRIC_STREAM_FRAME_TYPE_LAST_FRAME_EXT = 3,
            XR_HAPTIC_PARAMETRIC_STREAM_FRAME_TYPE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrHapticParametricPropertiesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public long idealFrameSubmissionRate;
            public long minimumFirstFrameDuration;

            public float minFrequencyHz;

            public float maxFrequencyHz;
        }

        public partial struct XrHapticParametricPointEXT
        {
            public long time;

            public float value;
        }

        public partial struct XrHapticParametricTransientEXT
        {
            public long time;

            public float amplitude;

            public float frequency;
        }

        public unsafe partial struct XrHapticParametricVibrationEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint amplitudePointCount;
            public XrHapticParametricPointEXT* amplitudePoints;
            public uint frequencyPointCount;
            public XrHapticParametricPointEXT* frequencyPoints;
            public uint transientCount;
            public XrHapticParametricTransientEXT* transients;

            public float minFrequencyHz;

            public float maxFrequencyHz;

            public XrHapticParametricStreamFrameTypeEXT streamFrameType;
        }

        public unsafe partial struct XrSystemHapticParametricPropertiesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsParametricHaptics;
        }
        public enum XrColorSpaceSONY : uint
        {
            XR_COLOR_SPACE_SRGB_NONLINEAR_SONY = 0,
            XR_COLOR_SPACE_DISPLAY_P3_LINEAR_SONY = 1,
            XR_COLOR_SPACE_DISPLAY_P3_NONLINEAR_SONY = 2,
            XR_COLOR_SPACE_DCI_P3_LINEAR_SONY = 3,
            XR_COLOR_SPACE_DCI_P3_NONLINEAR_SONY = 4,
            XR_COLOR_SPACE_EXTENDED_SRGB_LINEAR_SONY = 5,
            XR_COLOR_SPACE_BT709_LINEAR_SONY = 6,
            XR_COLOR_SPACE_BT709_NONLINEAR_SONY = 7,
            XR_COLOR_SPACE_BT2020_LINEAR_SONY = 8,
            XR_COLOR_SPACE_BT2020_PQ_SONY = 9,
            XR_COLOR_SPACE_BT2020_HLG_SONY = 10,
            XR_COLOR_SPACE_MAX_ENUM_SONY = 0x7FFFFFFF,
        }

        public unsafe partial struct XrColorSpacesEnumerateInfoSONY
        {
            public Types.XrStructureType type;
            public void* next;
            public long format;
        }

        public unsafe partial struct XrSwapchainCreateInfoColorSpaceSONY
        {
            public Types.XrStructureType type;
            public void* next;

            public XrColorSpaceSONY colorSpace;
        }

        public partial struct XrXYColorSONY
        {
            public float x;

            public float y;
        }

        public unsafe partial struct XrHdrMetadataSONY
        {
            public Types.XrStructureType type;
            public void* next;

            public XrXYColorSONY displayPrimaryRed;

            public XrXYColorSONY displayPrimaryGreen;

            public XrXYColorSONY displayPrimaryBlue;

            public XrXYColorSONY whitePoint;

            public float maxLuminance;

            public float minLuminance;

            public float maxContentLightLevel;

            public float maxFrameAverageLightLevel;
        }

        public unsafe partial struct XrSpatialEntityPersistInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContextEXT* spatialContext;
            public ulong spatialEntityId;
        }

        public unsafe partial struct XrPersistSpatialEntityCompletionEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;

            public XrSpatialPersistenceContextResultEXT persistResult;

            public XrUuid persistUuid;
        }

        public unsafe partial struct XrSpatialEntityUnpersistInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrUuid persistUuid;
        }

        public unsafe partial struct XrUnpersistSpatialEntityCompletionEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;

            public XrSpatialPersistenceContextResultEXT unpersistResult;
        }

        public partial struct XrSpatialImageTrackingDatabaseEXT
        {
        }
        public enum XrSpatialReferenceImageFormatEXT : uint
        {
            XR_SPATIAL_REFERENCE_IMAGE_FORMAT_RGBA_8888_EXT = 1,
            XR_SPATIAL_REFERENCE_IMAGE_FORMAT_RGB_888_EXT = 2,
            XR_SPATIAL_REFERENCE_IMAGE_FORMAT_YUV_420_888_EXT = 3,
            XR_SPATIAL_REFERENCE_IMAGE_FORMAT_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpatialReferenceImagePlaneEXT
        {
            public uint bufferSize;
            public byte* buffer;
            public uint rowStride;
            public uint pixelStride;
        }

        public unsafe partial struct XrSpatialReferenceImageEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint width;
            public uint height;

            public XrSpatialReferenceImageFormatEXT format;
            public uint planeCount;
            public XrSpatialReferenceImagePlaneEXT* planes;
        }

        public unsafe partial struct XrSpatialImageStaticOptimizationEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint optimizeForStaticImage;
        }

        public unsafe partial struct XrSpatialImageSizeEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public float physicalWidth;
        }

        public unsafe partial struct XrSpatialCapabilityConfigurationImageTrackingEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialCapabilityEXT capability;
            public uint enabledComponentCount;
            public XrSpatialComponentTypeEXT* enabledComponents;
            public uint imageTrackingDatabaseCount;
            public XrSpatialImageTrackingDatabaseEXT** imageTrackingDatabases;
        }

        public unsafe partial struct XrSpatialImageTrackingDatabaseCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint spatialReferenceImageCount;
            public XrSpatialReferenceImageEXT* spatialReferenceImages;
        }

        public unsafe partial struct XrSpatialImage2DDataEXT
        {
            public XrSpatialImageTrackingDatabaseEXT* imageTrackingDatabase;
            public uint referenceImageIndex;
        }

        public unsafe partial struct XrSpatialComponentImage2DListEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint imageCount;

            public XrSpatialImage2DDataEXT* images;
        }

        public unsafe partial struct XrCreateSpatialImageTrackingDatabaseCompletionEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public XrSpatialImageTrackingDatabaseEXT* database;
        }
        public enum XrSpatialObjectSemanticLabelANDROID : uint
        {
            XR_SPATIAL_OBJECT_SEMANTIC_LABEL_UNCATEGORIZED_ANDROID = 0,
            XR_SPATIAL_OBJECT_SEMANTIC_LABEL_KEYBOARD_ANDROID = 1,
            XR_SPATIAL_OBJECT_SEMANTIC_LABEL_MOUSE_ANDROID = 2,
            XR_SPATIAL_OBJECT_SEMANTIC_LABEL_LAPTOP_BASE_ANDROID = 3,
            XR_SPATIAL_OBJECT_SEMANTIC_LABEL_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSpatialCapabilityConfigurationObjectTrackingANDROID
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialCapabilityEXT capability;
            public uint enabledComponentCount;
            public XrSpatialComponentTypeEXT* enabledComponents;
            public uint activeSemanticLabelCount;
            public XrSpatialObjectSemanticLabelANDROID* activeSemanticLabels;
        }

        public unsafe partial struct XrSpatialComponentObjectSemanticLabelListANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint semanticLabelCount;

            public XrSpatialObjectSemanticLabelANDROID* semanticLabels;
        }

        public partial struct XrSpatialRaycastResultDataANDROID
        {
            public XrPosef hitPose;

            public float distanceSquared;
        }

        public unsafe partial struct XrSpatialCapabilityConfigurationDepthRaycastANDROID
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialCapabilityEXT capability;
            public uint enabledComponentCount;
            public XrSpatialComponentTypeEXT* enabledComponents;
        }

        public unsafe partial struct XrSpatialRaycastInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;
            public long time;

            public XrVector3f origin;

            public XrVector3f direction;

            public float maxDistance;
        }

        public unsafe partial struct XrSpatialComponentRaycastResultListANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint raycastResultCount;

            public XrSpatialRaycastResultDataANDROID* raycastResults;
        }

        public unsafe partial struct XrSpatialRaycastSnapshotCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public uint componentTypeCount;
            public XrSpatialComponentTypeEXT* componentTypes;
            public XrSpatialRaycastInfoANDROID* raycastInfo;
        }

        public enum XrGoogleCloudAuthErrorANDROID
        {
            XR_GOOGLE_CLOUD_AUTH_ERROR_NONE_ANDROID = 0,
            XR_GOOGLE_CLOUD_AUTH_ERROR_QUOTA_EXCEEDED_ANDROID = -1,
            XR_GOOGLE_CLOUD_AUTH_ERROR_UNREACHABLE_ANDROID = -2,
            XR_GOOGLE_CLOUD_AUTH_ERROR_ANDROID = -3,
            XR_GOOGLE_CLOUD_AUTH_ERROR_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrGoogleCloudAuthInfoBaseHeaderANDROID
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrGoogleCloudAuthInfoApiKeyANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public byte* apiKey;
        }

        public unsafe partial struct XrGoogleCloudAuthInfoTokenANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public byte* authToken;
        }

        public unsafe partial struct XrGoogleCloudAuthInfoKeylessANDROID
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrGoogleCloudAuthErrorResultANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public XrGoogleCloudAuthErrorANDROID error;
        }

        public partial struct XrGeospatialTrackerANDROID
        {
        }
        public enum XrGeospatialTrackerStateANDROID : uint
        {
            XR_GEOSPATIAL_TRACKER_STATE_STOPPED_ANDROID = 0,
            XR_GEOSPATIAL_TRACKER_STATE_RUNNING_ANDROID = 1,
            XR_GEOSPATIAL_TRACKER_STATE_INITIALIZATION_FAILED_ANDROID = 2,
            XR_GEOSPATIAL_TRACKER_STATE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }
        public enum XrVPSAvailabilityANDROID : uint
        {
            XR_VPS_AVAILABILITY_UNAVAILABLE_ANDROID = 1,
            XR_VPS_AVAILABILITY_AVAILABLE_ANDROID = 2,
            XR_VPSAVAILABILITY_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public partial struct XrGeospatialPoseANDROID
        {
            public XrQuaternionf eastUpSouthOrientation;

            public double latitude;

            public double longitude;

            public double altitude;
        }

        public unsafe partial struct XrSystemGeospatialPropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint supportsGeospatial;
        }

        public unsafe partial struct XrGeospatialTrackerCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrEventDataGeospatialTrackerStateChangedANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public XrGeospatialTrackerANDROID* geospatialTracker;

            public XrGeospatialTrackerStateANDROID state;

            public Types.XrResult initializationResult;
            public long time;
        }

        public unsafe partial struct XrGeospatialPoseFromPoseLocateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;
            public long time;

            public XrPosef pose;
        }

        public unsafe partial struct XrGeospatialPoseResultANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong poseFlags;

            public XrGeospatialPoseANDROID geospatialPose;

            public double horizontalAccuracy;

            public double verticalAccuracy;

            public double orientationYawAccuracy;
        }

        public unsafe partial struct XrGeospatialPoseLocateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public IntPtr space;
            public long time;

            public XrGeospatialPoseANDROID geospatialPose;
        }

        public unsafe partial struct XrVPSAvailabilityCheckCompletionANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;

            public XrVPSAvailabilityANDROID availability;
        }

        public unsafe partial struct XrSpatialAnchorParentANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong parentId;
        }

        public unsafe partial struct XrSpatialDiscoveryUniqueEntitiesFilterANDROID
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpatialComponentSubsumedByListANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint subsumedUniqueIdCount;
            public ulong* subsumedUniqueIds;
        }

        public unsafe partial struct XrSpatialAnchorSpaceFromIdCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong anchorEntityId;
        }
        public enum XrSurfaceAnchorTypeANDROID : uint
        {
            XR_SURFACE_ANCHOR_TYPE_TERRAIN_ANDROID = 1,
            XR_SURFACE_ANCHOR_TYPE_ROOFTOP_ANDROID = 2,
            XR_SURFACE_ANCHOR_TYPE_MAX_ENUM_ANDROID = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSystemGeospatialAnchorPropertiesANDROID
        {
            public Types.XrStructureType type;

            public void* next;
            public uint maxSurfaceAnchorCount;
        }

        public unsafe partial struct XrGeospatialTrackerAnchorTrackingInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public uint shouldTrackPlanes;
        }

        public unsafe partial struct XrGeospatialAnchorCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public XrGeospatialTrackerANDROID* geospatialTracker;

            public XrGeospatialPoseANDROID geospatialPose;
        }

        public unsafe partial struct XrSurfaceAnchorCreateInfoANDROID
        {
            public Types.XrStructureType type;
            public void* next;
            public XrGeospatialTrackerANDROID* geospatialTracker;

            public XrSurfaceAnchorTypeANDROID surfaceAnchorType;

            public XrQuaternionf eastUpSouthOrientation;

            public double latitude;

            public double longitude;

            public double altitudeRelativeToSurface;
        }

        public unsafe partial struct XrSurfaceAnchorCreateCompletionANDROID
        {
            public Types.XrStructureType type;

            public void* next;

            public Types.XrResult futureResult;
            public ulong anchorEntityId;
        }

        public partial struct XrSpatialContainerEXT
        {
        }
        public enum XrSpatialContainerGraphicsPresentationEXT : uint
        {
            XR_SPATIAL_CONTAINER_GRAPHICS_PRESENTATION_SELF_RENDERING_EXT = 1000813000,
            XR_SPATIAL_CONTAINER_GRAPHICS_PRESENTATION_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrSpatialContainerBoundsModeEXT : uint
        {
            XR_SPATIAL_CONTAINER_BOUNDS_MODE_BOUNDED_EXT = 1,
            XR_SPATIAL_CONTAINER_BOUNDS_MODE_IMMERSIVE_EXT = 2,
            XR_SPATIAL_CONTAINER_BOUNDS_MODE_MAX_ENUM_EXT = 0x7FFFFFFF,
        }
        public enum XrSpatialContainerVolumeClippingEXT : uint
        {
            XR_SPATIAL_CONTAINER_VOLUME_CLIPPING_NONE_EXT = 0,
            XR_SPATIAL_CONTAINER_VOLUME_CLIPPING_STRICT_EXT = 1,
            XR_SPATIAL_CONTAINER_VOLUME_CLIPPING_MAX_ENUM_EXT = 0x7FFFFFFF,
        }

        public unsafe partial struct XrSessionCreateInfoSpatialContainersEXT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpatialContainerCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialContainerGraphicsPresentationEXT graphicsPresentation;

            public XrExtent3Df suggestedBounds;
        }

        public unsafe partial struct XrSpatialContainerSpaceCreateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContainerEXT* spatialContainer;
        }

        public unsafe partial struct XrEventDataSpatialContainerClosedEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContainerEXT* spatialContainer;
        }

        public unsafe partial struct XrSystemSpatialContainerPropertiesEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint maxSpatialContainerCount;
            public uint supportsBounded;
            public uint supportsImmersive;
        }

        public unsafe partial struct XrSpatialContainerBoundsEXT
        {
            public Types.XrStructureType type;

            public void* next;

            public XrExtent3Df bounds;
            public uint infiniteBounds;
        }

        public unsafe partial struct XrEventDataSpatialContainerBoundsChangedEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContainerEXT* spatialContainer;

            public XrExtent3Df bounds;
            public uint infiniteBounds;

            public XrSpatialContainerBoundsModeEXT boundsMode;
        }

        public unsafe partial struct XrSpatialContainerBoundsGetInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpatialContainerStateGetInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
        }

        public unsafe partial struct XrSpatialContainerVisibleRequestInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint visible;
        }

        public unsafe partial struct XrEventDataSpatialContainerVisibleChangedEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContainerEXT* spatialContainer;
            public uint visible;
        }

        public unsafe partial struct XrEventDataSpatialContainerVisibleRequestDeniedEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContainerEXT* spatialContainer;
        }

        public unsafe partial struct XrEventDataSpatialContainerInteractableChangedEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContainerEXT* spatialContainer;
            public uint interactable;
        }

        public unsafe partial struct XrSpatialContainerBoundsModeRequestInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialContainerBoundsModeEXT boundsMode;
        }

        public unsafe partial struct XrEventDataSpatialContainerBoundsModeRequestDeniedEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContainerEXT* spatialContainer;
        }

        public unsafe partial struct XrSpatialContainerStateEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public uint visible;
            public uint interactable;

            public XrSpatialContainerBoundsModeEXT boundsMode;
        }

        public unsafe partial struct XrSpatialContainerViewLocateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrViewConfigurationType viewConfigurationType;
            public IntPtr space;
            public XrSpatialContainerEXT* spatialContainer;
        }

        public unsafe partial struct XrSpatialContainerViewsLocateInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public long displayTime;
            public uint viewLocateInfoCount;
            public XrSpatialContainerViewLocateInfoEXT* viewLocateInfos;
        }

        public unsafe partial struct XrSpatialContainerViewStateEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong viewStateFlags;

            public XrViewConfigurationType viewConfigurationType;
            public uint shouldSubmitLayers;

            public XrExtent2Di recommendedImageExtent;
        }

        public unsafe partial struct XrSpatialContainerLayerEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContainerEXT* spatialContainer;
            public uint retainPreviousSubmission;
            public uint layerCount;
            public XrCompositionLayerBaseHeader** layers;
        }

        public unsafe partial struct XrSpatialContainerLayerFrameEndInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint containerLayerCount;
            public XrSpatialContainerLayerEXT* containerLayers;
        }

        public unsafe partial struct XrSpatialContainerBeginInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContainerEXT* spatialContainer;

            public XrViewConfigurationType primaryViewConfigurationType;
        }

        public unsafe partial struct XrSpatialContainerEndInfoEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public XrSpatialContainerEXT* spatialContainer;
        }

        public unsafe partial struct XrSpatialContainerCompositionLayerViewConfigurationEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrViewConfigurationType viewConfigurationType;
        }

        public unsafe partial struct XrSpatialContainerLayerVolumeClippingEXT
        {
            public Types.XrStructureType type;
            public void* next;

            public XrSpatialContainerVolumeClippingEXT volumeClipping;
        }

        public unsafe partial struct XrBatteryStateDisplayEXT
        {
            public Types.XrStructureType type;

            public void* next;
            public ulong stateFlags;

            public float batteryLevel;
        }

        public unsafe partial struct XrLoaderInitPropertyValueEXT
        {
            public byte* name;
            public byte* value;
        }

        public unsafe partial struct XrLoaderInitInfoPropertiesEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public uint propertyValueCount;
            public XrLoaderInitPropertyValueEXT* propertyValues;
        }

        public unsafe partial struct XrEventDataViewConfigurationViewsChangedEXT
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong systemId;

            public XrViewConfigurationType viewConfigurationType;
        }
        
        [StructLayout(LayoutKind.Sequential)]
        public unsafe partial struct XrGraphicsRequirementsVulkanKHR {
            public Types.XrStructureType type;
            public IntPtr next;
            public ulong minApiVersionSupported;
            public ulong maxApiVersionSupported;
        }
        
        public struct XrVulkanGraphicsDeviceGetInfoKHR {
            public Types.XrStructureType type;
            public IntPtr next;
            public ulong systemId;
            public IntPtr vulkanInstance;
        }
        
        public unsafe struct XrVulkanInstanceCreateInfoKHR
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong systemId;
            public ulong createFlags;
            public IntPtr pfnGetInstanceProcAddr;
            public void* vulkanCreateInfo;
            public void* vulkanAllocator;
        }
        
        public unsafe struct XrVulkanDeviceCreateInfoKHR
        {
            public Types.XrStructureType type;
            public void* next;
            public ulong systemId;
            public ulong createFlags;
            public IntPtr pfnGetInstanceProcAddr;
            public IntPtr vulkanPhysicalDevice;
            public void* vulkanCreateInfo;
            public void* vulkanAllocator;
        }

        public static unsafe partial class Methods
        {
            public const ulong XR_SPACE_LOCATION_ORIENTATION_VALID_BIT = 0x00000001;
            public const ulong XR_SPACE_LOCATION_POSITION_VALID_BIT = 0x00000002;
            public const ulong XR_SPACE_LOCATION_ORIENTATION_TRACKED_BIT = 0x00000004;
            public const ulong XR_SPACE_LOCATION_POSITION_TRACKED_BIT = 0x00000008;
            public const ulong XR_SPACE_VELOCITY_LINEAR_VALID_BIT = 0x00000001;
            public const ulong XR_SPACE_VELOCITY_ANGULAR_VALID_BIT = 0x00000002;
            public const ulong XR_SWAPCHAIN_CREATE_PROTECTED_CONTENT_BIT = 0x00000001;
            public const ulong XR_SWAPCHAIN_CREATE_STATIC_IMAGE_BIT = 0x00000002;
            public const ulong XR_SWAPCHAIN_USAGE_COLOR_ATTACHMENT_BIT = 0x00000001;
            public const ulong XR_SWAPCHAIN_USAGE_DEPTH_STENCIL_ATTACHMENT_BIT = 0x00000002;
            public const ulong XR_SWAPCHAIN_USAGE_UNORDERED_ACCESS_BIT = 0x00000004;
            public const ulong XR_SWAPCHAIN_USAGE_TRANSFER_SRC_BIT = 0x00000008;
            public const ulong XR_SWAPCHAIN_USAGE_TRANSFER_DST_BIT = 0x00000010;
            public const ulong XR_SWAPCHAIN_USAGE_SAMPLED_BIT = 0x00000020;
            public const ulong XR_SWAPCHAIN_USAGE_MUTABLE_FORMAT_BIT = 0x00000040;
            public const ulong XR_SWAPCHAIN_USAGE_INPUT_ATTACHMENT_BIT_MND = 0x00000080;
            public const ulong XR_SWAPCHAIN_USAGE_INPUT_ATTACHMENT_BIT_KHR = 0x00000080;
            public const ulong XR_COMPOSITION_LAYER_CORRECT_CHROMATIC_ABERRATION_BIT = 0x00000001;
            public const ulong XR_COMPOSITION_LAYER_BLEND_TEXTURE_SOURCE_ALPHA_BIT = 0x00000002;
            public const ulong XR_COMPOSITION_LAYER_UNPREMULTIPLIED_ALPHA_BIT = 0x00000004;
            public const ulong XR_COMPOSITION_LAYER_INVERTED_ALPHA_BIT_EXT = 0x00000008;
            public const ulong XR_VIEW_STATE_ORIENTATION_VALID_BIT = 0x00000001;
            public const ulong XR_VIEW_STATE_POSITION_VALID_BIT = 0x00000002;
            public const ulong XR_VIEW_STATE_ORIENTATION_TRACKED_BIT = 0x00000004;
            public const ulong XR_VIEW_STATE_POSITION_TRACKED_BIT = 0x00000008;
            public const ulong XR_INPUT_SOURCE_LOCALIZED_NAME_USER_PATH_BIT = 0x00000001;
            public const ulong XR_INPUT_SOURCE_LOCALIZED_NAME_INTERACTION_PROFILE_BIT = 0x00000002;
            public const ulong XR_INPUT_SOURCE_LOCALIZED_NAME_COMPONENT_BIT = 0x00000004;

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetInstanceProcAddr( IntPtr instance, byte* name, delegate* unmanaged[Cdecl]<void>* function);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEnumerateApiLayerProperties( uint propertyCapacityInput, uint* propertyCountOutput, XrApiLayerProperties* properties);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetVulkanGraphicsRequirementsKHR(IntPtr instance, ulong systemId, XrGraphicsRequirementsVulkanKHR* graphicsRequirements);
            
            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEnumerateInstanceExtensionProperties( byte* layerName, uint propertyCapacityInput, uint* propertyCountOutput, XrExtensionProperties* properties);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrCreateInstance( XrInstanceCreateInfo* createInfo, IntPtr* instance);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrDestroyInstance( IntPtr instance);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetInstanceProperties( IntPtr instance, XrInstanceProperties* instanceProperties);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrPollEvent( IntPtr instance, XrEventDataBuffer* eventData);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrStructureTypeToString( IntPtr instance, Types.XrStructureType value, byte* buffer);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetSystem( IntPtr instance, XrSystemGetInfo* getInfo, ulong* systemId);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetSystemProperties( IntPtr instance, ulong systemId, XrSystemProperties* properties);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEnumerateEnvironmentBlendModes( IntPtr instance, ulong systemId, XrViewConfigurationType viewConfigurationType, uint environmentBlendModeCapacityInput, uint* environmentBlendModeCountOutput, XrEnvironmentBlendMode* environmentBlendModes);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrCreateSession( IntPtr instance, XrSessionCreateInfo* createInfo, IntPtr* session);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrDestroySession( IntPtr session);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEnumerateReferenceSpaces( IntPtr session, uint spaceCapacityInput, uint* spaceCountOutput, XrReferenceSpaceType* spaces);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrCreateReferenceSpace( IntPtr session, XrReferenceSpaceCreateInfo* createInfo, IntPtr* space);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetReferenceSpaceBoundsRect( IntPtr session, XrReferenceSpaceType referenceSpaceType, XrExtent2Df* bounds);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrCreateActionSpace( IntPtr session, XrActionSpaceCreateInfo* createInfo, IntPtr* space);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrLocateSpace( IntPtr space, IntPtr baseSpace, long time, XrSpaceLocation* location);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrDestroySpace( IntPtr space);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEnumerateViewConfigurations( IntPtr instance, ulong systemId, uint viewConfigurationTypeCapacityInput, uint* viewConfigurationTypeCountOutput, XrViewConfigurationType* viewConfigurationTypes);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetViewConfigurationProperties( IntPtr instance, ulong systemId, XrViewConfigurationType viewConfigurationType, XrViewConfigurationProperties* configurationProperties);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEnumerateViewConfigurationViews( IntPtr instance, ulong systemId, XrViewConfigurationType viewConfigurationType, uint viewCapacityInput, uint* viewCountOutput, XrViewConfigurationView* views);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEnumerateSwapchainFormats( IntPtr session, uint formatCapacityInput, uint* formatCountOutput, long* formats);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrCreateSwapchain( IntPtr session, XrSwapchainCreateInfo* createInfo, IntPtr* swapchain);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEnumerateSwapchainImages( IntPtr swapchain, uint imageCapacityInput, uint* imageCountOutput, IntPtr images);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrAcquireSwapchainImage( IntPtr swapchain, XrSwapchainImageAcquireInfo* acquireInfo, uint* index);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrWaitSwapchainImage( IntPtr swapchain, XrSwapchainImageWaitInfo* waitInfo);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrReleaseSwapchainImage( IntPtr swapchain, XrSwapchainImageReleaseInfo* releaseInfo);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrBeginSession( IntPtr session, XrSessionBeginInfo* beginInfo);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEndSession( IntPtr session);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrRequestExitSession( IntPtr session);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrWaitFrame( IntPtr session, XrFrameWaitInfo* frameWaitInfo, XrFrameState* frameState);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrBeginFrame( IntPtr session, XrFrameBeginInfo* frameBeginInfo);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEndFrame( IntPtr session, XrFrameEndInfo* frameEndInfo);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrLocateViews( IntPtr session, XrViewLocateInfo* viewLocateInfo, XrViewState* viewState, uint viewCapacityInput, uint* viewCountOutput, XrView* views);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrStringToPath( IntPtr instance, byte* pathString, ulong* path);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrPathToString( IntPtr instance, ulong path, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrCreateActionSet( IntPtr instance, XrActionSetCreateInfo* createInfo, IntPtr* actionSet);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrDestroyActionSet( IntPtr actionSet);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrCreateAction( IntPtr actionSet, XrActionCreateInfo* createInfo, IntPtr* action);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrDestroyAction( IntPtr action);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrSuggestInteractionProfileBindings( IntPtr instance, XrInteractionProfileSuggestedBinding* suggestedBindings);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrAttachSessionActionSets( IntPtr session, XrSessionActionSetsAttachInfo* attachInfo);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetCurrentInteractionProfile( IntPtr session, ulong topLevelUserPath, XrInteractionProfileState* interactionProfile);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetActionStateBoolean( IntPtr session, XrActionStateGetInfo* getInfo, XrActionStateBoolean* state);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetActionStateFloat( IntPtr session, XrActionStateGetInfo* getInfo, XrActionStateFloat* state);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetActionStateVector2f( IntPtr session, XrActionStateGetInfo* getInfo, XrActionStateVector2f* state);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetActionStatePose( IntPtr session, XrActionStateGetInfo* getInfo, XrActionStatePose* state);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrSyncActions( IntPtr session, XrActionsSyncInfo* syncInfo);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrEnumerateBoundSourcesForAction( IntPtr session, XrBoundSourcesForActionEnumerateInfo* enumerateInfo, uint sourceCapacityInput, uint* sourceCountOutput, ulong* sources);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrGetInputSourceLocalizedName( IntPtr session, XrInputSourceLocalizedNameGetInfo* getInfo, uint bufferCapacityInput, uint* bufferCountOutput, byte* buffer);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrApplyHapticFeedback( IntPtr session, XrHapticActionInfo* hapticActionInfo, XrHapticBaseHeader* hapticFeedback);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrStopHapticFeedback( IntPtr session, XrHapticActionInfo* hapticActionInfo);

            [DllImport("openxr_loader", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
            public static extern Types.XrResult xrLocateSpaces( IntPtr session, XrSpacesLocateInfo* locateInfo, XrSpaceLocations* spaceLocations);
            public const ulong XR_DEBUG_UTILS_MESSAGE_SEVERITY_VERBOSE_BIT_EXT = 0x00000001;
            public const ulong XR_DEBUG_UTILS_MESSAGE_SEVERITY_INFO_BIT_EXT = 0x00000010;
            public const ulong XR_DEBUG_UTILS_MESSAGE_SEVERITY_WARNING_BIT_EXT = 0x00000100;
            public const ulong XR_DEBUG_UTILS_MESSAGE_SEVERITY_ERROR_BIT_EXT = 0x00001000;
            public const ulong XR_DEBUG_UTILS_MESSAGE_TYPE_GENERAL_BIT_EXT = 0x00000001;
            public const ulong XR_DEBUG_UTILS_MESSAGE_TYPE_VALIDATION_BIT_EXT = 0x00000002;
            public const ulong XR_DEBUG_UTILS_MESSAGE_TYPE_PERFORMANCE_BIT_EXT = 0x00000004;
            public const ulong XR_DEBUG_UTILS_MESSAGE_TYPE_CONFORMANCE_BIT_EXT = 0x00000008;
            public const ulong XR_OVERLAY_MAIN_SESSION_ENABLED_COMPOSITION_LAYER_INFO_DEPTH_BIT_EXTX = 0x00000001;
            public const ulong XR_COMPOSITION_LAYER_IMAGE_LAYOUT_VERTICAL_FLIP_BIT_FB = 0x00000001;
            public const ulong XR_COMPOSITION_LAYER_SECURE_CONTENT_EXCLUDE_LAYER_BIT_FB = 0x00000001;
            public const ulong XR_COMPOSITION_LAYER_SECURE_CONTENT_REPLACE_LAYER_BIT_FB = 0x00000002;
            public const ulong XR_HAND_TRACKING_AIM_COMPUTED_BIT_FB = 0x00000001;
            public const ulong XR_HAND_TRACKING_AIM_VALID_BIT_FB = 0x00000002;
            public const ulong XR_HAND_TRACKING_AIM_INDEX_PINCHING_BIT_FB = 0x00000004;
            public const ulong XR_HAND_TRACKING_AIM_MIDDLE_PINCHING_BIT_FB = 0x00000008;
            public const ulong XR_HAND_TRACKING_AIM_RING_PINCHING_BIT_FB = 0x00000010;
            public const ulong XR_HAND_TRACKING_AIM_LITTLE_PINCHING_BIT_FB = 0x00000020;
            public const ulong XR_HAND_TRACKING_AIM_SYSTEM_GESTURE_BIT_FB = 0x00000040;
            public const ulong XR_HAND_TRACKING_AIM_DOMINANT_HAND_BIT_FB = 0x00000080;
            public const ulong XR_HAND_TRACKING_AIM_MENU_PRESSED_BIT_FB = 0x00000100;
            public const ulong XR_SWAPCHAIN_CREATE_FOVEATION_SCALED_BIN_BIT_FB = 0x00000001;
            public const ulong XR_SWAPCHAIN_CREATE_FOVEATION_FRAGMENT_DENSITY_MAP_BIT_FB = 0x00000002;
            public const ulong XR_KEYBOARD_TRACKING_EXISTS_BIT_FB = 0x00000001;
            public const ulong XR_KEYBOARD_TRACKING_LOCAL_BIT_FB = 0x00000002;
            public const ulong XR_KEYBOARD_TRACKING_REMOTE_BIT_FB = 0x00000004;
            public const ulong XR_KEYBOARD_TRACKING_CONNECTED_BIT_FB = 0x00000008;
            public const ulong XR_KEYBOARD_TRACKING_QUERY_LOCAL_BIT_FB = 0x00000002;
            public const ulong XR_KEYBOARD_TRACKING_QUERY_REMOTE_BIT_FB = 0x00000004;
            public const ulong XR_TRIANGLE_MESH_MUTABLE_BIT_FB = 0x00000001;
            public const ulong XR_PASSTHROUGH_CAPABILITY_BIT_FB = 0x00000001;
            public const ulong XR_PASSTHROUGH_CAPABILITY_COLOR_BIT_FB = 0x00000002;
            public const ulong XR_PASSTHROUGH_CAPABILITY_LAYER_DEPTH_BIT_FB = 0x00000004;
            public const ulong XR_PASSTHROUGH_IS_RUNNING_AT_CREATION_BIT_FB = 0x00000001;
            public const ulong XR_PASSTHROUGH_LAYER_DEPTH_BIT_FB = 0x00000002;
            public const ulong XR_PASSTHROUGH_STATE_CHANGED_REINIT_REQUIRED_BIT_FB = 0x00000001;
            public const ulong XR_PASSTHROUGH_STATE_CHANGED_NON_RECOVERABLE_ERROR_BIT_FB = 0x00000002;
            public const ulong XR_PASSTHROUGH_STATE_CHANGED_RECOVERABLE_ERROR_BIT_FB = 0x00000004;
            public const ulong XR_PASSTHROUGH_STATE_CHANGED_RESTORED_ERROR_BIT_FB = 0x00000008;
            public const ulong XR_RENDER_MODEL_SUPPORTS_GLTF_2_0_SUBSET_1_BIT_FB = 0x00000001;
            public const ulong XR_RENDER_MODEL_SUPPORTS_GLTF_2_0_SUBSET_2_BIT_FB = 0x00000002;
            public const ulong XR_FRAME_END_INFO_PROTECTED_BIT_ML = 0x00000001;
            public const ulong XR_FRAME_END_INFO_VIGNETTE_BIT_ML = 0x00000002;
            public const ulong XR_GLOBAL_DIMMER_FRAME_END_INFO_ENABLED_BIT_ML = 0x00000001;
            public const ulong XR_LOCALIZATION_MAP_ERROR_UNKNOWN_BIT_ML = 0x00000001;
            public const ulong XR_LOCALIZATION_MAP_ERROR_OUT_OF_MAPPED_AREA_BIT_ML = 0x00000002;
            public const ulong XR_LOCALIZATION_MAP_ERROR_LOW_FEATURE_COUNT_BIT_ML = 0x00000004;
            public const ulong XR_LOCALIZATION_MAP_ERROR_EXCESSIVE_MOTION_BIT_ML = 0x00000008;
            public const ulong XR_LOCALIZATION_MAP_ERROR_LOW_LIGHT_BIT_ML = 0x00000010;
            public const ulong XR_LOCALIZATION_MAP_ERROR_HEADPOSE_BIT_ML = 0x00000020;
            public const ulong XR_COMPOSITION_LAYER_SPACE_WARP_INFO_FRAME_SKIP_BIT_FB = 0x00000001;
            public const ulong XR_SEMANTIC_LABELS_SUPPORT_MULTIPLE_SEMANTIC_LABELS_BIT_FB = 0x00000001;
            public const ulong XR_SEMANTIC_LABELS_SUPPORT_ACCEPT_DESK_TO_TABLE_MIGRATION_BIT_FB = 0x00000002;
            public const ulong XR_SEMANTIC_LABELS_SUPPORT_ACCEPT_INVISIBLE_WALL_FACE_BIT_FB = 0x00000004;
            public const ulong XR_DIGITAL_LENS_CONTROL_PROCESSING_DISABLE_BIT_ALMALENCE = 0x00000001;
            public const ulong XR_FOVEATION_EYE_TRACKED_STATE_VALID_BIT_META = 0x00000001;
            public const ulong XR_COMPOSITION_LAYER_SETTINGS_NORMAL_SUPER_SAMPLING_BIT_FB = 0x00000001;
            public const ulong XR_COMPOSITION_LAYER_SETTINGS_QUALITY_SUPER_SAMPLING_BIT_FB = 0x00000002;
            public const ulong XR_COMPOSITION_LAYER_SETTINGS_NORMAL_SHARPENING_BIT_FB = 0x00000004;
            public const ulong XR_COMPOSITION_LAYER_SETTINGS_QUALITY_SHARPENING_BIT_FB = 0x00000008;
            public const ulong XR_COMPOSITION_LAYER_SETTINGS_AUTO_LAYER_FILTER_BIT_META = 0x00000020;
            public const ulong XR_FRAME_SYNTHESIS_INFO_USE_2D_MOTION_VECTOR_BIT_EXT = 0x00000001;
            public const ulong XR_FRAME_SYNTHESIS_INFO_REQUEST_RELAXED_FRAME_INTERVAL_BIT_EXT = 0x00000002;
            public const ulong XR_PASSTHROUGH_PREFERENCE_DEFAULT_TO_ACTIVE_BIT_META = 0x00000001;
            public const ulong XR_VIRTUAL_KEYBOARD_INPUT_STATE_PRESSED_BIT_META = 0x00000001;
            public const ulong XR_EXTERNAL_CAMERA_STATUS_CONNECTED_BIT_OCULUS = 0x00000001;
            public const ulong XR_EXTERNAL_CAMERA_STATUS_CALIBRATING_BIT_OCULUS = 0x00000002;
            public const ulong XR_EXTERNAL_CAMERA_STATUS_CALIBRATION_FAILED_BIT_OCULUS = 0x00000004;
            public const ulong XR_EXTERNAL_CAMERA_STATUS_CALIBRATED_BIT_OCULUS = 0x00000008;
            public const ulong XR_EXTERNAL_CAMERA_STATUS_CAPTURING_BIT_OCULUS = 0x00000010;
            public const ulong XR_PERFORMANCE_METRICS_COUNTER_ANY_VALUE_VALID_BIT_META = 0x00000001;
            public const ulong XR_PERFORMANCE_METRICS_COUNTER_UINT_VALUE_VALID_BIT_META = 0x00000002;
            public const ulong XR_PERFORMANCE_METRICS_COUNTER_FLOAT_VALUE_VALID_BIT_META = 0x00000004;
            public const ulong XR_FOVEATION_DYNAMIC_LEVEL_ENABLED_BIT_HTC = 0x00000001;
            public const ulong XR_FOVEATION_DYNAMIC_CLEAR_FOV_ENABLED_BIT_HTC = 0x00000002;
            public const ulong XR_FOVEATION_DYNAMIC_FOCAL_CENTER_OFFSET_ENABLED_BIT_HTC = 0x00000004;
            public const ulong XR_SPATIAL_MESH_CONFIG_SEMANTIC_BIT_BD = 0x00000001;
            public const ulong XR_SPATIAL_MESH_CONFIG_ALIGN_SEMANTIC_WITH_VERTEX_BIT_BD = 0x00000002;
            public const ulong XR_SPACE_ACCELERATION_LINEAR_VALID_BIT_BD = 0x00000001;
            public const ulong XR_SPACE_ACCELERATION_ANGULAR_VALID_BIT_BD = 0x00000002;
            public const ulong XR_LIGHT_ESTIMATION_CREATE_SPHERICAL_HARMONICS_BIT_BD = 0x00000001;
            public const ulong XR_LIGHT_ESTIMATION_CREATE_ENVIRONMENT_TEXTURE_BIT_BD = 0x00000002;
            public const ulong XR_SOUND_OBSTACLE_ENABLED_BIT_BD = 0x00000001;
            public const ulong XR_SOUND_OBSTACLE_POSE_BIT_BD = 0x00000002;
            public const ulong XR_SOUND_OBSTACLE_MESH_BIT_BD = 0x00000004;
            public const ulong XR_SOUND_OBSTACLE_MATERIALS_BIT_BD = 0x00000008;
            public const ulong XR_SOUND_OBJECT_ENABLED_BIT_BD = 0x00000001;
            public const ulong XR_SOUND_OBJECT_POSE_BIT_BD = 0x00000002;
            public const ulong XR_SOUND_OBJECT_DIRECTIVITY_BIT_BD = 0x00000004;
            public const ulong XR_SOUND_OBJECT_SHAPE_BIT_BD = 0x00000008;
            public const ulong XR_SOUND_OBJECT_MAIN_VOLUME_BIT_BD = 0x00000010;
            public const ulong XR_SOUND_OBJECT_REFLECTION_GAIN_BIT_BD = 0x00000020;
            public const ulong XR_SOUND_OBJECT_ENABLE_DOPPLER_BIT_BD = 0x00000040;
            public const ulong XR_SOUND_OBJECT_DIRECT_SOUND_ATTENUATION_BIT_BD = 0x00000080;
            public const ulong XR_SOUND_OBJECT_INDIRECT_SOUND_ATTENUATION_BIT_BD = 0x00000100;
            public const ulong XR_SOUND_FIELD_ENABLED_BIT_BD = 0x00000001;
            public const ulong XR_SOUND_FIELD_ORIENTATION_BIT_BD = 0x00000002;
            public const ulong XR_SOUND_FIELD_MAIN_VOLUME_BIT_BD = 0x00000004;
            public const ulong XR_SOUND_FIELD_LFE_GAIN_BIT_BD = 0x00000008;
            public const ulong XR_PLANE_DETECTION_CAPABILITY_PLANE_DETECTION_BIT_EXT = 0x00000001;
            public const ulong XR_PLANE_DETECTION_CAPABILITY_PLANE_HOLES_BIT_EXT = 0x00000002;
            public const ulong XR_PLANE_DETECTION_CAPABILITY_SEMANTIC_CEILING_BIT_EXT = 0x00000004;
            public const ulong XR_PLANE_DETECTION_CAPABILITY_SEMANTIC_FLOOR_BIT_EXT = 0x00000008;
            public const ulong XR_PLANE_DETECTION_CAPABILITY_SEMANTIC_WALL_BIT_EXT = 0x00000010;
            public const ulong XR_PLANE_DETECTION_CAPABILITY_SEMANTIC_PLATFORM_BIT_EXT = 0x00000020;
            public const ulong XR_PLANE_DETECTION_CAPABILITY_ORIENTATION_BIT_EXT = 0x00000040;
            public const ulong XR_PLANE_DETECTOR_ENABLE_CONTOUR_BIT_EXT = 0x00000001;
            public const ulong XR_PERFORMANCE_METRICS_COUNTER_ANY_VALUE_VALID_BIT_ANDROID = 0x00000001;
            public const ulong XR_PERFORMANCE_METRICS_COUNTER_UINT_VALUE_VALID_BIT_ANDROID = 0x00000002;
            public const ulong XR_PERFORMANCE_METRICS_COUNTER_FLOAT_VALUE_VALID_BIT_ANDROID = 0x00000004;
            public const ulong XR_WORLD_MESH_DETECTOR_POINT_CLOUD_BIT_ML = 0x00000001;
            public const ulong XR_WORLD_MESH_DETECTOR_COMPUTE_NORMALS_BIT_ML = 0x00000002;
            public const ulong XR_WORLD_MESH_DETECTOR_COMPUTE_CONFIDENCE_BIT_ML = 0x00000004;
            public const ulong XR_WORLD_MESH_DETECTOR_PLANARIZE_BIT_ML = 0x00000008;
            public const ulong XR_WORLD_MESH_DETECTOR_REMOVE_MESH_SKIRT_BIT_ML = 0x00000010;
            public const ulong XR_WORLD_MESH_DETECTOR_INDEX_ORDER_CW_BIT_ML = 0x00000020;
            public const ulong XR_FACIAL_EXPRESSION_BLEND_SHAPE_PROPERTIES_VALID_BIT_ML = 0x00000001;
            public const ulong XR_FACIAL_EXPRESSION_BLEND_SHAPE_PROPERTIES_TRACKED_BIT_ML = 0x00000002;
            public const ulong XR_GEOSPATIAL_POSE_ORIENTATION_VALID_BIT_ANDROID = 0x00000001;
            public const ulong XR_GEOSPATIAL_POSE_POSITION_VALID_BIT_ANDROID = 0x00000002;
            public const ulong XR_BATTERY_STATE_DISPLAY_STATE_VALID_BIT_EXT = 0x00000001;
            public const ulong XR_BATTERY_STATE_DISPLAY_STATE_CHARGING_BIT_EXT = 0x00000002;
            public const ulong XR_BATTERY_STATE_DISPLAY_STATE_PLUGGED_IN_BIT_EXT = 0x00000004;
            public const ulong XR_BATTERY_STATE_DISPLAY_STATE_NO_BATTERY_BIT_EXT = 0x00000008;
            public const int OPENXR_H_ = 1;
            public const int XR_VERSION_1_0 = 1;
            public const int OPENXR_PLATFORM_DEFINES_H_ = 1;
            public const int XR_PTR_SIZE = 8;
            public const int XR_CPP11_ENABLED = 1;
            public const int XR_CPP_NULLPTR_SUPPORTED = 1;
            public const ulong XR_CURRENT_API_VERSION = ((((1) & 0xffffUL) << 48) | (((1) & 0xffffUL) << 32) | ((63) & 0xffffffffUL));
            public const ulong XR_API_VERSION_1_0 = ((((1) & 0xffffUL) << 48) | (((0) & 0xffffUL) << 32) | (((uint)((ulong)(((((1) & 0xffffUL) << 48) | (((1) & 0xffffUL) << 32) | ((63) & 0xffffffffUL))) & 0xffffffffUL)) & 0xffffffffUL));
            public const int XR_MIN_COMPOSITION_LAYERS_SUPPORTED = 16;
            public const int XR_NULL_SYSTEM_ID = 0;
            public const int XR_NULL_PATH = 0;
            public const int XR_NO_DURATION = 0;
            public const long XR_INFINITE_DURATION = 0x7fffffffffffffffL;
            public const int XR_MIN_HAPTIC_DURATION = -1;
            public const int XR_FREQUENCY_UNSPECIFIED = 0;
            public static nuint XR_MAX_EVENT_DATA_SIZE => unchecked((nuint)((uint)(sizeof(XrEventDataBuffer))));
            public const int XR_EXTENSION_ENUM_BASE = 1000000000;
            public const int XR_EXTENSION_ENUM_STRIDE = 1000;
            public const int XR_TRUE = 1;
            public const int XR_FALSE = 0;
            public const int XR_MAX_EXTENSION_NAME_SIZE = 128;
            public const int XR_MAX_API_LAYER_NAME_SIZE = 256;
            public const int XR_MAX_API_LAYER_DESCRIPTION_SIZE = 256;
            public const int XR_MAX_SYSTEM_NAME_SIZE = 256;
            public const int XR_MAX_APPLICATION_NAME_SIZE = 128;
            public const int XR_MAX_ENGINE_NAME_SIZE = 128;
            public const int XR_MAX_RUNTIME_NAME_SIZE = 128;
            public const int XR_MAX_PATH_LENGTH = 256;
            public const int XR_MAX_STRUCTURE_NAME_SIZE = 64;
            public const int XR_MAX_RESULT_STRING_SIZE = 64;
            public const int XR_MAX_ACTION_SET_NAME_SIZE = 64;
            public const int XR_MAX_LOCALIZED_ACTION_SET_NAME_SIZE = 128;
            public const int XR_MAX_ACTION_NAME_SIZE = 64;
            public const int XR_MAX_LOCALIZED_ACTION_NAME_SIZE = 128;
            public const int XR_VERSION_1_1 = 1;
            public const ulong XR_API_VERSION_1_1 = ((((1) & 0xffffUL) << 48) | (((1) & 0xffffUL) << 32) | (((uint)((ulong)(((((1) & 0xffffUL) << 48) | (((1) & 0xffffUL) << 32) | ((63) & 0xffffffffUL))) & 0xffffffffUL)) & 0xffffffffUL));
            public const int XR_UUID_SIZE = 16;
            public const int XR_KHR_composition_layer_cube = 1;
            public const int XR_KHR_composition_layer_cube_SPEC_VERSION = 8;
            public static ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_CUBE_EXTENSION_NAME => "XR_KHR_composition_layer_cube"u8;
            public const int XR_KHR_composition_layer_depth = 1;
            public const int XR_KHR_composition_layer_depth_SPEC_VERSION = 6;
            public static ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_DEPTH_EXTENSION_NAME => "XR_KHR_composition_layer_depth"u8;
            public const int XR_KHR_composition_layer_cylinder = 1;
            public const int XR_KHR_composition_layer_cylinder_SPEC_VERSION = 4;
            public static ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_CYLINDER_EXTENSION_NAME => "XR_KHR_composition_layer_cylinder"u8;
            public const int XR_KHR_composition_layer_equirect = 1;
            public const int XR_KHR_composition_layer_equirect_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_EQUIRECT_EXTENSION_NAME => "XR_KHR_composition_layer_equirect"u8;
            public const int XR_KHR_visibility_mask = 1;
            public const int XR_KHR_visibility_mask_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_KHR_VISIBILITY_MASK_EXTENSION_NAME => "XR_KHR_visibility_mask"u8;
            public const int XR_KHR_composition_layer_color_scale_bias = 1;
            public const int XR_KHR_composition_layer_color_scale_bias_SPEC_VERSION = 5;
            public static ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_COLOR_SCALE_BIAS_EXTENSION_NAME => "XR_KHR_composition_layer_color_scale_bias"u8;
            public const int XR_KHR_loader_init = 1;
            public const int XR_KHR_loader_init_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_KHR_LOADER_INIT_EXTENSION_NAME => "XR_KHR_loader_init"u8;
            public const int XR_KHR_composition_layer_equirect2 = 1;
            public const int XR_KHR_composition_layer_equirect2_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_KHR_COMPOSITION_LAYER_EQUIRECT2_EXTENSION_NAME => "XR_KHR_composition_layer_equirect2"u8;
            public const int XR_KHR_binding_modification = 1;
            public const int XR_KHR_binding_modification_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_KHR_BINDING_MODIFICATION_EXTENSION_NAME => "XR_KHR_binding_modification"u8;
            public const int XR_KHR_extended_struct_name_lengths = 1;
            public const int XR_KHR_extended_struct_name_lengths_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_KHR_EXTENDED_STRUCT_NAME_LENGTHS_EXTENSION_NAME => "XR_KHR_extended_struct_name_lengths"u8;
            public const int XR_MAX_STRUCTURE_NAME_SIZE_EXTENDED_KHR = 256;
            public const int XR_KHR_swapchain_usage_input_attachment_bit = 1;
            public const int XR_KHR_swapchain_usage_input_attachment_bit_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_KHR_SWAPCHAIN_USAGE_INPUT_ATTACHMENT_BIT_EXTENSION_NAME => "XR_KHR_swapchain_usage_input_attachment_bit"u8;
            public const int XR_KHR_locate_spaces = 1;
            public const int XR_KHR_locate_spaces_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_KHR_LOCATE_SPACES_EXTENSION_NAME => "XR_KHR_locate_spaces"u8;
            public const int XR_KHR_maintenance1 = 1;
            public const int XR_KHR_maintenance1_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_KHR_MAINTENANCE1_EXTENSION_NAME => "XR_KHR_maintenance1"u8;
            public const int XR_KHR_generic_controller = 1;
            public const int XR_KHR_generic_controller_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_KHR_GENERIC_CONTROLLER_EXTENSION_NAME => "XR_KHR_generic_controller"u8;
            public const int XR_KHR_extended_result_name_lengths = 1;
            public const int XR_KHR_extended_result_name_lengths_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_KHR_EXTENDED_RESULT_NAME_LENGTHS_EXTENSION_NAME => "XR_KHR_extended_result_name_lengths"u8;
            public const int XR_MAX_RESULT_STRING_SIZE_EXTENDED_KHR = 256;
            public const int XR_EXT_performance_settings = 1;
            public const int XR_EXT_performance_settings_SPEC_VERSION = 4;
            public static ReadOnlySpan<byte> XR_EXT_PERFORMANCE_SETTINGS_EXTENSION_NAME => "XR_EXT_performance_settings"u8;
            public const int XR_EXT_thermal_query = 1;
            public const int XR_EXT_thermal_query_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_EXT_THERMAL_QUERY_EXTENSION_NAME => "XR_EXT_thermal_query"u8;
            public const int XR_EXT_debug_utils = 1;
            public const int XR_EXT_debug_utils_SPEC_VERSION = 5;
            public static ReadOnlySpan<byte> XR_EXT_DEBUG_UTILS_EXTENSION_NAME => "XR_EXT_debug_utils"u8;
            public const int XR_EXT_eye_gaze_interaction = 1;
            public const int XR_EXT_eye_gaze_interaction_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_EXT_EYE_GAZE_INTERACTION_EXTENSION_NAME => "XR_EXT_eye_gaze_interaction"u8;
            public const int XR_EXTX_overlay = 1;
            public const int XR_EXTX_overlay_SPEC_VERSION = 5;
            public static ReadOnlySpan<byte> XR_EXTX_OVERLAY_EXTENSION_NAME => "XR_EXTX_overlay"u8;
            public const int XR_VARJO_quad_views = 1;
            public const int XR_VARJO_quad_views_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_VARJO_QUAD_VIEWS_EXTENSION_NAME => "XR_VARJO_quad_views"u8;
            public const int XR_MSFT_unbounded_reference_space = 1;
            public const int XR_MSFT_unbounded_reference_space_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_MSFT_UNBOUNDED_REFERENCE_SPACE_EXTENSION_NAME => "XR_MSFT_unbounded_reference_space"u8;
            public const int XR_MSFT_spatial_anchor = 1;
            public const int XR_MSFT_spatial_anchor_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_MSFT_SPATIAL_ANCHOR_EXTENSION_NAME => "XR_MSFT_spatial_anchor"u8;
            public const int XR_FB_composition_layer_image_layout = 1;
            public const int XR_FB_composition_layer_image_layout_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_COMPOSITION_LAYER_IMAGE_LAYOUT_EXTENSION_NAME => "XR_FB_composition_layer_image_layout"u8;
            public const int XR_FB_composition_layer_alpha_blend = 1;
            public const int XR_FB_composition_layer_alpha_blend_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_FB_COMPOSITION_LAYER_ALPHA_BLEND_EXTENSION_NAME => "XR_FB_composition_layer_alpha_blend"u8;
            public const int XR_MND_headless = 1;
            public const int XR_MND_headless_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_MND_HEADLESS_EXTENSION_NAME => "XR_MND_headless"u8;
            public const int XR_OCULUS_android_session_state_enable = 1;
            public const int XR_OCULUS_android_session_state_enable_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_OCULUS_ANDROID_SESSION_STATE_ENABLE_EXTENSION_NAME => "XR_OCULUS_android_session_state_enable"u8;
            public const int XR_EXT_view_configuration_depth_range = 1;
            public const int XR_EXT_view_configuration_depth_range_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_VIEW_CONFIGURATION_DEPTH_RANGE_EXTENSION_NAME => "XR_EXT_view_configuration_depth_range"u8;
            public const int XR_EXT_conformance_automation = 1;
            public const int XR_EXT_conformance_automation_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_EXT_CONFORMANCE_AUTOMATION_EXTENSION_NAME => "XR_EXT_conformance_automation"u8;
            public const int XR_MSFT_spatial_graph_bridge = 1;
            public const int XR_GUID_SIZE_MSFT = 16;
            public const int XR_MSFT_spatial_graph_bridge_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_MSFT_SPATIAL_GRAPH_BRIDGE_EXTENSION_NAME => "XR_MSFT_spatial_graph_bridge"u8;
            public const int XR_MSFT_hand_interaction = 1;
            public const int XR_MSFT_hand_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_MSFT_HAND_INTERACTION_EXTENSION_NAME => "XR_MSFT_hand_interaction"u8;
            public const int XR_EXT_hand_tracking = 1;
            public const int XR_HAND_JOINT_COUNT_EXT = 26;
            public const int XR_EXT_hand_tracking_SPEC_VERSION = 4;
            public static ReadOnlySpan<byte> XR_EXT_HAND_TRACKING_EXTENSION_NAME => "XR_EXT_hand_tracking"u8;
            public const int XR_MSFT_hand_tracking_mesh = 1;
            public const int XR_MSFT_hand_tracking_mesh_SPEC_VERSION = 4;
            public static ReadOnlySpan<byte> XR_MSFT_HAND_TRACKING_MESH_EXTENSION_NAME => "XR_MSFT_hand_tracking_mesh"u8;
            public const int XR_MSFT_secondary_view_configuration = 1;
            public const int XR_MSFT_secondary_view_configuration_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_MSFT_SECONDARY_VIEW_CONFIGURATION_EXTENSION_NAME => "XR_MSFT_secondary_view_configuration"u8;
            public const int XR_MSFT_first_person_observer = 1;
            public const int XR_MSFT_first_person_observer_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_MSFT_FIRST_PERSON_OBSERVER_EXTENSION_NAME => "XR_MSFT_first_person_observer"u8;
            public const int XR_MSFT_controller_model = 1;
            public const int XR_NULL_CONTROLLER_MODEL_KEY_MSFT = 0;
            public const int XR_MAX_CONTROLLER_MODEL_NODE_NAME_SIZE_MSFT = 64;
            public const int XR_MSFT_controller_model_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_MSFT_CONTROLLER_MODEL_EXTENSION_NAME => "XR_MSFT_controller_model"u8;
            public const int XR_EXT_win32_appcontainer_compatible = 1;
            public const int XR_EXT_win32_appcontainer_compatible_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_WIN32_APPCONTAINER_COMPATIBLE_EXTENSION_NAME => "XR_EXT_win32_appcontainer_compatible"u8;
            public const int XR_EPIC_view_configuration_fov = 1;
            public const int XR_EPIC_view_configuration_fov_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_EPIC_VIEW_CONFIGURATION_FOV_EXTENSION_NAME => "XR_EPIC_view_configuration_fov"u8;
            public const int XR_MSFT_composition_layer_reprojection = 1;
            public const int XR_MSFT_composition_layer_reprojection_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_MSFT_COMPOSITION_LAYER_REPROJECTION_EXTENSION_NAME => "XR_MSFT_composition_layer_reprojection"u8;
            public const int XR_HUAWEI_controller_interaction = 1;
            public const int XR_HUAWEI_controller_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_HUAWEI_CONTROLLER_INTERACTION_EXTENSION_NAME => "XR_HUAWEI_controller_interaction"u8;
            public const int XR_FB_swapchain_update_state = 1;
            public const int XR_FB_swapchain_update_state_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_FB_SWAPCHAIN_UPDATE_STATE_EXTENSION_NAME => "XR_FB_swapchain_update_state"u8;
            public const int XR_FB_composition_layer_secure_content = 1;
            public const int XR_FB_composition_layer_secure_content_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_COMPOSITION_LAYER_SECURE_CONTENT_EXTENSION_NAME => "XR_FB_composition_layer_secure_content"u8;
            public const int XR_FB_body_tracking = 1;
            public const int XR_FB_body_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_BODY_TRACKING_EXTENSION_NAME => "XR_FB_body_tracking"u8;
            public const int XR_EXT_dpad_binding = 1;
            public const int XR_EXT_dpad_binding_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_DPAD_BINDING_EXTENSION_NAME => "XR_EXT_dpad_binding"u8;
            public const int XR_VALVE_analog_threshold = 1;
            public const int XR_VALVE_analog_threshold_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_VALVE_ANALOG_THRESHOLD_EXTENSION_NAME => "XR_VALVE_analog_threshold"u8;
            public const int XR_EXT_hand_joints_motion_range = 1;
            public const int XR_EXT_hand_joints_motion_range_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_HAND_JOINTS_MOTION_RANGE_EXTENSION_NAME => "XR_EXT_hand_joints_motion_range"u8;
            public const int XR_EXT_samsung_odyssey_controller = 1;
            public const int XR_EXT_samsung_odyssey_controller_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_SAMSUNG_ODYSSEY_CONTROLLER_EXTENSION_NAME => "XR_EXT_samsung_odyssey_controller"u8;
            public const int XR_EXT_hp_mixed_reality_controller = 1;
            public const int XR_EXT_hp_mixed_reality_controller_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_HP_MIXED_REALITY_CONTROLLER_EXTENSION_NAME => "XR_EXT_hp_mixed_reality_controller"u8;
            public const int XR_MND_swapchain_usage_input_attachment_bit = 1;
            public const int XR_MND_swapchain_usage_input_attachment_bit_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_MND_SWAPCHAIN_USAGE_INPUT_ATTACHMENT_BIT_EXTENSION_NAME => "XR_MND_swapchain_usage_input_attachment_bit"u8;
            public const int XR_MSFT_scene_understanding = 1;
            public const int XR_MSFT_scene_understanding_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_MSFT_SCENE_UNDERSTANDING_EXTENSION_NAME => "XR_MSFT_scene_understanding"u8;
            public const int XR_MSFT_scene_understanding_serialization = 1;
            public const int XR_MSFT_scene_understanding_serialization_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_MSFT_SCENE_UNDERSTANDING_SERIALIZATION_EXTENSION_NAME => "XR_MSFT_scene_understanding_serialization"u8;
            public const int XR_FB_display_refresh_rate = 1;
            public const int XR_FB_display_refresh_rate_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_DISPLAY_REFRESH_RATE_EXTENSION_NAME => "XR_FB_display_refresh_rate"u8;
            public const int XR_HTC_vive_cosmos_controller_interaction = 1;
            public const int XR_HTC_vive_cosmos_controller_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_HTC_VIVE_COSMOS_CONTROLLER_INTERACTION_EXTENSION_NAME => "XR_HTC_vive_cosmos_controller_interaction"u8;
            public const int XR_HTCX_vive_tracker_interaction = 1;
            public const int XR_HTCX_vive_tracker_interaction_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_HTCX_VIVE_TRACKER_INTERACTION_EXTENSION_NAME => "XR_HTCX_vive_tracker_interaction"u8;
            public const int XR_HTC_facial_tracking = 1;
            public const int XR_FACIAL_EXPRESSION_EYE_COUNT_HTC = 14;
            public const int XR_FACIAL_EXPRESSION_LIP_COUNT_HTC = 37;
            public const int XR_HTC_facial_tracking_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_HTC_FACIAL_TRACKING_EXTENSION_NAME => "XR_HTC_facial_tracking"u8;
            public const int XR_HTC_vive_focus3_controller_interaction = 1;
            public const int XR_HTC_vive_focus3_controller_interaction_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_HTC_VIVE_FOCUS3_CONTROLLER_INTERACTION_EXTENSION_NAME => "XR_HTC_vive_focus3_controller_interaction"u8;
            public const int XR_HTC_hand_interaction = 1;
            public const int XR_HTC_hand_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_HTC_HAND_INTERACTION_EXTENSION_NAME => "XR_HTC_hand_interaction"u8;
            public const int XR_HTC_vive_wrist_tracker_interaction = 1;
            public const int XR_HTC_vive_wrist_tracker_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_HTC_VIVE_WRIST_TRACKER_INTERACTION_EXTENSION_NAME => "XR_HTC_vive_wrist_tracker_interaction"u8;
            public const int XR_FB_color_space = 1;
            public const int XR_FB_color_space_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_FB_COLOR_SPACE_EXTENSION_NAME => "XR_FB_color_space"u8;
            public const int XR_FB_hand_tracking_mesh = 1;
            public const int XR_FB_hand_tracking_mesh_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_FB_HAND_TRACKING_MESH_EXTENSION_NAME => "XR_FB_hand_tracking_mesh"u8;
            public const int XR_FB_hand_tracking_aim = 1;
            public const int XR_FB_hand_tracking_aim_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_FB_HAND_TRACKING_AIM_EXTENSION_NAME => "XR_FB_hand_tracking_aim"u8;
            public const int XR_FB_hand_tracking_capsules = 1;
            public const int XR_HAND_TRACKING_CAPSULE_POINT_COUNT_FB = 2;
            public const int XR_HAND_TRACKING_CAPSULE_COUNT_FB = 19;
            public const int XR_FB_hand_tracking_capsules_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_FB_HAND_TRACKING_CAPSULES_EXTENSION_NAME => "XR_FB_hand_tracking_capsules"u8;
            public const int XR_FB_HAND_TRACKING_CAPSULE_POINT_COUNT = 2;
            public const int XR_FB_HAND_TRACKING_CAPSULE_COUNT = 19;
            public const int XR_FB_spatial_entity = 1;
            public const int XR_FB_spatial_entity_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_EXTENSION_NAME => "XR_FB_spatial_entity"u8;
            public const int XR_FB_foveation = 1;
            public const int XR_FB_foveation_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_FOVEATION_EXTENSION_NAME => "XR_FB_foveation"u8;
            public const int XR_FB_foveation_configuration = 1;
            public const int XR_FB_foveation_configuration_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_FOVEATION_CONFIGURATION_EXTENSION_NAME => "XR_FB_foveation_configuration"u8;
            public const int XR_FB_keyboard_tracking = 1;
            public const int XR_MAX_KEYBOARD_TRACKING_NAME_SIZE_FB = 128;
            public const int XR_FB_keyboard_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_KEYBOARD_TRACKING_EXTENSION_NAME => "XR_FB_keyboard_tracking"u8;
            public const int XR_FB_triangle_mesh = 1;
            public const int XR_FB_triangle_mesh_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_FB_TRIANGLE_MESH_EXTENSION_NAME => "XR_FB_triangle_mesh"u8;
            public const int XR_FB_passthrough = 1;
            public const int XR_PASSTHROUGH_COLOR_MAP_MONO_SIZE_FB = 256;
            public const int XR_FB_passthrough_SPEC_VERSION = 5;
            public static ReadOnlySpan<byte> XR_FB_PASSTHROUGH_EXTENSION_NAME => "XR_FB_passthrough"u8;
            public const int XR_FB_render_model = 1;
            public const int XR_NULL_RENDER_MODEL_KEY_FB = 0;
            public const int XR_MAX_RENDER_MODEL_NAME_SIZE_FB = 64;
            public const int XR_FB_render_model_SPEC_VERSION = 4;
            public static ReadOnlySpan<byte> XR_FB_RENDER_MODEL_EXTENSION_NAME => "XR_FB_render_model"u8;
            public const int XR_VARJO_foveated_rendering = 1;
            public const int XR_VARJO_foveated_rendering_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_VARJO_FOVEATED_RENDERING_EXTENSION_NAME => "XR_VARJO_foveated_rendering"u8;
            public const int XR_VARJO_composition_layer_depth_test = 1;
            public const int XR_VARJO_composition_layer_depth_test_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_VARJO_COMPOSITION_LAYER_DEPTH_TEST_EXTENSION_NAME => "XR_VARJO_composition_layer_depth_test"u8;
            public const int XR_VARJO_environment_depth_estimation = 1;
            public const int XR_VARJO_environment_depth_estimation_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_VARJO_ENVIRONMENT_DEPTH_ESTIMATION_EXTENSION_NAME => "XR_VARJO_environment_depth_estimation"u8;
            public const int XR_VARJO_marker_tracking = 1;
            public const int XR_VARJO_marker_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_VARJO_MARKER_TRACKING_EXTENSION_NAME => "XR_VARJO_marker_tracking"u8;
            public const int XR_VARJO_view_offset = 1;
            public const int XR_VARJO_view_offset_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_VARJO_VIEW_OFFSET_EXTENSION_NAME => "XR_VARJO_view_offset"u8;
            public const int XR_VARJO_xr4_controller_interaction = 1;
            public const int XR_VARJO_xr4_controller_interaction_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_VARJO_XR4_CONTROLLER_INTERACTION_EXTENSION_NAME => "XR_VARJO_xr4_controller_interaction"u8;
            public const int XR_ML_ml2_controller_interaction = 1;
            public const int XR_ML_ml2_controller_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_ML2_CONTROLLER_INTERACTION_EXTENSION_NAME => "XR_ML_ml2_controller_interaction"u8;
            public const int XR_ML_frame_end_info = 1;
            public const int XR_ML_frame_end_info_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_FRAME_END_INFO_EXTENSION_NAME => "XR_ML_frame_end_info"u8;
            public const int XR_ML_global_dimmer = 1;
            public const int XR_ML_global_dimmer_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_GLOBAL_DIMMER_EXTENSION_NAME => "XR_ML_global_dimmer"u8;
            public const int XR_ML_marker_understanding = 1;
            public const int XR_ML_marker_understanding_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_MARKER_UNDERSTANDING_EXTENSION_NAME => "XR_ML_marker_understanding"u8;
            public const int XR_ML_localization_map = 1;
            public const int XR_MAX_LOCALIZATION_MAP_NAME_LENGTH_ML = 64;
            public const int XR_ML_localization_map_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_LOCALIZATION_MAP_EXTENSION_NAME => "XR_ML_localization_map"u8;
            public const int XR_ML_spatial_anchors = 1;
            public const int XR_ML_spatial_anchors_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_SPATIAL_ANCHORS_EXTENSION_NAME => "XR_ML_spatial_anchors"u8;
            public const int XR_ML_spatial_anchors_storage = 1;
            public const int XR_ML_spatial_anchors_storage_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_SPATIAL_ANCHORS_STORAGE_EXTENSION_NAME => "XR_ML_spatial_anchors_storage"u8;
            public const int XR_MSFT_spatial_anchor_persistence = 1;
            public const int XR_MAX_SPATIAL_ANCHOR_NAME_SIZE_MSFT = 256;
            public const int XR_MSFT_spatial_anchor_persistence_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_MSFT_SPATIAL_ANCHOR_PERSISTENCE_EXTENSION_NAME => "XR_MSFT_spatial_anchor_persistence"u8;
            public const int XR_MSFT_scene_marker = 1;
            public const int XR_MSFT_scene_marker_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_MSFT_SCENE_MARKER_EXTENSION_NAME => "XR_MSFT_scene_marker"u8;
            public const int XR_ULTRALEAP_hand_tracking_forearm = 1;
            public const int XR_HAND_FOREARM_JOINT_COUNT_ULTRALEAP = 27;
            public const int XR_ULTRALEAP_hand_tracking_forearm_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ULTRALEAP_HAND_TRACKING_FOREARM_EXTENSION_NAME => "XR_ULTRALEAP_hand_tracking_forearm"u8;
            public const int XR_FB_spatial_entity_query = 1;
            public const int XR_FB_spatial_entity_query_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_QUERY_EXTENSION_NAME => "XR_FB_spatial_entity_query"u8;
            public const int XR_FB_spatial_entity_storage = 1;
            public const int XR_FB_spatial_entity_storage_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_STORAGE_EXTENSION_NAME => "XR_FB_spatial_entity_storage"u8;
            public const int XR_FB_touch_controller_pro = 1;
            public const int XR_FB_touch_controller_pro_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_TOUCH_CONTROLLER_PRO_EXTENSION_NAME => "XR_FB_touch_controller_pro"u8;
            public const int XR_FB_spatial_entity_sharing = 1;
            public const int XR_FB_spatial_entity_sharing_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_SHARING_EXTENSION_NAME => "XR_FB_spatial_entity_sharing"u8;
            public const int XR_FB_space_warp = 1;
            public const int XR_FB_space_warp_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_FB_SPACE_WARP_EXTENSION_NAME => "XR_FB_space_warp"u8;
            public const int XR_FB_haptic_amplitude_envelope = 1;
            public const uint XR_MAX_HAPTIC_AMPLITUDE_ENVELOPE_SAMPLES_FB = 4000U;
            public const int XR_FB_haptic_amplitude_envelope_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_HAPTIC_AMPLITUDE_ENVELOPE_EXTENSION_NAME => "XR_FB_haptic_amplitude_envelope"u8;
            public const int XR_FB_scene = 1;
            public const int XR_FB_scene_SPEC_VERSION = 4;
            public static ReadOnlySpan<byte> XR_FB_SCENE_EXTENSION_NAME => "XR_FB_scene"u8;
            public const int XR_EXT_palm_pose = 1;
            public const int XR_EXT_palm_pose_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_EXT_PALM_POSE_EXTENSION_NAME => "XR_EXT_palm_pose"u8;
            public const int XR_ALMALENCE_digital_lens_control = 1;
            public const int XR_ALMALENCE_digital_lens_control_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ALMALENCE_DIGITAL_LENS_CONTROL_EXTENSION_NAME => "XR_ALMALENCE_digital_lens_control"u8;
            public const int XR_FB_scene_capture = 1;
            public const int XR_FB_scene_capture_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_SCENE_CAPTURE_EXTENSION_NAME => "XR_FB_scene_capture"u8;
            public const int XR_FB_spatial_entity_container = 1;
            public const int XR_FB_spatial_entity_container_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_CONTAINER_EXTENSION_NAME => "XR_FB_spatial_entity_container"u8;
            public const int XR_META_foveation_eye_tracked = 1;
            public const int XR_FOVEATION_CENTER_SIZE_META = 2;
            public const int XR_META_foveation_eye_tracked_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_FOVEATION_EYE_TRACKED_EXTENSION_NAME => "XR_META_foveation_eye_tracked"u8;
            public const int XR_FB_face_tracking = 1;
            public const int XR_FB_face_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_FACE_TRACKING_EXTENSION_NAME => "XR_FB_face_tracking"u8;
            public const int XR_FB_eye_tracking_social = 1;
            public const int XR_FB_eye_tracking_social_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_EYE_TRACKING_SOCIAL_EXTENSION_NAME => "XR_FB_eye_tracking_social"u8;
            public const int XR_FB_passthrough_keyboard_hands = 1;
            public const int XR_FB_passthrough_keyboard_hands_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_FB_PASSTHROUGH_KEYBOARD_HANDS_EXTENSION_NAME => "XR_FB_passthrough_keyboard_hands"u8;
            public const int XR_FB_composition_layer_settings = 1;
            public const int XR_FB_composition_layer_settings_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_COMPOSITION_LAYER_SETTINGS_EXTENSION_NAME => "XR_FB_composition_layer_settings"u8;
            public const int XR_FB_touch_controller_proximity = 1;
            public const int XR_FB_touch_controller_proximity_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_TOUCH_CONTROLLER_PROXIMITY_EXTENSION_NAME => "XR_FB_touch_controller_proximity"u8;
            public const int XR_FB_haptic_pcm = 1;
            public const int XR_MAX_HAPTIC_PCM_BUFFER_SIZE_FB = 4000;
            public const int XR_FB_haptic_pcm_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_HAPTIC_PCM_EXTENSION_NAME => "XR_FB_haptic_pcm"u8;
            public const int XR_EXT_frame_synthesis = 1;
            public const int XR_EXT_frame_synthesis_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_FRAME_SYNTHESIS_EXTENSION_NAME => "XR_EXT_frame_synthesis"u8;
            public const int XR_FB_composition_layer_depth_test = 1;
            public const int XR_FB_composition_layer_depth_test_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_COMPOSITION_LAYER_DEPTH_TEST_EXTENSION_NAME => "XR_FB_composition_layer_depth_test"u8;
            public const int XR_META_local_dimming = 1;
            public const int XR_META_local_dimming_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_LOCAL_DIMMING_EXTENSION_NAME => "XR_META_local_dimming"u8;
            public const int XR_META_passthrough_preferences = 1;
            public const int XR_META_passthrough_preferences_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_PASSTHROUGH_PREFERENCES_EXTENSION_NAME => "XR_META_passthrough_preferences"u8;
            public const int XR_META_virtual_keyboard = 1;
            public const int XR_MAX_VIRTUAL_KEYBOARD_COMMIT_TEXT_SIZE_META = 3992;
            public const int XR_META_virtual_keyboard_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_VIRTUAL_KEYBOARD_EXTENSION_NAME => "XR_META_virtual_keyboard"u8;
            public const int XR_OCULUS_external_camera = 1;
            public const int XR_MAX_EXTERNAL_CAMERA_NAME_SIZE_OCULUS = 32;
            public const int XR_OCULUS_external_camera_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_OCULUS_EXTERNAL_CAMERA_EXTENSION_NAME => "XR_OCULUS_external_camera"u8;
            public const int XR_META_performance_metrics = 1;
            public const int XR_META_performance_metrics_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_META_PERFORMANCE_METRICS_EXTENSION_NAME => "XR_META_performance_metrics"u8;
            public const int XR_FB_spatial_entity_storage_batch = 1;
            public const int XR_FB_spatial_entity_storage_batch_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_STORAGE_BATCH_EXTENSION_NAME => "XR_FB_spatial_entity_storage_batch"u8;
            public const int XR_META_detached_controllers = 1;
            public const int XR_META_detached_controllers_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_DETACHED_CONTROLLERS_EXTENSION_NAME => "XR_META_detached_controllers"u8;
            public const int XR_FB_spatial_entity_user = 1;
            public const int XR_FB_spatial_entity_user_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_SPATIAL_ENTITY_USER_EXTENSION_NAME => "XR_FB_spatial_entity_user"u8;
            public const int XR_META_headset_id = 1;
            public const int XR_META_headset_id_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_META_HEADSET_ID_EXTENSION_NAME => "XR_META_headset_id"u8;
            public const int XR_META_spatial_entity_discovery = 1;
            public const int XR_META_spatial_entity_discovery_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_DISCOVERY_EXTENSION_NAME => "XR_META_spatial_entity_discovery"u8;
            public const int XR_META_hand_tracking_microgestures = 1;
            public const int XR_META_hand_tracking_microgestures_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_HAND_TRACKING_MICROGESTURES_EXTENSION_NAME => "XR_META_hand_tracking_microgestures"u8;
            public const int XR_META_recommended_layer_resolution = 1;
            public const int XR_META_recommended_layer_resolution_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_RECOMMENDED_LAYER_RESOLUTION_EXTENSION_NAME => "XR_META_recommended_layer_resolution"u8;
            public const int XR_META_spatial_entity_persistence = 1;
            public const int XR_META_spatial_entity_persistence_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_PERSISTENCE_EXTENSION_NAME => "XR_META_spatial_entity_persistence"u8;
            public const int XR_META_passthrough_color_lut = 1;
            public const int XR_META_passthrough_color_lut_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_PASSTHROUGH_COLOR_LUT_EXTENSION_NAME => "XR_META_passthrough_color_lut"u8;
            public const int XR_META_spatial_entity_mesh = 1;
            public const int XR_META_spatial_entity_mesh_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_MESH_EXTENSION_NAME => "XR_META_spatial_entity_mesh"u8;
            public const int XR_META_automatic_layer_filter = 1;
            public const int XR_META_automatic_layer_filter_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_AUTOMATIC_LAYER_FILTER_EXTENSION_NAME => "XR_META_automatic_layer_filter"u8;
            public const int XR_META_body_tracking_full_body = 1;
            public const int XR_META_body_tracking_full_body_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_BODY_TRACKING_FULL_BODY_EXTENSION_NAME => "XR_META_body_tracking_full_body"u8;
            public const int XR_META_touch_controller_plus = 1;
            public const int XR_META_touch_controller_plus_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_TOUCH_CONTROLLER_PLUS_EXTENSION_NAME => "XR_META_touch_controller_plus"u8;
            public const int XR_META_passthrough_layer_resumed_event = 1;
            public const int XR_META_passthrough_layer_resumed_event_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_PASSTHROUGH_LAYER_RESUMED_EVENT_EXTENSION_NAME => "XR_META_passthrough_layer_resumed_event"u8;
            public const int XR_META_body_tracking_calibration = 1;
            public const int XR_META_body_tracking_calibration_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_BODY_TRACKING_CALIBRATION_EXTENSION_NAME => "XR_META_body_tracking_calibration"u8;
            public const int XR_META_body_tracking_fidelity = 1;
            public const int XR_META_body_tracking_fidelity_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_BODY_TRACKING_FIDELITY_EXTENSION_NAME => "XR_META_body_tracking_fidelity"u8;
            public const int XR_FB_face_tracking2 = 1;
            public const int XR_FB_face_tracking2_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_FB_FACE_TRACKING2_EXTENSION_NAME => "XR_FB_face_tracking2"u8;
            public const int XR_META_spatial_entity_sharing = 1;
            public const int XR_META_spatial_entity_sharing_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_SHARING_EXTENSION_NAME => "XR_META_spatial_entity_sharing"u8;
            public const int XR_MAX_SPACES_PER_SHARE_REQUEST_META = 32;
            public const int XR_META_environment_depth = 1;
            public const int XR_META_environment_depth_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_META_ENVIRONMENT_DEPTH_EXTENSION_NAME => "XR_META_environment_depth"u8;
            public const int XR_EXT_uuid = 1;
            public const int XR_EXT_uuid_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_UUID_EXTENSION_NAME => "XR_EXT_uuid"u8;
            public const int XR_UUID_SIZE_EXT = 16;
            public const int XR_EXT_render_model = 1;
            public const int XR_MAX_RENDER_MODEL_ASSET_NODE_NAME_SIZE_EXT = 64;
            public const int XR_EXT_render_model_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_RENDER_MODEL_EXTENSION_NAME => "XR_EXT_render_model"u8;
            public const int XR_NULL_RENDER_MODEL_ID_EXT = 0;
            public const int XR_EXT_interaction_render_model = 1;
            public const int XR_EXT_interaction_render_model_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_INTERACTION_RENDER_MODEL_EXTENSION_NAME => "XR_EXT_interaction_render_model"u8;
            public const int XR_EXT_hand_interaction = 1;
            public const int XR_EXT_hand_interaction_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_EXT_HAND_INTERACTION_EXTENSION_NAME => "XR_EXT_hand_interaction"u8;
            public const int XR_QCOM_tracking_optimization_settings = 1;
            public const int XR_QCOM_tracking_optimization_settings_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_QCOM_TRACKING_OPTIMIZATION_SETTINGS_EXTENSION_NAME => "XR_QCOM_tracking_optimization_settings"u8;
            public const int XR_QCOM_hand_tracking_gesture = 1;
            public const int XR_QCOM_hand_tracking_gesture_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_QCOM_HAND_TRACKING_GESTURE_EXTENSION_NAME => "XR_QCOM_hand_tracking_gesture"u8;
            public const int XR_HTC_passthrough = 1;
            public const int XR_HTC_passthrough_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_HTC_PASSTHROUGH_EXTENSION_NAME => "XR_HTC_passthrough"u8;
            public const int XR_HTC_foveation = 1;
            public const int XR_HTC_foveation_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_HTC_FOVEATION_EXTENSION_NAME => "XR_HTC_foveation"u8;
            public const int XR_HTC_anchor = 1;
            public const int XR_MAX_SPATIAL_ANCHOR_NAME_SIZE_HTC = 256;
            public const int XR_HTC_anchor_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_HTC_ANCHOR_EXTENSION_NAME => "XR_HTC_anchor"u8;
            public const int XR_HTC_body_tracking = 1;
            public const int XR_BODY_JOINT_COUNT_HTC = 26;
            public const int XR_HTC_body_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_HTC_BODY_TRACKING_EXTENSION_NAME => "XR_HTC_body_tracking"u8;
            public const int XR_EXT_active_action_set_priority = 1;
            public const int XR_EXT_active_action_set_priority_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_ACTIVE_ACTION_SET_PRIORITY_EXTENSION_NAME => "XR_EXT_active_action_set_priority"u8;
            public const int XR_MNDX_force_feedback_curl = 1;
            public const int XR_MNDX_force_feedback_curl_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_MNDX_FORCE_FEEDBACK_CURL_EXTENSION_NAME => "XR_MNDX_force_feedback_curl"u8;
            public const int XR_BD_controller_interaction = 1;
            public const int XR_BD_controller_interaction_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_BD_CONTROLLER_INTERACTION_EXTENSION_NAME => "XR_BD_controller_interaction"u8;
            public const int XR_BD_body_tracking = 1;
            public const int XR_BODY_JOINT_COUNT_BD = 24;
            public const int XR_BODY_JOINT_WITHOUT_ARM_COUNT_BD = 16;
            public const int XR_BD_body_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_BODY_TRACKING_EXTENSION_NAME => "XR_BD_body_tracking"u8;
            public const int XR_BD_facial_simulation = 1;
            public const int XR_FACE_EXPRESSION_COUNT_BD = 52;
            public const int XR_LIP_EXPRESSION_COUNT_BD = 20;
            public const int XR_BD_facial_simulation_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_FACIAL_SIMULATION_EXTENSION_NAME => "XR_BD_facial_simulation"u8;
            public const int XR_BD_spatial_sensing = 1;
            public const int XR_BD_spatial_sensing_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_BD_SPATIAL_SENSING_EXTENSION_NAME => "XR_BD_spatial_sensing"u8;
            public const int XR_BD_spatial_anchor = 1;
            public const int XR_BD_spatial_anchor_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_BD_SPATIAL_ANCHOR_EXTENSION_NAME => "XR_BD_spatial_anchor"u8;
            public const int XR_BD_spatial_anchor_sharing = 1;
            public const int XR_BD_spatial_anchor_sharing_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_BD_SPATIAL_ANCHOR_SHARING_EXTENSION_NAME => "XR_BD_spatial_anchor_sharing"u8;
            public const int XR_BD_spatial_scene = 1;
            public const int XR_BD_spatial_scene_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_SPATIAL_SCENE_EXTENSION_NAME => "XR_BD_spatial_scene"u8;
            public const int XR_BD_spatial_mesh = 1;
            public const int XR_BD_spatial_mesh_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_SPATIAL_MESH_EXTENSION_NAME => "XR_BD_spatial_mesh"u8;
            public const int XR_BD_future_progress = 1;
            public const int XR_BD_future_progress_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_FUTURE_PROGRESS_EXTENSION_NAME => "XR_BD_future_progress"u8;
            public const int XR_BD_body_tracking_auxiliary_metrics = 1;
            public const int XR_BD_body_tracking_auxiliary_metrics_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_BODY_TRACKING_AUXILIARY_METRICS_EXTENSION_NAME => "XR_BD_body_tracking_auxiliary_metrics"u8;
            public const int XR_BD_spatial_plane = 1;
            public const int XR_BD_spatial_plane_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_SPATIAL_PLANE_EXTENSION_NAME => "XR_BD_spatial_plane"u8;
            public const int XR_BD_spatial_light_estimation = 1;
            public const int XR_BD_spatial_light_estimation_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_SPATIAL_LIGHT_ESTIMATION_EXTENSION_NAME => "XR_BD_spatial_light_estimation"u8;
            public const int XR_BD_ultra_controller_interaction = 1;
            public const int XR_BD_ultra_controller_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_ULTRA_CONTROLLER_INTERACTION_EXTENSION_NAME => "XR_BD_ultra_controller_interaction"u8;
            public const int XR_BD_spatial_audio_rendering = 1;
            public const int XR_BD_spatial_audio_rendering_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_SPATIAL_AUDIO_RENDERING_EXTENSION_NAME => "XR_BD_spatial_audio_rendering"u8;
            public const int XR_EXT_local_floor = 1;
            public const int XR_EXT_local_floor_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_LOCAL_FLOOR_EXTENSION_NAME => "XR_EXT_local_floor"u8;
            public const int XR_EXT_hand_tracking_data_source = 1;
            public const int XR_EXT_hand_tracking_data_source_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_HAND_TRACKING_DATA_SOURCE_EXTENSION_NAME => "XR_EXT_hand_tracking_data_source"u8;
            public const int XR_EXT_plane_detection = 1;
            public const int XR_EXT_plane_detection_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_EXT_PLANE_DETECTION_EXTENSION_NAME => "XR_EXT_plane_detection"u8;
            public const int XR_OPPO_controller_interaction = 1;
            public const int XR_OPPO_controller_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_OPPO_CONTROLLER_INTERACTION_EXTENSION_NAME => "XR_OPPO_controller_interaction"u8;
            public const int XR_ANDROID_trackables = 1;
            public const int XR_NULL_TRACKABLE_ANDROID = 0;
            public const int XR_ANDROID_trackables_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_ANDROID_TRACKABLES_EXTENSION_NAME => "XR_ANDROID_trackables"u8;
            public const int XR_ANDROID_eye_tracking = 1;
            public const int XR_EYE_MAX_ANDROID = 2;
            public const int XR_ANDROID_eye_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_EYE_TRACKING_EXTENSION_NAME => "XR_ANDROID_eye_tracking"u8;
            public const int XR_ANDROID_device_anchor_persistence = 1;
            public const int XR_ANDROID_device_anchor_persistence_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_DEVICE_ANCHOR_PERSISTENCE_EXTENSION_NAME => "XR_ANDROID_device_anchor_persistence"u8;
            public const int XR_ANDROID_face_tracking = 1;
            public const int XR_ANDROID_face_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_FACE_TRACKING_EXTENSION_NAME => "XR_ANDROID_face_tracking"u8;
            public const int XR_FACE_PARAMETER_COUNT_ANDROID = 68;
            public const int XR_FACE_REGION_CONFIDENCE_COUNT_ANDROID = 3;
            public const int XR_ANDROID_passthrough_camera_state = 1;
            public const int XR_ANDROID_passthrough_camera_state_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_PASSTHROUGH_CAMERA_STATE_EXTENSION_NAME => "XR_ANDROID_passthrough_camera_state"u8;
            public const int XR_ANDROID_recommended_resolution = 1;
            public const int XR_ANDROID_recommended_resolution_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_RECOMMENDED_RESOLUTION_EXTENSION_NAME => "XR_ANDROID_recommended_resolution"u8;
            public const int XR_ANDROID_composition_layer_passthrough_mesh = 1;
            public const int XR_ANDROID_composition_layer_passthrough_mesh_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_COMPOSITION_LAYER_PASSTHROUGH_MESH_EXTENSION_NAME => "XR_ANDROID_composition_layer_passthrough_mesh"u8;
            public const int XR_ANDROID_raycast = 1;
            public const int XR_ANDROID_raycast_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_RAYCAST_EXTENSION_NAME => "XR_ANDROID_raycast"u8;
            public const int XR_ANDROID_performance_metrics = 1;
            public const int XR_ANDROID_performance_metrics_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_PERFORMANCE_METRICS_EXTENSION_NAME => "XR_ANDROID_performance_metrics"u8;
            public const int XR_ANDROID_trackables_object = 1;
            public const int XR_ANDROID_trackables_object_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_ANDROID_TRACKABLES_OBJECT_EXTENSION_NAME => "XR_ANDROID_trackables_object"u8;
            public const int XR_ANDROID_unbounded_reference_space = 1;
            public const int XR_ANDROID_unbounded_reference_space_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_UNBOUNDED_REFERENCE_SPACE_EXTENSION_NAME => "XR_ANDROID_unbounded_reference_space"u8;
            public const int XR_EXT_future = 1;
            public const int XR_EXT_future_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_EXT_FUTURE_EXTENSION_NAME => "XR_EXT_future"u8;
            public const int XR_NULL_FUTURE_EXT = 0;
            public const int XR_EXT_user_presence = 1;
            public const int XR_EXT_user_presence_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_USER_PRESENCE_EXTENSION_NAME => "XR_EXT_user_presence"u8;
            public const int XR_ML_user_calibration = 1;
            public const int XR_ML_user_calibration_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_USER_CALIBRATION_EXTENSION_NAME => "XR_ML_user_calibration"u8;
            public const int XR_ML_system_notifications = 1;
            public const int XR_ML_system_notifications_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_SYSTEM_NOTIFICATIONS_EXTENSION_NAME => "XR_ML_system_notifications"u8;
            public const int XR_ML_world_mesh_detection = 1;
            public const int XR_ML_world_mesh_detection_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_WORLD_MESH_DETECTION_EXTENSION_NAME => "XR_ML_world_mesh_detection"u8;
            public const int XR_ML_facial_expression = 1;
            public const int XR_ML_facial_expression_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_FACIAL_EXPRESSION_EXTENSION_NAME => "XR_ML_facial_expression"u8;
            public const int XR_ML_view_configuration_depth_range_change = 1;
            public const int XR_ML_view_configuration_depth_range_change_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ML_VIEW_CONFIGURATION_DEPTH_RANGE_CHANGE_EXTENSION_NAME => "XR_ML_view_configuration_depth_range_change"u8;
            public const int XR_YVR_controller_interaction = 1;
            public const int XR_YVR_controller_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_YVR_CONTROLLER_INTERACTION_EXTENSION_NAME => "XR_YVR_controller_interaction"u8;
            public const int XR_META_boundary_visibility = 1;
            public const int XR_META_boundary_visibility_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_BOUNDARY_VISIBILITY_EXTENSION_NAME => "XR_META_boundary_visibility"u8;
            public const int XR_META_simultaneous_hands_and_controllers = 1;
            public const int XR_META_simultaneous_hands_and_controllers_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_SIMULTANEOUS_HANDS_AND_CONTROLLERS_EXTENSION_NAME => "XR_META_simultaneous_hands_and_controllers"u8;
            public const int XR_META_face_tracking_visemes = 1;
            public const int XR_FACE_TRACKING_VISEME_COUNT_META = 15;
            public const int XR_META_face_tracking_visemes_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_FACE_TRACKING_VISEMES_EXTENSION_NAME => "XR_META_face_tracking_visemes"u8;
            public const int XR_META_spatial_entity_semantic_label = 1;
            public const int XR_META_spatial_entity_semantic_label_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_SEMANTIC_LABEL_EXTENSION_NAME => "XR_META_spatial_entity_semantic_label"u8;
            public const int XR_META_spatial_entity_room_mesh = 1;
            public const int XR_META_spatial_entity_room_mesh_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_ROOM_MESH_EXTENSION_NAME => "XR_META_spatial_entity_room_mesh"u8;
            public const int XR_EXT_composition_layer_inverted_alpha = 1;
            public const int XR_EXT_composition_layer_inverted_alpha_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_COMPOSITION_LAYER_INVERTED_ALPHA_EXTENSION_NAME => "XR_EXT_composition_layer_inverted_alpha"u8;
            public const int XR_META_colocation_discovery = 1;
            public const int XR_MAX_COLOCATION_DISCOVERY_BUFFER_SIZE_META = 1024;
            public const int XR_META_colocation_discovery_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_COLOCATION_DISCOVERY_EXTENSION_NAME => "XR_META_colocation_discovery"u8;
            public const int XR_META_spatial_entity_group_sharing = 1;
            public const int XR_META_spatial_entity_group_sharing_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_SPATIAL_ENTITY_GROUP_SHARING_EXTENSION_NAME => "XR_META_spatial_entity_group_sharing"u8;
            public const int XR_META_environment_raycast = 1;
            public const int XR_META_environment_raycast_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_ENVIRONMENT_RAYCAST_EXTENSION_NAME => "XR_META_environment_raycast"u8;
            public const int XR_META_tile_properties_hint = 1;
            public const int XR_META_tile_properties_hint_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_TILE_PROPERTIES_HINT_EXTENSION_NAME => "XR_META_tile_properties_hint"u8;
            public const int XR_META_hand_tracking_unextrapolated_poses = 1;
            public const int XR_META_hand_tracking_unextrapolated_poses_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_HAND_TRACKING_UNEXTRAPOLATED_POSES_EXTENSION_NAME => "XR_META_hand_tracking_unextrapolated_poses"u8;
            public const int XR_META_hand_tracking_frequency_hint = 1;
            public const int XR_META_hand_tracking_frequency_hint_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_HAND_TRACKING_FREQUENCY_HINT_EXTENSION_NAME => "XR_META_hand_tracking_frequency_hint"u8;
            public const int XR_META_hand_tracking_wide_motion_mode2 = 1;
            public const int XR_META_hand_tracking_wide_motion_mode2_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_META_HAND_TRACKING_WIDE_MOTION_MODE2_EXTENSION_NAME => "XR_META_hand_tracking_wide_motion_mode2"u8;
            public const int XR_ANDROID_light_estimation = 1;
            public const int XR_ANDROID_light_estimation_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_LIGHT_ESTIMATION_EXTENSION_NAME => "XR_ANDROID_light_estimation"u8;
            public const int XR_ANDROID_mouse_interaction = 1;
            public const int XR_ANDROID_mouse_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_MOUSE_INTERACTION_EXTENSION_NAME => "XR_ANDROID_mouse_interaction"u8;
            public const int XR_ANDROID_trackables_marker = 1;
            public const int XR_ANDROID_trackables_marker_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_TRACKABLES_MARKER_EXTENSION_NAME => "XR_ANDROID_trackables_marker"u8;
            public const int XR_ANDROID_trackables_qr_code = 1;
            public const int XR_ANDROID_trackables_qr_code_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_TRACKABLES_QR_CODE_EXTENSION_NAME => "XR_ANDROID_trackables_qr_code"u8;
            public const int XR_ANDROID_trackables_image = 1;
            public const int XR_ANDROID_trackables_image_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_TRACKABLES_IMAGE_EXTENSION_NAME => "XR_ANDROID_trackables_image"u8;
            public const int XR_ANDROID_scene_meshing = 1;
            public const int XR_ANDROID_scene_meshing_SPEC_VERSION = 3;
            public static ReadOnlySpan<byte> XR_ANDROID_SCENE_MESHING_EXTENSION_NAME => "XR_ANDROID_scene_meshing"u8;
            public const int XR_EXT_spatial_entity = 1;
            public const int XR_NULL_SPATIAL_ENTITY_ID_EXT = 0;
            public const int XR_NULL_SPATIAL_BUFFER_ID_EXT = 0;
            public const int XR_EXT_spatial_entity_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_SPATIAL_ENTITY_EXTENSION_NAME => "XR_EXT_spatial_entity"u8;
            public const int XR_EXT_spatial_plane_tracking = 1;
            public const int XR_EXT_spatial_plane_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_SPATIAL_PLANE_TRACKING_EXTENSION_NAME => "XR_EXT_spatial_plane_tracking"u8;
            public const int XR_EXT_stationary_reference_space = 1;
            public const int XR_EXT_stationary_reference_space_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_STATIONARY_REFERENCE_SPACE_EXTENSION_NAME => "XR_EXT_stationary_reference_space"u8;
            public const int XR_EXT_spatial_marker_tracking = 1;
            public const int XR_EXT_spatial_marker_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_SPATIAL_MARKER_TRACKING_EXTENSION_NAME => "XR_EXT_spatial_marker_tracking"u8;
            public const int XR_LOGITECH_mx_ink_stylus_interaction = 1;
            public const int XR_LOGITECH_mx_ink_stylus_interaction_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_LOGITECH_MX_INK_STYLUS_INTERACTION_EXTENSION_NAME => "XR_LOGITECH_mx_ink_stylus_interaction"u8;
            public const int XR_BD_dynamic_object_tracking = 1;
            public const int XR_BD_dynamic_object_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_DYNAMIC_OBJECT_TRACKING_EXTENSION_NAME => "XR_BD_dynamic_object_tracking"u8;
            public const int XR_BD_dynamic_object_keyboard = 1;
            public const int XR_BD_dynamic_object_keyboard_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_DYNAMIC_OBJECT_KEYBOARD_EXTENSION_NAME => "XR_BD_dynamic_object_keyboard"u8;
            public const int XR_BD_dynamic_object_mouse = 1;
            public const int XR_BD_dynamic_object_mouse_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_DYNAMIC_OBJECT_MOUSE_EXTENSION_NAME => "XR_BD_dynamic_object_mouse"u8;
            public const int XR_BD_camera_image = 1;
            public const int XR_BD_camera_image_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_BD_CAMERA_IMAGE_EXTENSION_NAME => "XR_BD_camera_image"u8;
            public const int XR_ANDROID_spatial_discovery_bounds = 1;
            public const int XR_ANDROID_spatial_discovery_bounds_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_SPATIAL_DISCOVERY_BOUNDS_EXTENSION_NAME => "XR_ANDROID_spatial_discovery_bounds"u8;
            public const int XR_EXT_spatial_anchor = 1;
            public const int XR_EXT_spatial_anchor_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_SPATIAL_ANCHOR_EXTENSION_NAME => "XR_EXT_spatial_anchor"u8;
            public const int XR_EXT_spatial_persistence = 1;
            public const int XR_EXT_spatial_persistence_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_SPATIAL_PERSISTENCE_EXTENSION_NAME => "XR_EXT_spatial_persistence"u8;
            public const int XR_EXT_haptic_parametric = 1;
            public const int XR_HAPTIC_PARAMETRIC_MAX_POINTS_TRANSIENTS_EXT = 500;
            public const int XR_HAPTIC_PARAMETRIC_VIBRATION_EXTEND_DURATION_EXT = 50000000;
            public const int XR_HAPTIC_PARAMETRIC_FREQUENCY_MIN_HZ_EXT = 1;
            public const int XR_HAPTIC_PARAMETRIC_FREQUENCY_MAX_HZ_EXT = 1000;
            public const int XR_EXT_haptic_parametric_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_HAPTIC_PARAMETRIC_EXTENSION_NAME => "XR_EXT_haptic_parametric"u8;
            public const int XR_SONY_swapchain_color_space = 1;
            public const int XR_SONY_swapchain_color_space_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_SONY_SWAPCHAIN_COLOR_SPACE_EXTENSION_NAME => "XR_SONY_swapchain_color_space"u8;
            public const int XR_SONY_hdr_metadata = 1;
            public const int XR_SONY_hdr_metadata_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_SONY_HDR_METADATA_EXTENSION_NAME => "XR_SONY_hdr_metadata"u8;
            public const int XR_EXT_spatial_persistence_operations = 1;
            public const int XR_EXT_spatial_persistence_operations_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_SPATIAL_PERSISTENCE_OPERATIONS_EXTENSION_NAME => "XR_EXT_spatial_persistence_operations"u8;
            public const int XR_EXT_spatial_image_tracking = 1;
            public const int XR_EXT_spatial_image_tracking_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_SPATIAL_IMAGE_TRACKING_EXTENSION_NAME => "XR_EXT_spatial_image_tracking"u8;
            public const int XR_ANDROID_spatial_object_tracking = 1;
            public const int XR_ANDROID_spatial_object_tracking_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_ANDROID_SPATIAL_OBJECT_TRACKING_EXTENSION_NAME => "XR_ANDROID_spatial_object_tracking"u8;
            public const int XR_ANDROID_spatial_discovery_raycast = 1;
            public const int XR_ANDROID_spatial_discovery_raycast_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_SPATIAL_DISCOVERY_RAYCAST_EXTENSION_NAME => "XR_ANDROID_spatial_discovery_raycast"u8;
            public const int XR_ANDROID_google_cloud_auth = 1;
            public const int XR_ANDROID_google_cloud_auth_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_GOOGLE_CLOUD_AUTH_EXTENSION_NAME => "XR_ANDROID_google_cloud_auth"u8;
            public const int XR_ANDROID_geospatial = 1;
            public const int XR_ANDROID_geospatial_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_GEOSPATIAL_EXTENSION_NAME => "XR_ANDROID_geospatial"u8;
            public const int XR_ANDROID_spatial_entity_bound_anchor = 1;
            public const int XR_ANDROID_spatial_entity_bound_anchor_SPEC_VERSION = 2;
            public static ReadOnlySpan<byte> XR_ANDROID_SPATIAL_ENTITY_BOUND_ANCHOR_EXTENSION_NAME => "XR_ANDROID_spatial_entity_bound_anchor"u8;
            public const int XR_ANDROID_spatial_component_subsumed_by = 1;
            public const int XR_ANDROID_spatial_component_subsumed_by_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_SPATIAL_COMPONENT_SUBSUMED_BY_EXTENSION_NAME => "XR_ANDROID_spatial_component_subsumed_by"u8;
            public const int XR_ANDROID_spatial_anchor_space = 1;
            public const int XR_ANDROID_spatial_anchor_space_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_SPATIAL_ANCHOR_SPACE_EXTENSION_NAME => "XR_ANDROID_spatial_anchor_space"u8;
            public const int XR_ANDROID_geospatial_anchor = 1;
            public const int XR_ANDROID_geospatial_anchor_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_ANDROID_GEOSPATIAL_ANCHOR_EXTENSION_NAME => "XR_ANDROID_geospatial_anchor"u8;
            public const int XR_EXT_spatial_container = 1;
            public const int XR_EXT_spatial_container_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_SPATIAL_CONTAINER_EXTENSION_NAME => "XR_EXT_spatial_container"u8;
            public const int XR_EXT_spatial_container_self_rendering = 1;
            public const int XR_EXT_spatial_container_self_rendering_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_SPATIAL_CONTAINER_SELF_RENDERING_EXTENSION_NAME => "XR_EXT_spatial_container_self_rendering"u8;
            public const int XR_EXT_interaction_profile_battery_state_display = 1;
            public const int XR_EXT_interaction_profile_battery_state_display_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_INTERACTION_PROFILE_BATTERY_STATE_DISPLAY_EXTENSION_NAME => "XR_EXT_interaction_profile_battery_state_display"u8;
            public const int XR_EXT_loader_init_properties = 1;
            public const int XR_EXT_loader_init_properties_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_LOADER_INIT_PROPERTIES_EXTENSION_NAME => "XR_EXT_loader_init_properties"u8;
            public const int XR_EXT_view_configuration_views_change = 1;
            public const int XR_EXT_view_configuration_views_change_SPEC_VERSION = 1;
            public static ReadOnlySpan<byte> XR_EXT_VIEW_CONFIGURATION_VIEWS_CHANGE_EXTENSION_NAME => "XR_EXT_view_configuration_views_change"u8;
        }

        /// <summary>Defines the type of a member as it was used in the native signature.</summary>
        [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = true)]
        [Conditional("DEBUG")]
        internal sealed partial class NativeTypeNameAttribute : Attribute
        {
            private readonly string _name;

            /// <summary>Initializes a new instance of the <see cref="NativeTypeNameAttribute" /> class.</summary>
            /// <param name="name">The name of the type that was used in the native signature.</param>
            public NativeTypeNameAttribute(string name)
            {
                _name = name;
            }

            /// <summary>Gets the name of the type that was used in the native signature.</summary>
            public string Name => _name;
        }

        /// <summary>Defines the annotation found in a native declaration.</summary>
        [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = true, Inherited = false)]
        [Conditional("DEBUG")]
        internal sealed partial class NativeAnnotationAttribute : Attribute
        {
            private readonly string _annotation;

            /// <summary>Initializes a new instance of the <see cref="NativeAnnotationAttribute" /> class.</summary>
            /// <param name="annotation">The annotation that was used in the native declaration.</param>
            public NativeAnnotationAttribute(string annotation)
            {
                _annotation = annotation;
            }

            /// <summary>Gets the annotation that was used in the native declaration.</summary>
            public string Annotation => _annotation;
        }
    }
}
