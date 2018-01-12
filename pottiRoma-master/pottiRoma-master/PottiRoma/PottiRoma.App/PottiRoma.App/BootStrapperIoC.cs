using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace PottiRoma.App
{
    public class BootStrapperIoC
    {
        public static void Init(IUnityContainer Container)
        {
            RegisterTypesRepositories(Container);
            RegisterTypesServices(Container);
            RegisterTypesAppServices(Container);
        }

        protected static void RegisterTypesRepositories(IUnityContainer Container)
        {

        }

        protected static void RegisterTypesServices(IUnityContainer Container)
        {
        }

        protected static void RegisterTypesAppServices(IUnityContainer Container)
        {
        }
    }
}
