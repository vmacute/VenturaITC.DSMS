using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenturaITC.DSMS.DAL;
using VenturaITC.DSMS.Models;

namespace VenturaITC.DSMS.Utils
{
    public class UserUtils
    {
        /// <summary>
        /// Indicates whether a given username is already registered. 
        /// </summary>
        /// <param name="username">The username.</param>
        /// <returns>true if the given username is already registered, false otherwise.</returns>
        public static bool ExistUsername(string username)
        {
            try
            {
                user user = UWork<user>.FindBy(x => x.username == username).FirstOrDefault();
                return user != null ? true : false;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}