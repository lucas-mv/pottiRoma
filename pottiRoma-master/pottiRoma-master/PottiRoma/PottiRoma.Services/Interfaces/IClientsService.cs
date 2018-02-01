using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Interfaces
{
    public interface IClientsService
    {
        void RegisterClient(Guid salespersonId, string name, string telephone, string email, string address, DateTime birthdate);
        List<ClientEntity> GetClientsBySalespersonId(Guid salespersonId);
    }
}
