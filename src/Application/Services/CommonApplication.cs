using Application.DTO.Common;
using Application.Interfaces;
using Domain.Core.Entities;
using Domain.Core.Extensions;
using Infrastructure.Data.Repository.Interfaces.Repositories;
using Integration.BMG.Interfaces;

namespace Application.Services
{
    internal class CommonApplication : ICommonApplication
    {
        private readonly IAddressService _addressService;
        private readonly IPhoneTypeRepository _phoneTypeRepository;
        private readonly IEmailTypeRepository _emailTypeRepository;
        private readonly ICommunicantTypeRepository _communicantTypeRepository;
        private readonly IPeriodTypeRepository _periodTypeRepository;
        private readonly IStatusRepository _statusSinisterRepository;
        private readonly ISituationRepository _situationSinisterRepository;

        public CommonApplication(
            IAddressService addressService,
            IPhoneTypeRepository phoneTypeRepository,
            IEmailTypeRepository emailTypeRepository,
            ICommunicantTypeRepository communicantTypeRepository,
            IPeriodTypeRepository periodTypeRepository,
            IStatusRepository statusSinisterRepository,
            ISituationRepository situationSinisterRepository)
        {
            _addressService = addressService;
            _phoneTypeRepository = phoneTypeRepository;
            _emailTypeRepository = emailTypeRepository;
            _communicantTypeRepository = communicantTypeRepository;
            _periodTypeRepository = periodTypeRepository;
            _statusSinisterRepository = statusSinisterRepository;
            _situationSinisterRepository = situationSinisterRepository;
        }

        public async Task<ZipCodeResponseDto> GetZipCodeAsync(int zipCode)
        {
            var result = await _addressService.GetZipCodeAsync(zipCode);

            return new ZipCodeResponseDto(result.StreetName, result.District, result.CityName, result.StateInitials, result.StateName);
        }
        public async Task<IEnumerable<DomainResponseDto>> ListPhoneTypeAsync()
        {
            var list = await _phoneTypeRepository.GetAllAsync();
            if (!list.IsAny<PhoneType>()) return null;

            var result = new List<DomainResponseDto>();
            foreach (var item in list)
                result.Add(new DomainResponseDto(item.Id, item.Name));

            return result;
        }
        public async Task<IEnumerable<DomainResponseDto>> ListEmailTypeAsync()
        {
            var list = await _emailTypeRepository.GetAllAsync();
            if (!list.IsAny<EmailType>()) return null;

            var result = new List<DomainResponseDto>();
            foreach (var item in list)
                result.Add(new DomainResponseDto(item.Id, item.Name));

            return result;
        }
        public async Task<IEnumerable<DomainResponseDto>> ListPeriodTypeAsync()
        {
            var list = await _periodTypeRepository.GetAllAsync();
            if (!list.IsAny<PeriodType>()) return null;

            var result = new List<DomainResponseDto>();
            foreach (var item in list)
                result.Add(new DomainResponseDto(item.Id, item.Name));

            return result;
        }

        public async Task<IEnumerable<DomainResponseDto>> ListCommunicantTypeAsync()
        {
            var list = await _communicantTypeRepository.GetAllAsync();
            if (!list.IsAny<CommunicantType>()) return null;

            var result = new List<DomainResponseDto>();
            foreach (var item in list)
                result.Add(new DomainResponseDto(item.Id, item.Name));

            return result;
        }

        public async Task<IEnumerable<DomainResponseDto>> ListStatusAsync()
        {
            var list = await _statusSinisterRepository.GetAllAsync();
            if (!list.IsAny<Status>()) return null;

            var result = new List<DomainResponseDto>();
            foreach (var item in list)
                result.Add(new DomainResponseDto(item.Id, item.Name));

            return result;
        }

        public async Task<IEnumerable<DomainResponseDto>> ListSituationAsync()
        {
            var list = await _situationSinisterRepository.GetAllAsync();
            if (!list.IsAny<Situation>()) return null;

            var result = new List<DomainResponseDto>();
            foreach (var item in list)
                result.Add(new DomainResponseDto(item.Id, item.Name));

            return result;
        }
    }
}
