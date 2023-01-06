namespace Application.DTO.Common
{
    public class PhoneResponseDto
    {
        public PhoneResponseDto(int id, int phoneTypeId, string ddd, string phone, DateTime createdDate)
        {
            this.Id = id;
            this.PhoneTypeId = phoneTypeId;
            this.Ddd = ddd;
            this.Phone = phone;
            this.CreatedDate = createdDate;
        }

        public int Id { get; set; }
        public int PhoneTypeId { get; set; }
        public string Ddd { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
