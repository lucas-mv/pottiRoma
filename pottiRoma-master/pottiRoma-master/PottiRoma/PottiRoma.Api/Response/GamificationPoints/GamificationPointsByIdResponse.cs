using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Response.GamificationPoints
{
    public class GamificationPointsByIdResponse
    {
        public GamificationPointsEntity GamificationPoints { get; set; }
    }
}