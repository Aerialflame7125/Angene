namespace Angene.Common
{
    public class Attributes
    {
        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, Inherited = true)]
        public class PrecompileAttribute : Attribute { } // Literally just a marker attribute.
    }
}
