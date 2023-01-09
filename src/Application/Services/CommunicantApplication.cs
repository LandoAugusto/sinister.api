using Application.DTO.Common;
using Application.DTO.Communicant;
using Application.Interfaces;
using Domain.Core.Entities;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Application.DTO.Notification;

namespace Application.Services
{
    internal class CommunicantApplication : ICommunicantApplication
    {
        private readonly ICommunicantRepository _communicantRepository;

        public CommunicantApplication(ICommunicantRepository communicantRepository) =>
            _communicantRepository = communicantRepository;

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
                var entity = new Communicant(request.NotificationIdId, request.CommunicantTypeId, request.Name, userId);
                foreach (var email in request.Email)
                    entity.CommunicantEmail.Add(new CommunicantEmail(default, default, email.EmailTypeId, email.Email, userId));

                foreach (var phone in request.Phone)
                    entity.CommunicantPhone.Add(new CommunicantPhone(default, default, phone.PhoneTypeId, phone.Ddd, phone.Phone, userId));

                var result = await _communicantRepository.AddAsync(entity);

                return result.Id;

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
