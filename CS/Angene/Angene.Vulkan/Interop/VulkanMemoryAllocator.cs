using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using static Angene.Vulkan.Interop.VulkanMemoryAllocator.VmaAllocationCreateFlagBits;

namespace Angene.Vulkan.Interop;

public partial class VulkanMemoryAllocator
{
    public unsafe struct VmaBufferHandle
    {
        public IntPtr Buffer;
        public IntPtr Allocation;
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

    public unsafe partial struct VmaDeviceMemoryCallbacks
    {
            public delegate* unmanaged[Cdecl]<IntPtr, uint, IntPtr, ulong, void*, void> pfnAllocate;

            public delegate* unmanaged[Cdecl]<IntPtr, uint, IntPtr, ulong, void*, void> pfnFree;

            public void* pUserData;
    }

    public unsafe partial struct VmaVulkanFunctions
    {
            public delegate* unmanaged[Cdecl]<IntPtr, sbyte*, delegate* unmanaged[Cdecl]<void>> vkGetInstanceProcAddr;

            public delegate* unmanaged[Cdecl]<IntPtr, sbyte*, delegate* unmanaged[Cdecl]<void>> vkGetDeviceProcAddr;

            public delegate* unmanaged[Cdecl]<IntPtr, VkPhysicalDeviceProperties*, void> vkGetPhysicalDeviceProperties;

            public delegate* unmanaged[Cdecl]<IntPtr, VkPhysicalDeviceMemoryProperties*, void> vkGetPhysicalDeviceMemoryProperties;

            public delegate* unmanaged[Cdecl]<IntPtr, VkMemoryAllocateInfo*, VkAllocationCallbacks*, IntPtr*, VkResult> vkAllocateMemory;

            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, VkAllocationCallbacks*, void> vkFreeMemory;

            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, ulong, ulong, uint, void**, VkResult> vkMapMemory;

            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, void> vkUnmapMemory;

            public delegate* unmanaged[Cdecl]<IntPtr, uint, VkMappedMemoryRange*, VkResult> vkFlushMappedMemoryRanges;

            public delegate* unmanaged[Cdecl]<IntPtr, uint, VkMappedMemoryRange*, VkResult> vkInvalidateMappedMemoryRanges;

            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, ulong, VkResult> vkBindBufferMemory;

            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, ulong, VkResult> vkBindImageMemory;

            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, VkMemoryRequirements*, void> vkGetBufferMemoryRequirements;

            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, VkMemoryRequirements*, void> vkGetImageMemoryRequirements;

            public delegate* unmanaged[Cdecl]<IntPtr, VkBufferCreateInfo*, VkAllocationCallbacks*, IntPtr*, VkResult> vkCreateBuffer;

            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, VkAllocationCallbacks*, void> vkDestroyBuffer;

            public delegate* unmanaged[Cdecl]<IntPtr, VkImageCreateInfo*, VkAllocationCallbacks*, IntPtr*, VkResult> vkCreateImage;

            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, VkAllocationCallbacks*, void> vkDestroyImage;

            public delegate* unmanaged[Cdecl]<IntPtr, IntPtr, IntPtr, uint, VkBufferCopy*, void> vkCmdCopyBuffer;

            public delegate* unmanaged[Cdecl]<IntPtr, VkBufferMemoryRequirementsInfo2*, VkMemoryRequirements2*, void> vkGetBufferMemoryRequirements2KHR;

            public delegate* unmanaged[Cdecl]<IntPtr, VkImageMemoryRequirementsInfo2*, VkMemoryRequirements2*, void> vkGetImageMemoryRequirements2KHR;

            public delegate* unmanaged[Cdecl]<IntPtr, uint, VkBindBufferMemoryInfo*, VkResult> vkBindBufferMemory2KHR;

            public delegate* unmanaged[Cdecl]<IntPtr, uint, VkBindImageMemoryInfo*, VkResult> vkBindImageMemory2KHR;

            public delegate* unmanaged[Cdecl]<IntPtr, VkPhysicalDeviceMemoryProperties2*, void> vkGetPhysicalDeviceMemoryProperties2KHR;

            public delegate* unmanaged[Cdecl]<IntPtr, VkDeviceBufferMemoryRequirements*, VkMemoryRequirements2*, void> vkGetDeviceBufferMemoryRequirements;

            public delegate* unmanaged[Cdecl]<IntPtr, VkDeviceImageMemoryRequirements*, VkMemoryRequirements2*, void> vkGetDeviceImageMemoryRequirements;

            public void* vkGetMemoryWin32HandleKHR;

            public delegate* unmanaged[Cdecl]<IntPtr, VkPhysicalDeviceProperties2*, void> vkGetPhysicalDeviceProperties2KHR;
    }

    public unsafe partial struct VmaAllocatorCreateInfo
    {
            public uint flags;

            public IntPtr physicalDevice;

            public IntPtr device;

            public ulong preferredLargeHeapBlockSize;

            public VkAllocationCallbacks* pAllocationCallbacks;

            public VmaDeviceMemoryCallbacks* pDeviceMemoryCallbacks;

            public ulong* pHeapSizeLimit;

            public VmaVulkanFunctions* pVulkanFunctions;

            public IntPtr instance;

            public uint vulkanApiVersion;

            public uint* pTypeExternalMemoryHandleTypes;
    }

    public unsafe partial struct VmaAllocatorInfo
    {
            public IntPtr instance;

            public IntPtr physicalDevice;

            public IntPtr device;
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

            public IntPtr pool;

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

            public IntPtr deviceMemory;

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

            public IntPtr pool;

            public ulong maxBytesPerPass;

            public uint maxAllocationsPerPass;

            public delegate* unmanaged[Cdecl]<void*, uint> pfnBreakCallback;

            public void* pBreakCallbackUserData;
    }

    public unsafe partial struct VmaDefragmentationMove
    {
        public VmaDefragmentationMoveOperation operation;

            public IntPtr srcAllocation;

            public IntPtr dstTmpAllocation;
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
        public static partial VkResult vmaCreateAllocator(VmaAllocatorCreateInfo* pCreateInfo, IntPtr* pAllocator);

        [LibraryImport("vma")]
        public static partial void vmaDestroyAllocator(IntPtr allocator);

        [LibraryImport("vma")]
        public static partial void vmaGetAllocatorInfo(IntPtr allocator, VmaAllocatorInfo* pAllocatorInfo);

        [LibraryImport("vma")]
        public static partial void vmaGetPhysicalDeviceProperties(IntPtr allocator, VkPhysicalDeviceProperties** ppPhysicalDeviceProperties);

        [LibraryImport("vma")]
        public static partial void vmaGetMemoryProperties(IntPtr allocator, VkPhysicalDeviceMemoryProperties** ppPhysicalDeviceMemoryProperties);

        [LibraryImport("vma")]
        public static partial void vmaGetMemoryTypeProperties(IntPtr allocator, uint memoryTypeIndex, uint* pFlags);

        [LibraryImport("vma")]
        public static partial void vmaSetCurrentFrameIndex(IntPtr allocator, uint frameIndex);

        [LibraryImport("vma")]
        public static partial void vmaCalculateStatistics(IntPtr allocator, VmaTotalStatistics* pStats);

        [LibraryImport("vma")]
        public static partial void vmaGetHeapBudgets(IntPtr allocator, VmaBudget* pBudgets);

        [LibraryImport("vma")]
        public static partial VkResult vmaFindMemoryTypeIndex(IntPtr allocator, uint memoryTypeBits, VmaAllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        [LibraryImport("vma")]
        public static partial VkResult vmaFindMemoryTypeIndexForBufferInfo(IntPtr allocator, VkBufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        [LibraryImport("vma")]
        public static partial VkResult vmaFindMemoryTypeIndexForImageInfo(IntPtr allocator, VkImageCreateInfo* pImageCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, uint* pMemoryTypeIndex);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreatePool(IntPtr allocator, VmaPoolCreateInfo* pCreateInfo, IntPtr* pPool);

        [LibraryImport("vma")]
        public static partial void vmaDestroyPool(IntPtr allocator, IntPtr pool);

        [LibraryImport("vma")]
        public static partial void vmaGetPoolStatistics(IntPtr allocator, IntPtr pool, VmaStatistics* pPoolStats);

        [LibraryImport("vma")]
        public static partial void vmaCalculatePoolStatistics(IntPtr allocator, IntPtr pool, VmaDetailedStatistics* pPoolStats);

        [LibraryImport("vma")]
        public static partial VkResult vmaCheckPoolCorruption(IntPtr allocator, IntPtr pool);

        [LibraryImport("vma")]
        public static partial void vmaGetPoolName(IntPtr allocator, IntPtr pool, sbyte** ppName);

        [LibraryImport("vma")]
        public static partial void vmaSetPoolName(IntPtr allocator, IntPtr pool, sbyte* pName);

        [LibraryImport("vma")]
        public static partial VkResult vmaAllocateMemory(IntPtr allocator, VkMemoryRequirements* pVkMemoryRequirements, VmaAllocationCreateInfo* pCreateInfo, IntPtr* pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaAllocateDedicatedMemory(IntPtr allocator, VkMemoryRequirements* pVkMemoryRequirements, VmaAllocationCreateInfo* pCreateInfo, void* pMemoryAllocateNext, IntPtr* pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaAllocateMemoryPages(IntPtr allocator, VkMemoryRequirements* pVkMemoryRequirements, VmaAllocationCreateInfo* pCreateInfo, nuint allocationCount, IntPtr* pAllocations, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaAllocateMemoryForBuffer(IntPtr allocator, IntPtr buffer, VmaAllocationCreateInfo* pCreateInfo, IntPtr* pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaAllocateMemoryForImage(IntPtr allocator, IntPtr image, VmaAllocationCreateInfo* pCreateInfo, IntPtr* pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial void vmaFreeMemory(IntPtr allocator, IntPtr allocation);

        [LibraryImport("vma")]
        public static partial void vmaFreeMemoryPages(IntPtr allocator, nuint allocationCount, IntPtr* pAllocations);

        [LibraryImport("vma")]
        public static partial void vmaGetAllocationInfo(IntPtr allocator, IntPtr allocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial void vmaGetAllocationInfo2(IntPtr allocator, IntPtr allocation, VmaAllocationInfo2* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial void vmaSetAllocationUserData(IntPtr allocator, IntPtr allocation, void* pUserData);

        [LibraryImport("vma")]
        public static partial void vmaSetAllocationName(IntPtr allocator, IntPtr allocation, sbyte* pName);

        [LibraryImport("vma")]
        public static partial void vmaGetAllocationMemoryProperties(IntPtr allocator, IntPtr allocation, uint* pFlags);

        [LibraryImport("vma")]
        public static partial VkResult vmaMapMemory(IntPtr allocator, IntPtr allocation, void** ppData);

        [LibraryImport("vma")]
        public static partial void vmaUnmapMemory(IntPtr allocator, IntPtr allocation);

        [LibraryImport("vma")]
        public static partial VkResult vmaFlushAllocation(IntPtr allocator, IntPtr allocation, ulong offset, ulong size);

        [LibraryImport("vma")]
        public static partial VkResult vmaInvalidateAllocation(IntPtr allocator, IntPtr allocation, ulong offset, ulong size);

        [LibraryImport("vma")]
        public static partial VkResult vmaFlushAllocations(IntPtr allocator, uint allocationCount, IntPtr* allocations, ulong* offsets, ulong* sizes);

        [LibraryImport("vma")]
        public static partial VkResult vmaInvalidateAllocations(IntPtr allocator, uint allocationCount, IntPtr* allocations, ulong* offsets, ulong* sizes);

        [LibraryImport("vma")]
        public static partial VkResult vmaCopyMemoryToAllocation(IntPtr allocator, void* pSrcHostPointer, IntPtr dstAllocation, ulong dstAllocationLocalOffset, ulong size);

        [LibraryImport("vma")]
        public static partial VkResult vmaCopyAllocationToMemory(IntPtr allocator, IntPtr srcAllocation, ulong srcAllocationLocalOffset, void* pDstHostPointer, ulong size);

        [LibraryImport("vma")]
        public static partial VkResult vmaCheckCorruption(IntPtr allocator, uint memoryTypeBits);

        [LibraryImport("vma")]
        public static partial VkResult vmaBeginDefragmentation(IntPtr allocator, VmaDefragmentationInfo* pInfo, IntPtr* pContext);

        [LibraryImport("vma")]
        public static partial void vmaEndDefragmentation(IntPtr allocator, IntPtr context, VmaDefragmentationStats* pStats);

        [LibraryImport("vma")]
        public static partial VkResult vmaBeginDefragmentationPass(IntPtr allocator, IntPtr context, VmaDefragmentationPassMoveInfo* pPassInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaEndDefragmentationPass(IntPtr allocator, IntPtr context, VmaDefragmentationPassMoveInfo* pPassInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaBindBufferMemory(IntPtr allocator, IntPtr allocation, IntPtr buffer);

        [LibraryImport("vma")]
        public static partial VkResult vmaBindBufferMemory2(IntPtr allocator, IntPtr allocation, ulong allocationLocalOffset, IntPtr buffer, void* pNext);

        [LibraryImport("vma")]
        public static partial VkResult vmaBindImageMemory(IntPtr allocator, IntPtr allocation, IntPtr image);

        [LibraryImport("vma")]
        public static partial VkResult vmaBindImageMemory2(IntPtr allocator, IntPtr allocation, ulong allocationLocalOffset, IntPtr image, void* pNext);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateBuffer(IntPtr allocator, VkBufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, IntPtr* pBuffer, IntPtr* pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateBufferWithAlignment(IntPtr allocator, VkBufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, ulong minAlignment, IntPtr* pBuffer, IntPtr* pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateDedicatedBuffer(IntPtr allocator, VkBufferCreateInfo* pBufferCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, void* pMemoryAllocateNext, IntPtr* pBuffer, IntPtr* pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateAliasingBuffer(IntPtr allocator, IntPtr allocation, VkBufferCreateInfo* pBufferCreateInfo, IntPtr* pBuffer);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateAliasingBuffer2(IntPtr allocator, IntPtr allocation, ulong allocationLocalOffset, VkBufferCreateInfo* pBufferCreateInfo, IntPtr* pBuffer);

        [LibraryImport("vma")]
        public static partial void vmaDestroyBuffer(IntPtr allocator, IntPtr buffer, IntPtr allocation);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateImage(IntPtr allocator, VkImageCreateInfo* pImageCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, IntPtr* pImage, IntPtr* pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateDedicatedImage(IntPtr allocator, VkImageCreateInfo* pImageCreateInfo, VmaAllocationCreateInfo* pAllocationCreateInfo, void* pMemoryAllocateNext, IntPtr* pImage, IntPtr* pAllocation, VmaAllocationInfo* pAllocationInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateAliasingImage(IntPtr allocator, IntPtr allocation, VkImageCreateInfo* pImageCreateInfo, IntPtr* pImage);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateAliasingImage2(IntPtr allocator, IntPtr allocation, ulong allocationLocalOffset, VkImageCreateInfo* pImageCreateInfo, IntPtr* pImage);

        [LibraryImport("vma")]
        public static partial void vmaDestroyImage(IntPtr allocator, IntPtr image, IntPtr allocation);

        [LibraryImport("vma")]
        public static partial VkResult vmaCreateVirtualBlock(VmaVirtualBlockCreateInfo* pCreateInfo, IntPtr* pVirtualBlock);

        [LibraryImport("vma")]
        public static partial void vmaDestroyVirtualBlock(IntPtr virtualBlock);

        [LibraryImport("vma")]
        public static partial uint vmaIsVirtualBlockEmpty(IntPtr virtualBlock);

        [LibraryImport("vma")]
        public static partial void vmaGetVirtualAllocationInfo(IntPtr virtualBlock, IntPtr allocation, VmaVirtualAllocationInfo* pVirtualAllocInfo);

        [LibraryImport("vma")]
        public static partial VkResult vmaVirtualAllocate(IntPtr virtualBlock, VmaVirtualAllocationCreateInfo* pCreateInfo, IntPtr* pAllocation, ulong* pOffset);

        [LibraryImport("vma")]
        public static partial void vmaVirtualFree(IntPtr virtualBlock, IntPtr allocation);

        [LibraryImport("vma")]
        public static partial void vmaClearVirtualBlock(IntPtr virtualBlock);

        [LibraryImport("vma")]
        public static partial void vmaSetVirtualAllocationUserData(IntPtr virtualBlock, IntPtr allocation, void* pUserData);

        [LibraryImport("vma")]
        public static partial void vmaGetVirtualBlockStatistics(IntPtr virtualBlock, VmaStatistics* pStats);

        [LibraryImport("vma")]
        public static partial void vmaCalculateVirtualBlockStatistics(IntPtr virtualBlock, VmaDetailedStatistics* pStats);

        [LibraryImport("vma")]
        public static partial void vmaBuildVirtualBlockStatsString(IntPtr virtualBlock, sbyte** ppStatsString, uint detailedMap);

        [LibraryImport("vma")]
        public static partial void vmaFreeVirtualBlockStatsString(IntPtr virtualBlock, sbyte* pStatsString);

        [LibraryImport("vma")]
        public static partial void vmaBuildStatsString(IntPtr allocator, sbyte** ppStatsString, uint detailedMap);

        [LibraryImport("vma")]
        public static partial void vmaFreeStatsString(IntPtr allocator, sbyte* pStatsString);
    }
}
