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
    public class QuestionTypesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: QuestionTypes
        public ActionResult Index()
        {
            return View(db.QuestionTypes.ToList());
        }

        // GET: QuestionTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionType questionType = db.QuestionTypes.Find(id);
            if (questionType == null)
            {
                return HttpNotFound();
            }
            return View(questionType);
        }

        // GET: QuestionTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuestionTypes/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,QuestionType1")] QuestionType questionType)
        {
            if (ModelState.IsValid)
            {
                db.QuestionTypes.Add(questionType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(questionType);
        }

        // GET: QuestionTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionType questionType = db.QuestionTypes.Find(id);
            if (questionType == null)
            {
                return HttpNotFound();
            }
            return View(questionType);
        }

        // POST: QuestionTypes/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,QuestionType1")] QuestionType questionType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(questionType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(questionType);
        }

        // GET: QuestionTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QuestionType questionType = db.QuestionTypes.Find(id);
            if (questionType == null)
            {
                return HttpNotFound();
            }
            return View(questionType);
        }

        // POST: QuestionTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            QuestionType questionType = db.QuestionTypes.Find(id);
            db.QuestionTypes.Remove(questionType);
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
