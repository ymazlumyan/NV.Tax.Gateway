using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace NV.Tax.SST.Gateway.MVC.Models
{
    public class RoleModel
    {
        [Display(Name = "Username")]        
        public string Username { get; set; }

        [Display(Name = "User Role")]
        public string UserRole { get; set; }
    }
}
