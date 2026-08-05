namespace Angene.Graphics
{
    internal class Exceptions
    {
        public class GraphicsException : Exception
        {
            public GraphicsException(string message) : base(message) { }
            public GraphicsException(string message, Exception inner) : base(message, inner) { }
        }
        public class FailedToCreateGraphicsBackendException : Exception
        {
            public FailedToCreateGraphicsBackendException(string message) : base(message) { }
            public FailedToCreateGraphicsBackendException(string message, Exception inner) : base(message, inner) { }
        }
        public class FailedToInitializeVulkanException : Exception
        {
            public FailedToInitializeVulkanException(string message) : base(message) { }
            public FailedToInitializeVulkanException(string message, Exception inner) : base(message, inner) { }
        }
    }
}
