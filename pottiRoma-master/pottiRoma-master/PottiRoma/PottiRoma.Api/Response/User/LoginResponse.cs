using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace PottiRoma.Api.Response.User
{
    public class LoginResponse
    {
        public UserEntity User { get; set; }
        public Guid Token { get; set; }
    }
}