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
        Task<GetClientsByUserIdResponse> GetClientsUserId(string userId);
        Task RegisterClient(RegisterClientRequest request);
    }
}
