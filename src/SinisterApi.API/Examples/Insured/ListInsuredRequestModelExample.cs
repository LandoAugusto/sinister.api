using SinisterApi.API.Models.Insured;
using Swashbuckle.AspNetCore.Filters;

namespace SinisterApi.API.Examples.Insured
{
    public class ListInsuredRequestModelExample : IExamplesProvider<ListInsuredRequestModel>
    {
        public ListInsuredRequestModel GetExamples() => new()
        {
            Name = null,
            DocumentNumber = "99420050050",
        };
    }
}
