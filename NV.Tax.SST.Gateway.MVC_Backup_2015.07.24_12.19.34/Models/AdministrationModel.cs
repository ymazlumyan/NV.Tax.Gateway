using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace NV.Tax.SST.Gateway.MVC.Models
{
    public class AdministrationModel
    {
        [Display(Name = "User Name")]
        [Required]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        [Required]
        public string Password { get; set; }

        [Display(Name = "Process Type")]
        [Required]
        public string ProcessType { get; set; }

        private Boolean myVar;

        public Boolean isDataPurgeScheduler
        {
            get { return myVar; }
            set { myVar = value; }
        }

        public Boolean isJobPurgeScheduler { get; set; }

    }

    public class User
    {
        public string username { get; set; }
        public string password { get; set; }
        public string email { get; set; }
    }
}