using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.Business.Sale
{
    public static class SalesBusiness
    {
        public static void InsertNewSale(Guid userId, Guid clientId, string userName, string clientName, DateTime saleDate, float saleValue, float salePaidValue, int numberSoldPieces)
        {
            var newSale = new SaleEntity()
            {
                ClientId = clientId,
                ClientName = clientName,
                NumberSoldPieces = numberSoldPieces,
                SaleDate = saleDate,
                SaleId = Guid.NewGuid(),
                SalePaidValue = salePaidValue,
                SaleValue = saleValue,
                UserId = userId,
                UserName = userName
            };
            SalesRepository.Get().InsertNewSale(newSale);
        }

        public static List<SaleEntity> GetSalesByUserId(Guid userId)
        {
            return SalesRepository.Get().GetSalesByUserId(userId);
        }
    }
}
