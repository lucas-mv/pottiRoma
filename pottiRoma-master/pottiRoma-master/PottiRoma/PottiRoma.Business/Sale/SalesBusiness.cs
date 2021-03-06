﻿using PottiRoma.Business.General;
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
        public static void InsertNewSale(Guid usuarioId, Guid clienteId, string userName, string clientName, DateTime saleDate, float saleValue, float salePaidValue, int numberSoldPieces, string description)
        {
            var newSale = new SaleEntity()
            {
                ClienteId = clienteId,
                ClientName = clientName,
                NumberSoldPieces = numberSoldPieces,
                SaleDate = saleDate,
                VendaId = Guid.NewGuid(),
                SalePaidValue = salePaidValue,
                SaleValue = saleValue,
                UsuarioId = usuarioId,
                UserName = userName,
                Description = description
            };
            SalesRepository.Get().InsertNewSale(newSale);
        }

        public static List<SaleEntity> GetSalesByUserId(Guid userId)
        {
            return SalesRepository.Get().GetSalesByUserId(userId);
        }

        public static void UpdateSale(Guid vendaId, float saleValue, float salePaidValue, int numberSoldPieces, string description)
        {
            SalesRepository.Get().UpdateSale(vendaId, saleValue, salePaidValue, numberSoldPieces, description);
        }

        public static List<SaleEntity> GetAllSales()
        {
            return SalesRepository.Get().GetAllSales().OrderByDescending(s => s.SaleDate).ToList();
        }

        public static byte[] GenerateSalesReport()
        {
            return ReportGenerator.GenerateSalesReport(GetAllSales());
        }

        public static int GetUserSalePointsForChallenge(Guid usuarioId)
        {
            DateTime now = DateTime.Now;
            return SalesRepository.Get().GetUserSalePointsForChallenge(usuarioId, now);
        }
    }
}
