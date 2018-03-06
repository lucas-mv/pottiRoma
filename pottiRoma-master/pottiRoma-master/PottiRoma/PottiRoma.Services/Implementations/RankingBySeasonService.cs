using PottiRoma.Business.RankingBySeason;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Implementations
{
    public class RankingBySeasonService : IRankingBySeasonService
    {
        public void GenerateRankingBySeason(string name, string email, string season, int totalPoints, DateTime startDate, DateTime endDate,
            int averageTicketPoints, int registerClientsPoints, int salesNumberPoints, int averageItensPerSalePoints, int inviteAllyFlowersPoints)
        {
            RankingBySeasonBusiness.GenerateRankingBySeason(name, email, season, totalPoints, startDate, endDate,
            averageTicketPoints, registerClientsPoints, salesNumberPoints, averageItensPerSalePoints, inviteAllyFlowersPoints);
        }
    }
}
