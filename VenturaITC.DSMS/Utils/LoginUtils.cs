using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenturaITC.DSMS.Utils
{
    /// <summary>
    /// Provides login utility methods. 
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20180113    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public class LoginUtils
    {

        /// <summary>
        /// Gets the logged User ID.
        /// </summary>
        /// <returns>The ID of the logged User.</returns>
        public static int GetLoggedUserID()
        {
            try
            {
                return 1;
            }
            catch (Exception)
            {
                throw;
            }
        }


        /// <summary>
        /// Gets the name of the logged User
        /// </summary>
        /// <returns>The name of the logged User.</returns>
        public static string GetLoggedUserName()
        {
            try
            {
                return "Ventura Macute" ;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}