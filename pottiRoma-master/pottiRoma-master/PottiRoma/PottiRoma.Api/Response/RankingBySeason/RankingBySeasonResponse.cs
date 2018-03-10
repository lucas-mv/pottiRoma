using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Response.RankingBySeason
{
    public class RankingBySeasonResponse
    {
        public List<RankingBySeasonEntity> RankingBySeason { get; set; }
    }
}