using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Entities;
using SinisterApi.Domain.Extensions;
using SinisterApi.Domain.Models;
using SinisterApi.Repository.Interfaces.Repositories;
using SinisterApi.Service.Interfaces;

namespace SinisterApi.Application.Services
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

        public async Task<ZipCodeModel> GetZipCodeAsync(int zipCode) =>
             await _addressService.GetZipCodeAsync(zipCode);


        public async Task<IEnumerable<DomainModel>> ListPhoneTypeAsync()
        {
            var list = await _phoneTypeRepository.GetAllAsync();
            if (!list.IsAny<PhoneType>()) return null;

            var result = new List<DomainModel>();
            foreach (var item in list)
                result.Add(new DomainModel(item.Id, item.Name));

            return result;
        }
        public async Task<IEnumerable<DomainModel>> ListEmailTypeAsync()
        {
            var list = await _emailTypeRepository.GetAllAsync();
            if (!list.IsAny<EmailType>()) return null;

            var result = new List<DomainModel>();
            foreach (var item in list)
                result.Add(new DomainModel(item.Id, item.Name));

            return result;
        }
        public async Task<IEnumerable<DomainModel>> ListPeriodTypeAsync()
        {
            var list = await _periodTypeRepository.GetAllAsync();
            if (!list.IsAny<PeriodType>()) return null;

            var result = new List<DomainModel>();
            foreach (var item in list)
                result.Add(new DomainModel(item.Id, item.Name));

            return result;
        }

        public async Task<IEnumerable<DomainModel>> ListCommunicantTypeAsync()
        {
            var list = await _communicantTypeRepository.GetAllAsync();
            if (!list.IsAny<CommunicantType>()) return null;

            var result = new List<DomainModel>();
            foreach (var item in list)
                result.Add(new DomainModel(item.Id, item.Name));

            return result;
        }

        public async Task<IEnumerable<DomainModel>> ListStatusAsync()
        {
            var list = await _statusSinisterRepository.GetAllAsync();
            if (!list.IsAny<Status>()) return null;

            var result = new List<DomainModel>();
            foreach (var item in list)
                result.Add(new DomainModel(item.Id, item.Name));

            return result;
        }

        public async Task<IEnumerable<DomainModel>> ListSituationAsync()
        {
            var list = await _situationSinisterRepository.GetAllAsync();
            if (!list.IsAny<Situation>()) return null;

            var result = new List<DomainModel>();
            foreach (var item in list)
                result.Add(new DomainModel(item.Id, item.Name));

            return result;
        }
    }
}
