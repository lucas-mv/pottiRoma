using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PottiRoma.App.Utils.NavigationHelpers
{
    public static class NavigationSettings
    {
        #region Telas do Menu Principal

        public const string MenuPrincipal = "app:///MenuPrincipalPage/MainNavigationPage/RankingPage";

        public const string ListClientsForSale = "MainNavigationPage/ListClientsForSalePage";
        public const string InviteFlower = "MainNavigationPage/InviteFlowerPage";
        public const string RankingDetail = "MainNavigationPage/RankingPage";
        public const string MyClients = "MainNavigationPage/MyClientsPage";
        public const string EditPersonalData = "MainNavigationPage/EditPersonalDataPage";
        public const string TrophyRoom = "MainNavigationPage/TrophyRoomPage";
        public const string GamificationRules = "MainNavigationPage/GamificationRulesPage";
        public const string SalesHistory = "MainNavigationPage/SalesHistoryPage";


        #endregion

        public const string RegisterClients = "RegisterClientsPage";
        public const string Login = "LoginPage";
        public const string AbsoluteLogin = "app:///LoginPage";
        public const string RegisterSale = "RegisterSalePage";
        public const string ResetPassword = "ResetPasswordPage";

    }
}
