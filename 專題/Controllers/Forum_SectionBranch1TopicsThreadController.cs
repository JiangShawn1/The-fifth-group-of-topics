using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 專題.Models.EFModels;

namespace 專題.Controllers
{
    public class Forum_SectionBranch1TopicsThreadController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Forum_SectionBranch1TopicsThread
        public async Task<ActionResult> Index()
        {
            var forum_SectionBranch1TopicsThread = db.Forum_SectionBranch1TopicsThread.Include(f => f.Forum_SectionBranch1Topics).Include(f => f.Member);
            return View(await forum_SectionBranch1TopicsThread.ToListAsync());
        }

        // GET: Forum_SectionBranch1TopicsThread/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread = await db.Forum_SectionBranch1TopicsThread.FindAsync(id);
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
            ViewBag.replyMemberId = new SelectList(db.Members, "Members_Id", "Name");
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
                forum_SectionBranch1TopicsThread.replyNumber = (db.Forum_SectionBranch1TopicsThread.Where(x => x.topicId == 1).Select(x => x.replyNumber).Max())+1;
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
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread = await db.Forum_SectionBranch1TopicsThread.FindAsync(id);
            if (forum_SectionBranch1TopicsThread == null)
            {
                return HttpNotFound();
            }
            ViewBag.topicId = new SelectList(db.Forum_SectionBranch1Topics, "id", "Topic", forum_SectionBranch1TopicsThread.topicId);
            ViewBag.replyMemberId = new SelectList(db.Members, "Members_Id", "Name", forum_SectionBranch1TopicsThread.replyMemberId);
            return View(forum_SectionBranch1TopicsThread);
        }

        // POST: Forum_SectionBranch1TopicsThread/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,topicId,topicState,replyNumber,replyContent,replyTime,replyState,replyMemberId")] Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum_SectionBranch1TopicsThread).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.topicId = new SelectList(db.Forum_SectionBranch1Topics, "id", "Topic", forum_SectionBranch1TopicsThread.topicId);
            ViewBag.replyMemberId = new SelectList(db.Members, "Members_Id", "Name", forum_SectionBranch1TopicsThread.replyMemberId);
            return View(forum_SectionBranch1TopicsThread);
        }

        // GET: Forum_SectionBranch1TopicsThread/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread = await db.Forum_SectionBranch1TopicsThread.FindAsync(id);
            if (forum_SectionBranch1TopicsThread == null)
            {
                return HttpNotFound();
            }
            return View(forum_SectionBranch1TopicsThread);
        }

        // POST: Forum_SectionBranch1TopicsThread/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Forum_SectionBranch1TopicsThread forum_SectionBranch1TopicsThread = await db.Forum_SectionBranch1TopicsThread.FindAsync(id);
            db.Forum_SectionBranch1TopicsThread.Remove(forum_SectionBranch1TopicsThread);
            await db.SaveChangesAsync();
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
