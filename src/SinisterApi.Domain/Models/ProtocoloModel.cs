namespace SinisterApi.Domain.Models
{
    internal class ProtocoloModel
    {
        public int ProtocolNumber { get; set; }
        public string PolicyNumber { get; set; }
        public string SinisterNumber { get; set; }
        public DateTime DateCommunicant { get; set; }
        public DateTime DateOccurrence { get; set; }
    }
}
