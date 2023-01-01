

using Integration.BMG.Schemas;

namespace Integration.BMG.Interfaces
{
    public interface IProposalService
    {
        Task<ProposalResponse> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber);
    }
}
