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
    public class CustomerFeedbacksController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: CustomerFeedbacks
        public ActionResult Index()
        {
            var customerFeedbacks = db.CustomerFeedbacks.Include(c => c.QuestionType);
            return View(customerFeedbacks.ToList());
        }

        // GET: CustomerFeedbacks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerFeedback customerFeedback = db.CustomerFeedbacks.Find(id);
            if (customerFeedback == null)
            {
                return HttpNotFound();
            }
            return View(customerFeedback);
        }

        // GET: CustomerFeedbacks/Create
        public ActionResult Create()
        {
            ViewBag.QuestionTypeId = new SelectList(db.QuestionTypes, "Id", "QuestionType1");
            return View();
        }

        // POST: CustomerFeedbacks/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FeedbackContent,CustomerName,Email,QuestionTypeId,Status,CreateTime")] CustomerFeedback customerFeedback)
        {
            if (ModelState.IsValid)
            {
                db.CustomerFeedbacks.Add(customerFeedback);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionTypeId = new SelectList(db.QuestionTypes, "Id", "QuestionType1", customerFeedback.QuestionTypeId);
            return View(customerFeedback);
        }

        // GET: CustomerFeedbacks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerFeedback customerFeedback = db.CustomerFeedbacks.Find(id);
            if (customerFeedback == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionTypeId = new SelectList(db.QuestionTypes, "Id", "QuestionType1", customerFeedback.QuestionTypeId);
            return View(customerFeedback);
        }

        // POST: CustomerFeedbacks/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FeedbackContent,CustomerName,Email,QuestionTypeId,Status,CreateTime")] CustomerFeedback customerFeedback)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customerFeedback).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionTypeId = new SelectList(db.QuestionTypes, "Id", "QuestionType1", customerFeedback.QuestionTypeId);
            return View(customerFeedback);
        }

        // GET: CustomerFeedbacks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerFeedback customerFeedback = db.CustomerFeedbacks.Find(id);
            if (customerFeedback == null)
            {
                return HttpNotFound();
            }
            return View(customerFeedback);
        }

        // POST: CustomerFeedbacks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomerFeedback customerFeedback = db.CustomerFeedbacks.Find(id);
            db.CustomerFeedbacks.Remove(customerFeedback);
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
