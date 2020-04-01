using Autofac.Integration.Mvc;
using InterviewTestTemplatev2.App_Start;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace InterviewTestTemplatev2
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //IoC
            var builder = IoCConfig.ConfigureAutofac();
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);         
        }     
    }
}
