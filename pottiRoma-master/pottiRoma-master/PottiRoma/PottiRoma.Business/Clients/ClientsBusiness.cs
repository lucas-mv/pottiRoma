using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.Clients
{
    public static class ClientsBusiness
    {
        public static void RegisterClient(Guid clientId, Guid salespersonId, string name, string cpf, string telephone, string email, string address)
        {
            var client = new ClientEntity()
            {
                ClientId = clientId,
                Cpf = cpf,
                Email = email,
                Name = name,
                SalespersonId = salespersonId,
                Telephone = telephone,
                Address = address
            };
            ClientsRepository.Get().InsertClient(client);
        }

        public static List<ClientEntity> GetClientsBySalespersonId(Guid salespersonId)
        {
            return ClientsRepository.Get().GetClientsBySalespersonId(salespersonId);
        }
    }
}
