namespace SinisterApi.Service.Interfaces
{
    internal interface IAuthenticationService
    {
        Task<string> GetTokenAsync(string login, string password);
    }
}
