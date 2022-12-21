using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinisterApi.Service.Exceptions
{
    [Serializable]
    [ExcludeFromCodeCoverage]
    public class ServiceUnavailableException : CustomException
    {
        private const string ExMessage = "the requested service was unavailable";

        public ServiceUnavailableException(Exception innerEx)
            : base(ExMessage, innerEx)
        {
        }

        protected ServiceUnavailableException()
        {
        }

        protected ServiceUnavailableException(string message)
            : base(message)
        {
        }

        protected ServiceUnavailableException(string message, Exception innerEx)
            : base(message, innerEx)
        {
        }
    }
}

