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
        public static void RegisterClient(Guid userId , Guid clientId, string name, string telephone, string email, string Cep, DateTime birthdate)
        {
            var client = new ClientEntity()
            {
                ClienteId = clientId,
                Email = email,
                Name = name,
                UsuarioId = userId,
                Telephone = telephone,
                Cep = Cep,
                Birthdate = birthdate
            };
            ClientsRepository.Get().InsertClient(client);
        }

        public static List<ClientEntity> GetClientsByUserId(Guid UserId)
        {
            return ClientsRepository.Get().GetClientsByUserId(UserId);
        }
    }
}
