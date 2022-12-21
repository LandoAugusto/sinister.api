namespace SinisterApi.Domain.Models.Common
{
    public class CommunicantTypeModel
    {
        public CommunicantTypeModel(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public int Id { get; set; }
        public string Name { get; set; }
    }
}
