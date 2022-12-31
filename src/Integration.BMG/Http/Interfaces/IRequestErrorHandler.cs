namespace Integration.BMG.Http.Interfaces
{
    public interface IRequestErrorHandler
    {
        Task<(Exception Exception, int StatusCode)> HandleExceptionAsync(Exception ex);
        Task<(Exception Exception, int StatusCode, TErrorResponse ErrorResponse)> HandleExceptionAsync<TErrorResponse>(Exception ex);
    }
}
