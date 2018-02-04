using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PottiRoma.Api.Request.PointsGamification
{
    public class GamificationPointsRequest
    {
        public Guid PontosGamificacaoId { get; set; }
        public int AverageTicket { get; set; }
        public int RegisterNewClients { get; set; }
        public int SalesNumber { get; set; }
        public int AverageItensPerSale { get; set; }
        public int InviteFlower { get; set; }
    }
}