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
    
    public partial class enrollment
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public enrollment()
        {
            this.payment_installment = new HashSet<payment_installment>();
        }
    
        public int id { get; set; }
        public int student_id { get; set; }
        public int category_id { get; set; }
        public int payment_type_id { get; set; }
        public int payment_id { get; set; }
        public int user_id { get; set; }
    
        public virtual category category { get; set; }
        public virtual payment payment { get; set; }
        public virtual payment_type payment_type { get; set; }
        public virtual student student { get; set; }
        public virtual user user { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<payment_installment> payment_installment { get; set; }
    }
}