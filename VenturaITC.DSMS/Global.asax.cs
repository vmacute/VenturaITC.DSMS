using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace VenturaITC.DSMS
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            // For example a cookie, but better extract it from the url
            //string culture = HttpContext.Current.Request.Cookies["en"].Value;

            if (HttpContext.Current != null && HttpContext.Current.Session != null)
            {
                if (HttpContext.Current.Session["culture"] != null)
                {
                    string culture = HttpContext.Current.Session["culture"].ToString();

                    Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo(culture);
                    Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo(culture);
                    return;
                }
            }

            //Defaul culture
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("pt");
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("pt");
        }
    }
}
