using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.LogInsertPoints
{
    public static class LogInsertPointsBusiness
    {
        public static void InsertNewLog(Guid usuarioId, string userEmail, int averageTicket, int registerNewClients, int salesNumber, int averageItensPerSale, int inviteFlower, string description)
        {
            var newLog = new LogInsertPointsEntity()
            {
                UsuarioId = usuarioId,
                UserEmail = userEmail,
                AverageTicket = averageTicket,
                RegisterNewClients = registerNewClients,
                SalesNumber = salesNumber,
                AverageItensPerSale = averageItensPerSale,
                Description = description
            };
            LogInsertPointsRepository.Get().InsertNewLog(newLog);
        }
    }
}
