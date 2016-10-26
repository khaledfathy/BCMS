using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using BCMS.Models;
using System.Web.Security;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BCMS.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private ApplicationSignInManager _signInManager;
        private ApplicationUserManager _userManager;

        public AccountController()
        {
        }

        public AccountController(ApplicationUserManager userManager, ApplicationSignInManager signInManager)
        {
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public ApplicationSignInManager SignInManager
        {
            get
            {
                return _signInManager ?? HttpContext.GetOwinContext().Get<ApplicationSignInManager>();
            }
            private set
            {
                _signInManager = value;
            }
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        //
        // GET: /Account/Login
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> LoginChecker(LoginViewModel model, string returnUrl)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            if (!ModelState.IsValid)
            {
                return Json("InvalidLogin", JsonRequestBehavior.AllowGet);
            }
            var user = await UserManager.FindByEmailAsync(model.Email);
            if (user != null)
            {
                var UserConnection = db.Connections.Where(a => a.UserId == user.Id).FirstOrDefault();
                if (UserConnection != null)
                {
                    return Json("Connected", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    if(user.EmailConfirmed)
                    {
                        switch (user.UserStatus)
                        {
                            case UserStatus.Active:
                                return Json("Active", JsonRequestBehavior.AllowGet);
                            case UserStatus.Pending:
                                return Json("Waiting", JsonRequestBehavior.AllowGet);
                            case UserStatus.Waiting:
                                return Json("Waiting", JsonRequestBehavior.AllowGet);
                        }
                    }
                    else
                    {
                        return Json("NotConfirmed", JsonRequestBehavior.AllowGet);
                    }
                }
            }
            else
            {
                return Json("ErrorInUserNameOrPassword", JsonRequestBehavior.AllowGet);
            }
            return View();
        }

        //
        // POST: /Account/Login
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            var user = await UserManager.FindByEmailAsync(model.Email);

            var result = await SignInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, shouldLockout: false);
            switch (result)
            {

                case SignInStatus.Success:
                    HttpCookie cookie = new HttpCookie("SessionID", Session.SessionID);
                    cookie.Path = "/";
                    Response.Cookies.Add(cookie);
                    if (returnUrl != null)
                    {
                        return Json(returnUrl, JsonRequestBehavior.AllowGet);
                    }
                    else if (IsAdminUser(user.Id))
                        return Json("Admin", JsonRequestBehavior.AllowGet);
                    return Json("Active", JsonRequestBehavior.AllowGet);
                case SignInStatus.Failure:
                default:
                    return Json("PasswordError", JsonRequestBehavior.AllowGet);
            }
        }

        //
        // POST: /Account/Register
        [HttpPost]
        [AllowAnonymous]
        public async Task<JsonResult> Register(RegisterViewModel model, string language)
        {
            string message = "";
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    FirstName = model.FirstName,
                    MiddleName = model.MiddleName,
                    LastName = model.LastName,
                    UserName = model.Email,
                    Email = model.Email,
                    UserStatus = UserStatus.Waiting
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (language == "en")
                    {
                        string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code, lang = language }, protocol: Request.Url.Scheme);
                        string body = "<div dir='ltr'><h1>Welcome in Borsa Capital</h1><h3>You have done an account in Borsa Capital";
                        body += " and your password is " + model.Password + ".</h3>";
                        body += "<h3>To confirm your account please click <a href=\"" + callbackUrl + "\"><i>here</i></a></b></div>";
                        string msg = EmailVerification.SendEMail(model.Email, "Borsa Capital", body);
                    }
                    else
                    {
                        string code = await UserManager.GenerateEmailConfirmationTokenAsync(user.Id);
                        var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code, lang = language }, protocol: Request.Url.Scheme);
                        string body = "<div dir='rtl'><h1>مرحبا بك فى بورصه كابيتال</h1><h3>لقد قمت بعمل حساب على بورصه كابيتال";
                        body += "وكلمة المرور الخاصة بك هى ";
                        body += model.Password + ".</h3>";
                        body += "<h3>لتأكيد الحساب من فضلك اضغط <a href=\"" + callbackUrl + "\"><i>هنـــا</i></a></h3></div>";
                        string msg = EmailVerification.SendEMail(model.Email, "Borsa Capital", body);
                    }
                    message = "Success";
                }
                else
                {
                    AddErrors(result);
                    message = "EmailAlreadyToken";
                }
            }
            else
            {
                message = "InvalidPassword";
            }
            return new JsonResult { Data = message, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        //
        // GET: /Account/ConfirmEmail
        [AllowAnonymous]
        public async Task<ActionResult> ConfirmEmail(string userId, string code, string lang)
        {
            var user = await UserManager.FindByIdAsync(userId);
            ViewBag.name = user.FirstName;
            if (lang == "en")
            {
                if (userId == null || code == null)
                {
                    return View("ErrorEn");
                }
                var result = await UserManager.ConfirmEmailAsync(userId, code);
                return View(result.Succeeded ? "ConfirmEmailEn" : "ErrorEn");
            }
            else
            {
                if (userId == null || code == null)
                {
                    return View("ErrorAr");
                }
                var result = await UserManager.ConfirmEmailAsync(userId, code);
                return View(result.Succeeded ? "ConfirmEmailAr" : "ErrorAr");
            }
        }

        [HttpPost]
        [AllowAnonymous]
        //[ValidateAntiForgeryToken]
        public async Task<ActionResult> SendCode(string UserId, string language)
        {
            if (language == "en")
            {
                string code = await UserManager.GenerateEmailConfirmationTokenAsync(UserId);
                var user = await UserManager.FindByIdAsync(UserId);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = UserId, code = code }, protocol: Request.Url.Scheme);
                string body = "<div dir='ltr'><h1>Welcome in Borsa Capital<h1/>";
                body += "<h2>In order to confirm your account please click <a href=\"" + callbackUrl + "\"><i>here</i></a></h2></div>";
                string msg = EmailVerification.SendEMail(user.Email, "Borsa Capital", body);
                ViewBag.name = user.FirstName;
            }
            else
            {
                string code = await UserManager.GenerateEmailConfirmationTokenAsync(UserId);
                var user = await UserManager.FindByIdAsync(UserId);
                var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = UserId, code = code }, protocol: Request.Url.Scheme);
                string body = "<div dir='rtl'><h1>مرحبا بك فى بورصة كابيتال</h1>";
                body += "<h2>لتأكيد الحساب من فضلك اضغط<a href=\"" + callbackUrl + "\"><i> هنــا.</i></a></h2></div>";
                string msg = EmailVerification.SendEMail(user.Email, "Borsa Capital", body);
                ViewBag.name = user.FirstName;
            }

            return Json("success", JsonRequestBehavior.AllowGet);
        }

       // [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
       
            Session.Clear();
            Session.Abandon();

            if(HttpContext.Request.Cookies["SessionID"]!=null)
            {
                var c = new HttpCookie("SessionID");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }
                       
            FormsAuthentication.SignOut(); 
         
            return RedirectToAction("Index", "Home");
        }

        #region Forgot and Reset Password

        // POST: /Account/ForgotPassword
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await UserManager.FindByNameAsync(model.Email);
                if (user == null)
                {
                    // Don't reveal that the user does not exist or is not confirmed
                    return Json("InvalidUser", JsonRequestBehavior.AllowGet);
                    //return View("ForgotPasswordConfirmation");
                }
                else if (!(await UserManager.IsEmailConfirmedAsync(user.Id)))
                {
                    return Json("NotConfirmed", JsonRequestBehavior.AllowGet);
                }

                string code = await UserManager.GeneratePasswordResetTokenAsync(user.Id);
                var callbackUrl = Url.Action("ResetPassword", "Account", new { userId = user.Id, code = code }, protocol: Request.Url.Scheme);
                string body = "<b>لإعادة تعيين كلمة المرور من فضلك اضغط  <a href=\"" + callbackUrl + "\"><b>هـنــــا</b></a> </b><br/>";
                string msg = EmailVerification.SendEMail(model.Email, "Borsa Capital", body);
                return Json("EmailSent", JsonRequestBehavior.AllowGet);
                //return RedirectToAction("ForgotPasswordConfirmation", "Account");
            }
            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ResetPassword
        [AllowAnonymous]
        public ActionResult ResetPassword(string code)
        {
            ViewBag.code = code;
            return code == null ? View("Error") : View();
        }

        //
        // POST: /Account/ResetPassword
        [HttpPost]
        [AllowAnonymous]

        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await UserManager.FindByNameAsync(model.Email);
            if (user == null)
            {
                // Don't reveal that the user does not exist
                //return RedirectToAction("ResetPasswordConfirmation", "Account");
                return Json("InvalidUser", JsonRequestBehavior.AllowGet);
            }
            var result = await UserManager.ResetPasswordAsync(user.Id, model.Code, model.Password);
            if (result.Succeeded)
            {
                return Json("Success", JsonRequestBehavior.AllowGet);
                //return RedirectToAction("ResetPasswordConfirmation", "Account");
            }
            AddErrors(result);
            return View();
        }



        #endregion

        #region Send Code

        //
        // GET: /Account/SendCode
        //[AllowAnonymous]
        //public async Task<ActionResult> SendCode(string returnUrl, bool rememberMe, string UserId)
        //{
        //    //var userId = await SignInManager.GetVerifiedUserIdAsync();
        //    if (UserId == null)
        //    {
        //        return View("Error");
        //    }

        //    return View();
        //    //var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(UserId);
        //    //var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
        //    //return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });

        //}

        //[AllowAnonymous]
        //public ActionResult SendCode(string returnUrl, string UserId)
        //{
        //    //var userId = await SignInManager.GetVerifiedUserIdAsync();
        //    if (UserId == null)
        //    {
        //        return View("Error");
        //    }
        //    ViewBag.userId = UserId;

        //    return View();
        //    //var userFactors = await UserManager.GetValidTwoFactorProvidersAsync(UserId);
        //    //var factorOptions = userFactors.Select(purpose => new SelectListItem { Text = purpose, Value = purpose }).ToList();
        //    //return View(new SendCodeViewModel { Providers = factorOptions, ReturnUrl = returnUrl, RememberMe = rememberMe });

        //}

        //
        // POST: /Account/SendCode
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> SendCode(SendCodeViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View();
        //    }

        //    // Generate the token and send it
        //    if (!await SignInManager.SendTwoFactorCodeAsync(model.SelectedProvider))
        //    {
        //        return View("Error");
        //    }
        //    return RedirectToAction("VerifyCode", new { Provider = model.SelectedProvider, ReturnUrl = model.ReturnUrl, RememberMe = model.RememberMe });
        //}

        #endregion

        #region Verify Code

        ////
        //// GET: /Account/VerifyCode
        //[AllowAnonymous]
        //public async Task<ActionResult> VerifyCode(string provider, string returnUrl, bool rememberMe)
        //{
        //    // Require that the user has already logged in via username/password or external login
        //    if (!await SignInManager.HasBeenVerifiedAsync())
        //    {
        //        return View("Error");
        //    }
        //    return View(new VerifyCodeViewModel { Provider = provider, ReturnUrl = returnUrl, RememberMe = rememberMe });
        //}

        ////
        //// POST: /Account/VerifyCode
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> VerifyCode(VerifyCodeViewModel model)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return View(model);
        //    }

        //    // The following code protects for brute force attacks against the two factor codes. 
        //    // If a user enters incorrect codes for a specified amount of time then the user account 
        //    // will be locked out for a specified amount of time. 
        //    // You can configure the account lockout settings in IdentityConfig
        //    var result = await SignInManager.TwoFactorSignInAsync(model.Provider, model.Code, isPersistent: model.RememberMe, rememberBrowser: model.RememberBrowser);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            return RedirectToLocal(model.ReturnUrl);
        //        case SignInStatus.LockedOut:
        //            return View("Lockout");
        //        case SignInStatus.Failure:
        //        default:
        //            ModelState.AddModelError("", "Invalid code.");
        //            return View(model);
        //    }
        //}


        #endregion

        #region External Login

        ////
        //// POST: /Account/ExternalLogin
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public ActionResult ExternalLogin(string provider, string returnUrl)
        //{
        //    // Request a redirect to the external login provider
        //    return new ChallengeResult(provider, Url.Action("ExternalLoginCallback", "Account", new { ReturnUrl = returnUrl }));
        //}


        ////
        //// GET: /Account/ExternalLoginCallback
        //[AllowAnonymous]
        //public async Task<ActionResult> ExternalLoginCallback(string returnUrl)
        //{
        //    var loginInfo = await AuthenticationManager.GetExternalLoginInfoAsync();
        //    if (loginInfo == null)
        //    {
        //        return RedirectToAction("Login");
        //    }

        //    // Sign in the user with this external login provider if the user already has a login
        //    var result = await SignInManager.ExternalSignInAsync(loginInfo, isPersistent: false);
        //    switch (result)
        //    {
        //        case SignInStatus.Success:
        //            return RedirectToLocal(returnUrl);
        //        case SignInStatus.LockedOut:
        //            return View("Lockout");
        //        case SignInStatus.RequiresVerification:
        //            return RedirectToAction("SendCode", new { ReturnUrl = returnUrl, RememberMe = false });
        //        case SignInStatus.Failure:
        //        default:
        //            // If the user does not have an account, then prompt the user to create an account
        //            ViewBag.ReturnUrl = returnUrl;
        //            ViewBag.LoginProvider = loginInfo.Login.LoginProvider;
        //            return View("ExternalLoginConfirmation", new ExternalLoginConfirmationViewModel { Email = loginInfo.Email });
        //    }
        //}

        ////
        //// POST: /Account/ExternalLoginConfirmation
        //[HttpPost]
        //[AllowAnonymous]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> ExternalLoginConfirmation(ExternalLoginConfirmationViewModel model, string returnUrl)
        //{
        //    if (User.Identity.IsAuthenticated)
        //    {
        //        return RedirectToAction("Index", "Manage");
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        // Get the information about the user from the external login provider
        //        var info = await AuthenticationManager.GetExternalLoginInfoAsync();
        //        if (info == null)
        //        {
        //            return View("ExternalLoginFailure");
        //        }
        //        var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //        var result = await UserManager.CreateAsync(user);
        //        if (result.Succeeded)
        //        {
        //            result = await UserManager.AddLoginAsync(user.Id, info.Login);
        //            if (result.Succeeded)
        //            {
        //                await SignInManager.SignInAsync(user, isPersistent: false, rememberBrowser: false);
        //                return RedirectToLocal(returnUrl);
        //            }
        //        }
        //        AddErrors(result);
        //    }

        //    ViewBag.ReturnUrl = returnUrl;
        //    return View(model);
        //}

        ////
        //// POST: /Account/LogOff


        ////
        //// GET: /Account/ExternalLoginFailure
        //[AllowAnonymous]
        //public ActionResult ExternalLoginFailure()
        //{
        //    return View();
        //}

        #endregion
        public Boolean IsAdminUser(string UserId)
        {
            ApplicationDbContext context = new ApplicationDbContext();
            var user = context.Users.Where(a => a.Id == UserId).Select(a => a.Roles).FirstOrDefault();
            if (user.Count == 0)
            {
                return false;
            }
            else
            {
                foreach (var item in user)
                {
                    var RoleName = context.Roles.Where(a => a.Id == item.RoleId).Select(a => a.Name).FirstOrDefault();
                    if (RoleName == "Admin")
                    {
                        return true;
                    }
                }
                return false;
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

        #region Helpers
        // Used for XSRF protection when adding external logins
        private const string XsrfKey = "XsrfId";

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }

        internal class ChallengeResult : HttpUnauthorizedResult
        {
            public ChallengeResult(string provider, string redirectUri)
                : this(provider, redirectUri, null)
            {
            }

            public ChallengeResult(string provider, string redirectUri, string userId)
            {
                LoginProvider = provider;
                RedirectUri = redirectUri;
                UserId = userId;
            }

            public string LoginProvider { get; set; }
            public string RedirectUri { get; set; }
            public string UserId { get; set; }

            public override void ExecuteResult(ControllerContext context)
            {
                var properties = new AuthenticationProperties { RedirectUri = RedirectUri };
                if (UserId != null)
                {
                    properties.Dictionary[XsrfKey] = UserId;
                }
                context.HttpContext.GetOwinContext().Authentication.Challenge(properties, LoginProvider);
            }
        }
        #endregion
    }
}