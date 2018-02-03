﻿using PottiRoma.Business.Sale;
using PottiRoma.Entities;
using PottiRoma.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PottiRoma.Services.Implementations
{
    public class SalesService : ISalesService
    {
        public void InsertNewSale(Guid usuarioId, Guid clienteId, string userName, string clientName, DateTime saleDate, float saleValue, float salePaidValue, int numberSoldPieces)
        {
            SalesBusiness.InsertNewSale(usuarioId, clienteId, userName, clientName, saleDate, saleValue, salePaidValue, numberSoldPieces);
        }

        public List<SaleEntity> GetSalesByUserId(Guid usuarioId)
        {
            return SalesBusiness.GetSalesByUserId(usuarioId);
        }
    }
}
