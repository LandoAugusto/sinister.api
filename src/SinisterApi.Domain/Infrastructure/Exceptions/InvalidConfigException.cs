using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace SinisterApi.Domain.Infrastructure.Exceptions
{
    public class InvalidConfigException : Exception
    {
        private const string ExMessage = "Invalid values for configuration {0}, errors: {1}";

        public InvalidConfigException(string message)
            : base(message)
        {
        }

        public InvalidConfigException(IEnumerable<ValidationResult> validationResults, string configName)
            : base(FormatExMessage(validationResults, configName))
        {
        }

        protected InvalidConfigException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        protected InvalidConfigException()
        {
        }

        protected InvalidConfigException(string message, Exception innerEx)
            : base(message, innerEx)
        {
        }

        private static string FormatExMessage(IEnumerable<ValidationResult> validationResults, string configName) => string.Format(
            ExMessage,
            string.Join(" | ", validationResults.Select(vr => vr.ErrorMessage)),
            configName);
    }
}
