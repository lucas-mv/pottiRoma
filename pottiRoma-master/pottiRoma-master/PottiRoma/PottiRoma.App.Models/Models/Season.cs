using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Models.Models
{
    public class Season
    {
        public Guid TemporadaId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int AverageTicketGoal { get; set; }
        public int SalesNumberGoal { get; set; }
        public int AverageItensPerSaleGoal { get; set; }
        public int InviteFlowersGoal { get; set; }
        public bool IsActive { get; set; }
    }
}
