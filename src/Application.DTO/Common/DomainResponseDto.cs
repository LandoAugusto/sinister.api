namespace Application.DTO.Common
{
    public class DomainResponseDto
    {
        public DomainResponseDto(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
