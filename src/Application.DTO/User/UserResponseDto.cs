namespace Application.DTO.User
{
    public class UserResponseDto
    {
        public UserResponseDto(int? id, string? name)
        {
            Id = id;
            Name = name;
        }
        public int? Id { get; set; }
        public string? Name { get; set; }
    }
}
