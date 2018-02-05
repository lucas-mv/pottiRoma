using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Request.Clients
{
    public class UpdateClientRequest
    {
        public Guid ClienteId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Cep { get; set; }
        public DateTime Birthdate { get; set; }
    }
}