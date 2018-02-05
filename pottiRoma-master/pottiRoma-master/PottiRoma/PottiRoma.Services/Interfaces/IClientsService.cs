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
        void RegisterClient(Guid usuarioId, string name, string telephone, string email,string Cep, DateTime birthdate);
        List<ClientEntity> GetClientsByUserId(Guid usuarioId);
        void UpdateClientInfo(Guid clienteId, string name, string telephone, string email, string Cep, DateTime birthdate);
    }
}
