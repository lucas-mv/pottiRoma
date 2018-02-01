using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Entities
{
    public class Season
    {
        public Guid TemporadaId { get; set; }
        public string Name { get; set; }
        public int StartDate { get; set; }
        public int EndDate { get; set; }
        public int AverageTicketGoal { get; set; }
        public int RegisterClientsGoal { get; set; }
        public int SalesNumberGoal { get; set; }
        public int AverageItensPerSaleGoal { get; set; }
        public int InviteFlowersGoal { get; set; }
    }
}
