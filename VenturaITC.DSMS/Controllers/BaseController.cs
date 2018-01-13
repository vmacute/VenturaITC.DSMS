using System.Web.Mvc;

namespace VenturaITC.DSMS.Controllers
{
    /// <summary>
    ///Represents the base class for the application Controllers.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20171022    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class BaseController : Controller
    {
        /// <summary>
        /// Shows a success alert.
        /// </summary>
        /// <param name="message">The alert message.</param>
        public void ShowSuccessAlert(string message)
        {
            ViewBag.AlertSucess = message;
        }

        /// <summary>
        /// Shows a warning alert.
        /// </summary>
        /// <param name="message">The alert message.</param>
        public void ShowWarningAlert(string message)
        {
            ViewBag.AlertWarning = message;
        }

        /// <summary>
        /// Shows an error alert.
        /// </summary>
        /// <param name="message">The alert message.</param>
        public void ShowErrorAlert(string message)
        {
            ViewBag.AlertDanger = message;
        }

        /// <summary>
        /// Shows an information alert.
        /// </summary>
        /// <param name="message">The alert message.</param>
        public void ShowInfoAlert(string message)
        {
            ViewBag.AlertInfo = message;
        }
    }
}