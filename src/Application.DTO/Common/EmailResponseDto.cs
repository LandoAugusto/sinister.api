namespace Application.DTO.Common
{
    public class EmailResponseDto
    {
        public EmailResponseDto(int id, int emailTypeId, string email, DateTime createdDate)
        {
            this.Id = id;
            this.EmailTypeId = emailTypeId;
            this.Email = email;
            this.CreatedDate = createdDate;
        }

        public int Id { get; set; }
        public int EmailTypeId { get; set; }
        public string Email { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
