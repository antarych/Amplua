using System.Web.Http;
using DataAccess.NHibernate;
using Frontend.App_Start;

namespace Frontend
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            var bootstraper = new Bootstrapper();
            bootstraper.Setup();

            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        protected void Application_BeginRequest()
        {
            var sessionProvider = GlobalConfiguration.Configuration.DependencyResolver.GetService(
                typeof(SessionProvider)) as SessionProvider;
            sessionProvider.OpenSession();
        }

        protected void Application_EndRequest()
        {
            var sessionProvider = GlobalConfiguration.Configuration.DependencyResolver.GetService(
                typeof(SessionProvider)) as SessionProvider;
            sessionProvider.CloseSession();
        }
    }
}
