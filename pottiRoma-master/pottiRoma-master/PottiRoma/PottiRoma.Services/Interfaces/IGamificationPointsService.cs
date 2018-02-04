using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Interfaces
{
    public interface IGamificationPointsService
    {
        void UpdatePoints(Guid pontosGamificacaoId, int averageTicket, int RegisterNewClients, int SalesNumber, int AverageItensPerSale, int InviteFlower);
        GamificationPointsEntity GetGamificationPointsById(Guid GamificationPointsId);
    }
}
