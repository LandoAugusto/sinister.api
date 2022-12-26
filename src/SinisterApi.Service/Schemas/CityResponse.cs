namespace SinisterApi.Service.Schemas
{
    internal class CityResponse
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public StateResponse State { get; set; }
    }
}
