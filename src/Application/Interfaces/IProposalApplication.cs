using Application.DTO.Proposal;

namespace Application.Interfaces
{
    public interface IProposalApplication
    {
        Task<ProposalResponseDto> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber);
    }
}
