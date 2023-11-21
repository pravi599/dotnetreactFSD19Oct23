using System.Runtime.Serialization;

namespace HotelApplication.Exceptions
{
    [Serializable]
    internal class NoBookingsAvailableException : Exception
    {
        public NoBookingsAvailableException()
        {
        }

        public NoBookingsAvailableException(string? message) : base(message)
        {
        }

        public NoBookingsAvailableException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected NoBookingsAvailableException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}