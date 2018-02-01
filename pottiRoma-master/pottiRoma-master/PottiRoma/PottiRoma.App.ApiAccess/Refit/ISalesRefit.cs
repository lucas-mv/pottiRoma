using PottiRoma.App.Models.Requests.Sales;
using PottiRoma.App.Models.Responses.Sales;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.ApiAccess.Refit
{
    public interface ISalesRefit
    {
        [Get("/Sales/Get/{userId}")]
        [Headers("Authorization: Bearer")]
        Task<GetSalesByUserIdResponse> GetSalesByUserId(string userId);

        [Post("/Sales/New")]
        [Headers("Authorization: Bearer")]
        Task InsertNewSale(InsertNewSaleRequest request);
    }
}
