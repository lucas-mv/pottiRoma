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
            for (int i = 0; i < challenges.Challenges.Count; i++)
            {
                if (challenges.Challenges[i].EndDate < DateTime.Now && challenges.Challenges[i].StartDate > DateTime.Now)
                    challenges.Challenges.RemoveAt(i);
            }
            return challenges;
        }
    }
}
