using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VenturaITC.DSMS.App_GlobalResources;
using VenturaITC.DSMS.Models;

namespace VenturaITC.DSMS.ViewModels
{
    public class StudentEnrolmentViewModel
    {
        #region StudentData
        [Display(Name = "StudentNumber", ResourceType = typeof(ResourcesFields))]
        public int student_id { get; set; }

        [Display(Name = "StudentType", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "StudentTypeRequired")]
        public int student_type_id { get; set; }

        public string student_type_name { get; set; }

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
        [RegularExpression("([A-Z][a-z]{3,} )([A-Z][a-z]{3,} )?([A-Z][a-z]{3,})", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "NameMalformed")]
        public string fathers_name { get; set; }

        [Display(Name = "MothersName", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "MothersNameRequired")]
        [RegularExpression("([A-Z][a-z]{3,} )([A-Z][a-z]{3,} )?([A-Z][a-z]{3,})", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "NameMalformed")]
        public string mothers_name { get; set; }

        [Display(Name = "Address", ResourceType = typeof(ResourcesFields))]
        public string address { get; set; }

        [Display(Name = "IDNumber", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDNumberRequired")]
        [RegularExpression(@"^\d{12}[A-Z]$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDNumberMalformed")]
        public string id_number { get; set; }

        [Display(Name = "IDIssuancePlace", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDIssuancePlaceRequired")]
        public int id_issuance_place { get; set; }

        [Display(Name = "IDIssuanceDate", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDIssuanceDateRequired")]
        [DataType(DataType.Date)]
        public DateTime id_issuance_date { get; set; }

        [Display(Name = "IDExpiryDate", ResourceType = typeof(ResourcesFields))]
        [DataType(DataType.Date)]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "IDExpiryDateRequired")]
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

        [Display(Name = "MaritalStatus", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "MaritalStatusRequired")]
        public int marital_status_id { get; set; }

        [Display(Name = "Gender", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "GenderRequired")]
        public int gender_id { get; set; }

        [Display(Name = "ProvinceOfBirth", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "ProvinceOfBirthRequired")]
        public int province_of_birth_id { get; set; }

        [Display(Name = "AcademicLevel", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "AcademicLevelRequired")]
        public int academic_level_id { get; set; }

        //[Display(Name = "Status", ResourceType = typeof(ResourcesFields))]
        //public string name;
        //status
        #endregion

        #region EnrollmentData
        [Display(Name = "Category", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "CategoryRequired")]
        public int category_id { get; set; }

        public string category_name { get; set; }

        [Display(Name = "PaymentType", ResourceType = typeof(ResourcesFields))]
        [Required(ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PaymentTypeRequired")]
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

        [Display(Name = "EnrollmentDate", ResourceType = typeof(ResourcesFields))]
        public DateTime enrollmentDate { get; set; }

        [Display(Name = "Username", ResourceType = typeof(ResourcesFields))]
        public string username { get; set; }

        [Display(Name = "Documents", ResourceType = typeof(ResourcesFields))]
        public SelectList documents { get; set; }
        #endregion

        #region Documents
        [Display(Name = "Picture", ResourceType = typeof(ResourcesFields))]
        [FileExtensions(Extensions = "png,jpg,jpeg", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PictureInvalidFormat")]
        public HttpPostedFileBase picture { get; set; }

        [Display(Name = "IDCopy", ResourceType = typeof(ResourcesFields))]
        [RegularExpression(@".*\.([pP][dD][fFG])$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PDFInvalidFormat")]
        public HttpPostedFileBase IDCopy { get; set; }

        [Display(Name = "CriminalRecordCertificate", ResourceType = typeof(ResourcesFields))]
        [RegularExpression(@".*\.([pP][dD][fFG])$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PDFInvalidFormat")]
        public HttpPostedFileBase criminalRecordCertificate { get; set; }

        [Display(Name = "MedicalCertificate", ResourceType = typeof(ResourcesFields))]
        [RegularExpression(@".*\.([pP][dD][fFG])$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PDFInvalidFormat")]
        public HttpPostedFileBase medicalCertificate { get; set; }

        [Display(Name = "MilitaryServiceStatement", ResourceType = typeof(ResourcesFields))]
        [RegularExpression(@".*\.([pP][dD][fFG])$", ErrorMessageResourceType = typeof(ResourcesFields), ErrorMessageResourceName = "PDFInvalidFormat")]
        public HttpPostedFileBase militaryServiceStatement { get; set; }
        #endregion
    }
}