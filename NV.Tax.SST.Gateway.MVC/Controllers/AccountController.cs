using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NV.Tax.SST.Gateway.MVC.Models;
using System.Web.Security;
using System.Web.WebPages;
using NV.Tax.SST.Gateway.DB;

namespace NV.Tax.SST.Gateway.MVC.Controllers
{
    public class AccountController : Controller
    {
        /// <summary>
        ///     Includes Login, Registration pages
        ///     Login and Registration have forms so they have 
        ///     GET and POST methods
        /// </summary>
        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        // Post method for Login
        [HttpPost]
        public ActionResult Login(AccountViewModel model, string returnUrl)
        {
            var entity = new DB.Entities.sstpEntities();
            
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(model.Username, false, 60);
            string encTicket = FormsAuthentication.Encrypt(ticket);
            Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
            if (returnUrl.IsEmpty())
            {
                return (RedirectToAction("Index", "Home"));
            }
            else
            {
                return Redirect(returnUrl);
            }
        }

        // Log out Action
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, "");
            cookie.Expires = DateTime.Now.AddYears(-1);
            Response.Cookies.Add(cookie);
            FormsAuthentication.RedirectToLoginPage();
            return View();
        }
    }
}
