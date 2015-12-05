using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NV.Tax.SST.Gateway.MVC.Models;

namespace NV.Tax.SST.Gateway.MVC.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateUser(AdministrationModel model, string UserName)
        {
            return RedirectToAction("CreateRole");
        }

        public ActionResult CreateOnlyUser()
        {
            return View();
        }
        public ActionResult Manager()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateRole(string id)
        {
            ViewBag.Message = id;
            return View();
        }

        public ActionResult DataViewer()
        {
            return View();
        }

        public ActionResult doPurgeToggle(Boolean obj)
        {
            if (obj)
            {
                obj = false;
            }
            else
            {
                obj = true;
            }
            return View();
        }


        public Boolean doToggle(Boolean obj)
        {
            if (obj)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
