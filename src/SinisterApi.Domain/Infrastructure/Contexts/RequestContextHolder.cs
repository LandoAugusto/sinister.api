using SinisterApi.Domain.Infrastructure.Contexts.Intefaces;

namespace SinisterApi.Domain.Infrastructure.Contexts
{
    public class RequestContextHolder : IRequestContextHolder
    {
        public Guid CorrelationId { get; set; }

        public object RequestBody { get; set; }

        public string RequestUser { get; set; }
    }
}
