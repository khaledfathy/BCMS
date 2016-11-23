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
using System.Threading.Tasks;

namespace BCMS.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ManagementController : Controller
    {
        ApplicationDbContext db;
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        // Get All users who not assigned to role
        [HttpGet]
        public ActionResult UsersList()
        {
            try
            {
                db = new ApplicationDbContext();
                var users = db.Users.Where(a => a.Roles.Count == 0).ToList();
                var x = users.Select(a => a.Roles).ToList();
                return View(users);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
            
        }

        // Activate user
        public ActionResult Activate(string UserId)
        {
            try
            {
                if (UserId != null)
                {
                    db = new ApplicationDbContext();
                    var user = db.Users.Where(a => a.Id == UserId).FirstOrDefault();
                    user.UserStatus = UserStatus.Active;
                    db.SaveChanges();
                    var body = "<div style='text-align:center;'><h1>مرحباً بك فى بورصة كابيتال</h1>";
                    body += "<h3 style='color:green;'>تم تفعيل حسابك على بورصة كابيتال بنجاح</h3>";
                    body += "<h2>شكراً لاستخدامك بورصة كابيتال</h2>";
                    body += "<h2>من فضلك اضغط <a href='http://sa.borsacapital.com/#/Login'>هنــا لتسجيل الدخول</a> للموقع</h2>";
                    body += "<p>إذا واجهتك اى مشاكل او اذا كنت تريد الاستفسار عن اى شئ من فضلك لا تتردد فى <a href='http://sa.borsacapital.com/#/ContactUs'>التواصل معنا</a></p>";

                    body += "<br /><br />";

                    body += "<div style='text-align:center;'><h1>Welcome to Borsa Capital</h1>";
                    body += "<h3 style='color:green;'>Your account has been activeted succesfuly.</h3>";
                    body += "<h2>Thank you for using Borsa Capital</h2>";
                    body += "<h2>Please click <a href='http://sa.borsacapital.com/#/Login' > here to login</a> the site</h2>";
                    body += "<p>If you facing any problem or any question please don't hesitate to <a href='http://sa.borsacapital.com/#/ContactUs'>contact us</a></p>";
                    string msg = EmailVerification.SendEMail(user.Email, "Borsa Capital Admission", body);

                }

                var users = db.Users.Where(a => a.Roles.Count == 0).ToList();
                return PartialView("_PartialUsers", users);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Deactivate user
        public ActionResult Deactivate(string UserId)
        {
            try
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
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Delete user //  Get confirmation view in popup
        public ActionResult DeleteUser(string UserId)
        {
            try
            {
                ViewBag.UserId = UserId;
                db = new ApplicationDbContext();
                ViewBag.FullName = db.Users.FirstOrDefault(a => a.Id == UserId).FullName;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Delete user // Post
        [HttpPost]
        public ActionResult DeleteUserPost(string UserId)
        {
            try
            {
                if (UserId != null)
                {
                    db = new ApplicationDbContext();
                    var connections = db.Connections.Where(a => a.UserId == UserId).ToList();
                    if (connections != null)
                    {
                        foreach (var item in connections)
                        {
                            db.Connections.Remove(item);
                            db.SaveChanges();
                        }
                    }
                    var user = db.Users.Where(a => a.Id == UserId).FirstOrDefault();

                    db.Users.Remove(user);
                    db.SaveChanges();
                }

                var users = db.Users.Where(a => a.Roles.Count == 0).ToList();
                return PartialView("_PartialUsers", users);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Get All Staff
        [HttpGet]
        public ActionResult Staff()
        {
            try
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
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Get All roles
        [HttpGet]
        public ActionResult Roles()
        {
            try
            {
                db = new ApplicationDbContext();
                var roles = db.Roles.ToList();
                return View(roles);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Create role // Get View
        [HttpGet]
        public ActionResult CreateRole()
        {
            return View();
        }

        // Create role // Post
        [HttpPost]
        public ActionResult CreateRole(string roleName)
        {
            try
            {
                db = new ApplicationDbContext();
                var role = new IdentityRole();
                role.Name = roleName;
                db.Roles.Add(role);
                db.SaveChanges();
                return PartialView("_PartialRole", db.Roles);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Remove role // Get confirmation view in popup
        [HttpGet]
        public ActionResult RemoveRole(string id)
        {
            try
            {
                ViewBag.RoleId = id;
                db = new ApplicationDbContext();
                var RoleName = db.Roles.Where(a => a.Id == id).Select(a => a.Name).FirstOrDefault();
                ViewBag.RoleName = RoleName;
                return View();
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Remove role // Post
        [HttpPost]
        public ActionResult RemoveRolePost(string RoleId)
        {
            try
            {
                db = new ApplicationDbContext();
                var role = db.Roles.Where(a => a.Id == RoleId).FirstOrDefault();
                db.Roles.Remove(role);
                db.SaveChanges();

                return PartialView("_PartialRole", db.Roles);
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Add user to role // Get view in popup
        [HttpGet]
        public ActionResult AddUserToRole(string id)
        {
            try
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
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Add user to role // Post
        [HttpPost]
        public ActionResult AddUserToRole(string[] UsersIds, string RoleId)
        {
            try
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
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Remove user from role // Get confirmation view in popup
        [HttpGet]
        public ActionResult RemoveUserFromRole(string id)
        {
            try
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
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Remove user from role // Post
        [HttpPost]
        public ActionResult RemoveUserFromRole(string[] UsersIds, string RoleId)
        {
            try
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
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Get Users in role // Get view in popup
        [HttpGet]
        public ActionResult GetUsersInRole(string Id)
        {
            try
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
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        // Logoff // Get
        public ActionResult LogOff()
        {
            try
            {
                AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
                // WebSecurity.Logout();
                Session.Clear();
                Session.Abandon();
                FormsAuthentication.SignOut();
                var test = Request.IsAuthenticated;
                return RedirectToAction("Index", "Home");
            }
            catch (Exception ex)
            {
                return RedirectToAction("Error", "Home", new { area = "" });
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_userManager != null)
                {
                    _userManager.Dispose();
                    _userManager = null;
                }
                if (_signInManager != null)
                {
                    _signInManager.Dispose();
                    _signInManager = null;
                }
            }
            base.Dispose(disposing);
        }
    }
}