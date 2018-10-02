using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using NLog;

namespace WebApplication2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private Logger logger = 
            LogManager.GetCurrentClassLogger();

        protected void Application_Start()
        {
            logger.Info(DateTime.Now+ ": Application_Start");
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Application_End()
        {
            logger.Info(DateTime.Now + ": Application_End");
        }

        //наступает когда необработанное исключение происиходти в приложении
        public void Application_Error()
        {
            logger.Info(DateTime.Now + ": Application_Error");
        }

        public void Application_BeginReqest()
        {
            logger.Info(DateTime.Now + ": Application_BeginReqest");
        }
        public void Application_EndReqest()
        {
            logger.Info(DateTime.Now + ": Application_EndReqest");
        }
    }
}
