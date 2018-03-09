using PottiRoma.App.Models.Requests.Clients;
using PottiRoma.App.Models.Responses.Clients;
using PottiRoma.App.Repositories.Api;
using PottiRoma.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Implementations
{
    public class ClientsAppService : IClientsAppService
    {
        public async Task<GetClientsByUserIdResponse> GetClientsByUserId(string usuarioId)
        {
            return await ClientsApiRepository.Get().GetClientsByUserId(usuarioId);
        }

        public async Task RegisterClient(RegisterClientRequest request)
        {
            await ClientsApiRepository.Get().RegisterClient(request);
        }

        public async Task UpdateClientInfo(UpdateClientInfoRequest request)
        {
            await ClientsApiRepository.Get().UpdateClientInfo(request);
        }


        public async Task RemoveCliente(string clienteId)
        {
            await ClientsApiRepository.Get().RemoveCliente(clienteId);
        }

        public async Task<int> GetUserClientPointsForChallenge(string usuarioId)
        {
            return await ClientsApiRepository.Get().GetUserClientPointsForChallenge(usuarioId);
        }
    }
}
