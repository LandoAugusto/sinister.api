namespace SinisterApi.Domain.Models
{
    public abstract record BaseResponse
    {
        public DateTime ResponseDate { get; set; }

        public string ResponseData { get; set; }

        public string Message { get; set; }
    }
}
