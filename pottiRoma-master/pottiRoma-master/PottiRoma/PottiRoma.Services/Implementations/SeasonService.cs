using PottiRoma.Business.Season;
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

        public async Task InsertSeason(string name, DateTime startDate, DateTime endDate, int averageTicketGoal, int registerClientsGoal, int salesNumberGoal, int averageItensPerSaleGoal, int inviteFlowersGoal, bool isActive)
        {
            SeasonBusiness.InsertSeason(name, startDate, endDate, averageTicketGoal, registerClientsGoal, 
                salesNumberGoal, averageItensPerSaleGoal, inviteFlowersGoal, isActive);
        }
    }
}
