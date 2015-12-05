using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NV.Tax.SST.Gateway.MVC.Models
{
    public class UsersModel
    {
        [Display(Name="Username")]
        public string Username { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Processing Type")]
        public string ProcessType { get; set; }

    }
}