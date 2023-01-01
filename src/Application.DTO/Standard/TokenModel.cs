namespace Application.DTO.Standard
{
    public class TokenModel
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
