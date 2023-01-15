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
    public class AutoReplyKeyWordsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: AutoReplyKeyWords
        public ActionResult Index()
        {
            var autoReplyKeyWords = db.AutoReplyKeyWords.Include(a => a.AutoReply);
            return View(autoReplyKeyWords.ToList());
        }

        // GET: AutoReplyKeyWords/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoReplyKeyWord autoReplyKeyWord = db.AutoReplyKeyWords.Find(id);
            if (autoReplyKeyWord == null)
            {
                return HttpNotFound();
            }
            return View(autoReplyKeyWord);
        }

        // GET: AutoReplyKeyWords/Create
        public ActionResult Create()
        {
            ViewBag.AutoReplyID = new SelectList(db.AutoReplies, "Id", "AutoReplyContent");
            return View();
        }

        // POST: AutoReplyKeyWords/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AutoReplyID,KeyWord")] AutoReplyKeyWord autoReplyKeyWord)
        {
            if (ModelState.IsValid)
            {
                db.AutoReplyKeyWords.Add(autoReplyKeyWord);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutoReplyID = new SelectList(db.AutoReplies, "Id", "AutoReplyContent", autoReplyKeyWord.AutoReplyID);
            return View(autoReplyKeyWord);
        }

        // GET: AutoReplyKeyWords/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoReplyKeyWord autoReplyKeyWord = db.AutoReplyKeyWords.Find(id);
            if (autoReplyKeyWord == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutoReplyID = new SelectList(db.AutoReplies, "Id", "AutoReplyContent", autoReplyKeyWord.AutoReplyID);
            return View(autoReplyKeyWord);
        }

        // POST: AutoReplyKeyWords/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AutoReplyID,KeyWord")] AutoReplyKeyWord autoReplyKeyWord)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoReplyKeyWord).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutoReplyID = new SelectList(db.AutoReplies, "Id", "AutoReplyContent", autoReplyKeyWord.AutoReplyID);
            return View(autoReplyKeyWord);
        }

        // GET: AutoReplyKeyWords/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoReplyKeyWord autoReplyKeyWord = db.AutoReplyKeyWords.Find(id);
            if (autoReplyKeyWord == null)
            {
                return HttpNotFound();
            }
            return View(autoReplyKeyWord);
        }

        // POST: AutoReplyKeyWords/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoReplyKeyWord autoReplyKeyWord = db.AutoReplyKeyWords.Find(id);
            db.AutoReplyKeyWords.Remove(autoReplyKeyWord);
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
