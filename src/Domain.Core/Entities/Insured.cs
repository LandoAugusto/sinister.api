using Domain.Core.Entities.Interfaces;

namespace Domain.Core.Entities
{
    public class Insured : IIdentityEntity
    {      
        public int Id { get; set; }
        public int PolicyId { get; set; }
        public int InsuredId { get; set; }
        public int DocumentType { get; set; }
        public string Document { get; set; } = null!;
        public string Name { get; set; } = null!;
        public string? Sex { get; set; }
        public int? MaritalStatus { get; set; }
        public string? Profession { get; set; }
        public string? Nationality { get; set; }
        public string? Activity { get; set; }
        public decimal? MonthlyIncome { get; set; }
        public string? RegistrationMunicipal { get; set; }
        public string? DateFoundation { get; set; }
        public decimal? EstimatedEquity { get; set; }
        public int InclusionUserId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public virtual Policy Policy { get; set; } = null!;
        public virtual ICollection<InsuredAddress> InsuredAddress { get; set; } = new HashSet<InsuredAddress>();
        public virtual ICollection<InsuredEmail> InsuredEmail { get; set; } = new HashSet<InsuredEmail>();
        public virtual ICollection<InsuredPhone> InsuredPhone { get; set; } = new HashSet<InsuredPhone>();
    }
}
