using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace VenturaITC.DSMS.Classes
{
    public class Validator
    {
        /// <summary>
        /// Indicates whether a given document size is allowed.
        /// </summary>
        /// <param name="size"></param>
        /// <returns>true if the document size is allowed; false otherwise.</returns>
        public static bool IsDocumentSizeAllowed(int size)
        {
            try
            {
                int maxSize = 0;//ParameterizationUtils.GetDocumentMaxAllowedSize();
                return size <= maxSize ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Indicates whether the user's new password is the same with the new one.
        /// </summary>
        /// <param name="oldPassword">The old password</param>
        ///  <param name="newPassword">The new password</param>
        /// <returns>true if the user's new password is the same with the new one.; false otherwise.</returns>
        public static bool IsCurrentPassword(string oldPassword, string newPassword)
        {
            try
            {
                return oldPassword == newPassword ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}