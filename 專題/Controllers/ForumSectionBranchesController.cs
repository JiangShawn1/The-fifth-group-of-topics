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
    public class ForumSectionBranchesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ForumSectionBranches
        public ActionResult Index()
        {
            var forumSectionBranches = db.ForumSectionBranches.Include(f => f.ForumSection).Include(f => f.Member);
            return View(forumSectionBranches.ToList());
        }

        // GET: ForumSectionBranches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSectionBranch forumSectionBranch = db.ForumSectionBranches.Find(id);
            if (forumSectionBranch == null)
            {
                return HttpNotFound();
            }
            return View(forumSectionBranch);
        }

        // GET: ForumSectionBranches/Create
        public ActionResult Create()
        {
            ViewBag.sectionNameId = new SelectList(db.ForumSections, "id", "sectionName");
            ViewBag.administratorId = new SelectList(db.Members, "Member_Id", "Name");
            return View();
        }

        // POST: ForumSectionBranches/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,sectionNameId,branchName,sectionAdministrator,administratorId")] ForumSectionBranch forumSectionBranch)
        {
            if (ModelState.IsValid)
            {
                db.ForumSectionBranches.Add(forumSectionBranch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.sectionNameId = new SelectList(db.ForumSections, "id", "sectionName", forumSectionBranch.sectionNameId);
            ViewBag.administratorId = new SelectList(db.Members, "Member_Id", "Name", forumSectionBranch.administratorId);
            return View(forumSectionBranch);
        }

        // GET: ForumSectionBranches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSectionBranch forumSectionBranch = db.ForumSectionBranches.Find(id);
            if (forumSectionBranch == null)
            {
                return HttpNotFound();
            }
            ViewBag.sectionNameId = new SelectList(db.ForumSections, "id", "sectionName", forumSectionBranch.sectionNameId);
            ViewBag.administratorId = new SelectList(db.Members, "Member_Id", "Name", forumSectionBranch.administratorId);
            return View(forumSectionBranch);
        }

        // POST: ForumSectionBranches/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,sectionNameId,branchName,sectionAdministrator,administratorId")] ForumSectionBranch forumSectionBranch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumSectionBranch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.sectionNameId = new SelectList(db.ForumSections, "id", "sectionName", forumSectionBranch.sectionNameId);
            ViewBag.administratorId = new SelectList(db.Members, "Member_Id", "Name", forumSectionBranch.administratorId);
            return View(forumSectionBranch);
        }

        // GET: ForumSectionBranches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSectionBranch forumSectionBranch = db.ForumSectionBranches.Find(id);
            if (forumSectionBranch == null)
            {
                return HttpNotFound();
            }
            return View(forumSectionBranch);
        }

        // POST: ForumSectionBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ForumSectionBranch forumSectionBranch = db.ForumSectionBranches.Find(id);
            db.ForumSectionBranches.Remove(forumSectionBranch);
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
