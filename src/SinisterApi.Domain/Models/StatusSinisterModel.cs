namespace SinisterApi.Domain.Models
{
    public class StatusSinisterModel
    {
        public StatusSinisterModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
