using PottiRoma.DataAccess.Core;
using PottiRoma.DataAccess.Repositories;
using PottiRoma.Services.Implementations;
using PottiRoma.Services.Interfaces;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Text;

namespace PottiRoma.IoC
{
    public class BootStrapper
    {
        public static void Register(Container container)
        {
            // https://simpleinjector.org/
            // Lifestyle.Transient => Uma instancia para cada solicitacao;
            // Lifestyle.Singleton => Uma instancia unica para a classe;
            // Lifestyle.Scoped => Uma instancia unica para o request;

            RegisterServices(container);
        }

        public static void RegisterServices(Container container)
        {
            container.Register<IUserService, UserService>(Lifestyle.Transient);
            container.Register<ISalesService, SalesService>(Lifestyle.Transient);
            container.Register<IClientsService, ClientsService>(Lifestyle.Transient);
            container.Register<IAuthenticationService, AuthenticationService>(Lifestyle.Transient);
            container.Register<ISeasonService,SeasonService>(Lifestyle.Transient);
            container.Register<IGamificationPointsService, GamificationPointsService>(Lifestyle.Transient);
            container.Register<IChallengesService, ChallengesService>(Lifestyle.Transient);
            container.Register<ITrophyService, TrophyService>(Lifestyle.Transient);
        }
    }
}
