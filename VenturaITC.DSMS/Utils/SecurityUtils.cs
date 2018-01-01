using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VenturaITC.DSMS.Utils
{
    public class SecurityUtils
    {

        public static string FormatPassword(string password)
        {
            try
            {
                return "username" + password;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}