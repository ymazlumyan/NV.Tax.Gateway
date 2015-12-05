using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using NV.Tax.SST.Gateway.MVC.Models;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;
using System.Diagnostics;

namespace NV.Tax.SST.Gateway.MVC.Controllers
{
    [Authorize]
    public class AdministrationController : Controller
    {
        // Declaring Database Entity 
        private static DB.Entities.sstpEntities db = new DB.Entities.sstpEntities();
        private string globalMessage = "Testing User Management";

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
        public ActionResult CreateUser(AdministrationModel model, string UserName, string Password, string processType)
        {
            if (ModelState.IsValid)
            {
                char process;
                process = (processType != null) ? processType[0] : 'E';
                DB.Entities.user data = new DB.Entities.user
                {
                    username = UserName,
                    password = Password,
                    processtype = process.ToString(),
                    automanage = true
                };
                UserName = "";
                Password = "";
                
                db.users.Add(data);
                db.SaveChanges();
            }

            return RedirectToAction("Manager");
        }

        public ActionResult Manager()
        {
            // Test Messages 
            ViewBag.ErrorMessage = globalMessage;
            
            // Access MySQL Database and add all users to the list with their 
            // respective information
            var dbData = db.users.ToList();
            List<UserManagementModel> userList = new List<UserManagementModel>();
            UserManagementModel userModel = new UserManagementModel();

            foreach (var item in dbData)
            {
                userModel = new UserManagementModel();
                userModel.UserName = item.username;
                userModel.ProcessType = (item.processtype == "B") ? "Both" : "Processed";
                userModel.isAutoManaged = item.automanage;

                // Add to the list
                userList.Add(userModel);
            }

            AdministrationModel model = new AdministrationModel();
            model.UsersList = userList;
            ViewBag.UsersList = userList;
            return View();
        }

        public ActionResult Role_Management()
        {
            return View();
        }

        public ActionResult RemoveRole(string name, string role)
        {
            var roleDb = new NV.Tax.SST.Gateway.DB.Entities.userRoleEntity();
            var data = from m in roleDb.user_role
                       where m.username == name
                       select m;
            try
            {
                NV.Tax.SST.Gateway.DB.Entities.user_role roles = roleDb.user_role.First(m => m.username == name);
                roleDb.user_role.Remove(roles);
                roleDb.SaveChanges();
            }
            catch ( Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return RedirectToAction("Role_Management", "Administration", new { id = name });
        }

        public ActionResult AddRole(string name, string role)
        {
            var roleDb = new NV.Tax.SST.Gateway.DB.Entities.userRoleEntity();
            var data = from m in roleDb.user_role
                       where m.username == name
                       select m;
            try
            {
                DB.Entities.userRoleEntity roleEntity = new DB.Entities.userRoleEntity();
                DB.Entities.user_role roles = new DB.Entities.user_role();
                roles.username = name;
                roles.role = role;
                roleEntity.user_role.Add(roles);
                roleEntity.SaveChanges();                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return RedirectToAction("Role_Management", "Administration", new { id = name });
        }

        public ActionResult RemoveUser()
        {
            string name = Url.RequestContext.RouteData.Values["id"].ToString();
            var roleDb = new NV.Tax.SST.Gateway.DB.Entities.userRoleEntity();
            try
            {
                var count = from m in roleDb.user_role
                           where m.username == name
                           select m;
                if (count.Count() > 0)
                {
                    DB.Entities.user_role roles = roleDb.user_role.First(m => m.username == name);
                    roleDb.user_role.Remove(roles);
                    roleDb.SaveChanges();
                }
                
                DB.Entities.user users = db.users.First(m => m.username == name);
                db.users.Remove(users);
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                globalMessage = ex.Message;
            }
            
            return RedirectToAction("Manager");
        }

        public ActionResult EditUser()
        {

            return View();
        }

        [HttpPost]
        public ActionResult EditUser(string Username, string Password, string ProcessType)
        {
            if (ModelState.IsValid)
            {
                DB.Entities.user user = db.users.First(m => m.username == Username);
                user.password = Password;
                user.processtype = ProcessType[0].ToString();
                db.SaveChanges();
            }
            return RedirectToAction("Manager");
        }

        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateRole(string UserRole)
        {
            if (ModelState.IsValid)
            {
                DB.Entities.role roles = new DB.Entities.role();
                roles.role1 = UserRole.ToUpper();
                db.roles.Add(roles);
                db.SaveChanges();
            }

            return RedirectToAction("Manager");
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

        public ActionResult UserList([DataSourceRequest] DataSourceRequest request)
        {
            var entities = new NV.Tax.SST.Gateway.DB.Entities.userRoleEntity();
            var data = from db in entities.user_role
                       select db;
            List<string> userList = new List<string>();
            foreach(var item in data)
            {
                userList.Add(item.username.ToString());
                ViewBag.UserList = item.username.ToString();
            }
            return Json(GetRoleList().ToDataSourceResult(request));
        }

        private static IEnumerable<UsersModel>GetUserList()
        {
            var entities = new SST.Gateway.DB.Entities.sstpEntities();
            return entities.users.Select(user => new UsersModel
                        {
                            Username = user.username,
                            Password = user.password,
                            ProcessType = user.processtype
                        });
        }
        private static IEnumerable<RoleModel>GetRoleList()
        {
            var entities = new SST.Gateway.DB.Entities.userRoleEntity();
            return entities.user_role.Select(userRole => new RoleModel
                {
                    Username = userRole.username,
                    UserRole = userRole.role
                });
        }

        public ActionResult ChangePassword(string id, string Password, string ConfirmPassword)
        {
            if (ModelState.IsValid)
            {
                if (Password == ConfirmPassword)
                {
                    DB.Entities.user user = db.users.First(m => m.username == id);
                    user.password = Password;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("Manager");
        }
    }
}
