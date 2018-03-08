using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using PottiRoma.Utils.Constants;
using PottiRoma.Utils.CustomExceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.GamificationPoints
{
    public static class GamificationPointBusiness
    {
        public static void UpdatePoints(bool isActive, int averageTicket, int registerNewClients, int salesNumber, int averageItensPerSale, int inviteFlower)
        {
            var gamificationPoints = new GamificationPointsEntity()
            {
                IsActive = isActive,
                AverageTicket = averageTicket,
                AverageItensPerSale = averageItensPerSale,
                RegisterNewClients = registerNewClients,
                SalesNumber = salesNumber,
                InviteFlower = inviteFlower
            };
            GamificationPointsRepository.Get().UpdateGamificationPoints(gamificationPoints);
        }

        public static GamificationPointsEntity GetCurrentGamificationPoints()
        {
            var gamificationPoints = GamificationPointsRepository.Get().GetCurrentGamificationPoints();
            if (gamificationPoints == null)
                throw new ExceptionWithHttpStatus(System.Net.HttpStatusCode.BadRequest, Messages.NO_SEASONS_REGISTERED);
            else
                return gamificationPoints;
        }
    }
}
