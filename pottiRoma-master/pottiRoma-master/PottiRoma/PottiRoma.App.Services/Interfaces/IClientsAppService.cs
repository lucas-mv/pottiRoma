using PottiRoma.App.Models.Requests.Clients;
using PottiRoma.App.Models.Responses.Clients;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Interfaces
{
    public interface IClientsAppService
    {
        Task<GetClientsByUserIdResponse> GetClientsByUserId(string usuarioId);
        Task RegisterClient(RegisterClientRequest request);
        Task UpdateClientInfo(UpdateClientInfoRequest request);
        Task RemoveCliente(string clienteId);
        Task<int> GetUserInvitePointsForChallenge(string usuarioId);

    }
}
