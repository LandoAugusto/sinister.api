namespace Infrastruture.CrossCutting.Identity.Models
{
    public class GetTokenResponseModel
    {
        public string AccessToken { get; set; }
        public double ExpiresIn { get; set; }
        public IEnumerable<ClaimViewModel> Claims { get; set; }
    }

    public class ClaimViewModel
    {
        public string Value { get; set; }
        public string Type { get; set; }
    }
}
