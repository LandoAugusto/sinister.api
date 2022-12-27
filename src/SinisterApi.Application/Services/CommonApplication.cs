using SinisterApi.Application.Interfaces;
using SinisterApi.Domain.Entities;
using SinisterApi.Domain.Extensions;
using SinisterApi.Domain.Models;
using SinisterApi.Repository.Interfaces.Repositories;

namespace SinisterApi.Application.Services
{
    internal class CommonApplication : ICommonApplication
    {
        private readonly ICommunicantTypeRepository _communicantTypeRepository;
        private readonly IPeriodTypeRepository _periodTypeRepository;
        private readonly IStatusSinisterRepository _statusSinisterRepository;
        private readonly ISituationSinisterRepository _situationSinisterRepository;

        public CommonApplication(
            ICommunicantTypeRepository communicantTypeRepository, 
            IPeriodTypeRepository periodTypeRepository,
            IStatusSinisterRepository statusSinisterRepository,
            ISituationSinisterRepository situationSinisterRepository)
        {
            _communicantTypeRepository = communicantTypeRepository;
            _periodTypeRepository = periodTypeRepository;
            _statusSinisterRepository = statusSinisterRepository;
            _situationSinisterRepository = situationSinisterRepository;
        }

        public async Task<IEnumerable<PeriodTypeModel>> ListPeriodTypeAsync()
        {
            var list = await _periodTypeRepository.GetAllAsync();
            if (!list.IsAny<PeriodType>()) return null;

            var result = new List<PeriodTypeModel>();
            foreach (var item in list)
                result.Add(new PeriodTypeModel(item.Id, item.Name));

            return result;
        }

        public async Task<IEnumerable<CommunicantTypeModel>> ListCommunicantTypeAsync()
        {
            var list = await _communicantTypeRepository.GetAllAsync();
            if (!list.IsAny<CommunicantType>()) return null;          
            
            var result = new List<CommunicantTypeModel>();
            foreach (var item in list)
                result.Add(new CommunicantTypeModel(item.Id, item.Name));

            return result;
        }

        public async Task<IEnumerable<StatusModel>> ListStatusAsync()
        {
            var list = await _statusSinisterRepository.GetAllAsync();
            if (!list.IsAny<Status>()) return null;          

            var result = new List<StatusModel>();
            foreach (var item in list)
                result.Add(new StatusModel(item.Id, item.Name));

            return result;
        }

        public async Task<IEnumerable<SituationModel>> ListSituationAsync()
        {
            var list = await _situationSinisterRepository.GetAllAsync();
            if (!list.IsAny<Situation>()) return null;

            var result = new List<SituationModel>();
            foreach (var item in list)
                result.Add(new SituationModel(item.Id, item.Name));

            return result;
        }
    }
}
