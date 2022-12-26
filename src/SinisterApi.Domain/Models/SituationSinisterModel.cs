namespace SinisterApi.Domain.Models
{
    public class SituationSinisterModel
    {
        public SituationSinisterModel(int id, string name)
        {
            Id = id;
            Name = name;
        }
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
