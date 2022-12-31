namespace Integration.BMG.Interfaces
{
    public interface IAuthenticationService
    {
        Task<string> GetTokenAsync(string login, string password);
    }
}
