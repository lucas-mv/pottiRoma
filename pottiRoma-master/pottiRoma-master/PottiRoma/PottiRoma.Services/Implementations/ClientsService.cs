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
        public void RegisterClient(Guid userId, string name, string telephone, string email, string Cep, DateTime birthdate)
        {
            var clientId = Guid.NewGuid();
            ClientsBusiness.RegisterClient(userId, clientId, name, telephone, email, Cep, birthdate);
        }

        public List<ClientEntity> GetClientsByUserId(Guid userId)
        {
            return ClientsBusiness.GetClientsByUserId(userId);
        }
    }
}
