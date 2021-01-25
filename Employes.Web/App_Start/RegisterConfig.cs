using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Employes.Infrastructure.Data;
using Employes.Infrastructure.Data.Interfaces;
using Employes.Infrastructure.Services;
using Employes.Infrastructure.Services.Interfaces;
using Employes.Web.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;

namespace Employes.Web.App_Start
{
    public class RegisterConfig
    {
        public static void RegisterDependencies()
        {
            var perRequestBuilder = new ContainerBuilder();

            perRequestBuilder.RegisterModule<AutofacWebTypesModule>();
            perRequestBuilder.RegisterControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();
            perRequestBuilder.RegisterApiControllers(Assembly.GetExecutingAssembly()).InstancePerRequest();

            perRequestBuilder.RegisterType<EmployesContext>().As<IDbContext>().InstancePerRequest();
            perRequestBuilder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            perRequestBuilder.RegisterType<EmployesService>().As<IEmployesService>().InstancePerDependency();
            perRequestBuilder.RegisterType<DepartmentsService>().As<IDepartmentsService>().InstancePerDependency();
            perRequestBuilder.RegisterType<LanguagesService>().As<ILanguagesService>().InstancePerDependency();

            var perRequestContainer = perRequestBuilder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(perRequestContainer));
            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver(perRequestContainer);

            var perLifetimeScopeBuilder = new ContainerBuilder();

            var perLifetimeScopeContainer = perLifetimeScopeBuilder.Build();
            Sigleton<SiteDependencyResolver>.Instance = new SiteDependencyResolver { Container = perLifetimeScopeContainer };
        }
    }
}