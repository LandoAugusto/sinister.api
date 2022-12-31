using Microsoft.AspNetCore.Mvc.Filters;
using Domain.Core.Infrastructure.Contexts.Intefaces;
using Infrastruture.Logger.Interfaces;

namespace SinisterApi.API.Filters
{
    internal class ControllersFilter : IActionFilter
    {
        private readonly ILogWriter _logWriter;
        private readonly IRequestContextHolder _requestContextHolder;

        public ControllersFilter(
             ILogWriter logWrite,
             IRequestContextHolder requestContextHolder) =>
             (_requestContextHolder, _logWriter) = (requestContextHolder, logWrite);

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var controllerName = context.Controller.GetType().FullName;
            _logWriter.Info($"Executed {controllerName}");
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerName = context.Controller.GetType().FullName;
            _logWriter.Info($"Executing {controllerName}", _requestContextHolder.RequestBody);
        }
    }
}
