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

        public async Task<int> UpdateSaveCommunicantAsync(UpdateSaveCommunicantRequestDto request, int userId)
        {
            try
            {
                int communicantId = 0;

                var comunicant = await _communicantRepository.GetByIdAsync(request.NotificationId);
                if (comunicant is null)
                    communicantId = await SaveAsync(request, userId);
                else
                    communicantId = await UpdateAsync(request, userId, comunicant);

                await _notificationApplication.UpdateStageNotificationAscync(request.NotificationId, Domain.Core.Eums.PhaseEnum.Occurrence);

                return communicantId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<int> SaveAsync(UpdateSaveCommunicantRequestDto request, int userId)
        {
            var entity = new Communicant(request.NotificationId, request.CommunicantTypeId, request.Name, userId);
            foreach (var email in request.Email)
                entity.CommunicantEmail.Add(new CommunicantEmail(email.EmailTypeId, email.Email, email.SendAutomatic, userId));

            foreach (var phone in request.Phone)
                entity.CommunicantPhone.Add(new CommunicantPhone(phone.PhoneTypeId, phone.Ddd, phone.Phone, userId));

            var result = await _communicantRepository.AddAsync(entity);

            return result.Id;
        }

        private async Task<int> UpdateAsync(UpdateSaveCommunicantRequestDto request, int userId, Communicant comunicant)
        {
            comunicant.CommunicantTypeId = request.CommunicantTypeId;
            comunicant.Name = request.Name;
            comunicant.UpdatedDate = DateTime.Now;
            foreach (var item in request.Email)
            {
                var email = comunicant.CommunicantEmail.Where(x => x.Email.Equals(item.Email)).FirstOrDefault();
                if (email is null)
                    comunicant.CommunicantEmail.Add(new CommunicantEmail(comunicant.Id, item.EmailTypeId, item.Email, item.SendAutomatic, userId));
                else
                {
                    email.EmailTypeId = item.EmailTypeId;
                    email.Email = item.Email;
                    email.SendAutomatic = item.SendAutomatic;
                    email.UpdatedDate = DateTime.Now;
                }
            }

            foreach (var item in request.Phone)
            {
                var phone = comunicant.CommunicantPhone.Where(x => x.Phone.Equals(item.Phone)).FirstOrDefault();
                if (phone is null)
                    comunicant.CommunicantPhone.Add(new CommunicantPhone(comunicant.Id, item.PhoneTypeId, item.Ddd, item.Phone, userId));
                else
                {
                    phone.PhoneTypeId = item.PhoneTypeId;
                    phone.Phone = item.Phone;
                    phone.UpdatedDate = DateTime.Now;
                }
            }

            return await _communicantRepository.UpdateAsync(comunicant);
        }
    }
}
