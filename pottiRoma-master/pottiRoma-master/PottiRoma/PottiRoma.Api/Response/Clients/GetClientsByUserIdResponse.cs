﻿using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Response.Clients
{
    public class GetClientsByUserIdResponse
    {
        public List<ClientEntity> Clients { get; set; }
    }
}