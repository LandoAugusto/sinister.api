using SinisterApi.DTO.Policy;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Policy
{
    public class ListPoliciesRequestModelExample : IExamplesProvider<ListPoliciesRequestDto>
    {
        public ListPoliciesRequestDto GetExamples() => new()
        {           
            PolicyId = 28878,
            InsuredPersonId = null,
            StipulatorPersonId = null,
            Certificate = null,
        };
    }
}