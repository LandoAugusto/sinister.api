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

        public async Task<int> SaveOccurrenceAsync(int userId, SaveOccurenceRequestDto request)
        {
            try
            {
                var entity = new Occurrence(
                    request.NotificationId,
                    request.DateOccurence,
                    request.TimeOccurrence,
                    request.DescriptonOccurence,
                    request.DescriptionDamage,
                    request.Damage,
                    request.IsRiskLocation,
                    request.Comments, userId);

                foreach (var address in request.Address)
                {
                    entity.OccurenceAddress.Add(new OccurrenceAddress()
                    {
                        ZipCode = address.ZipCode.ToString(),
                        StreetName = address.StreetName,
                        StateInitials = address.StateInitials,
                        StateName = address.StateName,
                        Number = address.Number,
                        Complement = address.Complement,
                        District = address.District,
                        City = address.City,
                        InclusionUserId = userId
                    });
                }

                foreach (var phone in request.Phone)
                {
                    entity.OccurencePhone.Add(new OccurrencePhone()
                    {
                        Name = phone.Name,
                        PhoneTypeId = phone.PhoneTypeId,
                        Ddd = phone.Ddd,
                        Phone = phone.Phone,
                        InclusionUserId = userId
                    });
                }
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
