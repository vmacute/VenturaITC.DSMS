//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace VenturaITC.DSMS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class student
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public student()
        {
            this.enrollments = new HashSet<enrollment>();
            this.student_documentation = new HashSet<student_documentation>();
            this.student_payment = new HashSet<student_payment>();
            this.student_enrollment = new HashSet<student_enrollment>();
        }
    
        public int id { get; set; }
        public int student_type_id { get; set; }
        public string full_name { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public System.DateTime birth_date { get; set; }
        public int marital_status_id { get; set; }
        public int gender_id { get; set; }
        public string place_of_birth { get; set; }
        public int province_of_birth_id { get; set; }
        public string fathers_name { get; set; }
        public string mothers_name { get; set; }
        public string address { get; set; }
        public string id_number { get; set; }
        public int id_issuance_place { get; set; }
        public System.DateTime id_issuance_date { get; set; }
        public System.DateTime id_expiry_date { get; set; }
        public int academic_level_id { get; set; }
        public string job_title { get; set; }
        public string phone_number { get; set; }
        public string cell_phone1 { get; set; }
        public string cell_phone2 { get; set; }
        public string email { get; set; }
        public int status_id { get; set; }
    
        public virtual academic_level academic_level { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enrollment> enrollments { get; set; }
        public virtual gender gender { get; set; }
        public virtual marital_status marital_status { get; set; }
        public virtual province province { get; set; }
        public virtual province province1 { get; set; }
        public virtual status status { get; set; }
        public virtual student_type student_type { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<student_documentation> student_documentation { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<student_payment> student_payment { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<student_enrollment> student_enrollment { get; set; }
    }
}
