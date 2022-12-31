﻿using Application.Interfaces;
using Domain.Core.Models;
using SinisterApi.Service.Interfaces;

namespace Application.Services
{
    internal class InsurdeApplication : IInsurdeApplication
    {
        private readonly IInsuredService _insuredService;
        public InsurdeApplication(IInsuredService insuredService) =>
            _insuredService = insuredService;

        public async Task<List<InsuredModel>> ListInsuredAsync(string name, string documentNumber) =>
         await _insuredService.ListInsuredAsync(name, documentNumber);

        public async Task<InsuredModel> GetInsuredAsync(int insuredPersonId) =>
             await _insuredService.GetInsuredAsync(insuredPersonId);

    }
}