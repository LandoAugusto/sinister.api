﻿namespace Account.TransactionApi.Api.Configurations
{
    public class TokenModel
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
