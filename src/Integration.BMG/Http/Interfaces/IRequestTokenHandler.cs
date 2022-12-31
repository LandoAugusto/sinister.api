using Flurl.Http;

namespace Integration.BMG.Http.Interfaces
{
    public interface IRequestTokenHandler
    {
        public string AuthorizationToken { get; set; }
        Task GenerateTokenAsync();
        bool IsWorthRetryingAsync(FlurlHttpException ex);
    }
}
