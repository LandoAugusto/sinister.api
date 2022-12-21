﻿using SinisterApi.API.Models.Policy;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Policy
{
    public class ListPoliciesRequestModelExample : IExamplesProvider<ListPoliciesRequestModel>
    {
        public ListPoliciesRequestModel GetExamples() => new()
        {           
            PolicyId = 29259,
            InsuredPersonId = null,
            StipulatorPersonId = null,
            Certificate = null,
        };
    }
}