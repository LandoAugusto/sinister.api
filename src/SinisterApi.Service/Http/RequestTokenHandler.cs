using Flurl.Http;
using SinisterApi.Service.Http.Interfaces;

namespace SinisterApi.Service.Http
{
    public class RequestTokenHandler : IRequestTokenHandler
    {
        public string AuthorizationToken { get; set; }
        //private readonly IRedisCacheRepository _redisCacheRepository;
        //private readonly IAuthenticationService _authenticationService;
        //public RequestTokenHandler(IRedisCacheRepository redisCacheRepository, IAuthenticationService authenticationService) =>
        //   (_redisCacheRepository, _authenticationService) = (redisCacheRepository, authenticationService);

        //public async Task GenerateTokenAsync()
        //{
        //    var accessToken = await _redisCacheRepository.StringGetAsync<string>(("accessToken"));
        //    if (!string.IsNullOrEmpty(accessToken))
        //    {
        //        AuthorizationToken = accessToken;
        //        return;
        //    }

        //    var generateToken = await _authenticationService.GenerateTokenAsync();
        //    if (generateToken != null)
        //        await _redisCacheRepository.StringSetAsync("accessToken", generateToken);

        //    AuthorizationToken = generateToken;
        //}

        public bool IsWorthRetryingAsync(FlurlHttpException ex)
        {
            switch ((int)ex.Call.Response.StatusCode)
            {
                case 401:
                    _ = GetTokenAsync();
                    return true;
                case 408:
                case 500:
                case 502:
                case 504:
                    return true;
                default:
                    return false;
            }
        }

        private async Task GetTokenAsync()
        {
            //var generateToken = await _authenticationService.GenerateTokenAsync();
            //if (generateToken != null)
            //    await _redisCacheRepository.StringSetAsync("accessToken", generateToken);

            //AuthorizationToken = generateToken;            
        }
    }
}
