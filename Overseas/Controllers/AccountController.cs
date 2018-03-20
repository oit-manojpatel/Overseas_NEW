using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Web;
using System;
using OITReporting.Models.dbClasses;
using Overseas.Manager.DB;
using Overseas.Common;

namespace Overseas.Controllers
{
    public class AccountController : Controller
    {
        private readonly dbOITReporting db = new dbOITReporting();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Login() => View();

        private const int V = 525600;
        [HttpPost]
        public ActionResult Login(userLogin ul, string retrurnUrl)
        {
            dbOITReporting db = new dbOITReporting();
            #region Check Email Condition
            userMaster objUser = db.userMasters.FirstOrDefault(a => a.emailID.Trim().ToLower() == ul.Email.Trim().ToLower() && a.password == ul.Password);
            if (objUser != null)
            {
                #region Store Cookie
                Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(new FormsAuthenticationTicket(ul.Email, ul.RememberMe, ul.RememberMe ? 525600 : 20)))
                {
                    #region expire cookie
                    Expires = DateTime.Now.AddMinutes(ul.RememberMe ? V : 20),
                    HttpOnly = true
                    #endregion
                });
                #endregion
                #region check allready login or not
                if (Url.IsLocalUrl(retrurnUrl))
                {
                    SessionWrapper sa = new SessionWrapper
                    {
                        UserID = objUser.userId,
                        RoleID = Convert.ToInt32(objUser.RoleId)
                    };
                    return Redirect(retrurnUrl);
                }
                else
                {
                    return RedirectToAction("Dashboard", "Home");
                }
                #endregion
                #endregion
            }
            else
            {
                ModelState.AddModelError("usernameError", "Invalid Username or password!");
                return View("Login");
            }
        }
        [Authorize]
        [HttpPost]
        public ActionResult Logout()
        {
            #region Logout session
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
            #endregion
        }

    }
}