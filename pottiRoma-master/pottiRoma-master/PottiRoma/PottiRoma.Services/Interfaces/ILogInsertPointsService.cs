using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Interfaces
{
    public interface ILogInsertPointsService
    {
        void InsertNewLog(Guid usuarioEmail ,string userEmail, int averageTicket, int registerNewClients, int salesNumber, int averageItensPerSale, int inviteFlower, string description);
    }
}
