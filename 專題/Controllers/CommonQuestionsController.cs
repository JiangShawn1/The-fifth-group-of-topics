using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;
using 專題.Models.EFModels;

namespace 專題.Controllers
{
    public class CommonQuestionsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: CommonQuestions
        public ActionResult Index(int? questionTypeId, string question, int pageNumber = 1)
        {

			ViewBag.QuestionTypes = GetFeedbackContent(questionTypeId);
			ViewBag.Question = question;
			var data = db.CommonQuestions.Include(x => x.QuestionType);
			if (questionTypeId.HasValue) data = data.Where(p => p.QuestionType.Id == questionTypeId.Value);
			if (string.IsNullOrEmpty(question) == false) data = data.Where(p => p.Question.Contains(question));
            pageNumber = pageNumber > 0 ? pageNumber : 1;
			int pageSize = 10;
			var query = data.OrderBy(x => x.QuestionType.Id).ToPagedList(pageNumber, pageSize);

			return View(query);
		}
		private IEnumerable<SelectListItem> GetFeedbackContent(int? questionTypeId)
		{
			var items = db.QuestionTypes
				.Select(c => new SelectListItem
				{ Value = c.Id.ToString(), Text = c.QuestionType1, Selected = (questionTypeId.HasValue && c.Id == questionTypeId.Value) })
				.ToList()
				.Prepend(new SelectListItem { Value = string.Empty, Text = "請選擇" });

			return items;
		}

		// GET: CommonQuestions/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommonQuestion commonQuestion = db.CommonQuestions.Find(id);
            if (commonQuestion == null)
            {
                return HttpNotFound();
            }
            return View(commonQuestion);
        }

        // GET: CommonQuestions/Create
        public ActionResult Create()
        {
            ViewBag.QuestionTypeId = new SelectList(db.QuestionTypes, "Id", "QuestionType1");
            return View();
        }

        // POST: CommonQuestions/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Question,QuestionTypeId")] CommonQuestion commonQuestion)
        {
            if (ModelState.IsValid)
            {
                db.CommonQuestions.Add(commonQuestion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.QuestionTypeId = new SelectList(db.QuestionTypes, "Id", "QuestionType1", commonQuestion.QuestionTypeId);
            return View(commonQuestion);
        }

        // GET: CommonQuestions/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommonQuestion commonQuestion = db.CommonQuestions.Find(id);
            if (commonQuestion == null)
            {
                return HttpNotFound();
            }
            ViewBag.QuestionTypeId = new SelectList(db.QuestionTypes, "Id", "QuestionType1", commonQuestion.QuestionTypeId);
            return View(commonQuestion);
        }

        // POST: CommonQuestions/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Question,QuestionTypeId")] CommonQuestion commonQuestion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commonQuestion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionTypeId = new SelectList(db.QuestionTypes, "Id", "QuestionType1", commonQuestion.QuestionTypeId);
            return View(commonQuestion);
        }

        // GET: CommonQuestions/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommonQuestion commonQuestion = db.CommonQuestions.Find(id);
            if (commonQuestion == null)
            {
                return HttpNotFound();
            }
            return View(commonQuestion);
        }

        // POST: CommonQuestions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommonQuestion commonQuestion = db.CommonQuestions.Find(id);
            db.CommonQuestions.Remove(commonQuestion);
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
