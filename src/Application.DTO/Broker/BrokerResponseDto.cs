namespace Application.DTO.Broker
{
    public class BrokerResponseDto
    {
        public BrokerResponseDto(int? personId, long? documentNumber, string? name, string? susepCode)
        {
            PersonId = personId;
            DocumentNumber = documentNumber;
            Name = name;
            SusepCode = susepCode;
        }

        public int? PersonId { get; set; }
        public long? DocumentNumber { get; set; }
        public string? Name { get; set; }
        public string? SusepCode { get; set; }
    }
}
