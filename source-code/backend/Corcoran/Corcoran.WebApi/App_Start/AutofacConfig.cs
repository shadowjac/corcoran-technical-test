using Autofac;
using Autofac.Integration.WebApi;
using Corcoran.DataAccess.Implementations;
using Corcoran.DataAccess.Interfaces;
using System.Reflection;
using System.Web;
using System.Web.Http;

namespace Corcoran.WebApi.App_Start
{
    public static class AutofacConfig
    {
        public static IContainer Container;

        public static void Initialize(HttpConfiguration config)
        {
            Initialize(config, RegisterServices(new ContainerBuilder()));
        }


        public static void Initialize(HttpConfiguration config, IContainer container)
        {
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }

        private static IContainer RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly()).PropertiesAutowired();
            builder.RegisterType<PresidentsContext>()
                .As<IPresidentsContext>()
                .WithParameter(new NamedParameter("dataPath", HttpContext.Current.Server.MapPath("AppData/Presidents.csv")))
                .SingleInstance()
                .PropertiesAutowired();

            Container = builder.Build();

            return Container;
        }
    }
}