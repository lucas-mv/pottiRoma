using PottiRoma.Business.Challenges;
using PottiRoma.Entities;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Implementations
{
    public class ChallengesService : IChallengesService
    {
        public List<ChallengeEntity> GetCurrentChallenges(Guid temporadaId)
        {
            return ChallengesBusiness.GetCurrentChallenges(temporadaId);
        }

        public void InsertNewChallenge(Guid temporadaId, string name, DateTime startDate, DateTime endDate, int parameter, int goal, int prize, string description)
        {
            ChallengesBusiness.InsertNewChallenge(temporadaId, name, startDate, endDate, parameter, goal, prize, description);
        }
    }
}
