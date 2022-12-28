namespace SinisterApi.Domain.Models
{
    public class InsuredModel
    {
        public InsuredModel(int? personId, string? name, long? documentNumber, List<AddressModel> address)
        {
            this.PersonId = personId;
            this.Name = name;
            this.DocumentNumber = documentNumber;
            this.Address = address;
        }
        public int? PersonId { get; set; }
        public string? Name { get; set; }
        public long? DocumentNumber { get; set; }
        public List<AddressModel> Address { get; set; } = new List<AddressModel>();
    }
}
