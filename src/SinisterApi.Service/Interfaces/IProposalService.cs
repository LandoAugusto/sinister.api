﻿using SinisterApi.Domain.Models;

namespace SinisterApi.Service.Interfaces
{
    public interface IProposalService
    {
        Task<ProposalModel> GetBusinnesProposalAsync(int brokerUserId, string proposalNumber);
    }
}
