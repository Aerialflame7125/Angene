global using static Angene.Vulkan.Interop.Enumerators;
global using static Angene.Vulkan.Interop.Structs;
using System.Runtime.InteropServices;
using System.Runtime.CompilerServices;

namespace Angene.Vulkan.Interop;
public static unsafe partial class Methods
{
    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateInstance(VkInstanceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out IntPtr pInstance);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyInstance(IntPtr instance, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumeratePhysicalDevices(IntPtr instance, uint* pPhysicalDeviceCount, IntPtr* pPhysicalDevices);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceFeatures(IntPtr physicalDevice, VkPhysicalDeviceFeatures* pFeatures);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceFormatProperties(IntPtr physicalDevice, VkFormat format, VkFormatProperties* pFormatProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceImageFormatProperties(IntPtr physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, uint usage, uint flags, VkImageFormatProperties* pImageFormatProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceProperties(IntPtr physicalDevice, VkPhysicalDeviceProperties* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceQueueFamilyProperties(IntPtr physicalDevice, uint* pQueueFamilyPropertyCount, VkQueueFamilyProperties* pQueueFamilyProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceMemoryProperties(IntPtr physicalDevice, VkPhysicalDeviceMemoryProperties* pMemoryProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern delegate* unmanaged[Cdecl]<void> vkGetInstanceProcAddr(IntPtr instance, sbyte* pName);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern delegate* unmanaged[Cdecl]<void> vkGetDeviceProcAddr(IntPtr device, sbyte* pName);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDevice(IntPtr physicalDevice, VkDeviceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, out IntPtr pDevice);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyDevice(IntPtr device, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumerateInstanceExtensionProperties(sbyte* pLayerName, uint* pPropertyCount, VkExtensionProperties* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumerateDeviceExtensionProperties(IntPtr physicalDevice, sbyte* pLayerName, uint* pPropertyCount, VkExtensionProperties* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumerateInstanceLayerProperties(uint* pPropertyCount, VkLayerProperties* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumerateDeviceLayerProperties(IntPtr physicalDevice, uint* pPropertyCount, VkLayerProperties* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceQueue(IntPtr device, uint queueFamilyIndex, uint queueIndex, out IntPtr pQueue);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkQueueSubmit(IntPtr queue, uint submitCount, VkSubmitInfo* pSubmits, IntPtr fence);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkQueueWaitIdle(IntPtr queue);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkDeviceWaitIdle(IntPtr device);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkAllocateMemory(IntPtr device, VkMemoryAllocateInfo* pAllocateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pMemory);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkFreeMemory(IntPtr device, IntPtr memory, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkMapMemory(IntPtr device, IntPtr memory, ulong offset, ulong size, uint flags, void** ppData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkUnmapMemory(IntPtr device, IntPtr memory);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkFlushMappedMemoryRanges(IntPtr device, uint memoryRangeCount, VkMappedMemoryRange* pMemoryRanges);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkInvalidateMappedMemoryRanges(IntPtr device, uint memoryRangeCount, VkMappedMemoryRange* pMemoryRanges);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceMemoryCommitment(IntPtr device, IntPtr memory, ulong* pCommittedMemoryInBytes);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindBufferMemory(IntPtr device, IntPtr buffer, IntPtr memory, ulong memoryOffset);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindImageMemory(IntPtr device, IntPtr image, IntPtr memory, ulong memoryOffset);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetBufferMemoryRequirements(IntPtr device, IntPtr buffer, VkMemoryRequirements* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetImageMemoryRequirements(IntPtr device, IntPtr image, VkMemoryRequirements* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetImageSparseMemoryRequirements(IntPtr device, IntPtr image, uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements* pSparseMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceSparseImageFormatProperties(IntPtr physicalDevice, VkFormat format, VkImageType type, VkSampleCountFlagBits samples, uint usage, VkImageTiling tiling, uint* pPropertyCount, VkSparseImageFormatProperties* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkQueueBindSparse(IntPtr queue, uint bindInfoCount, VkBindSparseInfo* pBindInfo, IntPtr fence);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateFence(IntPtr device, VkFenceCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pFence);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyFence(IntPtr device, IntPtr fence, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkResetFences(IntPtr device, uint fenceCount, IntPtr* pFences);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetFenceStatus(IntPtr device, IntPtr fence);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkWaitForFences(IntPtr device, uint fenceCount, IntPtr* pFences, uint waitAll, ulong timeout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateSemaphore(IntPtr device, VkSemaphoreCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSemaphore);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroySemaphore(IntPtr device, IntPtr semaphore, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateQueryPool(IntPtr device, VkQueryPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pQueryPool);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyQueryPool(IntPtr device, IntPtr queryPool, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetQueryPoolResults(IntPtr device, IntPtr queryPool, uint firstQuery, uint queryCount, nuint dataSize, void* pData, ulong stride, uint flags);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateBuffer(IntPtr device, VkBufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyBuffer(IntPtr device, IntPtr buffer, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateImage(IntPtr device, VkImageCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pImage);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyImage(IntPtr device, IntPtr image, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetImageSubresourceLayout(IntPtr device, IntPtr image, VkImageSubresource* pSubresource, VkSubresourceLayout* pLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateImageView(IntPtr device, VkImageViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pView);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyImageView(IntPtr device, IntPtr imageView, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateCommandPool(IntPtr device, VkCommandPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pCommandPool);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyCommandPool(IntPtr device, IntPtr commandPool, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkResetCommandPool(IntPtr device, IntPtr commandPool, uint flags);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkAllocateCommandBuffers(IntPtr device, VkCommandBufferAllocateInfo* pAllocateInfo, IntPtr* pCommandBuffers);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkFreeCommandBuffers(IntPtr device, IntPtr commandPool, uint commandBufferCount, IntPtr* pCommandBuffers);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBeginCommandBuffer(IntPtr commandBuffer, VkCommandBufferBeginInfo* pBeginInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEndCommandBuffer(IntPtr commandBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkResetCommandBuffer(IntPtr commandBuffer, uint flags);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyBuffer(IntPtr commandBuffer, IntPtr srcBuffer, IntPtr dstBuffer, uint regionCount, VkBufferCopy* pRegions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyImage(IntPtr commandBuffer, IntPtr srcImage, VkImageLayout srcImageLayout, IntPtr dstImage, VkImageLayout dstImageLayout, uint regionCount, VkImageCopy* pRegions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyBufferToImage(IntPtr commandBuffer, IntPtr srcBuffer, IntPtr dstImage, VkImageLayout dstImageLayout, uint regionCount, VkBufferImageCopy* pRegions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyImageToBuffer(IntPtr commandBuffer, IntPtr srcImage, VkImageLayout srcImageLayout, IntPtr dstBuffer, uint regionCount, VkBufferImageCopy* pRegions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdUpdateBuffer(IntPtr commandBuffer, IntPtr dstBuffer, ulong dstOffset, ulong dataSize, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdFillBuffer(IntPtr commandBuffer, IntPtr dstBuffer, ulong dstOffset, ulong size, uint data);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPipelineBarrier(IntPtr commandBuffer, uint srcStageMask, uint dstStageMask, uint dependencyFlags, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginQuery(IntPtr commandBuffer, IntPtr queryPool, uint query, uint flags);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndQuery(IntPtr commandBuffer, IntPtr queryPool, uint query);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdResetQueryPool(IntPtr commandBuffer, IntPtr queryPool, uint firstQuery, uint queryCount);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWriteTimestamp(IntPtr commandBuffer, VkPipelineStageFlagBits pipelineStage, IntPtr queryPool, uint query);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyQueryPoolResults(IntPtr commandBuffer, IntPtr queryPool, uint firstQuery, uint queryCount, IntPtr dstBuffer, ulong dstOffset, ulong stride, uint flags);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdExecuteCommands(IntPtr commandBuffer, uint commandBufferCount, IntPtr* pCommandBuffers);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateEvent(IntPtr device, VkEventCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pEvent);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyEvent(IntPtr device, IntPtr @event, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetEventStatus(IntPtr device, IntPtr @event);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkSetEvent(IntPtr device, IntPtr @event);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkResetEvent(IntPtr device, IntPtr @event);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateBufferView(IntPtr device, VkBufferViewCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pView);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyBufferView(IntPtr device, IntPtr bufferView, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateShaderModule(IntPtr device, VkShaderModuleCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pShaderModule);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyShaderModule(IntPtr device, IntPtr shaderModule, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreatePipelineCache(IntPtr device, VkPipelineCacheCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pPipelineCache);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyPipelineCache(IntPtr device, IntPtr pipelineCache, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPipelineCacheData(IntPtr device, IntPtr pipelineCache, nuint* pDataSize, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkMergePipelineCaches(IntPtr device, IntPtr dstCache, uint srcCacheCount, IntPtr* pSrcCaches);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateComputePipelines(IntPtr device, IntPtr pipelineCache, uint createInfoCount, VkComputePipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, IntPtr* pPipelines);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyPipeline(IntPtr device, IntPtr pipeline, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreatePipelineLayout(IntPtr device, VkPipelineLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pPipelineLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyPipelineLayout(IntPtr device, IntPtr pipelineLayout, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateSampler(IntPtr device, VkSamplerCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSampler);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroySampler(IntPtr device, IntPtr sampler, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDescriptorSetLayout(IntPtr device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSetLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyDescriptorSetLayout(IntPtr device, IntPtr descriptorSetLayout, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDescriptorPool(IntPtr device, VkDescriptorPoolCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pDescriptorPool);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyDescriptorPool(IntPtr device, IntPtr descriptorPool, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkResetDescriptorPool(IntPtr device, IntPtr descriptorPool, uint flags);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkAllocateDescriptorSets(IntPtr device, VkDescriptorSetAllocateInfo* pAllocateInfo, IntPtr* pDescriptorSets);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkFreeDescriptorSets(IntPtr device, IntPtr descriptorPool, uint descriptorSetCount, IntPtr* pDescriptorSets);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkUpdateDescriptorSets(IntPtr device, uint descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites, uint descriptorCopyCount, VkCopyDescriptorSet* pDescriptorCopies);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindPipeline(IntPtr commandBuffer, VkPipelineBindPoint pipelineBindPoint, IntPtr pipeline);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindDescriptorSets(IntPtr commandBuffer, VkPipelineBindPoint pipelineBindPoint, IntPtr layout, uint firstSet, uint descriptorSetCount, IntPtr* pDescriptorSets, uint dynamicOffsetCount, uint* pDynamicOffsets);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdClearColorImage(IntPtr commandBuffer, IntPtr image, VkImageLayout imageLayout, VkClearColorValue* pColor, uint rangeCount, VkImageSubresourceRange* pRanges);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDispatch(IntPtr commandBuffer, uint groupCountX, uint groupCountY, uint groupCountZ);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDispatchIndirect(IntPtr commandBuffer, IntPtr buffer, ulong offset);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetEvent(IntPtr commandBuffer, IntPtr @event, uint stageMask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdResetEvent(IntPtr commandBuffer, IntPtr @event, uint stageMask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWaitEvents(IntPtr commandBuffer, uint eventCount, IntPtr* pEvents, uint srcStageMask, uint dstStageMask, uint memoryBarrierCount, VkMemoryBarrier* pMemoryBarriers, uint bufferMemoryBarrierCount, VkBufferMemoryBarrier* pBufferMemoryBarriers, uint imageMemoryBarrierCount, VkImageMemoryBarrier* pImageMemoryBarriers);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushConstants(IntPtr commandBuffer, IntPtr layout, uint stageFlags, uint offset, uint size, void* pValues);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateGraphicsPipelines(IntPtr device, IntPtr pipelineCache, uint createInfoCount, VkGraphicsPipelineCreateInfo* pCreateInfos, VkAllocationCallbacks* pAllocator, IntPtr* pPipelines);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateFramebuffer(IntPtr device, VkFramebufferCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pFramebuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyFramebuffer(IntPtr device, IntPtr framebuffer, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateRenderPass(IntPtr device, VkRenderPassCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pRenderPass);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyRenderPass(IntPtr device, IntPtr renderPass, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetRenderAreaGranularity(IntPtr device, IntPtr renderPass, VkExtent2D* pGranularity);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetViewport(IntPtr commandBuffer, uint firstViewport, uint viewportCount, VkViewport* pViewports);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetScissor(IntPtr commandBuffer, uint firstScissor, uint scissorCount, VkRect2D* pScissors);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetLineWidth(IntPtr commandBuffer, float lineWidth);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthBias(IntPtr commandBuffer, float depthBiasConstantFactor, float depthBiasClamp, float depthBiasSlopeFactor);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetBlendConstants(IntPtr commandBuffer, float* blendConstants);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthBounds(IntPtr commandBuffer, float minDepthBounds, float maxDepthBounds);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetStencilCompareMask(IntPtr commandBuffer, uint faceMask, uint compareMask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetStencilWriteMask(IntPtr commandBuffer, uint faceMask, uint writeMask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetStencilReference(IntPtr commandBuffer, uint faceMask, uint reference);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindIndexBuffer(IntPtr commandBuffer, IntPtr buffer, ulong offset, VkIndexType indexType);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindVertexBuffers(IntPtr commandBuffer, uint firstBinding, uint bindingCount, IntPtr* pBuffers, ulong* pOffsets);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDraw(IntPtr commandBuffer, uint vertexCount, uint instanceCount, uint firstVertex, uint firstInstance);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndexed(IntPtr commandBuffer, uint indexCount, uint instanceCount, uint firstIndex, int vertexOffset, uint firstInstance);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndirect(IntPtr commandBuffer, IntPtr buffer, ulong offset, uint drawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndexedIndirect(IntPtr commandBuffer, IntPtr buffer, ulong offset, uint drawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBlitImage(IntPtr commandBuffer, IntPtr srcImage, VkImageLayout srcImageLayout, IntPtr dstImage, VkImageLayout dstImageLayout, uint regionCount, VkImageBlit* pRegions, VkFilter filter);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdClearDepthStencilImage(IntPtr commandBuffer, IntPtr image, VkImageLayout imageLayout, VkClearDepthStencilValue* pDepthStencil, uint rangeCount, VkImageSubresourceRange* pRanges);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdClearAttachments(IntPtr commandBuffer, uint attachmentCount, VkClearAttachment* pAttachments, uint rectCount, VkClearRect* pRects);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdResolveImage(IntPtr commandBuffer, IntPtr srcImage, VkImageLayout srcImageLayout, IntPtr dstImage, VkImageLayout dstImageLayout, uint regionCount, VkImageResolve* pRegions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginRenderPass(IntPtr commandBuffer, VkRenderPassBeginInfo* pRenderPassBegin, VkSubpassContents contents);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdNextSubpass(IntPtr commandBuffer, VkSubpassContents contents);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndRenderPass(IntPtr commandBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumerateInstanceVersion(uint* pApiVersion);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindBufferMemory2(IntPtr device, uint bindInfoCount, VkBindBufferMemoryInfo* pBindInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindImageMemory2(IntPtr device, uint bindInfoCount, VkBindImageMemoryInfo* pBindInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceGroupPeerMemoryFeatures(IntPtr device, uint heapIndex, uint localDeviceIndex, uint remoteDeviceIndex, uint* pPeerMemoryFeatures);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDeviceMask(IntPtr commandBuffer, uint deviceMask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumeratePhysicalDeviceGroups(IntPtr instance, uint* pPhysicalDeviceGroupCount, VkPhysicalDeviceGroupProperties* pPhysicalDeviceGroupProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetImageMemoryRequirements2(IntPtr device, VkImageMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetBufferMemoryRequirements2(IntPtr device, VkBufferMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetImageSparseMemoryRequirements2(IntPtr device, VkImageSparseMemoryRequirementsInfo2* pInfo, uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceFeatures2(IntPtr physicalDevice, VkPhysicalDeviceFeatures2* pFeatures);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceProperties2(IntPtr physicalDevice, VkPhysicalDeviceProperties2* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceFormatProperties2(IntPtr physicalDevice, VkFormat format, VkFormatProperties2* pFormatProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceImageFormatProperties2(IntPtr physicalDevice, VkPhysicalDeviceImageFormatInfo2* pImageFormatInfo, VkImageFormatProperties2* pImageFormatProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceQueueFamilyProperties2(IntPtr physicalDevice, uint* pQueueFamilyPropertyCount, VkQueueFamilyProperties2* pQueueFamilyProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceMemoryProperties2(IntPtr physicalDevice, VkPhysicalDeviceMemoryProperties2* pMemoryProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceSparseImageFormatProperties2(IntPtr physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2* pFormatInfo, uint* pPropertyCount, VkSparseImageFormatProperties2* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkTrimCommandPool(IntPtr device, IntPtr commandPool, uint flags);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceQueue2(IntPtr device, VkDeviceQueueInfo2* pQueueInfo, IntPtr* pQueue);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceExternalBufferProperties(IntPtr physicalDevice, VkPhysicalDeviceExternalBufferInfo* pExternalBufferInfo, VkExternalBufferProperties* pExternalBufferProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceExternalFenceProperties(IntPtr physicalDevice, VkPhysicalDeviceExternalFenceInfo* pExternalFenceInfo, VkExternalFenceProperties* pExternalFenceProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceExternalSemaphoreProperties(IntPtr physicalDevice, VkPhysicalDeviceExternalSemaphoreInfo* pExternalSemaphoreInfo, VkExternalSemaphoreProperties* pExternalSemaphoreProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDispatchBase(IntPtr commandBuffer, uint baseGroupX, uint baseGroupY, uint baseGroupZ, uint groupCountX, uint groupCountY, uint groupCountZ);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDescriptorUpdateTemplate(IntPtr device, VkDescriptorUpdateTemplateCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pDescriptorUpdateTemplate);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyDescriptorUpdateTemplate(IntPtr device, IntPtr descriptorUpdateTemplate, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkUpdateDescriptorSetWithTemplate(IntPtr device, IntPtr descriptorSet, IntPtr descriptorUpdateTemplate, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDescriptorSetLayoutSupport(IntPtr device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkDescriptorSetLayoutSupport* pSupport);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateSamplerYcbcrConversion(IntPtr device, VkSamplerYcbcrConversionCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pYcbcrConversion);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroySamplerYcbcrConversion(IntPtr device, IntPtr ycbcrConversion, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkResetQueryPool(IntPtr device, IntPtr queryPool, uint firstQuery, uint queryCount);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetSemaphoreCounterValue(IntPtr device, IntPtr semaphore, ulong* pValue);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkWaitSemaphores(IntPtr device, VkSemaphoreWaitInfo* pWaitInfo, ulong timeout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkSignalSemaphore(IntPtr device, VkSemaphoreSignalInfo* pSignalInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetBufferDeviceAddress(IntPtr device, VkBufferDeviceAddressInfo* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetBufferOpaqueCaptureAddress(IntPtr device, VkBufferDeviceAddressInfo* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetDeviceMemoryOpaqueCaptureAddress(IntPtr device, VkDeviceMemoryOpaqueCaptureAddressInfo* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndirectCount(IntPtr commandBuffer, IntPtr buffer, ulong offset, IntPtr countBuffer, ulong countBufferOffset, uint maxDrawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndexedIndirectCount(IntPtr commandBuffer, IntPtr buffer, ulong offset, IntPtr countBuffer, ulong countBufferOffset, uint maxDrawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateRenderPass2(IntPtr device, VkRenderPassCreateInfo2* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pRenderPass);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginRenderPass2(IntPtr commandBuffer, VkRenderPassBeginInfo* pRenderPassBegin, VkSubpassBeginInfo* pSubpassBeginInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdNextSubpass2(IntPtr commandBuffer, VkSubpassBeginInfo* pSubpassBeginInfo, VkSubpassEndInfo* pSubpassEndInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndRenderPass2(IntPtr commandBuffer, VkSubpassEndInfo* pSubpassEndInfo);

        public const ulong VK_PIPELINE_STAGE_2_NONE = 0UL;

        public const ulong VK_PIPELINE_STAGE_2OP_OF_PIPE_BIT = 0x00000001UL;

        public const ulong VK_PIPELINE_STAGE_2_DRAW_INDIRECT_BIT = 0x00000002UL;

        public const ulong VK_PIPELINE_STAGE_2_VERTEX_INPUT_BIT = 0x00000004UL;

        public const ulong VK_PIPELINE_STAGE_2_VERTEX_SHADER_BIT = 0x00000008UL;

        public const ulong VK_PIPELINE_STAGE_2ESSELLATION_CONTROL_SHADER_BIT = 0x00000010UL;

        public const ulong VK_PIPELINE_STAGE_2ESSELLATION_EVALUATION_SHADER_BIT = 0x00000020UL;

        public const ulong VK_PIPELINE_STAGE_2_GEOMETRY_SHADER_BIT = 0x00000040UL;

        public const ulong VK_PIPELINE_STAGE_2_FRAGMENT_SHADER_BIT = 0x00000080UL;

        public const ulong VK_PIPELINE_STAGE_2_EARLY_FRAGMENTESTS_BIT = 0x00000100UL;

        public const ulong VK_PIPELINE_STAGE_2_LATE_FRAGMENTESTS_BIT = 0x00000200UL;

        public const ulong VK_PIPELINE_STAGE_2_COLOR_ATTACHMENT_OUTPUT_BIT = 0x00000400UL;

        public const ulong VK_PIPELINE_STAGE_2_COMPUTE_SHADER_BIT = 0x00000800UL;

        public const ulong VK_PIPELINE_STAGE_2_ALLRANSFER_BIT = 0x00001000UL;

        public const ulong VK_PIPELINE_STAGE_2RANSFER_BIT = 0x00001000UL;

        public const ulong VK_PIPELINE_STAGE_2_BOTTOM_OF_PIPE_BIT = 0x00002000UL;

        public const ulong VK_PIPELINE_STAGE_2_HOST_BIT = 0x00004000UL;

        public const ulong VK_PIPELINE_STAGE_2_ALL_GRAPHICS_BIT = 0x00008000UL;

        public const ulong VK_PIPELINE_STAGE_2_ALL_COMMANDS_BIT = 0x00010000UL;

        public const ulong VK_PIPELINE_STAGE_2_COPY_BIT = 0x100000000UL;

        public const ulong VK_PIPELINE_STAGE_2_RESOLVE_BIT = 0x200000000UL;

        public const ulong VK_PIPELINE_STAGE_2_BLIT_BIT = 0x400000000UL;

        public const ulong VK_PIPELINE_STAGE_2_CLEAR_BIT = 0x800000000UL;

        public const ulong VK_PIPELINE_STAGE_2_INDEX_INPUT_BIT = 0x1000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_VERTEX_ATTRIBUTE_INPUT_BIT = 0x2000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_PRE_RASTERIZATION_SHADERS_BIT = 0x4000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_VIDEO_DECODE_BIT_KHR = 0x04000000UL;

        public const ulong VK_PIPELINE_STAGE_2_VIDEO_ENCODE_BIT_KHR = 0x08000000UL;

        public const ulong VK_PIPELINE_STAGE_2_NONE_KHR = 0UL;

        public const ulong VK_PIPELINE_STAGE_2OP_OF_PIPE_BIT_KHR = 0x00000001UL;

        public const ulong VK_PIPELINE_STAGE_2_DRAW_INDIRECT_BIT_KHR = 0x00000002UL;

        public const ulong VK_PIPELINE_STAGE_2_VERTEX_INPUT_BIT_KHR = 0x00000004UL;

        public const ulong VK_PIPELINE_STAGE_2_VERTEX_SHADER_BIT_KHR = 0x00000008UL;

        public const ulong VK_PIPELINE_STAGE_2ESSELLATION_CONTROL_SHADER_BIT_KHR = 0x00000010UL;

        public const ulong VK_PIPELINE_STAGE_2ESSELLATION_EVALUATION_SHADER_BIT_KHR = 0x00000020UL;

        public const ulong VK_PIPELINE_STAGE_2_GEOMETRY_SHADER_BIT_KHR = 0x00000040UL;

        public const ulong VK_PIPELINE_STAGE_2_FRAGMENT_SHADER_BIT_KHR = 0x00000080UL;

        public const ulong VK_PIPELINE_STAGE_2_EARLY_FRAGMENTESTS_BIT_KHR = 0x00000100UL;

        public const ulong VK_PIPELINE_STAGE_2_LATE_FRAGMENTESTS_BIT_KHR = 0x00000200UL;

        public const ulong VK_PIPELINE_STAGE_2_COLOR_ATTACHMENT_OUTPUT_BIT_KHR = 0x00000400UL;

        public const ulong VK_PIPELINE_STAGE_2_COMPUTE_SHADER_BIT_KHR = 0x00000800UL;

        public const ulong VK_PIPELINE_STAGE_2_ALLRANSFER_BIT_KHR = 0x00001000UL;

        public const ulong VK_PIPELINE_STAGE_2RANSFER_BIT_KHR = 0x00001000UL;

        public const ulong VK_PIPELINE_STAGE_2_BOTTOM_OF_PIPE_BIT_KHR = 0x00002000UL;

        public const ulong VK_PIPELINE_STAGE_2_HOST_BIT_KHR = 0x00004000UL;

        public const ulong VK_PIPELINE_STAGE_2_ALL_GRAPHICS_BIT_KHR = 0x00008000UL;

        public const ulong VK_PIPELINE_STAGE_2_ALL_COMMANDS_BIT_KHR = 0x00010000UL;

        public const ulong VK_PIPELINE_STAGE_2_COPY_BIT_KHR = 0x100000000UL;

        public const ulong VK_PIPELINE_STAGE_2_RESOLVE_BIT_KHR = 0x200000000UL;

        public const ulong VK_PIPELINE_STAGE_2_BLIT_BIT_KHR = 0x400000000UL;

        public const ulong VK_PIPELINE_STAGE_2_CLEAR_BIT_KHR = 0x800000000UL;

        public const ulong VK_PIPELINE_STAGE_2_INDEX_INPUT_BIT_KHR = 0x1000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_VERTEX_ATTRIBUTE_INPUT_BIT_KHR = 0x2000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_PRE_RASTERIZATION_SHADERS_BIT_KHR = 0x4000000000UL;

        public const ulong VK_PIPELINE_STAGE_2RANSFORM_FEEDBACK_BIT_EXT = 0x01000000UL;

        public const ulong VK_PIPELINE_STAGE_2_CONDITIONAL_RENDERING_BIT_EXT = 0x00040000UL;

        public const ulong VK_PIPELINE_STAGE_2_COMMAND_PREPROCESS_BIT_NV = 0x00020000UL;

        public const ulong VK_PIPELINE_STAGE_2_COMMAND_PREPROCESS_BIT_EXT = 0x00020000UL;

        public const ulong VK_PIPELINE_STAGE_2_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x00400000UL;

        public const ulong VK_PIPELINE_STAGE_2_SHADING_RATE_IMAGE_BIT_NV = 0x00400000UL;

        public const ulong VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_BUILD_BIT_KHR = 0x02000000UL;

        public const ulong VK_PIPELINE_STAGE_2_RAYRACING_SHADER_BIT_KHR = 0x00200000UL;

        public const ulong VK_PIPELINE_STAGE_2_RAYRACING_SHADER_BIT_NV = 0x00200000UL;

        public const ulong VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_BUILD_BIT_NV = 0x02000000UL;

        public const ulong VK_PIPELINE_STAGE_2_FRAGMENT_DENSITY_PROCESS_BIT_EXT = 0x00800000UL;

        public const ulong VK_PIPELINE_STAGE_2ASK_SHADER_BIT_NV = 0x00080000UL;

        public const ulong VK_PIPELINE_STAGE_2_MESH_SHADER_BIT_NV = 0x00100000UL;

        public const ulong VK_PIPELINE_STAGE_2ASK_SHADER_BIT_EXT = 0x00080000UL;

        public const ulong VK_PIPELINE_STAGE_2_MESH_SHADER_BIT_EXT = 0x00100000UL;

        public const ulong VK_PIPELINE_STAGE_2_SUBPASS_SHADER_BIT_HUAWEI = 0x8000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_SUBPASS_SHADING_BIT_HUAWEI = 0x8000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_INVOCATION_MASK_BIT_HUAWEI = 0x10000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_ACCELERATION_STRUCTURE_COPY_BIT_KHR = 0x10000000UL;

        public const ulong VK_PIPELINE_STAGE_2_MICROMAP_BUILD_BIT_EXT = 0x40000000UL;

        public const ulong VK_PIPELINE_STAGE_2_CLUSTER_CULLING_SHADER_BIT_HUAWEI = 0x20000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_OPTICAL_FLOW_BIT_NV = 0x20000000UL;

        public const ulong VK_PIPELINE_STAGE_2_CONVERT_COOPERATIVE_VECTOR_MATRIX_BIT_NV = 0x100000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_DATA_GRAPH_BIT_ARM = 0x40000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_COPY_INDIRECT_BIT_KHR = 0x400000000000UL;

        public const ulong VK_PIPELINE_STAGE_2_MEMORY_DECOMPRESSION_BIT_EXT = 0x200000000000UL;

        public const ulong VK_ACCESS_2_NONE = 0UL;

        public const ulong VK_ACCESS_2_INDIRECT_COMMAND_READ_BIT = 0x00000001UL;

        public const ulong VK_ACCESS_2_INDEX_READ_BIT = 0x00000002UL;

        public const ulong VK_ACCESS_2_VERTEX_ATTRIBUTE_READ_BIT = 0x00000004UL;

        public const ulong VK_ACCESS_2_UNIFORM_READ_BIT = 0x00000008UL;

        public const ulong VK_ACCESS_2_INPUT_ATTACHMENT_READ_BIT = 0x00000010UL;

        public const ulong VK_ACCESS_2_SHADER_READ_BIT = 0x00000020UL;

        public const ulong VK_ACCESS_2_SHADER_WRITE_BIT = 0x00000040UL;

        public const ulong VK_ACCESS_2_COLOR_ATTACHMENT_READ_BIT = 0x00000080UL;

        public const ulong VK_ACCESS_2_COLOR_ATTACHMENT_WRITE_BIT = 0x00000100UL;

        public const ulong VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_READ_BIT = 0x00000200UL;

        public const ulong VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT = 0x00000400UL;

        public const ulong VK_ACCESS_2RANSFER_READ_BIT = 0x00000800UL;

        public const ulong VK_ACCESS_2RANSFER_WRITE_BIT = 0x00001000UL;

        public const ulong VK_ACCESS_2_HOST_READ_BIT = 0x00002000UL;

        public const ulong VK_ACCESS_2_HOST_WRITE_BIT = 0x00004000UL;

        public const ulong VK_ACCESS_2_MEMORY_READ_BIT = 0x00008000UL;

        public const ulong VK_ACCESS_2_MEMORY_WRITE_BIT = 0x00010000UL;

        public const ulong VK_ACCESS_2_SHADER_SAMPLED_READ_BIT = 0x100000000UL;

        public const ulong VK_ACCESS_2_SHADER_STORAGE_READ_BIT = 0x200000000UL;

        public const ulong VK_ACCESS_2_SHADER_STORAGE_WRITE_BIT = 0x400000000UL;

        public const ulong VK_ACCESS_2_VIDEO_DECODE_READ_BIT_KHR = 0x800000000UL;

        public const ulong VK_ACCESS_2_VIDEO_DECODE_WRITE_BIT_KHR = 0x1000000000UL;

        public const ulong VK_ACCESS_2_SAMPLER_HEAP_READ_BIT_EXT = 0x200000000000000UL;

        public const ulong VK_ACCESS_2_RESOURCE_HEAP_READ_BIT_EXT = 0x400000000000000UL;

        public const ulong VK_ACCESS_2_VIDEO_ENCODE_READ_BIT_KHR = 0x2000000000UL;

        public const ulong VK_ACCESS_2_VIDEO_ENCODE_WRITE_BIT_KHR = 0x4000000000UL;

        public const ulong VK_ACCESS_2_SHADERILE_ATTACHMENT_READ_BIT_QCOM = 0x8000000000000UL;

        public const ulong VK_ACCESS_2_SHADERILE_ATTACHMENT_WRITE_BIT_QCOM = 0x10000000000000UL;

        public const ulong VK_ACCESS_2_NONE_KHR = 0UL;

        public const ulong VK_ACCESS_2_INDIRECT_COMMAND_READ_BIT_KHR = 0x00000001UL;

        public const ulong VK_ACCESS_2_INDEX_READ_BIT_KHR = 0x00000002UL;

        public const ulong VK_ACCESS_2_VERTEX_ATTRIBUTE_READ_BIT_KHR = 0x00000004UL;

        public const ulong VK_ACCESS_2_UNIFORM_READ_BIT_KHR = 0x00000008UL;

        public const ulong VK_ACCESS_2_INPUT_ATTACHMENT_READ_BIT_KHR = 0x00000010UL;

        public const ulong VK_ACCESS_2_SHADER_READ_BIT_KHR = 0x00000020UL;

        public const ulong VK_ACCESS_2_SHADER_WRITE_BIT_KHR = 0x00000040UL;

        public const ulong VK_ACCESS_2_COLOR_ATTACHMENT_READ_BIT_KHR = 0x00000080UL;

        public const ulong VK_ACCESS_2_COLOR_ATTACHMENT_WRITE_BIT_KHR = 0x00000100UL;

        public const ulong VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_READ_BIT_KHR = 0x00000200UL;

        public const ulong VK_ACCESS_2_DEPTH_STENCIL_ATTACHMENT_WRITE_BIT_KHR = 0x00000400UL;

        public const ulong VK_ACCESS_2RANSFER_READ_BIT_KHR = 0x00000800UL;

        public const ulong VK_ACCESS_2RANSFER_WRITE_BIT_KHR = 0x00001000UL;

        public const ulong VK_ACCESS_2_HOST_READ_BIT_KHR = 0x00002000UL;

        public const ulong VK_ACCESS_2_HOST_WRITE_BIT_KHR = 0x00004000UL;

        public const ulong VK_ACCESS_2_MEMORY_READ_BIT_KHR = 0x00008000UL;

        public const ulong VK_ACCESS_2_MEMORY_WRITE_BIT_KHR = 0x00010000UL;

        public const ulong VK_ACCESS_2_SHADER_SAMPLED_READ_BIT_KHR = 0x100000000UL;

        public const ulong VK_ACCESS_2_SHADER_STORAGE_READ_BIT_KHR = 0x200000000UL;

        public const ulong VK_ACCESS_2_SHADER_STORAGE_WRITE_BIT_KHR = 0x400000000UL;

        public const ulong VK_ACCESS_2RANSFORM_FEEDBACK_WRITE_BIT_EXT = 0x02000000UL;

        public const ulong VK_ACCESS_2RANSFORM_FEEDBACK_COUNTER_READ_BIT_EXT = 0x04000000UL;

        public const ulong VK_ACCESS_2RANSFORM_FEEDBACK_COUNTER_WRITE_BIT_EXT = 0x08000000UL;

        public const ulong VK_ACCESS_2_CONDITIONAL_RENDERING_READ_BIT_EXT = 0x00100000UL;

        public const ulong VK_ACCESS_2_COMMAND_PREPROCESS_READ_BIT_NV = 0x00020000UL;

        public const ulong VK_ACCESS_2_COMMAND_PREPROCESS_WRITE_BIT_NV = 0x00040000UL;

        public const ulong VK_ACCESS_2_COMMAND_PREPROCESS_READ_BIT_EXT = 0x00020000UL;

        public const ulong VK_ACCESS_2_COMMAND_PREPROCESS_WRITE_BIT_EXT = 0x00040000UL;

        public const ulong VK_ACCESS_2_FRAGMENT_SHADING_RATE_ATTACHMENT_READ_BIT_KHR = 0x00800000UL;

        public const ulong VK_ACCESS_2_SHADING_RATE_IMAGE_READ_BIT_NV = 0x00800000UL;

        public const ulong VK_ACCESS_2_ACCELERATION_STRUCTURE_READ_BIT_KHR = 0x00200000UL;

        public const ulong VK_ACCESS_2_ACCELERATION_STRUCTURE_WRITE_BIT_KHR = 0x00400000UL;

        public const ulong VK_ACCESS_2_ACCELERATION_STRUCTURE_READ_BIT_NV = 0x00200000UL;

        public const ulong VK_ACCESS_2_ACCELERATION_STRUCTURE_WRITE_BIT_NV = 0x00400000UL;

        public const ulong VK_ACCESS_2_FRAGMENT_DENSITY_MAP_READ_BIT_EXT = 0x01000000UL;

        public const ulong VK_ACCESS_2_COLOR_ATTACHMENT_READ_NONCOHERENT_BIT_EXT = 0x00080000UL;

        public const ulong VK_ACCESS_2_DESCRIPTOR_BUFFER_READ_BIT_EXT = 0x20000000000UL;

        public const ulong VK_ACCESS_2_INVOCATION_MASK_READ_BIT_HUAWEI = 0x8000000000UL;

        public const ulong VK_ACCESS_2_SHADER_BINDINGABLE_READ_BIT_KHR = 0x10000000000UL;

        public const ulong VK_ACCESS_2_MICROMAP_READ_BIT_EXT = 0x100000000000UL;

        public const ulong VK_ACCESS_2_MICROMAP_WRITE_BIT_EXT = 0x200000000000UL;

        public const ulong VK_ACCESS_2_OPTICAL_FLOW_READ_BIT_NV = 0x40000000000UL;

        public const ulong VK_ACCESS_2_OPTICAL_FLOW_WRITE_BIT_NV = 0x80000000000UL;

        public const ulong VK_ACCESS_2_DATA_GRAPH_READ_BIT_ARM = 0x800000000000UL;

        public const ulong VK_ACCESS_2_DATA_GRAPH_WRITE_BIT_ARM = 0x1000000000000UL;

        public const ulong VK_ACCESS_2_MEMORY_DECOMPRESSION_READ_BIT_EXT = 0x80000000000000UL;

        public const ulong VK_ACCESS_2_MEMORY_DECOMPRESSION_WRITE_BIT_EXT = 0x100000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_BIT = 0x00000001UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGE_IMAGE_BIT = 0x00000002UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGE_IMAGE_ATOMIC_BIT = 0x00000004UL;

        public const ulong VK_FORMAT_FEATURE_2_UNIFORMEXEL_BUFFER_BIT = 0x00000008UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGEEXEL_BUFFER_BIT = 0x00000010UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGEEXEL_BUFFER_ATOMIC_BIT = 0x00000020UL;

        public const ulong VK_FORMAT_FEATURE_2_VERTEX_BUFFER_BIT = 0x00000040UL;

        public const ulong VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BIT = 0x00000080UL;

        public const ulong VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BLEND_BIT = 0x00000100UL;

        public const ulong VK_FORMAT_FEATURE_2_DEPTH_STENCIL_ATTACHMENT_BIT = 0x00000200UL;

        public const ulong VK_FORMAT_FEATURE_2_BLIT_SRC_BIT = 0x00000400UL;

        public const ulong VK_FORMAT_FEATURE_2_BLIT_DST_BIT = 0x00000800UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_LINEAR_BIT = 0x00001000UL;

        public const ulong VK_FORMAT_FEATURE_2RANSFER_SRC_BIT = 0x00004000UL;

        public const ulong VK_FORMAT_FEATURE_2RANSFER_DST_BIT = 0x00008000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_MINMAX_BIT = 0x00010000UL;

        public const ulong VK_FORMAT_FEATURE_2_MIDPOINT_CHROMA_SAMPLES_BIT = 0x00020000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_LINEAR_FILTER_BIT = 0x00040000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_SEPARATE_RECONSTRUCTION_FILTER_BIT = 0x00080000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_BIT = 0x00100000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_FORCEABLE_BIT = 0x00200000UL;

        public const ulong VK_FORMAT_FEATURE_2_DISJOINT_BIT = 0x00400000UL;

        public const ulong VK_FORMAT_FEATURE_2_COSITED_CHROMA_SAMPLES_BIT = 0x00800000UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGE_READ_WITHOUT_FORMAT_BIT = 0x80000000UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGE_WRITE_WITHOUT_FORMAT_BIT = 0x100000000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_DEPTH_COMPARISON_BIT = 0x200000000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_CUBIC_BIT = 0x00002000UL;

        public const ulong VK_FORMAT_FEATURE_2_HOST_IMAGERANSFER_BIT = 0x400000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_VIDEO_DECODE_OUTPUT_BIT_KHR = 0x02000000UL;

        public const ulong VK_FORMAT_FEATURE_2_VIDEO_DECODE_DPB_BIT_KHR = 0x04000000UL;

        public const ulong VK_FORMAT_FEATURE_2_ACCELERATION_STRUCTURE_VERTEX_BUFFER_BIT_KHR = 0x20000000UL;

        public const ulong VK_FORMAT_FEATURE_2_FRAGMENT_DENSITY_MAP_BIT_EXT = 0x01000000UL;

        public const ulong VK_FORMAT_FEATURE_2_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x40000000UL;

        public const ulong VK_FORMAT_FEATURE_2_HOST_IMAGERANSFER_BIT_EXT = 0x400000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_VIDEO_ENCODE_INPUT_BIT_KHR = 0x08000000UL;

        public const ulong VK_FORMAT_FEATURE_2_VIDEO_ENCODE_DPB_BIT_KHR = 0x10000000UL;

        public const ulong VK_FORMAT_FEATURE_2_BLOCK_MATCHING_SXD_BIT_QCOM = 0x100000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_BIT_KHR = 0x00000001UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGE_IMAGE_BIT_KHR = 0x00000002UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGE_IMAGE_ATOMIC_BIT_KHR = 0x00000004UL;

        public const ulong VK_FORMAT_FEATURE_2_UNIFORMEXEL_BUFFER_BIT_KHR = 0x00000008UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGEEXEL_BUFFER_BIT_KHR = 0x00000010UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGEEXEL_BUFFER_ATOMIC_BIT_KHR = 0x00000020UL;

        public const ulong VK_FORMAT_FEATURE_2_VERTEX_BUFFER_BIT_KHR = 0x00000040UL;

        public const ulong VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BIT_KHR = 0x00000080UL;

        public const ulong VK_FORMAT_FEATURE_2_COLOR_ATTACHMENT_BLEND_BIT_KHR = 0x00000100UL;

        public const ulong VK_FORMAT_FEATURE_2_DEPTH_STENCIL_ATTACHMENT_BIT_KHR = 0x00000200UL;

        public const ulong VK_FORMAT_FEATURE_2_BLIT_SRC_BIT_KHR = 0x00000400UL;

        public const ulong VK_FORMAT_FEATURE_2_BLIT_DST_BIT_KHR = 0x00000800UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_LINEAR_BIT_KHR = 0x00001000UL;

        public const ulong VK_FORMAT_FEATURE_2RANSFER_SRC_BIT_KHR = 0x00004000UL;

        public const ulong VK_FORMAT_FEATURE_2RANSFER_DST_BIT_KHR = 0x00008000UL;

        public const ulong VK_FORMAT_FEATURE_2_MIDPOINT_CHROMA_SAMPLES_BIT_KHR = 0x00020000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_LINEAR_FILTER_BIT_KHR = 0x00040000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_SEPARATE_RECONSTRUCTION_FILTER_BIT_KHR = 0x00080000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_BIT_KHR = 0x00100000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_YCBCR_CONVERSION_CHROMA_RECONSTRUCTION_EXPLICIT_FORCEABLE_BIT_KHR = 0x00200000UL;

        public const ulong VK_FORMAT_FEATURE_2_DISJOINT_BIT_KHR = 0x00400000UL;

        public const ulong VK_FORMAT_FEATURE_2_COSITED_CHROMA_SAMPLES_BIT_KHR = 0x00800000UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGE_READ_WITHOUT_FORMAT_BIT_KHR = 0x80000000UL;

        public const ulong VK_FORMAT_FEATURE_2_STORAGE_WRITE_WITHOUT_FORMAT_BIT_KHR = 0x100000000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_DEPTH_COMPARISON_BIT_KHR = 0x200000000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_MINMAX_BIT_KHR = 0x00010000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_CUBIC_BIT_EXT = 0x00002000UL;

        public const ulong VK_FORMAT_FEATURE_2_ACCELERATION_STRUCTURE_RADIUS_BUFFER_BIT_NV = 0x8000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_LINEAR_COLOR_ATTACHMENT_BIT_NV = 0x4000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_WEIGHT_IMAGE_BIT_QCOM = 0x400000000UL;

        public const ulong VK_FORMAT_FEATURE_2_WEIGHT_SAMPLED_IMAGE_BIT_QCOM = 0x800000000UL;

        public const ulong VK_FORMAT_FEATURE_2_BLOCK_MATCHING_BIT_QCOM = 0x1000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_BOX_FILTER_SAMPLED_BIT_QCOM = 0x2000000000UL;

        public const ulong VK_FORMAT_FEATURE_2ENSOR_SHADER_BIT_ARM = 0x8000000000UL;

        public const ulong VK_FORMAT_FEATURE_2ENSOR_IMAGE_ALIASING_BIT_ARM = 0x80000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_OPTICAL_FLOW_IMAGE_BIT_NV = 0x10000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_OPTICAL_FLOW_VECTOR_BIT_NV = 0x20000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_OPTICAL_FLOW_COST_BIT_NV = 0x40000000000UL;

        public const ulong VK_FORMAT_FEATURE_2ENSOR_DATA_GRAPH_BIT_ARM = 0x1000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_COPY_IMAGE_INDIRECT_DST_BIT_KHR = 0x800000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_VIDEO_ENCODE_QUANTIZATION_DELTA_MAP_BIT_KHR = 0x2000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_VIDEO_ENCODE_EMPHASIS_MAP_BIT_KHR = 0x4000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_SAMPLED_IMAGE_FILTER_LINEAR_2D_BIT_IMG = 0x200000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_DEPTH_COPY_ON_COMPUTE_QUEUE_BIT_KHR = 0x10000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_DEPTH_COPY_ONRANSFER_QUEUE_BIT_KHR = 0x20000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_STENCIL_COPY_ON_COMPUTE_QUEUE_BIT_KHR = 0x40000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_STENCIL_COPY_ONRANSFER_QUEUE_BIT_KHR = 0x80000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_DATA_GRAPH_OPTICAL_FLOW_IMAGE_BIT_ARM = 0x100000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_DATA_GRAPH_OPTICAL_FLOW_VECTOR_BIT_ARM = 0x200000000000000UL;

        public const ulong VK_FORMAT_FEATURE_2_DATA_GRAPH_OPTICAL_FLOW_COST_BIT_ARM = 0x400000000000000UL;

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceToolProperties(IntPtr physicalDevice, uint* pToolCount, VkPhysicalDeviceToolProperties* pToolProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreatePrivateDataSlot(IntPtr device, VkPrivateDataSlotCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pPrivateDataSlot);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyPrivateDataSlot(IntPtr device, IntPtr privateDataSlot, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkSetPrivateData(IntPtr device, VkObjectType objectType, ulong objectHandle, IntPtr privateDataSlot, ulong data);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPrivateData(IntPtr device, VkObjectType objectType, ulong objectHandle, IntPtr privateDataSlot, ulong* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPipelineBarrier2(IntPtr commandBuffer, VkDependencyInfo* pDependencyInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWriteTimestamp2(IntPtr commandBuffer, ulong stage, IntPtr queryPool, uint query);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkQueueSubmit2(IntPtr queue, uint submitCount, VkSubmitInfo2* pSubmits, IntPtr fence);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyBuffer2(IntPtr commandBuffer, VkCopyBufferInfo2* pCopyBufferInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyImage2(IntPtr commandBuffer, VkCopyImageInfo2* pCopyImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyBufferToImage2(IntPtr commandBuffer, VkCopyBufferToImageInfo2* pCopyBufferToImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyImageToBuffer2(IntPtr commandBuffer, VkCopyImageToBufferInfo2* pCopyImageToBufferInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceBufferMemoryRequirements(IntPtr device, VkDeviceBufferMemoryRequirements* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceImageMemoryRequirements(IntPtr device, VkDeviceImageMemoryRequirements* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceImageSparseMemoryRequirements(IntPtr device, VkDeviceImageMemoryRequirements* pInfo, uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetEvent2(IntPtr commandBuffer, IntPtr @event, VkDependencyInfo* pDependencyInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdResetEvent2(IntPtr commandBuffer, IntPtr @event, ulong stageMask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWaitEvents2(IntPtr commandBuffer, uint eventCount, IntPtr* pEvents, VkDependencyInfo* pDependencyInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBlitImage2(IntPtr commandBuffer, VkBlitImageInfo2* pBlitImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdResolveImage2(IntPtr commandBuffer, VkResolveImageInfo2* pResolveImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginRendering(IntPtr commandBuffer, VkRenderingInfo* pRenderingInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndRendering(IntPtr commandBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetCullMode(IntPtr commandBuffer, uint cullMode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetFrontFace(IntPtr commandBuffer, VkFrontFace frontFace);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetPrimitiveTopology(IntPtr commandBuffer, VkPrimitiveTopology primitiveTopology);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetViewportWithCount(IntPtr commandBuffer, uint viewportCount, VkViewport* pViewports);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetScissorWithCount(IntPtr commandBuffer, uint scissorCount, VkRect2D* pScissors);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindVertexBuffers2(IntPtr commandBuffer, uint firstBinding, uint bindingCount, IntPtr* pBuffers, ulong* pOffsets, ulong* pSizes, ulong* pStrides);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthTestEnable(IntPtr commandBuffer, uint depthTestEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthWriteEnable(IntPtr commandBuffer, uint depthWriteEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthCompareOp(IntPtr commandBuffer, VkCompareOp depthCompareOp);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthBoundsTestEnable(IntPtr commandBuffer, uint depthBoundsTestEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetStencilTestEnable(IntPtr commandBuffer, uint stencilTestEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetStencilOp(IntPtr commandBuffer, uint faceMask, VkStencilOp failOp, VkStencilOp passOp, VkStencilOp depthFailOp, VkCompareOp compareOp);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetRasterizerDiscardEnable(IntPtr commandBuffer, uint rasterizerDiscardEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthBiasEnable(IntPtr commandBuffer, uint depthBiasEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetPrimitiveRestartEnable(IntPtr commandBuffer, uint primitiveRestartEnable);

        public const ulong VK_BUFFER_USAGE_2RANSFER_SRC_BIT = 0x00000001UL;

        public const ulong VK_BUFFER_USAGE_2RANSFER_DST_BIT = 0x00000002UL;

        public const ulong VK_BUFFER_USAGE_2_UNIFORMEXEL_BUFFER_BIT = 0x00000004UL;

        public const ulong VK_BUFFER_USAGE_2_STORAGEEXEL_BUFFER_BIT = 0x00000008UL;

        public const ulong VK_BUFFER_USAGE_2_UNIFORM_BUFFER_BIT = 0x00000010UL;

        public const ulong VK_BUFFER_USAGE_2_STORAGE_BUFFER_BIT = 0x00000020UL;

        public const ulong VK_BUFFER_USAGE_2_INDEX_BUFFER_BIT = 0x00000040UL;

        public const ulong VK_BUFFER_USAGE_2_VERTEX_BUFFER_BIT = 0x00000080UL;

        public const ulong VK_BUFFER_USAGE_2_INDIRECT_BUFFER_BIT = 0x00000100UL;

        public const ulong VK_BUFFER_USAGE_2_SHADER_DEVICE_ADDRESS_BIT = 0x00020000UL;

        public const ulong VK_BUFFER_USAGE_2_DESCRIPTOR_HEAP_BIT_EXT = 0x10000000UL;

        public const ulong VK_BUFFER_USAGE_2_MICROMAP_BUILD_INPUT_READ_ONLY_BIT_EXT = 0x00800000UL;

        public const ulong VK_BUFFER_USAGE_2_MICROMAP_STORAGE_BIT_EXT = 0x01000000UL;

        public const ulong VK_BUFFER_USAGE_2RANSFER_SRC_BIT_KHR = 0x00000001UL;

        public const ulong VK_BUFFER_USAGE_2RANSFER_DST_BIT_KHR = 0x00000002UL;

        public const ulong VK_BUFFER_USAGE_2_UNIFORMEXEL_BUFFER_BIT_KHR = 0x00000004UL;

        public const ulong VK_BUFFER_USAGE_2_STORAGEEXEL_BUFFER_BIT_KHR = 0x00000008UL;

        public const ulong VK_BUFFER_USAGE_2_UNIFORM_BUFFER_BIT_KHR = 0x00000010UL;

        public const ulong VK_BUFFER_USAGE_2_STORAGE_BUFFER_BIT_KHR = 0x00000020UL;

        public const ulong VK_BUFFER_USAGE_2_INDEX_BUFFER_BIT_KHR = 0x00000040UL;

        public const ulong VK_BUFFER_USAGE_2_VERTEX_BUFFER_BIT_KHR = 0x00000080UL;

        public const ulong VK_BUFFER_USAGE_2_INDIRECT_BUFFER_BIT_KHR = 0x00000100UL;

        public const ulong VK_BUFFER_USAGE_2_CONDITIONAL_RENDERING_BIT_EXT = 0x00000200UL;

        public const ulong VK_BUFFER_USAGE_2_SHADER_BINDINGABLE_BIT_KHR = 0x00000400UL;

        public const ulong VK_BUFFER_USAGE_2_RAYRACING_BIT_NV = 0x00000400UL;

        public const ulong VK_BUFFER_USAGE_2RANSFORM_FEEDBACK_BUFFER_BIT_EXT = 0x00000800UL;

        public const ulong VK_BUFFER_USAGE_2RANSFORM_FEEDBACK_COUNTER_BUFFER_BIT_EXT = 0x00001000UL;

        public const ulong VK_BUFFER_USAGE_2_VIDEO_DECODE_SRC_BIT_KHR = 0x00002000UL;

        public const ulong VK_BUFFER_USAGE_2_VIDEO_DECODE_DST_BIT_KHR = 0x00004000UL;

        public const ulong VK_BUFFER_USAGE_2_VIDEO_ENCODE_DST_BIT_KHR = 0x00008000UL;

        public const ulong VK_BUFFER_USAGE_2_VIDEO_ENCODE_SRC_BIT_KHR = 0x00010000UL;

        public const ulong VK_BUFFER_USAGE_2_SHADER_DEVICE_ADDRESS_BIT_KHR = 0x00020000UL;

        public const ulong VK_BUFFER_USAGE_2_ACCELERATION_STRUCTURE_BUILD_INPUT_READ_ONLY_BIT_KHR = 0x00080000UL;

        public const ulong VK_BUFFER_USAGE_2_ACCELERATION_STRUCTURE_STORAGE_BIT_KHR = 0x00100000UL;

        public const ulong VK_BUFFER_USAGE_2_SAMPLER_DESCRIPTOR_BUFFER_BIT_EXT = 0x00200000UL;

        public const ulong VK_BUFFER_USAGE_2_RESOURCE_DESCRIPTOR_BUFFER_BIT_EXT = 0x00400000UL;

        public const ulong VK_BUFFER_USAGE_2_PUSH_DESCRIPTORS_DESCRIPTOR_BUFFER_BIT_EXT = 0x04000000UL;

        public const ulong VK_BUFFER_USAGE_2_DATA_GRAPH_FOREIGN_DESCRIPTOR_BIT_ARM = 0x20000000UL;

        public const ulong VK_BUFFER_USAGE_2ILE_MEMORY_BIT_QCOM = 0x08000000UL;

        public const ulong VK_BUFFER_USAGE_2_MEMORY_DECOMPRESSION_BIT_EXT = 0x100000000UL;

        public const ulong VK_BUFFER_USAGE_2_PREPROCESS_BUFFER_BIT_EXT = 0x80000000UL;

        public const ulong VK_PIPELINE_CREATE_2_DISABLE_OPTIMIZATION_BIT = 0x00000001UL;

        public const ulong VK_PIPELINE_CREATE_2_ALLOW_DERIVATIVES_BIT = 0x00000002UL;

        public const ulong VK_PIPELINE_CREATE_2_DERIVATIVE_BIT = 0x00000004UL;

        public const ulong VK_PIPELINE_CREATE_2_VIEW_INDEX_FROM_DEVICE_INDEX_BIT = 0x00000008UL;

        public const ulong VK_PIPELINE_CREATE_2_DISPATCH_BASE_BIT = 0x00000010UL;

        public const ulong VK_PIPELINE_CREATE_2_FAIL_ON_PIPELINE_COMPILE_REQUIRED_BIT = 0x00000100UL;

        public const ulong VK_PIPELINE_CREATE_2_EARLY_RETURN_ON_FAILURE_BIT = 0x00000200UL;

        public const ulong VK_PIPELINE_CREATE_2_NO_PROTECTED_ACCESS_BIT = 0x08000000UL;

        public const ulong VK_PIPELINE_CREATE_2_PROTECTED_ACCESS_ONLY_BIT = 0x40000000UL;

        public const ulong VK_PIPELINE_CREATE_2_DESCRIPTOR_HEAP_BIT_EXT = 0x1000000000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_SKIP_BUILT_IN_PRIMITIVES_BIT_KHR = 0x00001000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_OPACITY_MICROMAP_BIT_EXT = 0x01000000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_ALLOW_SPHERES_AND_LINEAR_SWEPT_SPHERES_BIT_NV = 0x200000000UL;

        public const ulong VK_PIPELINE_CREATE_2_ENABLE_LEGACY_DITHERING_BIT_EXT = 0x400000000UL;

        public const ulong VK_PIPELINE_CREATE_2_DISABLE_OPTIMIZATION_BIT_KHR = 0x00000001UL;

        public const ulong VK_PIPELINE_CREATE_2_ALLOW_DERIVATIVES_BIT_KHR = 0x00000002UL;

        public const ulong VK_PIPELINE_CREATE_2_DERIVATIVE_BIT_KHR = 0x00000004UL;

        public const ulong VK_PIPELINE_CREATE_2_VIEW_INDEX_FROM_DEVICE_INDEX_BIT_KHR = 0x00000008UL;

        public const ulong VK_PIPELINE_CREATE_2_DISPATCH_BASE_BIT_KHR = 0x00000010UL;

        public const ulong VK_PIPELINE_CREATE_2_DEFER_COMPILE_BIT_NV = 0x00000020UL;

        public const ulong VK_PIPELINE_CREATE_2_CAPTURE_STATISTICS_BIT_KHR = 0x00000040UL;

        public const ulong VK_PIPELINE_CREATE_2_CAPTURE_INTERNAL_REPRESENTATIONS_BIT_KHR = 0x00000080UL;

        public const ulong VK_PIPELINE_CREATE_2_FAIL_ON_PIPELINE_COMPILE_REQUIRED_BIT_KHR = 0x00000100UL;

        public const ulong VK_PIPELINE_CREATE_2_EARLY_RETURN_ON_FAILURE_BIT_KHR = 0x00000200UL;

        public const ulong VK_PIPELINE_CREATE_2_LINKIME_OPTIMIZATION_BIT_EXT = 0x00000400UL;

        public const ulong VK_PIPELINE_CREATE_2_RETAIN_LINKIME_OPTIMIZATION_INFO_BIT_EXT = 0x00800000UL;

        public const ulong VK_PIPELINE_CREATE_2_LIBRARY_BIT_KHR = 0x00000800UL;

        public const ulong VK_PIPELINE_CREATE_2_RAY_TRACING_SKIPRIANGLES_BIT_KHR = 0x00001000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_SKIP_AABBS_BIT_KHR = 0x00002000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_NO_NULL_ANY_HIT_SHADERS_BIT_KHR = 0x00004000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_NO_NULL_CLOSEST_HIT_SHADERS_BIT_KHR = 0x00008000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_NO_NULL_MISS_SHADERS_BIT_KHR = 0x00010000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_NO_NULL_INTERSECTION_SHADERS_BIT_KHR = 0x00020000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_SHADER_GROUP_HANDLE_CAPTURE_REPLAY_BIT_KHR = 0x00080000UL;

        public const ulong VK_PIPELINE_CREATE_2_INDIRECT_BINDABLE_BIT_NV = 0x00040000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_ALLOW_MOTION_BIT_NV = 0x00100000UL;

        public const ulong VK_PIPELINE_CREATE_2_RENDERING_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x00200000UL;

        public const ulong VK_PIPELINE_CREATE_2_RENDERING_FRAGMENT_DENSITY_MAP_ATTACHMENT_BIT_EXT = 0x00400000UL;

        public const ulong VK_PIPELINE_CREATE_2_COLOR_ATTACHMENT_FEEDBACK_LOOP_BIT_EXT = 0x02000000UL;

        public const ulong VK_PIPELINE_CREATE_2_DEPTH_STENCIL_ATTACHMENT_FEEDBACK_LOOP_BIT_EXT = 0x04000000UL;

        public const ulong VK_PIPELINE_CREATE_2_NO_PROTECTED_ACCESS_BIT_EXT = 0x08000000UL;

        public const ulong VK_PIPELINE_CREATE_2_PROTECTED_ACCESS_ONLY_BIT_EXT = 0x40000000UL;

        public const ulong VK_PIPELINE_CREATE_2_DESCRIPTOR_BUFFER_BIT_EXT = 0x20000000UL;

        public const ulong VK_PIPELINE_CREATE_2_DISALLOW_OPACITY_MICROMAP_BIT_ARM = 0x2000000000UL;

        public const ulong VK_PIPELINE_CREATE_2_INSTRUMENT_SHADERS_BIT_ARM = 0x8000000000UL;

        public const ulong VK_PIPELINE_CREATE_2_CAPTURE_DATA_BIT_KHR = 0x80000000UL;

        public const ulong VK_PIPELINE_CREATE_2_INDIRECT_BINDABLE_BIT_EXT = 0x4000000000UL;

        public const ulong VK_PIPELINE_CREATE_2_PER_LAYER_FRAGMENT_DENSITY_BIT_VALVE = 0x10000000000UL;

        public const ulong VK_PIPELINE_CREATE_2_RAYRACING_OPACITY_MICROMAP_BIT_KHR = 0x01000000UL;

        public const ulong VK_PIPELINE_CREATE_2_OPACITY_MICROMAP_DISALLOW_MIXED_SPECIAL_INDEX_BIT_KHR = 0x20000000000UL;

        public const ulong VK_PIPELINE_CREATE_2_64_BIT_INDEXING_BIT_EXT = 0x80000000000UL;

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkMapMemory2(IntPtr device, VkMemoryMapInfo* pMemoryMapInfo, void** ppData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkUnmapMemory2(IntPtr device, VkMemoryUnmapInfo* pMemoryUnmapInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceImageSubresourceLayout(IntPtr device, VkDeviceImageSubresourceInfo* pInfo, VkSubresourceLayout2* pLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetImageSubresourceLayout2(IntPtr device, IntPtr image, VkImageSubresource2* pSubresource, VkSubresourceLayout2* pLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyMemoryToImage(IntPtr device, VkCopyMemoryToImageInfo* pCopyMemoryToImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyImageToMemory(IntPtr device, VkCopyImageToMemoryInfo* pCopyImageToMemoryInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyImageToImage(IntPtr device, VkCopyImageToImageInfo* pCopyImageToImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkTransitionImageLayout(IntPtr device, uint transitionCount, VkHostImageLayoutTransitionInfo* pTransitions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushDescriptorSet(IntPtr commandBuffer, VkPipelineBindPoint pipelineBindPoint, IntPtr layout, uint set, uint descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushDescriptorSetWithTemplate(IntPtr commandBuffer, IntPtr descriptorUpdateTemplate, IntPtr layout, uint set, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindDescriptorSets2(IntPtr commandBuffer, VkBindDescriptorSetsInfo* pBindDescriptorSetsInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushConstants2(IntPtr commandBuffer, VkPushConstantsInfo* pPushConstantsInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushDescriptorSet2(IntPtr commandBuffer, VkPushDescriptorSetInfo* pPushDescriptorSetInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushDescriptorSetWithTemplate2(IntPtr commandBuffer, VkPushDescriptorSetWithTemplateInfo* pPushDescriptorSetWithTemplateInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetLineStipple(IntPtr commandBuffer, uint lineStippleFactor, ushort lineStipplePattern);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindIndexBuffer2(IntPtr commandBuffer, IntPtr buffer, ulong offset, ulong size, VkIndexType indexType);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetRenderingAreaGranularity(IntPtr device, VkRenderingAreaInfo* pRenderingAreaInfo, VkExtent2D* pGranularity);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetRenderingAttachmentLocations(IntPtr commandBuffer, VkRenderingAttachmentLocationInfo* pLocationInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetRenderingInputAttachmentIndices(IntPtr commandBuffer, VkRenderingInputAttachmentIndexInfo* pInputAttachmentIndexInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroySurfaceKHR(IntPtr instance, IntPtr surface, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceSurfaceSupportKHR(IntPtr physicalDevice, uint queueFamilyIndex, IntPtr surface, uint* pSupported);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceSurfaceCapabilitiesKHR(IntPtr physicalDevice, IntPtr surface, VkSurfaceCapabilitiesKHR* pSurfaceCapabilities);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceSurfaceFormatsKHR(IntPtr physicalDevice, IntPtr surface, uint* pSurfaceFormatCount, VkSurfaceFormatKHR* pSurfaceFormats);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceSurfacePresentModesKHR(IntPtr physicalDevice, IntPtr surface, uint* pPresentModeCount, VkPresentModeKHR* pPresentModes);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateSwapchainKHR(IntPtr device, VkSwapchainCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSwapchain);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroySwapchainKHR(IntPtr device, IntPtr swapchain, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetSwapchainImagesKHR(IntPtr device, IntPtr swapchain, uint* pSwapchainImageCount, IntPtr* pSwapchainImages);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkAcquireNextImageKHR(IntPtr device, IntPtr swapchain, ulong timeout, IntPtr semaphore, IntPtr fence, uint* pImageIndex);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkQueuePresentKHR(IntPtr queue, VkPresentInfoKHR* pPresentInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDeviceGroupPresentCapabilitiesKHR(IntPtr device, VkDeviceGroupPresentCapabilitiesKHR* pDeviceGroupPresentCapabilities);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDeviceGroupSurfacePresentModesKHR(IntPtr device, IntPtr surface, uint* pModes);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDevicePresentRectanglesKHR(IntPtr physicalDevice, IntPtr surface, uint* pRectCount, VkRect2D* pRects);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkAcquireNextImage2KHR(IntPtr device, VkAcquireNextImageInfoKHR* pAcquireInfo, uint* pImageIndex);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceDisplayPropertiesKHR(IntPtr physicalDevice, uint* pPropertyCount, VkDisplayPropertiesKHR* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceDisplayPlanePropertiesKHR(IntPtr physicalDevice, uint* pPropertyCount, VkDisplayPlanePropertiesKHR* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDisplayPlaneSupportedDisplaysKHR(IntPtr physicalDevice, uint planeIndex, uint* pDisplayCount, IntPtr* pDisplays);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDisplayModePropertiesKHR(IntPtr physicalDevice, IntPtr display, uint* pPropertyCount, VkDisplayModePropertiesKHR* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDisplayModeKHR(IntPtr physicalDevice, IntPtr display, VkDisplayModeCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pMode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDisplayPlaneCapabilitiesKHR(IntPtr physicalDevice, IntPtr mode, uint planeIndex, VkDisplayPlaneCapabilitiesKHR* pCapabilities);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDisplayPlaneSurfaceKHR(IntPtr instance, VkDisplaySurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSurface);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateSharedSwapchainsKHR(IntPtr device, uint swapchainCount, VkSwapchainCreateInfoKHR* pCreateInfos, VkAllocationCallbacks* pAllocator, IntPtr* pSwapchains);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceVideoCapabilitiesKHR(IntPtr physicalDevice, VkVideoProfileInfoKHR* pVideoProfile, VkVideoCapabilitiesKHR* pCapabilities);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceVideoFormatPropertiesKHR(IntPtr physicalDevice, VkPhysicalDeviceVideoFormatInfoKHR* pVideoFormatInfo, uint* pVideoFormatPropertyCount, VkVideoFormatPropertiesKHR* pVideoFormatProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateVideoSessionKHR(IntPtr device, VkVideoSessionCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pVideoSession);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyVideoSessionKHR(IntPtr device, IntPtr videoSession, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetVideoSessionMemoryRequirementsKHR(IntPtr device, IntPtr videoSession, uint* pMemoryRequirementsCount, VkVideoSessionMemoryRequirementsKHR* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindVideoSessionMemoryKHR(IntPtr device, IntPtr videoSession, uint bindSessionMemoryInfoCount, VkBindVideoSessionMemoryInfoKHR* pBindSessionMemoryInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateVideoSessionParametersKHR(IntPtr device, VkVideoSessionParametersCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pVideoSessionParameters);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkUpdateVideoSessionParametersKHR(IntPtr device, IntPtr videoSessionParameters, VkVideoSessionParametersUpdateInfoKHR* pUpdateInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyVideoSessionParametersKHR(IntPtr device, IntPtr videoSessionParameters, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginVideoCodingKHR(IntPtr commandBuffer, VkVideoBeginCodingInfoKHR* pBeginInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndVideoCodingKHR(IntPtr commandBuffer, VkVideoEndCodingInfoKHR* pEndCodingInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdControlVideoCodingKHR(IntPtr commandBuffer, VkVideoCodingControlInfoKHR* pCodingControlInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDecodeVideoKHR(IntPtr commandBuffer, VkVideoDecodeInfoKHR* pDecodeInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginRenderingKHR(IntPtr commandBuffer, VkRenderingInfo* pRenderingInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndRenderingKHR(IntPtr commandBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceFeatures2KHR(IntPtr physicalDevice, VkPhysicalDeviceFeatures2* pFeatures);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceProperties2KHR(IntPtr physicalDevice, VkPhysicalDeviceProperties2* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceFormatProperties2KHR(IntPtr physicalDevice, VkFormat format, VkFormatProperties2* pFormatProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceImageFormatProperties2KHR(IntPtr physicalDevice, VkPhysicalDeviceImageFormatInfo2* pImageFormatInfo, VkImageFormatProperties2* pImageFormatProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceQueueFamilyProperties2KHR(IntPtr physicalDevice, uint* pQueueFamilyPropertyCount, VkQueueFamilyProperties2* pQueueFamilyProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceMemoryProperties2KHR(IntPtr physicalDevice, VkPhysicalDeviceMemoryProperties2* pMemoryProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceSparseImageFormatProperties2KHR(IntPtr physicalDevice, VkPhysicalDeviceSparseImageFormatInfo2* pFormatInfo, uint* pPropertyCount, VkSparseImageFormatProperties2* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceGroupPeerMemoryFeaturesKHR(IntPtr device, uint heapIndex, uint localDeviceIndex, uint remoteDeviceIndex, uint* pPeerMemoryFeatures);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDeviceMaskKHR(IntPtr commandBuffer, uint deviceMask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDispatchBaseKHR(IntPtr commandBuffer, uint baseGroupX, uint baseGroupY, uint baseGroupZ, uint groupCountX, uint groupCountY, uint groupCountZ);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkTrimCommandPoolKHR(IntPtr device, IntPtr commandPool, uint flags);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumeratePhysicalDeviceGroupsKHR(IntPtr instance, uint* pPhysicalDeviceGroupCount, VkPhysicalDeviceGroupProperties* pPhysicalDeviceGroupProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceExternalBufferPropertiesKHR(IntPtr physicalDevice, VkPhysicalDeviceExternalBufferInfo* pExternalBufferInfo, VkExternalBufferProperties* pExternalBufferProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetMemoryFdKHR(IntPtr device, VkMemoryGetFdInfoKHR* pGetFdInfo, int* pFd);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetMemoryFdPropertiesKHR(IntPtr device, VkExternalMemoryHandleTypeFlagBits handleType, int fd, VkMemoryFdPropertiesKHR* pMemoryFdProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceExternalSemaphorePropertiesKHR(IntPtr physicalDevice, VkPhysicalDeviceExternalSemaphoreInfo* pExternalSemaphoreInfo, VkExternalSemaphoreProperties* pExternalSemaphoreProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkImportSemaphoreFdKHR(IntPtr device, VkImportSemaphoreFdInfoKHR* pImportSemaphoreFdInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetSemaphoreFdKHR(IntPtr device, VkSemaphoreGetFdInfoKHR* pGetFdInfo, int* pFd);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushDescriptorSetKHR(IntPtr commandBuffer, VkPipelineBindPoint pipelineBindPoint, IntPtr layout, uint set, uint descriptorWriteCount, VkWriteDescriptorSet* pDescriptorWrites);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushDescriptorSetWithTemplateKHR(IntPtr commandBuffer, IntPtr descriptorUpdateTemplate, IntPtr layout, uint set, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDescriptorUpdateTemplateKHR(IntPtr device, VkDescriptorUpdateTemplateCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pDescriptorUpdateTemplate);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyDescriptorUpdateTemplateKHR(IntPtr device, IntPtr descriptorUpdateTemplate, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkUpdateDescriptorSetWithTemplateKHR(IntPtr device, IntPtr descriptorSet, IntPtr descriptorUpdateTemplate, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateRenderPass2KHR(IntPtr device, VkRenderPassCreateInfo2* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pRenderPass);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginRenderPass2KHR(IntPtr commandBuffer, VkRenderPassBeginInfo* pRenderPassBegin, VkSubpassBeginInfo* pSubpassBeginInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdNextSubpass2KHR(IntPtr commandBuffer, VkSubpassBeginInfo* pSubpassBeginInfo, VkSubpassEndInfo* pSubpassEndInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndRenderPass2KHR(IntPtr commandBuffer, VkSubpassEndInfo* pSubpassEndInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetSwapchainStatusKHR(IntPtr device, IntPtr swapchain);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceExternalFencePropertiesKHR(IntPtr physicalDevice, VkPhysicalDeviceExternalFenceInfo* pExternalFenceInfo, VkExternalFenceProperties* pExternalFenceProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkImportFenceFdKHR(IntPtr device, VkImportFenceFdInfoKHR* pImportFenceFdInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetFenceFdKHR(IntPtr device, VkFenceGetFdInfoKHR* pGetFdInfo, int* pFd);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumeratePhysicalDeviceQueueFamilyPerformanceQueryCountersKHR(IntPtr physicalDevice, uint queueFamilyIndex, uint* pCounterCount, VkPerformanceCounterKHR* pCounters, VkPerformanceCounterDescriptionKHR* pCounterDescriptions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceQueueFamilyPerformanceQueryPassesKHR(IntPtr physicalDevice, VkQueryPoolPerformanceCreateInfoKHR* pPerformanceQueryCreateInfo, uint* pNumPasses);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkAcquireProfilingLockKHR(IntPtr device, VkAcquireProfilingLockInfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkReleaseProfilingLockKHR(IntPtr device);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceSurfaceCapabilities2KHR(IntPtr physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, VkSurfaceCapabilities2KHR* pSurfaceCapabilities);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceSurfaceFormats2KHR(IntPtr physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, uint* pSurfaceFormatCount, VkSurfaceFormat2KHR* pSurfaceFormats);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceDisplayProperties2KHR(IntPtr physicalDevice, uint* pPropertyCount, VkDisplayProperties2KHR* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceDisplayPlaneProperties2KHR(IntPtr physicalDevice, uint* pPropertyCount, VkDisplayPlaneProperties2KHR* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDisplayModeProperties2KHR(IntPtr physicalDevice, IntPtr display, uint* pPropertyCount, VkDisplayModeProperties2KHR* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDisplayPlaneCapabilities2KHR(IntPtr physicalDevice, VkDisplayPlaneInfo2KHR* pDisplayPlaneInfo, VkDisplayPlaneCapabilities2KHR* pCapabilities);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetImageMemoryRequirements2KHR(IntPtr device, VkImageMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetBufferMemoryRequirements2KHR(IntPtr device, VkBufferMemoryRequirementsInfo2* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetImageSparseMemoryRequirements2KHR(IntPtr device, VkImageSparseMemoryRequirementsInfo2* pInfo, uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateSamplerYcbcrConversionKHR(IntPtr device, VkSamplerYcbcrConversionCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pYcbcrConversion);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroySamplerYcbcrConversionKHR(IntPtr device, IntPtr ycbcrConversion, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindBufferMemory2KHR(IntPtr device, uint bindInfoCount, VkBindBufferMemoryInfo* pBindInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindImageMemory2KHR(IntPtr device, uint bindInfoCount, VkBindImageMemoryInfo* pBindInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDescriptorSetLayoutSupportKHR(IntPtr device, VkDescriptorSetLayoutCreateInfo* pCreateInfo, VkDescriptorSetLayoutSupport* pSupport);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndirectCountKHR(IntPtr commandBuffer, IntPtr buffer, ulong offset, IntPtr countBuffer, ulong countBufferOffset, uint maxDrawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndexedIndirectCountKHR(IntPtr commandBuffer, IntPtr buffer, ulong offset, IntPtr countBuffer, ulong countBufferOffset, uint maxDrawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetSemaphoreCounterValueKHR(IntPtr device, IntPtr semaphore, ulong* pValue);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkWaitSemaphoresKHR(IntPtr device, VkSemaphoreWaitInfo* pWaitInfo, ulong timeout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkSignalSemaphoreKHR(IntPtr device, VkSemaphoreSignalInfo* pSignalInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceFragmentShadingRatesKHR(IntPtr physicalDevice, uint* pFragmentShadingRateCount, VkPhysicalDeviceFragmentShadingRateKHR* pFragmentShadingRates);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetFragmentShadingRateKHR(IntPtr commandBuffer, VkExtent2D* pFragmentSize, VkFragmentShadingRateCombinerOpKHR* combinerOps);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetRenderingAttachmentLocationsKHR(IntPtr commandBuffer, VkRenderingAttachmentLocationInfo* pLocationInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetRenderingInputAttachmentIndicesKHR(IntPtr commandBuffer, VkRenderingInputAttachmentIndexInfo* pInputAttachmentIndexInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkWaitForPresentKHR(IntPtr device, IntPtr swapchain, ulong presentId, ulong timeout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetBufferDeviceAddressKHR(IntPtr device, VkBufferDeviceAddressInfo* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetBufferOpaqueCaptureAddressKHR(IntPtr device, VkBufferDeviceAddressInfo* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetDeviceMemoryOpaqueCaptureAddressKHR(IntPtr device, VkDeviceMemoryOpaqueCaptureAddressInfo* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDeferredOperationKHR(IntPtr device, VkAllocationCallbacks* pAllocator, IntPtr* pDeferredOperation);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyDeferredOperationKHR(IntPtr device, IntPtr operation, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint vkGetDeferredOperationMaxConcurrencyKHR(IntPtr device, IntPtr operation);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDeferredOperationResultKHR(IntPtr device, IntPtr operation);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkDeferredOperationJoinKHR(IntPtr device, IntPtr operation);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPipelineExecutablePropertiesKHR(IntPtr device, VkPipelineInfoKHR* pPipelineInfo, uint* pExecutableCount, VkPipelineExecutablePropertiesKHR* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPipelineExecutableStatisticsKHR(IntPtr device, VkPipelineExecutableInfoKHR* pExecutableInfo, uint* pStatisticCount, VkPipelineExecutableStatisticKHR* pStatistics);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPipelineExecutableInternalRepresentationsKHR(IntPtr device, VkPipelineExecutableInfoKHR* pExecutableInfo, uint* pInternalRepresentationCount, VkPipelineExecutableInternalRepresentationKHR* pInternalRepresentations);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkMapMemory2KHR(IntPtr device, VkMemoryMapInfo* pMemoryMapInfo, void** ppData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkUnmapMemory2KHR(IntPtr device, VkMemoryUnmapInfo* pMemoryUnmapInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceVideoEncodeQualityLevelPropertiesKHR(IntPtr physicalDevice, VkPhysicalDeviceVideoEncodeQualityLevelInfoKHR* pQualityLevelInfo, VkVideoEncodeQualityLevelPropertiesKHR* pQualityLevelProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetEncodedVideoSessionParametersKHR(IntPtr device, VkVideoEncodeSessionParametersGetInfoKHR* pVideoSessionParametersInfo, VkVideoEncodeSessionParametersFeedbackInfoKHR* pFeedbackInfo, nuint* pDataSize, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEncodeVideoKHR(IntPtr commandBuffer, VkVideoEncodeInfoKHR* pEncodeInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetEvent2KHR(IntPtr commandBuffer, IntPtr @event, VkDependencyInfo* pDependencyInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdResetEvent2KHR(IntPtr commandBuffer, IntPtr @event, ulong stageMask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWaitEvents2KHR(IntPtr commandBuffer, uint eventCount, IntPtr* pEvents, VkDependencyInfo* pDependencyInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPipelineBarrier2KHR(IntPtr commandBuffer, VkDependencyInfo* pDependencyInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWriteTimestamp2KHR(IntPtr commandBuffer, ulong stage, IntPtr queryPool, uint query);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkQueueSubmit2KHR(IntPtr queue, uint submitCount, VkSubmitInfo2* pSubmits, IntPtr fence);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindIndexBuffer3KHR(IntPtr commandBuffer, VkBindIndexBuffer3InfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindVertexBuffers3KHR(IntPtr commandBuffer, uint firstBinding, uint bindingCount, VkBindVertexBuffer3InfoKHR* pBindingInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndirect2KHR(IntPtr commandBuffer, VkDrawIndirect2InfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndexedIndirect2KHR(IntPtr commandBuffer, VkDrawIndirect2InfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDispatchIndirect2KHR(IntPtr commandBuffer, VkDispatchIndirect2InfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyMemoryKHR(IntPtr commandBuffer, VkCopyDeviceMemoryInfoKHR* pCopyMemoryInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyMemoryToImageKHR(IntPtr commandBuffer, VkCopyDeviceMemoryImageInfoKHR* pCopyMemoryInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyImageToMemoryKHR(IntPtr commandBuffer, VkCopyDeviceMemoryImageInfoKHR* pCopyMemoryInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdUpdateMemoryKHR(IntPtr commandBuffer, VkDeviceAddressRangeKHR* pDstRange, uint dstFlags, ulong dataSize, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdFillMemoryKHR(IntPtr commandBuffer, VkDeviceAddressRangeKHR* pDstRange, uint dstFlags, uint data);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyQueryPoolResultsToMemoryKHR(IntPtr commandBuffer, IntPtr queryPool, uint firstQuery, uint queryCount, VkStridedDeviceAddressRangeKHR* pDstRange, uint dstFlags, uint queryResultFlags);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndirectCount2KHR(IntPtr commandBuffer, VkDrawIndirectCount2InfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndexedIndirectCount2KHR(IntPtr commandBuffer, VkDrawIndirectCount2InfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginConditionalRendering2EXT(IntPtr commandBuffer, VkConditionalRenderingBeginInfo2EXT* pConditionalRenderingBegin);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindTransformFeedbackBuffers2EXT(IntPtr commandBuffer, uint firstBinding, uint bindingCount, VkBindTransformFeedbackBuffer2InfoEXT* pBindingInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginTransformFeedback2EXT(IntPtr commandBuffer, uint firstCounterRange, uint counterRangeCount, VkBindTransformFeedbackBuffer2InfoEXT* pCounterInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndTransformFeedback2EXT(IntPtr commandBuffer, uint firstCounterRange, uint counterRangeCount, VkBindTransformFeedbackBuffer2InfoEXT* pCounterInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndirectByteCount2EXT(IntPtr commandBuffer, uint instanceCount, uint firstInstance, VkBindTransformFeedbackBuffer2InfoEXT* pCounterInfo, uint counterOffset, uint vertexStride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawMeshTasksIndirect2EXT(IntPtr commandBuffer, VkDrawIndirect2InfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawMeshTasksIndirectCount2EXT(IntPtr commandBuffer, VkDrawIndirectCount2InfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWriteMarkerToMemoryAMD(IntPtr commandBuffer, VkMemoryMarkerInfoAMD* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateAccelerationStructure2KHR(IntPtr device, VkAccelerationStructureCreateInfo2KHR* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pAccelerationStructure);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyBuffer2KHR(IntPtr commandBuffer, VkCopyBufferInfo2* pCopyBufferInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyImage2KHR(IntPtr commandBuffer, VkCopyImageInfo2* pCopyImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyBufferToImage2KHR(IntPtr commandBuffer, VkCopyBufferToImageInfo2* pCopyBufferToImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyImageToBuffer2KHR(IntPtr commandBuffer, VkCopyImageToBufferInfo2* pCopyImageToBufferInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBlitImage2KHR(IntPtr commandBuffer, VkBlitImageInfo2* pBlitImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdResolveImage2KHR(IntPtr commandBuffer, VkResolveImageInfo2* pResolveImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdTraceRaysIndirect2KHR(IntPtr commandBuffer, ulong indirectDeviceAddress);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceBufferMemoryRequirementsKHR(IntPtr device, VkDeviceBufferMemoryRequirements* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceImageMemoryRequirementsKHR(IntPtr device, VkDeviceImageMemoryRequirements* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceImageSparseMemoryRequirementsKHR(IntPtr device, VkDeviceImageMemoryRequirements* pInfo, uint* pSparseMemoryRequirementCount, VkSparseImageMemoryRequirements2* pSparseMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindIndexBuffer2KHR(IntPtr commandBuffer, IntPtr buffer, ulong offset, ulong size, VkIndexType indexType);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetRenderingAreaGranularityKHR(IntPtr device, VkRenderingAreaInfo* pRenderingAreaInfo, VkExtent2D* pGranularity);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceImageSubresourceLayoutKHR(IntPtr device, VkDeviceImageSubresourceInfo* pInfo, VkSubresourceLayout2* pLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetImageSubresourceLayout2KHR(IntPtr device, IntPtr image, VkImageSubresource2* pSubresource, VkSubresourceLayout2* pLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkWaitForPresent2KHR(IntPtr device, IntPtr swapchain, VkPresentWait2InfoKHR* pPresentWait2Info);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreatePipelineBinariesKHR(IntPtr device, VkPipelineBinaryCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, VkPipelineBinaryHandlesInfoKHR* pBinaries);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyPipelineBinaryKHR(IntPtr device, IntPtr pipelineBinary, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPipelineKeyKHR(IntPtr device, VkPipelineCreateInfoKHR* pPipelineCreateInfo, VkPipelineBinaryKeyKHR* pPipelineKey);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPipelineBinaryDataKHR(IntPtr device, VkPipelineBinaryDataInfoKHR* pInfo, VkPipelineBinaryKeyKHR* pPipelineBinaryKey, nuint* pPipelineBinaryDataSize, void* pPipelineBinaryData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkReleaseCapturedPipelineDataKHR(IntPtr device, VkReleaseCapturedPipelineDataInfoKHR* pInfo, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkReleaseSwapchainImagesKHR(IntPtr device, VkReleaseSwapchainImagesInfoKHR* pReleaseInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceCooperativeMatrixPropertiesKHR(IntPtr physicalDevice, uint* pPropertyCount, VkCooperativeMatrixPropertiesKHR* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetLineStippleKHR(IntPtr commandBuffer, uint lineStippleFactor, ushort lineStipplePattern);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceCalibrateableTimeDomainsKHR(IntPtr physicalDevice, uint* pTimeDomainCount, VkTimeDomainKHR* pTimeDomains);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetCalibratedTimestampsKHR(IntPtr device, uint timestampCount, VkCalibratedTimestampInfoKHR* pTimestampInfos, ulong* pTimestamps, ulong* pMaxDeviation);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindDescriptorSets2KHR(IntPtr commandBuffer, VkBindDescriptorSetsInfo* pBindDescriptorSetsInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushConstants2KHR(IntPtr commandBuffer, VkPushConstantsInfo* pPushConstantsInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushDescriptorSet2KHR(IntPtr commandBuffer, VkPushDescriptorSetInfo* pPushDescriptorSetInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushDescriptorSetWithTemplate2KHR(IntPtr commandBuffer, VkPushDescriptorSetWithTemplateInfo* pPushDescriptorSetWithTemplateInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDescriptorBufferOffsets2EXT(IntPtr commandBuffer, VkSetDescriptorBufferOffsetsInfoEXT* pSetDescriptorBufferOffsetsInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindDescriptorBufferEmbeddedSamplers2EXT(IntPtr commandBuffer, VkBindDescriptorBufferEmbeddedSamplersInfoEXT* pBindDescriptorBufferEmbeddedSamplersInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyMemoryIndirectKHR(IntPtr commandBuffer, VkCopyMemoryIndirectInfoKHR* pCopyMemoryIndirectInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyMemoryToImageIndirectKHR(IntPtr commandBuffer, VkCopyMemoryToImageIndirectInfoKHR* pCopyMemoryToImageIndirectInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDeviceFaultReportsKHR(IntPtr device, ulong timeout, uint* pFaultCounts, VkDeviceFaultInfoKHR* pFaultInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDeviceFaultDebugInfoKHR(IntPtr device, VkDeviceFaultDebugInfoKHR* pDebugInfo);

        public const ulong VK_ACCESS_3_NONE_KHR = 0UL;

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndRendering2KHR(IntPtr commandBuffer, VkRenderingEndInfoKHR* pRenderingEndInfo);

        public const ulong VK_IMAGE_USAGE_2RANSFER_SRC_BIT_KHR = 0x00000001UL;

        public const ulong VK_IMAGE_USAGE_2RANSFER_DST_BIT_KHR = 0x00000002UL;

        public const ulong VK_IMAGE_USAGE_2_SAMPLED_BIT_KHR = 0x00000004UL;

        public const ulong VK_IMAGE_USAGE_2_STORAGE_BIT_KHR = 0x00000008UL;

        public const ulong VK_IMAGE_USAGE_2_COLOR_ATTACHMENT_BIT_KHR = 0x00000010UL;

        public const ulong VK_IMAGE_USAGE_2_DEPTH_STENCIL_ATTACHMENT_BIT_KHR = 0x00000020UL;

        public const ulong VK_IMAGE_USAGE_2RANSIENT_ATTACHMENT_BIT_KHR = 0x00000040UL;

        public const ulong VK_IMAGE_USAGE_2_INPUT_ATTACHMENT_BIT_KHR = 0x00000080UL;

        public const ulong VK_IMAGE_USAGE_2_FRAGMENT_SHADING_RATE_ATTACHMENT_BIT_KHR = 0x00000100UL;

        public const ulong VK_IMAGE_USAGE_2_FRAGMENT_DENSITY_MAP_BIT_EXT = 0x00000200UL;

        public const ulong VK_IMAGE_USAGE_2_VIDEO_DECODE_DST_BIT_KHR = 0x00000400UL;

        public const ulong VK_IMAGE_USAGE_2_VIDEO_DECODE_SRC_BIT_KHR = 0x00000800UL;

        public const ulong VK_IMAGE_USAGE_2_VIDEO_DECODE_DPB_BIT_KHR = 0x00001000UL;

        public const ulong VK_IMAGE_USAGE_2_VIDEO_ENCODE_DST_BIT_KHR = 0x00002000UL;

        public const ulong VK_IMAGE_USAGE_2_VIDEO_ENCODE_SRC_BIT_KHR = 0x00004000UL;

        public const ulong VK_IMAGE_USAGE_2_VIDEO_ENCODE_DPB_BIT_KHR = 0x00008000UL;

        public const ulong VK_IMAGE_USAGE_2_INVOCATION_MASK_BIT_HUAWEI = 0x00040000UL;

        public const ulong VK_IMAGE_USAGE_2_ATTACHMENT_FEEDBACK_LOOP_BIT_EXT = 0x00080000UL;

        public const ulong VK_IMAGE_USAGE_2_SAMPLE_WEIGHT_BIT_QCOM = 0x00100000UL;

        public const ulong VK_IMAGE_USAGE_2_SAMPLE_BLOCK_MATCH_BIT_QCOM = 0x00200000UL;

        public const ulong VK_IMAGE_USAGE_2_HOSTRANSFER_BIT_KHR = 0x00400000UL;

        public const ulong VK_IMAGE_USAGE_2ENSOR_ALIASING_BIT_ARM = 0x00800000UL;

        public const ulong VK_IMAGE_USAGE_2_VIDEO_ENCODE_QUANTIZATION_DELTA_MAP_BIT_KHR = 0x02000000UL;

        public const ulong VK_IMAGE_USAGE_2_VIDEO_ENCODE_EMPHASIS_MAP_BIT_KHR = 0x04000000UL;

        public const ulong VK_IMAGE_USAGE_2ILE_MEMORY_BIT_QCOM = 0x08000000UL;

        public const ulong VK_IMAGE_CREATE_2_SPARSE_BINDING_BIT_KHR = 0x00000001UL;

        public const ulong VK_IMAGE_CREATE_2_SPARSE_RESIDENCY_BIT_KHR = 0x00000002UL;

        public const ulong VK_IMAGE_CREATE_2_SPARSE_ALIASED_BIT_KHR = 0x00000004UL;

        public const ulong VK_IMAGE_CREATE_2_MUTABLE_FORMAT_BIT_KHR = 0x00000008UL;

        public const ulong VK_IMAGE_CREATE_2_CUBE_COMPATIBLE_BIT_KHR = 0x00000010UL;

        public const ulong VK_IMAGE_CREATE_2_ALIAS_SINGLE_LAYER_DESCRIPTOR_BIT_KHR = 0x00400000UL;

        public const ulong VK_IMAGE_CREATE_2_2D_ARRAY_COMPATIBLE_BIT_KHR = 0x00000020UL;

        public const ulong VK_IMAGE_CREATE_2_SPLIT_INSTANCE_BIND_REGIONS_BIT_KHR = 0x00000040UL;

        public const ulong VK_IMAGE_CREATE_2_BLOCKEXEL_VIEW_COMPATIBLE_BIT_KHR = 0x00000080UL;

        public const ulong VK_IMAGE_CREATE_2_EXTENDED_USAGE_BIT_KHR = 0x00000100UL;

        public const ulong VK_IMAGE_CREATE_2_DISJOINT_BIT_KHR = 0x00000200UL;

        public const ulong VK_IMAGE_CREATE_2_ALIAS_BIT_KHR = 0x00000400UL;

        public const ulong VK_IMAGE_CREATE_2_PROTECTED_BIT_KHR = 0x00000800UL;

        public const ulong VK_IMAGE_CREATE_2_SAMPLE_LOCATIONS_COMPATIBLE_DEPTH_BIT_EXT = 0x00001000UL;

        public const ulong VK_IMAGE_CREATE_2_CORNER_SAMPLED_BIT_NV = 0x00002000UL;

        public const ulong VK_IMAGE_CREATE_2_SUBSAMPLED_BIT_EXT = 0x00004000UL;

        public const ulong VK_IMAGE_CREATE_2_FRAGMENT_DENSITY_MAP_OFFSET_BIT_EXT = 0x00008000UL;

        public const ulong VK_IMAGE_CREATE_2_DESCRIPTOR_BUFFER_CAPTURE_REPLAY_BIT_EXT = 0x00010000UL;

        public const ulong VK_IMAGE_CREATE_2_2D_VIEW_COMPATIBLE_BIT_EXT = 0x00020000UL;

        public const ulong VK_IMAGE_CREATE_2_MULTISAMPLED_RENDERO_SINGLE_SAMPLED_BIT_EXT = 0x00040000UL;

        public const ulong VK_IMAGE_CREATE_2_VIDEO_PROFILE_INDEPENDENT_BIT_KHR = 0x00100000UL;

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDebugReportCallbackEXT(IntPtr instance, VkDebugReportCallbackCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pCallback);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyDebugReportCallbackEXT(IntPtr instance, IntPtr callback, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDebugReportMessageEXT(IntPtr instance, uint flags, VkDebugReportObjectTypeEXT objectType, ulong @object, nuint location, int messageCode, sbyte* pLayerPrefix, sbyte* pMessage);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkDebugMarkerSetObjectTagEXT(IntPtr device, VkDebugMarkerObjectTagInfoEXT* pTagInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkDebugMarkerSetObjectNameEXT(IntPtr device, VkDebugMarkerObjectNameInfoEXT* pNameInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDebugMarkerBeginEXT(IntPtr commandBuffer, VkDebugMarkerMarkerInfoEXT* pMarkerInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDebugMarkerEndEXT(IntPtr commandBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDebugMarkerInsertEXT(IntPtr commandBuffer, VkDebugMarkerMarkerInfoEXT* pMarkerInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindTransformFeedbackBuffersEXT(IntPtr commandBuffer, uint firstBinding, uint bindingCount, IntPtr* pBuffers, ulong* pOffsets, ulong* pSizes);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginTransformFeedbackEXT(IntPtr commandBuffer, uint firstCounterBuffer, uint counterBufferCount, IntPtr* pCounterBuffers, ulong* pCounterBufferOffsets);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndTransformFeedbackEXT(IntPtr commandBuffer, uint firstCounterBuffer, uint counterBufferCount, IntPtr* pCounterBuffers, ulong* pCounterBufferOffsets);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginQueryIndexedEXT(IntPtr commandBuffer, IntPtr queryPool, uint query, uint flags, uint index);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndQueryIndexedEXT(IntPtr commandBuffer, IntPtr queryPool, uint query, uint index);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndirectByteCountEXT(IntPtr commandBuffer, uint instanceCount, uint firstInstance, IntPtr counterBuffer, ulong counterBufferOffset, uint counterOffset, uint vertexStride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateCuModuleNVX(IntPtr device, VkCuModuleCreateInfoNVX* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pModule);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateCuFunctionNVX(IntPtr device, VkCuFunctionCreateInfoNVX* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pFunction);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyCuModuleNVX(IntPtr device, IntPtr module, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyCuFunctionNVX(IntPtr device, IntPtr function, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCuLaunchKernelNVX(IntPtr commandBuffer, VkCuLaunchInfoNVX* pLaunchInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint vkGetImageViewHandleNVX(IntPtr device, VkImageViewHandleInfoNVX* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetImageViewHandle64NVX(IntPtr device, VkImageViewHandleInfoNVX* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetImageViewAddressNVX(IntPtr device, IntPtr imageView, VkImageViewAddressPropertiesNVX* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetDeviceCombinedImageSamplerIndexNVX(IntPtr device, ulong imageViewIndex, ulong samplerIndex);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndirectCountAMD(IntPtr commandBuffer, IntPtr buffer, ulong offset, IntPtr countBuffer, ulong countBufferOffset, uint maxDrawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawIndexedIndirectCountAMD(IntPtr commandBuffer, IntPtr buffer, ulong offset, IntPtr countBuffer, ulong countBufferOffset, uint maxDrawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetShaderInfoAMD(IntPtr device, IntPtr pipeline, VkShaderStageFlagBits shaderStage, VkShaderInfoTypeAMD infoType, nuint* pInfoSize, void* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceExternalImageFormatPropertiesNV(IntPtr physicalDevice, VkFormat format, VkImageType type, VkImageTiling tiling, uint usage, uint flags, uint externalHandleType, VkExternalImageFormatPropertiesNV* pExternalImageFormatProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginConditionalRenderingEXT(IntPtr commandBuffer, VkConditionalRenderingBeginInfoEXT* pConditionalRenderingBegin);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndConditionalRenderingEXT(IntPtr commandBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetViewportWScalingNV(IntPtr commandBuffer, uint firstViewport, uint viewportCount, VkViewportWScalingNV* pViewportWScalings);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkReleaseDisplayEXT(IntPtr physicalDevice, IntPtr display);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceSurfaceCapabilities2EXT(IntPtr physicalDevice, IntPtr surface, VkSurfaceCapabilities2EXT* pSurfaceCapabilities);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkDisplayPowerControlEXT(IntPtr device, IntPtr display, VkDisplayPowerInfoEXT* pDisplayPowerInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkRegisterDeviceEventEXT(IntPtr device, VkDeviceEventInfoEXT* pDeviceEventInfo, VkAllocationCallbacks* pAllocator, IntPtr* pFence);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkRegisterDisplayEventEXT(IntPtr device, IntPtr display, VkDisplayEventInfoEXT* pDisplayEventInfo, VkAllocationCallbacks* pAllocator, IntPtr* pFence);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetSwapchainCounterEXT(IntPtr device, IntPtr swapchain, VkSurfaceCounterFlagBitsEXT counter, ulong* pCounterValue);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetRefreshCycleDurationGOOGLE(IntPtr device, IntPtr swapchain, VkRefreshCycleDurationGOOGLE* pDisplayTimingProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPastPresentationTimingGOOGLE(IntPtr device, IntPtr swapchain, uint* pPresentationTimingCount, VkPastPresentationTimingGOOGLE* pPresentationTimings);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDiscardRectangleEXT(IntPtr commandBuffer, uint firstDiscardRectangle, uint discardRectangleCount, VkRect2D* pDiscardRectangles);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDiscardRectangleEnableEXT(IntPtr commandBuffer, uint discardRectangleEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDiscardRectangleModeEXT(IntPtr commandBuffer, VkDiscardRectangleModeEXT discardRectangleMode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkSetHdrMetadataEXT(IntPtr device, uint swapchainCount, IntPtr* pSwapchains, VkHdrMetadataEXT* pMetadata);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkSetDebugUtilsObjectNameEXT(IntPtr device, VkDebugUtilsObjectNameInfoEXT* pNameInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkSetDebugUtilsObjectTagEXT(IntPtr device, VkDebugUtilsObjectTagInfoEXT* pTagInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkQueueBeginDebugUtilsLabelEXT(IntPtr queue, VkDebugUtilsLabelEXT* pLabelInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkQueueEndDebugUtilsLabelEXT(IntPtr queue);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkQueueInsertDebugUtilsLabelEXT(IntPtr queue, VkDebugUtilsLabelEXT* pLabelInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginDebugUtilsLabelEXT(IntPtr commandBuffer, VkDebugUtilsLabelEXT* pLabelInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndDebugUtilsLabelEXT(IntPtr commandBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdInsertDebugUtilsLabelEXT(IntPtr commandBuffer, VkDebugUtilsLabelEXT* pLabelInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDebugUtilsMessengerEXT(IntPtr instance, VkDebugUtilsMessengerCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pMessenger);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyDebugUtilsMessengerEXT(IntPtr instance, IntPtr messenger, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkSubmitDebugUtilsMessageEXT(IntPtr instance, VkDebugUtilsMessageSeverityFlagBitsEXT messageSeverity, uint messageTypes, VkDebugUtilsMessengerCallbackDataEXT* pCallbackData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateGpaSessionAMD(IntPtr device, VkGpaSessionCreateInfoAMD* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pGpaSession);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyGpaSessionAMD(IntPtr device, IntPtr gpaSession, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkSetGpaDeviceClockModeAMD(IntPtr device, VkGpaDeviceClockModeInfoAMD* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetGpaDeviceClockInfoAMD(IntPtr device, VkGpaDeviceGetClockInfoAMD* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCmdBeginGpaSessionAMD(IntPtr commandBuffer, IntPtr gpaSession);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCmdEndGpaSessionAMD(IntPtr commandBuffer, IntPtr gpaSession);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCmdBeginGpaSampleAMD(IntPtr commandBuffer, IntPtr gpaSession, VkGpaSampleBeginInfoAMD* pGpaSampleBeginInfo, uint* pSampleID);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndGpaSampleAMD(IntPtr commandBuffer, IntPtr gpaSession, uint sampleID);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetGpaSessionStatusAMD(IntPtr device, IntPtr gpaSession);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetGpaSessionResultsAMD(IntPtr device, IntPtr gpaSession, uint sampleID, nuint* pSizeInBytes, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkResetGpaSessionAMD(IntPtr device, IntPtr gpaSession);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyGpaSessionResultsAMD(IntPtr commandBuffer, IntPtr gpaSession);

        public const ulong VKENSOR_VIEW_CREATE_DESCRIPTOR_BUFFER_CAPTURE_REPLAY_BIT_ARM = 0x00000001UL;

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkWriteSamplerDescriptorsEXT(IntPtr device, uint samplerCount, VkSamplerCreateInfo* pSamplers, VkHostAddressRangeEXT* pDescriptors);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkWriteResourceDescriptorsEXT(IntPtr device, uint resourceCount, VkResourceDescriptorInfoEXT* pResources, VkHostAddressRangeEXT* pDescriptors);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindSamplerHeapEXT(IntPtr commandBuffer, VkBindHeapInfoEXT* pBindInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindResourceHeapEXT(IntPtr commandBuffer, VkBindHeapInfoEXT* pBindInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPushDataEXT(IntPtr commandBuffer, VkPushDataInfoEXT* pPushDataInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetImageOpaqueCaptureDataEXT(IntPtr device, uint imageCount, IntPtr* pImages, VkHostAddressRangeEXT* pDatas);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetPhysicalDeviceDescriptorSizeEXT(IntPtr physicalDevice, VkDescriptorType descriptorType);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkRegisterCustomBorderColorEXT(IntPtr device, VkSamplerCustomBorderColorCreateInfoEXT* pBorderColor, uint requestIndex, uint* pIndex);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkUnregisterCustomBorderColorEXT(IntPtr device, uint index);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetTensorOpaqueCaptureDataARM(IntPtr device, uint tensorCount, IntPtr* pTensors, VkHostAddressRangeEXT* pDatas);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetSampleLocationsEXT(IntPtr commandBuffer, VkSampleLocationsInfoEXT* pSampleLocationsInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceMultisamplePropertiesEXT(IntPtr physicalDevice, VkSampleCountFlagBits samples, VkMultisamplePropertiesEXT* pMultisampleProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetImageDrmFormatModifierPropertiesEXT(IntPtr device, IntPtr image, VkImageDrmFormatModifierPropertiesEXT* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateValidationCacheEXT(IntPtr device, VkValidationCacheCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pValidationCache);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyValidationCacheEXT(IntPtr device, IntPtr validationCache, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkMergeValidationCachesEXT(IntPtr device, IntPtr dstCache, uint srcCacheCount, IntPtr* pSrcCaches);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetValidationCacheDataEXT(IntPtr device, IntPtr validationCache, nuint* pDataSize, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindShadingRateImageNV(IntPtr commandBuffer, IntPtr imageView, VkImageLayout imageLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetViewportShadingRatePaletteNV(IntPtr commandBuffer, uint firstViewport, uint viewportCount, VkShadingRatePaletteNV* pShadingRatePalettes);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetCoarseSampleOrderNV(IntPtr commandBuffer, VkCoarseSampleOrderTypeNV sampleOrderType, uint customSampleOrderCount, VkCoarseSampleOrderCustomNV* pCustomSampleOrders);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateAccelerationStructureNV(IntPtr device, VkAccelerationStructureCreateInfoNV* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pAccelerationStructure);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyAccelerationStructureNV(IntPtr device, IntPtr accelerationStructure, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetAccelerationStructureMemoryRequirementsNV(IntPtr device, VkAccelerationStructureMemoryRequirementsInfoNV* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindAccelerationStructureMemoryNV(IntPtr device, uint bindInfoCount, VkBindAccelerationStructureMemoryInfoNV* pBindInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBuildAccelerationStructureNV(IntPtr commandBuffer, VkAccelerationStructureInfoNV* pInfo, IntPtr instanceData, ulong instanceOffset, uint update, IntPtr dst, IntPtr src, IntPtr scratch, ulong scratchOffset);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyAccelerationStructureNV(IntPtr commandBuffer, IntPtr dst, IntPtr src, VkCopyAccelerationStructureModeKHR mode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdTraceRaysNV(IntPtr commandBuffer, IntPtr raygenShaderBindingTableBuffer, ulong raygenShaderBindingOffset, IntPtr missShaderBindingTableBuffer, ulong missShaderBindingOffset, ulong missShaderBindingStride, IntPtr hitShaderBindingTableBuffer, ulong hitShaderBindingOffset, ulong hitShaderBindingStride, IntPtr callableShaderBindingTableBuffer, ulong callableShaderBindingOffset, ulong callableShaderBindingStride, uint width, uint height, uint depth);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateRayTracingPipelinesNV(IntPtr device, IntPtr pipelineCache, uint createInfoCount, VkRayTracingPipelineCreateInfoNV* pCreateInfos, VkAllocationCallbacks* pAllocator, IntPtr* pPipelines);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetRayTracingShaderGroupHandlesKHR(IntPtr device, IntPtr pipeline, uint firstGroup, uint groupCount, nuint dataSize, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetRayTracingShaderGroupHandlesNV(IntPtr device, IntPtr pipeline, uint firstGroup, uint groupCount, nuint dataSize, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetAccelerationStructureHandleNV(IntPtr device, IntPtr accelerationStructure, nuint dataSize, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWriteAccelerationStructuresPropertiesNV(IntPtr commandBuffer, uint accelerationStructureCount, IntPtr* pAccelerationStructures, VkQueryType queryType, IntPtr queryPool, uint firstQuery);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCompileDeferredNV(IntPtr device, IntPtr pipeline, uint shader);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetMemoryHostPointerPropertiesEXT(IntPtr device, VkExternalMemoryHandleTypeFlagBits handleType, void* pHostPointer, VkMemoryHostPointerPropertiesEXT* pMemoryHostPointerProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWriteBufferMarkerAMD(IntPtr commandBuffer, VkPipelineStageFlagBits pipelineStage, IntPtr dstBuffer, ulong dstOffset, uint marker);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWriteBufferMarker2AMD(IntPtr commandBuffer, ulong stage, IntPtr dstBuffer, ulong dstOffset, uint marker);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceCalibrateableTimeDomainsEXT(IntPtr physicalDevice, uint* pTimeDomainCount, VkTimeDomainKHR* pTimeDomains);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetCalibratedTimestampsEXT(IntPtr device, uint timestampCount, VkCalibratedTimestampInfoKHR* pTimestampInfos, ulong* pTimestamps, ulong* pMaxDeviation);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawMeshTasksNV(IntPtr commandBuffer, uint taskCount, uint firstTask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawMeshTasksIndirectNV(IntPtr commandBuffer, IntPtr buffer, ulong offset, uint drawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawMeshTasksIndirectCountNV(IntPtr commandBuffer, IntPtr buffer, ulong offset, IntPtr countBuffer, ulong countBufferOffset, uint maxDrawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetExclusiveScissorEnableNV(IntPtr commandBuffer, uint firstExclusiveScissor, uint exclusiveScissorCount, uint* pExclusiveScissorEnables);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetExclusiveScissorNV(IntPtr commandBuffer, uint firstExclusiveScissor, uint exclusiveScissorCount, VkRect2D* pExclusiveScissors);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetCheckpointNV(IntPtr commandBuffer, void* pCheckpointMarker);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetQueueCheckpointDataNV(IntPtr queue, uint* pCheckpointDataCount, VkCheckpointDataNV* pCheckpointData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetQueueCheckpointData2NV(IntPtr queue, uint* pCheckpointDataCount, VkCheckpointData2NV* pCheckpointData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkSetSwapchainPresentTimingQueueSizeEXT(IntPtr device, IntPtr swapchain, uint size);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetSwapchainTimingPropertiesEXT(IntPtr device, IntPtr swapchain, VkSwapchainTimingPropertiesEXT* pSwapchainTimingProperties, ulong* pSwapchainTimingPropertiesCounter);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetSwapchainTimeDomainPropertiesEXT(IntPtr device, IntPtr swapchain, VkSwapchainTimeDomainPropertiesEXT* pSwapchainTimeDomainProperties, ulong* pTimeDomainsCounter);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPastPresentationTimingEXT(IntPtr device, VkPastPresentationTimingInfoEXT* pPastPresentationTimingInfo, VkPastPresentationTimingPropertiesEXT* pPastPresentationTimingProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkInitializePerformanceApiINTEL(IntPtr device, VkInitializePerformanceApiInfoINTEL* pInitializeInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkUninitializePerformanceApiINTEL(IntPtr device);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCmdSetPerformanceMarkerINTEL(IntPtr commandBuffer, VkPerformanceMarkerInfoINTEL* pMarkerInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCmdSetPerformanceStreamMarkerINTEL(IntPtr commandBuffer, VkPerformanceStreamMarkerInfoINTEL* pMarkerInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCmdSetPerformanceOverrideINTEL(IntPtr commandBuffer, VkPerformanceOverrideInfoINTEL* pOverrideInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkAcquirePerformanceConfigurationINTEL(IntPtr device, VkPerformanceConfigurationAcquireInfoINTEL* pAcquireInfo, IntPtr* pConfiguration);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkReleasePerformanceConfigurationINTEL(IntPtr device, IntPtr configuration);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkQueueSetPerformanceConfigurationINTEL(IntPtr queue, IntPtr configuration);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPerformanceParameterINTEL(IntPtr device, VkPerformanceParameterTypeINTEL parameter, VkPerformanceValueINTEL* pValue);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkSetLocalDimmingAMD(IntPtr device, IntPtr swapChain, uint localDimmingEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetBufferDeviceAddressEXT(IntPtr device, VkBufferDeviceAddressInfo* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceToolPropertiesEXT(IntPtr physicalDevice, uint* pToolCount, VkPhysicalDeviceToolProperties* pToolProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceCooperativeMatrixPropertiesNV(IntPtr physicalDevice, uint* pPropertyCount, VkCooperativeMatrixPropertiesNV* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceSupportedFramebufferMixedSamplesCombinationsNV(IntPtr physicalDevice, uint* pCombinationCount, VkFramebufferMixedSamplesCombinationNV* pCombinations);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateHeadlessSurfaceEXT(IntPtr instance, VkHeadlessSurfaceCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSurface);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetLineStippleEXT(IntPtr commandBuffer, uint lineStippleFactor, ushort lineStipplePattern);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkResetQueryPoolEXT(IntPtr device, IntPtr queryPool, uint firstQuery, uint queryCount);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetCullModeEXT(IntPtr commandBuffer, uint cullMode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetFrontFaceEXT(IntPtr commandBuffer, VkFrontFace frontFace);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetPrimitiveTopologyEXT(IntPtr commandBuffer, VkPrimitiveTopology primitiveTopology);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetViewportWithCountEXT(IntPtr commandBuffer, uint viewportCount, VkViewport* pViewports);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetScissorWithCountEXT(IntPtr commandBuffer, uint scissorCount, VkRect2D* pScissors);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindVertexBuffers2EXT(IntPtr commandBuffer, uint firstBinding, uint bindingCount, IntPtr* pBuffers, ulong* pOffsets, ulong* pSizes, ulong* pStrides);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthTestEnableEXT(IntPtr commandBuffer, uint depthTestEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthWriteEnableEXT(IntPtr commandBuffer, uint depthWriteEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthCompareOpEXT(IntPtr commandBuffer, VkCompareOp depthCompareOp);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthBoundsTestEnableEXT(IntPtr commandBuffer, uint depthBoundsTestEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetStencilTestEnableEXT(IntPtr commandBuffer, uint stencilTestEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetStencilOpEXT(IntPtr commandBuffer, uint faceMask, VkStencilOp failOp, VkStencilOp passOp, VkStencilOp depthFailOp, VkCompareOp compareOp);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyMemoryToImageEXT(IntPtr device, VkCopyMemoryToImageInfo* pCopyMemoryToImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyImageToMemoryEXT(IntPtr device, VkCopyImageToMemoryInfo* pCopyImageToMemoryInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyImageToImageEXT(IntPtr device, VkCopyImageToImageInfo* pCopyImageToImageInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkTransitionImageLayoutEXT(IntPtr device, uint transitionCount, VkHostImageLayoutTransitionInfo* pTransitions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetImageSubresourceLayout2EXT(IntPtr device, IntPtr image, VkImageSubresource2* pSubresource, VkSubresourceLayout2* pLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkReleaseSwapchainImagesEXT(IntPtr device, VkReleaseSwapchainImagesInfoKHR* pReleaseInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetGeneratedCommandsMemoryRequirementsNV(IntPtr device, VkGeneratedCommandsMemoryRequirementsInfoNV* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPreprocessGeneratedCommandsNV(IntPtr commandBuffer, VkGeneratedCommandsInfoNV* pGeneratedCommandsInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdExecuteGeneratedCommandsNV(IntPtr commandBuffer, uint isPreprocessed, VkGeneratedCommandsInfoNV* pGeneratedCommandsInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindPipelineShaderGroupNV(IntPtr commandBuffer, VkPipelineBindPoint pipelineBindPoint, IntPtr pipeline, uint groupIndex);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateIndirectCommandsLayoutNV(IntPtr device, VkIndirectCommandsLayoutCreateInfoNV* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pIndirectCommandsLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyIndirectCommandsLayoutNV(IntPtr device, IntPtr indirectCommandsLayout, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthBias2EXT(IntPtr commandBuffer, VkDepthBiasInfoEXT* pDepthBiasInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkAcquireDrmDisplayEXT(IntPtr physicalDevice, int drmFd, IntPtr display);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDrmDisplayEXT(IntPtr physicalDevice, int drmFd, uint connectorId, IntPtr* display);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreatePrivateDataSlotEXT(IntPtr device, VkPrivateDataSlotCreateInfo* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pPrivateDataSlot);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyPrivateDataSlotEXT(IntPtr device, IntPtr privateDataSlot, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkSetPrivateDataEXT(IntPtr device, VkObjectType objectType, ulong objectHandle, IntPtr privateDataSlot, ulong data);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPrivateDataEXT(IntPtr device, VkObjectType objectType, ulong objectHandle, IntPtr privateDataSlot, ulong* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkQueueSetPerfHintQCOM(IntPtr queue, VkPerfHintInfoQCOM* pPerfHintInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDispatchTileQCOM(IntPtr commandBuffer, VkDispatchTileInfoQCOM* pDispatchTileInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginPerTileExecutionQCOM(IntPtr commandBuffer, VkPerTileBeginInfoQCOM* pPerTileBeginInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndPerTileExecutionQCOM(IntPtr commandBuffer, VkPerTileEndInfoQCOM* pPerTileEndInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkSetLatencySleepModeLegacyNV(IntPtr device, uint lowLatencyMode, uint lowLatencyBoost, uint minimumIntervalUs);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkLatencySleepLegacyNV(IntPtr device, IntPtr signalSemaphore, ulong value);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkSetLatencyMarkerLegacyNV(IntPtr device, ulong frameID, uint marker);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetLatencyTimingsLegacyNV(IntPtr device, void* pTimings);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkQueueNotifyOutOfBandLegacyNV(IntPtr queue, uint queueType);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetSleepStatusLegacyNV(IntPtr device, uint* pLowLatencyMode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkShutdownLatencyDeviceLegacyNV(IntPtr device);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDescriptorSetLayoutSizeEXT(IntPtr device, IntPtr layout, ulong* pLayoutSizeInBytes);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDescriptorSetLayoutBindingOffsetEXT(IntPtr device, IntPtr layout, uint binding, ulong* pOffset);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDescriptorEXT(IntPtr device, VkDescriptorGetInfoEXT* pDescriptorInfo, nuint dataSize, void* pDescriptor);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindDescriptorBuffersEXT(IntPtr commandBuffer, uint bufferCount, VkDescriptorBufferBindingInfoEXT* pBindingInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDescriptorBufferOffsetsEXT(IntPtr commandBuffer, VkPipelineBindPoint pipelineBindPoint, IntPtr layout, uint firstSet, uint setCount, uint* pBufferIndices, ulong* pOffsets);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindDescriptorBufferEmbeddedSamplersEXT(IntPtr commandBuffer, VkPipelineBindPoint pipelineBindPoint, IntPtr layout, uint set);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetBufferOpaqueCaptureDescriptorDataEXT(IntPtr device, VkBufferCaptureDescriptorDataInfoEXT* pInfo, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetImageOpaqueCaptureDescriptorDataEXT(IntPtr device, VkImageCaptureDescriptorDataInfoEXT* pInfo, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetImageViewOpaqueCaptureDescriptorDataEXT(IntPtr device, VkImageViewCaptureDescriptorDataInfoEXT* pInfo, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetSamplerOpaqueCaptureDescriptorDataEXT(IntPtr device, VkSamplerCaptureDescriptorDataInfoEXT* pInfo, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetAccelerationStructureOpaqueCaptureDescriptorDataEXT(IntPtr device, VkAccelerationStructureCaptureDescriptorDataInfoEXT* pInfo, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetFragmentShadingRateEnumNV(IntPtr commandBuffer, VkFragmentShadingRateNV shadingRate, VkFragmentShadingRateCombinerOpKHR* combinerOps);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDeviceFaultInfoEXT(IntPtr device, VkDeviceFaultCountsEXT* pFaultCounts, VkDeviceFaultInfoEXT* pFaultInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetVertexInputEXT(IntPtr commandBuffer, uint vertexBindingDescriptionCount, VkVertexInputBindingDescription2EXT* pVertexBindingDescriptions, uint vertexAttributeDescriptionCount, VkVertexInputAttributeDescription2EXT* pVertexAttributeDescriptions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDeviceSubpassShadingMaxWorkgroupSizeHUAWEI(IntPtr device, IntPtr renderpass, VkExtent2D* pMaxWorkgroupSize);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSubpassShadingHUAWEI(IntPtr commandBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindInvocationMaskHUAWEI(IntPtr commandBuffer, IntPtr imageView, VkImageLayout imageLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetMemoryRemoteAddressNV(IntPtr device, VkMemoryGetRemoteAddressInfoNV* pMemoryGetRemoteAddressInfo, void** pAddress);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPipelinePropertiesEXT(IntPtr device, VkPipelineInfoKHR* pPipelineInfo, VkBaseOutStructure* pPipelineProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetPatchControlPointsEXT(IntPtr commandBuffer, uint patchControlPoints);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetRasterizerDiscardEnableEXT(IntPtr commandBuffer, uint rasterizerDiscardEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthBiasEnableEXT(IntPtr commandBuffer, uint depthBiasEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetLogicOpEXT(IntPtr commandBuffer, VkLogicOp logicOp);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetPrimitiveRestartEnableEXT(IntPtr commandBuffer, uint primitiveRestartEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetColorWriteEnableEXT(IntPtr commandBuffer, uint attachmentCount, uint* pColorWriteEnables);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawMultiEXT(IntPtr commandBuffer, uint drawCount, VkMultiDrawInfoEXT* pVertexInfo, uint instanceCount, uint firstInstance, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawMultiIndexedEXT(IntPtr commandBuffer, uint drawCount, VkMultiDrawIndexedInfoEXT* pIndexInfo, uint instanceCount, uint firstInstance, uint stride, int* pVertexOffset);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateMicromapEXT(IntPtr device, VkMicromapCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pMicromap);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyMicromapEXT(IntPtr device, IntPtr micromap, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBuildMicromapsEXT(IntPtr commandBuffer, uint infoCount, VkMicromapBuildInfoEXT* pInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBuildMicromapsEXT(IntPtr device, IntPtr deferredOperation, uint infoCount, VkMicromapBuildInfoEXT* pInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyMicromapEXT(IntPtr device, IntPtr deferredOperation, VkCopyMicromapInfoEXT* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyMicromapToMemoryEXT(IntPtr device, IntPtr deferredOperation, VkCopyMicromapToMemoryInfoEXT* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyMemoryToMicromapEXT(IntPtr device, IntPtr deferredOperation, VkCopyMemoryToMicromapInfoEXT* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkWriteMicromapsPropertiesEXT(IntPtr device, uint micromapCount, IntPtr* pMicromaps, VkQueryType queryType, nuint dataSize, void* pData, nuint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyMicromapEXT(IntPtr commandBuffer, VkCopyMicromapInfoEXT* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyMicromapToMemoryEXT(IntPtr commandBuffer, VkCopyMicromapToMemoryInfoEXT* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyMemoryToMicromapEXT(IntPtr commandBuffer, VkCopyMemoryToMicromapInfoEXT* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWriteMicromapsPropertiesEXT(IntPtr commandBuffer, uint micromapCount, IntPtr* pMicromaps, VkQueryType queryType, IntPtr queryPool, uint firstQuery);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceMicromapCompatibilityEXT(IntPtr device, VkMicromapVersionInfoEXT* pVersionInfo, VkAccelerationStructureCompatibilityKHR* pCompatibility);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetMicromapBuildSizesEXT(IntPtr device, VkAccelerationStructureBuildTypeKHR buildType, VkMicromapBuildInfoEXT* pBuildInfo, VkMicromapBuildSizesInfoEXT* pSizeInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawClusterHUAWEI(IntPtr commandBuffer, uint groupCountX, uint groupCountY, uint groupCountZ);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawClusterIndirectHUAWEI(IntPtr commandBuffer, IntPtr buffer, ulong offset);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkSetDeviceMemoryPriorityEXT(IntPtr device, IntPtr memory, float priority);

        public const ulong VK_PHYSICAL_DEVICE_SCHEDULING_CONTROLS_SHADER_CORE_COUNT_ARM = 0x00000001UL;

        public const ulong VK_PHYSICAL_DEVICE_SCHEDULING_CONTROLS_DISPATCH_PARAMETERS_ARM = 0x00000002UL;

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDispatchParametersARM(IntPtr commandBuffer, VkDispatchParametersARM* pDispatchParameters);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDescriptorSetLayoutHostMappingInfoVALVE(IntPtr device, VkDescriptorSetBindingReferenceVALVE* pBindingReference, VkDescriptorSetLayoutHostMappingInfoVALVE* pHostMapping);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDescriptorSetHostMappingVALVE(IntPtr device, IntPtr descriptorSet, void** ppData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyMemoryIndirectNV(IntPtr commandBuffer, ulong copyBufferAddress, uint copyCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyMemoryToImageIndirectNV(IntPtr commandBuffer, ulong copyBufferAddress, uint copyCount, uint stride, IntPtr dstImage, VkImageLayout dstImageLayout, VkImageSubresourceLayers* pImageSubresources);

        public const ulong VK_MEMORY_DECOMPRESSION_METHOD_GDEFLATE_1_0_BIT_EXT = 0x00000001UL;

        public const ulong VK_MEMORY_DECOMPRESSION_METHOD_GDEFLATE_1_0_BIT_NV = 0x00000001UL;

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDecompressMemoryNV(IntPtr commandBuffer, uint decompressRegionCount, VkDecompressMemoryRegionNV* pDecompressMemoryRegions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDecompressMemoryIndirectCountNV(IntPtr commandBuffer, ulong indirectCommandsAddress, ulong indirectCommandsCountAddress, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPipelineIndirectMemoryRequirementsNV(IntPtr device, VkComputePipelineCreateInfo* pCreateInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdUpdatePipelineIndirectBufferNV(IntPtr commandBuffer, VkPipelineBindPoint pipelineBindPoint, IntPtr pipeline);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetPipelineIndirectDeviceAddressNV(IntPtr device, VkPipelineIndirectDeviceAddressInfoNV* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthClampEnableEXT(IntPtr commandBuffer, uint depthClampEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetPolygonModeEXT(IntPtr commandBuffer, VkPolygonMode polygonMode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetRasterizationSamplesEXT(IntPtr commandBuffer, VkSampleCountFlagBits rasterizationSamples);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetSampleMaskEXT(IntPtr commandBuffer, VkSampleCountFlagBits samples, uint* pSampleMask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetAlphaToCoverageEnableEXT(IntPtr commandBuffer, uint alphaToCoverageEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetAlphaToOneEnableEXT(IntPtr commandBuffer, uint alphaToOneEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetLogicOpEnableEXT(IntPtr commandBuffer, uint logicOpEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetColorBlendEnableEXT(IntPtr commandBuffer, uint firstAttachment, uint attachmentCount, uint* pColorBlendEnables);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetColorBlendEquationEXT(IntPtr commandBuffer, uint firstAttachment, uint attachmentCount, VkColorBlendEquationEXT* pColorBlendEquations);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetColorWriteMaskEXT(IntPtr commandBuffer, uint firstAttachment, uint attachmentCount, uint* pColorWriteMasks);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetTessellationDomainOriginEXT(IntPtr commandBuffer, VkTessellationDomainOrigin domainOrigin);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetRasterizationStreamEXT(IntPtr commandBuffer, uint rasterizationStream);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetConservativeRasterizationModeEXT(IntPtr commandBuffer, VkConservativeRasterizationModeEXT conservativeRasterizationMode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetExtraPrimitiveOverestimationSizeEXT(IntPtr commandBuffer, float extraPrimitiveOverestimationSize);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthClipEnableEXT(IntPtr commandBuffer, uint depthClipEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetSampleLocationsEnableEXT(IntPtr commandBuffer, uint sampleLocationsEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetColorBlendAdvancedEXT(IntPtr commandBuffer, uint firstAttachment, uint attachmentCount, VkColorBlendAdvancedEXT* pColorBlendAdvanced);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetProvokingVertexModeEXT(IntPtr commandBuffer, VkProvokingVertexModeEXT provokingVertexMode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetLineRasterizationModeEXT(IntPtr commandBuffer, VkLineRasterizationMode lineRasterizationMode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetLineStippleEnableEXT(IntPtr commandBuffer, uint stippledLineEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthClipNegativeOneToOneEXT(IntPtr commandBuffer, uint negativeOneToOne);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetViewportWScalingEnableNV(IntPtr commandBuffer, uint viewportWScalingEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetViewportSwizzleNV(IntPtr commandBuffer, uint firstViewport, uint viewportCount, VkViewportSwizzleNV* pViewportSwizzles);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetCoverageToColorEnableNV(IntPtr commandBuffer, uint coverageToColorEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetCoverageToColorLocationNV(IntPtr commandBuffer, uint coverageToColorLocation);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetCoverageModulationModeNV(IntPtr commandBuffer, VkCoverageModulationModeNV coverageModulationMode);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetCoverageModulationTableEnableNV(IntPtr commandBuffer, uint coverageModulationTableEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetCoverageModulationTableNV(IntPtr commandBuffer, uint coverageModulationTableCount, float* pCoverageModulationTable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetShadingRateImageEnableNV(IntPtr commandBuffer, uint shadingRateImageEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetRepresentativeFragmentTestEnableNV(IntPtr commandBuffer, uint representativeFragmentTestEnable);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetCoverageReductionModeNV(IntPtr commandBuffer, VkCoverageReductionModeNV coverageReductionMode);

        public const ulong VKENSOR_CREATE_MUTABLE_FORMAT_BIT_ARM = 0x00000001UL;

        public const ulong VKENSOR_CREATE_PROTECTED_BIT_ARM = 0x00000002UL;

        public const ulong VKENSOR_CREATE_DESCRIPTOR_HEAP_CAPTURE_REPLAY_BIT_ARM = 0x00000008UL;

        public const ulong VKENSOR_CREATE_DESCRIPTOR_BUFFER_CAPTURE_REPLAY_BIT_ARM = 0x00000004UL;

        public const ulong VKENSOR_USAGE_SHADER_BIT_ARM = 0x00000002UL;

        public const ulong VK_TENSOR_USAGERANSFER_SRC_BIT_ARM = 0x00000004UL;

        public const ulong VK_TENSOR_USAGERANSFER_DST_BIT_ARM = 0x00000008UL;

        public const ulong VKENSOR_USAGE_IMAGE_ALIASING_BIT_ARM = 0x00000010UL;

        public const ulong VKENSOR_USAGE_DATA_GRAPH_BIT_ARM = 0x00000020UL;

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateTensorARM(IntPtr device, VkTensorCreateInfoARM* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pTensor);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyTensorARM(IntPtr device, IntPtr tensor, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateTensorViewARM(IntPtr device, VkTensorViewCreateInfoARM* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pView);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyTensorViewARM(IntPtr device, IntPtr tensorView, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetTensorMemoryRequirementsARM(IntPtr device, VkTensorMemoryRequirementsInfoARM* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindTensorMemoryARM(IntPtr device, uint bindInfoCount, VkBindTensorMemoryInfoARM* pBindInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceTensorMemoryRequirementsARM(IntPtr device, VkDeviceTensorMemoryRequirementsARM* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyTensorARM(IntPtr commandBuffer, VkCopyTensorInfoARM* pCopyTensorInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceExternalTensorPropertiesARM(IntPtr physicalDevice, VkPhysicalDeviceExternalTensorInfoARM* pExternalTensorInfo, VkExternalTensorPropertiesARM* pExternalTensorProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetTensorOpaqueCaptureDescriptorDataARM(IntPtr device, VkTensorCaptureDescriptorDataInfoARM* pInfo, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetTensorViewOpaqueCaptureDescriptorDataARM(IntPtr device, VkTensorViewCaptureDescriptorDataInfoARM* pInfo, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetShaderModuleIdentifierEXT(IntPtr device, IntPtr shaderModule, VkShaderModuleIdentifierEXT* pIdentifier);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetShaderModuleCreateInfoIdentifierEXT(IntPtr device, VkShaderModuleCreateInfo* pCreateInfo, VkShaderModuleIdentifierEXT* pIdentifier);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceOpticalFlowImageFormatsNV(IntPtr physicalDevice, VkOpticalFlowImageFormatInfoNV* pOpticalFlowImageFormatInfo, uint* pFormatCount, VkOpticalFlowImageFormatPropertiesNV* pImageFormatProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateOpticalFlowSessionNV(IntPtr device, VkOpticalFlowSessionCreateInfoNV* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSession);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyOpticalFlowSessionNV(IntPtr device, IntPtr session, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindOpticalFlowSessionImageNV(IntPtr device, IntPtr session, VkOpticalFlowSessionBindingPointNV bindingPoint, IntPtr view, VkImageLayout layout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdOpticalFlowExecuteNV(IntPtr commandBuffer, IntPtr session, VkOpticalFlowExecuteInfoNV* pExecuteInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkAntiLagUpdateAMD(IntPtr device, VkAntiLagDataAMD* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateShadersEXT(IntPtr device, uint createInfoCount, VkShaderCreateInfoEXT* pCreateInfos, VkAllocationCallbacks* pAllocator, IntPtr* pShaders);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyShaderEXT(IntPtr device, IntPtr shader, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetShaderBinaryDataEXT(IntPtr device, IntPtr shader, nuint* pDataSize, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindShadersEXT(IntPtr commandBuffer, uint stageCount, VkShaderStageFlagBits* pStages, IntPtr* pShaders);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetDepthClampRangeEXT(IntPtr commandBuffer, VkDepthClampModeEXT depthClampMode, VkDepthClampRangeEXT* pDepthClampRange);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetFramebufferTilePropertiesQCOM(IntPtr device, IntPtr framebuffer, uint* pPropertiesCount, VkTilePropertiesQCOM* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDynamicRenderingTilePropertiesQCOM(IntPtr device, VkRenderingInfo* pRenderingInfo, VkTilePropertiesQCOM* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceCooperativeVectorPropertiesNV(IntPtr physicalDevice, uint* pPropertyCount, VkCooperativeVectorPropertiesNV* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkConvertCooperativeVectorMatrixNV(IntPtr device, VkConvertCooperativeVectorMatrixInfoNV* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdConvertCooperativeVectorMatrixNV(IntPtr commandBuffer, uint infoCount, VkConvertCooperativeVectorMatrixInfoNV* pInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkSetLatencySleepModeNV(IntPtr device, IntPtr swapchain, VkLatencySleepModeInfoNV* pSleepModeInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkLatencySleepNV(IntPtr device, IntPtr swapchain, VkLatencySleepInfoNV* pSleepInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkSetLatencyMarkerNV(IntPtr device, IntPtr swapchain, VkSetLatencyMarkerInfoNV* pLatencyMarkerInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetLatencyTimingsNV(IntPtr device, IntPtr swapchain, VkGetLatencyMarkerInfoNV* pLatencyMarkerInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkQueueNotifyOutOfBandNV(IntPtr queue, VkOutOfBandQueueTypeInfoNV* pQueueTypeInfo);

        public const ulong VK_DATA_GRAPH_PIPELINE_SESSION_CREATE_PROTECTED_BIT_ARM = 0x00000001UL;

        public const ulong VK_DATA_GRAPH_PIPELINE_SESSION_CREATE_OPTICAL_FLOW_CACHE_BIT_ARM = 0x00000002UL;

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDataGraphPipelinesARM(IntPtr device, IntPtr deferredOperation, IntPtr pipelineCache, uint createInfoCount, VkDataGraphPipelineCreateInfoARM* pCreateInfos, VkAllocationCallbacks* pAllocator, IntPtr* pPipelines);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateDataGraphPipelineSessionARM(IntPtr device, VkDataGraphPipelineSessionCreateInfoARM* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSession);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDataGraphPipelineSessionBindPointRequirementsARM(IntPtr device, VkDataGraphPipelineSessionBindPointRequirementsInfoARM* pInfo, uint* pBindPointRequirementCount, VkDataGraphPipelineSessionBindPointRequirementARM* pBindPointRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDataGraphPipelineSessionMemoryRequirementsARM(IntPtr device, VkDataGraphPipelineSessionMemoryRequirementsInfoARM* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBindDataGraphPipelineSessionMemoryARM(IntPtr device, uint bindInfoCount, VkBindDataGraphPipelineSessionMemoryInfoARM* pBindInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyDataGraphPipelineSessionARM(IntPtr device, IntPtr session, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDispatchDataGraphARM(IntPtr commandBuffer, IntPtr session, VkDataGraphPipelineDispatchInfoARM* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDataGraphPipelineAvailablePropertiesARM(IntPtr device, VkDataGraphPipelineInfoARM* pPipelineInfo, uint* pPropertiesCount, VkDataGraphPipelinePropertyARM* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDataGraphPipelinePropertiesARM(IntPtr device, VkDataGraphPipelineInfoARM* pPipelineInfo, uint propertiesCount, VkDataGraphPipelinePropertyQueryResultARM* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceQueueFamilyDataGraphPropertiesARM(IntPtr physicalDevice, uint queueFamilyIndex, uint* pQueueFamilyDataGraphPropertyCount, VkQueueFamilyDataGraphPropertiesARM* pQueueFamilyDataGraphProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPhysicalDeviceQueueFamilyDataGraphProcessingEnginePropertiesARM(IntPtr physicalDevice, VkPhysicalDeviceQueueFamilyDataGraphProcessingEngineInfoARM* pQueueFamilyDataGraphProcessingEngineInfo, VkQueueFamilyDataGraphProcessingEnginePropertiesARM* pQueueFamilyDataGraphProcessingEngineProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceQueueFamilyDataGraphEngineOperationPropertiesARM(IntPtr physicalDevice, uint queueFamilyIndex, VkQueueFamilyDataGraphPropertiesARM* pQueueFamilyDataGraphProperties, VkBaseOutStructure* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetAttachmentFeedbackLoopEnableEXT(IntPtr commandBuffer, uint aspectMask);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBindTileMemoryQCOM(IntPtr commandBuffer, VkTileMemoryBindInfoQCOM* pTileMemoryBindInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDecompressMemoryEXT(IntPtr commandBuffer, VkDecompressMemoryInfoEXT* pDecompressMemoryInfoEXT);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDecompressMemoryIndirectCountEXT(IntPtr commandBuffer, ulong decompressionMethod, ulong indirectCommandsAddress, ulong indirectCommandsCountAddress, uint maxDecompressionCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateExternalComputeQueueNV(IntPtr device, VkExternalComputeQueueCreateInfoNV* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pExternalQueue);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyExternalComputeQueueNV(IntPtr device, IntPtr externalQueue, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetExternalComputeQueueDataNV(IntPtr externalQueue, VkExternalComputeQueueDataParamsNV* @params, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetClusterAccelerationStructureBuildSizesNV(IntPtr device, VkClusterAccelerationStructureInputInfoNV* pInfo, VkAccelerationStructureBuildSizesInfoKHR* pSizeInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBuildClusterAccelerationStructureIndirectNV(IntPtr commandBuffer, VkClusterAccelerationStructureCommandsInfoNV* pCommandInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetPartitionedAccelerationStructuresBuildSizesNV(IntPtr device, VkPartitionedAccelerationStructureInstancesInputNV* pInfo, VkAccelerationStructureBuildSizesInfoKHR* pSizeInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBuildPartitionedAccelerationStructuresNV(IntPtr commandBuffer, VkBuildPartitionedAccelerationStructureInfoNV* pBuildInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetGeneratedCommandsMemoryRequirementsEXT(IntPtr device, VkGeneratedCommandsMemoryRequirementsInfoEXT* pInfo, VkMemoryRequirements2* pMemoryRequirements);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdPreprocessGeneratedCommandsEXT(IntPtr commandBuffer, VkGeneratedCommandsInfoEXT* pGeneratedCommandsInfo, IntPtr stateCommandBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdExecuteGeneratedCommandsEXT(IntPtr commandBuffer, uint isPreprocessed, VkGeneratedCommandsInfoEXT* pGeneratedCommandsInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateIndirectCommandsLayoutEXT(IntPtr device, VkIndirectCommandsLayoutCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pIndirectCommandsLayout);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyIndirectCommandsLayoutEXT(IntPtr device, IntPtr indirectCommandsLayout, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateIndirectExecutionSetEXT(IntPtr device, VkIndirectExecutionSetCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pIndirectExecutionSet);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyIndirectExecutionSetEXT(IntPtr device, IntPtr indirectExecutionSet, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkUpdateIndirectExecutionSetPipelineEXT(IntPtr device, IntPtr indirectExecutionSet, uint executionSetWriteCount, VkWriteIndirectExecutionSetPipelineEXT* pExecutionSetWrites);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkUpdateIndirectExecutionSetShaderEXT(IntPtr device, IntPtr indirectExecutionSet, uint executionSetWriteCount, VkWriteIndirectExecutionSetShaderEXT* pExecutionSetWrites);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceCooperativeMatrixFlexibleDimensionsPropertiesNV(IntPtr physicalDevice, uint* pPropertyCount, VkCooperativeMatrixFlexibleDimensionsPropertiesNV* pProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumeratePhysicalDeviceQueueFamilyPerformanceCountersByRegionARM(IntPtr physicalDevice, uint queueFamilyIndex, uint* pCounterCount, VkPerformanceCounterARM* pCounters, VkPerformanceCounterDescriptionARM* pCounterDescriptions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkEnumeratePhysicalDeviceShaderInstrumentationMetricsARM(IntPtr physicalDevice, uint* pDescriptionCount, VkShaderInstrumentationMetricDescriptionARM* pDescriptions);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateShaderInstrumentationARM(IntPtr device, VkShaderInstrumentationCreateInfoARM* pCreateInfo, VkAllocationCallbacks* pAllocator, VkShaderInstrumentationARM** pInstrumentation);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyShaderInstrumentationARM(IntPtr device, VkShaderInstrumentationARM* instrumentation, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginShaderInstrumentationARM(IntPtr commandBuffer, VkShaderInstrumentationARM* instrumentation);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndShaderInstrumentationARM(IntPtr commandBuffer);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetShaderInstrumentationValuesARM(IntPtr device, VkShaderInstrumentationARM* instrumentation, uint* pMetricBlockCount, void* pMetricValues, uint flags);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkClearShaderInstrumentationMetricsARM(IntPtr device, VkShaderInstrumentationARM* instrumentation);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdEndRendering2EXT(IntPtr commandBuffer, VkRenderingEndInfoKHR* pRenderingEndInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBeginCustomResolveEXT(IntPtr commandBuffer, VkBeginCustomResolveInfoEXT* pBeginCustomResolveInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceQueueFamilyDataGraphOpticalFlowImageFormatsARM(IntPtr physicalDevice, uint queueFamilyIndex, VkQueueFamilyDataGraphPropertiesARM* pQueueFamilyDataGraphProperties, VkDataGraphOpticalFlowImageFormatInfoARM* pOpticalFlowImageFormatInfo, uint* pFormatCount, VkDataGraphOpticalFlowImageFormatPropertiesARM* pImageFormatProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetComputeOccupancyPriorityNV(IntPtr commandBuffer, VkComputeOccupancyPriorityParametersNV* pParameters);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetPrimitiveRestartIndexEXT(IntPtr commandBuffer, uint primitiveRestartIndex);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateAccelerationStructureKHR(IntPtr device, VkAccelerationStructureCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pAccelerationStructure);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkDestroyAccelerationStructureKHR(IntPtr device, IntPtr accelerationStructure, VkAllocationCallbacks* pAllocator);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBuildAccelerationStructuresKHR(IntPtr commandBuffer, uint infoCount, VkAccelerationStructureBuildGeometryInfoKHR* pInfos, VkAccelerationStructureBuildRangeInfoKHR** ppBuildRangeInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdBuildAccelerationStructuresIndirectKHR(IntPtr commandBuffer, uint infoCount, VkAccelerationStructureBuildGeometryInfoKHR* pInfos, ulong* pIndirectDeviceAddresses, uint* pIndirectStrides, uint** ppMaxPrimitiveCounts);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkBuildAccelerationStructuresKHR(IntPtr device, IntPtr deferredOperation, uint infoCount, VkAccelerationStructureBuildGeometryInfoKHR* pInfos, VkAccelerationStructureBuildRangeInfoKHR** ppBuildRangeInfos);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyAccelerationStructureKHR(IntPtr device, IntPtr deferredOperation, VkCopyAccelerationStructureInfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyAccelerationStructureToMemoryKHR(IntPtr device, IntPtr deferredOperation, VkCopyAccelerationStructureToMemoryInfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCopyMemoryToAccelerationStructureKHR(IntPtr device, IntPtr deferredOperation, VkCopyMemoryToAccelerationStructureInfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkWriteAccelerationStructuresPropertiesKHR(IntPtr device, uint accelerationStructureCount, IntPtr* pAccelerationStructures, VkQueryType queryType, nuint dataSize, void* pData, nuint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyAccelerationStructureKHR(IntPtr commandBuffer, VkCopyAccelerationStructureInfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyAccelerationStructureToMemoryKHR(IntPtr commandBuffer, VkCopyAccelerationStructureToMemoryInfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdCopyMemoryToAccelerationStructureKHR(IntPtr commandBuffer, VkCopyMemoryToAccelerationStructureInfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetAccelerationStructureDeviceAddressKHR(IntPtr device, VkAccelerationStructureDeviceAddressInfoKHR* pInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdWriteAccelerationStructuresPropertiesKHR(IntPtr commandBuffer, uint accelerationStructureCount, IntPtr* pAccelerationStructures, VkQueryType queryType, IntPtr queryPool, uint firstQuery);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetDeviceAccelerationStructureCompatibilityKHR(IntPtr device, VkAccelerationStructureVersionInfoKHR* pVersionInfo, VkAccelerationStructureCompatibilityKHR* pCompatibility);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkGetAccelerationStructureBuildSizesKHR(IntPtr device, VkAccelerationStructureBuildTypeKHR buildType, VkAccelerationStructureBuildGeometryInfoKHR* pBuildInfo, uint* pMaxPrimitiveCounts, VkAccelerationStructureBuildSizesInfoKHR* pSizeInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdTraceRaysKHR(IntPtr commandBuffer, VkStridedDeviceAddressRegionKHR* pRaygenShaderBindingTable, VkStridedDeviceAddressRegionKHR* pMissShaderBindingTable, VkStridedDeviceAddressRegionKHR* pHitShaderBindingTable, VkStridedDeviceAddressRegionKHR* pCallableShaderBindingTable, uint width, uint height, uint depth);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateRayTracingPipelinesKHR(IntPtr device, IntPtr deferredOperation, IntPtr pipelineCache, uint createInfoCount, VkRayTracingPipelineCreateInfoKHR* pCreateInfos, VkAllocationCallbacks* pAllocator, IntPtr* pPipelines);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetRayTracingCaptureReplayShaderGroupHandlesKHR(IntPtr device, IntPtr pipeline, uint firstGroup, uint groupCount, nuint dataSize, void* pData);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdTraceRaysIndirectKHR(IntPtr commandBuffer, VkStridedDeviceAddressRegionKHR* pRaygenShaderBindingTable, VkStridedDeviceAddressRegionKHR* pMissShaderBindingTable, VkStridedDeviceAddressRegionKHR* pHitShaderBindingTable, VkStridedDeviceAddressRegionKHR* pCallableShaderBindingTable, ulong indirectDeviceAddress);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern ulong vkGetRayTracingShaderGroupStackSizeKHR(IntPtr device, IntPtr pipeline, uint group, VkShaderGroupShaderKHR groupShader);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdSetRayTracingPipelineStackSizeKHR(IntPtr commandBuffer, uint pipelineStackSize);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawMeshTasksEXT(IntPtr commandBuffer, uint groupCountX, uint groupCountY, uint groupCountZ);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawMeshTasksIndirectEXT(IntPtr commandBuffer, IntPtr buffer, ulong offset, uint drawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkCmdDrawMeshTasksIndirectCountEXT(IntPtr commandBuffer, IntPtr buffer, ulong offset, IntPtr countBuffer, ulong countBufferOffset, uint maxDrawCount, uint stride);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateMetalSurfaceEXT(IntPtr instance, VkMetalSurfaceCreateInfoEXT* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSurface);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern void vkExportMetalObjectsEXT(IntPtr device, VkExportMetalObjectsInfoEXT* pMetalObjectsInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetMemoryMetalHandleEXT(IntPtr device, VkMemoryGetMetalHandleInfoEXT* pGetMetalHandleInfo, void** pHandle);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetMemoryMetalHandlePropertiesEXT(IntPtr device, VkExternalMemoryHandleTypeFlagBits handleType, void* pHandle, VkMemoryMetalHandlePropertiesEXT* pMemoryMetalHandleProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateWin32SurfaceKHR(IntPtr instance, VkWin32SurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSurface);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint vkGetPhysicalDeviceWin32PresentationSupportKHR(IntPtr physicalDevice, uint queueFamilyIndex);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetMemoryWin32HandleKHR(IntPtr device, VkMemoryGetWin32HandleInfoKHR* pGetWin32HandleInfo, void** pHandle);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetMemoryWin32HandlePropertiesKHR(IntPtr device, VkExternalMemoryHandleTypeFlagBits handleType, void* handle, VkMemoryWin32HandlePropertiesKHR* pMemoryWin32HandleProperties);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkImportSemaphoreWin32HandleKHR(IntPtr device, VkImportSemaphoreWin32HandleInfoKHR* pImportSemaphoreWin32HandleInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetSemaphoreWin32HandleKHR(IntPtr device, VkSemaphoreGetWin32HandleInfoKHR* pGetWin32HandleInfo, void** pHandle);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkImportFenceWin32HandleKHR(IntPtr device, VkImportFenceWin32HandleInfoKHR* pImportFenceWin32HandleInfo);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetFenceWin32HandleKHR(IntPtr device, VkFenceGetWin32HandleInfoKHR* pGetWin32HandleInfo, void** pHandle);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetMemoryWin32HandleNV(IntPtr device, IntPtr memory, uint handleType, void** pHandle);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetPhysicalDeviceSurfacePresentModes2EXT(IntPtr physicalDevice, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, uint* pPresentModeCount, VkPresentModeKHR* pPresentModes);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkAcquireFullScreenExclusiveModeEXT(IntPtr device, IntPtr swapchain);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkReleaseFullScreenExclusiveModeEXT(IntPtr device, IntPtr swapchain);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetDeviceGroupSurfacePresentModes2EXT(IntPtr device, VkPhysicalDeviceSurfaceInfo2KHR* pSurfaceInfo, uint* pModes);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkAcquireWinrtDisplayNV(IntPtr physicalDevice, IntPtr display);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkGetWinrtDisplayNV(IntPtr physicalDevice, uint deviceRelativeId, IntPtr* pDisplay);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
    public static extern VkResult vkCreateXlibSurfaceKHR(IntPtr instance, VkXlibSurfaceCreateInfoKHR* pCreateInfo, VkAllocationCallbacks* pAllocator, IntPtr* pSurface);

    [DllImport("vulkan", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern uint vkGetPhysicalDeviceXlibPresentationSupportKHR(IntPtr physicalDevice, uint queueFamilyIndex, void** dpy, nuint visualID);
}
