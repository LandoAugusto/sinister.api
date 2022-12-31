using Domain.Core.Models;

namespace Application.Interfaces
{
    public interface IInsurdeApplication
    {
        Task<InsuredModel> GetInsuredAsync(int insuredPersonId);
        Task<List<InsuredModel>> ListInsuredAsync(string name, string documentNumber);
    }
}
