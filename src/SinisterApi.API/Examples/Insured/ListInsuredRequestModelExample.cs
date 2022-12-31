using SinisterApi.DTO.Insured;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Insured
{
    public class ListInsuredRequestModelExample : IExamplesProvider<ListInsuredRequestDto>
    {
        public ListInsuredRequestDto GetExamples() => new()
        {
            Name = null,
            DocumentNumber = "99420050050",
        };
    }
}
