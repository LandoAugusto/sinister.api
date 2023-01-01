namespace Application.DTO.Standard
{
    public abstract record BaseResponse
    {
        public bool Success { get; set; } = false;
        public object ResponseData { get; set; }
        public string Message { get; set; }
    }
}
