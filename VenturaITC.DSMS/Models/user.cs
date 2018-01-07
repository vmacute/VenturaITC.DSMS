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
    
    public partial class user
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public user()
        {
            this.enrollments = new HashSet<enrollment>();
        }
    
        public int id { get; set; }
        public string username { get; set; }
        public string full_name { get; set; }
        public string cell_phone { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public bool locked { get; set; }
        public bool disabled { get; set; }
        public byte[] password { get; set; }
        public bool must_change_password { get; set; }
        public Nullable<System.DateTime> last_password_change { get; set; }
        public bool logged { get; set; }
        public Nullable<System.DateTime> last_login { get; set; }
        public int current_login_attempts { get; set; }
        public System.DateTime registration_date { get; set; }
        public string registration_user { get; set; }
        public string status { get; set; }
    
        public virtual db_data_status db_data_status { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<enrollment> enrollments { get; set; }
        public virtual user_role user_role { get; set; }
    }
}
