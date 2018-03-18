using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Request.User
{
    public class UpdateUserStatusRequest
    {
        public Guid UserId { get; set; }
        public bool IsActive { get; set; }
    }
}