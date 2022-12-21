using SinisterApi.Domain.Models;

namespace SinisterApi.Application.Interfaces
{
    public interface IProposalApplication
    {
        Task<ProposalModel> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber);
    }
}
