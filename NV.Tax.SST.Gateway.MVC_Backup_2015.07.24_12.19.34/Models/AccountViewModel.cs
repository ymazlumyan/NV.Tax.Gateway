using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NV.Tax.SST.Gateway.MVC.Models
{
    public class AccountViewModel
    {
        [Display(Name = "Login")]
        [Required]
        public string Username { get; set; }

        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }


    }
}