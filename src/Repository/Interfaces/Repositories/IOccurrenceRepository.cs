﻿using Domain.Core.Entities;
using Repository.Interfaces.Repositories.Standard;

namespace Repository.Interfaces.Repositories
{
    public interface IOccurrenceRepository : IDomainRepository<Occurrence>
    {
        Task<Occurrence> GetByIdAsync(int notificationId);
    }
}

