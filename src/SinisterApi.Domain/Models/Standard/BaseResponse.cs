namespace SinisterApi.Domain.Models.Standard
{
    public abstract record BaseResponse
    {
        public DateTime ResponseDate { get; set; }

        public object ResponseData { get; set; }

        public string Message { get; set; }
    }
}
