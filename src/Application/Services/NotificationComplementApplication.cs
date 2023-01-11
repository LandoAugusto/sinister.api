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

        public async Task<int> UpdateSaveComplementAsync(int userId, UpdateSaveComplementRequestDto request)
        {
            int complementId;
            var complement = await _notificationComplementRepository.GetByIdAsync(request.NotificationId);
            if (complement is null)
                complementId = await SaveAsync(userId, request);
            else
                complementId = await UpdateAsync(request, complement);

            await _notificationApplication.UpdateStageNotificationAscync(request.NotificationId, PhaseEnum.Coverage);

            return complementId;
        }

        private async Task<int> SaveAsync(int userId, UpdateSaveComplementRequestDto request)
        {
            var response = await _notificationComplementRepository.AddAsync(
               new NotificationComplement(request.NotificationId, request.IsContentious, request.ProcessNumber, request.ProcessDate, request.ProcessTypeId,
               request.IsPoliceReport, request.PoliceReportNumber, request.IsThird, request.IsProvedor));

            return response.Id;
        }

        private async Task<int> UpdateAsync(UpdateSaveComplementRequestDto request, NotificationComplement complement)
        {
            complement.IsThird = request.IsThird;
            complement.IsProvedor = request.IsProvedor;
            complement.IsContentious = request.IsContentious;
            complement.ProcessNumber = request.ProcessNumber;
            complement.ProcessDate = request.ProcessDate;
            complement.ProcessTypeId = request.ProcessTypeId;
            complement.IsPoliceReport = request.IsPoliceReport;
            complement.PoliceReportNumber = request.PoliceReportNumber;
            complement.UpdatedDate = DateTime.Now;

            return await _notificationComplementRepository.UpdateAsync(complement);
        }
    }
}
