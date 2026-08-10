global using static Angene.Vulkan.Interop.VkVideo;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Angene.Vulkan.Interop;
public class Structs
{
    public partial struct VkInstance
    {
    }

    public partial struct VkPhysicalDevice
    {
    }

    public partial struct VkDevice
    {
    }

    public partial struct VkQueue
    {
    }

    public partial struct VkSemaphore
    {
    }

    public partial struct VkCommandBuffer
    {
    }

    public partial struct VkFence
    {
    }

    public partial struct VkDeviceMemory
    {
    }

    public partial struct VkBuffer
    {
    }

    public partial struct VkImage
    {
    }

    public partial struct VkQueryPool
    {
    }

    public partial struct VkImageView
    {
    }

    public partial struct VkCommandPool
    {
    }

    public partial struct VkRenderPass
    {
    }

    public partial struct VkFramebuffer
    {
    }

    public partial struct VkEvent
    {
    }

    public partial struct VkBufferView
    {
    }

    public partial struct VkShaderModule
    {
    }

    public partial struct VkPipelineCache
    {
    }

    public partial struct VkPipeline
    {
    }

    public partial struct VkPipelineLayout
    {
    }

    public partial struct VkDescriptorSetLayout
    {
    }

    public partial struct VkSampler
    {
    }

    public partial struct VkDescriptorSet
    {
    }

    public partial struct VkDescriptorPool
    {
    }

    public partial struct VkDeferredOperationKHR
    {
    }

    public partial struct VkAccelerationStructureKHR
    {
    }

    public partial struct VkExtent2D
    {
                public uint width;

                public uint height;
    }

    public partial struct VkExtent3D
    {
                public uint width;

                public uint height;

                public uint depth;
    }

    public partial struct VkOffset2D
    {
                public int x;

                public int y;
    }

    public partial struct VkOffset3D
    {
                public int x;

                public int y;

                public int z;
    }

    public partial struct VkRect2D
    {
        public VkOffset2D offset;

        public VkExtent2D extent;
    }

    public unsafe partial struct VkBaseInStructure
    {
        public Enumerators.VkStructureType sType;

                public VkBaseInStructure* pNext;
    }

    public unsafe partial struct VkBaseOutStructure
    {
        public Enumerators.VkStructureType sType;

                public VkBaseOutStructure* pNext;
    }

    public unsafe partial struct VkAllocationCallbacks
    {
        public void* pUserData;

                public delegate* unmanaged[Cdecl]<void*, nuint, nuint, VkSystemAllocationScope, void*> pfnAllocation;

                public delegate* unmanaged[Cdecl]<void*, void*, nuint, nuint, VkSystemAllocationScope, void*> pfnReallocation;

                public delegate* unmanaged[Cdecl]<void*, void*, void> pfnFree;

                public delegate* unmanaged[Cdecl]<void*, nuint, VkInternalAllocationType, VkSystemAllocationScope, void> pfnInternalAllocation;

                public delegate* unmanaged[Cdecl]<void*, nuint, VkInternalAllocationType, VkSystemAllocationScope, void> pfnInternalFree;
    }

    public unsafe partial struct VkApplicationInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public sbyte* pApplicationName;

                public uint applicationVersion;

                public sbyte* pEngineName;

                public uint engineVersion;

                public uint apiVersion;
    }

    public partial struct VkFormatProperties
    {
                public uint linearTilingFeatures;

                public uint optimalTilingFeatures;

                public uint bufferFeatures;
    }

    public partial struct VkImageFormatProperties
    {
        public VkExtent3D maxExtent;

                public uint maxMipLevels;

                public uint maxArrayLayers;

                public uint sampleCounts;

                public ulong maxResourceSize;
    }

    public unsafe partial struct VkInstanceCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkApplicationInfo* pApplicationInfo;

                public uint enabledLayerCount;

                public sbyte** ppEnabledLayerNames;

                public uint enabledExtensionCount;

                public sbyte** ppEnabledExtensionNames;
    }

    public partial struct VkMemoryHeap
    {
                public ulong size;

                public uint flags;
    }

    public partial struct VkMemoryType
    {
                public uint propertyFlags;

                public uint heapIndex;
    }

    public partial struct VkPhysicalDeviceFeatures
    {
                public uint robustBufferAccess;

                public uint fullDrawIndexUint32;

                public uint imageCubeArray;

                public uint independentBlend;

                public uint geometryShader;

                public uint tessellationShader;

                public uint sampleRateShading;

                public uint dualSrcBlend;

                public uint logicOp;

                public uint multiDrawIndirect;

                public uint drawIndirectFirstInstance;

                public uint depthClamp;

                public uint depthBiasClamp;

                public uint fillModeNonSolid;

                public uint depthBounds;

                public uint wideLines;

                public uint largePoints;

                public uint alphaToOne;

                public uint multiViewport;

                public uint samplerAnisotropy;

                public uint textureCompressionETC2;

                public uint textureCompressionASTC_LDR;

                public uint textureCompressionBC;

                public uint occlusionQueryPrecise;

                public uint pipelineStatisticsQuery;

                public uint vertexPipelineStoresAndAtomics;

                public uint fragmentStoresAndAtomics;

                public uint shaderTessellationAndGeometryPointSize;

                public uint shaderImageGatherExtended;

                public uint shaderStorageImageExtendedFormats;

                public uint shaderStorageImageMultisample;

                public uint shaderStorageImageReadWithoutFormat;

                public uint shaderStorageImageWriteWithoutFormat;

                public uint shaderUniformBufferArrayDynamicIndexing;

                public uint shaderSampledImageArrayDynamicIndexing;

                public uint shaderStorageBufferArrayDynamicIndexing;

                public uint shaderStorageImageArrayDynamicIndexing;

                public uint shaderClipDistance;

                public uint shaderCullDistance;

                public uint shaderFloat64;

                public uint shaderInt64;

                public uint shaderInt16;

                public uint shaderResourceResidency;

                public uint shaderResourceMinLod;

                public uint sparseBinding;

                public uint sparseResidencyBuffer;

                public uint sparseResidencyImage2D;

                public uint sparseResidencyImage3D;

                public uint sparseResidency2Samples;

                public uint sparseResidency4Samples;

                public uint sparseResidency8Samples;

                public uint sparseResidency16Samples;

                public uint sparseResidencyAliased;

                public uint variableMultisampleRate;

                public uint inheritedQueries;
    }

    public partial struct VkPhysicalDeviceLimits
    {
                public uint maxImageDimension1D;

                public uint maxImageDimension2D;

                public uint maxImageDimension3D;

                public uint maxImageDimensionCube;

                public uint maxImageArrayLayers;

                public uint maxTexelBufferElements;

                public uint maxUniformBufferRange;

                public uint maxStorageBufferRange;

                public uint maxPushConstantsSize;

                public uint maxMemoryAllocationCount;

                public uint maxSamplerAllocationCount;

                public ulong bufferImageGranularity;

                public ulong sparseAddressSpaceSize;

                public uint maxBoundDescriptorSets;

                public uint maxPerStageDescriptorSamplers;

                public uint maxPerStageDescriptorUniformBuffers;

                public uint maxPerStageDescriptorStorageBuffers;

                public uint maxPerStageDescriptorSampledImages;

                public uint maxPerStageDescriptorStorageImages;

                public uint maxPerStageDescriptorInputAttachments;

                public uint maxPerStageResources;

                public uint maxDescriptorSetSamplers;

                public uint maxDescriptorSetUniformBuffers;

                public uint maxDescriptorSetUniformBuffersDynamic;

                public uint maxDescriptorSetStorageBuffers;

                public uint maxDescriptorSetStorageBuffersDynamic;

                public uint maxDescriptorSetSampledImages;

                public uint maxDescriptorSetStorageImages;

                public uint maxDescriptorSetInputAttachments;

                public uint maxVertexInputAttributes;

                public uint maxVertexInputBindings;

                public uint maxVertexInputAttributeOffset;

                public uint maxVertexInputBindingStride;

                public uint maxVertexOutputComponents;

                public uint maxTessellationGenerationLevel;

                public uint maxTessellationPatchSize;

                public uint maxTessellationControlPerVertexInputComponents;

                public uint maxTessellationControlPerVertexOutputComponents;

                public uint maxTessellationControlPerPatchOutputComponents;

                public uint maxTessellationControlTotalOutputComponents;

                public uint maxTessellationEvaluationInputComponents;

                public uint maxTessellationEvaluationOutputComponents;

                public uint maxGeometryShaderInvocations;

                public uint maxGeometryInputComponents;

                public uint maxGeometryOutputComponents;

                public uint maxGeometryOutputVertices;

                public uint maxGeometryTotalOutputComponents;

                public uint maxFragmentInputComponents;

                public uint maxFragmentOutputAttachments;

                public uint maxFragmentDualSrcAttachments;

                public uint maxFragmentCombinedOutputResources;

                public uint maxComputeSharedMemorySize;

                public _maxComputeWorkGroupCount_e__FixedBuffer maxComputeWorkGroupCount;

                public uint maxComputeWorkGroupInvocations;

                public _maxComputeWorkGroupSize_e__FixedBuffer maxComputeWorkGroupSize;

                public uint subPixelPrecisionBits;

                public uint subTexelPrecisionBits;

                public uint mipmapPrecisionBits;

                public uint maxDrawIndexedIndexValue;

                public uint maxDrawIndirectCount;

        public float maxSamplerLodBias;

        public float maxSamplerAnisotropy;

                public uint maxViewports;

                public _maxViewportDimensions_e__FixedBuffer maxViewportDimensions;

                public _viewportBoundsRange_e__FixedBuffer viewportBoundsRange;

                public uint viewportSubPixelBits;

                public nuint minMemoryMapAlignment;

                public ulong minTexelBufferOffsetAlignment;

                public ulong minUniformBufferOffsetAlignment;

                public ulong minStorageBufferOffsetAlignment;

                public int minTexelOffset;

                public uint maxTexelOffset;

                public int minTexelGatherOffset;

                public uint maxTexelGatherOffset;

        public float minInterpolationOffset;

        public float maxInterpolationOffset;

                public uint subPixelInterpolationOffsetBits;

                public uint maxFramebufferWidth;

                public uint maxFramebufferHeight;

                public uint maxFramebufferLayers;

                public uint framebufferColorSampleCounts;

                public uint framebufferDepthSampleCounts;

                public uint framebufferStencilSampleCounts;

                public uint framebufferNoAttachmentsSampleCounts;

                public uint maxColorAttachments;

                public uint sampledImageColorSampleCounts;

                public uint sampledImageIntegerSampleCounts;

                public uint sampledImageDepthSampleCounts;

                public uint sampledImageStencilSampleCounts;

                public uint storageImageSampleCounts;

                public uint maxSampleMaskWords;

                public uint timestampComputeAndGraphics;

        public float timestampPeriod;

                public uint maxClipDistances;

                public uint maxCullDistances;

                public uint maxCombinedClipAndCullDistances;

                public uint discreteQueuePriorities;

                public _pointSizeRange_e__FixedBuffer pointSizeRange;

                public _lineWidthRange_e__FixedBuffer lineWidthRange;

        public float pointSizeGranularity;

        public float lineWidthGranularity;

                public uint strictLines;

                public uint standardSampleLocations;

                public ulong optimalBufferCopyOffsetAlignment;

                public ulong optimalBufferCopyRowPitchAlignment;

                public ulong nonCoherentAtomSize;

        [InlineArray(3)]
        public partial struct _maxComputeWorkGroupCount_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(3)]
        public partial struct _maxComputeWorkGroupSize_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(2)]
        public partial struct _maxViewportDimensions_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(2)]
        public partial struct _viewportBoundsRange_e__FixedBuffer
        {
            public float e0;
        }

        [InlineArray(2)]
        public partial struct _pointSizeRange_e__FixedBuffer
        {
            public float e0;
        }

        [InlineArray(2)]
        public partial struct _lineWidthRange_e__FixedBuffer
        {
            public float e0;
        }
    }

    public partial struct VkPhysicalDeviceMemoryProperties
    {
                public uint memoryTypeCount;

                public _memoryTypes_e__FixedBuffer memoryTypes;

                public uint memoryHeapCount;

                public _memoryHeaps_e__FixedBuffer memoryHeaps;

        [InlineArray(32)]
        public partial struct _memoryTypes_e__FixedBuffer
        {
            public VkMemoryType e0;
        }

        [InlineArray(16)]
        public partial struct _memoryHeaps_e__FixedBuffer
        {
            public VkMemoryHeap e0;
        }
    }

    public partial struct VkPhysicalDeviceSparseProperties
    {
                public uint residencyStandard2DBlockShape;

                public uint residencyStandard2DMultisampleBlockShape;

                public uint residencyStandard3DBlockShape;

                public uint residencyAlignedMipSize;

                public uint residencyNonResidentStrict;
    }

    public partial struct VkPhysicalDeviceProperties
    {
                public uint apiVersion;

                public uint driverVersion;

                public uint vendorID;

                public uint deviceID;

        public VkPhysicalDeviceType deviceType;

                public _deviceName_e__FixedBuffer deviceName;

                public _pipelineCacheUUID_e__FixedBuffer pipelineCacheUUID;

        public VkPhysicalDeviceLimits limits;

        public VkPhysicalDeviceSparseProperties sparseProperties;

        [InlineArray(256)]
        public partial struct _deviceName_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(16)]
        public partial struct _pipelineCacheUUID_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct VkQueueFamilyProperties
    {
                public uint queueFlags;

                public uint queueCount;

                public uint timestampValidBits;

        public VkExtent3D minImageTransferGranularity;
    }

    public unsafe partial struct VkDeviceQueueCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint queueFamilyIndex;

                public uint queueCount;

                public float* pQueuePriorities;
    }

    public unsafe partial struct VkDeviceCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint queueCreateInfoCount;

                public VkDeviceQueueCreateInfo* pQueueCreateInfos;

                public uint enabledLayerCount;

                public sbyte** ppEnabledLayerNames;

                public uint enabledExtensionCount;

                public sbyte** ppEnabledExtensionNames;

                public VkPhysicalDeviceFeatures* pEnabledFeatures;
    }

    public partial struct VkExtensionProperties
    {
                public _extensionName_e__FixedBuffer extensionName;

                public uint specVersion;

        [InlineArray(256)]
        public partial struct _extensionName_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public partial struct VkLayerProperties
    {
                public _layerName_e__FixedBuffer layerName;

                public uint specVersion;

                public uint implementationVersion;

                public _description_e__FixedBuffer description;

        [InlineArray(256)]
        public partial struct _layerName_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkSubmitInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint waitSemaphoreCount;

                public VkSemaphore** pWaitSemaphores;

                public uint* pWaitDstStageMask;

                public uint commandBufferCount;

                public VkCommandBuffer** pCommandBuffers;

                public uint signalSemaphoreCount;

                public VkSemaphore** pSignalSemaphores;
    }

    public unsafe partial struct VkMappedMemoryRange
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDeviceMemory* memory;

                public ulong offset;

                public ulong size;
    }

    public unsafe partial struct VkMemoryAllocateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong allocationSize;

                public uint memoryTypeIndex;
    }

    public partial struct VkMemoryRequirements
    {
                public ulong size;

                public ulong alignment;

                public uint memoryTypeBits;
    }

    public partial struct VkImageSubresource
    {
                public uint aspectMask;

                public uint mipLevel;

                public uint arrayLayer;
    }

    public partial struct VkSparseImageFormatProperties
    {
                public uint aspectMask;

        public VkExtent3D imageGranularity;

                public uint flags;
    }

    public unsafe partial struct VkSparseImageMemoryBind
    {
        public VkImageSubresource subresource;

        public VkOffset3D offset;

        public VkExtent3D extent;

                public VkDeviceMemory* memory;

                public ulong memoryOffset;

                public uint flags;
    }

    public unsafe partial struct VkSparseImageMemoryBindInfo
    {
                public VkImage* image;

                public uint bindCount;

                public VkSparseImageMemoryBind* pBinds;
    }

    public partial struct VkSparseImageMemoryRequirements
    {
        public VkSparseImageFormatProperties formatProperties;

                public uint imageMipTailFirstLod;

                public ulong imageMipTailSize;

                public ulong imageMipTailOffset;

                public ulong imageMipTailStride;
    }

    public unsafe partial struct VkSparseMemoryBind
    {
                public ulong resourceOffset;

                public ulong size;

                public VkDeviceMemory* memory;

                public ulong memoryOffset;

                public uint flags;
    }

    public unsafe partial struct VkSparseBufferMemoryBindInfo
    {
                public VkBuffer* buffer;

                public uint bindCount;

                public VkSparseMemoryBind* pBinds;
    }

    public unsafe partial struct VkSparseImageOpaqueMemoryBindInfo
    {
                public VkImage* image;

                public uint bindCount;

                public VkSparseMemoryBind* pBinds;
    }

    public unsafe partial struct VkBindSparseInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint waitSemaphoreCount;

                public VkSemaphore** pWaitSemaphores;

                public uint bufferBindCount;

                public VkSparseBufferMemoryBindInfo* pBufferBinds;

                public uint imageOpaqueBindCount;

                public VkSparseImageOpaqueMemoryBindInfo* pImageOpaqueBinds;

                public uint imageBindCount;

                public VkSparseImageMemoryBindInfo* pImageBinds;

                public uint signalSemaphoreCount;

                public VkSemaphore** pSignalSemaphores;
    }

    public unsafe partial struct VkFenceCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkSemaphoreCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkQueryPoolCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkQueryType queryType;

                public uint queryCount;

                public uint pipelineStatistics;
    }

    public unsafe partial struct VkBufferCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public ulong size;

                public uint usage;

        public VkSharingMode sharingMode;

                public uint queueFamilyIndexCount;

                public uint* pQueueFamilyIndices;
    }

    public unsafe partial struct VkImageCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkImageType imageType;

        public VkFormat format;

        public VkExtent3D extent;

                public uint mipLevels;

                public uint arrayLayers;

        public VkSampleCountFlagBits samples;

        public VkImageTiling tiling;

                public uint usage;

        public VkSharingMode sharingMode;

                public uint queueFamilyIndexCount;

                public uint* pQueueFamilyIndices;

        public VkImageLayout initialLayout;
    }

    public partial struct VkSubresourceLayout
    {
                public ulong offset;

                public ulong size;

                public ulong rowPitch;

                public ulong arrayPitch;

                public ulong depthPitch;
    }

    public partial struct VkComponentMapping
    {
        public VkComponentSwizzle r;

        public VkComponentSwizzle g;

        public VkComponentSwizzle b;

        public VkComponentSwizzle a;
    }

    public partial struct VkImageSubresourceRange
    {
                public uint aspectMask;

                public uint baseMipLevel;

                public uint levelCount;

                public uint baseArrayLayer;

                public uint layerCount;
    }

    public unsafe partial struct VkImageViewCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkImage* image;

        public VkImageViewType viewType;

        public VkFormat format;

        public VkComponentMapping components;

        public VkImageSubresourceRange subresourceRange;
    }

    public unsafe partial struct VkCommandPoolCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint queueFamilyIndex;
    }

    public unsafe partial struct VkCommandBufferAllocateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkCommandPool* commandPool;

        public VkCommandBufferLevel level;

                public uint commandBufferCount;
    }

    public unsafe partial struct VkCommandBufferInheritanceInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkRenderPass* renderPass;

                public uint subpass;

                public VkFramebuffer* framebuffer;

                public uint occlusionQueryEnable;

                public uint queryFlags;

                public uint pipelineStatistics;
    }

    public unsafe partial struct VkCommandBufferBeginInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkCommandBufferInheritanceInfo* pInheritanceInfo;
    }

    public partial struct VkBufferCopy
    {
                public ulong srcOffset;

                public ulong dstOffset;

                public ulong size;
    }

    public partial struct VkImageSubresourceLayers
    {
                public uint aspectMask;

                public uint mipLevel;

                public uint baseArrayLayer;

                public uint layerCount;
    }

    public partial struct VkBufferImageCopy
    {
                public ulong bufferOffset;

                public uint bufferRowLength;

                public uint bufferImageHeight;

        public VkImageSubresourceLayers imageSubresource;

        public VkOffset3D imageOffset;

        public VkExtent3D imageExtent;
    }

    public partial struct VkImageCopy
    {
        public VkImageSubresourceLayers srcSubresource;

        public VkOffset3D srcOffset;

        public VkImageSubresourceLayers dstSubresource;

        public VkOffset3D dstOffset;

        public VkExtent3D extent;
    }

    public unsafe partial struct VkBufferMemoryBarrier
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint srcAccessMask;

                public uint dstAccessMask;

                public uint srcQueueFamilyIndex;

                public uint dstQueueFamilyIndex;

                public VkBuffer* buffer;

                public ulong offset;

                public ulong size;
    }

    public unsafe partial struct VkImageMemoryBarrier
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint srcAccessMask;

                public uint dstAccessMask;

        public VkImageLayout oldLayout;

        public VkImageLayout newLayout;

                public uint srcQueueFamilyIndex;

                public uint dstQueueFamilyIndex;

                public VkImage* image;

        public VkImageSubresourceRange subresourceRange;
    }

    public unsafe partial struct VkMemoryBarrier
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint srcAccessMask;

                public uint dstAccessMask;
    }

    public partial struct VkDispatchIndirectCommand
    {
                public uint x;

                public uint y;

                public uint z;
    }

    public partial struct VkPipelineCacheHeaderVersionOne
    {
                public uint headerSize;

        public VkPipelineCacheHeaderVersion headerVersion;

                public uint vendorID;

                public uint deviceID;

                public _pipelineCacheUUID_e__FixedBuffer pipelineCacheUUID;

        [InlineArray(16)]
        public partial struct _pipelineCacheUUID_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkEventCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkBufferViewCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkBuffer* buffer;

        public VkFormat format;

                public ulong offset;

                public ulong range;
    }

    public unsafe partial struct VkShaderModuleCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public nuint codeSize;

                public uint* pCode;
    }

    public unsafe partial struct VkPipelineCacheCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public nuint initialDataSize;

                public void* pInitialData;
    }

    public partial struct VkSpecializationMapEntry
    {
                public uint constantID;

                public uint offset;

                public nuint size;
    }

    public unsafe partial struct VkSpecializationInfo
    {
                public uint mapEntryCount;

                public VkSpecializationMapEntry* pMapEntries;

                public nuint dataSize;

                public void* pData;
    }

    public unsafe partial struct VkPipelineShaderStageCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkShaderStageFlagBits stage;

                public VkShaderModule* module;

                public sbyte* pName;

                public VkSpecializationInfo* pSpecializationInfo;
    }

    public unsafe partial struct VkComputePipelineCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkPipelineShaderStageCreateInfo stage;

                public VkPipelineLayout* layout;

                public VkPipeline* basePipelineHandle;

                public int basePipelineIndex;
    }

    public partial struct VkPushConstantRange
    {
                public uint stageFlags;

                public uint offset;

                public uint size;
    }

    public unsafe partial struct VkPipelineLayoutCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint setLayoutCount;

                public VkDescriptorSetLayout** pSetLayouts;

                public uint pushConstantRangeCount;

                public VkPushConstantRange* pPushConstantRanges;
    }

    public unsafe partial struct VkSamplerCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkFilter magFilter;

        public VkFilter minFilter;

        public VkSamplerMipmapMode mipmapMode;

        public VkSamplerAddressMode addressModeU;

        public VkSamplerAddressMode addressModeV;

        public VkSamplerAddressMode addressModeW;

        public float mipLodBias;

                public uint anisotropyEnable;

        public float maxAnisotropy;

                public uint compareEnable;

        public VkCompareOp compareOp;

        public float minLod;

        public float maxLod;

        public VkBorderColor borderColor;

                public uint unnormalizedCoordinates;
    }

    public unsafe partial struct VkCopyDescriptorSet
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDescriptorSet* srcSet;

                public uint srcBinding;

                public uint srcArrayElement;

                public VkDescriptorSet* dstSet;

                public uint dstBinding;

                public uint dstArrayElement;

                public uint descriptorCount;
    }

    public unsafe partial struct VkDescriptorBufferInfo
    {
                public VkBuffer* buffer;

                public ulong offset;

                public ulong range;
    }

    public unsafe partial struct VkDescriptorImageInfo
    {
                public VkSampler* sampler;

                public VkImageView* imageView;

        public VkImageLayout imageLayout;
    }

    public partial struct VkDescriptorPoolSize
    {
        public VkDescriptorType type;

                public uint descriptorCount;
    }

    public unsafe partial struct VkDescriptorPoolCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint maxSets;

                public uint poolSizeCount;

                public VkDescriptorPoolSize* pPoolSizes;
    }

    public unsafe partial struct VkDescriptorSetAllocateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDescriptorPool* descriptorPool;

                public uint descriptorSetCount;

                public VkDescriptorSetLayout** pSetLayouts;
    }

    public unsafe partial struct VkDescriptorSetLayoutBinding
    {
                public uint binding;

        public VkDescriptorType descriptorType;

                public uint descriptorCount;

                public uint stageFlags;

                public VkSampler** pImmutableSamplers;
    }

    public unsafe partial struct VkDescriptorSetLayoutCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint bindingCount;

                public VkDescriptorSetLayoutBinding* pBindings;
    }

    public unsafe partial struct VkWriteDescriptorSet
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDescriptorSet* dstSet;

                public uint dstBinding;

                public uint dstArrayElement;

                public uint descriptorCount;

        public VkDescriptorType descriptorType;

                public VkDescriptorImageInfo* pImageInfo;

                public VkDescriptorBufferInfo* pBufferInfo;

                public VkBufferView** pTexelBufferView;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct VkClearColorValue
    {
        [FieldOffset(0)]
                public _float32_e__FixedBuffer float32;

        [FieldOffset(0)]
                public _int32_e__FixedBuffer int32;

        [FieldOffset(0)]
                public _uint32_e__FixedBuffer uint32;

        [InlineArray(4)]
        public partial struct _float32_e__FixedBuffer
        {
            public float e0;
        }

        [InlineArray(4)]
        public partial struct _int32_e__FixedBuffer
        {
            public int e0;
        }

        [InlineArray(4)]
        public partial struct _uint32_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public partial struct VkDrawIndexedIndirectCommand
    {
                public uint indexCount;

                public uint instanceCount;

                public uint firstIndex;

                public int vertexOffset;

                public uint firstInstance;
    }

    public partial struct VkDrawIndirectCommand
    {
                public uint vertexCount;

                public uint instanceCount;

                public uint firstVertex;

                public uint firstInstance;
    }

    public partial struct VkStencilOpState
    {
        public VkStencilOp failOp;

        public VkStencilOp passOp;

        public VkStencilOp depthFailOp;

        public VkCompareOp compareOp;

                public uint compareMask;

                public uint writeMask;

                public uint reference;
    }

    public partial struct VkVertexInputAttributeDescription
    {
                public uint location;

                public uint binding;

        public VkFormat format;

                public uint offset;
    }

    public partial struct VkVertexInputBindingDescription
    {
                public uint binding;

                public uint stride;

        public VkVertexInputRate inputRate;
    }

    public partial struct VkViewport
    {
        public float x;

        public float y;

        public float width;

        public float height;

        public float minDepth;

        public float maxDepth;
    }

    public partial struct VkPipelineColorBlendAttachmentState
    {
                public uint blendEnable;

        public VkBlendFactor srcColorBlendFactor;

        public VkBlendFactor dstColorBlendFactor;

        public VkBlendOp colorBlendOp;

        public VkBlendFactor srcAlphaBlendFactor;

        public VkBlendFactor dstAlphaBlendFactor;

        public VkBlendOp alphaBlendOp;

                public uint colorWriteMask;
    }

    public unsafe partial struct VkPipelineColorBlendStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint logicOpEnable;

        public VkLogicOp logicOp;

                public uint attachmentCount;

                public VkPipelineColorBlendAttachmentState* pAttachments;

                public _blendConstants_e__FixedBuffer blendConstants;

        [InlineArray(4)]
        public partial struct _blendConstants_e__FixedBuffer
        {
            public float e0;
        }
    }

    public unsafe partial struct VkPipelineDepthStencilStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint depthTestEnable;

                public uint depthWriteEnable;

        public VkCompareOp depthCompareOp;

                public uint depthBoundsTestEnable;

                public uint stencilTestEnable;

        public VkStencilOpState front;

        public VkStencilOpState back;

        public float minDepthBounds;

        public float maxDepthBounds;
    }

    public unsafe partial struct VkPipelineDynamicStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint dynamicStateCount;

                public VkDynamicState* pDynamicStates;
    }

    public unsafe partial struct VkPipelineInputAssemblyStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkPrimitiveTopology topology;

                public uint primitiveRestartEnable;
    }

    public unsafe partial struct VkPipelineMultisampleStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkSampleCountFlagBits rasterizationSamples;

                public uint sampleShadingEnable;

        public float minSampleShading;

                public uint* pSampleMask;

                public uint alphaToCoverageEnable;

                public uint alphaToOneEnable;
    }

    public unsafe partial struct VkPipelineRasterizationStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint depthClampEnable;

                public uint rasterizerDiscardEnable;

        public VkPolygonMode polygonMode;

                public uint cullMode;

        public VkFrontFace frontFace;

                public uint depthBiasEnable;

        public float depthBiasConstantFactor;

        public float depthBiasClamp;

        public float depthBiasSlopeFactor;

        public float lineWidth;
    }

    public unsafe partial struct VkPipelineTessellationStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint patchControlPoints;
    }

    public unsafe partial struct VkPipelineVertexInputStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint vertexBindingDescriptionCount;

                public VkVertexInputBindingDescription* pVertexBindingDescriptions;

                public uint vertexAttributeDescriptionCount;

                public VkVertexInputAttributeDescription* pVertexAttributeDescriptions;
    }

    public unsafe partial struct VkPipelineViewportStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint viewportCount;

                public VkViewport* pViewports;

                public uint scissorCount;

                public VkRect2D* pScissors;
    }

    public unsafe partial struct VkGraphicsPipelineCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint stageCount;

                public VkPipelineShaderStageCreateInfo* pStages;

                public VkPipelineVertexInputStateCreateInfo* pVertexInputState;

                public VkPipelineInputAssemblyStateCreateInfo* pInputAssemblyState;

                public VkPipelineTessellationStateCreateInfo* pTessellationState;

                public VkPipelineViewportStateCreateInfo* pViewportState;

                public VkPipelineRasterizationStateCreateInfo* pRasterizationState;

                public VkPipelineMultisampleStateCreateInfo* pMultisampleState;

                public VkPipelineDepthStencilStateCreateInfo* pDepthStencilState;

                public VkPipelineColorBlendStateCreateInfo* pColorBlendState;

                public VkPipelineDynamicStateCreateInfo* pDynamicState;

                public VkPipelineLayout* layout;

                public VkRenderPass* renderPass;

                public uint subpass;

                public VkPipeline* basePipelineHandle;

                public int basePipelineIndex;
    }

    public partial struct VkAttachmentDescription
    {
                public uint flags;

        public VkFormat format;

        public VkSampleCountFlagBits samples;

        public VkAttachmentLoadOp loadOp;

        public VkAttachmentStoreOp storeOp;

        public VkAttachmentLoadOp stencilLoadOp;

        public VkAttachmentStoreOp stencilStoreOp;

        public VkImageLayout initialLayout;

        public VkImageLayout finalLayout;
    }

    public partial struct VkAttachmentReference
    {
                public uint attachment;

        public VkImageLayout layout;
    }

    public unsafe partial struct VkFramebufferCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkRenderPass* renderPass;

                public uint attachmentCount;

                public VkImageView** pAttachments;

                public uint width;

                public uint height;

                public uint layers;
    }

    public partial struct VkSubpassDependency
    {
                public uint srcSubpass;

                public uint dstSubpass;

                public uint srcStageMask;

                public uint dstStageMask;

                public uint srcAccessMask;

                public uint dstAccessMask;

                public uint dependencyFlags;
    }

    public unsafe partial struct VkSubpassDescription
    {
                public uint flags;

        public VkPipelineBindPoint pipelineBindPoint;

                public uint inputAttachmentCount;

                public VkAttachmentReference* pInputAttachments;

                public uint colorAttachmentCount;

                public VkAttachmentReference* pColorAttachments;

                public VkAttachmentReference* pResolveAttachments;

                public VkAttachmentReference* pDepthStencilAttachment;

                public uint preserveAttachmentCount;

                public uint* pPreserveAttachments;
    }

    public unsafe partial struct VkRenderPassCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint attachmentCount;

                public VkAttachmentDescription* pAttachments;

                public uint subpassCount;

                public VkSubpassDescription* pSubpasses;

                public uint dependencyCount;

                public VkSubpassDependency* pDependencies;
    }

    public partial struct VkClearDepthStencilValue
    {
        public float depth;

                public uint stencil;
    }

    public partial struct VkClearRect
    {
        public VkRect2D rect;

                public uint baseArrayLayer;

                public uint layerCount;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct VkClearValue
    {
        [FieldOffset(0)]
        public VkClearColorValue color;

        [FieldOffset(0)]
        public VkClearDepthStencilValue depthStencil;
    }

    public partial struct VkClearAttachment
    {
                public uint aspectMask;

                public uint colorAttachment;

        public VkClearValue clearValue;
    }

    public partial struct VkImageBlit
    {
        public VkImageSubresourceLayers srcSubresource;

                public _srcOffsets_e__FixedBuffer srcOffsets;

        public VkImageSubresourceLayers dstSubresource;

                public _dstOffsets_e__FixedBuffer dstOffsets;

        [InlineArray(2)]
        public partial struct _srcOffsets_e__FixedBuffer
        {
            public VkOffset3D e0;
        }

        [InlineArray(2)]
        public partial struct _dstOffsets_e__FixedBuffer
        {
            public VkOffset3D e0;
        }
    }

    public partial struct VkImageResolve
    {
        public VkImageSubresourceLayers srcSubresource;

        public VkOffset3D srcOffset;

        public VkImageSubresourceLayers dstSubresource;

        public VkOffset3D dstOffset;

        public VkExtent3D extent;
    }

    public unsafe partial struct VkRenderPassBeginInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkRenderPass* renderPass;

                public VkFramebuffer* framebuffer;

        public VkRect2D renderArea;

                public uint clearValueCount;

                public VkClearValue* pClearValues;
    }

    public partial struct VkDescriptorUpdateTemplate
    {
    }

    public partial struct VkSamplerYcbcrConversion
    {
    }

    public unsafe partial struct VkBindBufferMemoryInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBuffer* buffer;

                public VkDeviceMemory* memory;

                public ulong memoryOffset;
    }

    public unsafe partial struct VkBindImageMemoryInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* image;

                public VkDeviceMemory* memory;

                public ulong memoryOffset;
    }

    public unsafe partial struct VkMemoryDedicatedRequirements
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint prefersDedicatedAllocation;

                public uint requiresDedicatedAllocation;
    }

    public unsafe partial struct VkMemoryDedicatedAllocateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* image;

                public VkBuffer* buffer;
    }

    public unsafe partial struct VkMemoryAllocateFlagsInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint deviceMask;
    }

    public unsafe partial struct VkDeviceGroupCommandBufferBeginInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint deviceMask;
    }

    public unsafe partial struct VkDeviceGroupSubmitInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint waitSemaphoreCount;

                public uint* pWaitSemaphoreDeviceIndices;

                public uint commandBufferCount;

                public uint* pCommandBufferDeviceMasks;

                public uint signalSemaphoreCount;

                public uint* pSignalSemaphoreDeviceIndices;
    }

    public unsafe partial struct VkDeviceGroupBindSparseInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint resourceDeviceIndex;

                public uint memoryDeviceIndex;
    }

    public unsafe partial struct VkBindBufferMemoryDeviceGroupInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint deviceIndexCount;

                public uint* pDeviceIndices;
    }

    public unsafe partial struct VkBindImageMemoryDeviceGroupInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint deviceIndexCount;

                public uint* pDeviceIndices;

                public uint splitInstanceBindRegionCount;

                public VkRect2D* pSplitInstanceBindRegions;
    }

    public unsafe partial struct VkPhysicalDeviceGroupProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint physicalDeviceCount;

                public _physicalDevices_e__FixedBuffer physicalDevices;

                public uint subsetAllocation;

        public unsafe partial struct _physicalDevices_e__FixedBuffer
        {
            public VkPhysicalDevice* e0;
            public VkPhysicalDevice* e1;
            public VkPhysicalDevice* e2;
            public VkPhysicalDevice* e3;
            public VkPhysicalDevice* e4;
            public VkPhysicalDevice* e5;
            public VkPhysicalDevice* e6;
            public VkPhysicalDevice* e7;
            public VkPhysicalDevice* e8;
            public VkPhysicalDevice* e9;
            public VkPhysicalDevice* e10;
            public VkPhysicalDevice* e11;
            public VkPhysicalDevice* e12;
            public VkPhysicalDevice* e13;
            public VkPhysicalDevice* e14;
            public VkPhysicalDevice* e15;
            public VkPhysicalDevice* e16;
            public VkPhysicalDevice* e17;
            public VkPhysicalDevice* e18;
            public VkPhysicalDevice* e19;
            public VkPhysicalDevice* e20;
            public VkPhysicalDevice* e21;
            public VkPhysicalDevice* e22;
            public VkPhysicalDevice* e23;
            public VkPhysicalDevice* e24;
            public VkPhysicalDevice* e25;
            public VkPhysicalDevice* e26;
            public VkPhysicalDevice* e27;
            public VkPhysicalDevice* e28;
            public VkPhysicalDevice* e29;
            public VkPhysicalDevice* e30;
            public VkPhysicalDevice* e31;

            public ref VkPhysicalDevice* this[int index]
            {
                get
                {
                    fixed (VkPhysicalDevice** pThis = &e0)
                    {
                        return ref pThis[index];
                    }
                }
            }
        }
    }

    public unsafe partial struct VkDeviceGroupDeviceCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint physicalDeviceCount;

                public VkPhysicalDevice** pPhysicalDevices;
    }

    public unsafe partial struct VkBufferMemoryRequirementsInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBuffer* buffer;
    }

    public unsafe partial struct VkImageMemoryRequirementsInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* image;
    }

    public unsafe partial struct VkImageSparseMemoryRequirementsInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* image;
    }

    public unsafe partial struct VkMemoryRequirements2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkMemoryRequirements memoryRequirements;
    }

    public unsafe partial struct VkSparseImageMemoryRequirements2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkSparseImageMemoryRequirements memoryRequirements;
    }

    public unsafe partial struct VkPhysicalDeviceFeatures2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPhysicalDeviceFeatures features;
    }

    public unsafe partial struct VkPhysicalDeviceProperties2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPhysicalDeviceProperties properties;
    }

    public unsafe partial struct VkFormatProperties2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkFormatProperties formatProperties;
    }

    public unsafe partial struct VkImageFormatProperties2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkImageFormatProperties imageFormatProperties;
    }

    public unsafe partial struct VkPhysicalDeviceImageFormatInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkFormat format;

        public VkImageType type;

        public VkImageTiling tiling;

                public uint usage;

                public uint flags;
    }

    public unsafe partial struct VkQueueFamilyProperties2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkQueueFamilyProperties queueFamilyProperties;
    }

    public unsafe partial struct VkPhysicalDeviceMemoryProperties2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPhysicalDeviceMemoryProperties memoryProperties;
    }

    public unsafe partial struct VkSparseImageFormatProperties2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkSparseImageFormatProperties properties;
    }

    public unsafe partial struct VkPhysicalDeviceSparseImageFormatInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkFormat format;

        public VkImageType type;

        public VkSampleCountFlagBits samples;

                public uint usage;

        public VkImageTiling tiling;
    }

    public unsafe partial struct VkImageViewUsageCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint usage;
    }

    public unsafe partial struct VkPhysicalDeviceProtectedMemoryFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint protectedMemory;
    }

    public unsafe partial struct VkPhysicalDeviceProtectedMemoryProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint protectedNoFault;
    }

    public unsafe partial struct VkDeviceQueueInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint queueFamilyIndex;

                public uint queueIndex;
    }

    public unsafe partial struct VkProtectedSubmitInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint protectedSubmit;
    }

    public unsafe partial struct VkBindImagePlaneMemoryInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkImageAspectFlagBits planeAspect;
    }

    public unsafe partial struct VkImagePlaneMemoryRequirementsInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkImageAspectFlagBits planeAspect;
    }

    public partial struct VkExternalMemoryProperties
    {
                public uint externalMemoryFeatures;

                public uint exportFromImportedHandleTypes;

                public uint compatibleHandleTypes;
    }

    public unsafe partial struct VkPhysicalDeviceExternalImageFormatInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExternalMemoryHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkExternalImageFormatProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExternalMemoryProperties externalMemoryProperties;
    }

    public unsafe partial struct VkPhysicalDeviceExternalBufferInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint usage;

        public VkExternalMemoryHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkExternalBufferProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExternalMemoryProperties externalMemoryProperties;
    }

    public unsafe partial struct VkPhysicalDeviceIDProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _deviceUUID_e__FixedBuffer deviceUUID;

                public _driverUUID_e__FixedBuffer driverUUID;

                public _deviceLUID_e__FixedBuffer deviceLUID;

                public uint deviceNodeMask;

                public uint deviceLUIDValid;

        [InlineArray(16)]
        public partial struct _deviceUUID_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(16)]
        public partial struct _driverUUID_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _deviceLUID_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkExternalMemoryImageCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint handleTypes;
    }

    public unsafe partial struct VkExternalMemoryBufferCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint handleTypes;
    }

    public unsafe partial struct VkExportMemoryAllocateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint handleTypes;
    }

    public unsafe partial struct VkPhysicalDeviceExternalFenceInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExternalFenceHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkExternalFenceProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint exportFromImportedHandleTypes;

                public uint compatibleHandleTypes;

                public uint externalFenceFeatures;
    }

    public unsafe partial struct VkExportFenceCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint handleTypes;
    }

    public unsafe partial struct VkExportSemaphoreCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint handleTypes;
    }

    public unsafe partial struct VkPhysicalDeviceExternalSemaphoreInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExternalSemaphoreHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkExternalSemaphoreProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint exportFromImportedHandleTypes;

                public uint compatibleHandleTypes;

                public uint externalSemaphoreFeatures;
    }

    public unsafe partial struct VkPhysicalDeviceSubgroupProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint subgroupSize;

                public uint supportedStages;

                public uint supportedOperations;

                public uint quadOperationsInAllStages;
    }

    public unsafe partial struct VkPhysicalDevice16BitStorageFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint storageBuffer16BitAccess;

                public uint uniformAndStorageBuffer16BitAccess;

                public uint storagePushConstant16;

                public uint storageInputOutput16;
    }

    public unsafe partial struct VkPhysicalDeviceVariablePointersFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint variablePointersStorageBuffer;

                public uint variablePointers;
    }

    public partial struct VkDescriptorUpdateTemplateEntry
    {
                public uint dstBinding;

                public uint dstArrayElement;

                public uint descriptorCount;

        public VkDescriptorType descriptorType;

                public nuint offset;

                public nuint stride;
    }

    public unsafe partial struct VkDescriptorUpdateTemplateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint descriptorUpdateEntryCount;

                public VkDescriptorUpdateTemplateEntry* pDescriptorUpdateEntries;

        public VkDescriptorUpdateTemplateType templateType;

                public VkDescriptorSetLayout* descriptorSetLayout;

        public VkPipelineBindPoint pipelineBindPoint;

                public VkPipelineLayout* pipelineLayout;

                public uint set;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance3Properties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxPerSetDescriptors;

                public ulong maxMemoryAllocationSize;
    }

    public unsafe partial struct VkDescriptorSetLayoutSupport
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint supported;
    }

    public unsafe partial struct VkSamplerYcbcrConversionCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkFormat format;

        public VkSamplerYcbcrModelConversion ycbcrModel;

        public VkSamplerYcbcrRange ycbcrRange;

        public VkComponentMapping components;

        public VkChromaLocation xChromaOffset;

        public VkChromaLocation yChromaOffset;

        public VkFilter chromaFilter;

                public uint forceExplicitReconstruction;
    }

    public unsafe partial struct VkSamplerYcbcrConversionInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSamplerYcbcrConversion* conversion;
    }

    public unsafe partial struct VkPhysicalDeviceSamplerYcbcrConversionFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint samplerYcbcrConversion;
    }

    public unsafe partial struct VkSamplerYcbcrConversionImageFormatProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint combinedImageSamplerDescriptorCount;
    }

    public unsafe partial struct VkDeviceGroupRenderPassBeginInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint deviceMask;

                public uint deviceRenderAreaCount;

                public VkRect2D* pDeviceRenderAreas;
    }

    public unsafe partial struct VkPhysicalDevicePointClippingProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPointClippingBehavior pointClippingBehavior;
    }

    public partial struct VkInputAttachmentAspectReference
    {
                public uint subpass;

                public uint inputAttachmentIndex;

                public uint aspectMask;
    }

    public unsafe partial struct VkRenderPassInputAttachmentAspectCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint aspectReferenceCount;

                public VkInputAttachmentAspectReference* pAspectReferences;
    }

    public unsafe partial struct VkPipelineTessellationDomainOriginStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkTessellationDomainOrigin domainOrigin;
    }

    public unsafe partial struct VkRenderPassMultiviewCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint subpassCount;

                public uint* pViewMasks;

                public uint dependencyCount;

                public int* pViewOffsets;

                public uint correlationMaskCount;

                public uint* pCorrelationMasks;
    }

    public unsafe partial struct VkPhysicalDeviceMultiviewFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint multiview;

                public uint multiviewGeometryShader;

                public uint multiviewTessellationShader;
    }

    public unsafe partial struct VkPhysicalDeviceMultiviewProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxMultiviewViewCount;

                public uint maxMultiviewInstanceIndex;
    }

    public unsafe partial struct VkPhysicalDeviceShaderDrawParametersFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderDrawParameters;
    }

    public partial struct VkConformanceVersion
    {
                public byte major;

                public byte minor;

                public byte subminor;

                public byte patch;
    }

    public unsafe partial struct VkPhysicalDeviceDriverProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkDriverId driverID;

                public _driverName_e__FixedBuffer driverName;

                public _driverInfo_e__FixedBuffer driverInfo;

        public VkConformanceVersion conformanceVersion;

        [InlineArray(256)]
        public partial struct _driverName_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _driverInfo_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkPhysicalDeviceVulkan11Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint storageBuffer16BitAccess;

                public uint uniformAndStorageBuffer16BitAccess;

                public uint storagePushConstant16;

                public uint storageInputOutput16;

                public uint multiview;

                public uint multiviewGeometryShader;

                public uint multiviewTessellationShader;

                public uint variablePointersStorageBuffer;

                public uint variablePointers;

                public uint protectedMemory;

                public uint samplerYcbcrConversion;

                public uint shaderDrawParameters;
    }

    public unsafe partial struct VkPhysicalDeviceVulkan11Properties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _deviceUUID_e__FixedBuffer deviceUUID;

                public _driverUUID_e__FixedBuffer driverUUID;

                public _deviceLUID_e__FixedBuffer deviceLUID;

                public uint deviceNodeMask;

                public uint deviceLUIDValid;

                public uint subgroupSize;

                public uint subgroupSupportedStages;

                public uint subgroupSupportedOperations;

                public uint subgroupQuadOperationsInAllStages;

        public VkPointClippingBehavior pointClippingBehavior;

                public uint maxMultiviewViewCount;

                public uint maxMultiviewInstanceIndex;

                public uint protectedNoFault;

                public uint maxPerSetDescriptors;

                public ulong maxMemoryAllocationSize;

        [InlineArray(16)]
        public partial struct _deviceUUID_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(16)]
        public partial struct _driverUUID_e__FixedBuffer
        {
            public byte e0;
        }

        [InlineArray(8)]
        public partial struct _deviceLUID_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkPhysicalDeviceVulkan12Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint samplerMirrorClampToEdge;

                public uint drawIndirectCount;

                public uint storageBuffer8BitAccess;

                public uint uniformAndStorageBuffer8BitAccess;

                public uint storagePushConstant8;

                public uint shaderBufferInt64Atomics;

                public uint shaderSharedInt64Atomics;

                public uint shaderFloat16;

                public uint shaderInt8;

                public uint descriptorIndexing;

                public uint shaderInputAttachmentArrayDynamicIndexing;

                public uint shaderUniformTexelBufferArrayDynamicIndexing;

                public uint shaderStorageTexelBufferArrayDynamicIndexing;

                public uint shaderUniformBufferArrayNonUniformIndexing;

                public uint shaderSampledImageArrayNonUniformIndexing;

                public uint shaderStorageBufferArrayNonUniformIndexing;

                public uint shaderStorageImageArrayNonUniformIndexing;

                public uint shaderInputAttachmentArrayNonUniformIndexing;

                public uint shaderUniformTexelBufferArrayNonUniformIndexing;

                public uint shaderStorageTexelBufferArrayNonUniformIndexing;

                public uint descriptorBindingUniformBufferUpdateAfterBind;

                public uint descriptorBindingSampledImageUpdateAfterBind;

                public uint descriptorBindingStorageImageUpdateAfterBind;

                public uint descriptorBindingStorageBufferUpdateAfterBind;

                public uint descriptorBindingUniformTexelBufferUpdateAfterBind;

                public uint descriptorBindingStorageTexelBufferUpdateAfterBind;

                public uint descriptorBindingUpdateUnusedWhilePending;

                public uint descriptorBindingPartiallyBound;

                public uint descriptorBindingVariableDescriptorCount;

                public uint runtimeDescriptorArray;

                public uint samplerFilterMinmax;

                public uint scalarBlockLayout;

                public uint imagelessFramebuffer;

                public uint uniformBufferStandardLayout;

                public uint shaderSubgroupExtendedTypes;

                public uint separateDepthStencilLayouts;

                public uint hostQueryReset;

                public uint timelineSemaphore;

                public uint bufferDeviceAddress;

                public uint bufferDeviceAddressCaptureReplay;

                public uint bufferDeviceAddressMultiDevice;

                public uint vulkanMemoryModel;

                public uint vulkanMemoryModelDeviceScope;

                public uint vulkanMemoryModelAvailabilityVisibilityChains;

                public uint shaderOutputViewportIndex;

                public uint shaderOutputLayer;

                public uint subgroupBroadcastDynamicId;
    }

    public unsafe partial struct VkPhysicalDeviceVulkan12Properties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkDriverId driverID;

                public _driverName_e__FixedBuffer driverName;

                public _driverInfo_e__FixedBuffer driverInfo;

        public VkConformanceVersion conformanceVersion;

        public VkShaderFloatControlsIndependence denormBehaviorIndependence;

        public VkShaderFloatControlsIndependence roundingModeIndependence;

                public uint shaderSignedZeroInfNanPreserveFloat16;

                public uint shaderSignedZeroInfNanPreserveFloat32;

                public uint shaderSignedZeroInfNanPreserveFloat64;

                public uint shaderDenormPreserveFloat16;

                public uint shaderDenormPreserveFloat32;

                public uint shaderDenormPreserveFloat64;

                public uint shaderDenormFlushToZeroFloat16;

                public uint shaderDenormFlushToZeroFloat32;

                public uint shaderDenormFlushToZeroFloat64;

                public uint shaderRoundingModeRTEFloat16;

                public uint shaderRoundingModeRTEFloat32;

                public uint shaderRoundingModeRTEFloat64;

                public uint shaderRoundingModeRTZFloat16;

                public uint shaderRoundingModeRTZFloat32;

                public uint shaderRoundingModeRTZFloat64;

                public uint maxUpdateAfterBindDescriptorsInAllPools;

                public uint shaderUniformBufferArrayNonUniformIndexingNative;

                public uint shaderSampledImageArrayNonUniformIndexingNative;

                public uint shaderStorageBufferArrayNonUniformIndexingNative;

                public uint shaderStorageImageArrayNonUniformIndexingNative;

                public uint shaderInputAttachmentArrayNonUniformIndexingNative;

                public uint robustBufferAccessUpdateAfterBind;

                public uint quadDivergentImplicitLod;

                public uint maxPerStageDescriptorUpdateAfterBindSamplers;

                public uint maxPerStageDescriptorUpdateAfterBindUniformBuffers;

                public uint maxPerStageDescriptorUpdateAfterBindStorageBuffers;

                public uint maxPerStageDescriptorUpdateAfterBindSampledImages;

                public uint maxPerStageDescriptorUpdateAfterBindStorageImages;

                public uint maxPerStageDescriptorUpdateAfterBindInputAttachments;

                public uint maxPerStageUpdateAfterBindResources;

                public uint maxDescriptorSetUpdateAfterBindSamplers;

                public uint maxDescriptorSetUpdateAfterBindUniformBuffers;

                public uint maxDescriptorSetUpdateAfterBindUniformBuffersDynamic;

                public uint maxDescriptorSetUpdateAfterBindStorageBuffers;

                public uint maxDescriptorSetUpdateAfterBindStorageBuffersDynamic;

                public uint maxDescriptorSetUpdateAfterBindSampledImages;

                public uint maxDescriptorSetUpdateAfterBindStorageImages;

                public uint maxDescriptorSetUpdateAfterBindInputAttachments;

                public uint supportedDepthResolveModes;

                public uint supportedStencilResolveModes;

                public uint independentResolveNone;

                public uint independentResolve;

                public uint filterMinmaxSingleComponentFormats;

                public uint filterMinmaxImageComponentMapping;

                public ulong maxTimelineSemaphoreValueDifference;

                public uint framebufferIntegerColorSampleCounts;

        [InlineArray(256)]
        public partial struct _driverName_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _driverInfo_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkImageFormatListCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint viewFormatCount;

                public VkFormat* pViewFormats;
    }

    public unsafe partial struct VkPhysicalDeviceVulkanMemoryModelFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint vulkanMemoryModel;

                public uint vulkanMemoryModelDeviceScope;

                public uint vulkanMemoryModelAvailabilityVisibilityChains;
    }

    public unsafe partial struct VkPhysicalDeviceHostQueryResetFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint hostQueryReset;
    }

    public unsafe partial struct VkPhysicalDeviceTimelineSemaphoreFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint timelineSemaphore;
    }

    public unsafe partial struct VkPhysicalDeviceTimelineSemaphoreProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong maxTimelineSemaphoreValueDifference;
    }

    public unsafe partial struct VkSemaphoreTypeCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkSemaphoreType semaphoreType;

                public ulong initialValue;
    }

    public unsafe partial struct VkTimelineSemaphoreSubmitInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint waitSemaphoreValueCount;

                public ulong* pWaitSemaphoreValues;

                public uint signalSemaphoreValueCount;

                public ulong* pSignalSemaphoreValues;
    }

    public unsafe partial struct VkSemaphoreWaitInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint semaphoreCount;

                public VkSemaphore** pSemaphores;

                public ulong* pValues;
    }

    public unsafe partial struct VkSemaphoreSignalInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSemaphore* semaphore;

                public ulong value;
    }

    public unsafe partial struct VkPhysicalDeviceBufferDeviceAddressFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint bufferDeviceAddress;

                public uint bufferDeviceAddressCaptureReplay;

                public uint bufferDeviceAddressMultiDevice;
    }

    public unsafe partial struct VkBufferDeviceAddressInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBuffer* buffer;
    }

    public unsafe partial struct VkBufferOpaqueCaptureAddressCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong opaqueCaptureAddress;
    }

    public unsafe partial struct VkMemoryOpaqueCaptureAddressAllocateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong opaqueCaptureAddress;
    }

    public unsafe partial struct VkDeviceMemoryOpaqueCaptureAddressInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDeviceMemory* memory;
    }

    public unsafe partial struct VkPhysicalDevice8BitStorageFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint storageBuffer8BitAccess;

                public uint uniformAndStorageBuffer8BitAccess;

                public uint storagePushConstant8;
    }

    public unsafe partial struct VkPhysicalDeviceShaderAtomicInt64Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderBufferInt64Atomics;

                public uint shaderSharedInt64Atomics;
    }

    public unsafe partial struct VkPhysicalDeviceShaderFloat16Int8Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderFloat16;

                public uint shaderInt8;
    }

    public unsafe partial struct VkPhysicalDeviceFloatControlsProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkShaderFloatControlsIndependence denormBehaviorIndependence;

        public VkShaderFloatControlsIndependence roundingModeIndependence;

                public uint shaderSignedZeroInfNanPreserveFloat16;

                public uint shaderSignedZeroInfNanPreserveFloat32;

                public uint shaderSignedZeroInfNanPreserveFloat64;

                public uint shaderDenormPreserveFloat16;

                public uint shaderDenormPreserveFloat32;

                public uint shaderDenormPreserveFloat64;

                public uint shaderDenormFlushToZeroFloat16;

                public uint shaderDenormFlushToZeroFloat32;

                public uint shaderDenormFlushToZeroFloat64;

                public uint shaderRoundingModeRTEFloat16;

                public uint shaderRoundingModeRTEFloat32;

                public uint shaderRoundingModeRTEFloat64;

                public uint shaderRoundingModeRTZFloat16;

                public uint shaderRoundingModeRTZFloat32;

                public uint shaderRoundingModeRTZFloat64;
    }

    public unsafe partial struct VkDescriptorSetLayoutBindingFlagsCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint bindingCount;

                public uint* pBindingFlags;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorIndexingFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderInputAttachmentArrayDynamicIndexing;

                public uint shaderUniformTexelBufferArrayDynamicIndexing;

                public uint shaderStorageTexelBufferArrayDynamicIndexing;

                public uint shaderUniformBufferArrayNonUniformIndexing;

                public uint shaderSampledImageArrayNonUniformIndexing;

                public uint shaderStorageBufferArrayNonUniformIndexing;

                public uint shaderStorageImageArrayNonUniformIndexing;

                public uint shaderInputAttachmentArrayNonUniformIndexing;

                public uint shaderUniformTexelBufferArrayNonUniformIndexing;

                public uint shaderStorageTexelBufferArrayNonUniformIndexing;

                public uint descriptorBindingUniformBufferUpdateAfterBind;

                public uint descriptorBindingSampledImageUpdateAfterBind;

                public uint descriptorBindingStorageImageUpdateAfterBind;

                public uint descriptorBindingStorageBufferUpdateAfterBind;

                public uint descriptorBindingUniformTexelBufferUpdateAfterBind;

                public uint descriptorBindingStorageTexelBufferUpdateAfterBind;

                public uint descriptorBindingUpdateUnusedWhilePending;

                public uint descriptorBindingPartiallyBound;

                public uint descriptorBindingVariableDescriptorCount;

                public uint runtimeDescriptorArray;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorIndexingProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxUpdateAfterBindDescriptorsInAllPools;

                public uint shaderUniformBufferArrayNonUniformIndexingNative;

                public uint shaderSampledImageArrayNonUniformIndexingNative;

                public uint shaderStorageBufferArrayNonUniformIndexingNative;

                public uint shaderStorageImageArrayNonUniformIndexingNative;

                public uint shaderInputAttachmentArrayNonUniformIndexingNative;

                public uint robustBufferAccessUpdateAfterBind;

                public uint quadDivergentImplicitLod;

                public uint maxPerStageDescriptorUpdateAfterBindSamplers;

                public uint maxPerStageDescriptorUpdateAfterBindUniformBuffers;

                public uint maxPerStageDescriptorUpdateAfterBindStorageBuffers;

                public uint maxPerStageDescriptorUpdateAfterBindSampledImages;

                public uint maxPerStageDescriptorUpdateAfterBindStorageImages;

                public uint maxPerStageDescriptorUpdateAfterBindInputAttachments;

                public uint maxPerStageUpdateAfterBindResources;

                public uint maxDescriptorSetUpdateAfterBindSamplers;

                public uint maxDescriptorSetUpdateAfterBindUniformBuffers;

                public uint maxDescriptorSetUpdateAfterBindUniformBuffersDynamic;

                public uint maxDescriptorSetUpdateAfterBindStorageBuffers;

                public uint maxDescriptorSetUpdateAfterBindStorageBuffersDynamic;

                public uint maxDescriptorSetUpdateAfterBindSampledImages;

                public uint maxDescriptorSetUpdateAfterBindStorageImages;

                public uint maxDescriptorSetUpdateAfterBindInputAttachments;
    }

    public unsafe partial struct VkDescriptorSetVariableDescriptorCountAllocateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint descriptorSetCount;

                public uint* pDescriptorCounts;
    }

    public unsafe partial struct VkDescriptorSetVariableDescriptorCountLayoutSupport
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxVariableDescriptorCount;
    }

    public unsafe partial struct VkPhysicalDeviceScalarBlockLayoutFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint scalarBlockLayout;
    }

    public unsafe partial struct VkSamplerReductionModeCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkSamplerReductionMode reductionMode;
    }

    public unsafe partial struct VkPhysicalDeviceSamplerFilterMinmaxProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint filterMinmaxSingleComponentFormats;

                public uint filterMinmaxImageComponentMapping;
    }

    public unsafe partial struct VkPhysicalDeviceUniformBufferStandardLayoutFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint uniformBufferStandardLayout;
    }

    public unsafe partial struct VkPhysicalDeviceShaderSubgroupExtendedTypesFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderSubgroupExtendedTypes;
    }

    public unsafe partial struct VkAttachmentDescription2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkFormat format;

        public VkSampleCountFlagBits samples;

        public VkAttachmentLoadOp loadOp;

        public VkAttachmentStoreOp storeOp;

        public VkAttachmentLoadOp stencilLoadOp;

        public VkAttachmentStoreOp stencilStoreOp;

        public VkImageLayout initialLayout;

        public VkImageLayout finalLayout;
    }

    public unsafe partial struct VkAttachmentReference2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint attachment;

        public VkImageLayout layout;

                public uint aspectMask;
    }

    public unsafe partial struct VkSubpassDescription2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkPipelineBindPoint pipelineBindPoint;

                public uint viewMask;

                public uint inputAttachmentCount;

                public VkAttachmentReference2* pInputAttachments;

                public uint colorAttachmentCount;

                public VkAttachmentReference2* pColorAttachments;

                public VkAttachmentReference2* pResolveAttachments;

                public VkAttachmentReference2* pDepthStencilAttachment;

                public uint preserveAttachmentCount;

                public uint* pPreserveAttachments;
    }

    public unsafe partial struct VkSubpassDependency2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint srcSubpass;

                public uint dstSubpass;

                public uint srcStageMask;

                public uint dstStageMask;

                public uint srcAccessMask;

                public uint dstAccessMask;

                public uint dependencyFlags;

                public int viewOffset;
    }

    public unsafe partial struct VkSubpassBeginInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkSubpassContents contents;
    }

    public unsafe partial struct VkSubpassEndInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;
    }

    public unsafe partial struct VkRenderPassCreateInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint attachmentCount;

                public VkAttachmentDescription2* pAttachments;

                public uint subpassCount;

                public VkSubpassDescription2* pSubpasses;

                public uint dependencyCount;

                public VkSubpassDependency2* pDependencies;

                public uint correlatedViewMaskCount;

                public uint* pCorrelatedViewMasks;
    }

    public unsafe partial struct VkSubpassDescriptionDepthStencilResolve
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkResolveModeFlagBits depthResolveMode;

        public VkResolveModeFlagBits stencilResolveMode;

                public VkAttachmentReference2* pDepthStencilResolveAttachment;
    }

    public unsafe partial struct VkPhysicalDeviceDepthStencilResolveProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint supportedDepthResolveModes;

                public uint supportedStencilResolveModes;

                public uint independentResolveNone;

                public uint independentResolve;
    }

    public unsafe partial struct VkImageStencilUsageCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stencilUsage;
    }

    public unsafe partial struct VkPhysicalDeviceImagelessFramebufferFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint imagelessFramebuffer;
    }

    public unsafe partial struct VkFramebufferAttachmentImageInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint usage;

                public uint width;

                public uint height;

                public uint layerCount;

                public uint viewFormatCount;

                public VkFormat* pViewFormats;
    }

    public unsafe partial struct VkRenderPassAttachmentBeginInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint attachmentCount;

                public VkImageView** pAttachments;
    }

    public unsafe partial struct VkFramebufferAttachmentsCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint attachmentImageInfoCount;

                public VkFramebufferAttachmentImageInfo* pAttachmentImageInfos;
    }

    public unsafe partial struct VkPhysicalDeviceSeparateDepthStencilLayoutsFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint separateDepthStencilLayouts;
    }

    public unsafe partial struct VkAttachmentReferenceStencilLayout
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkImageLayout stencilLayout;
    }

    public unsafe partial struct VkAttachmentDescriptionStencilLayout
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkImageLayout stencilInitialLayout;

        public VkImageLayout stencilFinalLayout;
    }

    public partial struct VkPrivateDataSlot
    {
    }

    public unsafe partial struct VkPhysicalDeviceVulkan13Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint robustImageAccess;

                public uint inlineUniformBlock;

                public uint descriptorBindingInlineUniformBlockUpdateAfterBind;

                public uint pipelineCreationCacheControl;

                public uint privateData;

                public uint shaderDemoteToHelperInvocation;

                public uint shaderTerminateInvocation;

                public uint subgroupSizeControl;

                public uint computeFullSubgroups;

                public uint synchronization2;

                public uint textureCompressionASTC_HDR;

                public uint shaderZeroInitializeWorkgroupMemory;

                public uint dynamicRendering;

                public uint shaderIntegerDotProduct;

                public uint maintenance4;
    }

    public unsafe partial struct VkPhysicalDeviceVulkan13Properties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint minSubgroupSize;

                public uint maxSubgroupSize;

                public uint maxComputeWorkgroupSubgroups;

                public uint requiredSubgroupSizeStages;

                public uint maxInlineUniformBlockSize;

                public uint maxPerStageDescriptorInlineUniformBlocks;

                public uint maxPerStageDescriptorUpdateAfterBindInlineUniformBlocks;

                public uint maxDescriptorSetInlineUniformBlocks;

                public uint maxDescriptorSetUpdateAfterBindInlineUniformBlocks;

                public uint maxInlineUniformTotalSize;

                public uint integerDotProduct8BitUnsignedAccelerated;

                public uint integerDotProduct8BitSignedAccelerated;

                public uint integerDotProduct8BitMixedSignednessAccelerated;

                public uint integerDotProduct4x8BitPackedUnsignedAccelerated;

                public uint integerDotProduct4x8BitPackedSignedAccelerated;

                public uint integerDotProduct4x8BitPackedMixedSignednessAccelerated;

                public uint integerDotProduct16BitUnsignedAccelerated;

                public uint integerDotProduct16BitSignedAccelerated;

                public uint integerDotProduct16BitMixedSignednessAccelerated;

                public uint integerDotProduct32BitUnsignedAccelerated;

                public uint integerDotProduct32BitSignedAccelerated;

                public uint integerDotProduct32BitMixedSignednessAccelerated;

                public uint integerDotProduct64BitUnsignedAccelerated;

                public uint integerDotProduct64BitSignedAccelerated;

                public uint integerDotProduct64BitMixedSignednessAccelerated;

                public uint integerDotProductAccumulatingSaturating8BitUnsignedAccelerated;

                public uint integerDotProductAccumulatingSaturating8BitSignedAccelerated;

                public uint integerDotProductAccumulatingSaturating8BitMixedSignednessAccelerated;

                public uint integerDotProductAccumulatingSaturating4x8BitPackedUnsignedAccelerated;

                public uint integerDotProductAccumulatingSaturating4x8BitPackedSignedAccelerated;

                public uint integerDotProductAccumulatingSaturating4x8BitPackedMixedSignednessAccelerated;

                public uint integerDotProductAccumulatingSaturating16BitUnsignedAccelerated;

                public uint integerDotProductAccumulatingSaturating16BitSignedAccelerated;

                public uint integerDotProductAccumulatingSaturating16BitMixedSignednessAccelerated;

                public uint integerDotProductAccumulatingSaturating32BitUnsignedAccelerated;

                public uint integerDotProductAccumulatingSaturating32BitSignedAccelerated;

                public uint integerDotProductAccumulatingSaturating32BitMixedSignednessAccelerated;

                public uint integerDotProductAccumulatingSaturating64BitUnsignedAccelerated;

                public uint integerDotProductAccumulatingSaturating64BitSignedAccelerated;

                public uint integerDotProductAccumulatingSaturating64BitMixedSignednessAccelerated;

                public ulong storageTexelBufferOffsetAlignmentBytes;

                public uint storageTexelBufferOffsetSingleTexelAlignment;

                public ulong uniformTexelBufferOffsetAlignmentBytes;

                public uint uniformTexelBufferOffsetSingleTexelAlignment;

                public ulong maxBufferSize;
    }

    public unsafe partial struct VkPhysicalDeviceToolProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _name_e__FixedBuffer name;

                public _version_e__FixedBuffer version;

                public uint purposes;

                public _description_e__FixedBuffer description;

                public _layer_e__FixedBuffer layer;

        [InlineArray(256)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _version_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _layer_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkPhysicalDevicePrivateDataFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint privateData;
    }

    public unsafe partial struct VkDevicePrivateDataCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint privateDataSlotRequestCount;
    }

    public unsafe partial struct VkPrivateDataSlotCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkMemoryBarrier2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong srcStageMask;

                public ulong srcAccessMask;

                public ulong dstStageMask;

                public ulong dstAccessMask;
    }

    public unsafe partial struct VkBufferMemoryBarrier2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong srcStageMask;

                public ulong srcAccessMask;

                public ulong dstStageMask;

                public ulong dstAccessMask;

                public uint srcQueueFamilyIndex;

                public uint dstQueueFamilyIndex;

                public VkBuffer* buffer;

                public ulong offset;

                public ulong size;
    }

    public unsafe partial struct VkImageMemoryBarrier2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong srcStageMask;

                public ulong srcAccessMask;

                public ulong dstStageMask;

                public ulong dstAccessMask;

        public VkImageLayout oldLayout;

        public VkImageLayout newLayout;

                public uint srcQueueFamilyIndex;

                public uint dstQueueFamilyIndex;

                public VkImage* image;

        public VkImageSubresourceRange subresourceRange;
    }

    public unsafe partial struct VkDependencyInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint dependencyFlags;

                public uint memoryBarrierCount;

                public VkMemoryBarrier2* pMemoryBarriers;

                public uint bufferMemoryBarrierCount;

                public VkBufferMemoryBarrier2* pBufferMemoryBarriers;

                public uint imageMemoryBarrierCount;

                public VkImageMemoryBarrier2* pImageMemoryBarriers;
    }

    public unsafe partial struct VkSemaphoreSubmitInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSemaphore* semaphore;

                public ulong value;

                public ulong stageMask;

                public uint deviceIndex;
    }

    public unsafe partial struct VkCommandBufferSubmitInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkCommandBuffer* commandBuffer;

                public uint deviceMask;
    }

    public unsafe partial struct VkSubmitInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint waitSemaphoreInfoCount;

                public VkSemaphoreSubmitInfo* pWaitSemaphoreInfos;

                public uint commandBufferInfoCount;

                public VkCommandBufferSubmitInfo* pCommandBufferInfos;

                public uint signalSemaphoreInfoCount;

                public VkSemaphoreSubmitInfo* pSignalSemaphoreInfos;
    }

    public unsafe partial struct VkPhysicalDeviceSynchronization2Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint synchronization2;
    }

    public unsafe partial struct VkBufferCopy2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong srcOffset;

                public ulong dstOffset;

                public ulong size;
    }

    public unsafe partial struct VkCopyBufferInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBuffer* srcBuffer;

                public VkBuffer* dstBuffer;

                public uint regionCount;

                public VkBufferCopy2* pRegions;
    }

    public unsafe partial struct VkImageCopy2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkImageSubresourceLayers srcSubresource;

        public VkOffset3D srcOffset;

        public VkImageSubresourceLayers dstSubresource;

        public VkOffset3D dstOffset;

        public VkExtent3D extent;
    }

    public unsafe partial struct VkCopyImageInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* srcImage;

        public VkImageLayout srcImageLayout;

                public VkImage* dstImage;

        public VkImageLayout dstImageLayout;

                public uint regionCount;

                public VkImageCopy2* pRegions;
    }

    public unsafe partial struct VkBufferImageCopy2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong bufferOffset;

                public uint bufferRowLength;

                public uint bufferImageHeight;

        public VkImageSubresourceLayers imageSubresource;

        public VkOffset3D imageOffset;

        public VkExtent3D imageExtent;
    }

    public unsafe partial struct VkCopyBufferToImageInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBuffer* srcBuffer;

                public VkImage* dstImage;

        public VkImageLayout dstImageLayout;

                public uint regionCount;

                public VkBufferImageCopy2* pRegions;
    }

    public unsafe partial struct VkCopyImageToBufferInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* srcImage;

        public VkImageLayout srcImageLayout;

                public VkBuffer* dstBuffer;

                public uint regionCount;

                public VkBufferImageCopy2* pRegions;
    }

    public unsafe partial struct VkPhysicalDeviceTextureCompressionASTCHDRFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint textureCompressionASTC_HDR;
    }

    public unsafe partial struct VkFormatProperties3
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong linearTilingFeatures;

                public ulong optimalTilingFeatures;

                public ulong bufferFeatures;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance4Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maintenance4;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance4Properties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong maxBufferSize;
    }

    public unsafe partial struct VkDeviceBufferMemoryRequirements
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBufferCreateInfo* pCreateInfo;
    }

    public unsafe partial struct VkDeviceImageMemoryRequirements
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImageCreateInfo* pCreateInfo;

        public VkImageAspectFlagBits planeAspect;
    }

    public partial struct VkPipelineCreationFeedback
    {
                public uint flags;

                public ulong duration;
    }

    public unsafe partial struct VkPipelineCreationFeedbackCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkPipelineCreationFeedback* pPipelineCreationFeedback;

                public uint pipelineStageCreationFeedbackCount;

        public VkPipelineCreationFeedback* pPipelineStageCreationFeedbacks;
    }

    public unsafe partial struct VkPhysicalDeviceShaderTerminateInvocationFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderTerminateInvocation;
    }

    public unsafe partial struct VkPhysicalDeviceShaderDemoteToHelperInvocationFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderDemoteToHelperInvocation;
    }

    public unsafe partial struct VkPhysicalDevicePipelineCreationCacheControlFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelineCreationCacheControl;
    }

    public unsafe partial struct VkPhysicalDeviceZeroInitializeWorkgroupMemoryFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderZeroInitializeWorkgroupMemory;
    }

    public unsafe partial struct VkPhysicalDeviceImageRobustnessFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint robustImageAccess;
    }

    public unsafe partial struct VkPhysicalDeviceSubgroupSizeControlFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint subgroupSizeControl;

                public uint computeFullSubgroups;
    }

    public unsafe partial struct VkPhysicalDeviceSubgroupSizeControlProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint minSubgroupSize;

                public uint maxSubgroupSize;

                public uint maxComputeWorkgroupSubgroups;

                public uint requiredSubgroupSizeStages;
    }

    public unsafe partial struct VkPipelineShaderStageRequiredSubgroupSizeCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint requiredSubgroupSize;
    }

    public unsafe partial struct VkPhysicalDeviceInlineUniformBlockFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint inlineUniformBlock;

                public uint descriptorBindingInlineUniformBlockUpdateAfterBind;
    }

    public unsafe partial struct VkPhysicalDeviceInlineUniformBlockProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxInlineUniformBlockSize;

                public uint maxPerStageDescriptorInlineUniformBlocks;

                public uint maxPerStageDescriptorUpdateAfterBindInlineUniformBlocks;

                public uint maxDescriptorSetInlineUniformBlocks;

                public uint maxDescriptorSetUpdateAfterBindInlineUniformBlocks;
    }

    public unsafe partial struct VkWriteDescriptorSetInlineUniformBlock
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint dataSize;

                public void* pData;
    }

    public unsafe partial struct VkDescriptorPoolInlineUniformBlockCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint maxInlineUniformBlockBindings;
    }

    public unsafe partial struct VkPhysicalDeviceShaderIntegerDotProductFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderIntegerDotProduct;
    }

    public unsafe partial struct VkPhysicalDeviceShaderIntegerDotProductProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint integerDotProduct8BitUnsignedAccelerated;

                public uint integerDotProduct8BitSignedAccelerated;

                public uint integerDotProduct8BitMixedSignednessAccelerated;

                public uint integerDotProduct4x8BitPackedUnsignedAccelerated;

                public uint integerDotProduct4x8BitPackedSignedAccelerated;

                public uint integerDotProduct4x8BitPackedMixedSignednessAccelerated;

                public uint integerDotProduct16BitUnsignedAccelerated;

                public uint integerDotProduct16BitSignedAccelerated;

                public uint integerDotProduct16BitMixedSignednessAccelerated;

                public uint integerDotProduct32BitUnsignedAccelerated;

                public uint integerDotProduct32BitSignedAccelerated;

                public uint integerDotProduct32BitMixedSignednessAccelerated;

                public uint integerDotProduct64BitUnsignedAccelerated;

                public uint integerDotProduct64BitSignedAccelerated;

                public uint integerDotProduct64BitMixedSignednessAccelerated;

                public uint integerDotProductAccumulatingSaturating8BitUnsignedAccelerated;

                public uint integerDotProductAccumulatingSaturating8BitSignedAccelerated;

                public uint integerDotProductAccumulatingSaturating8BitMixedSignednessAccelerated;

                public uint integerDotProductAccumulatingSaturating4x8BitPackedUnsignedAccelerated;

                public uint integerDotProductAccumulatingSaturating4x8BitPackedSignedAccelerated;

                public uint integerDotProductAccumulatingSaturating4x8BitPackedMixedSignednessAccelerated;

                public uint integerDotProductAccumulatingSaturating16BitUnsignedAccelerated;

                public uint integerDotProductAccumulatingSaturating16BitSignedAccelerated;

                public uint integerDotProductAccumulatingSaturating16BitMixedSignednessAccelerated;

                public uint integerDotProductAccumulatingSaturating32BitUnsignedAccelerated;

                public uint integerDotProductAccumulatingSaturating32BitSignedAccelerated;

                public uint integerDotProductAccumulatingSaturating32BitMixedSignednessAccelerated;

                public uint integerDotProductAccumulatingSaturating64BitUnsignedAccelerated;

                public uint integerDotProductAccumulatingSaturating64BitSignedAccelerated;

                public uint integerDotProductAccumulatingSaturating64BitMixedSignednessAccelerated;
    }

    public unsafe partial struct VkPhysicalDeviceTexelBufferAlignmentProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong storageTexelBufferOffsetAlignmentBytes;

                public uint storageTexelBufferOffsetSingleTexelAlignment;

                public ulong uniformTexelBufferOffsetAlignmentBytes;

                public uint uniformTexelBufferOffsetSingleTexelAlignment;
    }

    public unsafe partial struct VkImageBlit2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkImageSubresourceLayers srcSubresource;

                public _srcOffsets_e__FixedBuffer srcOffsets;

        public VkImageSubresourceLayers dstSubresource;

                public _dstOffsets_e__FixedBuffer dstOffsets;

        [InlineArray(2)]
        public partial struct _srcOffsets_e__FixedBuffer
        {
            public VkOffset3D e0;
        }

        [InlineArray(2)]
        public partial struct _dstOffsets_e__FixedBuffer
        {
            public VkOffset3D e0;
        }
    }

    public unsafe partial struct VkBlitImageInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* srcImage;

        public VkImageLayout srcImageLayout;

                public VkImage* dstImage;

        public VkImageLayout dstImageLayout;

                public uint regionCount;

                public VkImageBlit2* pRegions;

        public VkFilter filter;
    }

    public unsafe partial struct VkImageResolve2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkImageSubresourceLayers srcSubresource;

        public VkOffset3D srcOffset;

        public VkImageSubresourceLayers dstSubresource;

        public VkOffset3D dstOffset;

        public VkExtent3D extent;
    }

    public unsafe partial struct VkResolveImageInfo2
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* srcImage;

        public VkImageLayout srcImageLayout;

                public VkImage* dstImage;

        public VkImageLayout dstImageLayout;

                public uint regionCount;

                public VkImageResolve2* pRegions;
    }

    public unsafe partial struct VkRenderingAttachmentInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImageView* imageView;

        public VkImageLayout imageLayout;

        public VkResolveModeFlagBits resolveMode;

                public VkImageView* resolveImageView;

        public VkImageLayout resolveImageLayout;

        public VkAttachmentLoadOp loadOp;

        public VkAttachmentStoreOp storeOp;

        public VkClearValue clearValue;
    }

    public unsafe partial struct VkRenderingInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkRect2D renderArea;

                public uint layerCount;

                public uint viewMask;

                public uint colorAttachmentCount;

                public VkRenderingAttachmentInfo* pColorAttachments;

                public VkRenderingAttachmentInfo* pDepthAttachment;

                public VkRenderingAttachmentInfo* pStencilAttachment;
    }

    public unsafe partial struct VkPipelineRenderingCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint viewMask;

                public uint colorAttachmentCount;

                public VkFormat* pColorAttachmentFormats;

        public VkFormat depthAttachmentFormat;

        public VkFormat stencilAttachmentFormat;
    }

    public unsafe partial struct VkPhysicalDeviceDynamicRenderingFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint dynamicRendering;
    }

    public unsafe partial struct VkCommandBufferInheritanceRenderingInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint viewMask;

                public uint colorAttachmentCount;

                public VkFormat* pColorAttachmentFormats;

        public VkFormat depthAttachmentFormat;

        public VkFormat stencilAttachmentFormat;

        public VkSampleCountFlagBits rasterizationSamples;
    }

    public unsafe partial struct VkPhysicalDeviceVulkan14Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint globalPriorityQuery;

                public uint shaderSubgroupRotate;

                public uint shaderSubgroupRotateClustered;

                public uint shaderFloatControls2;

                public uint shaderExpectAssume;

                public uint rectangularLines;

                public uint bresenhamLines;

                public uint smoothLines;

                public uint stippledRectangularLines;

                public uint stippledBresenhamLines;

                public uint stippledSmoothLines;

                public uint vertexAttributeInstanceRateDivisor;

                public uint vertexAttributeInstanceRateZeroDivisor;

                public uint indexTypeUint8;

                public uint dynamicRenderingLocalRead;

                public uint maintenance5;

                public uint maintenance6;

                public uint pipelineProtectedAccess;

                public uint pipelineRobustness;

                public uint hostImageCopy;

                public uint pushDescriptor;
    }

    public unsafe partial struct VkPhysicalDeviceVulkan14Properties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint lineSubPixelPrecisionBits;

                public uint maxVertexAttribDivisor;

                public uint supportsNonZeroFirstInstance;

                public uint maxPushDescriptors;

                public uint dynamicRenderingLocalReadDepthStencilAttachments;

                public uint dynamicRenderingLocalReadMultisampledAttachments;

                public uint earlyFragmentMultisampleCoverageAfterSampleCounting;

                public uint earlyFragmentSampleMaskTestBeforeSampleCounting;

                public uint depthStencilSwizzleOneSupport;

                public uint polygonModePointSize;

                public uint nonStrictSinglePixelWideLinesUseParallelogram;

                public uint nonStrictWideLinesUseParallelogram;

                public uint blockTexelViewCompatibleMultipleLayers;

                public uint maxCombinedImageSamplerDescriptorCount;

                public uint fragmentShadingRateClampCombinerInputs;

        public VkPipelineRobustnessBufferBehavior defaultRobustnessStorageBuffers;

        public VkPipelineRobustnessBufferBehavior defaultRobustnessUniformBuffers;

        public VkPipelineRobustnessBufferBehavior defaultRobustnessVertexInputs;

        public VkPipelineRobustnessImageBehavior defaultRobustnessImages;

                public uint copySrcLayoutCount;

        public VkImageLayout* pCopySrcLayouts;

                public uint copyDstLayoutCount;

        public VkImageLayout* pCopyDstLayouts;

                public _optimalTilingLayoutUUID_e__FixedBuffer optimalTilingLayoutUUID;

                public uint identicalMemoryTypeRequirements;

        [InlineArray(16)]
        public partial struct _optimalTilingLayoutUUID_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkDeviceQueueGlobalPriorityCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkQueueGlobalPriority globalPriority;
    }

    public unsafe partial struct VkPhysicalDeviceGlobalPriorityQueryFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint globalPriorityQuery;
    }

    public unsafe partial struct VkQueueFamilyGlobalPriorityProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint priorityCount;

                public _priorities_e__FixedBuffer priorities;

        [InlineArray(16)]
        public partial struct _priorities_e__FixedBuffer
        {
            public VkQueueGlobalPriority e0;
        }
    }

    public unsafe partial struct VkPhysicalDeviceIndexTypeUint8Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint indexTypeUint8;
    }

    public unsafe partial struct VkMemoryMapInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkDeviceMemory* memory;

                public ulong offset;

                public ulong size;
    }

    public unsafe partial struct VkMemoryUnmapInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkDeviceMemory* memory;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance5Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maintenance5;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance5Properties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint earlyFragmentMultisampleCoverageAfterSampleCounting;

                public uint earlyFragmentSampleMaskTestBeforeSampleCounting;

                public uint depthStencilSwizzleOneSupport;

                public uint polygonModePointSize;

                public uint nonStrictSinglePixelWideLinesUseParallelogram;

                public uint nonStrictWideLinesUseParallelogram;
    }

    public unsafe partial struct VkSubresourceLayout2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkSubresourceLayout subresourceLayout;
    }

    public unsafe partial struct VkImageSubresource2
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkImageSubresource imageSubresource;
    }

    public unsafe partial struct VkDeviceImageSubresourceInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImageCreateInfo* pCreateInfo;

                public VkImageSubresource2* pSubresource;
    }

    public unsafe partial struct VkBufferUsageFlags2CreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong usage;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance6Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maintenance6;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance6Properties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint blockTexelViewCompatibleMultipleLayers;

                public uint maxCombinedImageSamplerDescriptorCount;

                public uint fragmentShadingRateClampCombinerInputs;
    }

    public unsafe partial struct VkBindMemoryStatus
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkResult* pResult;
    }

    public unsafe partial struct VkPhysicalDeviceHostImageCopyFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint hostImageCopy;
    }

    public unsafe partial struct VkPhysicalDeviceHostImageCopyProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint copySrcLayoutCount;

        public VkImageLayout* pCopySrcLayouts;

                public uint copyDstLayoutCount;

        public VkImageLayout* pCopyDstLayouts;

                public _optimalTilingLayoutUUID_e__FixedBuffer optimalTilingLayoutUUID;

                public uint identicalMemoryTypeRequirements;

        [InlineArray(16)]
        public partial struct _optimalTilingLayoutUUID_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkMemoryToImageCopy
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public void* pHostPointer;

                public uint memoryRowLength;

                public uint memoryImageHeight;

        public VkImageSubresourceLayers imageSubresource;

        public VkOffset3D imageOffset;

        public VkExtent3D imageExtent;
    }

    public unsafe partial struct VkImageToMemoryCopy
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public void* pHostPointer;

                public uint memoryRowLength;

                public uint memoryImageHeight;

        public VkImageSubresourceLayers imageSubresource;

        public VkOffset3D imageOffset;

        public VkExtent3D imageExtent;
    }

    public unsafe partial struct VkCopyMemoryToImageInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkImage* dstImage;

        public VkImageLayout dstImageLayout;

                public uint regionCount;

                public VkMemoryToImageCopy* pRegions;
    }

    public unsafe partial struct VkCopyImageToMemoryInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkImage* srcImage;

        public VkImageLayout srcImageLayout;

                public uint regionCount;

                public VkImageToMemoryCopy* pRegions;
    }

    public unsafe partial struct VkCopyImageToImageInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkImage* srcImage;

        public VkImageLayout srcImageLayout;

                public VkImage* dstImage;

        public VkImageLayout dstImageLayout;

                public uint regionCount;

                public VkImageCopy2* pRegions;
    }

    public unsafe partial struct VkHostImageLayoutTransitionInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* image;

        public VkImageLayout oldLayout;

        public VkImageLayout newLayout;

        public VkImageSubresourceRange subresourceRange;
    }

    public unsafe partial struct VkSubresourceHostMemcpySize
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong size;
    }

    public unsafe partial struct VkHostImageCopyDevicePerformanceQuery
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint optimalDeviceAccess;

                public uint identicalMemoryLayout;
    }

    public unsafe partial struct VkPhysicalDeviceShaderSubgroupRotateFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderSubgroupRotate;

                public uint shaderSubgroupRotateClustered;
    }

    public unsafe partial struct VkPhysicalDeviceShaderFloatControls2Features
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderFloatControls2;
    }

    public unsafe partial struct VkPhysicalDeviceShaderExpectAssumeFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderExpectAssume;
    }

    public unsafe partial struct VkPipelineCreateFlags2CreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong flags;
    }

    public unsafe partial struct VkPhysicalDevicePushDescriptorProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxPushDescriptors;
    }

    public unsafe partial struct VkBindDescriptorSetsInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stageFlags;

                public VkPipelineLayout* layout;

                public uint firstSet;

                public uint descriptorSetCount;

                public VkDescriptorSet** pDescriptorSets;

                public uint dynamicOffsetCount;

                public uint* pDynamicOffsets;
    }

    public unsafe partial struct VkPushConstantsInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkPipelineLayout* layout;

                public uint stageFlags;

                public uint offset;

                public uint size;

                public void* pValues;
    }

    public unsafe partial struct VkPushDescriptorSetInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stageFlags;

                public VkPipelineLayout* layout;

                public uint set;

                public uint descriptorWriteCount;

                public VkWriteDescriptorSet* pDescriptorWrites;
    }

    public unsafe partial struct VkPushDescriptorSetWithTemplateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDescriptorUpdateTemplate* descriptorUpdateTemplate;

                public VkPipelineLayout* layout;

                public uint set;

                public void* pData;
    }

    public unsafe partial struct VkPhysicalDevicePipelineProtectedAccessFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelineProtectedAccess;
    }

    public unsafe partial struct VkPhysicalDevicePipelineRobustnessFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelineRobustness;
    }

    public unsafe partial struct VkPhysicalDevicePipelineRobustnessProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPipelineRobustnessBufferBehavior defaultRobustnessStorageBuffers;

        public VkPipelineRobustnessBufferBehavior defaultRobustnessUniformBuffers;

        public VkPipelineRobustnessBufferBehavior defaultRobustnessVertexInputs;

        public VkPipelineRobustnessImageBehavior defaultRobustnessImages;
    }

    public unsafe partial struct VkPipelineRobustnessCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkPipelineRobustnessBufferBehavior storageBuffers;

        public VkPipelineRobustnessBufferBehavior uniformBuffers;

        public VkPipelineRobustnessBufferBehavior vertexInputs;

        public VkPipelineRobustnessImageBehavior images;
    }

    public unsafe partial struct VkPhysicalDeviceLineRasterizationFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rectangularLines;

                public uint bresenhamLines;

                public uint smoothLines;

                public uint stippledRectangularLines;

                public uint stippledBresenhamLines;

                public uint stippledSmoothLines;
    }

    public unsafe partial struct VkPhysicalDeviceLineRasterizationProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint lineSubPixelPrecisionBits;
    }

    public unsafe partial struct VkPipelineRasterizationLineStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkLineRasterizationMode lineRasterizationMode;

                public uint stippledLineEnable;

                public uint lineStippleFactor;

                public ushort lineStipplePattern;
    }

    public unsafe partial struct VkPhysicalDeviceVertexAttributeDivisorProperties
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxVertexAttribDivisor;

                public uint supportsNonZeroFirstInstance;
    }

    public partial struct VkVertexInputBindingDivisorDescription
    {
                public uint binding;

                public uint divisor;
    }

    public unsafe partial struct VkPipelineVertexInputDivisorStateCreateInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint vertexBindingDivisorCount;

                public VkVertexInputBindingDivisorDescription* pVertexBindingDivisors;
    }

    public unsafe partial struct VkPhysicalDeviceVertexAttributeDivisorFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint vertexAttributeInstanceRateDivisor;

                public uint vertexAttributeInstanceRateZeroDivisor;
    }

    public unsafe partial struct VkRenderingAreaInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint viewMask;

                public uint colorAttachmentCount;

                public VkFormat* pColorAttachmentFormats;

        public VkFormat depthAttachmentFormat;

        public VkFormat stencilAttachmentFormat;
    }

    public unsafe partial struct VkPhysicalDeviceDynamicRenderingLocalReadFeatures
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint dynamicRenderingLocalRead;
    }

    public unsafe partial struct VkRenderingAttachmentLocationInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint colorAttachmentCount;

                public uint* pColorAttachmentLocations;
    }

    public unsafe partial struct VkRenderingInputAttachmentIndexInfo
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint colorAttachmentCount;

                public uint* pColorAttachmentInputIndices;

                public uint* pDepthInputAttachmentIndex;

                public uint* pStencilInputAttachmentIndex;
    }

    public partial struct VkSurfaceKHR
    {
    }

    public partial struct VkSurfaceCapabilitiesKHR
    {
                public uint minImageCount;

                public uint maxImageCount;

        public VkExtent2D currentExtent;

        public VkExtent2D minImageExtent;

        public VkExtent2D maxImageExtent;

                public uint maxImageArrayLayers;

                public uint supportedTransforms;

        public VkSurfaceTransformFlagBitsKHR currentTransform;

                public uint supportedCompositeAlpha;

                public uint supportedUsageFlags;
    }

    public partial struct VkSurfaceFormatKHR
    {
        public VkFormat format;

        public VkColorSpaceKHR colorSpace;
    }

    public partial struct VkSwapchainKHR
    {
    }

    public unsafe partial struct VkSwapchainCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkSurfaceKHR* surface;

                public uint minImageCount;

        public VkFormat imageFormat;

        public VkColorSpaceKHR imageColorSpace;

        public VkExtent2D imageExtent;

                public uint imageArrayLayers;

                public uint imageUsage;

        public VkSharingMode imageSharingMode;

                public uint queueFamilyIndexCount;

                public uint* pQueueFamilyIndices;

        public VkSurfaceTransformFlagBitsKHR preTransform;

        public VkCompositeAlphaFlagBitsKHR compositeAlpha;

        public VkPresentModeKHR presentMode;

                public uint clipped;

                public VkSwapchainKHR* oldSwapchain;
    }

    public unsafe partial struct VkPresentInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint waitSemaphoreCount;

                public VkSemaphore** pWaitSemaphores;

                public uint swapchainCount;

                public VkSwapchainKHR** pSwapchains;

                public uint* pImageIndices;

        public VkResult* pResults;
    }

    public unsafe partial struct VkImageSwapchainCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSwapchainKHR* swapchain;
    }

    public unsafe partial struct VkBindImageMemorySwapchainInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSwapchainKHR* swapchain;

                public uint imageIndex;
    }

    public unsafe partial struct VkAcquireNextImageInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSwapchainKHR* swapchain;

                public ulong timeout;

                public VkSemaphore* semaphore;

                public VkFence* fence;

                public uint deviceMask;
    }

    public unsafe partial struct VkDeviceGroupPresentCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _presentMask_e__FixedBuffer presentMask;

                public uint modes;

        [InlineArray(32)]
        public partial struct _presentMask_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public unsafe partial struct VkDeviceGroupPresentInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint swapchainCount;

                public uint* pDeviceMasks;

        public VkDeviceGroupPresentModeFlagBitsKHR mode;
    }

    public unsafe partial struct VkDeviceGroupSwapchainCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint modes;
    }

    public partial struct VkDisplayKHR
    {
    }

    public partial struct VkDisplayModeKHR
    {
    }

    public partial struct VkDisplayModeParametersKHR
    {
        public VkExtent2D visibleRegion;

                public uint refreshRate;
    }

    public unsafe partial struct VkDisplayModeCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkDisplayModeParametersKHR parameters;
    }

    public unsafe partial struct VkDisplayModePropertiesKHR
    {
                public VkDisplayModeKHR* displayMode;

        public VkDisplayModeParametersKHR parameters;
    }

    public partial struct VkDisplayPlaneCapabilitiesKHR
    {
                public uint supportedAlpha;

        public VkOffset2D minSrcPosition;

        public VkOffset2D maxSrcPosition;

        public VkExtent2D minSrcExtent;

        public VkExtent2D maxSrcExtent;

        public VkOffset2D minDstPosition;

        public VkOffset2D maxDstPosition;

        public VkExtent2D minDstExtent;

        public VkExtent2D maxDstExtent;
    }

    public unsafe partial struct VkDisplayPlanePropertiesKHR
    {
                public VkDisplayKHR* currentDisplay;

                public uint currentStackIndex;
    }

    public unsafe partial struct VkDisplayPropertiesKHR
    {
                public VkDisplayKHR* display;

                public sbyte* displayName;

        public VkExtent2D physicalDimensions;

        public VkExtent2D physicalResolution;

                public uint supportedTransforms;

                public uint planeReorderPossible;

                public uint persistentContent;
    }

    public unsafe partial struct VkDisplaySurfaceCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkDisplayModeKHR* displayMode;

                public uint planeIndex;

                public uint planeStackIndex;

        public VkSurfaceTransformFlagBitsKHR transform;

        public float globalAlpha;

        public VkDisplayPlaneAlphaFlagBitsKHR alphaMode;

        public VkExtent2D imageExtent;
    }

    public unsafe partial struct VkDisplayPresentInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkRect2D srcRect;

        public VkRect2D dstRect;

                public uint persistent;
    }

    public partial struct VkVideoSessionKHR
    {
    }

    public partial struct VkVideoSessionParametersKHR
    {
    }

    public unsafe partial struct VkQueueFamilyQueryResultStatusPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint queryResultStatusSupport;
    }

    public unsafe partial struct VkQueueFamilyVideoPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint videoCodecOperations;
    }

    public unsafe partial struct VkVideoProfileInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkVideoCodecOperationFlagBitsKHR videoCodecOperation;

                public uint chromaSubsampling;

                public uint lumaBitDepth;

                public uint chromaBitDepth;
    }

    public unsafe partial struct VkVideoProfileListInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint profileCount;

                public VkVideoProfileInfoKHR* pProfiles;
    }

    public unsafe partial struct VkVideoCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public ulong minBitstreamBufferOffsetAlignment;

                public ulong minBitstreamBufferSizeAlignment;

        public VkExtent2D pictureAccessGranularity;

        public VkExtent2D minCodedExtent;

        public VkExtent2D maxCodedExtent;

                public uint maxDpbSlots;

                public uint maxActiveReferencePictures;

        public VkExtensionProperties stdHeaderVersion;
    }

    public unsafe partial struct VkPhysicalDeviceVideoFormatInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint imageUsage;
    }

    public unsafe partial struct VkVideoFormatPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkFormat format;

        public VkComponentMapping componentMapping;

                public uint imageCreateFlags;

        public VkImageType imageType;

        public VkImageTiling imageTiling;

                public uint imageUsageFlags;
    }

    public unsafe partial struct VkVideoPictureResourceInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkOffset2D codedOffset;

        public VkExtent2D codedExtent;

                public uint baseArrayLayer;

                public VkImageView* imageViewBinding;
    }

    public unsafe partial struct VkVideoReferenceSlotInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public int slotIndex;

                public VkVideoPictureResourceInfoKHR* pPictureResource;
    }

    public unsafe partial struct VkVideoSessionMemoryRequirementsKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint memoryBindIndex;

        public VkMemoryRequirements memoryRequirements;
    }

    public unsafe partial struct VkBindVideoSessionMemoryInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint memoryBindIndex;

                public VkDeviceMemory* memory;

                public ulong memoryOffset;

                public ulong memorySize;
    }

    public unsafe partial struct VkVideoSessionCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint queueFamilyIndex;

                public uint flags;

                public VkVideoProfileInfoKHR* pVideoProfile;

        public VkFormat pictureFormat;

        public VkExtent2D maxCodedExtent;

        public VkFormat referencePictureFormat;

                public uint maxDpbSlots;

                public uint maxActiveReferencePictures;

                public VkExtensionProperties* pStdHeaderVersion;
    }

    public unsafe partial struct VkVideoSessionParametersCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkVideoSessionParametersKHR* videoSessionParametersTemplate;

                public VkVideoSessionKHR* videoSession;
    }

    public unsafe partial struct VkVideoSessionParametersUpdateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint updateSequenceCount;
    }

    public unsafe partial struct VkVideoBeginCodingInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkVideoSessionKHR* videoSession;

                public VkVideoSessionParametersKHR* videoSessionParameters;

                public uint referenceSlotCount;

                public VkVideoReferenceSlotInfoKHR* pReferenceSlots;
    }

    public unsafe partial struct VkVideoEndCodingInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkVideoCodingControlInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkVideoDecodeCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkVideoDecodeUsageInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint videoUsageHints;
    }

    public unsafe partial struct VkVideoDecodeInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkBuffer* srcBuffer;

                public ulong srcBufferOffset;

                public ulong srcBufferRange;

        public VkVideoPictureResourceInfoKHR dstPictureResource;

                public VkVideoReferenceSlotInfoKHR* pSetupReferenceSlot;

                public uint referenceSlotCount;

                public VkVideoReferenceSlotInfoKHR* pReferenceSlots;
    }

    public unsafe partial struct VkVideoEncodeH264CapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

        public StdVideoH264LevelIdc maxLevelIdc;

                public uint maxSliceCount;

                public uint maxPPictureL0ReferenceCount;

                public uint maxBPictureL0ReferenceCount;

                public uint maxL1ReferenceCount;

                public uint maxTemporalLayerCount;

                public uint expectDyadicTemporalLayerPattern;

                public int minQp;

                public int maxQp;

                public uint prefersGopRemainingFrames;

                public uint requiresGopRemainingFrames;

                public uint stdSyntaxFlags;
    }

    public partial struct VkVideoEncodeH264QpKHR
    {
                public int qpI;

                public int qpP;

                public int qpB;
    }

    public unsafe partial struct VkVideoEncodeH264QualityLevelPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint preferredRateControlFlags;

                public uint preferredGopFrameCount;

                public uint preferredIdrPeriod;

                public uint preferredConsecutiveBFrameCount;

                public uint preferredTemporalLayerCount;

        public VkVideoEncodeH264QpKHR preferredConstantQp;

                public uint preferredMaxL0ReferenceCount;

                public uint preferredMaxL1ReferenceCount;

                public uint preferredStdEntropyCodingModeFlag;
    }

    public unsafe partial struct VkVideoEncodeH264SessionCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint useMaxLevelIdc;

        public StdVideoH264LevelIdc maxLevelIdc;
    }

    public unsafe partial struct VkVideoEncodeH264SessionParametersAddInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stdSPSCount;

                public StdVideoH264SequenceParameterSet* pStdSPSs;

                public uint stdPPSCount;

                public StdVideoH264PictureParameterSet* pStdPPSs;
    }

    public unsafe partial struct VkVideoEncodeH264SessionParametersCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint maxStdSPSCount;

                public uint maxStdPPSCount;

                public VkVideoEncodeH264SessionParametersAddInfoKHR* pParametersAddInfo;
    }

    public unsafe partial struct VkVideoEncodeH264SessionParametersGetInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint writeStdSPS;

                public uint writeStdPPS;

                public uint stdSPSId;

                public uint stdPPSId;
    }

    public unsafe partial struct VkVideoEncodeH264SessionParametersFeedbackInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint hasStdSPSOverrides;

                public uint hasStdPPSOverrides;
    }

    public unsafe partial struct VkVideoEncodeH264NaluSliceInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public int constantQp;

                public StdVideoEncodeH264SliceHeader* pStdSliceHeader;
    }

    public unsafe partial struct VkVideoEncodeH264PictureInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint naluSliceEntryCount;

                public VkVideoEncodeH264NaluSliceInfoKHR* pNaluSliceEntries;

                public StdVideoEncodeH264PictureInfo* pStdPictureInfo;

                public uint generatePrefixNalu;
    }

    public unsafe partial struct VkVideoEncodeH264DpbSlotInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoEncodeH264ReferenceInfo* pStdReferenceInfo;
    }

    public unsafe partial struct VkVideoEncodeH264ProfileInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public StdVideoH264ProfileIdc stdProfileIdc;
    }

    public unsafe partial struct VkVideoEncodeH264RateControlInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint gopFrameCount;

                public uint idrPeriod;

                public uint consecutiveBFrameCount;

                public uint temporalLayerCount;
    }

    public partial struct VkVideoEncodeH264FrameSizeKHR
    {
                public uint frameISize;

                public uint framePSize;

                public uint frameBSize;
    }

    public unsafe partial struct VkVideoEncodeH264RateControlLayerInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint useMinQp;

        public VkVideoEncodeH264QpKHR minQp;

                public uint useMaxQp;

        public VkVideoEncodeH264QpKHR maxQp;

                public uint useMaxFrameSize;

        public VkVideoEncodeH264FrameSizeKHR maxFrameSize;
    }

    public unsafe partial struct VkVideoEncodeH264GopRemainingFrameInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint useGopRemainingFrames;

                public uint gopRemainingI;

                public uint gopRemainingP;

                public uint gopRemainingB;
    }

    public unsafe partial struct VkVideoEncodeH265CapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

        public StdVideoH265LevelIdc maxLevelIdc;

                public uint maxSliceSegmentCount;

        public VkExtent2D maxTiles;

                public uint ctbSizes;

                public uint transformBlockSizes;

                public uint maxPPictureL0ReferenceCount;

                public uint maxBPictureL0ReferenceCount;

                public uint maxL1ReferenceCount;

                public uint maxSubLayerCount;

                public uint expectDyadicTemporalSubLayerPattern;

                public int minQp;

                public int maxQp;

                public uint prefersGopRemainingFrames;

                public uint requiresGopRemainingFrames;

                public uint stdSyntaxFlags;
    }

    public unsafe partial struct VkVideoEncodeH265SessionCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint useMaxLevelIdc;

        public StdVideoH265LevelIdc maxLevelIdc;
    }

    public partial struct VkVideoEncodeH265QpKHR
    {
                public int qpI;

                public int qpP;

                public int qpB;
    }

    public unsafe partial struct VkVideoEncodeH265QualityLevelPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint preferredRateControlFlags;

                public uint preferredGopFrameCount;

                public uint preferredIdrPeriod;

                public uint preferredConsecutiveBFrameCount;

                public uint preferredSubLayerCount;

        public VkVideoEncodeH265QpKHR preferredConstantQp;

                public uint preferredMaxL0ReferenceCount;

                public uint preferredMaxL1ReferenceCount;
    }

    public unsafe partial struct VkVideoEncodeH265SessionParametersAddInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stdVPSCount;

                public StdVideoH265VideoParameterSet* pStdVPSs;

                public uint stdSPSCount;

                public StdVideoH265SequenceParameterSet* pStdSPSs;

                public uint stdPPSCount;

                public StdVideoH265PictureParameterSet* pStdPPSs;
    }

    public unsafe partial struct VkVideoEncodeH265SessionParametersCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint maxStdVPSCount;

                public uint maxStdSPSCount;

                public uint maxStdPPSCount;

                public VkVideoEncodeH265SessionParametersAddInfoKHR* pParametersAddInfo;
    }

    public unsafe partial struct VkVideoEncodeH265SessionParametersGetInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint writeStdVPS;

                public uint writeStdSPS;

                public uint writeStdPPS;

                public uint stdVPSId;

                public uint stdSPSId;

                public uint stdPPSId;
    }

    public unsafe partial struct VkVideoEncodeH265SessionParametersFeedbackInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint hasStdVPSOverrides;

                public uint hasStdSPSOverrides;

                public uint hasStdPPSOverrides;
    }

    public unsafe partial struct VkVideoEncodeH265NaluSliceSegmentInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public int constantQp;

                public StdVideoEncodeH265SliceSegmentHeader* pStdSliceSegmentHeader;
    }

    public unsafe partial struct VkVideoEncodeH265PictureInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint naluSliceSegmentEntryCount;

                public VkVideoEncodeH265NaluSliceSegmentInfoKHR* pNaluSliceSegmentEntries;

                public StdVideoEncodeH265PictureInfo* pStdPictureInfo;
    }

    public unsafe partial struct VkVideoEncodeH265DpbSlotInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoEncodeH265ReferenceInfo* pStdReferenceInfo;
    }

    public unsafe partial struct VkVideoEncodeH265ProfileInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public StdVideoH265ProfileIdc stdProfileIdc;
    }

    public unsafe partial struct VkVideoEncodeH265RateControlInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint gopFrameCount;

                public uint idrPeriod;

                public uint consecutiveBFrameCount;

                public uint subLayerCount;
    }

    public partial struct VkVideoEncodeH265FrameSizeKHR
    {
                public uint frameISize;

                public uint framePSize;

                public uint frameBSize;
    }

    public unsafe partial struct VkVideoEncodeH265RateControlLayerInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint useMinQp;

        public VkVideoEncodeH265QpKHR minQp;

                public uint useMaxQp;

        public VkVideoEncodeH265QpKHR maxQp;

                public uint useMaxFrameSize;

        public VkVideoEncodeH265FrameSizeKHR maxFrameSize;
    }

    public unsafe partial struct VkVideoEncodeH265GopRemainingFrameInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint useGopRemainingFrames;

                public uint gopRemainingI;

                public uint gopRemainingP;

                public uint gopRemainingB;
    }

    public unsafe partial struct VkVideoDecodeH264ProfileInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public StdVideoH264ProfileIdc stdProfileIdc;

        public VkVideoDecodeH264PictureLayoutFlagBitsKHR pictureLayout;
    }

    public unsafe partial struct VkVideoDecodeH264CapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public StdVideoH264LevelIdc maxLevelIdc;

        public VkOffset2D fieldOffsetGranularity;
    }

    public unsafe partial struct VkVideoDecodeH264SessionParametersAddInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stdSPSCount;

                public StdVideoH264SequenceParameterSet* pStdSPSs;

                public uint stdPPSCount;

                public StdVideoH264PictureParameterSet* pStdPPSs;
    }

    public unsafe partial struct VkVideoDecodeH264SessionParametersCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint maxStdSPSCount;

                public uint maxStdPPSCount;

                public VkVideoDecodeH264SessionParametersAddInfoKHR* pParametersAddInfo;
    }

    public unsafe partial struct VkVideoDecodeH264PictureInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoDecodeH264PictureInfo* pStdPictureInfo;

                public uint sliceCount;

                public uint* pSliceOffsets;
    }

    public unsafe partial struct VkVideoDecodeH264DpbSlotInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoDecodeH264ReferenceInfo* pStdReferenceInfo;
    }

    public unsafe partial struct VkImportMemoryFdInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExternalMemoryHandleTypeFlagBits handleType;

        public int fd;
    }

    public unsafe partial struct VkMemoryFdPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint memoryTypeBits;
    }

    public unsafe partial struct VkMemoryGetFdInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDeviceMemory* memory;

        public VkExternalMemoryHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkImportSemaphoreFdInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSemaphore* semaphore;

                public uint flags;

        public VkExternalSemaphoreHandleTypeFlagBits handleType;

        public int fd;
    }

    public unsafe partial struct VkSemaphoreGetFdInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSemaphore* semaphore;

        public VkExternalSemaphoreHandleTypeFlagBits handleType;
    }

    public partial struct VkRectLayerKHR
    {
        public VkOffset2D offset;

        public VkExtent2D extent;

                public uint layer;
    }

    public unsafe partial struct VkPresentRegionKHR
    {
                public uint rectangleCount;

                public VkRectLayerKHR* pRectangles;
    }

    public unsafe partial struct VkPresentRegionsKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint swapchainCount;

                public VkPresentRegionKHR* pRegions;
    }

    public unsafe partial struct VkSharedPresentSurfaceCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint sharedPresentSupportedUsageFlags;
    }

    public unsafe partial struct VkImportFenceFdInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkFence* fence;

                public uint flags;

        public VkExternalFenceHandleTypeFlagBits handleType;

        public int fd;
    }

    public unsafe partial struct VkFenceGetFdInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkFence* fence;

        public VkExternalFenceHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkPhysicalDevicePerformanceQueryFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint performanceCounterQueryPools;

                public uint performanceCounterMultipleQueryPools;
    }

    public unsafe partial struct VkPhysicalDevicePerformanceQueryPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint allowCommandBufferQueryCopies;
    }

    public unsafe partial struct VkPerformanceCounterKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPerformanceCounterUnitKHR unit;

        public VkPerformanceCounterScopeKHR scope;

        public VkPerformanceCounterStorageKHR storage;

                public _uuid_e__FixedBuffer uuid;

        [InlineArray(16)]
        public partial struct _uuid_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkPerformanceCounterDescriptionKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public _name_e__FixedBuffer name;

                public _category_e__FixedBuffer category;

                public _description_e__FixedBuffer description;

        [InlineArray(256)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _category_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkQueryPoolPerformanceCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint queueFamilyIndex;

                public uint counterIndexCount;

                public uint* pCounterIndices;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct VkPerformanceCounterResultKHR
    {
        [FieldOffset(0)]
                public int int32;

        [FieldOffset(0)]
                public long int64;

        [FieldOffset(0)]
                public uint uint32;

        [FieldOffset(0)]
                public ulong uint64;

        [FieldOffset(0)]
        public float float32;

        [FieldOffset(0)]
        public double float64;
    }

    public unsafe partial struct VkAcquireProfilingLockInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public ulong timeout;
    }

    public unsafe partial struct VkPerformanceQuerySubmitInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint counterPassIndex;
    }

    public unsafe partial struct VkPhysicalDeviceSurfaceInfo2KHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSurfaceKHR* surface;
    }

    public unsafe partial struct VkSurfaceCapabilities2KHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkSurfaceCapabilitiesKHR surfaceCapabilities;
    }

    public unsafe partial struct VkSurfaceFormat2KHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkSurfaceFormatKHR surfaceFormat;
    }

    public unsafe partial struct VkDisplayProperties2KHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkDisplayPropertiesKHR displayProperties;
    }

    public unsafe partial struct VkDisplayPlaneProperties2KHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkDisplayPlanePropertiesKHR displayPlaneProperties;
    }

    public unsafe partial struct VkDisplayModeProperties2KHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkDisplayModePropertiesKHR displayModeProperties;
    }

    public unsafe partial struct VkDisplayPlaneInfo2KHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDisplayModeKHR* mode;

                public uint planeIndex;
    }

    public unsafe partial struct VkDisplayPlaneCapabilities2KHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkDisplayPlaneCapabilitiesKHR capabilities;
    }

    public unsafe partial struct VkPhysicalDeviceShaderBfloat16FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderBFloat16Type;

                public uint shaderBFloat16DotProduct;

                public uint shaderBFloat16CooperativeMatrix;
    }

    public unsafe partial struct VkPhysicalDeviceShaderClockFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderSubgroupClock;

                public uint shaderDeviceClock;
    }

    public unsafe partial struct VkVideoDecodeH265ProfileInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public StdVideoH265ProfileIdc stdProfileIdc;
    }

    public unsafe partial struct VkVideoDecodeH265CapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public StdVideoH265LevelIdc maxLevelIdc;
    }

    public unsafe partial struct VkVideoDecodeH265SessionParametersAddInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stdVPSCount;

                public StdVideoH265VideoParameterSet* pStdVPSs;

                public uint stdSPSCount;

                public StdVideoH265SequenceParameterSet* pStdSPSs;

                public uint stdPPSCount;

                public StdVideoH265PictureParameterSet* pStdPPSs;
    }

    public unsafe partial struct VkVideoDecodeH265SessionParametersCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint maxStdVPSCount;

                public uint maxStdSPSCount;

                public uint maxStdPPSCount;

                public VkVideoDecodeH265SessionParametersAddInfoKHR* pParametersAddInfo;
    }

    public unsafe partial struct VkVideoDecodeH265PictureInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoDecodeH265PictureInfo* pStdPictureInfo;

                public uint sliceSegmentCount;

                public uint* pSliceSegmentOffsets;
    }

    public unsafe partial struct VkVideoDecodeH265DpbSlotInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoDecodeH265ReferenceInfo* pStdReferenceInfo;
    }

    public unsafe partial struct VkFragmentShadingRateAttachmentInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkAttachmentReference2* pFragmentShadingRateAttachment;

        public VkExtent2D shadingRateAttachmentTexelSize;
    }

    public unsafe partial struct VkPipelineFragmentShadingRateStateCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExtent2D fragmentSize;

                public _combinerOps_e__FixedBuffer combinerOps;

        [InlineArray(2)]
        public partial struct _combinerOps_e__FixedBuffer
        {
            public VkFragmentShadingRateCombinerOpKHR e0;
        }
    }

    public unsafe partial struct VkPhysicalDeviceFragmentShadingRateFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelineFragmentShadingRate;

                public uint primitiveFragmentShadingRate;

                public uint attachmentFragmentShadingRate;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentShadingRatePropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent2D minFragmentShadingRateAttachmentTexelSize;

        public VkExtent2D maxFragmentShadingRateAttachmentTexelSize;

                public uint maxFragmentShadingRateAttachmentTexelSizeAspectRatio;

                public uint primitiveFragmentShadingRateWithMultipleViewports;

                public uint layeredShadingRateAttachments;

                public uint fragmentShadingRateNonTrivialCombinerOps;

        public VkExtent2D maxFragmentSize;

                public uint maxFragmentSizeAspectRatio;

                public uint maxFragmentShadingRateCoverageSamples;

        public VkSampleCountFlagBits maxFragmentShadingRateRasterizationSamples;

                public uint fragmentShadingRateWithShaderDepthStencilWrites;

                public uint fragmentShadingRateWithSampleMask;

                public uint fragmentShadingRateWithShaderSampleMask;

                public uint fragmentShadingRateWithConservativeRasterization;

                public uint fragmentShadingRateWithFragmentShaderInterlock;

                public uint fragmentShadingRateWithCustomSampleLocations;

                public uint fragmentShadingRateStrictMultiplyCombiner;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentShadingRateKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint sampleCounts;

        public VkExtent2D fragmentSize;
    }

    public unsafe partial struct VkRenderingFragmentShadingRateAttachmentInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImageView* imageView;

        public VkImageLayout imageLayout;

        public VkExtent2D shadingRateAttachmentTexelSize;
    }

    public unsafe partial struct VkPhysicalDeviceShaderConstantDataFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderConstantData;
    }

    public unsafe partial struct VkPhysicalDeviceShaderAbortFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderAbort;
    }

    public unsafe partial struct VkDeviceFaultShaderAbortMessageInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong messageDataSize;

        public void* pMessageData;
    }

    public unsafe partial struct VkPhysicalDeviceShaderAbortPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong maxShaderAbortMessageSize;
    }

    public unsafe partial struct VkPhysicalDeviceShaderQuadControlFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderQuadControl;
    }

    public unsafe partial struct VkSurfaceProtectedCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint supportsProtected;
    }

    public unsafe partial struct VkPhysicalDevicePresentWaitFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentWait;
    }

    public unsafe partial struct VkPhysicalDevicePipelineExecutablePropertiesFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelineExecutableInfo;
    }

    public unsafe partial struct VkPipelineInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkPipeline* pipeline;
    }

    public unsafe partial struct VkPipelineExecutablePropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint stages;

                public _name_e__FixedBuffer name;

                public _description_e__FixedBuffer description;

                public uint subgroupSize;

        [InlineArray(256)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkPipelineExecutableInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkPipeline* pipeline;

                public uint executableIndex;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct VkPipelineExecutableStatisticValueKHR
    {
        [FieldOffset(0)]
                public uint b32;

        [FieldOffset(0)]
                public long i64;

        [FieldOffset(0)]
                public ulong u64;

        [FieldOffset(0)]
        public double f64;
    }

    public unsafe partial struct VkPipelineExecutableStatisticKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _name_e__FixedBuffer name;

                public _description_e__FixedBuffer description;

        public VkPipelineExecutableStatisticFormatKHR format;

        public VkPipelineExecutableStatisticValueKHR value;

        [InlineArray(256)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkPipelineExecutableInternalRepresentationKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _name_e__FixedBuffer name;

                public _description_e__FixedBuffer description;

                public uint isText;

                public nuint dataSize;

        public void* pData;

        [InlineArray(256)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkPipelineLibraryCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint libraryCount;

                public VkPipeline** pLibraries;
    }

    public unsafe partial struct VkPresentIdKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint swapchainCount;

                public ulong* pPresentIds;
    }

    public unsafe partial struct VkPhysicalDevicePresentIdFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentId;
    }

    public unsafe partial struct VkVideoEncodeInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkBuffer* dstBuffer;

                public ulong dstBufferOffset;

                public ulong dstBufferRange;

        public VkVideoPictureResourceInfoKHR srcPictureResource;

                public VkVideoReferenceSlotInfoKHR* pSetupReferenceSlot;

                public uint referenceSlotCount;

                public VkVideoReferenceSlotInfoKHR* pReferenceSlots;

                public uint precedingExternallyEncodedBytes;
    }

    public unsafe partial struct VkVideoEncodeCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public uint rateControlModes;

                public uint maxRateControlLayers;

                public ulong maxBitrate;

                public uint maxQualityLevels;

        public VkExtent2D encodeInputPictureGranularity;

                public uint supportedEncodeFeedbackFlags;
    }

    public unsafe partial struct VkQueryPoolVideoEncodeFeedbackCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint encodeFeedbackFlags;
    }

    public unsafe partial struct VkVideoEncodeUsageInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint videoUsageHints;

                public uint videoContentHints;

        public VkVideoEncodeTuningModeKHR tuningMode;
    }

    public unsafe partial struct VkVideoEncodeRateControlLayerInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong averageBitrate;

                public ulong maxBitrate;

                public uint frameRateNumerator;

                public uint frameRateDenominator;
    }

    public unsafe partial struct VkVideoEncodeRateControlInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkVideoEncodeRateControlModeFlagBitsKHR rateControlMode;

                public uint layerCount;

                public VkVideoEncodeRateControlLayerInfoKHR* pLayers;

                public uint virtualBufferSizeInMs;

                public uint initialVirtualBufferSizeInMs;
    }

    public unsafe partial struct VkPhysicalDeviceVideoEncodeQualityLevelInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkVideoProfileInfoKHR* pVideoProfile;

                public uint qualityLevel;
    }

    public unsafe partial struct VkVideoEncodeQualityLevelPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkVideoEncodeRateControlModeFlagBitsKHR preferredRateControlMode;

                public uint preferredRateControlLayerCount;
    }

    public unsafe partial struct VkVideoEncodeQualityLevelInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint qualityLevel;
    }

    public unsafe partial struct VkVideoEncodeSessionParametersGetInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkVideoSessionParametersKHR* videoSessionParameters;
    }

    public unsafe partial struct VkVideoEncodeSessionParametersFeedbackInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint hasOverrides;
    }

    public partial struct VkDeviceAddressRangeKHR
    {
                public ulong address;

                public ulong size;
    }

    public partial struct VkStridedDeviceAddressRangeKHR
    {
                public ulong address;

                public ulong size;

                public ulong stride;
    }

    public unsafe partial struct VkDeviceMemoryCopyKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceAddressRangeKHR srcRange;

                public uint srcFlags;

        public VkDeviceAddressRangeKHR dstRange;

                public uint dstFlags;
    }

    public unsafe partial struct VkCopyDeviceMemoryInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint regionCount;

                public VkDeviceMemoryCopyKHR* pRegions;
    }

    public unsafe partial struct VkDeviceMemoryImageCopyKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceAddressRangeKHR addressRange;

                public uint addressFlags;

                public uint addressRowLength;

                public uint addressImageHeight;

        public VkImageSubresourceLayers imageSubresource;

        public VkImageLayout imageLayout;

        public VkOffset3D imageOffset;

        public VkExtent3D imageExtent;
    }

    public unsafe partial struct VkCopyDeviceMemoryImageInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* image;

                public uint regionCount;

                public VkDeviceMemoryImageCopyKHR* pRegions;
    }

    public unsafe partial struct VkMemoryRangeBarrierKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong srcStageMask;

                public ulong srcAccessMask;

                public ulong dstStageMask;

                public ulong dstAccessMask;

                public uint srcQueueFamilyIndex;

                public uint dstQueueFamilyIndex;

        public VkDeviceAddressRangeKHR addressRange;

                public uint addressFlags;
    }

    public unsafe partial struct VkMemoryRangeBarriersInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint memoryRangeBarrierCount;

                public VkMemoryRangeBarrierKHR* pMemoryRangeBarriers;
    }

    public unsafe partial struct VkPhysicalDeviceDeviceAddressCommandsFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint deviceAddressCommands;
    }

    public unsafe partial struct VkBindIndexBuffer3InfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceAddressRangeKHR addressRange;

                public uint addressFlags;

        public VkIndexType indexType;
    }

    public unsafe partial struct VkBindVertexBuffer3InfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint setStride;

        public VkStridedDeviceAddressRangeKHR addressRange;

                public uint addressFlags;
    }

    public unsafe partial struct VkDrawIndirect2InfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkStridedDeviceAddressRangeKHR addressRange;

                public uint addressFlags;

                public uint drawCount;
    }

    public unsafe partial struct VkDrawIndirectCount2InfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkStridedDeviceAddressRangeKHR addressRange;

                public uint addressFlags;

        public VkDeviceAddressRangeKHR countAddressRange;

                public uint countAddressFlags;

                public uint maxDrawCount;
    }

    public unsafe partial struct VkDispatchIndirect2InfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceAddressRangeKHR addressRange;

                public uint addressFlags;
    }

    public unsafe partial struct VkConditionalRenderingBeginInfo2EXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceAddressRangeKHR addressRange;

                public uint addressFlags;

                public uint flags;
    }

    public unsafe partial struct VkBindTransformFeedbackBuffer2InfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceAddressRangeKHR addressRange;

                public uint addressFlags;
    }

    public unsafe partial struct VkMemoryMarkerInfoAMD
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong stage;

        public VkDeviceAddressRangeKHR dstRange;

                public uint dstFlags;

                public uint marker;
    }

    public unsafe partial struct VkAccelerationStructureCreateInfo2KHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint createFlags;

        public VkDeviceAddressRangeKHR addressRange;

                public uint addressFlags;

        public VkAccelerationStructureTypeKHR type;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentShaderBarycentricFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint fragmentShaderBarycentric;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentShaderBarycentricPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint triStripVertexOrderIndependentOfProvokingVertex;
    }

    public unsafe partial struct VkPhysicalDeviceShaderSubgroupUniformControlFlowFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderSubgroupUniformControlFlow;
    }

    public unsafe partial struct VkPhysicalDeviceWorkgroupMemoryExplicitLayoutFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint workgroupMemoryExplicitLayout;

                public uint workgroupMemoryExplicitLayoutScalarBlockLayout;

                public uint workgroupMemoryExplicitLayout8BitAccess;

                public uint workgroupMemoryExplicitLayout16BitAccess;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingMaintenance1FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rayTracingMaintenance1;

                public uint rayTracingPipelineTraceRaysIndirect2;
    }

    public partial struct VkTraceRaysIndirectCommand2KHR
    {
                public ulong raygenShaderRecordAddress;

                public ulong raygenShaderRecordSize;

                public ulong missShaderBindingTableAddress;

                public ulong missShaderBindingTableSize;

                public ulong missShaderBindingTableStride;

                public ulong hitShaderBindingTableAddress;

                public ulong hitShaderBindingTableSize;

                public ulong hitShaderBindingTableStride;

                public ulong callableShaderBindingTableAddress;

                public ulong callableShaderBindingTableSize;

                public ulong callableShaderBindingTableStride;

                public uint width;

                public uint height;

                public uint depth;
    }

    public unsafe partial struct VkPhysicalDeviceShaderUntypedPointersFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderUntypedPointers;
    }

    public unsafe partial struct VkPhysicalDeviceShaderMaximalReconvergenceFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderMaximalReconvergence;
    }

    public unsafe partial struct VkSurfaceCapabilitiesPresentId2KHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentId2Supported;
    }

    public unsafe partial struct VkPresentId2KHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint swapchainCount;

                public ulong* pPresentIds;
    }

    public unsafe partial struct VkPhysicalDevicePresentId2FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentId2;
    }

    public unsafe partial struct VkSurfaceCapabilitiesPresentWait2KHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentWait2Supported;
    }

    public unsafe partial struct VkPhysicalDevicePresentWait2FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentWait2;
    }

    public unsafe partial struct VkPresentWait2InfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong presentId;

                public ulong timeout;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingPositionFetchFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rayTracingPositionFetch;
    }

    public partial struct VkPipelineBinaryKHR
    {
    }

    public unsafe partial struct VkPhysicalDevicePipelineBinaryFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelineBinaries;
    }

    public unsafe partial struct VkPhysicalDevicePipelineBinaryPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelineBinaryInternalCache;

                public uint pipelineBinaryInternalCacheControl;

                public uint pipelineBinaryPrefersInternalCache;

                public uint pipelineBinaryPrecompiledInternalCache;

                public uint pipelineBinaryCompressedData;
    }

    public unsafe partial struct VkDevicePipelineBinaryInternalCacheControlKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint disableInternalCache;
    }

    public unsafe partial struct VkPipelineBinaryKeyKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint keySize;

                public _key_e__FixedBuffer key;

        [InlineArray(32)]
        public partial struct _key_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkPipelineBinaryDataKHR
    {
                public nuint dataSize;

        public void* pData;
    }

    public unsafe partial struct VkPipelineBinaryKeysAndDataKHR
    {
                public uint binaryCount;

                public VkPipelineBinaryKeyKHR* pPipelineBinaryKeys;

                public VkPipelineBinaryDataKHR* pPipelineBinaryData;
    }

    public unsafe partial struct VkPipelineCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;
    }

    public unsafe partial struct VkPipelineBinaryCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkPipelineBinaryKeysAndDataKHR* pKeysAndDataInfo;

                public VkPipeline* pipeline;

                public VkPipelineCreateInfoKHR* pPipelineCreateInfo;
    }

    public unsafe partial struct VkPipelineBinaryInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint binaryCount;

                public VkPipelineBinaryKHR** pPipelineBinaries;
    }

    public unsafe partial struct VkReleaseCapturedPipelineDataInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public VkPipeline* pipeline;
    }

    public unsafe partial struct VkPipelineBinaryDataInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public VkPipelineBinaryKHR* pipelineBinary;
    }

    public unsafe partial struct VkPipelineBinaryHandlesInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint pipelineBinaryCount;

                public VkPipelineBinaryKHR** pPipelineBinaries;
    }

    public unsafe partial struct VkSurfacePresentModeKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPresentModeKHR presentMode;
    }

    public unsafe partial struct VkSurfacePresentScalingCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint supportedPresentScaling;

                public uint supportedPresentGravityX;

                public uint supportedPresentGravityY;

        public VkExtent2D minScaledImageExtent;

        public VkExtent2D maxScaledImageExtent;
    }

    public unsafe partial struct VkSurfacePresentModeCompatibilityKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentModeCount;

        public VkPresentModeKHR* pPresentModes;
    }

    public unsafe partial struct VkPhysicalDeviceSwapchainMaintenance1FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint swapchainMaintenance1;
    }

    public unsafe partial struct VkSwapchainPresentFenceInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint swapchainCount;

                public VkFence** pFences;
    }

    public unsafe partial struct VkSwapchainPresentModesCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint presentModeCount;

                public VkPresentModeKHR* pPresentModes;
    }

    public unsafe partial struct VkSwapchainPresentModeInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint swapchainCount;

                public VkPresentModeKHR* pPresentModes;
    }

    public unsafe partial struct VkSwapchainPresentScalingCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint scalingBehavior;

                public uint presentGravityX;

                public uint presentGravityY;
    }

    public unsafe partial struct VkReleaseSwapchainImagesInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSwapchainKHR* swapchain;

                public uint imageIndexCount;

                public uint* pImageIndices;
    }

    public unsafe partial struct VkPhysicalDeviceInternallySynchronizedQueuesFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint internallySynchronizedQueues;
    }

    public unsafe partial struct VkCooperativeMatrixPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint MSize;

                public uint NSize;

                public uint KSize;

        public VkComponentTypeKHR AType;

        public VkComponentTypeKHR BType;

        public VkComponentTypeKHR CType;

        public VkComponentTypeKHR ResultType;

                public uint saturatingAccumulation;

        public VkScopeKHR scope;
    }

    public unsafe partial struct VkPhysicalDeviceCooperativeMatrixFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cooperativeMatrix;

                public uint cooperativeMatrixRobustBufferAccess;
    }

    public unsafe partial struct VkPhysicalDeviceCooperativeMatrixPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cooperativeMatrixSupportedStages;
    }

    public unsafe partial struct VkPhysicalDeviceComputeShaderDerivativesFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint computeDerivativeGroupQuads;

                public uint computeDerivativeGroupLinear;
    }

    public unsafe partial struct VkPhysicalDeviceComputeShaderDerivativesPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint meshAndTaskShaderDerivatives;
    }

    public unsafe partial struct VkVideoDecodeAV1ProfileInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public StdVideoAV1Profile stdProfile;

                public uint filmGrainSupport;
    }

    public unsafe partial struct VkVideoDecodeAV1CapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public StdVideoAV1Level maxLevel;
    }

    public unsafe partial struct VkVideoDecodeAV1SessionParametersCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoAV1SequenceHeader* pStdSequenceHeader;
    }

    public unsafe partial struct VkVideoDecodeAV1PictureInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoDecodeAV1PictureInfo* pStdPictureInfo;

                public _referenceNameSlotIndices_e__FixedBuffer referenceNameSlotIndices;

                public uint frameHeaderOffset;

                public uint tileCount;

                public uint* pTileOffsets;

                public uint* pTileSizes;

        [InlineArray(7)]
        public partial struct _referenceNameSlotIndices_e__FixedBuffer
        {
            public int e0;
        }
    }

    public unsafe partial struct VkVideoDecodeAV1DpbSlotInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoDecodeAV1ReferenceInfo* pStdReferenceInfo;
    }

    public unsafe partial struct VkPhysicalDeviceVideoEncodeAV1FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint videoEncodeAV1;
    }

    public unsafe partial struct VkVideoEncodeAV1CapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

        public StdVideoAV1Level maxLevel;

        public VkExtent2D codedPictureAlignment;

        public VkExtent2D maxTiles;

        public VkExtent2D minTileSize;

        public VkExtent2D maxTileSize;

                public uint superblockSizes;

                public uint maxSingleReferenceCount;

                public uint singleReferenceNameMask;

                public uint maxUnidirectionalCompoundReferenceCount;

                public uint maxUnidirectionalCompoundGroup1ReferenceCount;

                public uint unidirectionalCompoundReferenceNameMask;

                public uint maxBidirectionalCompoundReferenceCount;

                public uint maxBidirectionalCompoundGroup1ReferenceCount;

                public uint maxBidirectionalCompoundGroup2ReferenceCount;

                public uint bidirectionalCompoundReferenceNameMask;

                public uint maxTemporalLayerCount;

                public uint maxSpatialLayerCount;

                public uint maxOperatingPoints;

                public uint minQIndex;

                public uint maxQIndex;

                public uint prefersGopRemainingFrames;

                public uint requiresGopRemainingFrames;

                public uint stdSyntaxFlags;
    }

    public partial struct VkVideoEncodeAV1QIndexKHR
    {
                public uint intraQIndex;

                public uint predictiveQIndex;

                public uint bipredictiveQIndex;
    }

    public unsafe partial struct VkVideoEncodeAV1QualityLevelPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint preferredRateControlFlags;

                public uint preferredGopFrameCount;

                public uint preferredKeyFramePeriod;

                public uint preferredConsecutiveBipredictiveFrameCount;

                public uint preferredTemporalLayerCount;

        public VkVideoEncodeAV1QIndexKHR preferredConstantQIndex;

                public uint preferredMaxSingleReferenceCount;

                public uint preferredSingleReferenceNameMask;

                public uint preferredMaxUnidirectionalCompoundReferenceCount;

                public uint preferredMaxUnidirectionalCompoundGroup1ReferenceCount;

                public uint preferredUnidirectionalCompoundReferenceNameMask;

                public uint preferredMaxBidirectionalCompoundReferenceCount;

                public uint preferredMaxBidirectionalCompoundGroup1ReferenceCount;

                public uint preferredMaxBidirectionalCompoundGroup2ReferenceCount;

                public uint preferredBidirectionalCompoundReferenceNameMask;
    }

    public unsafe partial struct VkVideoEncodeAV1SessionCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint useMaxLevel;

        public StdVideoAV1Level maxLevel;
    }

    public unsafe partial struct VkVideoEncodeAV1SessionParametersCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoAV1SequenceHeader* pStdSequenceHeader;

                public StdVideoEncodeAV1DecoderModelInfo* pStdDecoderModelInfo;

                public uint stdOperatingPointCount;

                public StdVideoEncodeAV1OperatingPointInfo* pStdOperatingPoints;
    }

    public unsafe partial struct VkVideoEncodeAV1PictureInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkVideoEncodeAV1PredictionModeKHR predictionMode;

        public VkVideoEncodeAV1RateControlGroupKHR rateControlGroup;

                public uint constantQIndex;

                public StdVideoEncodeAV1PictureInfo* pStdPictureInfo;

                public _referenceNameSlotIndices_e__FixedBuffer referenceNameSlotIndices;

                public uint primaryReferenceCdfOnly;

                public uint generateObuExtensionHeader;

        [InlineArray(7)]
        public partial struct _referenceNameSlotIndices_e__FixedBuffer
        {
            public int e0;
        }
    }

    public unsafe partial struct VkVideoEncodeAV1DpbSlotInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoEncodeAV1ReferenceInfo* pStdReferenceInfo;
    }

    public unsafe partial struct VkVideoEncodeAV1ProfileInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public StdVideoAV1Profile stdProfile;
    }

    public partial struct VkVideoEncodeAV1FrameSizeKHR
    {
                public uint intraFrameSize;

                public uint predictiveFrameSize;

                public uint bipredictiveFrameSize;
    }

    public unsafe partial struct VkVideoEncodeAV1GopRemainingFrameInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint useGopRemainingFrames;

                public uint gopRemainingIntra;

                public uint gopRemainingPredictive;

                public uint gopRemainingBipredictive;
    }

    public unsafe partial struct VkVideoEncodeAV1RateControlInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint gopFrameCount;

                public uint keyFramePeriod;

                public uint consecutiveBipredictiveFrameCount;

                public uint temporalLayerCount;
    }

    public unsafe partial struct VkVideoEncodeAV1RateControlLayerInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint useMinQIndex;

        public VkVideoEncodeAV1QIndexKHR minQIndex;

                public uint useMaxQIndex;

        public VkVideoEncodeAV1QIndexKHR maxQIndex;

                public uint useMaxFrameSize;

        public VkVideoEncodeAV1FrameSizeKHR maxFrameSize;
    }

    public unsafe partial struct VkPhysicalDeviceVideoDecodeVP9FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint videoDecodeVP9;
    }

    public unsafe partial struct VkVideoDecodeVP9ProfileInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public StdVideoVP9Profile stdProfile;
    }

    public unsafe partial struct VkVideoDecodeVP9CapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public StdVideoVP9Level maxLevel;
    }

    public unsafe partial struct VkVideoDecodeVP9PictureInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoDecodeVP9PictureInfo* pStdPictureInfo;

                public _referenceNameSlotIndices_e__FixedBuffer referenceNameSlotIndices;

                public uint uncompressedHeaderOffset;

                public uint compressedHeaderOffset;

                public uint tilesOffset;

        [InlineArray(3)]
        public partial struct _referenceNameSlotIndices_e__FixedBuffer
        {
            public int e0;
        }
    }

    public unsafe partial struct VkPhysicalDeviceVideoMaintenance1FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint videoMaintenance1;
    }

    public unsafe partial struct VkVideoInlineQueryInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkQueryPool* queryPool;

                public uint firstQuery;

                public uint queryCount;
    }

    public unsafe partial struct VkPhysicalDeviceUnifiedImageLayoutsFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint unifiedImageLayouts;

                public uint unifiedImageLayoutsVideo;
    }

    public unsafe partial struct VkAttachmentFeedbackLoopInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint feedbackLoopEnable;
    }

    public unsafe partial struct VkCalibratedTimestampInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkTimeDomainKHR timeDomain;
    }

    public unsafe partial struct VkSetDescriptorBufferOffsetsInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stageFlags;

                public VkPipelineLayout* layout;

                public uint firstSet;

                public uint setCount;

                public uint* pBufferIndices;

                public ulong* pOffsets;
    }

    public unsafe partial struct VkBindDescriptorBufferEmbeddedSamplersInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stageFlags;

                public VkPipelineLayout* layout;

                public uint set;
    }

    public partial struct VkCopyMemoryIndirectCommandKHR
    {
                public ulong srcAddress;

                public ulong dstAddress;

                public ulong size;
    }

    public unsafe partial struct VkCopyMemoryIndirectInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint srcCopyFlags;

                public uint dstCopyFlags;

                public uint copyCount;

        public VkStridedDeviceAddressRangeKHR copyAddressRange;
    }

    public partial struct VkCopyMemoryToImageIndirectCommandKHR
    {
                public ulong srcAddress;

                public uint bufferRowLength;

                public uint bufferImageHeight;

        public VkImageSubresourceLayers imageSubresource;

        public VkOffset3D imageOffset;

        public VkExtent3D imageExtent;
    }

    public unsafe partial struct VkCopyMemoryToImageIndirectInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint srcCopyFlags;

                public uint copyCount;

        public VkStridedDeviceAddressRangeKHR copyAddressRange;

                public VkImage* dstImage;

        public VkImageLayout dstImageLayout;

                public VkImageSubresourceLayers* pImageSubresources;
    }

    public unsafe partial struct VkPhysicalDeviceCopyMemoryIndirectFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint indirectMemoryCopy;

                public uint indirectMemoryToImageCopy;
    }

    public unsafe partial struct VkPhysicalDeviceCopyMemoryIndirectPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint supportedQueues;
    }

    public unsafe partial struct VkVideoEncodeIntraRefreshCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint intraRefreshModes;

                public uint maxIntraRefreshCycleDuration;

                public uint maxIntraRefreshActiveReferencePictures;

                public uint partitionIndependentIntraRefreshRegions;

                public uint nonRectangularIntraRefreshRegions;
    }

    public unsafe partial struct VkVideoEncodeSessionIntraRefreshCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkVideoEncodeIntraRefreshModeFlagBitsKHR intraRefreshMode;
    }

    public unsafe partial struct VkVideoEncodeIntraRefreshInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint intraRefreshCycleDuration;

                public uint intraRefreshIndex;
    }

    public unsafe partial struct VkVideoReferenceIntraRefreshInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint dirtyIntraRefreshRegions;
    }

    public unsafe partial struct VkPhysicalDeviceVideoEncodeIntraRefreshFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint videoEncodeIntraRefresh;
    }

    public unsafe partial struct VkVideoEncodeQuantizationMapCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent2D maxQuantizationMapExtent;
    }

    public unsafe partial struct VkVideoFormatQuantizationMapPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent2D quantizationMapTexelSize;
    }

    public unsafe partial struct VkVideoEncodeQuantizationMapInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImageView* quantizationMap;

        public VkExtent2D quantizationMapExtent;
    }

    public unsafe partial struct VkVideoEncodeQuantizationMapSessionParametersCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExtent2D quantizationMapTexelSize;
    }

    public unsafe partial struct VkPhysicalDeviceVideoEncodeQuantizationMapFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint videoEncodeQuantizationMap;
    }

    public unsafe partial struct VkVideoEncodeH264QuantizationMapCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public int minQpDelta;

                public int maxQpDelta;
    }

    public unsafe partial struct VkVideoEncodeH265QuantizationMapCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public int minQpDelta;

                public int maxQpDelta;
    }

    public unsafe partial struct VkVideoFormatH265QuantizationMapPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint compatibleCtbSizes;
    }

    public unsafe partial struct VkVideoEncodeAV1QuantizationMapCapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public int minQIndexDelta;

                public int maxQIndexDelta;
    }

    public unsafe partial struct VkVideoFormatAV1QuantizationMapPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint compatibleSuperblockSizes;
    }

    public unsafe partial struct VkPhysicalDeviceShaderRelaxedExtendedInstructionFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderRelaxedExtendedInstruction;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance7FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maintenance7;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance7PropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint robustFragmentShadingRateAttachmentAccess;

                public uint separateDepthStencilAttachmentAccess;

                public uint maxDescriptorSetTotalUniformBuffersDynamic;

                public uint maxDescriptorSetTotalStorageBuffersDynamic;

                public uint maxDescriptorSetTotalBuffersDynamic;

                public uint maxDescriptorSetUpdateAfterBindTotalUniformBuffersDynamic;

                public uint maxDescriptorSetUpdateAfterBindTotalStorageBuffersDynamic;

                public uint maxDescriptorSetUpdateAfterBindTotalBuffersDynamic;
    }

    public unsafe partial struct VkPhysicalDeviceLayeredApiPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint vendorID;

                public uint deviceID;

        public VkPhysicalDeviceLayeredApiKHR layeredAPI;

                public _deviceName_e__FixedBuffer deviceName;

        [InlineArray(256)]
        public partial struct _deviceName_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkPhysicalDeviceLayeredApiPropertiesListKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint layeredApiCount;

        public VkPhysicalDeviceLayeredApiPropertiesKHR* pLayeredApis;
    }

    public unsafe partial struct VkPhysicalDeviceLayeredApiVulkanPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPhysicalDeviceProperties2 properties;
    }

    public unsafe partial struct VkPhysicalDeviceFaultFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint deviceFault;

                public uint deviceFaultVendorBinary;

                public uint deviceFaultReportMasked;

                public uint deviceFaultDeviceLostOnMasked;
    }

    public unsafe partial struct VkPhysicalDeviceFaultPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxDeviceFaultCount;
    }

    public partial struct VkDeviceFaultAddressInfoKHR
    {
        public VkDeviceFaultAddressTypeKHR addressType;

                public ulong reportedAddress;

                public ulong addressPrecision;
    }

    public partial struct VkDeviceFaultVendorInfoKHR
    {
                public _description_e__FixedBuffer description;

                public ulong vendorFaultCode;

                public ulong vendorFaultData;

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkDeviceFaultInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public ulong groupId;

                public _description_e__FixedBuffer description;

        public VkDeviceFaultAddressInfoKHR faultAddressInfo;

        public VkDeviceFaultAddressInfoKHR instructionAddressInfo;

        public VkDeviceFaultVendorInfoKHR vendorInfo;

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkDeviceFaultDebugInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint vendorBinarySize;

        public void* pVendorBinaryData;
    }

    public partial struct VkDeviceFaultVendorBinaryHeaderVersionOneKHR
    {
                public uint headerSize;

        public VkDeviceFaultVendorBinaryHeaderVersionKHR headerVersion;

                public uint vendorID;

                public uint deviceID;

                public uint driverVersion;

                public _pipelineCacheUUID_e__FixedBuffer pipelineCacheUUID;

                public uint applicationNameOffset;

                public uint applicationVersion;

                public uint engineNameOffset;

                public uint engineVersion;

                public uint apiVersion;

        [InlineArray(16)]
        public partial struct _pipelineCacheUUID_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkMemoryBarrierAccessFlags3KHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong srcAccessMask3;

                public ulong dstAccessMask3;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance8FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maintenance8;
    }

    public unsafe partial struct VkPhysicalDeviceShaderFmaFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderFmaFloat16;

                public uint shaderFmaFloat32;

                public uint shaderFmaFloat64;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance9FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maintenance9;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance9PropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint image2DViewOf3DSparse;

        public VkDefaultVertexAttributeValueKHR defaultVertexAttributeValue;
    }

    public unsafe partial struct VkQueueFamilyOwnershipTransferPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint optimalImageTransferToQueueFamilies;
    }

    public unsafe partial struct VkPhysicalDeviceVideoMaintenance2FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint videoMaintenance2;
    }

    public unsafe partial struct VkVideoDecodeH264InlineSessionParametersInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoH264SequenceParameterSet* pStdSPS;

                public StdVideoH264PictureParameterSet* pStdPPS;
    }

    public unsafe partial struct VkVideoDecodeH265InlineSessionParametersInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoH265VideoParameterSet* pStdVPS;

                public StdVideoH265SequenceParameterSet* pStdSPS;

                public StdVideoH265PictureParameterSet* pStdPPS;
    }

    public unsafe partial struct VkVideoDecodeAV1InlineSessionParametersInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public StdVideoAV1SequenceHeader* pStdSequenceHeader;
    }

    public unsafe partial struct VkPhysicalDeviceVideoEncodeFeedback2FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint videoEncodeFeedback2;
    }

    public unsafe partial struct VkVideoEncodeFeedback2CapabilitiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxPerPartitionFeedbackEntries;

                public uint supportedPerPartitionEncodeFeedbackFlags;
    }

    public unsafe partial struct VkQueryPoolVideoEncodePerPartitionFeedbackCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint maxPerPartitionFeedbackEntries;

                public uint perPartitionEncodeFeedbackFlags;
    }

    public unsafe partial struct VkPhysicalDeviceDepthClampZeroOneFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint depthClampZeroOne;
    }

    public unsafe partial struct VkPhysicalDeviceRobustness2FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint robustBufferAccess2;

                public uint robustImageAccess2;

                public uint nullDescriptor;
    }

    public unsafe partial struct VkPhysicalDeviceRobustness2PropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong robustStorageBufferAccessSizeAlignment;

                public ulong robustUniformBufferAccessSizeAlignment;
    }

    public unsafe partial struct VkPhysicalDevicePresentModeFifoLatestReadyFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentModeFifoLatestReady;
    }

    public partial struct VkMicromapUsageKHR
    {
                public uint count;

                public uint subdivisionLevel;

        public VkOpacityMicromapFormatKHR format;
    }

    public unsafe partial struct VkAccelerationStructureGeometryMicromapDataKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint usageCountsCount;

                public VkMicromapUsageKHR* pUsageCounts;

                public VkMicromapUsageKHR** ppUsageCounts;

                public ulong data;

                public ulong triangleArray;

                public ulong triangleArrayStride;
    }

    public unsafe partial struct VkPhysicalDeviceOpacityMicromapFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint micromap;
    }

    public unsafe partial struct VkPhysicalDeviceOpacityMicromapPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxOpacity2StateSubdivisionLevel;

                public uint maxOpacity4StateSubdivisionLevel;

                public uint maxOpacityLossy4StateSubdivisionLevel;

                public ulong maxMicromapTriangles;
    }

    public partial struct VkMicromapTriangleKHR
    {
                public uint dataOffset;

                public ushort subdivisionLevel;

                public ushort format;
    }

    public unsafe partial struct VkAccelerationStructureTrianglesOpacityMicromapKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkIndexType indexType;

                public ulong indexBuffer;

                public ulong indexStride;

                public uint baseTriangle;

                public VkAccelerationStructureKHR* micromap;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance10FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maintenance10;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance10PropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rgba4OpaqueBlackSwizzled;

                public uint resolveSrgbFormatAppliesTransferFunction;

                public uint resolveSrgbFormatSupportsTransferFunctionControl;
    }

    public unsafe partial struct VkRenderingEndInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;
    }

    public unsafe partial struct VkRenderingAttachmentFlagsInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkResolveImageModeInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkResolveModeFlagBits resolveMode;

        public VkResolveModeFlagBits stencilResolveMode;
    }

    public unsafe partial struct VkPhysicalDeviceMaintenance11FeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maintenance11;
    }

    public unsafe partial struct VkQueueFamilyOptimalImageTransferGranularityPropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent3D optimalImageTransferGranularity;
    }

    public unsafe partial struct VkFormatProperties4KHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong linearTilingFeatures;

                public ulong optimalTilingFeatures;

                public ulong bufferFeatures;
    }

    public unsafe partial struct VkImageUsageFlags2CreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong usage;
    }

    public unsafe partial struct VkImageCreateFlags2CreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong flags;
    }

    public unsafe partial struct VkImageViewUsage2CreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong usage;
    }

    public unsafe partial struct VkPhysicalDeviceExtendedFlagsFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint extendedFlags;
    }

    public unsafe partial struct VkImageStencilUsage2CreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong stencilUsage;
    }

    public unsafe partial struct VkSharedPresentSurfaceCapabilities2KHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong sharedPresentSupportedUsageFlags;
    }

    public partial struct VkDebugReportCallbackEXT
    {
    }

    public unsafe partial struct VkDebugReportCallbackCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public delegate* unmanaged[Cdecl]<uint, VkDebugReportObjectTypeEXT, ulong, nuint, int, sbyte*, sbyte*, void*, uint> pfnCallback;

        public void* pUserData;
    }

    public unsafe partial struct VkPipelineRasterizationStateRasterizationOrderAMD
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkRasterizationOrderAMD rasterizationOrder;
    }

    public unsafe partial struct VkDebugMarkerObjectNameInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDebugReportObjectTypeEXT objectType;

                public ulong @object;

                public sbyte* pObjectName;
    }

    public unsafe partial struct VkDebugMarkerObjectTagInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDebugReportObjectTypeEXT objectType;

                public ulong @object;

                public ulong tagName;

                public nuint tagSize;

                public void* pTag;
    }

    public unsafe partial struct VkDebugMarkerMarkerInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public sbyte* pMarkerName;

                public _color_e__FixedBuffer color;

        [InlineArray(4)]
        public partial struct _color_e__FixedBuffer
        {
            public float e0;
        }
    }

    public unsafe partial struct VkDedicatedAllocationImageCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint dedicatedAllocation;
    }

    public unsafe partial struct VkDedicatedAllocationBufferCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint dedicatedAllocation;
    }

    public unsafe partial struct VkDedicatedAllocationMemoryAllocateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* image;

                public VkBuffer* buffer;
    }

    public unsafe partial struct VkPhysicalDeviceTransformFeedbackFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint transformFeedback;

                public uint geometryStreams;
    }

    public unsafe partial struct VkPhysicalDeviceTransformFeedbackPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxTransformFeedbackStreams;

                public uint maxTransformFeedbackBuffers;

                public ulong maxTransformFeedbackBufferSize;

                public uint maxTransformFeedbackStreamDataSize;

                public uint maxTransformFeedbackBufferDataSize;

                public uint maxTransformFeedbackBufferDataStride;

                public uint transformFeedbackQueries;

                public uint transformFeedbackStreamsLinesTriangles;

                public uint transformFeedbackRasterizationStreamSelect;

                public uint transformFeedbackDraw;
    }

    public unsafe partial struct VkPipelineRasterizationStateStreamCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint rasterizationStream;
    }

    public partial struct VkCuModuleNVX
    {
    }

    public partial struct VkCuFunctionNVX
    {
    }

    public unsafe partial struct VkCuModuleCreateInfoNVX
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public nuint dataSize;

                public void* pData;
    }

    public unsafe partial struct VkCuModuleTexturingModeCreateInfoNVX
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint use64bitTexturing;
    }

    public unsafe partial struct VkCuFunctionCreateInfoNVX
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkCuModuleNVX* module;

                public sbyte* pName;
    }

    public unsafe partial struct VkCuLaunchInfoNVX
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkCuFunctionNVX* function;

                public uint gridDimX;

                public uint gridDimY;

                public uint gridDimZ;

                public uint blockDimX;

                public uint blockDimY;

                public uint blockDimZ;

                public uint sharedMemBytes;

                public nuint paramCount;

                public void** pParams;

                public nuint extraCount;

                public void** pExtras;
    }

    public unsafe partial struct VkImageViewHandleInfoNVX
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImageView* imageView;

        public VkDescriptorType descriptorType;

                public VkSampler* sampler;
    }

    public unsafe partial struct VkImageViewAddressPropertiesNVX
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong deviceAddress;

                public ulong size;
    }

    public unsafe partial struct VkTextureLODGatherFormatPropertiesAMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint supportsTextureGatherLODBiasAMD;
    }

    public partial struct VkShaderResourceUsageAMD
    {
                public uint numUsedVgprs;

                public uint numUsedSgprs;

                public uint ldsSizePerLocalWorkGroup;

                public nuint ldsUsageSizeInBytes;

                public nuint scratchMemUsageInBytes;
    }

    public partial struct VkShaderStatisticsInfoAMD
    {
                public uint shaderStageMask;

        public VkShaderResourceUsageAMD resourceUsage;

                public uint numPhysicalVgprs;

                public uint numPhysicalSgprs;

                public uint numAvailableVgprs;

                public uint numAvailableSgprs;

                public _computeWorkGroupSize_e__FixedBuffer computeWorkGroupSize;

        [InlineArray(3)]
        public partial struct _computeWorkGroupSize_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public unsafe partial struct VkPhysicalDeviceCornerSampledImageFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cornerSampledImage;
    }

    public partial struct VkExternalImageFormatPropertiesNV
    {
        public VkImageFormatProperties imageFormatProperties;

                public uint externalMemoryFeatures;

                public uint exportFromImportedHandleTypes;

                public uint compatibleHandleTypes;
    }

    public unsafe partial struct VkExternalMemoryImageCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint handleTypes;
    }

    public unsafe partial struct VkExportMemoryAllocateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint handleTypes;
    }

    public unsafe partial struct VkValidationFlagsEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint disabledValidationCheckCount;

                public VkValidationCheckEXT* pDisabledValidationChecks;
    }

    public unsafe partial struct VkImageViewASTCDecodeModeEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkFormat decodeMode;
    }

    public unsafe partial struct VkPhysicalDeviceASTCDecodeFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint decodeModeSharedExponent;
    }

    public unsafe partial struct VkConditionalRenderingBeginInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBuffer* buffer;

                public ulong offset;

                public uint flags;
    }

    public unsafe partial struct VkPhysicalDeviceConditionalRenderingFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint conditionalRendering;

                public uint inheritedConditionalRendering;
    }

    public unsafe partial struct VkCommandBufferInheritanceConditionalRenderingInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint conditionalRenderingEnable;
    }

    public partial struct VkViewportWScalingNV
    {
        public float xcoeff;

        public float ycoeff;
    }

    public unsafe partial struct VkPipelineViewportWScalingStateCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint viewportWScalingEnable;

                public uint viewportCount;

                public VkViewportWScalingNV* pViewportWScalings;
    }

    public unsafe partial struct VkSurfaceCapabilities2EXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint minImageCount;

                public uint maxImageCount;

        public VkExtent2D currentExtent;

        public VkExtent2D minImageExtent;

        public VkExtent2D maxImageExtent;

                public uint maxImageArrayLayers;

                public uint supportedTransforms;

        public VkSurfaceTransformFlagBitsKHR currentTransform;

                public uint supportedCompositeAlpha;

                public uint supportedUsageFlags;

                public uint supportedSurfaceCounters;
    }

    public unsafe partial struct VkDisplayPowerInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDisplayPowerStateEXT powerState;
    }

    public unsafe partial struct VkDeviceEventInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceEventTypeEXT deviceEvent;
    }

    public unsafe partial struct VkDisplayEventInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDisplayEventTypeEXT displayEvent;
    }

    public unsafe partial struct VkSwapchainCounterCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint surfaceCounters;
    }

    public partial struct VkRefreshCycleDurationGOOGLE
    {
                public ulong refreshDuration;
    }

    public partial struct VkPastPresentationTimingGOOGLE
    {
                public uint presentID;

                public ulong desiredPresentTime;

                public ulong actualPresentTime;

                public ulong earliestPresentTime;

                public ulong presentMargin;
    }

    public partial struct VkPresentTimeGOOGLE
    {
                public uint presentID;

                public ulong desiredPresentTime;
    }

    public unsafe partial struct VkPresentTimesInfoGOOGLE
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint swapchainCount;

                public VkPresentTimeGOOGLE* pTimes;
    }

    public unsafe partial struct VkPhysicalDeviceMultiviewPerViewAttributesPropertiesNVX
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint perViewPositionAllComponents;
    }

    public unsafe partial struct VkMultiviewPerViewAttributesInfoNVX
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint perViewAttributes;

                public uint perViewAttributesPositionXOnly;
    }

    public partial struct VkViewportSwizzleNV
    {
        public VkViewportCoordinateSwizzleNV x;

        public VkViewportCoordinateSwizzleNV y;

        public VkViewportCoordinateSwizzleNV z;

        public VkViewportCoordinateSwizzleNV w;
    }

    public unsafe partial struct VkPipelineViewportSwizzleStateCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint viewportCount;

                public VkViewportSwizzleNV* pViewportSwizzles;
    }

    public unsafe partial struct VkPhysicalDeviceDiscardRectanglePropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxDiscardRectangles;
    }

    public unsafe partial struct VkPipelineDiscardRectangleStateCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkDiscardRectangleModeEXT discardRectangleMode;

                public uint discardRectangleCount;

                public VkRect2D* pDiscardRectangles;
    }

    public unsafe partial struct VkPhysicalDeviceConservativeRasterizationPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public float primitiveOverestimationSize;

        public float maxExtraPrimitiveOverestimationSize;

        public float extraPrimitiveOverestimationSizeGranularity;

                public uint primitiveUnderestimation;

                public uint conservativePointAndLineRasterization;

                public uint degenerateTrianglesRasterized;

                public uint degenerateLinesRasterized;

                public uint fullyCoveredFragmentShaderInputVariable;

                public uint conservativeRasterizationPostDepthCoverage;
    }

    public unsafe partial struct VkPipelineRasterizationConservativeStateCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkConservativeRasterizationModeEXT conservativeRasterizationMode;

        public float extraPrimitiveOverestimationSize;
    }

    public unsafe partial struct VkPhysicalDeviceDepthClipEnableFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint depthClipEnable;
    }

    public unsafe partial struct VkPipelineRasterizationDepthClipStateCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint depthClipEnable;
    }

    public partial struct VkXYColorEXT
    {
        public float x;

        public float y;
    }

    public unsafe partial struct VkHdrMetadataEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkXYColorEXT displayPrimaryRed;

        public VkXYColorEXT displayPrimaryGreen;

        public VkXYColorEXT displayPrimaryBlue;

        public VkXYColorEXT whitePoint;

        public float maxLuminance;

        public float minLuminance;

        public float maxContentLightLevel;

        public float maxFrameAverageLightLevel;
    }

    public unsafe partial struct VkPhysicalDeviceRelaxedLineRasterizationFeaturesIMG
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint relaxedLineRasterization;
    }

    public partial struct VkDebugUtilsMessengerEXT
    {
    }

    public unsafe partial struct VkDebugUtilsLabelEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public sbyte* pLabelName;

                public _color_e__FixedBuffer color;

        [InlineArray(4)]
        public partial struct _color_e__FixedBuffer
        {
            public float e0;
        }
    }

    public unsafe partial struct VkDebugUtilsObjectNameInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkObjectType objectType;

                public ulong objectHandle;

                public sbyte* pObjectName;
    }

    public unsafe partial struct VkDebugUtilsMessengerCallbackDataEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public sbyte* pMessageIdName;

                public int messageIdNumber;

                public sbyte* pMessage;

                public uint queueLabelCount;

                public VkDebugUtilsLabelEXT* pQueueLabels;

                public uint cmdBufLabelCount;

                public VkDebugUtilsLabelEXT* pCmdBufLabels;

                public uint objectCount;

                public VkDebugUtilsObjectNameInfoEXT* pObjects;
    }

    public unsafe partial struct VkDebugUtilsMessengerCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint messageSeverity;

                public uint messageType;

                public delegate* unmanaged[Cdecl]<VkDebugUtilsMessageSeverityFlagBitsEXT, uint, VkDebugUtilsMessengerCallbackDataEXT*, void*, uint> pfnUserCallback;

        public void* pUserData;
    }

    public unsafe partial struct VkDebugUtilsObjectTagInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkObjectType objectType;

                public ulong objectHandle;

                public ulong tagName;

                public nuint tagSize;

                public void* pTag;
    }

    public partial struct VkGpaSessionAMD
    {
    }

    public partial struct VkGpaPerfBlockPropertiesAMD
    {
        public VkGpaPerfBlockAMD blockType;

                public uint flags;

                public uint instanceCount;

                public uint maxEventID;

                public uint maxGlobalOnlyCounters;

                public uint maxGlobalSharedCounters;

                public uint maxStreamingCounters;
    }

    public unsafe partial struct VkPhysicalDeviceGpaFeaturesAMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint perfCounters;

                public uint streamingPerfCounters;

                public uint sqThreadTracing;

                public uint clockModes;
    }

    public unsafe partial struct VkPhysicalDeviceGpaPropertiesAMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public ulong maxSqttSeBufferSize;

                public uint shaderEngineCount;

                public uint perfBlockCount;

        public VkGpaPerfBlockPropertiesAMD* pPerfBlocks;
    }

    public unsafe partial struct VkPhysicalDeviceGpaProperties2AMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint revisionId;
    }

    public partial struct VkGpaPerfCounterAMD
    {
        public VkGpaPerfBlockAMD blockType;

                public uint blockInstance;

                public uint eventID;
    }

    public unsafe partial struct VkGpaSampleBeginInfoAMD
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkGpaSampleTypeAMD sampleType;

                public uint sampleInternalOperations;

                public uint cacheFlushOnCounterCollection;

                public uint sqShaderMaskEnable;

                public uint sqShaderMask;

                public uint perfCounterCount;

                public VkGpaPerfCounterAMD* pPerfCounters;

                public uint streamingPerfTraceSampleInterval;

                public ulong perfCounterDeviceMemoryLimit;

                public uint sqThreadTraceEnable;

                public uint sqThreadTraceSuppressInstructionTokens;

                public ulong sqThreadTraceDeviceMemoryLimit;

                public uint timingPreSample;

                public uint timingPostSample;
    }

    public unsafe partial struct VkGpaDeviceClockModeInfoAMD
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkGpaDeviceClockModeAMD clockMode;

        public float memoryClockRatioToPeak;

        public float engineClockRatioToPeak;
    }

    public unsafe partial struct VkGpaDeviceGetClockInfoAMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public float memoryClockRatioToPeak;

        public float engineClockRatioToPeak;

                public uint memoryClockFrequency;

                public uint engineClockFrequency;
    }

    public unsafe partial struct VkGpaSessionCreateInfoAMD
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkGpaSessionAMD* secondaryCopySource;
    }

    public partial struct VkTensorARM
    {
    }

    public unsafe partial struct VkHostAddressRangeEXT
    {
        public void* address;

                public nuint size;
    }

    public unsafe partial struct VkHostAddressRangeConstEXT
    {
                public void* address;

                public nuint size;
    }

    public unsafe partial struct VkTexelBufferDescriptorInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkFormat format;

                public VkDeviceAddressRangeKHR addressRange;
    }

    public unsafe partial struct VkImageDescriptorInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImageViewCreateInfo* pView;

        public VkImageLayout layout;
    }

    public unsafe partial struct VkTensorViewCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong flags;

                public VkTensorARM* tensor;

        public VkFormat format;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct VkResourceDescriptorDataEXT
    {
        [FieldOffset(0)]
                public VkImageDescriptorInfoEXT* pImage;

        [FieldOffset(0)]
                public VkTexelBufferDescriptorInfoEXT* pTexelBuffer;

        [FieldOffset(0)]
                public VkDeviceAddressRangeKHR* pAddressRange;

        [FieldOffset(0)]
                public VkTensorViewCreateInfoARM* pTensorARM;
    }

    public unsafe partial struct VkResourceDescriptorInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDescriptorType type;

        public VkResourceDescriptorDataEXT data;
    }

    public unsafe partial struct VkBindHeapInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDeviceAddressRangeKHR heapRange;

                public ulong reservedRangeOffset;

                public ulong reservedRangeSize;
    }

    public unsafe partial struct VkPushDataInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint offset;

        public VkHostAddressRangeConstEXT data;
    }

    public unsafe partial struct VkDescriptorMappingSourceConstantOffsetEXT
    {
                public uint heapOffset;

                public uint heapArrayStride;

                public VkSamplerCreateInfo* pEmbeddedSampler;

                public uint samplerHeapOffset;

                public uint samplerHeapArrayStride;
    }

    public unsafe partial struct VkDescriptorMappingSourcePushIndexEXT
    {
                public uint heapOffset;

                public uint pushOffset;

                public uint heapIndexStride;

                public uint heapArrayStride;

                public VkSamplerCreateInfo* pEmbeddedSampler;

                public uint useCombinedImageSamplerIndex;

                public uint samplerHeapOffset;

                public uint samplerPushOffset;

                public uint samplerHeapIndexStride;

                public uint samplerHeapArrayStride;
    }

    public unsafe partial struct VkDescriptorMappingSourceIndirectIndexEXT
    {
                public uint heapOffset;

                public uint pushOffset;

                public uint addressOffset;

                public uint heapIndexStride;

                public uint heapArrayStride;

                public VkSamplerCreateInfo* pEmbeddedSampler;

                public uint useCombinedImageSamplerIndex;

                public uint samplerHeapOffset;

                public uint samplerPushOffset;

                public uint samplerAddressOffset;

                public uint samplerHeapIndexStride;

                public uint samplerHeapArrayStride;
    }

    public partial struct VkDescriptorMappingSourceHeapDataEXT
    {
                public uint heapOffset;

                public uint pushOffset;
    }

    public partial struct VkDescriptorMappingSourceIndirectAddressEXT
    {
                public uint pushOffset;

                public uint addressOffset;
    }

    public unsafe partial struct VkDescriptorMappingSourceShaderRecordIndexEXT
    {
                public uint heapOffset;

                public uint shaderRecordOffset;

                public uint heapIndexStride;

                public uint heapArrayStride;

                public VkSamplerCreateInfo* pEmbeddedSampler;

                public uint useCombinedImageSamplerIndex;

                public uint samplerHeapOffset;

                public uint samplerShaderRecordOffset;

                public uint samplerHeapIndexStride;

                public uint samplerHeapArrayStride;
    }

    public unsafe partial struct VkDescriptorMappingSourceIndirectIndexArrayEXT
    {
                public uint heapOffset;

                public uint pushOffset;

                public uint addressOffset;

                public uint heapIndexStride;

                public VkSamplerCreateInfo* pEmbeddedSampler;

                public uint useCombinedImageSamplerIndex;

                public uint samplerHeapOffset;

                public uint samplerPushOffset;

                public uint samplerAddressOffset;

                public uint samplerHeapIndexStride;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct VkDescriptorMappingSourceDataEXT
    {
        [FieldOffset(0)]
        public VkDescriptorMappingSourceConstantOffsetEXT constantOffset;

        [FieldOffset(0)]
        public VkDescriptorMappingSourcePushIndexEXT pushIndex;

        [FieldOffset(0)]
        public VkDescriptorMappingSourceIndirectIndexEXT indirectIndex;

        [FieldOffset(0)]
        public VkDescriptorMappingSourceIndirectIndexArrayEXT indirectIndexArray;

        [FieldOffset(0)]
        public VkDescriptorMappingSourceHeapDataEXT heapData;

        [FieldOffset(0)]
                public uint pushDataOffset;

        [FieldOffset(0)]
                public uint pushAddressOffset;

        [FieldOffset(0)]
        public VkDescriptorMappingSourceIndirectAddressEXT indirectAddress;

        [FieldOffset(0)]
        public VkDescriptorMappingSourceShaderRecordIndexEXT shaderRecordIndex;

        [FieldOffset(0)]
                public uint shaderRecordDataOffset;

        [FieldOffset(0)]
                public uint shaderRecordAddressOffset;
    }

    public unsafe partial struct VkDescriptorSetAndBindingMappingEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint descriptorSet;

                public uint firstBinding;

                public uint bindingCount;

                public uint resourceMask;

        public VkDescriptorMappingSourceEXT source;

        public VkDescriptorMappingSourceDataEXT sourceData;
    }

    public unsafe partial struct VkShaderDescriptorSetAndBindingMappingInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint mappingCount;

                public VkDescriptorSetAndBindingMappingEXT* pMappings;
    }

    public unsafe partial struct VkOpaqueCaptureDataCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkHostAddressRangeConstEXT* pData;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorHeapFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint descriptorHeap;

                public uint descriptorHeapCaptureReplay;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorHeapPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong samplerHeapAlignment;

                public ulong resourceHeapAlignment;

                public ulong maxSamplerHeapSize;

                public ulong maxResourceHeapSize;

                public ulong minSamplerHeapReservedRange;

                public ulong minSamplerHeapReservedRangeWithEmbedded;

                public ulong minResourceHeapReservedRange;

                public ulong samplerDescriptorSize;

                public ulong imageDescriptorSize;

                public ulong bufferDescriptorSize;

                public ulong samplerDescriptorAlignment;

                public ulong imageDescriptorAlignment;

                public ulong bufferDescriptorAlignment;

                public ulong maxPushDataSize;

                public nuint imageCaptureReplayOpaqueDataSize;

                public uint maxDescriptorHeapEmbeddedSamplers;

                public uint samplerYcbcrConversionCount;

                public uint sparseDescriptorHeaps;

                public uint protectedDescriptorHeaps;
    }

    public unsafe partial struct VkCommandBufferInheritanceDescriptorHeapInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBindHeapInfoEXT* pSamplerHeapBindInfo;

                public VkBindHeapInfoEXT* pResourceHeapBindInfo;
    }

    public unsafe partial struct VkSamplerCustomBorderColorIndexCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint index;
    }

    public unsafe partial struct VkSamplerCustomBorderColorCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkClearColorValue customBorderColor;

        public VkFormat format;
    }

    public unsafe partial struct VkIndirectCommandsLayoutPushDataTokenNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint pushDataOffset;

                public uint pushDataSize;
    }

    public unsafe partial struct VkSubsampledImageFormatPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint subsampledImageDescriptorCount;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorHeapTensorPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong tensorDescriptorSize;

                public ulong tensorDescriptorAlignment;

                public nuint tensorCaptureReplayOpaqueDataSize;
    }

    public unsafe partial struct VkAttachmentSampleCountInfoAMD
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint colorAttachmentCount;

                public VkSampleCountFlagBits* pColorAttachmentSamples;

        public VkSampleCountFlagBits depthStencilAttachmentSamples;
    }

    public partial struct VkSampleLocationEXT
    {
        public float x;

        public float y;
    }

    public unsafe partial struct VkSampleLocationsInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkSampleCountFlagBits sampleLocationsPerPixel;

        public VkExtent2D sampleLocationGridSize;

                public uint sampleLocationsCount;

                public VkSampleLocationEXT* pSampleLocations;
    }

    public partial struct VkAttachmentSampleLocationsEXT
    {
                public uint attachmentIndex;

        public VkSampleLocationsInfoEXT sampleLocationsInfo;
    }

    public partial struct VkSubpassSampleLocationsEXT
    {
                public uint subpassIndex;

        public VkSampleLocationsInfoEXT sampleLocationsInfo;
    }

    public unsafe partial struct VkRenderPassSampleLocationsBeginInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint attachmentInitialSampleLocationsCount;

                public VkAttachmentSampleLocationsEXT* pAttachmentInitialSampleLocations;

                public uint postSubpassSampleLocationsCount;

                public VkSubpassSampleLocationsEXT* pPostSubpassSampleLocations;
    }

    public unsafe partial struct VkPipelineSampleLocationsStateCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint sampleLocationsEnable;

        public VkSampleLocationsInfoEXT sampleLocationsInfo;
    }

    public unsafe partial struct VkPhysicalDeviceSampleLocationsPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint sampleLocationSampleCounts;

        public VkExtent2D maxSampleLocationGridSize;

                public _sampleLocationCoordinateRange_e__FixedBuffer sampleLocationCoordinateRange;

                public uint sampleLocationSubPixelBits;

                public uint variableSampleLocations;

        [InlineArray(2)]
        public partial struct _sampleLocationCoordinateRange_e__FixedBuffer
        {
            public float e0;
        }
    }

    public unsafe partial struct VkMultisamplePropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent2D maxSampleLocationGridSize;
    }

    public unsafe partial struct VkPhysicalDeviceBlendOperationAdvancedFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint advancedBlendCoherentOperations;
    }

    public unsafe partial struct VkPhysicalDeviceBlendOperationAdvancedPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint advancedBlendMaxColorAttachments;

                public uint advancedBlendIndependentBlend;

                public uint advancedBlendNonPremultipliedSrcColor;

                public uint advancedBlendNonPremultipliedDstColor;

                public uint advancedBlendCorrelatedOverlap;

                public uint advancedBlendAllOperations;
    }

    public unsafe partial struct VkPipelineColorBlendAdvancedStateCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint srcPremultiplied;

                public uint dstPremultiplied;

        public VkBlendOverlapEXT blendOverlap;
    }

    public unsafe partial struct VkPipelineCoverageToColorStateCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint coverageToColorEnable;

                public uint coverageToColorLocation;
    }

    public unsafe partial struct VkPipelineCoverageModulationStateCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkCoverageModulationModeNV coverageModulationMode;

                public uint coverageModulationTableEnable;

                public uint coverageModulationTableCount;

                public float* pCoverageModulationTable;
    }

    public unsafe partial struct VkPhysicalDeviceShaderSMBuiltinsPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderSMCount;

                public uint shaderWarpsPerSM;
    }

    public unsafe partial struct VkPhysicalDeviceShaderSMBuiltinsFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderSMBuiltins;
    }

    public partial struct VkDrmFormatModifierPropertiesEXT
    {
                public ulong drmFormatModifier;

                public uint drmFormatModifierPlaneCount;

                public uint drmFormatModifierTilingFeatures;
    }

    public unsafe partial struct VkDrmFormatModifierPropertiesListEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint drmFormatModifierCount;

        public VkDrmFormatModifierPropertiesEXT* pDrmFormatModifierProperties;
    }

    public unsafe partial struct VkPhysicalDeviceImageDrmFormatModifierInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong drmFormatModifier;

        public VkSharingMode sharingMode;

                public uint queueFamilyIndexCount;

                public uint* pQueueFamilyIndices;
    }

    public unsafe partial struct VkImageDrmFormatModifierListCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint drmFormatModifierCount;

                public ulong* pDrmFormatModifiers;
    }

    public unsafe partial struct VkImageDrmFormatModifierExplicitCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong drmFormatModifier;

                public uint drmFormatModifierPlaneCount;

                public VkSubresourceLayout* pPlaneLayouts;
    }

    public unsafe partial struct VkImageDrmFormatModifierPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong drmFormatModifier;
    }

    public partial struct VkDrmFormatModifierProperties2EXT
    {
                public ulong drmFormatModifier;

                public uint drmFormatModifierPlaneCount;

                public ulong drmFormatModifierTilingFeatures;
    }

    public unsafe partial struct VkDrmFormatModifierPropertiesList2EXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint drmFormatModifierCount;

        public VkDrmFormatModifierProperties2EXT* pDrmFormatModifierProperties;
    }

    public partial struct VkValidationCacheEXT
    {
    }

    public unsafe partial struct VkValidationCacheCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public nuint initialDataSize;

                public void* pInitialData;
    }

    public unsafe partial struct VkShaderModuleValidationCacheCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkValidationCacheEXT* validationCache;
    }

    public unsafe partial struct VkShadingRatePaletteNV
    {
                public uint shadingRatePaletteEntryCount;

                public VkShadingRatePaletteEntryNV* pShadingRatePaletteEntries;
    }

    public unsafe partial struct VkPipelineViewportShadingRateImageStateCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint shadingRateImageEnable;

                public uint viewportCount;

                public VkShadingRatePaletteNV* pShadingRatePalettes;
    }

    public unsafe partial struct VkPhysicalDeviceShadingRateImageFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shadingRateImage;

                public uint shadingRateCoarseSampleOrder;
    }

    public unsafe partial struct VkPhysicalDeviceShadingRateImagePropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent2D shadingRateTexelSize;

                public uint shadingRatePaletteSize;

                public uint shadingRateMaxCoarseSamples;
    }

    public partial struct VkCoarseSampleLocationNV
    {
                public uint pixelX;

                public uint pixelY;

                public uint sample;
    }

    public unsafe partial struct VkCoarseSampleOrderCustomNV
    {
        public VkShadingRatePaletteEntryNV shadingRate;

                public uint sampleCount;

                public uint sampleLocationCount;

                public VkCoarseSampleLocationNV* pSampleLocations;
    }

    public unsafe partial struct VkPipelineViewportCoarseSampleOrderStateCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkCoarseSampleOrderTypeNV sampleOrderType;

                public uint customSampleOrderCount;

                public VkCoarseSampleOrderCustomNV* pCustomSampleOrders;
    }

    public partial struct VkAccelerationStructureNV
    {
    }

    public unsafe partial struct VkRayTracingShaderGroupCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkRayTracingShaderGroupTypeKHR type;

                public uint generalShader;

                public uint closestHitShader;

                public uint anyHitShader;

                public uint intersectionShader;
    }

    public unsafe partial struct VkRayTracingPipelineCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint stageCount;

                public VkPipelineShaderStageCreateInfo* pStages;

                public uint groupCount;

                public VkRayTracingShaderGroupCreateInfoNV* pGroups;

                public uint maxRecursionDepth;

                public VkPipelineLayout* layout;

                public VkPipeline* basePipelineHandle;

                public int basePipelineIndex;
    }

    public unsafe partial struct VkGeometryTrianglesNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBuffer* vertexData;

                public ulong vertexOffset;

                public uint vertexCount;

                public ulong vertexStride;

        public VkFormat vertexFormat;

                public VkBuffer* indexData;

                public ulong indexOffset;

                public uint indexCount;

        public VkIndexType indexType;

                public VkBuffer* transformData;

                public ulong transformOffset;
    }

    public unsafe partial struct VkGeometryAABBNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBuffer* aabbData;

                public uint numAABBs;

                public uint stride;

                public ulong offset;
    }

    public partial struct VkGeometryDataNV
    {
        public VkGeometryTrianglesNV triangles;

        public VkGeometryAABBNV aabbs;
    }

    public unsafe partial struct VkGeometryNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkGeometryTypeKHR geometryType;

        public VkGeometryDataNV geometry;

                public uint flags;
    }

    public unsafe partial struct VkAccelerationStructureInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkAccelerationStructureTypeKHR type;

                public uint flags;

                public uint instanceCount;

                public uint geometryCount;

                public VkGeometryNV* pGeometries;
    }

    public unsafe partial struct VkAccelerationStructureCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong compactedSize;

        public VkAccelerationStructureInfoNV info;
    }

    public unsafe partial struct VkBindAccelerationStructureMemoryInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkAccelerationStructureNV* accelerationStructure;

                public VkDeviceMemory* memory;

                public ulong memoryOffset;

                public uint deviceIndexCount;

                public uint* pDeviceIndices;
    }

    public unsafe partial struct VkWriteDescriptorSetAccelerationStructureNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint accelerationStructureCount;

                public VkAccelerationStructureNV** pAccelerationStructures;
    }

    public unsafe partial struct VkAccelerationStructureMemoryRequirementsInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkAccelerationStructureMemoryRequirementsTypeNV type;

                public VkAccelerationStructureNV* accelerationStructure;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderGroupHandleSize;

                public uint maxRecursionDepth;

                public uint maxShaderGroupStride;

                public uint shaderGroupBaseAlignment;

                public ulong maxGeometryCount;

                public ulong maxInstanceCount;

                public ulong maxTriangleCount;

                public uint maxDescriptorSetAccelerationStructures;
    }

    public partial struct VkTransformMatrixKHR
    {
                public _matrix_e__FixedBuffer matrix;

        [InlineArray(3 * 4)]
        public partial struct _matrix_e__FixedBuffer
        {
            public float e0_0;
        }
    }

    public partial struct VkAabbPositionsKHR
    {
        public float minX;

        public float minY;

        public float minZ;

        public float maxX;

        public float maxY;

        public float maxZ;
    }

    public partial struct VkAccelerationStructureInstanceKHR
    {
        public VkTransformMatrixKHR transform;

        public uint _bitfield1;

                public uint instanceCustomIndex
        {
            readonly get
            {
                return _bitfield1 & 0xFFFFFFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

                public uint mask
        {
            readonly get
            {
                return (_bitfield1 >> 24) & 0xFFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

        public uint _bitfield2;

                public uint instanceShaderBindingTableRecordOffset
        {
            readonly get
            {
                return _bitfield2 & 0xFFFFFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

                public uint flags
        {
            readonly get
            {
                return (_bitfield2 >> 24) & 0xFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

                public ulong accelerationStructureReference;
    }

    public unsafe partial struct VkPhysicalDeviceRepresentativeFragmentTestFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint representativeFragmentTest;
    }

    public unsafe partial struct VkPipelineRepresentativeFragmentTestStateCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint representativeFragmentTestEnable;
    }

    public unsafe partial struct VkPhysicalDeviceImageViewImageFormatInfoEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkImageViewType imageViewType;
    }

    public unsafe partial struct VkFilterCubicImageViewImageFormatPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint filterCubic;

                public uint filterCubicMinmax;
    }

    public unsafe partial struct VkPhysicalDeviceCooperativeMatrixConversionFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cooperativeMatrixConversion;
    }

    public unsafe partial struct VkPhysicalDeviceElapsedTimerQueryFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint elapsedTimerQuery;
    }

    public unsafe partial struct VkImportMemoryHostPointerInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExternalMemoryHandleTypeFlagBits handleType;

        public void* pHostPointer;
    }

    public unsafe partial struct VkMemoryHostPointerPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint memoryTypeBits;
    }

    public unsafe partial struct VkPhysicalDeviceExternalMemoryHostPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong minImportedHostPointerAlignment;
    }

    public unsafe partial struct VkPipelineCompilerControlCreateInfoAMD
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint compilerControlFlags;
    }

    public unsafe partial struct VkPhysicalDeviceShaderCorePropertiesAMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderEngineCount;

                public uint shaderArraysPerEngineCount;

                public uint computeUnitsPerShaderArray;

                public uint simdPerComputeUnit;

                public uint wavefrontsPerSimd;

                public uint wavefrontSize;

                public uint sgprsPerSimd;

                public uint minSgprAllocation;

                public uint maxSgprAllocation;

                public uint sgprAllocationGranularity;

                public uint vgprsPerSimd;

                public uint minVgprAllocation;

                public uint maxVgprAllocation;

                public uint vgprAllocationGranularity;
    }

    public unsafe partial struct VkDeviceMemoryOverallocationCreateInfoAMD
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkMemoryOverallocationBehaviorAMD overallocationBehavior;
    }

    public unsafe partial struct VkPhysicalDeviceVertexAttributeDivisorPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxVertexAttribDivisor;
    }

    public unsafe partial struct VkPhysicalDeviceMeshShaderFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint taskShader;

                public uint meshShader;
    }

    public unsafe partial struct VkPhysicalDeviceMeshShaderPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxDrawMeshTasksCount;

                public uint maxTaskWorkGroupInvocations;

                public _maxTaskWorkGroupSize_e__FixedBuffer maxTaskWorkGroupSize;

                public uint maxTaskTotalMemorySize;

                public uint maxTaskOutputCount;

                public uint maxMeshWorkGroupInvocations;

                public _maxMeshWorkGroupSize_e__FixedBuffer maxMeshWorkGroupSize;

                public uint maxMeshTotalMemorySize;

                public uint maxMeshOutputVertices;

                public uint maxMeshOutputPrimitives;

                public uint maxMeshMultiviewViewCount;

                public uint meshOutputPerVertexGranularity;

                public uint meshOutputPerPrimitiveGranularity;

        [InlineArray(3)]
        public partial struct _maxTaskWorkGroupSize_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(3)]
        public partial struct _maxMeshWorkGroupSize_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public partial struct VkDrawMeshTasksIndirectCommandNV
    {
                public uint taskCount;

                public uint firstTask;
    }

    public unsafe partial struct VkPhysicalDeviceShaderImageFootprintFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint imageFootprint;
    }

    public unsafe partial struct VkPipelineViewportExclusiveScissorStateCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint exclusiveScissorCount;

                public VkRect2D* pExclusiveScissors;
    }

    public unsafe partial struct VkPhysicalDeviceExclusiveScissorFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint exclusiveScissor;
    }

    public unsafe partial struct VkQueueFamilyCheckpointPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint checkpointExecutionStageMask;
    }

    public unsafe partial struct VkCheckpointDataNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPipelineStageFlagBits stage;

        public void* pCheckpointMarker;
    }

    public unsafe partial struct VkQueueFamilyCheckpointProperties2NV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong checkpointExecutionStageMask;
    }

    public unsafe partial struct VkCheckpointData2NV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong stage;

        public void* pCheckpointMarker;
    }

    public unsafe partial struct VkPhysicalDevicePresentTimingFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentTiming;

                public uint presentAtAbsoluteTime;

                public uint presentAtRelativeTime;
    }

    public unsafe partial struct VkPresentTimingSurfaceCapabilitiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentTimingSupported;

                public uint presentAtAbsoluteTimeSupported;

                public uint presentAtRelativeTimeSupported;

                public uint presentStageQueries;
    }

    public unsafe partial struct VkSwapchainCalibratedTimestampInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSwapchainKHR* swapchain;

                public uint presentStage;

                public ulong timeDomainId;
    }

    public unsafe partial struct VkSwapchainTimingPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong refreshDuration;

                public ulong refreshInterval;
    }

    public unsafe partial struct VkSwapchainTimeDomainPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint timeDomainCount;

        public VkTimeDomainKHR* pTimeDomains;

                public ulong* pTimeDomainIds;
    }

    public unsafe partial struct VkPastPresentationTimingInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public VkSwapchainKHR* swapchain;
    }

    public partial struct VkPresentStageTimeEXT
    {
                public uint stage;

                public ulong time;
    }

    public unsafe partial struct VkPastPresentationTimingEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong presentId;

                public ulong targetTime;

                public uint presentStageCount;

        public VkPresentStageTimeEXT* pPresentStages;

        public VkTimeDomainKHR timeDomain;

                public ulong timeDomainId;

                public uint reportComplete;
    }

    public unsafe partial struct VkPastPresentationTimingPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong timingPropertiesCounter;

                public ulong timeDomainsCounter;

                public uint presentationTimingCount;

        public VkPastPresentationTimingEXT* pPresentationTimings;
    }

    public unsafe partial struct VkPresentTimingInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public ulong targetTime;

                public ulong timeDomainId;

                public uint presentStageQueries;

                public uint targetTimeDomainPresentStage;
    }

    public unsafe partial struct VkPresentTimingsInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint swapchainCount;

                public VkPresentTimingInfoEXT* pTimingInfos;
    }

    public unsafe partial struct VkPhysicalDeviceShaderIntegerFunctions2FeaturesINTEL
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderIntegerFunctions2;
    }

    public partial struct VkPerformanceConfigurationINTEL
    {
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct VkPerformanceValueDataINTEL
    {
        [FieldOffset(0)]
                public uint value32;

        [FieldOffset(0)]
                public ulong value64;

        [FieldOffset(0)]
        public float valueFloat;

        [FieldOffset(0)]
                public uint valueBool;

        [FieldOffset(0)]
                public sbyte* valueString;
    }

    public partial struct VkPerformanceValueINTEL
    {
        public VkPerformanceValueTypeINTEL type;

        public VkPerformanceValueDataINTEL data;
    }

    public unsafe partial struct VkInitializePerformanceApiInfoINTEL
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public void* pUserData;
    }

    public unsafe partial struct VkQueryPoolPerformanceQueryCreateInfoINTEL
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkQueryPoolSamplingModeINTEL performanceCountersSampling;
    }

    public unsafe partial struct VkPerformanceMarkerInfoINTEL
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong marker;
    }

    public unsafe partial struct VkPerformanceStreamMarkerInfoINTEL
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint marker;
    }

    public unsafe partial struct VkPerformanceOverrideInfoINTEL
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkPerformanceOverrideTypeINTEL type;

                public uint enable;

                public ulong parameter;
    }

    public unsafe partial struct VkPerformanceConfigurationAcquireInfoINTEL
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkPerformanceConfigurationTypeINTEL type;
    }

    public unsafe partial struct VkPhysicalDevicePCIBusInfoPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pciDomain;

                public uint pciBus;

                public uint pciDevice;

                public uint pciFunction;
    }

    public unsafe partial struct VkDisplayNativeHdrSurfaceCapabilitiesAMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint localDimmingSupport;
    }

    public unsafe partial struct VkSwapchainDisplayNativeHdrCreateInfoAMD
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint localDimmingEnable;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentDensityMapFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint fragmentDensityMap;

                public uint fragmentDensityMapDynamic;

                public uint fragmentDensityMapNonSubsampledImages;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentDensityMapPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent2D minFragmentDensityTexelSize;

        public VkExtent2D maxFragmentDensityTexelSize;

                public uint fragmentDensityInvocations;
    }

    public unsafe partial struct VkRenderPassFragmentDensityMapCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkAttachmentReference fragmentDensityMapAttachment;
    }

    public unsafe partial struct VkRenderingFragmentDensityMapAttachmentInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImageView* imageView;

        public VkImageLayout imageLayout;
    }

    public unsafe partial struct VkPhysicalDeviceShaderCoreProperties2AMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderCoreFeatures;

                public uint activeComputeUnitCount;
    }

    public unsafe partial struct VkPhysicalDeviceCoherentMemoryFeaturesAMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint deviceCoherentMemory;
    }

    public unsafe partial struct VkPhysicalDeviceShaderImageAtomicInt64FeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderImageInt64Atomics;

                public uint sparseImageInt64Atomics;
    }

    public unsafe partial struct VkPhysicalDeviceMemoryBudgetPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _heapBudget_e__FixedBuffer heapBudget;

                public _heapUsage_e__FixedBuffer heapUsage;

        [InlineArray(16)]
        public partial struct _heapBudget_e__FixedBuffer
        {
            public ulong e0;
        }

        [InlineArray(16)]
        public partial struct _heapUsage_e__FixedBuffer
        {
            public ulong e0;
        }
    }

    public unsafe partial struct VkPhysicalDeviceMemoryPriorityFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint memoryPriority;
    }

    public unsafe partial struct VkMemoryPriorityAllocateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public float priority;
    }

    public unsafe partial struct VkPhysicalDeviceDedicatedAllocationImageAliasingFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint dedicatedAllocationImageAliasing;
    }

    public unsafe partial struct VkPhysicalDeviceBufferDeviceAddressFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint bufferDeviceAddress;

                public uint bufferDeviceAddressCaptureReplay;

                public uint bufferDeviceAddressMultiDevice;
    }

    public unsafe partial struct VkBufferDeviceAddressCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong deviceAddress;
    }

    public unsafe partial struct VkValidationFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint enabledValidationFeatureCount;

                public VkValidationFeatureEnableEXT* pEnabledValidationFeatures;

                public uint disabledValidationFeatureCount;

                public VkValidationFeatureDisableEXT* pDisabledValidationFeatures;
    }

    public unsafe partial struct VkCooperativeMatrixPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint MSize;

                public uint NSize;

                public uint KSize;

                public VkComponentTypeKHR AType;

                public VkComponentTypeKHR BType;

                public VkComponentTypeKHR CType;

                public VkComponentTypeKHR DType;

                public VkScopeKHR scope;
    }

    public unsafe partial struct VkPhysicalDeviceCooperativeMatrixFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cooperativeMatrix;

                public uint cooperativeMatrixRobustBufferAccess;
    }

    public unsafe partial struct VkPhysicalDeviceCooperativeMatrixPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cooperativeMatrixSupportedStages;
    }

    public unsafe partial struct VkPhysicalDeviceCoverageReductionModeFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint coverageReductionMode;
    }

    public unsafe partial struct VkPipelineCoverageReductionStateCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkCoverageReductionModeNV coverageReductionMode;
    }

    public unsafe partial struct VkFramebufferMixedSamplesCombinationNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkCoverageReductionModeNV coverageReductionMode;

        public VkSampleCountFlagBits rasterizationSamples;

                public uint depthStencilSamples;

                public uint colorSamples;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentShaderInterlockFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint fragmentShaderSampleInterlock;

                public uint fragmentShaderPixelInterlock;

                public uint fragmentShaderShadingRateInterlock;
    }

    public unsafe partial struct VkPhysicalDeviceYcbcrImageArraysFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint ycbcrImageArrays;
    }

    public unsafe partial struct VkPhysicalDeviceProvokingVertexFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint provokingVertexLast;

                public uint transformFeedbackPreservesProvokingVertex;
    }

    public unsafe partial struct VkPhysicalDeviceProvokingVertexPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint provokingVertexModePerPipeline;

                public uint transformFeedbackPreservesTriangleFanProvokingVertex;
    }

    public unsafe partial struct VkPipelineRasterizationProvokingVertexStateCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkProvokingVertexModeEXT provokingVertexMode;
    }

    public unsafe partial struct VkHeadlessSurfaceCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkPhysicalDeviceShaderAtomicFloatFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderBufferFloat32Atomics;

                public uint shaderBufferFloat32AtomicAdd;

                public uint shaderBufferFloat64Atomics;

                public uint shaderBufferFloat64AtomicAdd;

                public uint shaderSharedFloat32Atomics;

                public uint shaderSharedFloat32AtomicAdd;

                public uint shaderSharedFloat64Atomics;

                public uint shaderSharedFloat64AtomicAdd;

                public uint shaderImageFloat32Atomics;

                public uint shaderImageFloat32AtomicAdd;

                public uint sparseImageFloat32Atomics;

                public uint sparseImageFloat32AtomicAdd;
    }

    public unsafe partial struct VkPhysicalDeviceExtendedDynamicStateFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint extendedDynamicState;
    }

    public unsafe partial struct VkPhysicalDeviceMapMemoryPlacedFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint memoryMapPlaced;

                public uint memoryMapRangePlaced;

                public uint memoryUnmapReserve;
    }

    public unsafe partial struct VkPhysicalDeviceMapMemoryPlacedPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong minPlacedMemoryMapAlignment;
    }

    public unsafe partial struct VkMemoryMapPlacedInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public void* pPlacedAddress;
    }

    public unsafe partial struct VkPhysicalDeviceShaderAtomicFloat2FeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderBufferFloat16Atomics;

                public uint shaderBufferFloat16AtomicAdd;

                public uint shaderBufferFloat16AtomicMinMax;

                public uint shaderBufferFloat32AtomicMinMax;

                public uint shaderBufferFloat64AtomicMinMax;

                public uint shaderSharedFloat16Atomics;

                public uint shaderSharedFloat16AtomicAdd;

                public uint shaderSharedFloat16AtomicMinMax;

                public uint shaderSharedFloat32AtomicMinMax;

                public uint shaderSharedFloat64AtomicMinMax;

                public uint shaderImageFloat32AtomicMinMax;

                public uint sparseImageFloat32AtomicMinMax;
    }

    public partial struct VkIndirectCommandsLayoutNV
    {
    }

    public unsafe partial struct VkPhysicalDeviceDeviceGeneratedCommandsPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxGraphicsShaderGroupCount;

                public uint maxIndirectSequenceCount;

                public uint maxIndirectCommandsTokenCount;

                public uint maxIndirectCommandsStreamCount;

                public uint maxIndirectCommandsTokenOffset;

                public uint maxIndirectCommandsStreamStride;

                public uint minSequencesCountBufferOffsetAlignment;

                public uint minSequencesIndexBufferOffsetAlignment;

                public uint minIndirectCommandsBufferOffsetAlignment;
    }

    public unsafe partial struct VkPhysicalDeviceDeviceGeneratedCommandsFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint deviceGeneratedCommands;
    }

    public unsafe partial struct VkGraphicsShaderGroupCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stageCount;

                public VkPipelineShaderStageCreateInfo* pStages;

                public VkPipelineVertexInputStateCreateInfo* pVertexInputState;

                public VkPipelineTessellationStateCreateInfo* pTessellationState;
    }

    public unsafe partial struct VkGraphicsPipelineShaderGroupsCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint groupCount;

                public VkGraphicsShaderGroupCreateInfoNV* pGroups;

                public uint pipelineCount;

                public VkPipeline** pPipelines;
    }

    public partial struct VkBindShaderGroupIndirectCommandNV
    {
                public uint groupIndex;
    }

    public partial struct VkBindIndexBufferIndirectCommandNV
    {
                public ulong bufferAddress;

                public uint size;

        public VkIndexType indexType;
    }

    public partial struct VkBindVertexBufferIndirectCommandNV
    {
                public ulong bufferAddress;

                public uint size;

                public uint stride;
    }

    public partial struct VkSetStateFlagsIndirectCommandNV
    {
                public uint data;
    }

    public unsafe partial struct VkIndirectCommandsStreamNV
    {
                public VkBuffer* buffer;

                public ulong offset;
    }

    public unsafe partial struct VkIndirectCommandsLayoutTokenNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkIndirectCommandsTokenTypeNV tokenType;

                public uint stream;

                public uint offset;

                public uint vertexBindingUnit;

                public uint vertexDynamicStride;

                public VkPipelineLayout* pushconstantPipelineLayout;

                public uint pushconstantShaderStageFlags;

                public uint pushconstantOffset;

                public uint pushconstantSize;

                public uint indirectStateFlags;

                public uint indexTypeCount;

                public VkIndexType* pIndexTypes;

                public uint* pIndexTypeValues;
    }

    public unsafe partial struct VkIndirectCommandsLayoutCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkPipelineBindPoint pipelineBindPoint;

                public uint tokenCount;

                public VkIndirectCommandsLayoutTokenNV* pTokens;

                public uint streamCount;

                public uint* pStreamStrides;
    }

    public unsafe partial struct VkGeneratedCommandsInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkPipelineBindPoint pipelineBindPoint;

                public VkPipeline* pipeline;

                public VkIndirectCommandsLayoutNV* indirectCommandsLayout;

                public uint streamCount;

                public VkIndirectCommandsStreamNV* pStreams;

                public uint sequencesCount;

                public VkBuffer* preprocessBuffer;

                public ulong preprocessOffset;

                public ulong preprocessSize;

                public VkBuffer* sequencesCountBuffer;

                public ulong sequencesCountOffset;

                public VkBuffer* sequencesIndexBuffer;

                public ulong sequencesIndexOffset;
    }

    public unsafe partial struct VkGeneratedCommandsMemoryRequirementsInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkPipelineBindPoint pipelineBindPoint;

                public VkPipeline* pipeline;

                public VkIndirectCommandsLayoutNV* indirectCommandsLayout;

                public uint maxSequencesCount;
    }

    public unsafe partial struct VkPhysicalDeviceInheritedViewportScissorFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint inheritedViewportScissor2D;
    }

    public unsafe partial struct VkCommandBufferInheritanceViewportScissorInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint viewportScissor2D;

                public uint viewportDepthCount;

                public VkViewport* pViewportDepths;
    }

    public unsafe partial struct VkPhysicalDeviceTexelBufferAlignmentFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint texelBufferAlignment;
    }

    public unsafe partial struct VkRenderPassTransformBeginInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkSurfaceTransformFlagBitsKHR transform;
    }

    public unsafe partial struct VkCommandBufferInheritanceRenderPassTransformInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkSurfaceTransformFlagBitsKHR transform;

        public VkRect2D renderArea;
    }

    public unsafe partial struct VkPhysicalDeviceDepthBiasControlFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint depthBiasControl;

                public uint leastRepresentableValueForceUnormRepresentation;

                public uint floatRepresentation;

                public uint depthBiasExact;
    }

    public unsafe partial struct VkDepthBiasInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public float depthBiasConstantFactor;

        public float depthBiasClamp;

        public float depthBiasSlopeFactor;
    }

    public unsafe partial struct VkDepthBiasRepresentationInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDepthBiasRepresentationEXT depthBiasRepresentation;

                public uint depthBiasExact;
    }

    public unsafe partial struct VkPhysicalDeviceDeviceMemoryReportFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint deviceMemoryReport;
    }

    public unsafe partial struct VkDeviceMemoryReportCallbackDataEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

        public VkDeviceMemoryReportEventTypeEXT type;

                public ulong memoryObjectId;

                public ulong size;

        public VkObjectType objectType;

                public ulong objectHandle;

                public uint heapIndex;
    }

    public unsafe partial struct VkDeviceDeviceMemoryReportCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public delegate* unmanaged[Cdecl]<VkDeviceMemoryReportCallbackDataEXT*, void*, void> pfnUserCallback;

        public void* pUserData;
    }

    public unsafe partial struct VkPhysicalDeviceCustomBorderColorPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxCustomBorderColorSamplers;
    }

    public unsafe partial struct VkPhysicalDeviceCustomBorderColorFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint customBorderColors;

                public uint customBorderColorWithoutFormat;
    }

    public unsafe partial struct VkPhysicalDeviceTextureCompressionASTC3DFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint textureCompressionASTC_3D;
    }

    public unsafe partial struct VkPhysicalDevicePresentBarrierFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentBarrier;
    }

    public unsafe partial struct VkSurfaceCapabilitiesPresentBarrierNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentBarrierSupported;
    }

    public unsafe partial struct VkSwapchainPresentBarrierCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentBarrierEnable;
    }

    public unsafe partial struct VkPhysicalDeviceDiagnosticsConfigFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint diagnosticsConfig;
    }

    public unsafe partial struct VkDeviceDiagnosticsConfigCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkPerfHintInfoQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPerfHintTypeQCOM type;

                public uint scale;
    }

    public unsafe partial struct VkPhysicalDeviceQueuePerfHintFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint queuePerfHint;
    }

    public unsafe partial struct VkPhysicalDeviceQueuePerfHintPropertiesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint supportedQueues;
    }

    public unsafe partial struct VkPhysicalDeviceImageProcessing3FeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint imageGatherLinear;

                public uint imageGatherExtendedModes;

                public uint blockMatchExtendedClampToEdge;
    }

    public unsafe partial struct VkPhysicalDeviceShaderMultipleWaitQueuesFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderMultipleWaitQueues;
    }

    public unsafe partial struct VkPhysicalDeviceShaderMultipleWaitQueuesPropertiesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxShaderWaitQueues;
    }

    public unsafe partial struct VkPhysicalDeviceShaderSplitBarrierFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderSplitBarrier;
    }

    public unsafe partial struct VkPhysicalDeviceShaderSplitBarrierPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint splitBarrierReservedSharedMemory;
    }

    public unsafe partial struct VkPhysicalDeviceTileShadingFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint tileShading;

                public uint tileShadingFragmentStage;

                public uint tileShadingColorAttachments;

                public uint tileShadingDepthAttachments;

                public uint tileShadingStencilAttachments;

                public uint tileShadingInputAttachments;

                public uint tileShadingSampledAttachments;

                public uint tileShadingPerTileDraw;

                public uint tileShadingPerTileDispatch;

                public uint tileShadingDispatchTile;

                public uint tileShadingApron;

                public uint tileShadingAnisotropicApron;

                public uint tileShadingAtomicOps;

                public uint tileShadingImageProcessing;
    }

    public unsafe partial struct VkPhysicalDeviceTileShadingPropertiesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxApronSize;

                public uint preferNonCoherent;

        public VkExtent2D tileGranularity;

        public VkExtent2D maxTileShadingRate;
    }

    public unsafe partial struct VkRenderPassTileShadingCreateInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkExtent2D tileApronSize;
    }

    public unsafe partial struct VkPerTileBeginInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;
    }

    public unsafe partial struct VkPerTileEndInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;
    }

    public unsafe partial struct VkDispatchTileInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;
    }

    public unsafe partial struct VkQueryLowLatencySupportNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public void* pQueriedLowLatencyData;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorBufferPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint combinedImageSamplerDescriptorSingleArray;

                public uint bufferlessPushDescriptors;

                public uint allowSamplerImageViewPostSubmitCreation;

                public ulong descriptorBufferOffsetAlignment;

                public uint maxDescriptorBufferBindings;

                public uint maxResourceDescriptorBufferBindings;

                public uint maxSamplerDescriptorBufferBindings;

                public uint maxEmbeddedImmutableSamplerBindings;

                public uint maxEmbeddedImmutableSamplers;

                public nuint bufferCaptureReplayDescriptorDataSize;

                public nuint imageCaptureReplayDescriptorDataSize;

                public nuint imageViewCaptureReplayDescriptorDataSize;

                public nuint samplerCaptureReplayDescriptorDataSize;

                public nuint accelerationStructureCaptureReplayDescriptorDataSize;

                public nuint samplerDescriptorSize;

                public nuint combinedImageSamplerDescriptorSize;

                public nuint sampledImageDescriptorSize;

                public nuint storageImageDescriptorSize;

                public nuint uniformTexelBufferDescriptorSize;

                public nuint robustUniformTexelBufferDescriptorSize;

                public nuint storageTexelBufferDescriptorSize;

                public nuint robustStorageTexelBufferDescriptorSize;

                public nuint uniformBufferDescriptorSize;

                public nuint robustUniformBufferDescriptorSize;

                public nuint storageBufferDescriptorSize;

                public nuint robustStorageBufferDescriptorSize;

                public nuint inputAttachmentDescriptorSize;

                public nuint accelerationStructureDescriptorSize;

                public ulong maxSamplerDescriptorBufferRange;

                public ulong maxResourceDescriptorBufferRange;

                public ulong samplerDescriptorBufferAddressSpaceSize;

                public ulong resourceDescriptorBufferAddressSpaceSize;

                public ulong descriptorBufferAddressSpaceSize;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorBufferFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint descriptorBuffer;

                public uint descriptorBufferCaptureReplay;

                public uint descriptorBufferImageLayoutIgnored;

                public uint descriptorBufferPushDescriptors;
    }

    public unsafe partial struct VkDescriptorAddressInfoEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong address;

                public ulong range;

        public VkFormat format;
    }

    public unsafe partial struct VkDescriptorBufferBindingInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong address;

                public uint usage;
    }

    public unsafe partial struct VkDescriptorBufferBindingPushDescriptorBufferHandleEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBuffer* buffer;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct VkDescriptorDataEXT
    {
        [FieldOffset(0)]
                public VkSampler** pSampler;

        [FieldOffset(0)]
                public VkDescriptorImageInfo* pCombinedImageSampler;

        [FieldOffset(0)]
                public VkDescriptorImageInfo* pInputAttachmentImage;

        [FieldOffset(0)]
                public VkDescriptorImageInfo* pSampledImage;

        [FieldOffset(0)]
                public VkDescriptorImageInfo* pStorageImage;

        [FieldOffset(0)]
                public VkDescriptorAddressInfoEXT* pUniformTexelBuffer;

        [FieldOffset(0)]
                public VkDescriptorAddressInfoEXT* pStorageTexelBuffer;

        [FieldOffset(0)]
                public VkDescriptorAddressInfoEXT* pUniformBuffer;

        [FieldOffset(0)]
                public VkDescriptorAddressInfoEXT* pStorageBuffer;

        [FieldOffset(0)]
                public ulong accelerationStructure;
    }

    public unsafe partial struct VkDescriptorGetInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDescriptorType type;

        public VkDescriptorDataEXT data;
    }

    public unsafe partial struct VkBufferCaptureDescriptorDataInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkBuffer* buffer;
    }

    public unsafe partial struct VkImageCaptureDescriptorDataInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* image;
    }

    public unsafe partial struct VkImageViewCaptureDescriptorDataInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImageView* imageView;
    }

    public unsafe partial struct VkSamplerCaptureDescriptorDataInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSampler* sampler;
    }

    public unsafe partial struct VkOpaqueCaptureDescriptorDataCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public void* opaqueCaptureDescriptorData;
    }

    public unsafe partial struct VkAccelerationStructureCaptureDescriptorDataInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkAccelerationStructureKHR* accelerationStructure;

                public VkAccelerationStructureNV* accelerationStructureNV;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorBufferDensityMapPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public nuint combinedImageSamplerDensityMapDescriptorSize;
    }

    public unsafe partial struct VkPhysicalDeviceGraphicsPipelineLibraryFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint graphicsPipelineLibrary;
    }

    public unsafe partial struct VkPhysicalDeviceGraphicsPipelineLibraryPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint graphicsPipelineLibraryFastLinking;

                public uint graphicsPipelineLibraryIndependentInterpolationDecoration;
    }

    public unsafe partial struct VkGraphicsPipelineLibraryCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;
    }

    public unsafe partial struct VkPhysicalDeviceShaderEarlyAndLateFragmentTestsFeaturesAMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderEarlyAndLateFragmentTests;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentShadingRateEnumsFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint fragmentShadingRateEnums;

                public uint supersampleFragmentShadingRates;

                public uint noInvocationFragmentShadingRates;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentShadingRateEnumsPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkSampleCountFlagBits maxFragmentShadingRateInvocationCount;
    }

    public unsafe partial struct VkPipelineFragmentShadingRateEnumStateCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkFragmentShadingRateTypeNV shadingRateType;

        public VkFragmentShadingRateNV shadingRate;

                public _combinerOps_e__FixedBuffer combinerOps;

        [InlineArray(2)]
        public partial struct _combinerOps_e__FixedBuffer
        {
            public VkFragmentShadingRateCombinerOpKHR e0;
        }
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct VkDeviceOrHostAddressConstKHR
    {
        [FieldOffset(0)]
                public ulong deviceAddress;

        [FieldOffset(0)]
                public void* hostAddress;
    }

    public unsafe partial struct VkAccelerationStructureGeometryMotionTrianglesDataNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceOrHostAddressConstKHR vertexData;
    }

    public unsafe partial struct VkAccelerationStructureMotionInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint maxInstances;

                public uint flags;
    }

    public partial struct VkAccelerationStructureMatrixMotionInstanceNV
    {
        public VkTransformMatrixKHR transformT0;

        public VkTransformMatrixKHR transformT1;

        public uint _bitfield1;

                public uint instanceCustomIndex
        {
            readonly get
            {
                return _bitfield1 & 0xFFFFFFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

                public uint mask
        {
            readonly get
            {
                return (_bitfield1 >> 24) & 0xFFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

        public uint _bitfield2;

                public uint instanceShaderBindingTableRecordOffset
        {
            readonly get
            {
                return _bitfield2 & 0xFFFFFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

                public uint flags
        {
            readonly get
            {
                return (_bitfield2 >> 24) & 0xFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

                public ulong accelerationStructureReference;
    }

    public partial struct VkSRTDataNV
    {
        public float sx;

        public float a;

        public float b;

        public float pvx;

        public float sy;

        public float c;

        public float pvy;

        public float sz;

        public float pvz;

        public float qx;

        public float qy;

        public float qz;

        public float qw;

        public float tx;

        public float ty;

        public float tz;
    }

    public partial struct VkAccelerationStructureSRTMotionInstanceNV
    {
        public VkSRTDataNV transformT0;

        public VkSRTDataNV transformT1;

        public uint _bitfield1;

                public uint instanceCustomIndex
        {
            readonly get
            {
                return _bitfield1 & 0xFFFFFFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

                public uint mask
        {
            readonly get
            {
                return (_bitfield1 >> 24) & 0xFFu;
            }

            set
            {
                _bitfield1 = (_bitfield1 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

        public uint _bitfield2;

                public uint instanceShaderBindingTableRecordOffset
        {
            readonly get
            {
                return _bitfield2 & 0xFFFFFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

                public uint flags
        {
            readonly get
            {
                return (_bitfield2 >> 24) & 0xFFu;
            }

            set
            {
                _bitfield2 = (_bitfield2 & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

                public ulong accelerationStructureReference;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct VkAccelerationStructureMotionInstanceDataNV
    {
        [FieldOffset(0)]
        public VkAccelerationStructureInstanceKHR staticInstance;

        [FieldOffset(0)]
        public VkAccelerationStructureMatrixMotionInstanceNV matrixMotionInstance;

        [FieldOffset(0)]
        public VkAccelerationStructureSRTMotionInstanceNV srtMotionInstance;
    }

    public partial struct VkAccelerationStructureMotionInstanceNV
    {
        public VkAccelerationStructureMotionInstanceTypeNV type;

                public uint flags;

        public VkAccelerationStructureMotionInstanceDataNV data;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingMotionBlurFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rayTracingMotionBlur;

                public uint rayTracingMotionBlurPipelineTraceRaysIndirect;
    }

    public unsafe partial struct VkPhysicalDeviceYcbcr2Plane444FormatsFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint ycbcr2plane444Formats;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentDensityMap2FeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint fragmentDensityMapDeferred;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentDensityMap2PropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint subsampledLoads;

                public uint subsampledCoarseReconstructionEarlyAccess;

                public uint maxSubsampledArrayLayers;

                public uint maxDescriptorSetSubsampledSamplers;
    }

    public unsafe partial struct VkCopyCommandTransformInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkSurfaceTransformFlagBitsKHR transform;
    }

    public unsafe partial struct VkPhysicalDeviceImageCompressionControlFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint imageCompressionControl;
    }

    public unsafe partial struct VkImageCompressionControlEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint compressionControlPlaneCount;

                public uint* pFixedRateFlags;
    }

    public unsafe partial struct VkImageCompressionPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint imageCompressionFlags;

                public uint imageCompressionFixedRateFlags;
    }

    public unsafe partial struct VkPhysicalDeviceAttachmentFeedbackLoopLayoutFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint attachmentFeedbackLoopLayout;
    }

    public unsafe partial struct VkPhysicalDevice4444FormatsFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint formatA4R4G4B4;

                public uint formatA4B4G4R4;
    }

    public unsafe partial struct VkPhysicalDeviceFaultFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint deviceFault;

                public uint deviceFaultVendorBinary;
    }

    public unsafe partial struct VkDeviceFaultCountsEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint addressInfoCount;

                public uint vendorInfoCount;

                public ulong vendorBinarySize;
    }

    public unsafe partial struct VkDeviceFaultInfoEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _description_e__FixedBuffer description;

        public VkDeviceFaultAddressInfoKHR* pAddressInfos;

        public VkDeviceFaultVendorInfoKHR* pVendorInfos;

        public void* pVendorBinaryData;

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkPhysicalDeviceRasterizationOrderAttachmentAccessFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rasterizationOrderColorAttachmentAccess;

                public uint rasterizationOrderDepthAttachmentAccess;

                public uint rasterizationOrderStencilAttachmentAccess;
    }

    public unsafe partial struct VkPhysicalDeviceRGBA10X6FormatsFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint formatRgba10x6WithoutYCbCrSampler;
    }

    public unsafe partial struct VkPhysicalDeviceMutableDescriptorTypeFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint mutableDescriptorType;
    }

    public unsafe partial struct VkMutableDescriptorTypeListEXT
    {
                public uint descriptorTypeCount;

                public VkDescriptorType* pDescriptorTypes;
    }

    public unsafe partial struct VkMutableDescriptorTypeCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint mutableDescriptorTypeListCount;

                public VkMutableDescriptorTypeListEXT* pMutableDescriptorTypeLists;
    }

    public unsafe partial struct VkPhysicalDeviceVertexInputDynamicStateFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint vertexInputDynamicState;
    }

    public unsafe partial struct VkVertexInputBindingDescription2EXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint binding;

                public uint stride;

        public VkVertexInputRate inputRate;

                public uint divisor;
    }

    public unsafe partial struct VkVertexInputAttributeDescription2EXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint location;

                public uint binding;

        public VkFormat format;

                public uint offset;
    }

    public unsafe partial struct VkPhysicalDeviceDrmPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint hasPrimary;

                public uint hasRender;

                public long primaryMajor;

                public long primaryMinor;

                public long renderMajor;

                public long renderMinor;
    }

    public unsafe partial struct VkPhysicalDeviceAddressBindingReportFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint reportAddressBinding;
    }

    public unsafe partial struct VkDeviceAddressBindingCallbackDataEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public ulong baseAddress;

                public ulong size;

        public VkDeviceAddressBindingTypeEXT bindingType;
    }

    public unsafe partial struct VkPhysicalDeviceDepthClipControlFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint depthClipControl;
    }

    public unsafe partial struct VkPipelineViewportDepthClipControlCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint negativeOneToOne;
    }

    public unsafe partial struct VkPhysicalDevicePrimitiveTopologyListRestartFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint primitiveTopologyListRestart;

                public uint primitiveTopologyPatchListRestart;
    }

    public unsafe partial struct VkSubpassShadingPipelineCreateInfoHUAWEI
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public VkRenderPass* renderPass;

                public uint subpass;
    }

    public unsafe partial struct VkPhysicalDeviceSubpassShadingFeaturesHUAWEI
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint subpassShading;
    }

    public unsafe partial struct VkPhysicalDeviceSubpassShadingPropertiesHUAWEI
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxSubpassShadingWorkgroupSizeAspectRatio;
    }

    public unsafe partial struct VkPhysicalDeviceInvocationMaskFeaturesHUAWEI
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint invocationMask;
    }

    public unsafe partial struct VkMemoryGetRemoteAddressInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDeviceMemory* memory;

        public VkExternalMemoryHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkPhysicalDeviceExternalMemoryRDMAFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint externalMemoryRDMA;
    }

    public unsafe partial struct VkPipelinePropertiesIdentifierEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _pipelineIdentifier_e__FixedBuffer pipelineIdentifier;

        [InlineArray(16)]
        public partial struct _pipelineIdentifier_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkPhysicalDevicePipelinePropertiesFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelinePropertiesIdentifier;
    }

    public unsafe partial struct VkPhysicalDeviceFrameBoundaryFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint frameBoundary;
    }

    public unsafe partial struct VkFrameBoundaryEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public ulong frameID;

                public uint imageCount;

                public VkImage** pImages;

                public uint bufferCount;

                public VkBuffer** pBuffers;

                public ulong tagName;

                public nuint tagSize;

                public void* pTag;
    }

    public unsafe partial struct VkPhysicalDeviceMultisampledRenderToSingleSampledFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint multisampledRenderToSingleSampled;
    }

    public unsafe partial struct VkSubpassResolvePerformanceQueryEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint optimal;
    }

    public unsafe partial struct VkMultisampledRenderToSingleSampledInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint multisampledRenderToSingleSampledEnable;

        public VkSampleCountFlagBits rasterizationSamples;
    }

    public unsafe partial struct VkPhysicalDeviceExtendedDynamicState2FeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint extendedDynamicState2;

                public uint extendedDynamicState2LogicOp;

                public uint extendedDynamicState2PatchControlPoints;
    }

    public unsafe partial struct VkPhysicalDeviceColorWriteEnableFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint colorWriteEnable;
    }

    public unsafe partial struct VkPipelineColorWriteCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint attachmentCount;

                public uint* pColorWriteEnables;
    }

    public unsafe partial struct VkPhysicalDevicePrimitivesGeneratedQueryFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint primitivesGeneratedQuery;

                public uint primitivesGeneratedQueryWithRasterizerDiscard;

                public uint primitivesGeneratedQueryWithNonZeroStreams;
    }

    public unsafe partial struct VkPhysicalDeviceVideoEncodeRgbConversionFeaturesVALVE
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint videoEncodeRgbConversion;
    }

    public unsafe partial struct VkVideoEncodeRgbConversionCapabilitiesVALVE
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rgbModels;

                public uint rgbRanges;

                public uint xChromaOffsets;

                public uint yChromaOffsets;
    }

    public unsafe partial struct VkVideoEncodeProfileRgbConversionInfoVALVE
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint performEncodeRgbConversion;
    }

    public unsafe partial struct VkVideoEncodeSessionRgbConversionCreateInfoVALVE
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkVideoEncodeRgbModelConversionFlagBitsVALVE rgbModel;

        public VkVideoEncodeRgbRangeCompressionFlagBitsVALVE rgbRange;

        public VkVideoEncodeRgbChromaOffsetFlagBitsVALVE xChromaOffset;

        public VkVideoEncodeRgbChromaOffsetFlagBitsVALVE yChromaOffset;
    }

    public unsafe partial struct VkPhysicalDeviceImageViewMinLodFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint minLod;
    }

    public unsafe partial struct VkImageViewMinLodCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public float minLod;
    }

    public unsafe partial struct VkPhysicalDeviceMultiDrawFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint multiDraw;
    }

    public unsafe partial struct VkPhysicalDeviceMultiDrawPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxMultiDrawCount;
    }

    public partial struct VkMultiDrawInfoEXT
    {
                public uint firstVertex;

                public uint vertexCount;
    }

    public partial struct VkMultiDrawIndexedInfoEXT
    {
                public uint firstIndex;

                public uint indexCount;

                public int vertexOffset;
    }

    public unsafe partial struct VkPhysicalDeviceImage2DViewOf3DFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint image2DViewOf3D;

                public uint sampler2DViewOf3D;
    }

    public unsafe partial struct VkPhysicalDeviceShaderTileImageFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderTileImageColorReadAccess;

                public uint shaderTileImageDepthReadAccess;

                public uint shaderTileImageStencilReadAccess;
    }

    public unsafe partial struct VkPhysicalDeviceShaderTileImagePropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderTileImageCoherentReadAccelerated;

                public uint shaderTileImageReadSampleFromPixelRateInvocation;

                public uint shaderTileImageReadFromHelperInvocation;
    }

    public partial struct VkMicromapEXT
    {
    }

    public partial struct VkMicromapUsageEXT
    {
                public uint count;

                public uint subdivisionLevel;

                public uint format;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct VkDeviceOrHostAddressKHR
    {
        [FieldOffset(0)]
                public ulong deviceAddress;

        [FieldOffset(0)]
        public void* hostAddress;
    }

    public unsafe partial struct VkMicromapBuildInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkMicromapTypeEXT type;

                public uint flags;

        public VkBuildMicromapModeEXT mode;

                public VkMicromapEXT* dstMicromap;

                public uint usageCountsCount;

                public VkMicromapUsageEXT* pUsageCounts;

                public VkMicromapUsageEXT** ppUsageCounts;

        public VkDeviceOrHostAddressConstKHR data;

        public VkDeviceOrHostAddressKHR scratchData;

        public VkDeviceOrHostAddressConstKHR triangleArray;

                public ulong triangleArrayStride;
    }

    public unsafe partial struct VkMicromapCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint createFlags;

                public VkBuffer* buffer;

                public ulong offset;

                public ulong size;

        public VkMicromapTypeEXT type;

                public ulong deviceAddress;
    }

    public unsafe partial struct VkPhysicalDeviceOpacityMicromapFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint micromap;

                public uint micromapCaptureReplay;

                public uint micromapHostCommands;
    }

    public unsafe partial struct VkPhysicalDeviceOpacityMicromapPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxOpacity2StateSubdivisionLevel;

                public uint maxOpacity4StateSubdivisionLevel;
    }

    public unsafe partial struct VkMicromapVersionInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public byte* pVersionData;
    }

    public unsafe partial struct VkCopyMicromapToMemoryInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkMicromapEXT* src;

        public VkDeviceOrHostAddressKHR dst;

        public VkCopyMicromapModeEXT mode;
    }

    public unsafe partial struct VkCopyMemoryToMicromapInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceOrHostAddressConstKHR src;

                public VkMicromapEXT* dst;

        public VkCopyMicromapModeEXT mode;
    }

    public unsafe partial struct VkCopyMicromapInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkMicromapEXT* src;

                public VkMicromapEXT* dst;

        public VkCopyMicromapModeEXT mode;
    }

    public unsafe partial struct VkMicromapBuildSizesInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong micromapSize;

                public ulong buildScratchSize;

                public uint discardable;
    }

    public unsafe partial struct VkAccelerationStructureTrianglesOpacityMicromapEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkIndexType indexType;

        public VkDeviceOrHostAddressConstKHR indexBuffer;

                public ulong indexStride;

                public uint baseTriangle;

                public uint usageCountsCount;

                public VkMicromapUsageEXT* pUsageCounts;

                public VkMicromapUsageEXT** ppUsageCounts;

                public VkMicromapEXT* micromap;
    }

    public unsafe partial struct VkPhysicalDeviceClusterCullingShaderFeaturesHUAWEI
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint clustercullingShader;

                public uint multiviewClusterCullingShader;
    }

    public unsafe partial struct VkPhysicalDeviceClusterCullingShaderPropertiesHUAWEI
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _maxWorkGroupCount_e__FixedBuffer maxWorkGroupCount;

                public _maxWorkGroupSize_e__FixedBuffer maxWorkGroupSize;

                public uint maxOutputClusterCount;

                public ulong indirectBufferOffsetAlignment;

        [InlineArray(3)]
        public partial struct _maxWorkGroupCount_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(3)]
        public partial struct _maxWorkGroupSize_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public unsafe partial struct VkPhysicalDeviceClusterCullingShaderVrsFeaturesHUAWEI
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint clusterShadingRate;
    }

    public unsafe partial struct VkPhysicalDeviceBorderColorSwizzleFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint borderColorSwizzle;

                public uint borderColorSwizzleFromImage;
    }

    public unsafe partial struct VkSamplerBorderColorComponentMappingCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkComponentMapping components;

                public uint srgb;
    }

    public unsafe partial struct VkPhysicalDevicePageableDeviceLocalMemoryFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pageableDeviceLocalMemory;
    }

    public unsafe partial struct VkPhysicalDeviceShaderCorePropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pixelRate;

                public uint texelRate;

                public uint fmaRate;
    }

    public unsafe partial struct VkDeviceQueueShaderCoreControlCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderCoreCount;
    }

    public unsafe partial struct VkPhysicalDeviceSchedulingControlsFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint schedulingControls;
    }

    public unsafe partial struct VkPhysicalDeviceSchedulingControlsPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong schedulingControlsFlags;
    }

    public unsafe partial struct VkDispatchParametersARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint workGroupBatchSize;

                public uint maxQueuedWorkGroupBatches;

                public uint maxWarpsPerShaderCore;
    }

    public unsafe partial struct VkPhysicalDeviceSchedulingControlsDispatchParametersPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint schedulingControlsMaxWarpsCount;

                public uint schedulingControlsMaxQueuedBatchesCount;

                public uint schedulingControlsMaxWorkGroupBatchSize;
    }

    public unsafe partial struct VkPhysicalDeviceImageSlicedViewOf3DFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint imageSlicedViewOf3D;
    }

    public unsafe partial struct VkImageViewSlicedCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint sliceOffset;

                public uint sliceCount;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorSetHostMappingFeaturesVALVE
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint descriptorSetHostMapping;
    }

    public unsafe partial struct VkDescriptorSetBindingReferenceVALVE
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDescriptorSetLayout* descriptorSetLayout;

                public uint binding;
    }

    public unsafe partial struct VkDescriptorSetLayoutHostMappingInfoVALVE
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public nuint descriptorOffset;

                public uint descriptorSize;
    }

    public unsafe partial struct VkPhysicalDeviceNonSeamlessCubeMapFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint nonSeamlessCubeMap;
    }

    public unsafe partial struct VkPhysicalDeviceRenderPassStripedFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint renderPassStriped;
    }

    public unsafe partial struct VkPhysicalDeviceRenderPassStripedPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent2D renderPassStripeGranularity;

                public uint maxRenderPassStripes;
    }

    public unsafe partial struct VkRenderPassStripeInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkRect2D stripeArea;
    }

    public unsafe partial struct VkRenderPassStripeBeginInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stripeInfoCount;

                public VkRenderPassStripeInfoARM* pStripeInfos;
    }

    public unsafe partial struct VkRenderPassStripeSubmitInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint stripeSemaphoreInfoCount;

                public VkSemaphoreSubmitInfo* pStripeSemaphoreInfos;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentDensityMapOffsetFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint fragmentDensityMapOffset;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentDensityMapOffsetPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent2D fragmentDensityOffsetGranularity;
    }

    public unsafe partial struct VkRenderPassFragmentDensityMapOffsetEndInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint fragmentDensityOffsetCount;

                public VkOffset2D* pFragmentDensityOffsets;
    }

    public unsafe partial struct VkPhysicalDeviceCopyMemoryIndirectFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint indirectCopy;
    }

    public partial struct VkDecompressMemoryRegionNV
    {
                public ulong srcAddress;

                public ulong dstAddress;

                public ulong compressedSize;

                public ulong decompressedSize;

                public ulong decompressionMethod;
    }

    public unsafe partial struct VkPhysicalDeviceMemoryDecompressionFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint memoryDecompression;
    }

    public unsafe partial struct VkPhysicalDeviceMemoryDecompressionPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong decompressionMethods;

                public ulong maxDecompressionIndirectCount;
    }

    public unsafe partial struct VkPhysicalDeviceDeviceGeneratedCommandsComputeFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint deviceGeneratedCompute;

                public uint deviceGeneratedComputePipelines;

                public uint deviceGeneratedComputeCaptureReplay;
    }

    public unsafe partial struct VkComputePipelineIndirectBufferInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong deviceAddress;

                public ulong size;

                public ulong pipelineDeviceAddressCaptureReplay;
    }

    public unsafe partial struct VkPipelineIndirectDeviceAddressInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkPipelineBindPoint pipelineBindPoint;

                public VkPipeline* pipeline;
    }

    public partial struct VkBindPipelineIndirectCommandNV
    {
                public ulong pipelineAddress;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingLinearSweptSpheresFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint spheres;

                public uint linearSweptSpheres;
    }

    public unsafe partial struct VkAccelerationStructureGeometryLinearSweptSpheresDataNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkFormat vertexFormat;

        public VkDeviceOrHostAddressConstKHR vertexData;

                public ulong vertexStride;

        public VkFormat radiusFormat;

        public VkDeviceOrHostAddressConstKHR radiusData;

                public ulong radiusStride;

        public VkIndexType indexType;

        public VkDeviceOrHostAddressConstKHR indexData;

                public ulong indexStride;

        public VkRayTracingLssIndexingModeNV indexingMode;

        public VkRayTracingLssPrimitiveEndCapsModeNV endCapsMode;
    }

    public unsafe partial struct VkAccelerationStructureGeometrySpheresDataNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkFormat vertexFormat;

        public VkDeviceOrHostAddressConstKHR vertexData;

                public ulong vertexStride;

        public VkFormat radiusFormat;

        public VkDeviceOrHostAddressConstKHR radiusData;

                public ulong radiusStride;

        public VkIndexType indexType;

        public VkDeviceOrHostAddressConstKHR indexData;

                public ulong indexStride;
    }

    public unsafe partial struct VkPhysicalDeviceLinearColorAttachmentFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint linearColorAttachment;
    }

    public unsafe partial struct VkPhysicalDeviceImageCompressionControlSwapchainFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint imageCompressionControlSwapchain;
    }

    public unsafe partial struct VkImageViewSampleWeightCreateInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkOffset2D filterCenter;

        public VkExtent2D filterSize;

                public uint numPhases;
    }

    public unsafe partial struct VkPhysicalDeviceImageProcessingFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint textureSampleWeighted;

                public uint textureBoxFilter;

                public uint textureBlockMatch;
    }

    public unsafe partial struct VkPhysicalDeviceImageProcessingPropertiesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxWeightFilterPhases;

        public VkExtent2D maxWeightFilterDimension;

        public VkExtent2D maxBlockMatchRegion;

        public VkExtent2D maxBoxFilterBlockSize;
    }

    public unsafe partial struct VkPhysicalDeviceNestedCommandBufferFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint nestedCommandBuffer;

                public uint nestedCommandBufferRendering;

                public uint nestedCommandBufferSimultaneousUse;
    }

    public unsafe partial struct VkPhysicalDeviceNestedCommandBufferPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxCommandBufferNestingLevel;
    }

    public unsafe partial struct VkExternalMemoryAcquireUnmodifiedEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint acquireUnmodifiedMemory;
    }

    public unsafe partial struct VkPhysicalDeviceExtendedDynamicState3FeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint extendedDynamicState3TessellationDomainOrigin;

                public uint extendedDynamicState3DepthClampEnable;

                public uint extendedDynamicState3PolygonMode;

                public uint extendedDynamicState3RasterizationSamples;

                public uint extendedDynamicState3SampleMask;

                public uint extendedDynamicState3AlphaToCoverageEnable;

                public uint extendedDynamicState3AlphaToOneEnable;

                public uint extendedDynamicState3LogicOpEnable;

                public uint extendedDynamicState3ColorBlendEnable;

                public uint extendedDynamicState3ColorBlendEquation;

                public uint extendedDynamicState3ColorWriteMask;

                public uint extendedDynamicState3RasterizationStream;

                public uint extendedDynamicState3ConservativeRasterizationMode;

                public uint extendedDynamicState3ExtraPrimitiveOverestimationSize;

                public uint extendedDynamicState3DepthClipEnable;

                public uint extendedDynamicState3SampleLocationsEnable;

                public uint extendedDynamicState3ColorBlendAdvanced;

                public uint extendedDynamicState3ProvokingVertexMode;

                public uint extendedDynamicState3LineRasterizationMode;

                public uint extendedDynamicState3LineStippleEnable;

                public uint extendedDynamicState3DepthClipNegativeOneToOne;

                public uint extendedDynamicState3ViewportWScalingEnable;

                public uint extendedDynamicState3ViewportSwizzle;

                public uint extendedDynamicState3CoverageToColorEnable;

                public uint extendedDynamicState3CoverageToColorLocation;

                public uint extendedDynamicState3CoverageModulationMode;

                public uint extendedDynamicState3CoverageModulationTableEnable;

                public uint extendedDynamicState3CoverageModulationTable;

                public uint extendedDynamicState3CoverageReductionMode;

                public uint extendedDynamicState3RepresentativeFragmentTestEnable;

                public uint extendedDynamicState3ShadingRateImageEnable;
    }

    public unsafe partial struct VkPhysicalDeviceExtendedDynamicState3PropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint dynamicPrimitiveTopologyUnrestricted;
    }

    public partial struct VkColorBlendEquationEXT
    {
        public VkBlendFactor srcColorBlendFactor;

        public VkBlendFactor dstColorBlendFactor;

        public VkBlendOp colorBlendOp;

        public VkBlendFactor srcAlphaBlendFactor;

        public VkBlendFactor dstAlphaBlendFactor;

        public VkBlendOp alphaBlendOp;
    }

    public partial struct VkColorBlendAdvancedEXT
    {
        public VkBlendOp advancedBlendOp;

                public uint srcPremultiplied;

                public uint dstPremultiplied;

        public VkBlendOverlapEXT blendOverlap;

                public uint clampResults;
    }

    public unsafe partial struct VkPhysicalDeviceSubpassMergeFeedbackFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint subpassMergeFeedback;
    }

    public unsafe partial struct VkRenderPassCreationControlEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint disallowMerging;
    }

    public partial struct VkRenderPassCreationFeedbackInfoEXT
    {
                public uint postMergeSubpassCount;
    }

    public unsafe partial struct VkRenderPassCreationFeedbackCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkRenderPassCreationFeedbackInfoEXT* pRenderPassFeedback;
    }

    public partial struct VkRenderPassSubpassFeedbackInfoEXT
    {
        public VkSubpassMergeStatusEXT subpassMergeStatus;

                public _description_e__FixedBuffer description;

                public uint postMergeIndex;

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkRenderPassSubpassFeedbackCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkRenderPassSubpassFeedbackInfoEXT* pSubpassFeedback;
    }

    public unsafe partial struct VkDirectDriverLoadingInfoLUNARG
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public delegate* unmanaged[Cdecl]<VkInstance*, sbyte*, delegate* unmanaged[Cdecl]<void>> pfnGetInstanceProcAddr;
    }

    public unsafe partial struct VkDirectDriverLoadingListLUNARG
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDirectDriverLoadingModeLUNARG mode;

                public uint driverCount;

                public VkDirectDriverLoadingInfoLUNARG* pDrivers;
    }

    public partial struct VkTensorViewARM
    {
    }

    public unsafe partial struct VkTensorDescriptionARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkTensorTilingARM tiling;

        public VkFormat format;

                public uint dimensionCount;

                public long* pDimensions;

                public long* pStrides;

                public ulong usage;
    }

    public unsafe partial struct VkTensorCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong flags;

                public VkTensorDescriptionARM* pDescription;

        public VkSharingMode sharingMode;

                public uint queueFamilyIndexCount;

                public uint* pQueueFamilyIndices;
    }

    public unsafe partial struct VkTensorMemoryRequirementsInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkTensorARM* tensor;
    }

    public unsafe partial struct VkBindTensorMemoryInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkTensorARM* tensor;

                public VkDeviceMemory* memory;

                public ulong memoryOffset;
    }

    public unsafe partial struct VkWriteDescriptorSetTensorARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint tensorViewCount;

                public VkTensorViewARM** pTensorViews;
    }

    public unsafe partial struct VkTensorFormatPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong optimalTilingTensorFeatures;

                public ulong linearTilingTensorFeatures;
    }

    public unsafe partial struct VkPhysicalDeviceTensorPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxTensorDimensionCount;

                public ulong maxTensorElements;

                public ulong maxPerDimensionTensorElements;

                public long maxTensorStride;

                public ulong maxTensorSize;

                public uint maxTensorShaderAccessArrayLength;

                public uint maxTensorShaderAccessSize;

                public uint maxDescriptorSetStorageTensors;

                public uint maxPerStageDescriptorSetStorageTensors;

                public uint maxDescriptorSetUpdateAfterBindStorageTensors;

                public uint maxPerStageDescriptorUpdateAfterBindStorageTensors;

                public uint shaderStorageTensorArrayNonUniformIndexingNative;

                public uint shaderTensorSupportedStages;
    }

    public unsafe partial struct VkTensorMemoryBarrierARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong srcStageMask;

                public ulong srcAccessMask;

                public ulong dstStageMask;

                public ulong dstAccessMask;

                public uint srcQueueFamilyIndex;

                public uint dstQueueFamilyIndex;

                public VkTensorARM* tensor;
    }

    public unsafe partial struct VkTensorDependencyInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint tensorMemoryBarrierCount;

                public VkTensorMemoryBarrierARM* pTensorMemoryBarriers;
    }

    public unsafe partial struct VkPhysicalDeviceTensorFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint tensorNonPacked;

                public uint shaderTensorAccess;

                public uint shaderStorageTensorArrayDynamicIndexing;

                public uint shaderStorageTensorArrayNonUniformIndexing;

                public uint descriptorBindingStorageTensorUpdateAfterBind;

                public uint tensors;
    }

    public unsafe partial struct VkDeviceTensorMemoryRequirementsARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkTensorCreateInfoARM* pCreateInfo;
    }

    public unsafe partial struct VkTensorCopyARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint dimensionCount;

                public ulong* pSrcOffset;

                public ulong* pDstOffset;

                public ulong* pExtent;
    }

    public unsafe partial struct VkCopyTensorInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkTensorARM* srcTensor;

                public VkTensorARM* dstTensor;

                public uint regionCount;

                public VkTensorCopyARM* pRegions;
    }

    public unsafe partial struct VkMemoryDedicatedAllocateInfoTensorARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkTensorARM* tensor;
    }

    public unsafe partial struct VkPhysicalDeviceExternalTensorInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong flags;

                public VkTensorDescriptionARM* pDescription;

        public VkExternalMemoryHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkExternalTensorPropertiesARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExternalMemoryProperties externalMemoryProperties;
    }

    public unsafe partial struct VkExternalMemoryTensorCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint handleTypes;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorBufferTensorFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint descriptorBufferTensorDescriptors;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorBufferTensorPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public nuint tensorCaptureReplayDescriptorDataSize;

                public nuint tensorViewCaptureReplayDescriptorDataSize;

                public nuint tensorDescriptorSize;
    }

    public unsafe partial struct VkDescriptorGetTensorInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkTensorViewARM* tensorView;
    }

    public unsafe partial struct VkTensorCaptureDescriptorDataInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkTensorARM* tensor;
    }

    public unsafe partial struct VkTensorViewCaptureDescriptorDataInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkTensorViewARM* tensorView;
    }

    public unsafe partial struct VkFrameBoundaryTensorsARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint tensorCount;

                public VkTensorARM** pTensors;
    }

    public unsafe partial struct VkPhysicalDeviceShaderModuleIdentifierFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderModuleIdentifier;
    }

    public unsafe partial struct VkPhysicalDeviceShaderModuleIdentifierPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _shaderModuleIdentifierAlgorithmUUID_e__FixedBuffer shaderModuleIdentifierAlgorithmUUID;

        [InlineArray(16)]
        public partial struct _shaderModuleIdentifierAlgorithmUUID_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkPipelineShaderStageModuleIdentifierCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint identifierSize;

                public byte* pIdentifier;
    }

    public unsafe partial struct VkShaderModuleIdentifierEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint identifierSize;

                public _identifier_e__FixedBuffer identifier;

        [InlineArray(32)]
        public partial struct _identifier_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public partial struct VkOpticalFlowSessionNV
    {
    }

    public unsafe partial struct VkPhysicalDeviceOpticalFlowFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint opticalFlow;
    }

    public unsafe partial struct VkPhysicalDeviceOpticalFlowPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint supportedOutputGridSizes;

                public uint supportedHintGridSizes;

                public uint hintSupported;

                public uint costSupported;

                public uint bidirectionalFlowSupported;

                public uint globalFlowSupported;

                public uint minWidth;

                public uint minHeight;

                public uint maxWidth;

                public uint maxHeight;

                public uint maxNumRegionsOfInterest;
    }

    public unsafe partial struct VkOpticalFlowImageFormatInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint usage;
    }

    public unsafe partial struct VkOpticalFlowImageFormatPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkFormat format;
    }

    public unsafe partial struct VkOpticalFlowSessionCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint width;

                public uint height;

        public VkFormat imageFormat;

        public VkFormat flowVectorFormat;

        public VkFormat costFormat;

                public uint outputGridSize;

                public uint hintGridSize;

        public VkOpticalFlowPerformanceLevelNV performanceLevel;

                public uint flags;
    }

    public unsafe partial struct VkOpticalFlowSessionCreatePrivateDataInfoNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint id;

                public uint size;

                public void* pPrivateData;
    }

    public unsafe partial struct VkOpticalFlowExecuteInfoNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public uint regionCount;

                public VkRect2D* pRegions;
    }

    public unsafe partial struct VkPhysicalDeviceLegacyDitheringFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint legacyDithering;
    }

    public unsafe partial struct VkPhysicalDeviceAntiLagFeaturesAMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint antiLag;
    }

    public unsafe partial struct VkAntiLagPresentationInfoAMD
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkAntiLagStageAMD stage;

                public ulong frameIndex;
    }

    public unsafe partial struct VkAntiLagDataAMD
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkAntiLagModeAMD mode;

                public uint maxFPS;

                public VkAntiLagPresentationInfoAMD* pPresentationInfo;
    }

    public partial struct VkShaderEXT
    {
    }

    public unsafe partial struct VkPhysicalDeviceShaderObjectFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderObject;
    }

    public unsafe partial struct VkPhysicalDeviceShaderObjectPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _shaderBinaryUUID_e__FixedBuffer shaderBinaryUUID;

                public uint shaderBinaryVersion;

        [InlineArray(16)]
        public partial struct _shaderBinaryUUID_e__FixedBuffer
        {
            public byte e0;
        }
    }

    public unsafe partial struct VkShaderCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

        public VkShaderStageFlagBits stage;

                public uint nextStage;

        public VkShaderCodeTypeEXT codeType;

                public nuint codeSize;

                public void* pCode;

                public sbyte* pName;

                public uint setLayoutCount;

                public VkDescriptorSetLayout** pSetLayouts;

                public uint pushConstantRangeCount;

                public VkPushConstantRange* pPushConstantRanges;

                public VkSpecializationInfo* pSpecializationInfo;
    }

    public partial struct VkDepthClampRangeEXT
    {
        public float minDepthClamp;

        public float maxDepthClamp;
    }

    public unsafe partial struct VkPhysicalDeviceTilePropertiesFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint tileProperties;
    }

    public unsafe partial struct VkTilePropertiesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent3D tileSize;

        public VkExtent2D apronSize;

        public VkOffset2D origin;
    }

    public unsafe partial struct VkPhysicalDeviceAmigoProfilingFeaturesSEC
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint amigoProfiling;
    }

    public unsafe partial struct VkAmigoProfilingSubmitInfoSEC
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong firstDrawTimestamp;

                public ulong swapBufferTimestamp;
    }

    public unsafe partial struct VkPhysicalDeviceMultiviewPerViewViewportsFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint multiviewPerViewViewports;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingInvocationReorderPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkRayTracingInvocationReorderModeEXT rayTracingInvocationReorderReorderingHint;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingInvocationReorderFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rayTracingInvocationReorder;
    }

    public unsafe partial struct VkPhysicalDeviceCooperativeVectorPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cooperativeVectorSupportedStages;

                public uint cooperativeVectorTrainingFloat16Accumulation;

                public uint cooperativeVectorTrainingFloat32Accumulation;

                public uint maxCooperativeVectorComponents;
    }

    public unsafe partial struct VkPhysicalDeviceCooperativeVectorFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cooperativeVector;

                public uint cooperativeVectorTraining;
    }

    public unsafe partial struct VkCooperativeVectorPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkComponentTypeKHR inputType;

        public VkComponentTypeKHR inputInterpretation;

        public VkComponentTypeKHR matrixInterpretation;

        public VkComponentTypeKHR biasInterpretation;

        public VkComponentTypeKHR resultType;

                public uint transpose;
    }

    public unsafe partial struct VkConvertCooperativeVectorMatrixInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public nuint srcSize;

        public VkDeviceOrHostAddressConstKHR srcData;

                public nuint* pDstSize;

        public VkDeviceOrHostAddressKHR dstData;

        public VkComponentTypeKHR srcComponentType;

        public VkComponentTypeKHR dstComponentType;

                public uint numRows;

                public uint numColumns;

        public VkCooperativeVectorMatrixLayoutNV srcLayout;

                public nuint srcStride;

        public VkCooperativeVectorMatrixLayoutNV dstLayout;

                public nuint dstStride;
    }

    public unsafe partial struct VkPhysicalDeviceExtendedSparseAddressSpaceFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint extendedSparseAddressSpace;
    }

    public unsafe partial struct VkPhysicalDeviceExtendedSparseAddressSpacePropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong extendedSparseAddressSpaceSize;

                public uint extendedSparseImageUsageFlags;

                public uint extendedSparseBufferUsageFlags;
    }

    public unsafe partial struct VkPhysicalDeviceLegacyVertexAttributesFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint legacyVertexAttributes;
    }

    public unsafe partial struct VkPhysicalDeviceLegacyVertexAttributesPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint nativeUnalignedPerformance;
    }

    public unsafe partial struct VkLayerSettingEXT
    {
                public sbyte* pLayerName;

                public sbyte* pSettingName;

        public VkLayerSettingTypeEXT type;

                public uint valueCount;

                public void* pValues;
    }

    public unsafe partial struct VkLayerSettingsCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint settingCount;

                public VkLayerSettingEXT* pSettings;
    }

    public unsafe partial struct VkPhysicalDeviceShaderCoreBuiltinsFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderCoreBuiltins;
    }

    public unsafe partial struct VkPhysicalDeviceShaderCoreBuiltinsPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong shaderCoreMask;

                public uint shaderCoreCount;

                public uint shaderWarpsPerCore;
    }

    public unsafe partial struct VkPhysicalDevicePipelineLibraryGroupHandlesFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelineLibraryGroupHandles;
    }

    public unsafe partial struct VkPhysicalDeviceDynamicRenderingUnusedAttachmentsFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint dynamicRenderingUnusedAttachments;
    }

    public unsafe partial struct VkLatencySleepModeInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint lowLatencyMode;

                public uint lowLatencyBoost;

                public uint minimumIntervalUs;
    }

    public unsafe partial struct VkLatencySleepInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSemaphore* signalSemaphore;

                public ulong value;
    }

    public unsafe partial struct VkSetLatencyMarkerInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong presentID;

        public VkLatencyMarkerNV marker;
    }

    public unsafe partial struct VkLatencyTimingsFrameReportNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong presentID;

                public ulong inputSampleTimeUs;

                public ulong simStartTimeUs;

                public ulong simEndTimeUs;

                public ulong renderSubmitStartTimeUs;

                public ulong renderSubmitEndTimeUs;

                public ulong presentStartTimeUs;

                public ulong presentEndTimeUs;

                public ulong driverStartTimeUs;

                public ulong driverEndTimeUs;

                public ulong osRenderQueueStartTimeUs;

                public ulong osRenderQueueEndTimeUs;

                public ulong gpuRenderStartTimeUs;

                public ulong gpuRenderEndTimeUs;
    }

    public unsafe partial struct VkGetLatencyMarkerInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint timingCount;

        public VkLatencyTimingsFrameReportNV* pTimings;
    }

    public unsafe partial struct VkLatencySubmissionPresentIdNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong presentID;
    }

    public unsafe partial struct VkSwapchainLatencyCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint latencyModeEnable;
    }

    public unsafe partial struct VkOutOfBandQueueTypeInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkOutOfBandQueueTypeNV queueType;
    }

    public unsafe partial struct VkLatencySurfaceCapabilitiesNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint presentModeCount;

        public VkPresentModeKHR* pPresentModes;
    }

    public partial struct VkDataGraphPipelineSessionARM
    {
    }

    public unsafe partial struct VkPhysicalDeviceDataGraphFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint dataGraph;

                public uint dataGraphUpdateAfterBind;

                public uint dataGraphSpecializationConstants;

                public uint dataGraphDescriptorBuffer;

                public uint dataGraphShaderModule;
    }

    public unsafe partial struct VkDataGraphPipelineConstantARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint id;

                public void* pConstantData;
    }

    public unsafe partial struct VkDataGraphPipelineResourceInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint descriptorSet;

                public uint binding;

                public uint arrayElement;
    }

    public unsafe partial struct VkDataGraphPipelineCompilerControlCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public sbyte* pVendorOptions;
    }

    public unsafe partial struct VkDataGraphPipelineCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong flags;

                public VkPipelineLayout* layout;

                public uint resourceInfoCount;

                public VkDataGraphPipelineResourceInfoARM* pResourceInfos;
    }

    public unsafe partial struct VkDataGraphPipelineShaderModuleCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkShaderModule* module;

                public sbyte* pName;

                public VkSpecializationInfo* pSpecializationInfo;

                public uint constantCount;

                public VkDataGraphPipelineConstantARM* pConstants;
    }

    public unsafe partial struct VkDataGraphPipelineSessionCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong flags;

                public VkPipeline* dataGraphPipeline;
    }

    public unsafe partial struct VkDataGraphPipelineSessionBindPointRequirementsInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDataGraphPipelineSessionARM* session;
    }

    public unsafe partial struct VkDataGraphPipelineSessionBindPointRequirementARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkDataGraphPipelineSessionBindPointARM bindPoint;

        public VkDataGraphPipelineSessionBindPointTypeARM bindPointType;

                public uint numObjects;
    }

    public unsafe partial struct VkDataGraphPipelineSessionMemoryRequirementsInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDataGraphPipelineSessionARM* session;

        public VkDataGraphPipelineSessionBindPointARM bindPoint;

                public uint objectIndex;
    }

    public unsafe partial struct VkBindDataGraphPipelineSessionMemoryInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDataGraphPipelineSessionARM* session;

        public VkDataGraphPipelineSessionBindPointARM bindPoint;

                public uint objectIndex;

                public VkDeviceMemory* memory;

                public ulong memoryOffset;
    }

    public unsafe partial struct VkDataGraphPipelineInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkPipeline* dataGraphPipeline;
    }

    public unsafe partial struct VkDataGraphPipelinePropertyQueryResultARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkDataGraphPipelinePropertyARM property;

                public uint isText;

                public nuint dataSize;

        public void* pData;
    }

    public unsafe partial struct VkDataGraphPipelineIdentifierCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint identifierSize;

                public byte* pIdentifier;
    }

    public unsafe partial struct VkDataGraphPipelineDispatchInfoARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong flags;
    }

    public partial struct VkPhysicalDeviceDataGraphProcessingEngineARM
    {
        public VkPhysicalDeviceDataGraphProcessingEngineTypeARM type;

                public uint isForeign;
    }

    public partial struct VkPhysicalDeviceDataGraphOperationSupportARM
    {
        public VkPhysicalDeviceDataGraphOperationTypeARM operationType;

                public _name_e__FixedBuffer name;

                public uint version;

        [InlineArray(128)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkQueueFamilyDataGraphPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPhysicalDeviceDataGraphProcessingEngineARM engine;

        public VkPhysicalDeviceDataGraphOperationSupportARM operation;
    }

    public unsafe partial struct VkDataGraphProcessingEngineCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint processingEngineCount;

        public VkPhysicalDeviceDataGraphProcessingEngineARM* pProcessingEngines;
    }

    public unsafe partial struct VkPhysicalDeviceQueueFamilyDataGraphProcessingEngineInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint queueFamilyIndex;

        public VkPhysicalDeviceDataGraphProcessingEngineTypeARM engineType;
    }

    public unsafe partial struct VkQueueFamilyDataGraphProcessingEnginePropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint foreignSemaphoreHandleTypes;

                public uint foreignMemoryHandleTypes;
    }

    public unsafe partial struct VkDataGraphPipelineConstantTensorSemiStructuredSparsityInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint dimension;

                public uint zeroCount;

                public uint groupSize;
    }

    public partial struct VkDataGraphTOSANameQualityARM
    {
                public _name_e__FixedBuffer name;

                public uint qualityFlags;

        [InlineArray(128)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkQueueFamilyDataGraphTOSAPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint profileCount;

                public VkDataGraphTOSANameQualityARM* pProfiles;

                public uint extensionCount;

                public VkDataGraphTOSANameQualityARM* pExtensions;

        public VkDataGraphTOSALevelARM level;
    }

    public unsafe partial struct VkPhysicalDeviceMultiviewPerViewRenderAreasFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint multiviewPerViewRenderAreas;
    }

    public unsafe partial struct VkMultiviewPerViewRenderAreasRenderPassBeginInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint perViewRenderAreaCount;

                public VkRect2D* pPerViewRenderAreas;
    }

    public unsafe partial struct VkPhysicalDevicePerStageDescriptorSetFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint perStageDescriptorSet;

                public uint dynamicPipelineLayout;
    }

    public unsafe partial struct VkPhysicalDeviceImageProcessing2FeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint textureBlockMatch2;
    }

    public unsafe partial struct VkPhysicalDeviceImageProcessing2PropertiesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkExtent2D maxBlockMatchWindow;
    }

    public unsafe partial struct VkSamplerBlockMatchWindowCreateInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExtent2D windowExtent;

        public VkBlockMatchWindowCompareModeQCOM windowCompareMode;
    }

    public unsafe partial struct VkPhysicalDeviceCubicWeightsFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint selectableCubicWeights;
    }

    public unsafe partial struct VkSamplerCubicWeightsCreateInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkCubicFilterWeightsQCOM cubicWeights;
    }

    public unsafe partial struct VkBlitImageCubicWeightsInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkCubicFilterWeightsQCOM cubicWeights;
    }

    public unsafe partial struct VkPhysicalDeviceYcbcrDegammaFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint ycbcrDegamma;
    }

    public unsafe partial struct VkSamplerYcbcrConversionYcbcrDegammaCreateInfoQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint enableYDegamma;

                public uint enableCbCrDegamma;
    }

    public unsafe partial struct VkPhysicalDeviceCubicClampFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cubicRangeClamp;
    }

    public unsafe partial struct VkPhysicalDeviceAttachmentFeedbackLoopDynamicStateFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint attachmentFeedbackLoopDynamicState;
    }

    public unsafe partial struct VkPhysicalDeviceLayeredDriverPropertiesMSFT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkLayeredDriverUnderlyingApiMSFT underlyingAPI;
    }

    public unsafe partial struct VkPhysicalDeviceDescriptorPoolOverallocationFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint descriptorPoolOverallocation;
    }

    public unsafe partial struct VkPhysicalDeviceTileMemoryHeapFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint tileMemoryHeap;
    }

    public unsafe partial struct VkPhysicalDeviceTileMemoryHeapPropertiesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint queueSubmitBoundary;

                public uint tileBufferTransfers;
    }

    public unsafe partial struct VkTileMemoryRequirementsQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong size;

                public ulong alignment;
    }

    public unsafe partial struct VkTileMemoryBindInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDeviceMemory* memory;
    }

    public unsafe partial struct VkTileMemorySizeInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong size;
    }

    public partial struct VkDecompressMemoryRegionEXT
    {
                public ulong srcAddress;

                public ulong dstAddress;

                public ulong compressedSize;

                public ulong decompressedSize;
    }

    public unsafe partial struct VkDecompressMemoryInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public ulong decompressionMethod;

                public uint regionCount;

                public VkDecompressMemoryRegionEXT* pRegions;
    }

    public unsafe partial struct VkDisplaySurfaceStereoCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDisplaySurfaceStereoTypeNV stereoType;
    }

    public unsafe partial struct VkDisplayModeStereoPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint hdmi3DSupported;
    }

    public unsafe partial struct VkPhysicalDeviceRawAccessChainsFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderRawAccessChains;
    }

    public partial struct VkExternalComputeQueueNV
    {
    }

    public unsafe partial struct VkExternalComputeQueueDeviceCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint reservedExternalQueues;
    }

    public unsafe partial struct VkExternalComputeQueueCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkQueue* preferredQueue;
    }

    public unsafe partial struct VkExternalComputeQueueDataParamsNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint deviceIndex;
    }

    public unsafe partial struct VkPhysicalDeviceExternalComputeQueuePropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint externalDataSize;

                public uint maxExternalQueues;
    }

    public unsafe partial struct VkPhysicalDeviceCommandBufferInheritanceFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint commandBufferInheritance;
    }

    public unsafe partial struct VkPhysicalDeviceShaderAtomicFloat16VectorFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderFloat16VectorAtomics;
    }

    public unsafe partial struct VkPhysicalDeviceShaderReplicatedCompositesFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderReplicatedComposites;
    }

    public unsafe partial struct VkTensorRollingBackingCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public _wraps_e__FixedBuffer wraps;

        [InlineArray(4)]
        public partial struct _wraps_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public unsafe partial struct VkTensorExplicitTilingFormatPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong brick16TilingTensorFeatures;

                public ulong brick8TilingTensorFeatures;

                public ulong brick4TilingTensorFeatures;

                public ulong blockUTilingTensorFeatures;

                public ulong blockU64kTilingTensorFeatures;
    }

    public unsafe partial struct VkPhysicalDeviceShaderFloat8FeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderFloat8;

                public uint shaderFloat8CooperativeMatrix;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingValidationFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rayTracingValidation;
    }

    public unsafe partial struct VkPhysicalDeviceClusterAccelerationStructureFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint clusterAccelerationStructure;
    }

    public unsafe partial struct VkPhysicalDeviceClusterAccelerationStructurePropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxVerticesPerCluster;

                public uint maxTrianglesPerCluster;

                public uint clusterScratchByteAlignment;

                public uint clusterByteAlignment;

                public uint clusterTemplateByteAlignment;

                public uint clusterBottomLevelByteAlignment;

                public uint clusterTemplateBoundsByteAlignment;

                public uint maxClusterGeometryIndex;
    }

    public unsafe partial struct VkClusterAccelerationStructureClustersBottomLevelInputNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxTotalClusterCount;

                public uint maxClusterCountPerAccelerationStructure;
    }

    public unsafe partial struct VkClusterAccelerationStructureTriangleClusterInputNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkFormat vertexFormat;

                public uint maxGeometryIndexValue;

                public uint maxClusterUniqueGeometryCount;

                public uint maxClusterTriangleCount;

                public uint maxClusterVertexCount;

                public uint maxTotalTriangleCount;

                public uint maxTotalVertexCount;

                public uint minPositionTruncateBitCount;
    }

    public unsafe partial struct VkClusterAccelerationStructureMoveObjectsInputNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkClusterAccelerationStructureTypeNV type;

                public uint noMoveOverlap;

                public ulong maxMovedBytes;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct VkClusterAccelerationStructureOpInputNV
    {
        [FieldOffset(0)]
        public VkClusterAccelerationStructureClustersBottomLevelInputNV* pClustersBottomLevel;

        [FieldOffset(0)]
        public VkClusterAccelerationStructureTriangleClusterInputNV* pTriangleClusters;

        [FieldOffset(0)]
        public VkClusterAccelerationStructureMoveObjectsInputNV* pMoveObjects;
    }

    public unsafe partial struct VkClusterAccelerationStructureInputInfoNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxAccelerationStructureCount;

                public uint flags;

        public VkClusterAccelerationStructureOpTypeNV opType;

        public VkClusterAccelerationStructureOpModeNV opMode;

        public VkClusterAccelerationStructureOpInputNV opInput;
    }

    public partial struct VkStridedDeviceAddressRegionKHR
    {
                public ulong deviceAddress;

                public ulong stride;

                public ulong size;
    }

    public unsafe partial struct VkClusterAccelerationStructureCommandsInfoNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkClusterAccelerationStructureInputInfoNV input;

                public ulong dstImplicitData;

                public ulong scratchData;

        public VkStridedDeviceAddressRegionKHR dstAddressesArray;

        public VkStridedDeviceAddressRegionKHR dstSizesArray;

        public VkStridedDeviceAddressRegionKHR srcInfosArray;

                public ulong srcInfosCount;

                public uint addressResolutionFlags;
    }

    public partial struct VkStridedDeviceAddressNV
    {
                public ulong startAddress;

                public ulong strideInBytes;
    }

    public partial struct VkClusterAccelerationStructureGeometryIndexAndGeometryFlagsNV
    {
        public uint _bitfield;

                public uint geometryIndex
        {
            readonly get
            {
                return _bitfield & 0xFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

                public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 24) & 0x1Fu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1Fu << 24)) | ((value & 0x1Fu) << 24);
            }
        }

                public uint geometryFlags
        {
            readonly get
            {
                return (_bitfield >> 29) & 0x7u;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x7u << 29)) | ((value & 0x7u) << 29);
            }
        }
    }

    public partial struct VkClusterAccelerationStructureMoveObjectsInfoNV
    {
                public ulong srcAccelerationStructure;
    }

    public partial struct VkClusterAccelerationStructureBuildClustersBottomLevelInfoNV
    {
                public uint clusterReferencesCount;

                public uint clusterReferencesStride;

                public ulong clusterReferences;
    }

    public partial struct VkClusterAccelerationStructureBuildTriangleClusterInfoNV
    {
                public uint clusterID;

                public uint clusterFlags;

        public uint _bitfield;

                public uint triangleCount
        {
            readonly get
            {
                return _bitfield & 0x1FFu;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1FFu) | (value & 0x1FFu);
            }
        }

                public uint vertexCount
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1FFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1FFu << 9)) | ((value & 0x1FFu) << 9);
            }
        }

                public uint positionTruncateBitCount
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x3Fu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3Fu << 18)) | ((value & 0x3Fu) << 18);
            }
        }

                public uint indexType
        {
            readonly get
            {
                return (_bitfield >> 24) & 0xFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFu << 24)) | ((value & 0xFu) << 24);
            }
        }

                public uint opacityMicromapIndexType
        {
            readonly get
            {
                return (_bitfield >> 28) & 0xFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFu << 28)) | ((value & 0xFu) << 28);
            }
        }

        public VkClusterAccelerationStructureGeometryIndexAndGeometryFlagsNV baseGeometryIndexAndGeometryFlags;

                public ushort indexBufferStride;

                public ushort vertexBufferStride;

                public ushort geometryIndexAndFlagsBufferStride;

                public ushort opacityMicromapIndexBufferStride;

                public ulong indexBuffer;

                public ulong vertexBuffer;

                public ulong geometryIndexAndFlagsBuffer;

                public ulong opacityMicromapArray;

                public ulong opacityMicromapIndexBuffer;
    }

    public partial struct VkClusterAccelerationStructureBuildTriangleClusterTemplateInfoNV
    {
                public uint clusterID;

                public uint clusterFlags;

        public uint _bitfield;

                public uint triangleCount
        {
            readonly get
            {
                return _bitfield & 0x1FFu;
            }

            set
            {
                _bitfield = (_bitfield & ~0x1FFu) | (value & 0x1FFu);
            }
        }

                public uint vertexCount
        {
            readonly get
            {
                return (_bitfield >> 9) & 0x1FFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x1FFu << 9)) | ((value & 0x1FFu) << 9);
            }
        }

                public uint positionTruncateBitCount
        {
            readonly get
            {
                return (_bitfield >> 18) & 0x3Fu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0x3Fu << 18)) | ((value & 0x3Fu) << 18);
            }
        }

                public uint indexType
        {
            readonly get
            {
                return (_bitfield >> 24) & 0xFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFu << 24)) | ((value & 0xFu) << 24);
            }
        }

                public uint opacityMicromapIndexType
        {
            readonly get
            {
                return (_bitfield >> 28) & 0xFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFu << 28)) | ((value & 0xFu) << 28);
            }
        }

        public VkClusterAccelerationStructureGeometryIndexAndGeometryFlagsNV baseGeometryIndexAndGeometryFlags;

                public ushort indexBufferStride;

                public ushort vertexBufferStride;

                public ushort geometryIndexAndFlagsBufferStride;

                public ushort opacityMicromapIndexBufferStride;

                public ulong indexBuffer;

                public ulong vertexBuffer;

                public ulong geometryIndexAndFlagsBuffer;

                public ulong opacityMicromapArray;

                public ulong opacityMicromapIndexBuffer;

                public ulong instantiationBoundingBoxLimit;
    }

    public partial struct VkClusterAccelerationStructureInstantiateClusterInfoNV
    {
                public uint clusterIdOffset;

        public uint _bitfield;

                public uint geometryIndexOffset
        {
            readonly get
            {
                return _bitfield & 0xFFFFFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~0xFFFFFFu) | (value & 0xFFFFFFu);
            }
        }

                public uint reserved
        {
            readonly get
            {
                return (_bitfield >> 24) & 0xFFu;
            }

            set
            {
                _bitfield = (_bitfield & ~(0xFFu << 24)) | ((value & 0xFFu) << 24);
            }
        }

                public ulong clusterTemplateAddress;

        public VkStridedDeviceAddressNV vertexBuffer;
    }

    public partial struct VkClusterAccelerationStructureGetTemplateIndicesInfoNV
    {
                public ulong clusterTemplateAddress;
    }

    public unsafe partial struct VkAccelerationStructureBuildSizesInfoKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong accelerationStructureSize;

                public ulong updateScratchSize;

                public ulong buildScratchSize;
    }

    public unsafe partial struct VkRayTracingPipelineClusterAccelerationStructureCreateInfoNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint allowClusterAccelerationStructure;
    }

    public unsafe partial struct VkPhysicalDevicePartitionedAccelerationStructureFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint partitionedAccelerationStructure;
    }

    public unsafe partial struct VkPhysicalDevicePartitionedAccelerationStructurePropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxPartitionCount;
    }

    public unsafe partial struct VkPartitionedAccelerationStructureFlagsNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint enablePartitionTranslation;
    }

    public partial struct VkBuildPartitionedAccelerationStructureIndirectCommandNV
    {
        public VkPartitionedAccelerationStructureOpTypeNV opType;

                public uint argCount;

        public VkStridedDeviceAddressNV argData;
    }

    public partial struct VkPartitionedAccelerationStructureWriteInstanceDataNV
    {
        public VkTransformMatrixKHR transform;

                public _explicitAABB_e__FixedBuffer explicitAABB;

                public uint instanceID;

                public uint instanceMask;

                public uint instanceContributionToHitGroupIndex;

                public uint instanceFlags;

                public uint instanceIndex;

                public uint partitionIndex;

                public ulong accelerationStructure;

        [InlineArray(6)]
        public partial struct _explicitAABB_e__FixedBuffer
        {
            public float e0;
        }
    }

    public partial struct VkPartitionedAccelerationStructureUpdateInstanceDataNV
    {
                public uint instanceIndex;

                public uint instanceContributionToHitGroupIndex;

                public ulong accelerationStructure;
    }

    public partial struct VkPartitionedAccelerationStructureWritePartitionTranslationDataNV
    {
                public uint partitionIndex;

                public _partitionTranslation_e__FixedBuffer partitionTranslation;

        [InlineArray(3)]
        public partial struct _partitionTranslation_e__FixedBuffer
        {
            public float e0;
        }
    }

    public unsafe partial struct VkWriteDescriptorSetPartitionedAccelerationStructureNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint accelerationStructureCount;

                public ulong* pAccelerationStructures;
    }

    public unsafe partial struct VkPartitionedAccelerationStructureInstancesInputNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public uint instanceCount;

                public uint maxInstancePerPartitionCount;

                public uint partitionCount;

                public uint maxInstanceInGlobalPartitionCount;
    }

    public unsafe partial struct VkBuildPartitionedAccelerationStructureInfoNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkPartitionedAccelerationStructureInstancesInputNV input;

                public ulong srcAccelerationStructureData;

                public ulong dstAccelerationStructureData;

                public ulong scratchData;

                public ulong srcInfos;

                public ulong srcInfosCount;
    }

    public partial struct VkIndirectExecutionSetEXT
    {
    }

    public partial struct VkIndirectCommandsLayoutEXT
    {
    }

    public unsafe partial struct VkPhysicalDeviceDeviceGeneratedCommandsFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint deviceGeneratedCommands;

                public uint dynamicGeneratedPipelineLayout;
    }

    public unsafe partial struct VkPhysicalDeviceDeviceGeneratedCommandsPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxIndirectPipelineCount;

                public uint maxIndirectShaderObjectCount;

                public uint maxIndirectSequenceCount;

                public uint maxIndirectCommandsTokenCount;

                public uint maxIndirectCommandsTokenOffset;

                public uint maxIndirectCommandsIndirectStride;

                public uint supportedIndirectCommandsInputModes;

                public uint supportedIndirectCommandsShaderStages;

                public uint supportedIndirectCommandsShaderStagesPipelineBinding;

                public uint supportedIndirectCommandsShaderStagesShaderBinding;

                public uint deviceGeneratedCommandsTransformFeedback;

                public uint deviceGeneratedCommandsMultiDrawIndirectCount;
    }

    public unsafe partial struct VkGeneratedCommandsMemoryRequirementsInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkIndirectExecutionSetEXT* indirectExecutionSet;

                public VkIndirectCommandsLayoutEXT* indirectCommandsLayout;

                public uint maxSequenceCount;

                public uint maxDrawCount;
    }

    public unsafe partial struct VkIndirectExecutionSetPipelineInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkPipeline* initialPipeline;

                public uint maxPipelineCount;
    }

    public unsafe partial struct VkIndirectExecutionSetShaderLayoutInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint setLayoutCount;

                public VkDescriptorSetLayout** pSetLayouts;
    }

    public unsafe partial struct VkIndirectExecutionSetShaderInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint shaderCount;

                public VkShaderEXT** pInitialShaders;

                public VkIndirectExecutionSetShaderLayoutInfoEXT* pSetLayoutInfos;

                public uint maxShaderCount;

                public uint pushConstantRangeCount;

                public VkPushConstantRange* pPushConstantRanges;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct VkIndirectExecutionSetInfoEXT
    {
        [FieldOffset(0)]
                public VkIndirectExecutionSetPipelineInfoEXT* pPipelineInfo;

        [FieldOffset(0)]
                public VkIndirectExecutionSetShaderInfoEXT* pShaderInfo;
    }

    public unsafe partial struct VkIndirectExecutionSetCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkIndirectExecutionSetInfoTypeEXT type;

        public VkIndirectExecutionSetInfoEXT info;
    }

    public unsafe partial struct VkGeneratedCommandsInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint shaderStages;

                public VkIndirectExecutionSetEXT* indirectExecutionSet;

                public VkIndirectCommandsLayoutEXT* indirectCommandsLayout;

                public ulong indirectAddress;

                public ulong indirectAddressSize;

                public ulong preprocessAddress;

                public ulong preprocessSize;

                public uint maxSequenceCount;

                public ulong sequenceCountAddress;

                public uint maxDrawCount;
    }

    public unsafe partial struct VkWriteIndirectExecutionSetPipelineEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint index;

                public VkPipeline* pipeline;
    }

    public partial struct VkIndirectCommandsPushConstantTokenEXT
    {
        public VkPushConstantRange updateRange;
    }

    public partial struct VkIndirectCommandsVertexBufferTokenEXT
    {
                public uint vertexBindingUnit;
    }

    public partial struct VkIndirectCommandsIndexBufferTokenEXT
    {
        public VkIndirectCommandsInputModeFlagBitsEXT mode;
    }

    public partial struct VkIndirectCommandsExecutionSetTokenEXT
    {
        public VkIndirectExecutionSetInfoTypeEXT type;

                public uint shaderStages;
    }

    [StructLayout(LayoutKind.Explicit)]
    public unsafe partial struct VkIndirectCommandsTokenDataEXT
    {
        [FieldOffset(0)]
                public VkIndirectCommandsPushConstantTokenEXT* pPushConstant;

        [FieldOffset(0)]
                public VkIndirectCommandsVertexBufferTokenEXT* pVertexBuffer;

        [FieldOffset(0)]
                public VkIndirectCommandsIndexBufferTokenEXT* pIndexBuffer;

        [FieldOffset(0)]
                public VkIndirectCommandsExecutionSetTokenEXT* pExecutionSet;
    }

    public unsafe partial struct VkIndirectCommandsLayoutTokenEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkIndirectCommandsTokenTypeEXT type;

        public VkIndirectCommandsTokenDataEXT data;

                public uint offset;
    }

    public unsafe partial struct VkIndirectCommandsLayoutCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint shaderStages;

                public uint indirectStride;

                public VkPipelineLayout* pipelineLayout;

                public uint tokenCount;

                public VkIndirectCommandsLayoutTokenEXT* pTokens;
    }

    public partial struct VkDrawIndirectCountIndirectCommandEXT
    {
                public ulong bufferAddress;

                public uint stride;

                public uint commandCount;
    }

    public partial struct VkBindVertexBufferIndirectCommandEXT
    {
                public ulong bufferAddress;

                public uint size;

                public uint stride;
    }

    public partial struct VkBindIndexBufferIndirectCommandEXT
    {
                public ulong bufferAddress;

                public uint size;

        public VkIndexType indexType;
    }

    public unsafe partial struct VkGeneratedCommandsPipelineInfoEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public VkPipeline* pipeline;
    }

    public unsafe partial struct VkGeneratedCommandsShaderInfoEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderCount;

                public VkShaderEXT** pShaders;
    }

    public unsafe partial struct VkWriteIndirectExecutionSetShaderEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint index;

                public VkShaderEXT* shader;
    }

    public unsafe partial struct VkPhysicalDeviceImageAlignmentControlFeaturesMESA
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint imageAlignmentControl;
    }

    public unsafe partial struct VkPhysicalDeviceImageAlignmentControlPropertiesMESA
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint supportedImageAlignmentMask;
    }

    public unsafe partial struct VkImageAlignmentControlCreateInfoMESA
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint maximumRequestedAlignment;
    }

    public unsafe partial struct VkPushConstantBankInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint bank;
    }

    public unsafe partial struct VkPhysicalDevicePushConstantBankFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pushConstantBank;
    }

    public unsafe partial struct VkPhysicalDevicePushConstantBankPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxGraphicsPushConstantBanks;

                public uint maxComputePushConstantBanks;

                public uint maxGraphicsPushDataBanks;

                public uint maxComputePushDataBanks;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingInvocationReorderPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkRayTracingInvocationReorderModeEXT rayTracingInvocationReorderReorderingHint;

                public uint maxShaderBindingTableRecordIndex;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingInvocationReorderFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rayTracingInvocationReorder;
    }

    public unsafe partial struct VkPhysicalDeviceDepthClampControlFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint depthClampControl;
    }

    public unsafe partial struct VkPipelineViewportDepthClampControlCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDepthClampModeEXT depthClampMode;

                public VkDepthClampRangeEXT* pDepthClampRange;
    }

    public unsafe partial struct VkPhysicalDeviceHdrVividFeaturesHUAWEI
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint hdrVivid;
    }

    public unsafe partial struct VkHdrVividDynamicMetadataHUAWEI
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public nuint dynamicMetadataSize;

                public void* pDynamicMetadata;
    }

    public unsafe partial struct VkCooperativeMatrixFlexibleDimensionsPropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint MGranularity;

                public uint NGranularity;

                public uint KGranularity;

        public VkComponentTypeKHR AType;

        public VkComponentTypeKHR BType;

        public VkComponentTypeKHR CType;

        public VkComponentTypeKHR ResultType;

                public uint saturatingAccumulation;

        public VkScopeKHR scope;

                public uint workgroupInvocations;
    }

    public unsafe partial struct VkPhysicalDeviceCooperativeMatrix2FeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cooperativeMatrixWorkgroupScope;

                public uint cooperativeMatrixFlexibleDimensions;

                public uint cooperativeMatrixReductions;

                public uint cooperativeMatrixConversions;

                public uint cooperativeMatrixPerElementOperations;

                public uint cooperativeMatrixTensorAddressing;

                public uint cooperativeMatrixBlockLoads;
    }

    public unsafe partial struct VkPhysicalDeviceCooperativeMatrix2PropertiesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cooperativeMatrixWorkgroupScopeMaxWorkgroupSize;

                public uint cooperativeMatrixFlexibleDimensionsMaxDimension;

                public uint cooperativeMatrixWorkgroupScopeReservedSharedMemory;
    }

    public unsafe partial struct VkPhysicalDevicePipelineOpacityMicromapFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelineOpacityMicromap;
    }

    public unsafe partial struct VkPhysicalDevicePerformanceCountersByRegionFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint performanceCountersByRegion;
    }

    public unsafe partial struct VkPhysicalDevicePerformanceCountersByRegionPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxPerRegionPerformanceCounters;

        public VkExtent2D performanceCounterRegionSize;

                public uint rowStrideAlignment;

                public uint regionAlignment;

                public uint identityTransformOrder;
    }

    public unsafe partial struct VkPerformanceCounterARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint counterID;
    }

    public unsafe partial struct VkPerformanceCounterDescriptionARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public _name_e__FixedBuffer name;

        [InlineArray(256)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public unsafe partial struct VkRenderPassPerformanceCountersByRegionBeginInfoARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint counterAddressCount;

                public ulong* pCounterAddresses;

                public uint serializeRegions;

                public uint counterIndexCount;

                public uint* pCounterIndices;
    }

    public partial struct VkShaderInstrumentationARM
    {
    }

    public unsafe partial struct VkPhysicalDeviceShaderInstrumentationFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderInstrumentation;
    }

    public unsafe partial struct VkPhysicalDeviceShaderInstrumentationPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint numMetrics;

                public uint perBasicBlockGranularity;
    }

    public unsafe partial struct VkShaderInstrumentationCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;
    }

    public unsafe partial struct VkShaderInstrumentationMetricDescriptionARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public _name_e__FixedBuffer name;

                public _description_e__FixedBuffer description;

        [InlineArray(256)]
        public partial struct _name_e__FixedBuffer
        {
            public sbyte e0;
        }

        [InlineArray(256)]
        public partial struct _description_e__FixedBuffer
        {
            public sbyte e0;
        }
    }

    public partial struct VkShaderInstrumentationMetricDataHeaderARM
    {
                public uint resultIndex;

                public uint resultSubIndex;

                public uint stages;

                public uint basicBlockIndex;
    }

    public unsafe partial struct VkPhysicalDeviceVertexAttributeRobustnessFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint vertexAttributeRobustness;
    }

    public unsafe partial struct VkPhysicalDeviceFormatPackFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint formatPack;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentDensityMapLayeredFeaturesVALVE
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint fragmentDensityMapLayered;
    }

    public unsafe partial struct VkPhysicalDeviceFragmentDensityMapLayeredPropertiesVALVE
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxFragmentDensityMapLayers;
    }

    public unsafe partial struct VkPipelineFragmentDensityMapLayeredCreateInfoVALVE
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint maxFragmentDensityMapLayers;
    }

    public unsafe partial struct VkSetPresentConfigNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint numFramesPerBatch;

                public uint presentConfigFeedback;
    }

    public unsafe partial struct VkPhysicalDevicePresentMeteringFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint presentMetering;
    }

    public unsafe partial struct VkPhysicalDeviceMultisampledRenderToSwapchainFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint multisampledRenderToSwapchain;
    }

    public unsafe partial struct VkSwapchainFlagsSurfaceCapabilitiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint swapchainSupportedFlags;
    }

    public unsafe partial struct VkPhysicalDeviceZeroInitializeDeviceMemoryFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint zeroInitializeDeviceMemory;
    }

    public unsafe partial struct VkPhysicalDeviceShader64BitIndexingFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shader64BitIndexing;
    }

    public unsafe partial struct VkPhysicalDeviceCustomResolveFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint customResolve;
    }

    public unsafe partial struct VkBeginCustomResolveInfoEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;
    }

    public unsafe partial struct VkCustomResolveCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint customResolve;

                public uint colorAttachmentCount;

                public VkFormat* pColorAttachmentFormats;

        public VkFormat depthAttachmentFormat;

        public VkFormat stencilAttachmentFormat;
    }

    public partial struct VkPipelineCacheHeaderVersionDataGraphQCOM
    {
                public uint headerSize;

        public VkPipelineCacheHeaderVersion headerVersion;

        public VkDataGraphModelCacheTypeQCOM cacheType;

                public uint cacheVersion;

                public _toolchainVersion_e__FixedBuffer toolchainVersion;

        [InlineArray(3)]
        public partial struct _toolchainVersion_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public unsafe partial struct VkDataGraphPipelineBuiltinModelCreateInfoQCOM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkPhysicalDeviceDataGraphOperationSupportARM* pOperation;
    }

    public unsafe partial struct VkPhysicalDeviceDataGraphModelFeaturesQCOM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint dataGraphModel;
    }

    public unsafe partial struct VkPhysicalDeviceDataGraphOpticalFlowFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint dataGraphOpticalFlow;
    }

    public unsafe partial struct VkQueueFamilyDataGraphOpticalFlowPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint supportedOutputGridSizes;

                public uint supportedHintGridSizes;

                public uint hintSupported;

                public uint costSupported;

                public uint minWidth;

                public uint minHeight;

                public uint maxWidth;

                public uint maxHeight;
    }

    public unsafe partial struct VkDataGraphPipelineOpticalFlowCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint width;

                public uint height;

        public VkFormat imageFormat;

        public VkFormat flowVectorFormat;

        public VkFormat costFormat;

                public uint outputGridSize;

                public uint hintGridSize;

        public VkDataGraphOpticalFlowPerformanceLevelARM performanceLevel;

                public uint flags;
    }

    public unsafe partial struct VkDataGraphOpticalFlowImageFormatPropertiesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkFormat format;
    }

    public unsafe partial struct VkDataGraphOpticalFlowImageFormatInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint usage;
    }

    public unsafe partial struct VkDataGraphPipelineOpticalFlowDispatchInfoARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint flags;

                public uint meanFlowL1NormHint;
    }

    public unsafe partial struct VkDataGraphPipelineResourceInfoImageLayoutARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkImageLayout layout;
    }

    public unsafe partial struct VkDataGraphPipelineSingleNodeConnectionARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint set;

                public uint binding;

        public VkDataGraphPipelineNodeConnectionTypeARM connection;
    }

    public unsafe partial struct VkDataGraphPipelineSingleNodeCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkDataGraphPipelineNodeTypeARM nodeType;

                public uint connectionCount;

                public VkDataGraphPipelineSingleNodeConnectionARM* pConnections;
    }

    public unsafe partial struct VkPhysicalDeviceShaderLongVectorFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint longVector;
    }

    public unsafe partial struct VkPhysicalDeviceShaderLongVectorPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxVectorComponents;
    }

    public unsafe partial struct VkPhysicalDevicePipelineCacheIncrementalModeFeaturesSEC
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint pipelineCacheIncrementalMode;
    }

    public unsafe partial struct VkPhysicalDeviceShaderUniformBufferUnsizedArrayFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderUniformBufferUnsizedArray;
    }

    public unsafe partial struct VkComputeOccupancyPriorityParametersNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public float occupancyPriority;

        public float occupancyThrottling;
    }

    public unsafe partial struct VkPhysicalDeviceComputeOccupancyPriorityFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint computeOccupancyPriority;
    }

    public unsafe partial struct VkPhysicalDeviceShaderSubgroupPartitionedFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderSubgroupPartitioned;
    }

    public unsafe partial struct VkPhysicalDeviceShaderOCPMicroscalingTypesFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderFloat4;

                public uint shaderFloat6;

                public uint shaderFloat8UnsignedE8M0;

                public uint shaderMXInt8;
    }

    public unsafe partial struct VkPhysicalDeviceShaderMixedFloatDotProductFeaturesVALVE
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderMixedFloatDotProductFloat16AccFloat32;

                public uint shaderMixedFloatDotProductFloat16AccFloat16;

                public uint shaderMixedFloatDotProductBFloat16Acc;

                public uint shaderMixedFloatDotProductFloat8AccFloat32;
    }

    public unsafe partial struct VkThrottleHintSubmitInfoSEC
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkThrottleHintTypeSEC throttleHint;
    }

    public unsafe partial struct VkPhysicalDeviceThrottleHintFeaturesSEC
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint throttleHint;
    }

    public unsafe partial struct VkPhysicalDeviceDataGraphNeuralAcceleratorStatisticsFeaturesARM
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint dataGraphNeuralAcceleratorStatistics;
    }

    public unsafe partial struct VkDataGraphPipelineNeuralStatisticsCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint allowNeuralStatistics;
    }

    public unsafe partial struct VkDataGraphPipelineSessionNeuralStatisticsCreateInfoARM
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkNeuralAcceleratorStatisticsModeARM mode;
    }

    public unsafe partial struct VkPhysicalDevicePrimitiveRestartIndexFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint primitiveRestartIndex;
    }

    public unsafe partial struct VkPhysicalDeviceImageTilingControlFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint imageTilingControl;
    }

    public unsafe partial struct VkImageTilingControlCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkImageTilingControlEXT tilingControl;
    }

    public unsafe partial struct VkPhysicalDeviceCooperativeMatrixDecodeVectorFeaturesNV
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint cooperativeMatrixDecodeVector;
    }

    public partial struct VkAccelerationStructureBuildRangeInfoKHR
    {
                public uint primitiveCount;

                public uint primitiveOffset;

                public uint firstVertex;

                public uint transformOffset;
    }

    public unsafe partial struct VkAccelerationStructureGeometryTrianglesDataKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkFormat vertexFormat;

        public VkDeviceOrHostAddressConstKHR vertexData;

                public ulong vertexStride;

                public uint maxVertex;

        public VkIndexType indexType;

        public VkDeviceOrHostAddressConstKHR indexData;

        public VkDeviceOrHostAddressConstKHR transformData;
    }

    public unsafe partial struct VkAccelerationStructureGeometryAabbsDataKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceOrHostAddressConstKHR data;

                public ulong stride;
    }

    public unsafe partial struct VkAccelerationStructureGeometryInstancesDataKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint arrayOfPointers;

        public VkDeviceOrHostAddressConstKHR data;
    }

    [StructLayout(LayoutKind.Explicit)]
    public partial struct VkAccelerationStructureGeometryDataKHR
    {
        [FieldOffset(0)]
        public VkAccelerationStructureGeometryTrianglesDataKHR triangles;

        [FieldOffset(0)]
        public VkAccelerationStructureGeometryAabbsDataKHR aabbs;

        [FieldOffset(0)]
        public VkAccelerationStructureGeometryInstancesDataKHR instances;
    }

    public unsafe partial struct VkAccelerationStructureGeometryKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkGeometryTypeKHR geometryType;

        public VkAccelerationStructureGeometryDataKHR geometry;

                public uint flags;
    }

    public unsafe partial struct VkAccelerationStructureBuildGeometryInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkAccelerationStructureTypeKHR type;

                public uint flags;

        public VkBuildAccelerationStructureModeKHR mode;

                public VkAccelerationStructureKHR* srcAccelerationStructure;

                public VkAccelerationStructureKHR* dstAccelerationStructure;

                public uint geometryCount;

                public VkAccelerationStructureGeometryKHR* pGeometries;

                public VkAccelerationStructureGeometryKHR** ppGeometries;

        public VkDeviceOrHostAddressKHR scratchData;
    }

    public unsafe partial struct VkAccelerationStructureCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint createFlags;

                public VkBuffer* buffer;

                public ulong offset;

                public ulong size;

        public VkAccelerationStructureTypeKHR type;

                public ulong deviceAddress;
    }

    public unsafe partial struct VkWriteDescriptorSetAccelerationStructureKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint accelerationStructureCount;

                public VkAccelerationStructureKHR** pAccelerationStructures;
    }

    public unsafe partial struct VkPhysicalDeviceAccelerationStructureFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint accelerationStructure;

                public uint accelerationStructureCaptureReplay;

                public uint accelerationStructureIndirectBuild;

                public uint accelerationStructureHostCommands;

                public uint descriptorBindingAccelerationStructureUpdateAfterBind;
    }

    public unsafe partial struct VkPhysicalDeviceAccelerationStructurePropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public ulong maxGeometryCount;

                public ulong maxInstanceCount;

                public ulong maxPrimitiveCount;

                public uint maxPerStageDescriptorAccelerationStructures;

                public uint maxPerStageDescriptorUpdateAfterBindAccelerationStructures;

                public uint maxDescriptorSetAccelerationStructures;

                public uint maxDescriptorSetUpdateAfterBindAccelerationStructures;

                public uint minAccelerationStructureScratchOffsetAlignment;
    }

    public unsafe partial struct VkAccelerationStructureDeviceAddressInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkAccelerationStructureKHR* accelerationStructure;
    }

    public unsafe partial struct VkAccelerationStructureVersionInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public byte* pVersionData;
    }

    public unsafe partial struct VkCopyAccelerationStructureToMemoryInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkAccelerationStructureKHR* src;

        public VkDeviceOrHostAddressKHR dst;

        public VkCopyAccelerationStructureModeKHR mode;
    }

    public unsafe partial struct VkCopyMemoryToAccelerationStructureInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkDeviceOrHostAddressConstKHR src;

                public VkAccelerationStructureKHR* dst;

        public VkCopyAccelerationStructureModeKHR mode;
    }

    public unsafe partial struct VkCopyAccelerationStructureInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkAccelerationStructureKHR* src;

                public VkAccelerationStructureKHR* dst;

        public VkCopyAccelerationStructureModeKHR mode;
    }

    public unsafe partial struct VkRayTracingShaderGroupCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkRayTracingShaderGroupTypeKHR type;

                public uint generalShader;

                public uint closestHitShader;

                public uint anyHitShader;

                public uint intersectionShader;

                public void* pShaderGroupCaptureReplayHandle;
    }

    public unsafe partial struct VkRayTracingPipelineInterfaceCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint maxPipelineRayPayloadSize;

                public uint maxPipelineRayHitAttributeSize;
    }

    public unsafe partial struct VkRayTracingPipelineCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public uint stageCount;

                public VkPipelineShaderStageCreateInfo* pStages;

                public uint groupCount;

                public VkRayTracingShaderGroupCreateInfoKHR* pGroups;

                public uint maxPipelineRayRecursionDepth;

                public VkPipelineLibraryCreateInfoKHR* pLibraryInfo;

                public VkRayTracingPipelineInterfaceCreateInfoKHR* pLibraryInterface;

                public VkPipelineDynamicStateCreateInfo* pDynamicState;

                public VkPipelineLayout* layout;

                public VkPipeline* basePipelineHandle;

                public int basePipelineIndex;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingPipelineFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rayTracingPipeline;

                public uint rayTracingPipelineShaderGroupHandleCaptureReplay;

                public uint rayTracingPipelineShaderGroupHandleCaptureReplayMixed;

                public uint rayTracingPipelineTraceRaysIndirect;

                public uint rayTraversalPrimitiveCulling;
    }

    public unsafe partial struct VkPhysicalDeviceRayTracingPipelinePropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint shaderGroupHandleSize;

                public uint maxRayRecursionDepth;

                public uint maxShaderGroupStride;

                public uint shaderGroupBaseAlignment;

                public uint shaderGroupHandleCaptureReplaySize;

                public uint maxRayDispatchInvocationCount;

                public uint shaderGroupHandleAlignment;

                public uint maxRayHitAttributeSize;
    }

    public partial struct VkTraceRaysIndirectCommandKHR
    {
                public uint width;

                public uint height;

                public uint depth;
    }

    public unsafe partial struct VkPhysicalDeviceRayQueryFeaturesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint rayQuery;
    }

    public unsafe partial struct VkPhysicalDeviceMeshShaderFeaturesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint taskShader;

                public uint meshShader;

                public uint multiviewMeshShader;

                public uint primitiveFragmentShadingRateMeshShader;

                public uint meshShaderQueries;
    }

    public unsafe partial struct VkPhysicalDeviceMeshShaderPropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint maxTaskWorkGroupTotalCount;

                public _maxTaskWorkGroupCount_e__FixedBuffer maxTaskWorkGroupCount;

                public uint maxTaskWorkGroupInvocations;

                public _maxTaskWorkGroupSize_e__FixedBuffer maxTaskWorkGroupSize;

                public uint maxTaskPayloadSize;

                public uint maxTaskSharedMemorySize;

                public uint maxTaskPayloadAndSharedMemorySize;

                public uint maxMeshWorkGroupTotalCount;

                public _maxMeshWorkGroupCount_e__FixedBuffer maxMeshWorkGroupCount;

                public uint maxMeshWorkGroupInvocations;

                public _maxMeshWorkGroupSize_e__FixedBuffer maxMeshWorkGroupSize;

                public uint maxMeshSharedMemorySize;

                public uint maxMeshPayloadAndSharedMemorySize;

                public uint maxMeshOutputMemorySize;

                public uint maxMeshPayloadAndOutputMemorySize;

                public uint maxMeshOutputComponents;

                public uint maxMeshOutputVertices;

                public uint maxMeshOutputPrimitives;

                public uint maxMeshOutputLayers;

                public uint maxMeshMultiviewViewCount;

                public uint meshOutputPerVertexGranularity;

                public uint meshOutputPerPrimitiveGranularity;

                public uint maxPreferredTaskWorkGroupInvocations;

                public uint maxPreferredMeshWorkGroupInvocations;

                public uint prefersLocalInvocationVertexOutput;

                public uint prefersLocalInvocationPrimitiveOutput;

                public uint prefersCompactVertexOutput;

                public uint prefersCompactPrimitiveOutput;

        [InlineArray(3)]
        public partial struct _maxTaskWorkGroupCount_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(3)]
        public partial struct _maxTaskWorkGroupSize_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(3)]
        public partial struct _maxMeshWorkGroupCount_e__FixedBuffer
        {
            public uint e0;
        }

        [InlineArray(3)]
        public partial struct _maxMeshWorkGroupSize_e__FixedBuffer
        {
            public uint e0;
        }
    }

    public partial struct VkDrawMeshTasksIndirectCommandEXT
    {
                public uint groupCountX;

                public uint groupCountY;

                public uint groupCountZ;
    }

    public unsafe partial struct VkMetalSurfaceCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public void* pLayer;
    }

    public partial struct __IOSurface
    {
    }

    public unsafe partial struct VkExportMetalObjectCreateInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExportMetalObjectTypeFlagBitsEXT exportObjectType;
    }

    public unsafe partial struct VkExportMetalObjectsInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;
    }

    public unsafe partial struct VkExportMetalDeviceInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public void* mtlDevice;
    }

    public unsafe partial struct VkExportMetalCommandQueueInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkQueue* queue;

                public void* mtlCommandQueue;
    }

    public unsafe partial struct VkExportMetalBufferInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDeviceMemory* memory;

                public void* mtlBuffer;
    }

    public unsafe partial struct VkImportMetalBufferInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public void* mtlBuffer;
    }

    public unsafe partial struct VkExportMetalTextureInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* image;

                public VkImageView* imageView;

                public VkBufferView* bufferView;

        public VkImageAspectFlagBits plane;

                public void* mtlTexture;
    }

    public unsafe partial struct VkImportMetalTextureInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkImageAspectFlagBits plane;

                public void* mtlTexture;
    }

    public unsafe partial struct VkExportMetalIOSurfaceInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkImage* image;

                public __IOSurface* ioSurface;
    }

    public unsafe partial struct VkImportMetalIOSurfaceInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public __IOSurface* ioSurface;
    }

    public unsafe partial struct VkExportMetalSharedEventInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSemaphore* semaphore;

                public VkEvent* @event;

                public void* mtlSharedEvent;
    }

    public unsafe partial struct VkImportMetalSharedEventInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public void* mtlSharedEvent;
    }

    public unsafe partial struct VkImportMemoryMetalHandleInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExternalMemoryHandleTypeFlagBits handleType;

        public void* handle;
    }

    public unsafe partial struct VkMemoryMetalHandlePropertiesEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint memoryTypeBits;
    }

    public unsafe partial struct VkMemoryGetMetalHandleInfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDeviceMemory* memory;

        public VkExternalMemoryHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkWin32SurfaceCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public void* hinstance;

                public void* hwnd;
    }

    public unsafe partial struct VkImportMemoryWin32HandleInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

        public VkExternalMemoryHandleTypeFlagBits handleType;

                public void* handle;

                public void* name;
    }

    public unsafe partial struct VkExportMemoryWin32HandleInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public Prereq.Structs.SECURITY_ATTRIBUTES* pAttributes;

                public uint dwAccess;

                public void* name;
    }

    public unsafe partial struct VkMemoryWin32HandlePropertiesKHR
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint memoryTypeBits;
    }

    public unsafe partial struct VkMemoryGetWin32HandleInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkDeviceMemory* memory;

        public VkExternalMemoryHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkWin32KeyedMutexAcquireReleaseInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint acquireCount;

                public VkDeviceMemory** pAcquireSyncs;

                public ulong* pAcquireKeys;

                public uint* pAcquireTimeouts;

                public uint releaseCount;

                public VkDeviceMemory** pReleaseSyncs;

                public ulong* pReleaseKeys;
    }

    public unsafe partial struct VkImportSemaphoreWin32HandleInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSemaphore* semaphore;

                public uint flags;

        public VkExternalSemaphoreHandleTypeFlagBits handleType;

                public void* handle;

                public void* name;
    }

    public unsafe partial struct VkExportSemaphoreWin32HandleInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public Prereq.Structs.SECURITY_ATTRIBUTES* pAttributes;

                public uint dwAccess;

                public void* name;
    }

    public unsafe partial struct VkD3D12FenceSubmitInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint waitSemaphoreValuesCount;

                public ulong* pWaitSemaphoreValues;

                public uint signalSemaphoreValuesCount;

                public ulong* pSignalSemaphoreValues;
    }

    public unsafe partial struct VkSemaphoreGetWin32HandleInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkSemaphore* semaphore;

        public VkExternalSemaphoreHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkImportFenceWin32HandleInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkFence* fence;

                public uint flags;

        public VkExternalFenceHandleTypeFlagBits handleType;

                public void* handle;

                public void* name;
    }

    public unsafe partial struct VkExportFenceWin32HandleInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public Prereq.Structs.SECURITY_ATTRIBUTES* pAttributes;

                public uint dwAccess;

                public void* name;
    }

    public unsafe partial struct VkFenceGetWin32HandleInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public VkFence* fence;

        public VkExternalFenceHandleTypeFlagBits handleType;
    }

    public unsafe partial struct VkImportMemoryWin32HandleInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint handleType;

                public void* handle;
    }

    public unsafe partial struct VkExportMemoryWin32HandleInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public Prereq.Structs.SECURITY_ATTRIBUTES* pAttributes;

                public uint dwAccess;
    }

    public unsafe partial struct VkWin32KeyedMutexAcquireReleaseInfoNV
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint acquireCount;

                public VkDeviceMemory** pAcquireSyncs;

                public ulong* pAcquireKeys;

                public uint* pAcquireTimeoutMilliseconds;

                public uint releaseCount;

                public VkDeviceMemory** pReleaseSyncs;

                public ulong* pReleaseKeys;
    }

    public unsafe partial struct VkSurfaceFullScreenExclusiveInfoEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

        public VkFullScreenExclusiveEXT fullScreenExclusive;
    }

    public unsafe partial struct VkSurfaceCapabilitiesFullScreenExclusiveEXT
    {
        public Enumerators.VkStructureType sType;

        public void* pNext;

                public uint fullScreenExclusiveSupported;
    }

    public unsafe partial struct VkSurfaceFullScreenExclusiveWin32InfoEXT
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public void* hmonitor;
    }

    public unsafe partial struct VkXlibSurfaceCreateInfoKHR
    {
        public Enumerators.VkStructureType sType;

                public void* pNext;

                public uint flags;

                public void** dpy;

                public nuint window;
    }
}
