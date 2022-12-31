using FluentValidation.Results;

namespace Domain.Core.Models.Standard
{
    public class ValidationErrorModel
    {
        public string PropertyName { get; }
        public string ErrorMessage { get; }
        public object AttemptedValue { get; }
        public string ErrorCode { get; }

        public ValidationErrorModel(ValidationFailure error)
        {
            PropertyName = error.PropertyName;
            ErrorMessage = error.ErrorMessage;
            AttemptedValue = error.AttemptedValue;
            ErrorCode = error.ErrorCode;
        }
    }
}
