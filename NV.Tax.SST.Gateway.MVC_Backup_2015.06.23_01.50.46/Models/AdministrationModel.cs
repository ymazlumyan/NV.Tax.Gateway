using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace NV.Tax.SST.Gateway.MVC.Models
{
    public class AdministrationModel
    {
        [Display(Name = "First Name")]
        [Required]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required]
        public string LastName { get; set; }

        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Email Address")]
        [EmailAddress]
        [Required]
        public string EmailAddress { get; set; }

        private Boolean myVar;

        public Boolean isDataPurgeScheduler
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public Boolean isJobPurgeScheduler { get; set; }

    }
}