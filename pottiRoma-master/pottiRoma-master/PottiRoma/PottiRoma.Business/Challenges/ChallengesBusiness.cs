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
        public static void InsertNewChallenge(Guid temporadaId, string name, DateTime startDate, DateTime endDate, int parameter, int goal, int prize, string description)
        {
            var newChallenge = new ChallengeEntity()
            {
                DesafioId = Guid.NewGuid(),
                TemporadaId = temporadaId,
                Name = name,
                StartDate = startDate,
                EndDate = endDate,
                Parameter = parameter,
                Goal = goal,
                Prize = prize,
                Description = description
            };

            ChallengesRepository.Get().InsertNewChallenge(newChallenge);
        }

        public static List<ChallengeEntity> GetCurrentChallenges(Guid temporadaId)
        {
            var challenges = ChallengesRepository.Get().GetCurrentChallenges(temporadaId);
            return challenges.OrderByDescending(challenge => challenge.StartDate).Where(challenge => challenge.StartDate < DateTime.Now && challenge.EndDate > DateTime.Now).ToList();
        }
    }
}
