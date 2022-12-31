namespace Domain.Core.Models
{
    public class BusinessModel
    {
        public BusinessModel(int? id, int? susepCode, string? name)
        {
            Id = id;
            SusepCode = susepCode;
            Name = name;
        }
    
        public int? Id { get; set; }
        public int? SusepCode { get; set; }
        public string? Name { get; set; }        
    }
}
    