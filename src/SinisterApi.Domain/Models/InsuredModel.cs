namespace SinisterApi.Domain.Models
{
    public class InsuredModel
    {
        public InsuredModel(int? personId, string? name, long? documentNumber)
        {
            this.PersonId = personId;
            this.Name = name;
            this.DocumentNumber = documentNumber;
        }
        public int? PersonId { get; set; }
        public string? Name { get; set; }
        public long? DocumentNumber { get; set; }
        public List<AddressModel> Address { get; set; }
    }
}
