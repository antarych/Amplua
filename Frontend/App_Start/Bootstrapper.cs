using SimpleInjector;
using System.Web.Http;
using DataAccess;
using DataAccess.Repositories;
using SimpleInjector.Integration.WebApi;
using UserManagement.Application;
using UserManagement.Domain;
using UserManagement.Infrastructure;

namespace Frontend.App_Start
{
    public class Bootstrapper
    {
        public void Setup()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebApiRequestLifestyle();
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            SetupDependencies(container);
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private void SetupDependencies(Container container)
        {
            container.Register<IUserRepository, UserRepository>();
            container.Register<IUserManager, UserManager>();
            container.Register<NHibernateHelper>(() => new NHibernateHelper());
        }
    }
}