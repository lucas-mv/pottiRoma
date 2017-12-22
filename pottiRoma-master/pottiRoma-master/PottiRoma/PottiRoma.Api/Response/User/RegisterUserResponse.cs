using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Response.User
{
    public class RegisterUserResponse
    {
        public UserEntity User { get; set; }
    }
}