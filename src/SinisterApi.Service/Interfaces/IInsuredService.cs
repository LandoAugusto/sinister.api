using Domain.Core.Models;

namespace SinisterApi.Service.Interfaces
{
    public interface IInsuredService
    {
        Task<InsuredModel> GetInsuredAsync(int insuredPersonId);

        Task<List<InsuredModel>> ListInsuredAsync(string name, string documentNumber);
    }
}
