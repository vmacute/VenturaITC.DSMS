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
    
    public partial class student_license_status
    {
        public int id { get; set; }
        public int student_id { get; set; }
        public int license_status_id { get; set; }
    
        public virtual license_status license_status { get; set; }
        public virtual student student { get; set; }
    }
}
