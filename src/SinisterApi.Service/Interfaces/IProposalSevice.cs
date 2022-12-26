using SinisterApi.Domain.Models;

namespace SinisterApi.Service.Interfaces
{
    public interface IProposalSevice
    {
        Task<ProposalModel> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber);
    }
}
