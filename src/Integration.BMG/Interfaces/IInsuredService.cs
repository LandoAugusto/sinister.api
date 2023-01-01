using Integration.BMG.Schemas;

namespace Integration.BMG.Interfaces
{
    public interface IInsuredService
    {
        Task<InsuredResponse> GetInsuredAsync(int insuredPersonId);

        Task<List<InsuredResponse>> ListInsuredAsync(string name, string documentNumber);
    }
}
