using Flurl.Http;

namespace SinisterApi.Service.Http.Interfaces
{
    public interface IRequestTokenHandler
    {
        public string AuthorizationToken { get; set; }
        Task GenerateTokenAsync();
        bool IsWorthRetryingAsync(FlurlHttpException ex);
    }
}
