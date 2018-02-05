using PottiRoma.Business.GamificationPoints;
using PottiRoma.Entities;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Implementations
{
    public class GamificationPointsService : IGamificationPointsService
    {
        public GamificationPointsEntity GetCurrentGamificationPoints()
        {
            return GamificationPointBusiness.GetCurrentGamificationPoints();
        }

        public void UpdatePoints(bool isActive, int averageTicket, int registerNewClients, int salesNumber, int averageItensPerSale, int inviteFlower)
        {
            GamificationPointBusiness.UpdatePoints(isActive, averageTicket, registerNewClients, salesNumber, averageItensPerSale, inviteFlower);
        }
    }
}
