namespace Domain.Core.Models
{
    public class DomainModel
    {
        public DomainModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
