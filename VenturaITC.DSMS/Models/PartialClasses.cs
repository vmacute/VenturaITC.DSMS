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

    [MetadataType(typeof(StudentTypeMetadata))]
    public partial class student_type
    {

    }
    [MetadataType(typeof(AcademicLevelMetadata))]
    public partial class academic_level
    {

    }

    [MetadataType(typeof(ProvinceMetadata))]
    public partial class province
    {

    }

    [MetadataType(typeof(MaritalStatusMetadata))]
    public partial class marital_status
    {

    }

    [MetadataType(typeof(GenderMetadata))]
    public partial class gender
    {

    }

    [MetadataType(typeof(StatusMetadata))]
    public partial class status
    {

    }

    [MetadataType(typeof(CategoryMetadata))]
    public partial class category
    {

    }


    [MetadataType(typeof(PaymentTypeMetadata))]
    public partial class payment_type
    {

    }

}