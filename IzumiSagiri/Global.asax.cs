using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using IzumiSagirisCommon.Resolver;
using IzumiSagiri.App_Start;

namespace IzumiSagiri
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            IzumiIocManager.RegisterIzumiLocator(new IzumiContainer());
           // DependencyResolver.SetResolver(new IzumiDependencyResolver());

        }
    }
}
