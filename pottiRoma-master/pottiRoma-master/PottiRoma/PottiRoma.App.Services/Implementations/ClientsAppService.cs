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
        public async Task<GetClientsByUserIdResponse> GetClientsBySalespersonId(string salespersonId)
        {
            return await ClientsApiRepository.Get().GetClientsBySalespersonId(salespersonId);
        }

        public async Task RegisterClient(RegisterClientRequest request)
        {
            await ClientsApiRepository.Get().RegisterClient(request);
        }
    }
}
