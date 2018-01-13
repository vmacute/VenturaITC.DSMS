using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Resources;
using VenturaITC.DSMS.App_GlobalResources;
using VenturaITC.DSMS.Classes;

namespace VenturaITC.DSMS.Models
{
    public class UserMetadata
    {
        [Display(Name = "Username", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "UsernameRequired")]
        [StringLength(50, ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "FieldLong")]
        public string username;

        [Display(Name = "Name", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "NameRequired")]
        [StringLength(255, ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "FieldLong")]
        //[RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$", ErrorMessageResourceType = typeof(ERRORMSG), ErrorMessageResourceName = "RegExEmpName")]
        [RegularExpression("([A-Z][a-z]{3,} )([A-Z][a-z]{3,} )?([A-Z][a-z]{3,})", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "NameMalformed")]
        public string full_name;


        [Display(Name = "CellPhone", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "CellPhoneRequired")]
        [StringLength(255, ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "FieldLong")]
        [RegularExpression(@"^82(\d{7})|83(\d{7})|84(\d{7})|85(\d{7})|86(\d{7})|87(\d{7})$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "CellPhoneMalformed")]
        public string cell_phone;

        [Display(Name = "Email", ResourceType = typeof(ResourcesFields))]
        [StringLength(50, ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "FieldLong")]
        [DataType(DataType.EmailAddress)]
        public string email;

        [Display(Name = "UserRole", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "UserRoleRequired")]
        public string role;

        [Display(Name = "Locked", ResourceType = typeof(ResourcesFields))]
        public bool locked;

        [Display(Name = "Disabled", ResourceType = typeof(ResourcesFields))]
        public bool disabled;

        [Display(Name = "Password", ResourceType = typeof(ResourcesFields))]
        public byte[] password;

        [Display(Name = "MustChangePassword", ResourceType = typeof(ResourcesFields))]
        public bool must_change_password;

        [Display(Name = "LastPasswordChange", ResourceType = typeof(ResourcesFields))]
        public Nullable<DateTime> last_password_change;

        [Display(Name = "Logged", ResourceType = typeof(ResourcesFields))]
        public bool logged;

        [Display(Name = "LastLogin", ResourceType = typeof(ResourcesFields))]
        public Nullable<DateTime> last_login;

        [Display(Name = "LoginAttempts", ResourceType = typeof(ResourcesFields))]
        public int current_login_attempts;

        [Display(Name = "RegistrationDate", ResourceType = typeof(ResourcesFields))]
        public DateTime registration_date;

        [Display(Name = "RegistrationUser", ResourceType = typeof(ResourcesFields))]
        public string registration_user;

        [Display(Name = "Status", ResourceType = typeof(ResourcesFields))]
        public string status;

        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PasswordRequired")]
        [Display(Name = "Password", ResourceType = typeof(ResourcesFields))]
        [DataType(DataType.Password)]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{8,15}$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PasswordInvalid")]
        public string _password;

        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PasswordConfirmRequired")]
        [Display(Name = "PasswordConfirm", ResourceType = typeof(ResourcesFields))]
        [DataType(DataType.Password)]
        public string _passwordConfirm;

    }

    public class UserRoleMetadata
    {
        [Display(Name = "UserRole", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "UserRoleRequired")]
        public string name;

        [Display(Name = "UserRole", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "UserRoleRequired")]
        public string description;
    }

    public class DBDataStatusMetadata
    {
        [Display(Name = "Status", ResourceType = typeof(ResourcesFields))]
        public string name;

        [Display(Name = "Status", ResourceType = typeof(ResourcesFields))]
        public string description;
    }
    
}