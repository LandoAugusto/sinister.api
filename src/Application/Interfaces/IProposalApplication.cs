using Domain.Core.Models;

namespace Application.Interfaces
{
    public interface IProposalApplication
    {
        Task<ProposalModel> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber);
    }
}
