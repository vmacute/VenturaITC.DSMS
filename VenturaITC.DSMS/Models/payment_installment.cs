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
    
    public partial class payment_installment
    {
        public int id { get; set; }
        public Nullable<int> enrollment_id { get; set; }
        public Nullable<int> installment_id { get; set; }
        public Nullable<int> payment_id { get; set; }
    
        public virtual enrollment enrollment { get; set; }
        public virtual installment installment { get; set; }
        public virtual payment payment { get; set; }
    }
}
