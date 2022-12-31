using Application.Interfaces;
using Domain.Core.Models;
using SinisterApi.Service.Interfaces;

namespace Application.Services
{
    internal class ProposalApplication : IProposalApplication
    {
        private readonly IProposalService _proposalSevice;
        public ProposalApplication(IProposalService proposalSevice) => _proposalSevice = proposalSevice;

        public async Task<ProposalModel> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber)
        {
           return await _proposalSevice.GetBusinnesProposalAsync(brokerUserId, proposalNumber);
        }
    }
}
