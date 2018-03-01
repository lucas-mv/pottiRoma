using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PottiRoma.Services.Interfaces
{
    public interface ISalesService
    {
        void InsertNewSale(Guid usuarioId, Guid clienteId, string userName, string clientName, DateTime saleDate, float saleValue, float salePaidValue, int numberSoldPieces, string description);
        List<SaleEntity> GetSalesByUserId(Guid userId);
        void UpdateSale(Guid vendaId,float saleValue, float salePaidValue, int numberSoldPieces, string description);
        List<SaleEntity> GetAllSales();

    }
}
