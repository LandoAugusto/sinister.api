﻿using Domain.Core.Entities;
using Repository.Interfaces.Repositories.Standard;

namespace Infrastructure.Data.Repository.Interfaces.Repositories
{
    public interface INotificationRepository : IDomainRepository<Notification>
    {
        Task<IEnumerable<Notification>> ListNotificationAsync();
    }
}
