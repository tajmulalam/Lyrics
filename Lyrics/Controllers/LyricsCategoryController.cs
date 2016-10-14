using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Lyrics.Models;

namespace Lyrics.Controllers
{
    public class LyricsCategoryController : Controller
    {
        private LyricsDBEntities db = new LyricsDBEntities();

        //
        // GET: /LyricsCategory/

        public ActionResult Index()
        {
            return View(db.LyricsCategoryTable.ToList());
        }

        //
        // GET: /LyricsCategory/Details/5

        public ActionResult Details(int id = 0)
        {
            LyricsCategoryTable lyricscategorytable = db.LyricsCategoryTable.Find(id);
            if (lyricscategorytable == null)
            {
                return HttpNotFound();
            }
            return View(lyricscategorytable);
        }

        //
        // GET: /LyricsCategory/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /LyricsCategory/Create

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Create(LyricsCategoryTable lyricscategorytable)
        {
            if (ModelState.IsValid)
            {
                db.LyricsCategoryTable.Add(lyricscategorytable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lyricscategorytable);
        }

        //
        // GET: /LyricsCategory/Edit/5

        public ActionResult Edit(int id = 0)
        {
            LyricsCategoryTable lyricscategorytable = db.LyricsCategoryTable.Find(id);
            if (lyricscategorytable == null)
            {
                return HttpNotFound();
            }
            return View(lyricscategorytable);
        }

        //
        // POST: /LyricsCategory/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LyricsCategoryTable lyricscategorytable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lyricscategorytable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lyricscategorytable);
        }

        //
        // GET: /LyricsCategory/Delete/5

        public ActionResult Delete(int id = 0)
        {
            LyricsCategoryTable lyricscategorytable = db.LyricsCategoryTable.Find(id);
            if (lyricscategorytable == null)
            {
                return HttpNotFound();
            }
            return View(lyricscategorytable);
        }

        //
        // POST: /LyricsCategory/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LyricsCategoryTable lyricscategorytable = db.LyricsCategoryTable.Find(id);
            db.LyricsCategoryTable.Remove(lyricscategorytable);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult AddSubCategory(int id)
        {
            return View(db.LyricsCategoryTable.Find(id));
        }
        [HttpPost]
        public ActionResult AddSubCategory(Models.LyricsSubCategoryTable aSubCat)
        {
            db.LyricsSubCategoryTable.Add(aSubCat);
            db.SaveChanges();
            return RedirectToAction("SubCategoryList");
        }

        public ActionResult SubCategoryList()
        {
            return View(db.LyricsSubCategoryTable);
        }

        public ActionResult DeleteSubCategory(int id)
        {
            db.LyricsSubCategoryTable.Remove(db.LyricsSubCategoryTable.Find(id));
            db.SaveChanges();
            return RedirectToAction("SubCategoryList");
        }


        public ActionResult LyricsDetailForCategory(int id)
        {
            return View(db.lyricsTable.Where(i=>i.category_id==id));
        }

        public ActionResult LyricsDetailForSubCategory(int id)
        {
            return View(db.lyricsTable.Where(i=>i.sub_category_id==id));
        }


        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}