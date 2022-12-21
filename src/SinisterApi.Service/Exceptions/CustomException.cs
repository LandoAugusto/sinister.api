using System.Runtime.Serialization;

namespace SinisterApi.Service.Exceptions
{
    public abstract class CustomException : Exception
    {

        protected CustomException()
        {

        }

        protected CustomException(string message)
            : base(message)
        {
        }

        protected CustomException(string message, Exception innerEx)
        : base(message, innerEx)
        {
        }

        protected CustomException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {

        }
    }
}