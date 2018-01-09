using PottiRoma.Business.Clients;
using PottiRoma.Entities;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Services.Implementations
{
    public class ClientsService : IClientsService
    {
        public void RegisterClient(Guid salespersonId, string name, string cpf, string telephone, string email, string address)
        {
            var clientId = Guid.NewGuid();
            ClientsBusiness.RegisterClient(clientId, salespersonId, name, cpf, telephone, email, address);
        }

        public List<ClientEntity> GetClientsBySalespersonId(Guid salespersonId)
        {
            return ClientsBusiness.GetClientsBySalespersonId(salespersonId);
        }
    }
}
