﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Requests.Clients
{
    public class RegisterClientRequest
    {
        public Guid SalespersonId { get; set; }
        public string Name { get; set; }
        public string Cep { get; set; }
        public string Email { get; set; }
        public string Telephone { get; set; }
        public string Address { get; set; }
        public DateTime Birthdate { get; set; }
    }
}
