
namespace GCB.Specification
{
    [Serializable]
    internal class UnsupportedPlatformException : Exception
    {
        public UnsupportedPlatformException()
        {
        }

        public UnsupportedPlatformException(string? message) : base(message)
        {
        }

        public UnsupportedPlatformException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}