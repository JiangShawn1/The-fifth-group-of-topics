using PagedList;
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
    public class CommonAnswersController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: CommonAnswers
        public ActionResult Index(int? commonQuestionId, string answer, int pageNumber = 1)
        {
            ViewBag.CommonQuestion = GetCommonQuestion(commonQuestionId);
            ViewBag.Answer = answer;

            var data = db.CommonAnswers.Include(x => x.CommonQuestion);
            if (commonQuestionId.HasValue) data = data.Where(p => p.CommonQuestion.Id == commonQuestionId.Value);
            if (string.IsNullOrEmpty(answer) == false) data = data.Where(p => p.Answer.Contains(answer));
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            int pageSize = 10;
            var query = data.OrderBy(x => x.CommonQuestion.Id).ToPagedList(pageNumber, pageSize);

            return View(query);

            //var commonAnswers = db.CommonAnswers.Include(c => c.CommonQuestion);
            //return View(commonAnswers.ToList());
        }
        private IEnumerable<SelectListItem> GetCommonQuestion(int? commonQuestionId)
        {
            var items = db.CommonQuestions
                .Select(c => new SelectListItem
                { Value = c.Id.ToString(), Text = c.Question, Selected = (commonQuestionId.HasValue && c.Id == commonQuestionId.Value) })
                .ToList()
                .Prepend(new SelectListItem { Value = string.Empty, Text = "請選擇" });

            return items;
        }

        // GET: CommonAnswers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommonAnswer commonAnswer = db.CommonAnswers.Find(id);
            if (commonAnswer == null)
            {
                return HttpNotFound();
            }
            return View(commonAnswer);
        }

        // GET: CommonAnswers/Create
        public ActionResult Create()
        {
            ViewBag.CommonQuestionId = new SelectList(db.CommonQuestions, "Id", "Question");
            return View();
        }

        // POST: CommonAnswers/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CommonQuestionId,Answer")] CommonAnswer commonAnswer)
        {
            if (ModelState.IsValid)
            {
                db.CommonAnswers.Add(commonAnswer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CommonQuestionId = new SelectList(db.CommonQuestions, "Id", "Question", commonAnswer.CommonQuestionId);
            return View(commonAnswer);
        }

        // GET: CommonAnswers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommonAnswer commonAnswer = db.CommonAnswers.Find(id);
            if (commonAnswer == null)
            {
                return HttpNotFound();
            }
            ViewBag.CommonQuestionId = new SelectList(db.CommonQuestions, "Id", "Question", commonAnswer.CommonQuestionId);
            return View(commonAnswer);
        }

        // POST: CommonAnswers/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CommonQuestionId,Answer")] CommonAnswer commonAnswer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(commonAnswer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CommonQuestionId = new SelectList(db.CommonQuestions, "Id", "Question", commonAnswer.CommonQuestionId);
            return View(commonAnswer);
        }

        // GET: CommonAnswers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CommonAnswer commonAnswer = db.CommonAnswers.Find(id);
            if (commonAnswer == null)
            {
                return HttpNotFound();
            }
            return View(commonAnswer);
        }

        // POST: CommonAnswers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CommonAnswer commonAnswer = db.CommonAnswers.Find(id);
            db.CommonAnswers.Remove(commonAnswer);
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
