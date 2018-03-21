using PottiRoma.App.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Helpers
{
    public static class TrophyDescriptionHelper
    {
        public static string GetDescription(int parameter, int goal, DateTime startDate, DateTime endDate)
        {
            switch (parameter)
            {
                case 1:
                    return @"Uaau!! Você inspirou muitas mulheres a se conectarem com seu íntimo! Parabéns, você ganhou " + goal + " sementes por ter completado o desafio de número de atendimentos entre os dias " + Formatter.FormatDate(startDate) + " e " + Formatter.FormatDate(endDate) + ".";
                case 2:
                    return @"Uhuu! Agora você conhece mais suas colecionadoras e tem mais informações pra gerenciar seus relacionamentos! Parabéns, você ganhou " + goal + " sementes por ter completado o desafio de número de cadastro de Colecionadoras entre os dias " + Formatter.FormatDate(startDate) + " e " + Formatter.FormatDate(endDate) + ".";
                case 3:
                    return @"Eba! Tem Flor nova no nosso jardim! Que bom que você está incentivando sua equipe! Parabéns, você ganhou " + goal + " sementes por ter completado o desafio de cadastro de Flor Aliada entre os dias " + Formatter.FormatDate(startDate) + " e " + Formatter.FormatDate(endDate) + ".";
                default:
                    return "";
            }
        }

        public static string GetImageSource(int parameter)
        {
            switch (parameter)
            {
                case 1:
                    return "ic_sala_trofeu_caramelo.png";
                case 2:
                    return "ic_sala_trofeu_verde.png";
                case 3:
                    return "ic_sala_trofeu_vermelho.png";
                default:
                    return "";
            }
        }
    }
}
