using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Models;
using SinisterApi.Service.Interfaces;

namespace SinisterApi.Application.Services
{
    internal class ProposalApplication : IProposalApplication
    {
        private readonly IProposalSevice _proposalSevice;
        public ProposalApplication(IProposalSevice proposalSevice) => _proposalSevice = proposalSevice;

        public async Task<ProposalModel> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber)
        {
           return await _proposalSevice.GetBusinnesProposalAsync(brokerUserId, proposalNumber);
        }
    }
}
