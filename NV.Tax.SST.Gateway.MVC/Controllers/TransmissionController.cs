using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using NV.Tax.SST.Gateway.MVC.Models;

namespace NV.Tax.SST.Gateway.MVC.Controllers
{
    public class TransmissionController : Controller
    {
        
        public ActionResult Validate()
        {
            XmlDocument xml = new XmlDocument();
            
            
            return View();
        }

        [HttpPost]
        public ActionResult Validate(TransmissionModel Model, HttpPostedFileBase file)
        {
            ViewBag.Xml = "Testing: ";
            ViewBag.Xml += file;
            return View();
        }
        
    }

    public static class FileUpload
    {
        public static bool HasFile(this HttpPostedFileBase file)
        {
            return (file != null && file.ContentLength > 0) ? true : false;
        }
    }
}
