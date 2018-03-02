using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.Challenges
{
    public static class ChallengesBusiness
    {
        public static void InsertNewChallenge(Guid temporadaId, string name, DateTime startDate, DateTime endDate, int parameter, int goal)
        {
            var newChallenge = new ChallengeEntity()
            {
                TemporadaId = temporadaId,
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Parameter = parameter,
                Goal = goal
            };

            ChallengesRepository.Get().InsertNewChallenge(newChallenge);
        }

        public static List<ChallengeEntity> GetAllChallenges()
        {
            return ChallengesRepository.Get().GetAllChallenges();
        }
    }
}
