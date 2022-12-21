using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SinisterApi.Domain.Infrastructure.Contexts.Intefaces;
using SinisterApi.Domain.Models;
using SinisterApi.Infra.Logger.Interfaces;
using SinisterApi.Service.Exceptions;
using Newtonsoft.Json;

namespace SinisterApi.API.Filters
{
    internal class ExceptionFilter : IExceptionFilter
    {
        private readonly ILogWriter _logWriter;
        private readonly IRequestContextHolder _requestContextHolder;
        public ExceptionFilter(
            ILogWriter logWriter,
            IRequestContextHolder requestContextHolder) =>
            (_logWriter, _requestContextHolder) = (logWriter, requestContextHolder);

        public void OnException(ExceptionContext context)
        {
            var ex = context.Exception;
            _logWriter.Error(
                message: ex.Message,
                data: _requestContextHolder.RequestBody,
                ex: ex,
                source: ex.TargetSite?.Name);

            context.ExceptionHandled = true;            

            context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
            context.Result = new ObjectResult(ErrorResponseModel.BuildError(ex.Message));
        }
    }
}
