using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 專題.Models.EFModels;

namespace 專題.Controllers
{
    public class AutoRepliesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: AutoReplies
        public ActionResult Index()
        {
            return View(db.AutoReplies.ToList());
        }

        // GET: AutoReplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoReply autoReply = db.AutoReplies.Find(id);
            if (autoReply == null)
            {
                return HttpNotFound();
            }
            return View(autoReply);
        }

        // GET: AutoReplies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AutoReplies/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AutoReplyContent")] AutoReply autoReply)
        {
            if (ModelState.IsValid)
            {
                db.AutoReplies.Add(autoReply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(autoReply);
        }

        // GET: AutoReplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoReply autoReply = db.AutoReplies.Find(id);
            if (autoReply == null)
            {
                return HttpNotFound();
            }
            return View(autoReply);
        }

        // POST: AutoReplies/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AutoReplyContent")] AutoReply autoReply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoReply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(autoReply);
        }

        // GET: AutoReplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoReply autoReply = db.AutoReplies.Find(id);
            if (autoReply == null)
            {
                return HttpNotFound();
            }
            return View(autoReply);
        }

        // POST: AutoReplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoReply autoReply = db.AutoReplies.Find(id);
            db.AutoReplies.Remove(autoReply);
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
