using System.Web.Mvc;

namespace VenturaITC.DSMS.Controllers
{
    public class BaseController : Controller
    {
        public void ShowSuccessMsg(string message)
        {
            ViewBag.AlertSucess = message;
        }

        public void ShowWarningMsg(string message)
        {
            ViewBag.AlertWarning = message;
        }

        public void ShowDangerMsg(string message)
        {
            ViewBag.AlertDanger = message;
        }
        public void ShowInfoMsg(string message)
        {
            ViewBag.AlertInfo = message;
        }
    }
}