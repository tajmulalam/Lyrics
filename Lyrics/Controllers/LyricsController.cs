using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XtrWebTools;
namespace Lyrics.Controllers
{
    public class LyricsController : Controller
    {
        //
        // GET: /Lyrics/
     private Lyrics.Models.LyricsDBEntities db = new Models.LyricsDBEntities();


        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetSubCategoryByCategoryID(int id)
        {

            return Json(db.LyricsSubCategoryTable.Where(i => i.category_id == id).Select(i => new { i.sub_category_id, i.sub_category_name }), JsonRequestBehavior.AllowGet);
        }
        public ActionResult CreateLyrics()
        {
            var VM = new ViewModel.LyricsViewModel();
            VM.lyrics = db.lyricsTable;
            VM.lyricsCategory = db.LyricsCategoryTable;
            VM.lyricsSubCategory = db.LyricsSubCategoryTable;
            return View(VM);
        }

        [HttpPost]
        public ActionResult CreateLyrics(Models.lyricsTable aLyric)
        {

            string fileName = "";
            if (Request.Files["files"].FileName!="" && Request.Files["files"].ContentLength>0)
            {
                var photo = Request.Files["files"];
                fileName = photo.FileName.clearFileNameWithUniqueIdentifier();
                photo.SaveAs(Server.MapPath("~/Images/LyricsPhotos/") + fileName);
                aLyric.image = fileName;
            }
            db.lyricsTable.Add(aLyric);
            db.SaveChanges();
            ModelState.Clear();

            var VM = new ViewModel.LyricsViewModel();
            VM.lyrics = db.lyricsTable;
            VM.lyricsCategory = db.LyricsCategoryTable;
            VM.lyricsSubCategory = db.LyricsSubCategoryTable;
            return View(VM);
        }

        public ActionResult LyricsList()
        {
            return View(db.lyricsTable);
        }
       public ActionResult FullDetailForLyrics(int id)
        {
            return View(db.lyricsTable.Find(id));
        }
    }
}
