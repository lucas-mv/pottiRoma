﻿using PottiRoma.Business.RankingBySeason;
using PottiRoma.Business.Season;
using PottiRoma.Entities;
using PottiRoma.Entities.Internal;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Implementations
{
    public class SeasonService : ISeasonService
    {
        public SeasonEntity GetCurrentSeason()
        {
            return SeasonBusiness.GetCurrentSeason();
        }

        public List<RankingBySeasonEntity> GetRankingBySeason()
        {
            return RankingBySeasonBusiness.GetRankingBySeason();
        }

        public async Task InsertSeason(string name, DateTime startDate, DateTime endDate, bool isActive)
        {
            SeasonBusiness.InsertSeason(name, startDate, endDate, isActive);
        }
    }
}
