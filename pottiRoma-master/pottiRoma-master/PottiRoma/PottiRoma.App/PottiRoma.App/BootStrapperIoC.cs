using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using PottiRoma.App.Services.Implementations;
using PottiRoma.App.Services.Interfaces;

namespace PottiRoma.App
{
    public class BootStrapperIoC
    {
        public static void Init(IUnityContainer Container)
        {
            RegisterTypesAppServices(Container);
        }

        protected static void RegisterTypesAppServices(IUnityContainer Container)
        {
            Container.RegisterType<IClientsAppService, ClientsAppService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IUserAppService, UserAppService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ISalesAppService, SalesAppService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<ISeasonAppService, SeasonAppService>(new ContainerControlledLifetimeManager());
            Container.RegisterType<IGamificationPointsAppService, GamificationPointsAppService>(new ContainerControlledLifetimeManager());
        }
    }
}
