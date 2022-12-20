namespace SinisterApi.Domain.Entities
{
    public class StatusSinister 
    {
        public int StatusSinisterId { get; set; }
        public string Name { get; set; }
        public bool Active { get; set; }
        public DateTime CreatedDt { get; set; }
        public DateTime? UpatedDt { get; set; }

    }
}
