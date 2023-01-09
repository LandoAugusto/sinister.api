namespace Application.DTO.Common
{
    public class EmailRequestDto
    {
        public int EmailTypeId { get; set; }

        public string Email { get; set; }

        public bool SendAutomatic { get; set; }        
    }
}
