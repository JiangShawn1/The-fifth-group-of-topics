using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 專題.Models.EFModels;
using 專題.Models;

namespace 專題.Controllers
{
    public class ForumSectionsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ForumSections
        public ActionResult Index()
        {
            return View(db.ForumSections.ToList());
        }

        // GET: ForumSections/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection forumSection = db.ForumSections.Find(id);
            if (forumSection == null)
            {
                return HttpNotFound();
            }
            return View(forumSection);
        }

        // GET: ForumSections/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ForumSections/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,sectionName")] ForumSection forumSection)
        {
            if (ModelState.IsValid)
            {
                db.ForumSections.Add(forumSection);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(forumSection);
        }

        // GET: ForumSections/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection forumSection = db.ForumSections.Find(id);
            if (forumSection == null)
            {
                return HttpNotFound();
            }
            return View(forumSection);
        }

        // POST: ForumSections/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,sectionName")] ForumSection forumSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumSection).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(forumSection);
        }

        // GET: ForumSections/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection forumSection = db.ForumSections.Find(id);
            if (forumSection == null)
            {
                return HttpNotFound();
            }
            return View(forumSection);
        }

        // POST: ForumSections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumSection forumSection = db.ForumSections.Find(id);
            db.ForumSections.Remove(forumSection);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
