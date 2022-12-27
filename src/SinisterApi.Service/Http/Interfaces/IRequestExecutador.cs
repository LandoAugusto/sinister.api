namespace SinisterApi.Service.Http.Interfaces
{
    internal interface IRequestExecutador
    {
        Task<(TResponse, TErrorResponse)> GetJsonApiAsync<TResponse, TErrorResponse>(
              string url,
              int timeoutInMilliseconds = 10000000,
              CancellationToken cancellationToken = default);

        Task<(int StatusCode, TResponse ResponseObject, TErrorResponse ErrorResponseObject)> PostManyJsonApiAsync<TBody, TResponse, TErrorResponse>(
           string url,
           TBody body,
           int timeoutInMilliseconds,
           bool isToken = false,
           CancellationToken cancellationToken = default);
    }
}
