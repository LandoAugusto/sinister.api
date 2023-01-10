using Application.DTO.Common;
using Application.DTO.Communicant;
using Application.Interfaces;
using Domain.Core.Entities;
using Infrastructure.Data.Repository.Interfaces.Repositories;

namespace Application.Services
{
    internal class CommunicantApplication : ICommunicantApplication
    {
        private readonly ICommunicantRepository _communicantRepository;
        private readonly INotificationApplication _notificationApplication;
        public CommunicantApplication(ICommunicantRepository communicantRepository, INotificationApplication notificationApplication) =>
            (_communicantRepository, _notificationApplication) = (communicantRepository, notificationApplication);

        public async Task<GetCommunicantResponseDto> GetCommunicantAsync(int notificationId)
        {
            var entity = await _communicantRepository.GetByIdAsync(notificationId);
            if (entity is null) return null;

            var result = new GetCommunicantResponseDto(
                entity.Id, entity.NotificationId, entity.CommunicantTypeId, entity.Name, entity.InclusionUserId, entity.CreatedDate);

            foreach (var item in entity.CommunicantEmail)
                result.Email.Add(new EmailResponseDto(
                    item.Id, item.EmailTypeId, item.Email, item.CreatedDate));

            foreach (var item in entity.CommunicantPhone)
                result.Phone.Add(new PhoneResponseDto(
                    item.Id, item.PhoneTypeId, item.Ddd, item.Phone, item.CreatedDate));

            return result;
        }

        public async Task<int> SaveCommunicantAsync(SaveCommunicantRequestDto request, int userId)
        {
            try
            {
                var entity = new Communicant(request.NotificationId, request.CommunicantTypeId, request.Name, userId);
                foreach (var email in request.Email)
                    entity.CommunicantEmail.Add(new CommunicantEmail(default, default, email.EmailTypeId, email.Email, userId));

                foreach (var phone in request.Phone)
                    entity.CommunicantPhone.Add(new CommunicantPhone(default, default, phone.PhoneTypeId, phone.Ddd, phone.Phone, userId));

                var result = await _communicantRepository.AddAsync(entity);
                await _notificationApplication.UpdateStageNotificationAscync(request.NotificationId, Domain.Core.Eums.PhaseEnum.Occurrence);

                return result.Id;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
