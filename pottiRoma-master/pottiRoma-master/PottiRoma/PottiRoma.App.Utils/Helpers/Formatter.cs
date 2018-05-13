using PottiRoma.App.Utils.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Utils.Helpers
{
    public static class Formatter
    {
        public static string FormatMoney(decimal parameter)
        {
            NumberFormatInfo nfi = new CultureInfo("pt-BR").NumberFormat;
            string Retorno = parameter.ToString("N", nfi);
            Retorno = string.Concat("R$ ", Retorno);
            return Retorno;
        }

        public static string FormatDate(DateTime Date)
        {
            string StringDate = Date.ToString();
            string FormattedDate = Convert.ToDateTime(StringDate).ToString("dd/MM/yyyy");
            return FormattedDate;
        }

        public static string FormatDateWithoutYear(DateTime Date)
        {
            string StringDate = Date.ToString();
            string FormattedDate = Convert.ToDateTime(StringDate).ToString("dd/MM");
            return FormattedDate;
        }

        public static string FormatAveragePiecesForSale(int points)
        {
            string pointsFormatted = ConvertToString(points);
            return points + " und";
        }

        public static string ConvertToString(int points)
        {
            string pointsFormatted = points.ToString();
            if (string.IsNullOrWhiteSpace(pointsFormatted) || string.IsNullOrWhiteSpace(pointsFormatted))
                return "0";
            else return pointsFormatted;
        }

        public static string FormatUserRankingPosition(int position)
        {
            return position.ToString() + ". ";
        }

        public static string FormatChallengeType(ChallengeType type)
        {
            switch (type)
            {
                case ChallengeType.NumeroVendas:
                    return "Vendas que Faltam";
                case ChallengeType.ConvidarFloresAliadas:
                    return "Cadastros que Faltam";
                case ChallengeType.CadastrarClientes:
                    return "Registros de Clientes que Faltam";
                default:
                    return "Registros de Clientes que Faltam";
            }
        }

        public static string FormatChallengeTypeForDescription(ChallengeType type)
        {
            switch (type)
            {
                case ChallengeType.NumeroVendas:
                    return "Vendas";
                case ChallengeType.ConvidarFloresAliadas:
                    return "Convites de Flores Aliadas";
                case ChallengeType.CadastrarClientes:
                    return "Cadastrar Clientes";
                default:
                    return "Convites de Flores Aliadas";
            }
        }
    }
}
