using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using RollDice.Biz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace RollDice.App_Start
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            // Register dependencies in controllers
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            // Register dependencies in filter attributes
            builder.RegisterFilterProvider();

            // Register dependencies in custom views
            builder.RegisterSource(new ViewRegistrationSource());

            // Register our Data dependencies
            //builder.RegisterModule(new DataModule("MVCWithAutofacDB"));

            builder.RegisterType(typeof(DiceRoller))
                .As(typeof(IDiceRoller))
                .SingleInstance();

            //webapi2 controllers
            builder.RegisterApiControllers(AppDomain.CurrentDomain.GetAssemblies()).InstancePerRequest();

            var container = builder.Build();

            // Set MVC DI resolver to use our Autofac container
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            // Set WEBAPI DI resolver to use our Autofac container
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}