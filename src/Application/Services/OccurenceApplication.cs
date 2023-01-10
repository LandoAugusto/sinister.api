using Application.DTO.Occurence;
using Application.Interfaces;
using Domain.Core.Entities;
using Repository.Interfaces.Repositories;

namespace Application.Services
{
    internal class OccurenceApplication : IOccurenceApplication
    {
        private readonly IOccurrenceRepository _occurrenceRepository;

        public OccurenceApplication(IOccurrenceRepository occurrenceRepository) =>
            _occurrenceRepository = occurrenceRepository;

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
                        PhoneTypeId = phone.PhoneTypeId,
                        Ddd = phone.Ddd,
                        Phone = phone.Phone,
                        InclusionUserId = userId
                    });
                }
                var result = await _occurrenceRepository.AddAsync(entity);

                return result.Id;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
