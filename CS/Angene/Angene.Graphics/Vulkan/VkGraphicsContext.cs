using Angene.Common;
using Angene.Graphics;
using Angene.Windows;
public class VkGraphicsContext : IVkGraphicsContext
{
    private IntPtr _VkInstance;
    private IntPtr _VkPhysicalDevice;
    private IntPtr _VkDevice;
    private IntPtr _VkQueue;
    private IntPtr _VkSurfaceKHR;
    private IntPtr _VkSwapchainKHR;
    private IntPtr _VkFormat;
    private IntPtr _VkExtent2D;
    private int _SwapchainImageCount;
    private int _CurrentImageIndex;
    private IntPtr _VkCommandPool;
    private IntPtr _VkCommandBuffer;
    private IntPtr _VkRenderPass;
    private IntPtr _VkFramebuffer;
    private IntPtr _VkPipeline;
    private IntPtr _VkSemaphoreImageAvailable;
    private IntPtr _VkSemaphoreRenderFinished;
    private IntPtr _VkFenceInFlight;


    public IntPtr VkPhysicalDevice => _VkPhysicalDevice;
    public IntPtr VkDevice => _VkDevice;
    public IntPtr VkQueue => _VkQueue;
    public IntPtr VkSurfaceKHR => _VkSurfaceKHR;
    public IntPtr VkInstance => _VkInstance;
    public IntPtr VkSwapchainKHR => _VkSwapchainKHR;
    public IntPtr VkFormat => _VkFormat;
    public IntPtr VkExtent2D => _VkExtent2D;
    public int SwapchainImageCount => _SwapchainImageCount;
    public int CurrentImageIndex => _CurrentImageIndex;
    public IntPtr VkCommandPool => _VkCommandPool;
    public IntPtr VkCommandBuffer => _VkCommandBuffer;
    public IntPtr VkRenderPass => _VkRenderPass;
    public IntPtr VkFramebuffer => _VkFramebuffer;
    public IntPtr VkPipeline => _VkPipeline;
    public IntPtr VkSemaphoreImageAvailable => _VkSemaphoreImageAvailable;
    public IntPtr VkSemaphoreRenderFinished => _VkSemaphoreRenderFinished;
    public IntPtr VkFenceInFlight => _VkFenceInFlight;

    // IGraphicsContext
    public IntPtr Handle => VkDevice;
    public IntPtr ContextHandle => VkInstance;

    // Window stuff
    private IntPtr _hwnd;
    private int _w, _h;

    // Keeping instances so we dont keep remaking shit
    private IntPtr _existingContext, _existingDevice;
    private bool _sharingDevice;

    public VkGraphicsContext(IntPtr hwnd, int width, int height, IntPtr existingDevice, IntPtr existingContext)
    {
        this._hwnd = hwnd;
        this._w = width;
        this._h = height;
        _existingContext = existingContext;
        _existingDevice = existingDevice;

        try
        {
            if (existingDevice != IntPtr.Zero && existingContext != IntPtr.Zero)
            {
                _VkDevice = existingDevice;
                _VkInstance = existingContext;
                _sharingDevice = true;
            }
            else
            {
                // Initialize Vk
            }
            // Swapchain, rendertargetview, depthstencilview, rendertargets and viewport
        }
        catch (Exception ex)
        {
            Logger.LogCritical($"[Vulkan] Initialization failed: {ex.Message}", LoggingTarget.Engine, ex);
            throw;
        }
    }

    public void BeginFrame()
    {
        
    }


    public void Clear(uint color)
    {
        
    }

    public void EndFrame()
    {
        
    }

    public byte[] GetRawPixels()
    {
        return new byte[0];
    }

    public void Present(IntPtr windowHandle)
    {
        
    }

    public void Render()
    {
        
    }

    public void Resize(int width, int height)
    {
        
    }
    public void Cleanup()
    {
        
    }
}