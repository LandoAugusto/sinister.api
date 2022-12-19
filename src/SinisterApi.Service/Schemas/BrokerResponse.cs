using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SinisterApi.Service.Schemas
{
    public class BrokerResponse
    {
        public int? PersonId { get; set; }
        public long? DocumentNumber { get; set; }
        public string? Name { get; set; }
        public string? SusepCode { get; set; }
        public int? UserId { get; set; }
        public PersonTypeResponse PersonType { get; set; }
        public AddressResponse Address { get; set; }
    }
}
