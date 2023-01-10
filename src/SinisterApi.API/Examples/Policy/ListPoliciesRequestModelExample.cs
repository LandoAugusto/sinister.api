using Application.DTO.Policy;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Policy
{
    public class ListPoliciesRequestModelExample : IExamplesProvider<ListPoliciesRequestDto>
    {
        public ListPoliciesRequestDto GetExamples() => new()
        {           
            PolicyId = null,
            InsuredPersonId = 334747,
            StipulatorPersonId = null,
            Certificate = null,
        };
    }
}