﻿namespace SinisterApi.API.Models.Common
{
    public class AddressRequestModel
    {   
        public int? ZipCode { get; set; }
        public string? StreetName { get; set; }
        public string? StateName { get; set; }
        public string? StateInitials { get; set; }
        public string? Number { get; set; }
        public string? Complement { get; set; }
        public string? District { get; set; }
        public string? City { get; set; }
    }
}
