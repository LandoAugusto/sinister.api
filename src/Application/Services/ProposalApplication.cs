using Application.DTO.Proposal;
using Application.Interfaces;
using Application.Mappers;
using Integration.BMG.Interfaces;

namespace Application.Services
{
    internal class ProposalApplication : IProposalApplication
    {
        private readonly IProposalService _proposalSevice;
        public ProposalApplication(IProposalService proposalSevice) => _proposalSevice = proposalSevice;

        public async Task<ProposalResponseDto> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber)
        {
            return ProposalMap.Map(await _proposalSevice.GetBusinnesProposalAsync(brokerUserId, proposalNumber));
        }
    }
}
