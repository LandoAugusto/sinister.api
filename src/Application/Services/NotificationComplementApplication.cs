using Application.DTO.NotificationComplement;
using Application.Interfaces;
using Domain.Core.Entities;
using Domain.Core.Eums;
using Repository.Interfaces.Repositories;

namespace Application.Services
{
    internal class NotificationComplementApplication : INotificationComplementApplication
    {
        private readonly INotificationApplication _notificationApplication;
        private readonly INotificationComplementRepository _notificationComplementRepository;

        public NotificationComplementApplication(
            INotificationApplication notificationApplication,
            INotificationComplementRepository notificationComplementRepository) =>
           (_notificationApplication, _notificationComplementRepository) = (notificationApplication, notificationComplementRepository);

        public async Task<int> SaveNotificationComplementAsync(SaveComplementRequestDto request)
        {
            var response = await _notificationComplementRepository.AddAsync(
                new NotificationComplement(request.NotificationId, request.IsContentious, request.ProcessNumber, request.ProcessDate, request.ProcessTypeId,
                request.IsPoliceReport, request.PoliceReportNumber, request.IsThird, request.IsProvedor));

            await _notificationApplication.UpdateStageNotificationAscync(request.NotificationId, PhaseEnum.Coverage);

            return response.Id;
        }
    }
}
