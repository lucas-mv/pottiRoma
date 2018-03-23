using PottiRoma.App.Models.Responses.Challenges;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Helpers
{
    public static class SelectActualChallenges
    {
        public static GetCurrentChallengesResponse Select(GetCurrentChallengesResponse challenges)
        {
            var response = new GetCurrentChallengesResponse();
            response.Challenges = challenges.Challenges.OrderByDescending(challenge => challenge.StartDate).Where(challenge => challenge.StartDate < DateTime.Now && challenge.EndDate > DateTime.Now).ToList();
            return response;
        }
    }
}
