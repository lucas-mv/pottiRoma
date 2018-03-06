using PottiRoma.Business.LogInsertPoints;
using PottiRoma.Entities;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Implementations
{
    public class LogInsertPointsService : ILogInsertPointsService
    {
        public void InsertNewLog(Guid usuarioId,string userEmail, int averageTicket, int registerNewClients, int salesNumber, int averageItensPerSale, int inviteFlower, string description)
        {
            LogInsertPointsBusiness.InsertNewLog (usuarioId, userEmail, averageTicket, registerNewClients, salesNumber, averageItensPerSale, inviteFlower, description);
        }
    }
}
