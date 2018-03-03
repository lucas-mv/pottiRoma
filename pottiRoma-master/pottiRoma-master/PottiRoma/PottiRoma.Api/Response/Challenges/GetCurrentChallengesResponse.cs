using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Response.Challenges
{
    public class GetCurrentChallengesResponse
    {
        public List<ChallengeEntity> Challenges { get; set; }
    }
}