using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VenturaITC.DSMS.Classes;

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

}