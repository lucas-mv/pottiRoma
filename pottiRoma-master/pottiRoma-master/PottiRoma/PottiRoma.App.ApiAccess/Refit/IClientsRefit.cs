using PottiRoma.App.Models.Requests.Clients;
using PottiRoma.App.Models.Responses.Clients;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.ApiAccess.Refit
{
    public interface IClientsRefit
    {
        [Get("/Clients/Get/{salespersonid}")]
        [Headers("Authorization: Bearer")]
        Task<GetClientsByUserIdResponse> GetClientsBySalespersonId([AliasAs("id")]string salespersonId);

        [Post("/Clients/Register")]
        [Headers("Authorization: Bearer")]
        Task RegisterClient(RegisterClientRequest request);
    }
}
