using Domain.Core.Infrastructure.Contexts.Intefaces;

namespace Domain.Core.Infrastructure.Contexts
{
    public class RequestContextHolder : IRequestContextHolder
    {
        public Guid CorrelationId { get; set; }

        public object RequestBody { get; set; }

        public string RequestUser { get; set; }
    }
}
