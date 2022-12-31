using Domain.Core.Models;

namespace Integration.BMG.Interfaces
{
    public interface IInsuredService
    {
        Task<InsuredModel> GetInsuredAsync(int insuredPersonId);

        Task<List<InsuredModel>> ListInsuredAsync(string name, string documentNumber);
    }
}
