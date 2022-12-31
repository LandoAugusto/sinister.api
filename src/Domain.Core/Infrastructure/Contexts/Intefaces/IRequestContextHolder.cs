namespace Domain.Core.Infrastructure.Contexts.Intefaces
{
    public interface IRequestContextHolder
    {
        public Guid CorrelationId { get; set; }

        public object RequestBody { get; set; }

        public string RequestUser { get; set; }
    }
}
