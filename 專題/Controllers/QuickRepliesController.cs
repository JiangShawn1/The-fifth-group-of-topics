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
    public class QuickRepliesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: QuickReplies
        public ActionResult Index()
        {
            return View(db.QuickReplies.ToList());
        }

        // GET: QuickReplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickReply quickReply = db.QuickReplies.Find(id);
            if (quickReply == null)
            {
                return HttpNotFound();
            }
            return View(quickReply);
        }

        // GET: QuickReplies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuickReplies/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QuickReplyContent")] QuickReply quickReply)
        {
            if (ModelState.IsValid)
            {
                db.QuickReplies.Add(quickReply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(quickReply);
        }

        // GET: QuickReplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickReply quickReply = db.QuickReplies.Find(id);
            if (quickReply == null)
            {
                return HttpNotFound();
            }
            return View(quickReply);
        }

        // POST: QuickReplies/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QuickReplyContent")] QuickReply quickReply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quickReply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(quickReply);
        }

        // GET: QuickReplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickReply quickReply = db.QuickReplies.Find(id);
            if (quickReply == null)
            {
                return HttpNotFound();
            }
            return View(quickReply);
        }

        // POST: QuickReplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuickReply quickReply = db.QuickReplies.Find(id);
            db.QuickReplies.Remove(quickReply);
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
