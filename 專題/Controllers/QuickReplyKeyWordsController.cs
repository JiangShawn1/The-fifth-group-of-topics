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
    public class QuickReplyKeyWordsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: QuickReplyKeyWords
        public ActionResult Index()
        {
            var quickReplyKeyWords = db.QuickReplyKeyWords.Include(q => q.QuickReply);
            return View(quickReplyKeyWords.ToList());
        }

        // GET: QuickReplyKeyWords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickReplyKeyWord quickReplyKeyWord = db.QuickReplyKeyWords.Find(id);
            if (quickReplyKeyWord == null)
            {
                return HttpNotFound();
            }
            return View(quickReplyKeyWord);
        }

        // GET: QuickReplyKeyWords/Create
        public ActionResult Create()
        {
            ViewBag.QuickReplyID = new SelectList(db.QuickReplies, "Id", "QuickReplyContent");
            return View();
        }

        // POST: QuickReplyKeyWords/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QuickReplyID,KeyWord")] QuickReplyKeyWord quickReplyKeyWord)
        {
            if (ModelState.IsValid)
            {
                db.QuickReplyKeyWords.Add(quickReplyKeyWord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuickReplyID = new SelectList(db.QuickReplies, "Id", "QuickReplyContent", quickReplyKeyWord.QuickReplyID);
            return View(quickReplyKeyWord);
        }

        // GET: QuickReplyKeyWords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickReplyKeyWord quickReplyKeyWord = db.QuickReplyKeyWords.Find(id);
            if (quickReplyKeyWord == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuickReplyID = new SelectList(db.QuickReplies, "Id", "QuickReplyContent", quickReplyKeyWord.QuickReplyID);
            return View(quickReplyKeyWord);
        }

        // POST: QuickReplyKeyWords/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QuickReplyID,KeyWord")] QuickReplyKeyWord quickReplyKeyWord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(quickReplyKeyWord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuickReplyID = new SelectList(db.QuickReplies, "Id", "QuickReplyContent", quickReplyKeyWord.QuickReplyID);
            return View(quickReplyKeyWord);
        }

        // GET: QuickReplyKeyWords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuickReplyKeyWord quickReplyKeyWord = db.QuickReplyKeyWords.Find(id);
            if (quickReplyKeyWord == null)
            {
                return HttpNotFound();
            }
            return View(quickReplyKeyWord);
        }

        // POST: QuickReplyKeyWords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuickReplyKeyWord quickReplyKeyWord = db.QuickReplyKeyWords.Find(id);
            db.QuickReplyKeyWords.Remove(quickReplyKeyWord);
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
