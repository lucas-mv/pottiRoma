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
        void RegisterClient(Guid salespersonId, string name, string cpf, string telephone, string email, string address);
        List<ClientEntity> GetClientsBySalespersonId(Guid salespersonId);
    }
}
