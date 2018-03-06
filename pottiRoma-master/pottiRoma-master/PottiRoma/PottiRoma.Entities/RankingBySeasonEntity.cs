using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Entities
{
    public class RankingBySeasonEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Season { get; set; }
        public int TotalPoints { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AverageTicketPoints { get; set; }
        public int RegisterClientsPoints { get; set; }
        public int SalesNumberPoints { get; set; }
        public int AverageItensPerSalePoints { get; set; }
        public int InviteAllyFlowersPoints { get; set; }
    }
}
