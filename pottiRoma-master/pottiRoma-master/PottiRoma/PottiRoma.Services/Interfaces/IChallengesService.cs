﻿using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Interfaces
{
    public interface IChallengesService
    {
        void InsertNewChallenge(Guid temporadaId, string name, DateTime startDate, DateTime endDate, int parameter, int goal, int prize, string description);

        List<ChallengeEntity> GetCurrentChallenges(Guid temporadaId);

        void UpdateChallenge(Guid desafioId, Guid temporadaId, string name, DateTime startDate, DateTime endDate, int parameter, int goal, int prize, string description);

        List<ChallengeEntity> GetCurrentChallengesPortal();
    }
}
