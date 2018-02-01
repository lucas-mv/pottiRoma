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
        public static void RegisterClient(Guid clientId, Guid salespersonId, string name, string telephone, string email, string address, DateTime birthdate)
        {
            var client = new ClientEntity()
            {
                ClienteId = clientId,
                Email = email,
                Name = name,
                UsuarioId = salespersonId,
                Telephone = telephone,
                Cep = address,
                Birthdate = birthdate
            };
            ClientsRepository.Get().InsertClient(client);
        }

        public static List<ClientEntity> GetClientsBySalespersonId(Guid salespersonId)
        {
            return ClientsRepository.Get().GetClientsBySalespersonId(salespersonId);
        }
    }
}
