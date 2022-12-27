namespace SinisterApi.Service.Schemas
{
    internal class GetTokenResponseModel
    {
        public bool Sucess { get; set; }
        public TokenResponse Data { get; set; }
    }

    internal class TokenResponse
    {
        public string AccessToken { get; set; }
    }
}
