using PottiRoma.App.Utils.Helpers;
using PottiRoma.App.Views.Core;
using Prism.Navigation;
using Rg.Plugins.Popup.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Helpers
{
    public static class GetDatePopupHelper
    {
        public static async Task Mostrar()
        {
            await PopupNavigation.PushAsync(new PopupGetDate());
        }

        public static async Task EsconderAsync()
        {
            await PopupNavigation.PopAsync();
        }

        public static int ConvertBack(string value)
        {
            switch (value)
            {
                case MonthStringFormat.Janeiro:
                    return 1;
                case MonthStringFormat.Fevereiro:
                    return 2;
                case MonthStringFormat.Março:
                    return 3;
                case MonthStringFormat.Abril:
                    return 4;
                case MonthStringFormat.Maio:
                    return 5;
                case MonthStringFormat.Junho:
                    return 6;
                case MonthStringFormat.Julho:
                    return 7;
                case MonthStringFormat.Agosto:
                    return 8;
                case MonthStringFormat.Setembro:
                    return 9;
                case MonthStringFormat.Outubro:
                    return 11;
                case MonthStringFormat.Novembro:
                    return 10;
                case MonthStringFormat.Dezembro:
                    return 12;
                default:
                    return 0;
            }
        }

        public static string Convert(int value)
        {
            switch (value)
            {
                case 1:
                    return MonthStringFormat.Janeiro;
                case 2:
                    return MonthStringFormat.Fevereiro;
                case 3:
                    return MonthStringFormat.Março;
                case 4:
                    return MonthStringFormat.Abril;
                case 5:
                    return MonthStringFormat.Maio;
                case 6:
                    return MonthStringFormat.Junho;
                case 7:
                    return MonthStringFormat.Julho;
                case 8:
                    return MonthStringFormat.Agosto;
                case 9:
                    return MonthStringFormat.Setembro;
                case 10:
                    return MonthStringFormat.Outubro;
                case 11:
                    return MonthStringFormat.Novembro;
                case 12:
                    return MonthStringFormat.Dezembro;
                default:
                    return null;
            }
        }

    }
}
