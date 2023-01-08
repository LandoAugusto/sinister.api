﻿using Application.DTO.Notification;
using Application.DTO.Notification;

namespace Application.Interfaces
{
    public interface INotificationApplication
    {
        Task<IEnumerable<ListNotificationResponseDto>> ListNotificationAsync();
        Task<int> SaveNotificationAsync(int policyId, int codeItem);
    }
}
