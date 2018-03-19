using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCUChecklist.Helpers;
using MCUChecklist.Models;
using System.Web.Security;

namespace MCUChecklist.Controllers
{
    public class AccountController : Controller
    {
        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(Register registerModel)
        {
            User user = AccountHelper.AddUser(registerModel);

            if(user.LoginMessage == "Success")
            {
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddDays(1), true, "", "/");
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                Response.Cookies.Add(cookie);

                return RedirectToAction("AuthHomepage", user);
            }

            return RedirectToAction("Index", "Home");
        }

        public ActionResult Login()
        {
            return View();
        }

        public ActionResult Logout()
        {
            if(!SiteHelper.CheckIfSessionExpired(Request)) {
                var c = new HttpCookie(".ASPXAUTH");
                c.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(c);
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult Login(Login loginModel)
        {
            User user = AccountHelper.Login(loginModel);

            if (user.LoginMessage == "Success")
            {
                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, user.Username, DateTime.Now, DateTime.Now.AddDays(1), loginModel.RememberMe, "", "/");
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(authTicket));
                Response.Cookies.Add(cookie);

                return RedirectToAction("AuthHomepage", user);
            }

            if(user.LoginMessage == "Error")
            {

            }

            return RedirectToAction("Index", "Home");
        }

        [Authorize]
        public ActionResult AuthHomepage(User user)
        {         
            if(user.Username == null) {
                if (!SiteHelper.CheckIfSessionExpired(Request))
                {
                    user.Username = FormsAuthentication.Decrypt(Request.Cookies[".ASPXAUTH"].Value).Name;
                }
            }

            user.Films = FilmDataHelper.GetFilms();

            return View(user);
        }
    }
}