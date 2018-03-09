using PottiRoma.App.Models.Requests.Sales;
using PottiRoma.App.Models.Responses.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Services.Interfaces
{
    public interface ISalesAppService
    {
        Task<GetSalesByUserIdResponse> GetSalesByUserId(string usuarioId);
        Task InsertNewSale(InsertNewSaleRequest request);
        Task UpdateSale(string vendaId, float saleValue, float salePaidValue, int numberSoldPieces, string description);
        Task<int> GetUserSalePointsForChallenge(string usuarioId);
    }
}
