namespace Application.DTO.Authentication
{
    public class GetTokenResponseDto
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public IEnumerable<ClaimViewResponseDto> Claims { get; set; }
    }

    public class ClaimViewResponseDto
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
