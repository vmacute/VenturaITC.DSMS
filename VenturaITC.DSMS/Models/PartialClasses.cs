using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Web;
using VenturaITC.DSMS.Classes;
using VenturaITC.DSMS.Utils;

namespace VenturaITC.DSMS.Models
{
    [MetadataType(typeof(UserMetadata))]
    public partial class user
    {
        public string _password { get; set; }

        [Compare("_password", ErrorMessage = AppConstants.ErrorMessage.ERROR_PASSWORD_DONT_MATCH)]
        public string _passwordConfirm { get; set; }
    }

    [MetadataType(typeof(UserRoleMetadata))]
    public partial class user_role
    {
    }

    [MetadataType(typeof(DBDataStatusMetadata))]
    public partial class db_data_status
    {
    }

    /// <summary>
    /// Represents the dsmsEntities class.
    /// </summary>
    /// <author> Ventura Macute - ventura.macute@gmail.com </author>
    /// <history>
    /// __________________________________________________________________________
    /// History :
    /// 20180113    Ventura Macute    [+]    Inicial version
    /// __________________________________________________________________________
    /// </history>
    public partial class dsmsEntities
    {
        /// <summary>
        /// Overriding the base.SaveChanges() so that we can intercept the EntityValidationErrors.
        /// </summary>
        /// <returns></returns>
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder validationErrors = new StringBuilder();

                foreach (var errors in ex.EntityValidationErrors)
                {
                    foreach (var error in errors.ValidationErrors)
                    {
                        Trace.TraceInformation("Entity: {0}, Property: {1}, Value: {2}, Error: {3}",
                        errors.Entry.Entity.GetType().FullName,
                        error.PropertyName,
                        errors.Entry.CurrentValues.GetValue<object>(error.PropertyName),
                        error.ErrorMessage);

                        validationErrors.Append(String.Format("Entity: {0}, Property: {1}, Value: {2}, Error: {3}",
                            errors.Entry.Entity.GetType().FullName,
                            error.PropertyName,
                            errors.Entry.CurrentValues.GetValue<object>(error.PropertyName),
                            error.ErrorMessage));
                    }
                }

                throw;
            }
        }
    }
}

