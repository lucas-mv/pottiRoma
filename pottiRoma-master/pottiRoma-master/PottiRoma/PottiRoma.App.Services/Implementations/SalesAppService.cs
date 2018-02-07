using PottiRoma.App.Models.Requests.Sales;
using PottiRoma.App.Models.Responses.Sales;
using PottiRoma.App.Repositories.Api;
using PottiRoma.App.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Implementations
{
    public class SalesAppService : ISalesAppService
    {
        public async Task<GetSalesByUserIdResponse> GetSalesByUserId(string usuarioId)
        {
            return await SalesApiRepository.Get().GetSalesByUserId(usuarioId);
        }

        public async Task InsertNewSale(InsertNewSaleRequest request)
        {
            await SalesApiRepository.Get().InsertNewSale(request);
        }

        public async Task UpdateSale(string vendaId, float saleValue, float salePaidValue, int numberSoldPieces, string description)
        {
            await SalesApiRepository.Get().UpdateSale(vendaId, saleValue, salePaidValue, numberSoldPieces, description);
        }
    }
}
