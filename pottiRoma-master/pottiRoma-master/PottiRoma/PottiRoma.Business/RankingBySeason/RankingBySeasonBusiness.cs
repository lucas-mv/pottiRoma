using PottiRoma.Business.General;
using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.RankingBySeason
{
    public static class RankingBySeasonBusiness
    {
        public static void GenerateRankingBySeason(string name, string email, string season, int totalPoints, DateTime startDate, DateTime endDate,
            int averageTicketPoints, int registerClientsPoints, int salesNumberPoints, int averageItensPerSalePoints, int inviteAllyFlowersPoints)
        {
            var newRankingItem = new RankingBySeasonEntity()
            {
                AverageItensPerSalePoints = averageItensPerSalePoints,
                AverageTicketPoints = averageTicketPoints,
                Name = name,
                Email = email,
                Season = season,
                TotalPoints = totalPoints,
                StartDate = startDate,
                EndDate = endDate,
                RegisterClientsPoints = registerClientsPoints,
                SalesNumberPoints = salesNumberPoints,
                InviteAllyFlowersPoints = inviteAllyFlowersPoints,
            };

            RankingBySeasonRepository.Get().GenerateRankingBySeason(newRankingItem);
        }

        public static List<RankingBySeasonEntity> GetRankingBySeason()
        {
            var ranking = RankingBySeasonRepository.Get().GetRankingBySeason();
            foreach(var position in ranking)
            {
                position.TotalPoints = position.SalesNumberPoints + position.RegisterClientsPoints + position.InviteAllyFlowersPoints + position.AverageTicketPoints + position.AverageItensPerSalePoints;
            }
            return ranking.OrderByDescending(r => r.StartDate).ThenByDescending(r => r.TotalPoints).ToList();
        }

        public static byte[] GenerateRankingBySeasonReport()
        {
            return ReportGenerator.GenerateRankingBySeasonReport(GetRankingBySeason());
        }
    }
}
