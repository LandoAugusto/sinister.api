using SinisterApi.Domain.Models.Policy;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Policy
{
    public class GetPolicyModelExample : IExamplesProvider<GetPolicyModel>
    {
        public GetPolicyModel GetExamples() => new()
        {           
            PolicyId = 150
        };
    }
}