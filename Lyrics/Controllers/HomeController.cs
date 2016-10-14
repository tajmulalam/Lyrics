using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lyrics.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private Lyrics.Models.LyricsDBEntities db = new Models.LyricsDBEntities();
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult getCategoryAndSubCategoryList()
        {
            return PartialView("_partialCategoryList", db.LyricsCategoryTable);
        }


        public ActionResult Login(string username,string password)
        {
            if (username=="admin" && password=="lyricsBD")
            {
                Session["lyricsMainSession"] = "SessionActived";
                return RedirectToAction("LyricsList","Lyrics");
            }
            else
            {
                ViewBag.message = "Login Failed";
                return RedirectToAction("Index");

            }
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
