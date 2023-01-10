using Application.DTO.Proposal;

namespace Integration.BMG.Interfaces
{
    public interface IProposalService
    {
        Task<ProposalResponseDto> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber);
    }
}
