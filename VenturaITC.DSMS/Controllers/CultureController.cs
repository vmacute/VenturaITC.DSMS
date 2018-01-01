using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VenturaITC.DSMS.Controllers
{
    public class CultureController : Controller
    {
        // GET: Culture
        public ActionResult SetCulture(string lang)
        {
            HttpContext.Session["culture"] = lang;
            return Redirect(Request.UrlReferrer.ToString());
        }
    }
}