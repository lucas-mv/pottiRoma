using PottiRoma.App.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Utils.Helpers
{
    public static class ConvertIndexToEnumHelper
    {
        public static CarouselBannerType Convert(int index)
        {
            switch (index)
            {
                case 0:
                    return CarouselBannerType.AverageTicket;
                case 1:
                    return CarouselBannerType.RegisterClients;
                case 2:
                    return CarouselBannerType.AveragePiecesForSale;
                case 3:
                    return CarouselBannerType.RegisterAlliedFlowers;
                case 4:
                    return CarouselBannerType.RegisteredSales;
                default:
                    return CarouselBannerType.AveragePiecesForSale;
            }
        }
    }
}
