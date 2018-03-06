using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Interfaces
{
    public interface IRankingBySeasonService
    {
        void GenerateRankingBySeason(string name, string email, string season, int totalPoints, DateTime startDate, DateTime endDate,
            int averageTicketPoints, int registerClientsPoints, int salesNumberPoints, int averageItensPerSalePoints, int inviteAllyFlowersPoints);
    }
}
