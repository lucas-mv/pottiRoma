using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Response.Trophies
{
    public class GetTrophiesResponse
    {
        public List<TrophyEntity> Trophies { get; set; }
    }
}