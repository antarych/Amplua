using System.Web.Http;
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
    }
}
