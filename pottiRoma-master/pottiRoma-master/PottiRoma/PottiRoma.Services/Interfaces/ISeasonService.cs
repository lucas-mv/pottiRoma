using PottiRoma.Entities;
using PottiRoma.Entities.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Interfaces
{
    public interface ISeasonService
    {
        Task InsertSeason(string name, DateTime startDate, DateTime endDate, bool isActive);
        SeasonEntity GetCurrentSeason();
        List<RankingBySeasonEntity> GetRankingBySeason();
    }
}
