using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using VenturaITC.DSMS.App_GlobalResources;
using VenturaITC.DSMS.Models;

namespace VenturaITC.DSMS.ViewModels
{
    public class StudentEnrolmentViewModel
    {
        #region StudentData
        [Display(Name = "FullName", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "FullNameRequired")]
        [RegularExpression("([A-Z][a-z]{3,} )([A-Z][a-z]{3,} )?([A-Z][a-z]{3,})", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "NameMalformed")]
        public string full_name { get; set; }

        [Display(Name = "Birthdate", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "BirthdateRequired")]
        [DataType(DataType.Date)]
        public DateTime birth_date { get; set; }

        [Display(Name = "PlaceOfBirth", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PlaceOfBirthRequired")]
        public string place_of_birth { get; set; }

        [Display(Name = "FathersName", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "FathersNameRequired")]
        public string fathers_name { get; set; }

        [Display(Name = "MothersName", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "MothersNameRequired")]
        public string mothers_name { get; set; }

        [Display(Name = "Address", ResourceType = typeof(ResourcesFields))]
        public string address { get; set; }

        [Display(Name = "IDNumber", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDNumberRequired")]
        [RegularExpression(@"^\d{12}[A-Z]$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDNumberMalformed")]
        public string id_number { get; set; }

        [Display(Name = "IDIssuancePlace", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDIssuancePlaceRequired")]
        public string id_issuance_place { get; set; }

        [Display(Name = "IDIssuanceDate", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDIssuanceDateRequired")]
        [DataType(DataType.Date)]
        public DateTime id_issuance_date { get; set; }

        [Display(Name = "IDExpiryDate", ResourceType = typeof(ResourcesFields))]
        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDExpiryDateRequired")]
        [RegularExpression(@"^\d{12}[A-Z]$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDNumberMalformed")]
        public DateTime id_expiry_date { get; set; }

        [Display(Name = "JobTitle", ResourceType = typeof(ResourcesFields))]
        public string job_title { get; set; }

        [Display(Name = "PhoneNumber", ResourceType = typeof(ResourcesFields))]
        [RegularExpression(@"^21(\d{6})|281(\d{6})|282(\d{6})|293(\d{6})|23(\d{6})|251(\d{6})252(\d{6})|24(\d{6})|26(\d{6})|271(\d{6})|272(\d{6})$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PhoneMalformed")]
        public string phone_number { get; set; }

        [Display(Name = "CellPhone1", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "CellPhone1Required")]
        [RegularExpression(@"^82(\d{7})|83(\d{7})|84(\d{7})|85(\d{7})|86(\d{7})|87(\d{7})$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "CellPhoneMalformed")]
        public string cell_phone1 { get; set; }

        [Display(Name = "CellPhone2", ResourceType = typeof(ResourcesFields))]
        [RegularExpression(@"^82(\d{7})|83(\d{7})|84(\d{7})|85(\d{7})|86(\d{7})|87(\d{7})$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "CellPhoneMalformed")]
        public string cell_phone2 { get; set; }

        [Display(Name = "Email", ResourceType = typeof(ResourcesFields))]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        public int student_type_id { get; set; }

        public int marital_status_id { get; set; }
        public int gender_id { get; set; }
        public int province_of_birth_id { get; set; }
        public int academic_level_id { get; set; }
        public int status_id { get; set; }

        public virtual academic_level academic_level { get; set; }
        public virtual gender gender { get; set; }
        public virtual marital_status marital_status { get; set; }
        public virtual province province { get; set; }
        public virtual province province1 { get; set; }
        public virtual status status { get; set; }
        public virtual student_type student_type { get; set; }
        #endregion

        #region EnrollmentData
        public int category_id { get; set; }
        public int payment_type_id { get; set; }

        [Display(Name = "ReceiptNumber", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "ReceiptNumberRequired")]
        public int payment_id { get; set; }

        [Display(Name = "TotalAmount", ResourceType = typeof(ResourcesFields))]
        public decimal totalAmount { get; set; }

        [Display(Name = "MinimumAmount", ResourceType = typeof(ResourcesFields))]
        public decimal minimumAmount { get; set; }

        [Display(Name = "AmountToPay", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "AmountToPayRequired")]
        public decimal amountToPay { get; set; }
        public virtual category category { get; set; }
        public virtual payment_type payment_type { get; set; }
        #endregion
    }
}