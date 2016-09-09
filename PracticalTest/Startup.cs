using Microsoft.Owin;
using Owin;
using PraticalTest.Domain.Interfaces;
using PraticalTest.Service;
using PraticalTest.Service.Interfaces;
using SimpleInjector;
using SimpleInjector.Integration.Web.Mvc;
using System.Web.Mvc;
using PraticalTest.Data.Repository;

[assembly: OwinStartupAttribute(typeof(PracticalTest.Startup))]
namespace PracticalTest
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            InjectorConfig.Configure();
            ConfigureAuth(app);
        }
    }

    public class InjectorConfig
    {
        public static void Configure()
        {
            var container = new Container();

            container.Register<IRepositoryClient, RepositoryClient>(Lifestyle.Transient);
            container.Register<IRepositoryUser, RepositoryUser>(Lifestyle.Transient);
            container.Register<IRepositoryRegion, RepositoryRegion>(Lifestyle.Transient);
            container.Register<IRepositoryClassification, RepositoryClassification>(Lifestyle.Transient);
            container.Register<IRepositoryCity, RepositoryCity>(Lifestyle.Transient);

            container.Register<IServiceClient, ServiceClient>(Lifestyle.Transient);
            container.Register<IServiceUser, ServiceUser>(Lifestyle.Transient);
            container.Register<IServiceRegion, ServiceRegion>(Lifestyle.Transient);
            container.Register<IServiceClassification, ServiceClassification>(Lifestyle.Transient);
            container.Register<IServiceCity, ServiceCity>(Lifestyle.Transient);

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        } 
    }
}
