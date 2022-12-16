using System.Runtime.Serialization;
using static SinisterApi.Domain.Extensions.StringExtension;

namespace SinisterApi.Domain.Infrastructure.Exceptions
{
    internal class NotOpenTransactionException : UnitOfWorkException
    {
        private const string ErrorMessage =
           "There is no transaction openend to {0}";

        public NotOpenTransactionException()
        {
        }

        public NotOpenTransactionException(string operation)
            : base(ErrorMessage.Format(operation))
        {
        }

        public NotOpenTransactionException(string message, Exception inner)
            : base(message, inner)
        {
        }

        protected NotOpenTransactionException(
            SerializationInfo serializationInfo,
            StreamingContext streamingContext)
            : base(serializationInfo, streamingContext)
        {
        }
    }
}

