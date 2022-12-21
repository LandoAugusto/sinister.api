using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.Domain.Models;
using SinisterApi.Domain.Models.Standard;
using SinisterApi.Infra.Logger.Interfaces;

namespace SinisterApi.API.Interceptors
{
    public class FluentValidatorInterceptor : IValidatorInterceptor
    {
        private const string ValidationFailedMessage = "Appeal validation failed";
        private readonly ILogWriter _logWriter;

        public FluentValidatorInterceptor(ILogWriter logWriter) =>
            _logWriter = logWriter;

        public IValidationContext BeforeAspNetValidation(
            ActionContext actionContext,
            IValidationContext commonContext) => commonContext;

        public ValidationResult AfterAspNetValidation(
            ActionContext actionContext,
            IValidationContext validationContext,
            ValidationResult result)
        {
            if (!result.IsValid)
            {
                var errors = result.Errors.Select(err => new ValidationErrorModel(err)).ToArray();

                _logWriter.Error(ValidationFailedMessage, errors);
                actionContext.HttpContext.Items.Add(nameof(ValidationResult), result);
            }

            return result;
        }
    }
}
