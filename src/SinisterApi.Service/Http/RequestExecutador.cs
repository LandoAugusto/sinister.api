using Flurl.Http;
using Polly;
using SinisterApi.Infra.Logger.Interfaces;
using SinisterApi.Service.Http.Interfaces;
using System.Net;

namespace SinisterApi.Service.Http
{
    internal class RequestExecutador : IRequestExecutador
    {
        private const string JsonApiContentType = "application/json";
        private readonly ILogWriter _logWriter;
        private readonly IRequestErrorHandler _errorHandler;
        private readonly IRequestTokenHandler _tokenHandler;

        public RequestExecutador(IRequestTokenHandler tokenHandler, IRequestErrorHandler errorHandler, ILogWriter logWriter) =>
           (_tokenHandler, _errorHandler, _logWriter) = (tokenHandler, errorHandler, logWriter);

        public async Task<(TResponse, TErrorResponse)> GetJsonApiAsync<TResponse, TErrorResponse>(
             string url,
             int timeoutInMilliseconds = 10000000,
             CancellationToken cancellationToken = default)
        {
            try
            {
                //await _tokenHandler.GenerateTokenAsync();

                TResponse response = (await Policy
                    .Handle<FlurlHttpException>(_tokenHandler.IsWorthRetryingAsync)
                    .WaitAndRetryAsync(new[] { TimeSpan.FromSeconds(1) })
                .ExecuteAsync(() =>
                     SetupRequest(url, timeoutInMilliseconds)
                        .GetJsonAsync<TResponse>(cancellationToken)
                    ));

                return (response, default(TErrorResponse));
            }
            catch (Exception e)
            {                
                var (handledException, statusCode, errorResponse) = await _errorHandler.HandleExceptionAsync<TErrorResponse>(e);

                _logWriter.Error(handledException.Message, handledException.Data, handledException);
                if (statusCode == (int)HttpStatusCode.NotFound || (statusCode == (int)HttpStatusCode.BadRequest))
                {
                    return ( default(TResponse), errorResponse);
                }
                throw handledException;
            }
        }

        public async Task<(int StatusCode, TResponse ResponseObject, TErrorResponse ErrorResponseObject)> PostManyJsonApiAsync<TBody, TResponse, TErrorResponse>(
            string url,
            TBody body,
            int timeoutInMilliseconds,
            CancellationToken cancellationToken = default)
        {
            try
            {
                // await _tokenHandler.GenerateTokenAsync();
                var response = await SetupRequest(url, timeoutInMilliseconds)
                    .PostJsonAsync(body, cancellationToken);
                var responseObject = await response.GetJsonAsync<TResponse>();

                return (response.StatusCode, responseObject, default(TErrorResponse));
            }
            catch (Exception e)
            {
                var (handledException, statusCode, errorResponse) = await _errorHandler.HandleExceptionAsync<TErrorResponse>(e);
                _logWriter.Error(handledException.Message, body, handledException);
                if (statusCode == (int)HttpStatusCode.NotFound || (statusCode == (int)HttpStatusCode.BadRequest))
                {
                    return (statusCode, default(TResponse), errorResponse);
                }

                throw handledException;
            }
        }

        private IFlurlRequest SetupRequest(string url, int timeoutInMilliseconds) => url
            .WithOAuthBearerToken(_tokenHandler.AuthorizationToken)
            .WithHeaders(new
            {
                Content_Type = JsonApiContentType,
            })
            .ConfigureRequest(cfg =>
            {
                cfg.Timeout = timeoutInMilliseconds is 0 ? null : TimeSpan.FromMilliseconds(timeoutInMilliseconds);
                cfg.UrlEncodedSerializer = null;
            });
    }
}
