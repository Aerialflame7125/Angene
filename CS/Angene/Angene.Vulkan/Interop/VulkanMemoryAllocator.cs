using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Angene.Vulkan.Interop.VulkanMemoryAllocator.VmaAllocationCreateFlagBits;

namespace Angene.Vulkan.Interop;

public partial class VulkanMemoryAllocator
{
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public unsafe static void* Allocate(void* pUserData, nuint size, nuint alignment, VkSystemAllocationScope scope)
    {
        // NativeMemory handles aligned allocations efficiently in .NET
        return NativeMemory.AlignedAlloc(size, alignment);
    }
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public unsafe static void* Reallocate(void* pUserData, void* pOriginal, nuint size, nuint alignment, VkSystemAllocationScope scope)
    {
        return NativeMemory.AlignedRealloc(pOriginal, size, alignment);
    }
    [UnmanagedCallersOnly(CallConvs = new[] { typeof(CallConvCdecl) })]
    public unsafe static void Free(void* pUserData, void* pMemory)
    {
        NativeMemory.AlignedFree(pMemory);
    }

    public enum VmaAllocatorCreateFlagBits : uint
    {
        VMA_ALLOCATOR_CREATE_EXTERNALLY_SYNCHRONIZED_BIT = 0x00000001,
        VMA_ALLOCATOR_CREATE_KHR_DEDICATED_ALLOCATION_BIT = 0x00000002,
        VMA_ALLOCATOR_CREATE_KHR_BIND_MEMORY2_BIT = 0x00000004,
        VMA_ALLOCATOR_CREATE_EXT_MEMORY_BUDGET_BIT = 0x00000008,
        VMA_ALLOCATOR_CREATE_AMD_DEVICE_COHERENT_MEMORY_BIT = 0x00000010,
        VMA_ALLOCATOR_CREATE_BUFFER_DEVICE_ADDRESS_BIT = 0x00000020,
        VMA_ALLOCATOR_CREATE_EXT_MEMORY_PRIORITY_BIT = 0x00000040,
        VMA_ALLOCATOR_CREATE_KHR_MAINTENANCE4_BIT = 0x00000080,
        VMA_ALLOCATOR_CREATE_KHR_MAINTENANCE5_BIT = 0x00000100,
        VMA_ALLOCATOR_CREATE_KHR_EXTERNAL_MEMORY_WIN32_BIT = 0x00000200,
        VMA_ALLOCATOR_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum VmaMemoryUsage : uint
    {
        VMA_MEMORY_USAGE_UNKNOWN = 0,
        VMA_MEMORY_USAGE_GPU_ONLY = 1,
        VMA_MEMORY_USAGE_CPU_ONLY = 2,
        VMA_MEMORY_USAGE_CPUO_GPU = 3,
        VMA_MEMORY_USAGE_GPUO_CPU = 4,
        VMA_MEMORY_USAGE_CPU_COPY = 5,
        VMA_MEMORY_USAGE_GPU_LAZILY_ALLOCATED = 6,
        VMA_MEMORY_USAGE_AUTO = 7,
        VMA_MEMORY_USAGE_AUTO_PREFER_DEVICE = 8,
        VMA_MEMORY_USAGE_AUTO_PREFER_HOST = 9,
        VMA_MEMORY_USAGE_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum VmaAllocationCreateFlagBits : uint
    {
        VMA_ALLOCATION_CREATE_DEDICATED_MEMORY_BIT = 0x00000001,
        VMA_ALLOCATION_CREATE_NEVER_ALLOCATE_BIT = 0x00000002,
        VMA_ALLOCATION_CREATE_MAPPED_BIT = 0x00000004,
        VMA_ALLOCATION_CREATE_USER_DATA_COPY_STRING_BIT = 0x00000020,
        VMA_ALLOCATION_CREATE_UPPER_ADDRESS_BIT = 0x00000040,
        VMA_ALLOCATION_CREATE_DONT_BIND_BIT = 0x00000080,
        VMA_ALLOCATION_CREATE_WITHIN_BUDGET_BIT = 0x00000100,
        VMA_ALLOCATION_CREATE_CAN_ALIAS_BIT = 0x00000200,
        VMA_ALLOCATION_CREATE_HOST_ACCESS_SEQUENTIAL_WRITE_BIT = 0x00000400,
        VMA_ALLOCATION_CREATE_HOST_ACCESS_RANDOM_BIT = 0x00000800,
        VMA_ALLOCATION_CREATE_HOST_ACCESS_ALLOWRANSFER_INSTEAD_BIT = 0x00001000,
        VMA_ALLOCATION_CREATE_STRATEGY_MIN_MEMORY_BIT = 0x00010000,
        VMA_ALLOCATION_CREATE_STRATEGY_MINIME_BIT = 0x00020000,
        VMA_ALLOCATION_CREATE_STRATEGY_MIN_OFFSET_BIT = 0x00040000,
        VMA_ALLOCATION_CREATE_STRATEGY_BEST_FIT_BIT = VMA_ALLOCATION_CREATE_STRATEGY_MIN_MEMORY_BIT,
        VMA_ALLOCATION_CREATE_STRATEGY_FIRST_FIT_BIT = VMA_ALLOCATION_CREATE_STRATEGY_MINIME_BIT,
        VMA_ALLOCATION_CREATE_STRATEGY_MASK = VMA_ALLOCATION_CREATE_STRATEGY_MIN_MEMORY_BIT | VMA_ALLOCATION_CREATE_STRATEGY_MINIME_BIT | VMA_ALLOCATION_CREATE_STRATEGY_MIN_OFFSET_BIT,
        VMA_ALLOCATION_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum VmaPoolCreateFlagBits : uint
    {
        VMA_POOL_CREATE_IGNORE_BUFFER_IMAGE_GRANULARITY_BIT = 0x00000002,
        VMA_POOL_CREATE_LINEAR_ALGORITHM_BIT = 0x00000004,
        VMA_POOL_CREATE_ALGORITHM_MASK = VMA_POOL_CREATE_LINEAR_ALGORITHM_BIT,
        VMA_POOL_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum VmaDefragmentationFlagBits : uint
    {
        VMA_DEFRAGMENTATION_FLAG_ALGORITHM_FAST_BIT = 0x1,
        VMA_DEFRAGMENTATION_FLAG_ALGORITHM_BALANCED_BIT = 0x2,
        VMA_DEFRAGMENTATION_FLAG_ALGORITHM_FULL_BIT = 0x4,
        VMA_DEFRAGMENTATION_FLAG_ALGORITHM_EXTENSIVE_BIT = 0x8,
        VMA_DEFRAGMENTATION_FLAG_ALGORITHM_MASK = VMA_DEFRAGMENTATION_FLAG_ALGORITHM_FAST_BIT | VMA_DEFRAGMENTATION_FLAG_ALGORITHM_BALANCED_BIT | VMA_DEFRAGMENTATION_FLAG_ALGORITHM_FULL_BIT | VMA_DEFRAGMENTATION_FLAG_ALGORITHM_EXTENSIVE_BIT,
        VMA_DEFRAGMENTATION_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum VmaDefragmentationMoveOperation : uint
    {
        VMA_DEFRAGMENTATION_MOVE_OPERATION_COPY = 0,
        VMA_DEFRAGMENTATION_MOVE_OPERATION_IGNORE = 1,
        VMA_DEFRAGMENTATION_MOVE_OPERATION_DESTROY = 2,
    }

    public enum VmaVirtualBlockCreateFlagBits : uint
    {
        VMA_VIRTUAL_BLOCK_CREATE_LINEAR_ALGORITHM_BIT = 0x00000001,
        VMA_VIRTUAL_BLOCK_CREATE_ALGORITHM_MASK = VMA_VIRTUAL_BLOCK_CREATE_LINEAR_ALGORITHM_BIT,
        VMA_VIRTUAL_BLOCK_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }

    public enum VmaVirtualAllocationCreateFlagBits : uint
    {
        VMA_VIRTUAL_ALLOCATION_CREATE_UPPER_ADDRESS_BIT = VMA_ALLOCATION_CREATE_UPPER_ADDRESS_BIT,
        VMA_VIRTUAL_ALLOCATION_CREATE_STRATEGY_MIN_MEMORY_BIT = VMA_ALLOCATION_CREATE_STRATEGY_MIN_MEMORY_BIT,
        VMA_VIRTUAL_ALLOCATION_CREATE_STRATEGY_MINIME_BIT = VMA_ALLOCATION_CREATE_STRATEGY_MINIME_BIT,
        VMA_VIRTUAL_ALLOCATION_CREATE_STRATEGY_MIN_OFFSET_BIT = VMA_ALLOCATION_CREATE_STRATEGY_MIN_OFFSET_BIT,
        VMA_VIRTUAL_ALLOCATION_CREATE_STRATEGY_MASK = VMA_ALLOCATION_CREATE_STRATEGY_MASK,
        VMA_VIRTUAL_ALLOCATION_CREATE_FLAG_BITS_MAX_ENUM = 0x7FFFFFFF,
    }

    public partial struct VmaAllocator
    {
    }

    public partial struct VmaPool
    {
    }

    public partial struct VmaAllocation
    {
    }

    public partial struct VmaDefragmentationContext
    {
    }

    public partial struct VmaVirtualAllocation
    {
    }

    public partial struct VmaVirtualBlock
    {
    }

    public unsafe partial struct VmaDeviceMemoryCallbacks
    {
            public delegate* unmanaged[Cdecl]<VmaAllocator*, uint, VkDeviceMemory*, ulong, void*, void> pfnAllocate;

            public delegate* unmanaged[Cdecl]<VmaAllocator*, uint, VkDeviceMemory*, ulong, void*, void> pfnFree;

            public void* pUserData;
    }

    public unsafe partial struct VmaVulkanFunctions
    {
            public delegate* unmanaged[Cdecl]<VkInstance*, sbyte*, delegate* unmanaged[Cdecl]<void>> vkGetInstanceProcAddr;

            public delegate* unmanaged[Cdecl]<VkDevice*, sbyte*, delegate* unmanaged[Cdecl]<void>> vkGetDeviceProcAddr;

            public delegate* unmanaged[Cdecl]<VkPhysicalDevice*, VkPhysicalDeviceProperties*, void> vkGetPhysicalDeviceProperties;

            public delegate* unmanaged[Cdecl]<VkPhysicalDevice*, VkPhysicalDeviceMemoryProperties*, void> vkGetPhysicalDeviceMemoryProperties;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkMemoryAllocateInfo*, VkAllocationCallbacks*, VkDeviceMemory**, VkResult> vkAllocateMemory;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkDeviceMemory*, VkAllocationCallbacks*, void> vkFreeMemory;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkDeviceMemory*, ulong, ulong, uint, void**, VkResult> vkMapMemory;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkDeviceMemory*, void> vkUnmapMemory;

            public delegate* unmanaged[Cdecl]<VkDevice*, uint, VkMappedMemoryRange*, VkResult> vkFlushMappedMemoryRanges;

            public delegate* unmanaged[Cdecl]<VkDevice*, uint, VkMappedMemoryRange*, VkResult> vkInvalidateMappedMemoryRanges;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkBuffer*, VkDeviceMemory*, ulong, VkResult> vkBindBufferMemory;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkImage*, VkDeviceMemory*, ulong, VkResult> vkBindImageMemory;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkBuffer*, VkMemoryRequirements*, void> vkGetBufferMemoryRequirements;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkImage*, VkMemoryRequirements*, void> vkGetImageMemoryRequirements;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkBufferCreateInfo*, VkAllocationCallbacks*, VkBuffer**, VkResult> vkCreateBuffer;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkBuffer*, VkAllocationCallbacks*, void> vkDestroyBuffer;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkImageCreateInfo*, VkAllocationCallbacks*, VkImage**, VkResult> vkCreateImage;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkImage*, VkAllocationCallbacks*, void> vkDestroyImage;

            public delegate* unmanaged[Cdecl]<VkCommandBuffer*, VkBuffer*, VkBuffer*, uint, VkBufferCopy*, void> vkCmdCopyBuffer;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkBufferMemoryRequirementsInfo2*, VkMemoryRequirements2*, void> vkGetBufferMemoryRequirements2KHR;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkImageMemoryRequirementsInfo2*, VkMemoryRequirements2*, void> vkGetImageMemoryRequirements2KHR;

            public delegate* unmanaged[Cdecl]<VkDevice*, uint, VkBindBufferMemoryInfo*, VkResult> vkBindBufferMemory2KHR;

            public delegate* unmanaged[Cdecl]<VkDevice*, uint, VkBindImageMemoryInfo*, VkResult> vkBindImageMemory2KHR;

            public delegate* unmanaged[Cdecl]<VkPhysicalDevice*, VkPhysicalDeviceMemoryProperties2*, void> vkGetPhysicalDeviceMemoryProperties2KHR;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkDeviceBufferMemoryRequirements*, VkMemoryRequirements2*, void> vkGetDeviceBufferMemoryRequirements;

            public delegate* unmanaged[Cdecl]<VkDevice*, VkDeviceImageMemoryRequirements*, VkMemoryRequirements2*, void> vkGetDeviceImageMemoryRequirements;

            public void* vkGetMemoryWin32HandleKHR;

            public delegate* unmanaged[Cdecl]<VkPhysicalDevice*, VkPhysicalDeviceProperties2*, void> vkGetPhysicalDeviceProperties2KHR;
    }

    public unsafe partial struct VmaAllocatorCreateInfo
    {
            public uint flags;

            public VkPhysicalDevice* physicalDevice;

            public VkDevice* device;

            public ulong preferredLargeHeapBlockSize;

            public VkAllocationCallbacks* pAllocationCallbacks;

            public VmaDeviceMemoryCallbacks* pDeviceMemoryCallbacks;

            public ulong* pHeapSizeLimit;

            public VmaVulkanFunctions* pVulkanFunctions;

            public VkInstance* instance;

            public uint vulkanApiVersion;

            public uint* pTypeExternalMemoryHandleTypes;
    }

    public unsafe partial struct VmaAllocatorInfo
    {
            public VkInstance* instance;

            public VkPhysicalDevice* physicalDevice;

            public VkDevice* device;
    }

    public partial struct VmaStatistics
    {
            public uint blockCount;

            public uint allocationCount;

            public ulong blockBytes;

            public ulong allocationBytes;
    }

    public partial struct VmaDetailedStatistics
    {
        public VmaStatistics statistics;

            public uint unusedRangeCount;

            public ulong allocationSizeMin;

            public ulong allocationSizeMax;

            public ulong unusedRangeSizeMin;

            public ulong unusedRangeSizeMax;
    }

    public partial struct VmaTotalStatistics
    {
            public _memoryType_e__FixedBuffer memoryType;

            public _memoryHeap_e__FixedBuffer memoryHeap;

        public VmaDetailedStatistics total;

        [InlineArray(32)]
        public partial struct _memoryType_e__FixedBuffer
        {
            public VmaDetailedStatistics e0;
        }

        [InlineArray(16)]
        public partial struct _memoryHeap_e__FixedBuffer
        {
            public VmaDetailedStatistics e0;
        }
    }

    public partial struct VmaBudget
    {
        public VmaStatistics statistics;

            public ulong usage;

            public ulong budget;
    }

    public unsafe partial struct VmaAllocationCreateInfo
    {
            public uint flags;

        public VmaMemoryUsage usage;

            public uint requiredFlags;

            public uint preferredFlags;

            public uint memoryTypeBits;

            public VmaPool* pool;

            public void* pUserData;

        public float priority;

            public ulong minAlignment;
    }

    public unsafe partial struct VmaPoolCreateInfo
    {
            public uint memoryTypeIndex;

            public uint flags;

            public ulong blockSize;

            public nuint minBlockCount;

            public nuint maxBlockCount;

        public float priority;

            public ulong minAllocationAlignment;

            public void* pMemoryAllocateNext;
    }

    public unsafe partial struct VmaAllocationInfo
    {
            public uint memoryType;

            public VkDeviceMemory* deviceMemory;

            public ulong offset;

            public ulong size;

            public void* pMappedData;

            public void* pUserData;

            public sbyte* pName;
    }

    public partial struct VmaAllocationInfo2
    {
        public VmaAllocationInfo allocationInfo;

            public ulong blockSize;

            public uint dedicatedMemory;
    }

    public unsafe partial struct VmaDefragmentationInfo
    {
            public uint flags;

            public VmaPool* pool;

            public ulong maxBytesPerPass;

            public uint maxAllocationsPerPass;

            public delegate* unmanaged[Cdecl]<void*, uint> pfnBreakCallback;

            public void* pBreakCallbackUserData;
    }

    public unsafe partial struct VmaDefragmentationMove
    {
        public VmaDefragmentationMoveOperation operation;

            public VmaAllocation* srcAllocation;

            public VmaAllocation* dstTmpAllocation;
    }

    public unsafe partial struct VmaDefragmentationPassMoveInfo
    {
            public uint moveCount;

            public VmaDefragmentationMove* pMoves;
    }

    public partial struct VmaDefragmentationStats
    {
            public ulong bytesMoved;

            public ulong bytesFreed;

            public uint allocationsMoved;

            public uint deviceMemoryBlocksFreed;
    }

    public unsafe partial struct VmaVirtualBlockCreateInfo
    {
            public ulong size;

            public uint flags;

            public VkAllocationCallbacks* pAllocationCallbacks;
    }

    public unsafe partial struct VmaVirtualAllocationCreateInfo
    {
            public ulong size;

            public ulong alignment;

            public uint flags;

            public void* pUserData;
    }

    public unsafe partial struct VmaVirtualAllocationInfo
    {
            public ulong offset;

            public ulong size;

            public void* pUserData;
    }

    public unsafe partial class Methods
    {        
        [LibraryImport("vma")]
        public static partial VkResult vmaCreateAllocator(VmaAllocatorCreateInfo* pCreateInfo, VmaAllocator** pAllocator);

        [LibraryImport("vma")]
        public static partial void vmaDestroyAllocator(VmaAllocator* allocator);

        [LibraryImport("vma")]
        public static partial void vmaGetAllocatorInfo(VmaAllocator* allocator, VmaAllocatorInfo* pAllocatorInfo);

        [LibraryImport("vma")]
        public static partial void vmaGetPhysicalDeviceProperties(VmaAllocator* allocator, VkPhysicalDeviceProperties** ppPhysicalDeviceProperties);

        [LibraryImport("vma")]
        public static partial void vmaGetMemoryProperties(VmaAllocator* allocator, VkPhysicalDeviceMemoryProperties** ppPhysicalDeviceMemoryProperties);

        [LibraryImport("vma")]
        public static partial void vmaGetMemoryTypeProperties(VmaAllocator* allocator, uint memoryTypeIndex, uint* pFlags);

        [LibraryImport("vma")]
        public static partial void vmaSetCurrentFrameIndex(VmaAllocator* allocator, uint frameIndex);

        [LibraryImport("vma")]
        public static partial void vmaCalculateStatistics(VmaAllocator* allocator, VmaTotalStatistics* pStats);

        [LibraryImport("vma")]
        public static partial void vmaGetHeapBudgets(VmaAllocator* allocator, VmaBudget* pBudgets);

        [LibraryImport("vma")]
        public static partial VkResult vmaFindMemoryTypeIndex(VmaAllocator* allocator, uint memoryTypeBits, VmaAllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        [LibraryImport("vma")]
        public static partial VkResult vmaFindMemoryTypeIndexForBufferInfo(VmaAllocator* allocator, VkBufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        [LibraryImport("vma")]
        public static partial VkResult vmaFindMemoryTypeIndexForImageInfo(VmaAllocator* allocator, VkImageCreateInfo* pImageCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreatePool(VmaAllocator* allocator, VmaPoolCreateInfo* pCreateInfo, VmaPool** pPool);

        [LibraryImport("vma")]
        public static partial void vmaDestroyPool(VmaAllocator* allocator, VmaPool* pool);

        [LibraryImport("vma")]
        public static partial void vmaGetPoolStatistics(VmaAllocator* allocator, VmaPool* pool, VmaStatistics* pPoolStats);

        [LibraryImport("vma")]
        public static partial void vmaCalculatePoolStatistics(VmaAllocator* allocator, VmaPool* pool, VmaDetailedStatistics* pPoolStats);

        [LibraryImport("vma")]
        public static partial VkResult vmaCheckPoolCorruption(VmaAllocator* allocator, VmaPool* pool);

        [LibraryImport("vma")]
        public static partial void vmaGetPoolName(VmaAllocator* allocator, VmaPool* pool, sbyte** ppName);

        [LibraryImport("vma")]
        public static partial void vmaSetPoolName(VmaAllocator* allocator, VmaPool* pool, sbyte* pName);

        [LibraryImport("vma")]
        public static partial VkResult vmaAllocateMemory(VmaAllocator* allocator, VkMemoryRequirements* pVkMemoryRequirements, VmaAllocationCreateInfo* pCreateInfo, VmaAllocation** pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaAllocateDedicatedMemory(VmaAllocator* allocator, VkMemoryRequirements* pVkMemoryRequirements, VmaAllocationCreateInfo* pCreateInfo, void* pMemoryAllocateNext, VmaAllocation** pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaAllocateMemoryPages(VmaAllocator* allocator, VkMemoryRequirements* pVkMemoryRequirements, VmaAllocationCreateInfo* pCreateInfo, nuint allocationCount, VmaAllocation** pAllocations, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaAllocateMemoryForBuffer(VmaAllocator* allocator, VkBuffer* buffer, VmaAllocationCreateInfo* pCreateInfo, VmaAllocation** pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaAllocateMemoryForImage(VmaAllocator* allocator, VkImage* image, VmaAllocationCreateInfo* pCreateInfo, VmaAllocation** pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial void vmaFreeMemory(VmaAllocator* allocator, VmaAllocation* allocation);

        [LibraryImport("vma")]
        public static partial void vmaFreeMemoryPages(VmaAllocator* allocator, nuint allocationCount, VmaAllocation** pAllocations);

        [LibraryImport("vma")]
        public static partial void vmaGetAllocationInfo(VmaAllocator* allocator, VmaAllocation* allocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial void vmaGetAllocationInfo2(VmaAllocator* allocator, VmaAllocation* allocation, VmaAllocationInfo2* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial void vmaSetAllocationUserData(VmaAllocator* allocator, VmaAllocation* allocation, void* pUserData);

        [LibraryImport("vma")]
        public static partial void vmaSetAllocationName(VmaAllocator* allocator, VmaAllocation* allocation, sbyte* pName);

        [LibraryImport("vma")]
        public static partial void vmaGetAllocationMemoryProperties(VmaAllocator* allocator, VmaAllocation* allocation, uint* pFlags);

        [LibraryImport("vma")]
        public static partial VkResult vmaMapMemory(VmaAllocator* allocator, VmaAllocation* allocation, void** ppData);

        [LibraryImport("vma")]
        public static partial void vmaUnmapMemory(VmaAllocator* allocator, VmaAllocation* allocation);

        [LibraryImport("vma")]
        public static partial VkResult vmaFlushAllocation(VmaAllocator* allocator, VmaAllocation* allocation, ulong offset, ulong size);

        [LibraryImport("vma")]
        public static partial VkResult vmaInvalidateAllocation(VmaAllocator* allocator, VmaAllocation* allocation, ulong offset, ulong size);

        [LibraryImport("vma")]
        public static partial VkResult vmaFlushAllocations(VmaAllocator* allocator, uint allocationCount, VmaAllocation** allocations, ulong* offsets, ulong* sizes);

        [LibraryImport("vma")]
        public static partial VkResult vmaInvalidateAllocations(VmaAllocator* allocator, uint allocationCount, VmaAllocation** allocations, ulong* offsets, ulong* sizes);

        [LibraryImport("vma")]
        public static partial VkResult vmaCopyMemoryToAllocation(VmaAllocator* allocator, void* pSrcHostPointer, VmaAllocation* dstAllocation, ulong dstAllocationLocalOffset, ulong size);

        [LibraryImport("vma")]
        public static partial VkResult vmaCopyAllocationToMemory(VmaAllocator* allocator, VmaAllocation* srcAllocation, ulong srcAllocationLocalOffset, void* pDstHostPointer, ulong size);

        [LibraryImport("vma")]
        public static partial VkResult vmaCheckCorruption(VmaAllocator* allocator, uint memoryTypeBits);

        [LibraryImport("vma")]
        public static partial VkResult vmaBeginDefragmentation(VmaAllocator* allocator, VmaDefragmentationInfo* pInfo, VmaDefragmentationContext** pContext);

        [LibraryImport("vma")]
        public static partial void vmaEndDefragmentation(VmaAllocator* allocator, VmaDefragmentationContext* context, VmaDefragmentationStats* pStats);

        [LibraryImport("vma")]
        public static partial VkResult vmaBeginDefragmentationPass(VmaAllocator* allocator, VmaDefragmentationContext* context, VmaDefragmentationPassMoveInfo* pPassInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaEndDefragmentationPass(VmaAllocator* allocator, VmaDefragmentationContext* context, VmaDefragmentationPassMoveInfo* pPassInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaBindBufferMemory(VmaAllocator* allocator, VmaAllocation* allocation, VkBuffer* buffer);

        [LibraryImport("vma")]
        public static partial VkResult vmaBindBufferMemory2(VmaAllocator* allocator, VmaAllocation* allocation, ulong allocationLocalOffset, VkBuffer* buffer, void* pNext);

        [LibraryImport("vma")]
        public static partial VkResult vmaBindImageMemory(VmaAllocator* allocator, VmaAllocation* allocation, VkImage* image);

        [LibraryImport("vma")]
        public static partial VkResult vmaBindImageMemory2(VmaAllocator* allocator, VmaAllocation* allocation, ulong allocationLocalOffset, VkImage* image, void* pNext);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateBuffer(VmaAllocator* allocator, VkBufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, VkBuffer** pBuffer, VmaAllocation** pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateBufferWithAlignment(VmaAllocator* allocator, VkBufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, ulong minAlignment, VkBuffer** pBuffer, VmaAllocation** pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateDedicatedBuffer(VmaAllocator* allocator, VkBufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, void* pMemoryAllocateNext, VkBuffer** pBuffer, VmaAllocation** pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateAliasingBuffer(VmaAllocator* allocator, VmaAllocation* allocation, VkBufferCreateInfo* pBufferCreateInfo, VkBuffer** pBuffer);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateAliasingBuffer2(VmaAllocator* allocator, VmaAllocation* allocation, ulong allocationLocalOffset, VkBufferCreateInfo* pBufferCreateInfo, VkBuffer** pBuffer);

        [LibraryImport("vma")]
        public static partial void vmaDestroyBuffer(VmaAllocator* allocator, VkBuffer* buffer, VmaAllocation* allocation);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateImage(VmaAllocator* allocator, VkImageCreateInfo* pImageCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, VkImage** pImage, VmaAllocation** pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateDedicatedImage(VmaAllocator* allocator, VkImageCreateInfo* pImageCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, void* pMemoryAllocateNext, VkImage** pImage, VmaAllocation** pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateAliasingImage(VmaAllocator* allocator, VmaAllocation* allocation, VkImageCreateInfo* pImageCreateInfo, VkImage** pImage);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateAliasingImage2(VmaAllocator* allocator, VmaAllocation* allocation, ulong allocationLocalOffset, VkImageCreateInfo* pImageCreateInfo, VkImage** pImage);

        [LibraryImport("vma")]
        public static partial void vmaDestroyImage(VmaAllocator* allocator, VkImage* image, VmaAllocation* allocation);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateVirtualBlock(VmaVirtualBlockCreateInfo* pCreateInfo, VmaVirtualBlock** pVirtualBlock);

        [LibraryImport("vma")]
        public static partial void vmaDestroyVirtualBlock(VmaVirtualBlock* virtualBlock);

        [LibraryImport("vma")]
        public static partial uint vmaIsVirtualBlockEmpty(VmaVirtualBlock* virtualBlock);

        [LibraryImport("vma")]
        public static partial void vmaGetVirtualAllocationInfo(VmaVirtualBlock* virtualBlock, VmaVirtualAllocation* allocation, VmaVirtualAllocationInfo* pVirtualAllocInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaVirtualAllocate(VmaVirtualBlock* virtualBlock, VmaVirtualAllocationCreateInfo* pCreateInfo, VmaVirtualAllocation** pAllocation, ulong* pOffset);

        [LibraryImport("vma")]
        public static partial void vmaVirtualFree(VmaVirtualBlock* virtualBlock, VmaVirtualAllocation* allocation);

        [LibraryImport("vma")]
        public static partial void vmaClearVirtualBlock(VmaVirtualBlock* virtualBlock);

        [LibraryImport("vma")]
        public static partial void vmaSetVirtualAllocationUserData(VmaVirtualBlock* virtualBlock, VmaVirtualAllocation* allocation, void* pUserData);

        [LibraryImport("vma")]
        public static partial void vmaGetVirtualBlockStatistics(VmaVirtualBlock* virtualBlock, VmaStatistics* pStats);

        [LibraryImport("vma")]
        public static partial void vmaCalculateVirtualBlockStatistics(VmaVirtualBlock* virtualBlock, VmaDetailedStatistics* pStats);

        [LibraryImport("vma")]
        public static partial void vmaBuildVirtualBlockStatsString(VmaVirtualBlock* virtualBlock, sbyte** ppStatsString, uint detailedMap);

        [LibraryImport("vma")]
        public static partial void vmaFreeVirtualBlockStatsString(VmaVirtualBlock* virtualBlock, sbyte* pStatsString);

        [LibraryImport("vma")]
        public static partial void vmaBuildStatsString(VmaAllocator* allocator, sbyte** ppStatsString, uint detailedMap);

        [LibraryImport("vma")]
        public static partial void vmaFreeStatsString(VmaAllocator* allocator, sbyte* pStatsString);
    }
}
