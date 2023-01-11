namespace Application.DTO.Policy
{
    public class GetPolicyInsuredResponseDto
    {
        public GetPolicyInsuredResponseDto(int id, int insuredId, int documentType, string document, string name)
        {
            this.Id = id;
            this.InsuredId = insuredId;
            this.DocumentType = documentType;
            this.Document = document;
            this.Name = name;
        }

        public int Id { get; set; }
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
    }
}
