namespace Angene.Extensions.XR;

public class Exceptions
{
    public class FailedToInitializeOpenXRException : Exception
    {
        public FailedToInitializeOpenXRException(string message) : base(message) { }
        public FailedToInitializeOpenXRException(string message, Exception inner) : base(message, inner) { }
    }
}