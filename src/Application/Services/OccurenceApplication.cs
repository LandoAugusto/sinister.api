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

        public async Task<int> UpdateSaveOccurrenceAsync(int userId, UpdateSaveOccurenceRequestDto request)
        {
            try
            {
                int occurrenceId = 0;
                var ocurrence = await _occurrenceRepository.GetByIdAsync(request.NotificationId);
                if (ocurrence is null)
                    occurrenceId = await SaveAsync(userId, request);
                else
                    occurrenceId = await UpdateAsync(userId, request, ocurrence);

                await _notificationApplication.UpdateStageNotificationAscync(request.NotificationId, PhaseEnum.Insured);

                return occurrenceId;
            }
            catch (Exception)
            {
                throw;
            }
        }

        private async Task<int> SaveAsync(int userId, UpdateSaveOccurenceRequestDto request)
        {
            var entity = new Occurrence(request.NotificationId, request.DateOccurence, request.TimeOccurrence,
                request.DescriptonOccurence, request.DescriptionDamage, request.Damage, request.IsRiskLocation, request.Comments, userId);

            foreach (var occurenceAddress in request.Address)
                entity.OccurenceAddress.Add(new OccurrenceAddress(occurenceAddress.ZipCode, occurenceAddress.StreetName,
                    occurenceAddress.StateName, occurenceAddress.StateInitials, occurenceAddress.Number, occurenceAddress.Complement,
                    occurenceAddress.District, occurenceAddress.City, userId));

            foreach (var occurrencePhone in request.Phone)
                entity.OccurencePhone.Add(new OccurrencePhone(occurrencePhone.Name, occurrencePhone.PhoneTypeId, occurrencePhone.Ddd, occurrencePhone.Phone, userId));


            var result = await _occurrenceRepository.AddAsync(entity);

            return result.Id;
        }

        private async Task<int> UpdateAsync(int userId, UpdateSaveOccurenceRequestDto request, Occurrence occurrence)
        {
            occurrence.DateOccurrence = request.DateOccurence;
            occurrence.TimeOccurrence = request.TimeOccurrence;
            occurrence.DescriptonOccurrence = request.DescriptonOccurence;
            occurrence.DescriptionDamage = request.DescriptionDamage;
            occurrence.Damage = request.Damage;
            occurrence.Comments = request.Comments;
            occurrence.UpdatedDate = DateTime.Now;

            foreach (var item in request.Phone)
            {
                var phone = occurrence.OccurencePhone.Where(x => x.Phone.Equals(item.Phone)).FirstOrDefault();
                if (phone is null)
                    occurrence.OccurencePhone.Add(new OccurrencePhone(item.Name, item.PhoneTypeId, item.Ddd, item.Phone, userId));
                else
                {
                    phone.PhoneTypeId = item.PhoneTypeId;
                    phone.Phone = item.Phone;
                    phone.UpdatedDate = DateTime.Now;
                }
            }

            foreach (var item in request.Address)
            {
                var address = occurrence.OccurenceAddress.Where(x => x.ZipCode.Equals(item.ZipCode)).FirstOrDefault();
                if (address is null)
                    occurrence.OccurenceAddress.Add(new OccurrenceAddress(item.ZipCode, item.StreetName, item.StateName, item.StateInitials, item.Number, item.Complement, item.District, item.City, userId));
                else
                {
                    address.ZipCode = item.ZipCode;
                    address.StreetName = item.StreetName;
                    address.StateName = item.StateName;
                    address.StateInitials = item.StateInitials;
                    address.Number = item.Number;
                    address.Complement = item.Complement;
                    address.District = item.District;
                    address.City = item.City;                    
                    address.UpdatedDate = DateTime.Now;
                }
            }

            return await _occurrenceRepository.UpdateAsync(occurrence);
        }
    }
}
