using Flurl.Http;
using SinisterApi.Domain.Constants;
using SinisterApi.Service.Exceptions;
using SinisterApi.Service.Http.Interfaces;

namespace SinisterApi.Service.Http
{
    internal class RequestErrorHandler : IRequestErrorHandler
    {
        public async Task<(Exception Exception, int StatusCode)> HandleExceptionAsync(Exception ex)
        {
            if (ex?.InnerException is OperationCanceledException opEx)
            {
                return (new OperationCanceledException(ex.Message, opEx), ResponseCodes.NotApplicable);
            }

            if (ex is FlurlHttpException fex)
            {
                var statusCode = fex.StatusCode ?? ResponseCodes.NotApplicable;
                return (await ResolveExceptionFromFlurl(fex), statusCode);
            }

            if (ex is FlurlHttpTimeoutException flrTimeEx)
            {
                var statusCode = flrTimeEx.StatusCode ?? ResponseCodes.NotApplicable;
                return (await ResolveExceptionFromFlurl(flrTimeEx), statusCode);
            }
            return (ex, ResponseCodes.NotApplicable);
        }

        public async Task<(Exception Exception, int StatusCode, TErrorResponse ErrorResponse)> HandleExceptionAsync<TErrorResponse>(Exception ex)
        {
            if (ex?.InnerException is OperationCanceledException opEx)
            {
                return (new OperationCanceledException(ex.Message, opEx), ResponseCodes.NotApplicable, default(TErrorResponse));
            }

            if (ex is FlurlHttpException fex)
            {
                var statusCode = fex.StatusCode ?? ResponseCodes.NotApplicable;
                TErrorResponse errorResponse = await fex.GetResponseJsonAsync<TErrorResponse>();

                return (Exception: await ResolveExceptionFromFlurl(fex), StatusCode: statusCode, ErrorResponse: errorResponse);
            }
            return (ex, ResponseCodes.NotApplicable, default(TErrorResponse));
        }

        private static async Task<Exception> ResolveExceptionFromFlurl(FlurlHttpException fex)
        {
            var reqEx = await RequestException.FromFlurlException(fex);

            if (reqEx.ServiceUnavailable)
            {
                return new ServiceUnavailableException(reqEx);
            }

            return reqEx;
        }
    }
}
