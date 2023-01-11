using Application.DTO.Insured;
using Application.Interfaces;
using Domain.Core.Extensions;
using Integration.BMG.Interfaces;

namespace Application.Services
{
    internal class InsuredApplication : IInsuredApplication
    {
        private readonly IInsuredService _insuredService;    
        public InsuredApplication(IInsuredService insuredService) =>
            _insuredService = insuredService;

        public async Task<List<InsuredResponseDto>?> ListInsuredAsync(string name, string documentNumber)
        {
            var list = await _insuredService.ListInsuredAsync(name, documentNumber);
            if (!list.IsAny<InsuredResponseDto>()) return null;

            return list;

        }
        public async Task<InsuredResponseDto?> GetByIdAsync(int insuredId)
        {
            var response = await _insuredService.GetByIdAsync(insuredId);
            if (response == null) return null;

            return response;
        }      
    }
}
