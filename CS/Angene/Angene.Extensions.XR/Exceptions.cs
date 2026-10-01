namespace Angene.Extensions.XR;

public class Exceptions
{
    public class FailedToInitializeOpenXRException : Exception
    {
        public FailedToInitializeOpenXRException(string message) : base(message) { }
        public FailedToInitializeOpenXRException(string message, Exception inner) : base(message, inner) { }
    }
    
    public class FailedToEnumerateSwapchainImageOpenXRException : Exception
    {
        public FailedToEnumerateSwapchainImageOpenXRException(string message) : base(message) { }
        public FailedToEnumerateSwapchainImageOpenXRException(string message, Exception inner) : base(message, inner) { }
    }
    public class OpenXRSessionException : Exception
    {
        public OpenXRSessionException(string message) : base(message) { }
        public OpenXRSessionException(string message, Exception inner) : base(message, inner) { }
    }
}