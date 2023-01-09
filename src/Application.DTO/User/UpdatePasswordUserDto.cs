namespace Application.DTO.User
{
    public class UpdatePasswordUserDto
    {
        public string Id { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}
