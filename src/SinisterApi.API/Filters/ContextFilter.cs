using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SinisterApi.Domain.Constants;
using SinisterApi.Domain.Infrastructure.Contexts.Intefaces;
using SinisterApi.Domain.Models;
using SinisterApi.Infra.Logger.Interfaces;
using System.Security.Claims;

namespace SinisterApi.API.Filters
{
    internal class ContextFilter : IAsyncActionFilter
    {
        private readonly ILogWriter _logWriter;
        private readonly IRequestContextHolder _requestContextHolder;

        public ContextFilter(ILogWriter logWrite, IRequestContextHolder requestContextHolder) =>
            (_requestContextHolder, _logWriter) = (requestContextHolder, logWrite);

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var headers = context.HttpContext.Request.Headers;
            var correlationId = headers[HttpHeaders.CorrelationId];
            var parsed = Guid.TryParse(correlationId, out var guid)
                ? guid
                : Guid.NewGuid();

            _logWriter.SetCorrelationId(parsed);
            _requestContextHolder.CorrelationId = parsed;
            _requestContextHolder.RequestBody = GetRequestBody(context);
            _requestContextHolder.RequestUser = GetRequestUser(context);

            _requestContextHolder.RequestUser = "Teste Leandro";

            if (context.HttpContext.Items.TryGetValue(nameof(ValidationResult), out var value))
            {
                var validationResult = (ValidationResult)value;
                var errorResponse = ErrorResponseModel.FromValidation(validationResult);

                context.Result = new ObjectResult(errorResponse)
                {
                    StatusCode = ErrorResponseModel.StatusCode,
                };

                return;
            }

            await next();
        }

        private static object GetRequestBody(ActionExecutingContext context)
        {
            context.ActionArguments.TryGetValue("request", out var requestBody);
            return requestBody;
        }

        private static string GetRequestUser(ActionExecutingContext context)
        {
            var claimsIdentity = (ClaimsIdentity)context.HttpContext.User.Identity;
            var requestUser = claimsIdentity.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            return requestUser?.Value;
        }
    }
}