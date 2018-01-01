using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenturaITC.DSMS.Utils
{
    public class StringUtils
    {
        /// <summary>
        /// Indicates whether given full name is valid.
        /// </summary>
        /// <param name="fullName">The full name.</param>
        /// <returns>true if valid; false otherwise</returns>
        public static bool IsFullNameValid(string fullName)
        {
            try
            {
                string[] names = fullName.Split(' ');
                return names.Length > 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}