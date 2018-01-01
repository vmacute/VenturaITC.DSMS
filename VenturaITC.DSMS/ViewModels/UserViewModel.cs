using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VenturaITC.DSMS.Models;

namespace VenturaITC.DSMS.ViewModels
{
    public class UserViewModel
    {
        public string username { get; set; }
        public string full_name { get; set; }
        public string cell_phone { get; set; }
        public string email { get; set; }
        public string role { get; set; }
        public bool locked { get; set; }
        public bool disabled { get; set; }
        public bool must_change_password { get; set; }
        public bool logged { get; set; }
        public string status { get; set; }

        public virtual db_data_status db_data_status { get; set; }
        public virtual user_role user_role { get; set; }
    }
}