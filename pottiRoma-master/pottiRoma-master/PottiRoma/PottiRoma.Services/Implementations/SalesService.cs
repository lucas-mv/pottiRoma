using PottiRoma.Business.Sale;
using PottiRoma.Entities;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PottiRoma.Services.Implementations
{
    public class SalesService : ISalesService
    {
        public List<SaleEntity> GetSalesByUserId(Guid userId)
        {
            return SalesBusiness.GetSalesByUserId(userId);
        }

        public void InsertNewSale(Guid userId, Guid clientId, string userName, string clientName, DateTime saleDate, float saleValue, float salePaidValue, int numberSoldPieces)
        {
            SalesBusiness.InsertNewSale(userId, clientId, userName, clientName, saleDate, saleValue, salePaidValue, numberSoldPieces);
        }
    }
}
