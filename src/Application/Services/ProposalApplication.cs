using Application.DTO.Proposal;
using Application.Interfaces;
using Integration.BMG.Interfaces;

namespace Application.Services
{
    internal class ProposalApplication : IProposalApplication
    {
        private readonly IProposalService _proposalSevice;
        public ProposalApplication(IProposalService proposalSevice) => _proposalSevice = proposalSevice;

        public async Task<ProposalResponseDto?> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber)
        {
            var response = await _proposalSevice.GetBusinnesProposalAsync(brokerUserId, proposalNumber);
            if (response == null) return null;

            return response;
        }
    }
}
