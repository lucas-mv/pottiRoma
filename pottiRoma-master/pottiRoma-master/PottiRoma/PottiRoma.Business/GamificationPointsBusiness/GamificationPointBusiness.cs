using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.GamificationPoints
{
    public static class GamificationPointBusiness
    {
        public static void UpdatePoints(Guid pontosGamificacaoId ,int averageTicket, int registerNewClients, int salesNumber, int averageItensPerSale, int inviteFlower)
        {
            var gamificationPoints = new GamificationPointsEntity()
            {
                PontosGamificacaoId = pontosGamificacaoId,
                AverageTicket = averageTicket,
                AverageItensPerSale = averageItensPerSale,
                RegisterNewClients = registerNewClients,
                SalesNumber = salesNumber,
                InviteFlower = inviteFlower
            };
            GamificationPointsRepository.Get().UpdateGamificationPoints(gamificationPoints);
        }

        public static GamificationPointsEntity GetGamificationPointsById(Guid gamificationPointsId)
        {
            return GamificationPointsRepository.Get().GetGamificationPointsById(gamificationPointsId);
        }
    }
}
