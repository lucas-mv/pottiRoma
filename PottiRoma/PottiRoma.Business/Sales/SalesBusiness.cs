using PottiRoma.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace PottiRoma.Business.Sales
{
    public static class SalesBusiness
    {
        public static void NewSalesPerson()
        {
            var user = UserRepository.Get().GetUserById(new Guid("799e7f37-77be-416a-bb5e-c0a936322381"));
        }
    }
}
