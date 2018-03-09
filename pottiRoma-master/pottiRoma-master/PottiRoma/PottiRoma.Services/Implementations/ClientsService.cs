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
        public void RegisterClient(Guid usuarioId, string name, string telephone, string email, string Cep, DateTime birthdate)
        {
            ClientsBusiness.RegisterClient(usuarioId, name, telephone, email, Cep, birthdate);
        }

        public List<ClientEntity> GetClientsByUserId(Guid usuarioId)
        {
            return ClientsBusiness.GetClientsByUserId(usuarioId);
        }

        public void UpdateClientInfo(Guid clienteId, string name, string telephone, string email, string Cep, DateTime birthdate)
        {
            ClientsBusiness.UpdateClientInfo(clienteId, name, telephone, email, Cep, birthdate);
        }

        public void RemoveCliente(Guid clienteId)
        {
            ClientsBusiness.RemoveClient(clienteId);
        }

        public List<ClientEntity> GetAllClients()
        {
            return ClientsBusiness.GetAllClients();
        }

        public byte[] GenerateClientsReport()
        {
            return ClientsBusiness.GenerateClientsReport();
        }

        public int GetUserClientPointsForChallenge(Guid usuarioId)
        {
            return ClientsBusiness.GetUserClientPointsForChallenge(usuarioId);
        }
    }
}
