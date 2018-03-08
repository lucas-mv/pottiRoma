using PottiRoma.Business.General;
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
        public static void RegisterClient(Guid usuarioId, string name, string telephone, string email, string Cep, DateTime birthdate)
        {
            var client = new ClientEntity()
            {
                ClienteId = Guid.NewGuid(),
                Email = email,
                Name = name,
                UsuarioId = usuarioId,
                Telephone = telephone,
                Cep = Cep,
                Birthdate = birthdate
            };
            ClientsRepository.Get().InsertClient(client);
        }

        public static List<ClientEntity> GetClientsByUserId(Guid usuarioId)
        {
            return ClientsRepository.Get().GetClientsByUserId(usuarioId);
        }

        public static void RemoveClient(Guid clienteId)
        {
            ClientsRepository.Get().RemoveClient(clienteId);
        }

        public static void UpdateClientInfo(Guid clienteId, string name, string telephone, string email, string Cep, DateTime birthdate)
        {
            var client = new ClientEntity()
            {
                ClienteId = clienteId,
                Name = name,
                Telephone = telephone,
                Email = email,
                Cep = Cep,
                Birthdate = birthdate
            };
            ClientsRepository.Get().UpdateClientInfo(client);
        }

        public static List<ClientEntity> GetAllClients()
        {
            return ClientsRepository.Get().GetAllClients().OrderBy(c => c.Name).ToList();
        }

        public static byte[] GenerateClientsReport()
        {
            return ReportGenerator.GenerateClientsReport(GetAllClients());
        }

        public static int GetUserClientPointsForChallenge(Guid usuarioId)
        {
            DateTime now = DateTime.Now;
            return ClientsRepository.Get().GetUserClientPointsForChallenge(usuarioId, now);
        }
    }
}
