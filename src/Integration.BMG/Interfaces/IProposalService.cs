using Domain.Core.Models;

namespace Integration.BMG.Interfaces
{
    public interface IProposalService
    {
        Task<ProposalModel> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber);
    }
}
