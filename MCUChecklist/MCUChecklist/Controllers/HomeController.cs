using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MCUChecklist.Models;
using MCUChecklist.Helpers;
using System.Web.Security;

namespace MCUChecklist.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (!SiteHelper.CheckIfSessionExpired(Request))
            {
                return RedirectToAction("AuthHomepage", "Account");
            }
            else
            {
                List<Film> films = FilmDataHelper.GetFilms();
                return View(new TilesModel() { Films = films });
            }
        }
    }
}