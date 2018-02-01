using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PottiRoma.Services.Interfaces
{
    public interface ISalesService
    {
        void InsertNewSale(Guid userId, Guid clientId, string userName, string clientName, DateTime saleDate, float saleValue, float salePaidValue, int numberSoldPieces);
        List<SaleEntity> GetSalesByUserId(Guid userId);
    }
}
