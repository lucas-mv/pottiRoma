using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Response.User
{
    public class GetAppUsersResponse
    {
        public List<UserEntity> Users { get; set; }
    }
}