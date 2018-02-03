using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PottiRoma.Services.Interfaces
{
    public interface ISalesService
    {
        void InsertNewSale(Guid usuarioId, Guid clienteId, string userName, string clientName, DateTime saleDate, float saleValue, float salePaidValue, int numberSoldPieces);
        List<SaleEntity> GetSalesByUserId(Guid userId);
    }
}
