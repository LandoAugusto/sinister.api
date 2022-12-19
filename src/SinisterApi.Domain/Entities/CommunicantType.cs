namespace SinisterApi.Domain.Entities
{
    public class CommunicantType 
    {
        public int CommunicantTypeId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime? UpatedDt { get; set; }

    }
}
