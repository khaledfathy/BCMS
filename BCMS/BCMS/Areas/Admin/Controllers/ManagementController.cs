using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BCMS.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Web.Security;
using Microsoft.Owin.Security;

namespace BCMS.Areas.Admin.Controllers
{
    public class ManagementController : Controller
    {
        ApplicationDbContext db;

        [HttpGet]
        public ActionResult UsersList()
        {
            db = new ApplicationDbContext();
            var users = db.Users.Where(a => a.Roles.Count == 0).ToList();

            var x = users.Select(a => a.Roles).ToList();
            return View(users);
        }

        public ActionResult Activate(string UserId)
        {
            if (UserId != null)
            {
                db = new ApplicationDbContext();
                var user = db.Users.Where(a => a.Id == UserId).FirstOrDefault();
                user.UserStatus = UserStatus.Active;
                db.SaveChanges();
            }

            var users = db.Users.Where(a => a.Roles.Count == 0).ToList();
            return PartialView("_PartialUsers", users);
        }

        public ActionResult Deactivate(string UserId)
        {
            if (UserId != null)
            {
                db = new ApplicationDbContext();
                var user = db.Users.Where(a => a.Id == UserId).FirstOrDefault();
                user.UserStatus = UserStatus.Pending;
                db.SaveChanges();
            }
            var users = db.Users.Where(a => a.Roles.Count == 0).ToList();
            return PartialView("_PartialUsers", users);
            //return RedirectToAction("UsersList");
        }

        public ActionResult DeleteUser(string UserId)
        {
            ViewBag.UserId = UserId;
            db = new ApplicationDbContext();
            ViewBag.FullName = db.Users.FirstOrDefault(a => a.Id == UserId).FullName;
            return View();
        }

        [HttpPost]
        public ActionResult DeleteUserPost(string UserId)
        {
            if (UserId != null)
            {
                db = new ApplicationDbContext();
                var user = db.Users.Where(a => a.Id == UserId).FirstOrDefault();
                db.Users.Remove(user);
                db.SaveChanges();
            }

            var users = db.Users.Where(a => a.Roles.Count == 0).ToList();
            return PartialView("_PartialUsers", users);
        }

        [HttpGet]
        public ActionResult Staff()
        {
            db = new ApplicationDbContext();

            var usrs = db.Users.Where(a => a.Roles.Count != 0).ToList();
            List<Staff> stafList = new List<Staff>();
            foreach (var usr in usrs)
            {
                Staff staf = new Staff();
                staf.FirstName = usr.FirstName;
                if (usr.MiddleName != null)
                    staf.MiddleName = usr.MiddleName;
                else
                    staf.MiddleName = "ــ";
                staf.LastName = usr.LastName;
                staf.Email = usr.Email;
                var RolesOfUsers = db.Users.Where(a => a.Id == usr.Id).Select(a => a.Roles).FirstOrDefault();
                staf.Roles = new List<string>();
                foreach (var item in RolesOfUsers)
                {
                    var role = db.Roles.Where(a => a.Id == item.RoleId).Select(a => a.Name).FirstOrDefault();
                    staf.Roles.Add(role);
                }
                staf.UserStatus = usr.UserStatus;
                stafList.Add(staf);
            }
            return View(stafList);
        }
        [HttpGet]
        public ActionResult Roles()
        {
            db = new ApplicationDbContext();
            var roles = db.Roles.ToList();
            return View(roles);
        }
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateRole(string roleName)
        {
            db = new ApplicationDbContext();
            var role = new IdentityRole();
            role.Name = roleName;
            db.Roles.Add(role);
            db.SaveChanges();
            return PartialView("_PartialRole", db.Roles);
            //return Json("Success", JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult RemoveRole(string id)
        {
            ViewBag.RoleId = id;
            db = new ApplicationDbContext();
            var RoleName = db.Roles.Where(a => a.Id == id).Select(a => a.Name).FirstOrDefault();
            ViewBag.RoleName = RoleName;
            return View();
        }
        [HttpPost]
        public ActionResult RemoveRolePost(string RoleId)
        {
            db = new ApplicationDbContext();
            var role = db.Roles.Where(a => a.Id == RoleId).FirstOrDefault();
            db.Roles.Remove(role);
            db.SaveChanges();

            return PartialView("_PartialRole", db.Roles);
        }
        [HttpGet]
        public ActionResult AddUserToRole(string id)
        {
            ViewBag.RoleId = id;

            db = new ApplicationDbContext();
            var RName = db.Roles.Where(a => a.Id == id).Select(a => a.Name).FirstOrDefault();
            ViewBag.RoleName = RName;
            var Users = db.Users.ToList();
            var AllRolesExceptCurrent = db.Roles.Where(a => a.Id != id).ToList();
            var RolesWithUsers = AllRolesExceptCurrent.Select(a => a.Users).ToList();
            List<Staff> staffList = new List<Staff>();
            foreach (var item in Users)
            {
                Staff user = new Staff();
                if (item.Roles.Count != 0)
                {
                    var xx = db.Users.Where(a => a.Id == item.Id).Select(a => a.Roles).FirstOrDefault();

                    if (!xx.Select(a => a.RoleId).Contains(id))
                    {
                        user.Id = item.Id;
                        user.FirstName = item.FirstName;
                        user.MiddleName = item.MiddleName;
                        user.LastName = item.LastName;
                        user.Email = item.Email;
                        user.UserStatus = item.UserStatus;

                        var UserRoles = db.Users.Where(a => a.Id == item.Id).Select(a => a.Roles).FirstOrDefault();
                        var RoleIds = UserRoles.Select(a => a.RoleId).ToList();
                        user.Roles = new List<string>();
                        foreach (var RoleId in RoleIds)
                        {
                            var RoleName = db.Roles.Where(a => a.Id == RoleId).Select(a => a.Name).FirstOrDefault();
                            user.Roles.Add(RoleName);
                        }
                        staffList.Add(user);
                    }
                }
                else
                {
                    user.Id = item.Id;
                    user.FirstName = item.FirstName;
                    user.MiddleName = item.MiddleName;
                    user.LastName = item.LastName;
                    user.Email = item.Email;
                    user.Roles = null;
                    user.UserStatus = item.UserStatus;
                    staffList.Add(user);
                }
            }

            return View(staffList);
        }
        [HttpPost]
        public ActionResult AddUserToRole(string[] UsersIds, string RoleId)
        {
            db = new ApplicationDbContext();
            var RoleName = db.Roles.Where(a => a.Id == RoleId).Select(a => a.Name).FirstOrDefault();


            foreach (var UserId in UsersIds)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var result = userManager.AddToRole(UserId, RoleName);

            }
            return PartialView("_PartialRole", db.Roles);
        }
        [HttpGet]
        public ActionResult RemoveUserFromRole(string id)
        {
            ViewBag.RoleId = id;

            db = new ApplicationDbContext();
            var RName = db.Roles.Where(a => a.Id == id).Select(a => a.Name).FirstOrDefault();
            ViewBag.RoleName = RName;
            var Users = db.Users.ToList();
            List<Staff> staffList = new List<Staff>();
            foreach (var item in Users)
            {
                Staff user = new Staff();
                if (item.Roles.Count != 0)
                {
                    var xx = db.Users.Where(a => a.Id == item.Id).Select(a => a.Roles).FirstOrDefault();
                    if (xx.Select(a => a.RoleId).Contains(id))
                    {
                        user.Id = item.Id;
                        user.FirstName = item.FirstName;
                        user.MiddleName = item.MiddleName;
                        user.LastName = item.LastName;
                        user.Email = item.Email;
                        user.UserStatus = item.UserStatus;
                        var UserRoles = db.Users.Where(a => a.Id == item.Id).Select(a => a.Roles).FirstOrDefault();
                        var RoleIds = UserRoles.Select(a => a.RoleId).ToList();
                        user.Roles = new List<string>();
                        foreach (var RoleId in RoleIds)
                        {
                            if (RoleId != id)
                            {
                                var RoleName = db.Roles.Where(a => a.Id == RoleId).Select(a => a.Name).FirstOrDefault();
                                user.Roles.Add(RoleName);
                            }

                        }
                        staffList.Add(user);
                    }
                }

            }

            return View(staffList);
        }
        [HttpPost]
        public ActionResult RemoveUserFromRole(string[] UsersIds, string RoleId)
        {
            db = new ApplicationDbContext();
            var RoleName = db.Roles.Where(a => a.Id == RoleId).Select(a => a.Name).FirstOrDefault();


            foreach (var UserId in UsersIds)
            {
                var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));
                var result = userManager.RemoveFromRole(UserId, RoleName);

            }
            return PartialView("_PartialRole", db.Roles);
        }
        [HttpGet]
        public ActionResult GetUsersInRole(string Id)
        {

            db = new ApplicationDbContext();
            var RName = db.Roles.Where(a => a.Id == Id).Select(a => a.Name).FirstOrDefault();
            ViewBag.RoleName = RName;
            var Users = db.Roles.Where(a => a.Id == Id).Select(a => a.Users).FirstOrDefault();
            List<ApplicationUser> UsersInRole = new List<ApplicationUser>();

            foreach (var item in Users)
            {
                var user = db.Users.Where(a => a.Id == item.UserId).FirstOrDefault();
                UsersInRole.Add(user);

            }
            return View(UsersInRole);
        }

        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            // WebSecurity.Logout();
            Session.Clear();
            Session.Abandon();
            FormsAuthentication.SignOut();
            var test = Request.IsAuthenticated;
            return RedirectToAction("Index", "Home");
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
    }
}