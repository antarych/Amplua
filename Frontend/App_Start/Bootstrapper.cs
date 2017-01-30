using System;
using System.Configuration;
using SimpleInjector;
using System.Web.Http;
using Common;
using DataAccess;
using DataAccess.NHibernate;
using DataAccess.Repositories;
using FileManagement;
using Frontend.App_Data;
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
            RegisterSettings(container);
            SetupDependencies(container);            
            container.Verify();
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private void SetupDependencies(Container container)
        {
            container.Register<IUserRepository, UserRepository>();
            container.Register<IUserManager, UserManager>();
            container.Register<ISessionProvider, SessionProvider>();
            container.Register<NHibernateHelper>(() => new NHibernateHelper());
            container.Register<IAuthorizer>(() => new Authorizer(
                    TimeSpan.FromSeconds(int.Parse(ConfigurationManager.AppSettings["Authorizer.TokenLifeTimeInSeconds"])),
                    container.GetInstance<IUserRepository>()),
                Lifestyle.Singleton);
            container.Register<IFileManager, FileManager>(Lifestyle.Singleton);
            //container.Register<IImageResizer>(
            //    () =>
            //        new ImageResizer(500, container.GetInstance<FileStorage>(),
            //            container.GetInstance<ApplicationLocationSettings>()), Lifestyle.Singleton);
        }

        private static void RegisterSettings(Container container)
        {
            var settings = ConfigurationManager.AppSettings;
            container.Register(() => SettingsReader.ReadFileStorage(settings), Lifestyle.Singleton);

        }
    }
}