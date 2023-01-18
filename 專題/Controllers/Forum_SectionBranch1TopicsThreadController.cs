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
using System.Threading.Tasks;

namespace 專題.Controllers
{
    public class Forum_SectionBranch1TopicsThreadController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Forum_SectionBranch1TopicsThread
        public ActionResult Index()
        {
            var forum_SectionBranch1TopicsThread = db.Forum_SectionBranch1TopicsThread.Include(f => f.Forum_SectionBranch1Topics).Include(f => f.Member);
            return View(forum_SectionBranch1TopicsThread.ToList());
        }

        // GET: Forum_SectionBranch1TopicsThread/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread = db.Forum_SectionBranch1TopicsThread.Find(id);
            if (forum_SectionBranch1TopicsThread == null)
            {
                return HttpNotFound();
            }
            return View(forum_SectionBranch1TopicsThread);
        }

        // GET: Forum_SectionBranch1TopicsThread/Create
        public ActionResult Create()
        {
            ViewBag.topicId = new SelectList(db.Forum_SectionBranch1Topics, "id", "Topic");
            ViewBag.replyMemberId = new SelectList(db.Members, "Member_Id", "Name");
            return View();
        }

        // POST: Forum_SectionBranch1TopicsThread/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
		public async Task<ActionResult> Create([Bind(Include = "id,topicId,topicState,replyNumber,replyContent,replyTime,replyState,replyMemberId")] Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread)
		{
			if (ModelState.IsValid)
			{
				forum_SectionBranch1TopicsThread.replyTime = DateTime.Now;
				forum_SectionBranch1TopicsThread.topicId = 1;
				forum_SectionBranch1TopicsThread.replyNumber = (db.Forum_SectionBranch1TopicsThread.Where(x => x.topicId == 1).Select(x => x.replyNumber).Max()) + 1;
				forum_SectionBranch1TopicsThread.replyMemberId = 1;
				db.Forum_SectionBranch1TopicsThread.Add(forum_SectionBranch1TopicsThread);
				await db.SaveChangesAsync();
				return RedirectToAction("Index");
			}

			ViewBag.topicId = new SelectList(db.Forum_SectionBranch1Topics, "id", "Topic", forum_SectionBranch1TopicsThread.topicId);
			ViewBag.replyMemberId = new SelectList(db.Members, "Members_Id", "Name", forum_SectionBranch1TopicsThread.replyMemberId);
			return View(forum_SectionBranch1TopicsThread);
		}

		// GET: Forum_SectionBranch1TopicsThread/Edit/5
		public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread = db.Forum_SectionBranch1TopicsThread.Find(id);
            if (forum_SectionBranch1TopicsThread == null)
            {
                return HttpNotFound();
            }
            ViewBag.topicId = new SelectList(db.Forum_SectionBranch1Topics, "id", "Topic", forum_SectionBranch1TopicsThread.topicId);
            ViewBag.replyMemberId = new SelectList(db.Members, "Member_Id", "Name", forum_SectionBranch1TopicsThread.replyMemberId);
            return View(forum_SectionBranch1TopicsThread);
        }

        // POST: Forum_SectionBranch1TopicsThread/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,topicId,topicState,replyNumber,replyContent,replyTime,replyState,replyMemberId")] Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum_SectionBranch1TopicsThread).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.topicId = new SelectList(db.Forum_SectionBranch1Topics, "id", "Topic", forum_SectionBranch1TopicsThread.topicId);
            ViewBag.replyMemberId = new SelectList(db.Members, "Member_Id", "Name", forum_SectionBranch1TopicsThread.replyMemberId);
            return View(forum_SectionBranch1TopicsThread);
        }

        // GET: Forum_SectionBranch1TopicsThread/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread = db.Forum_SectionBranch1TopicsThread.Find(id);
            if (forum_SectionBranch1TopicsThread == null)
            {
                return HttpNotFound();
            }
            return View(forum_SectionBranch1TopicsThread);
        }

        // POST: Forum_SectionBranch1TopicsThread/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread = db.Forum_SectionBranch1TopicsThread.Find(id);
            db.Forum_SectionBranch1TopicsThread.Remove(forum_SectionBranch1TopicsThread);
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
