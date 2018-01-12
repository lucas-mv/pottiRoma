using PottiRoma.DataAccess.Repositories;
using PottiRoma.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PottiRoma.Business.Sales
{
    public static class SalesBusiness
    {
        public static void NewSalesPerson(SalespersonEntity salesperson)
        {
            SalespersonRepository.Get().InsertSalesperson(salesperson.UserId, salesperson.SalespersonId, salesperson.FlowerId, salesperson.Birthday);
        }

        public static SalespersonEntity GetSalespersonById(Guid salespersonId)
        {
            return SalespersonRepository.Get().GetSalespersonById(salespersonId);
        }

        public static SalespersonEntity GetSalespersonByUserId(Guid userId)
        {
            return SalespersonRepository.Get().GetSalespersonByUserId(userId);
        }
    }
}
