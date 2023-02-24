using System.Runtime.Serialization;

namespace SvSupportSales.Commons
{
    public class ServiceException : Exception
    {
        public ServiceException()
        {
        }
        public ServiceException(string message) : base(message)
        {
            // Add any type-specific logic.
        }
        public ServiceException(string message, Exception innerException) : base(message, innerException)
        {
            // Add any type-specific logic for inner exceptions.
        }
        protected ServiceException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
            // Implement type-specific serialization constructor logic.
        }
    }
}
