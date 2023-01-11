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
    public class Forum_S1MainTopicsBranch1ThreadController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Forum_S1MainTopicsBranch1Thread
        public async Task<ActionResult> Index()
        {
            var forum_S1MainTopicsBranch1Thread = db.Forum_S1MainTopicsBranch1Thread.Include(f => f.Member);
            return View(await forum_S1MainTopicsBranch1Thread.ToListAsync());
        }

        // GET: Forum_S1MainTopicsBranch1Thread/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_S1MainTopicsBranch1Thread forum_S1MainTopicsBranch1Thread = await db.Forum_S1MainTopicsBranch1Thread.FindAsync(id);
            if (forum_S1MainTopicsBranch1Thread == null)
            {
                return HttpNotFound();
            }
            return View(forum_S1MainTopicsBranch1Thread);
        }

        // GET: Forum_S1MainTopicsBranch1Thread/Create
        public ActionResult Create()
        {
            ViewBag.replyMemberId = new SelectList(db.Members, "Members_Id", "Name");
            return View();
        }

        // POST: Forum_S1MainTopicsBranch1Thread/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,boardId,topicState,replyNumber,replyContent,replyTime,replyState,replyMemberId")] Forum_S1MainTopicsBranch1Thread forum_S1MainTopicsBranch1Thread)
        {
            if (ModelState.IsValid)
            {
                db.Forum_S1MainTopicsBranch1Thread.Add(forum_S1MainTopicsBranch1Thread);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.replyMemberId = new SelectList(db.Members, "Members_Id", "Name", forum_S1MainTopicsBranch1Thread.replyMemberId);
            return View(forum_S1MainTopicsBranch1Thread);
        }

        // GET: Forum_S1MainTopicsBranch1Thread/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_S1MainTopicsBranch1Thread forum_S1MainTopicsBranch1Thread = await db.Forum_S1MainTopicsBranch1Thread.FindAsync(id);
            if (forum_S1MainTopicsBranch1Thread == null)
            {
                return HttpNotFound();
            }
            ViewBag.replyMemberId = new SelectList(db.Members, "Members_Id", "Name", forum_S1MainTopicsBranch1Thread.replyMemberId);
            return View(forum_S1MainTopicsBranch1Thread);
        }

        // POST: Forum_S1MainTopicsBranch1Thread/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,boardId,topicState,replyNumber,replyContent,replyTime,replyState,replyMemberId")] Forum_S1MainTopicsBranch1Thread forum_S1MainTopicsBranch1Thread)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum_S1MainTopicsBranch1Thread).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.replyMemberId = new SelectList(db.Members, "Members_Id", "Name", forum_S1MainTopicsBranch1Thread.replyMemberId);
            return View(forum_S1MainTopicsBranch1Thread);
        }

        // GET: Forum_S1MainTopicsBranch1Thread/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_S1MainTopicsBranch1Thread forum_S1MainTopicsBranch1Thread = await db.Forum_S1MainTopicsBranch1Thread.FindAsync(id);
            if (forum_S1MainTopicsBranch1Thread == null)
            {
                return HttpNotFound();
            }
            return View(forum_S1MainTopicsBranch1Thread);
        }

        // POST: Forum_S1MainTopicsBranch1Thread/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Forum_S1MainTopicsBranch1Thread forum_S1MainTopicsBranch1Thread = await db.Forum_S1MainTopicsBranch1Thread.FindAsync(id);
            db.Forum_S1MainTopicsBranch1Thread.Remove(forum_S1MainTopicsBranch1Thread);
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
