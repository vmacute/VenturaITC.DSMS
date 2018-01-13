using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenturaITC.DSMS.Models;
using VenturaITC.DSMS.Utils;

namespace VenturaITC.DSMS.Controllers
{
    /// <summary>
    /// Provides payment utility methods. 
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20180113    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class PaymentUtilsController : Controller
    {
        private string numberFormatting= AppConstants.Numeric.NUMBER_FORMATTING;
        /// <summary>
        /// Gets a Category's cost.
        /// </summary>
        /// <param name="categoryID">The Category ID.</param>
        /// <returns>The cost of the given Category's ID.</returns>
        [HttpGet]
        public JsonResult GetCategoryCost(int categoryID)
        {
            try
            {
                using (dsmsEntities db = new dsmsEntities())
                {
                    category categ = db.categories.Find(categoryID);
                    return Json(new { categoryCost = categ.cost.ToString(numberFormatting) }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Gets the enrollment payment amounts.
        /// </summary>
        /// <param name="categoryID">The Category ID.</param>
        /// <param name="paymentTypeID">The Payment Type ID.</param>
        /// <returns>The minimum and the total payment amount for the enrollment process.</returns>
        [HttpGet]
        public JsonResult GetEnrollmentPaymentAmounts(int categoryID, int paymentTypeID)
        {
            try
            {
                using (dsmsEntities db = new dsmsEntities())
                {
                    category categ = db.categories.Find(categoryID);

                    //Get the percentage of the first installment.
                    decimal percent = db.installments.Find(1).percentage;

                    switch (paymentTypeID)
                    {
                        case 2:
                            return Json(new
                            {
                                //TODO: check for easy way to get value's percentage
                                minimumAmount = (categ.cost * percent / 100).ToString(numberFormatting),
                                amountToPay = (categ.cost * percent / 100).ToString(numberFormatting)
                            }, JsonRequestBehavior.AllowGet);


                        default:
                            return Json(new
                            {
                                minimumAmount = categ.cost.ToString(numberFormatting),
                                amountToPay = categ.cost.ToString(numberFormatting)
                            }, JsonRequestBehavior.AllowGet);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}