using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NV.Tax.SST.Gateway.MVC.Models;
using System.Web.Security;
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
        public ActionResult Login(AccountViewModel model, string name, string returnUrl)
        {
            var message = Request["ErrorMessage"];
            var user = Request["Username"];
            var pass = Request["Password"];
            var entity = new DB.Entities.sstpEntities();
            var item = from db in entity.users
                       where user == db.username &&
                             pass == db.password
                       select db;
            if (item.Count() != 0)
            {
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(user, false, 60);
                string encTicket = FormsAuthentication.Encrypt(ticket);
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encTicket));
                if (returnUrl == string.Empty || returnUrl == null || returnUrl == "")
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    return Redirect(returnUrl);
                }
            }
            else
            {
                ViewBag.ErrorMessage = "The username and password combination is incorrect";
                
                
            }


            return View();
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
