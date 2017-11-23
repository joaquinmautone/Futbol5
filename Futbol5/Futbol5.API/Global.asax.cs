using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Futbol5.DAL.Infrastructure;
using Futbol5.DAL.Repositories;
using Futbol5.ServiceAgent;

namespace Futbol5.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            Configure();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);            
        }

        public static void Configure()
        {
            ConfigureAutofacContainer();
            AutoMapperConfiguration.Configure();
        }

        public static void ConfigureAutofacContainer()
        {

            var webApiContainerBuilder = new ContainerBuilder();
            ConfigureWebApiContainer(webApiContainerBuilder);
        }

        public static void ConfigureWebApiContainer(ContainerBuilder containerBuilder)
        {
            containerBuilder.RegisterType<DatabaseFactory>().As<IDatabaseFactory>().AsImplementedInterfaces().InstancePerApiRequest();
            containerBuilder.RegisterType<UnitOfWork>().As<IUnitOfWork>().AsImplementedInterfaces().InstancePerApiRequest();
            containerBuilder.RegisterType<CampeonatoRepository>().As<ICampeonatoRepository>().AsImplementedInterfaces().InstancePerApiRequest();
            containerBuilder.RegisterType<CampeonatoService>().As<ICampeonatoService>().InstancePerApiRequest();
            containerBuilder.RegisterType<EquipoRepository>().As<IEquipoRepository>().AsImplementedInterfaces().InstancePerApiRequest();
            containerBuilder.RegisterType<EquipoService>().As<IEquipoService>().InstancePerApiRequest();
            containerBuilder.RegisterType<JugadorRepository>().As<IJugadorRepository>().AsImplementedInterfaces().InstancePerApiRequest();
            containerBuilder.RegisterType<JugadorService>().As<IJugadorService>().InstancePerApiRequest();

            containerBuilder.RegisterApiControllers(System.Reflection.Assembly.GetExecutingAssembly());
            IContainer container = containerBuilder.Build();
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}
