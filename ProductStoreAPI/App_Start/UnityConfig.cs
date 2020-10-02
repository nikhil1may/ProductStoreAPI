using ProductStoreAPI.Utility;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace ProductStoreAPI
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {

            var container = new UnityContainer();
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }

        public static UnityContainer Register()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<IDatabaseOperations, DatabaseOperations>();
            return container;
        }
    }
}