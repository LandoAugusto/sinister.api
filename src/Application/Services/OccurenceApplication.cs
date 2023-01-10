using Application.DTO.Common;
using Application.DTO.Occurence;
using Application.Interfaces;
using Domain.Core.Entities;
using Domain.Core.Eums;
using Repository.Interfaces.Repositories;

namespace Application.Services
{
    internal class OccurenceApplication : IOccurenceApplication
    {
        private readonly IOccurrenceRepository _occurrenceRepository;
        private readonly INotificationApplication _notificationApplication;

        public OccurenceApplication(IOccurrenceRepository occurrenceRepository, INotificationApplication notificationApplication) =>
            (_occurrenceRepository, _notificationApplication) = (occurrenceRepository, notificationApplication);

        public async Task<GetOccurenceResponseDto?> GetOccurrenceAsync(int notificaitonId)
        {
            var entity = await _occurrenceRepository.GetByIdAsync(notificaitonId);
            if (entity == null) return null;

            var response = new GetOccurenceResponseDto()
            {
                Id = entity.Id,
                NotificationId = entity.NotificationId,
                DateOccurence = entity.DateOccurrence,
                TimeOccurrence = entity.TimeOccurrence,
                DescriptonOccurrence = entity.DescriptonOccurrence,
                DescriptionDamage = entity.DescriptionDamage,
                Damage = entity.Damage,
                Comments = entity.Comments,
                IsRiskLocation = entity.IsRiskLocation,
                
            };

            foreach (var item in entity.OccurencePhone)
            {
                response.Phone.Add(new OccurencePhoneResponseDto()
                {
                    Id = item.Id,
                    Name = item.Name,
                    PhoneTypeId = item.PhoneTypeId,
                    Ddd = item.Ddd,
                    Phone = item.Phone,
                });
            }
            foreach (var item in entity.OccurenceAddress)
            {
                response.Address.Add(new AddressResponseDto()
                {
                    Id = item.Id,
                    ZipCode = item.ZipCode,
                    StreetName = item.StreetName,
                    StateName = item.StateName,
                    StateInitials = item.StateInitials,
                    Number = item.Number,
                    Complement = item.Complement,
                    District = item.District,
                    City = item.City
                });
            }
            return response;
        }

        public async Task<int> SaveOccurrenceAsync(int userId, SaveOccurenceRequestDto request)
        {
            try
            {
                var entity = new Occurrence(request.NotificationId, request.DateOccurence, request.TimeOccurrence, request.DescriptonOccurence,
                    request.DescriptionDamage, request.Damage, request.IsRiskLocation, request.Comments, userId);

                foreach (var occurenceAddress in request.Address)
                    entity.OccurenceAddress.Add(new OccurrenceAddress(occurenceAddress.ZipCode.ToString(), occurenceAddress.StreetName, 
                        occurenceAddress.StateName, occurenceAddress.StateInitials, occurenceAddress.Number, occurenceAddress.Complement, occurenceAddress.District, occurenceAddress.City, userId));

                foreach (var occurrencePhone in request.Phone)
                    entity.OccurencePhone.Add(new OccurrencePhone(occurrencePhone.Name, occurrencePhone.PhoneTypeId, occurrencePhone.Ddd, occurrencePhone.Phone, userId));

                var result = await _occurrenceRepository.AddAsync(entity);
                await _notificationApplication.UpdateStageNotificationAscync(request.NotificationId, PhaseEnum.Insured);

                return result.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
