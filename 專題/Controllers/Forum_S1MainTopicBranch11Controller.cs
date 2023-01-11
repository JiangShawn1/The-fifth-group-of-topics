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
    public class Forum_S1MainTopicBranch11Controller : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Forum_S1MainTopicBranch11
        public async Task<ActionResult> Index()
        {
            var forum_S1MainTopicBranch1 = db.Forum_S1MainTopicBranch1.Include(f => f.Forum_S1MainTopicsBranch1Thread);
            return View(await forum_S1MainTopicBranch1.ToListAsync());
        }

        // GET: Forum_S1MainTopicBranch11/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_S1MainTopicBranch1 forum_S1MainTopicBranch1 = await db.Forum_S1MainTopicBranch1.FindAsync(id);
            if (forum_S1MainTopicBranch1 == null)
            {
                return HttpNotFound();
            }
            return View(forum_S1MainTopicBranch1);
        }

        // GET: Forum_S1MainTopicBranch11/Create
        public ActionResult Create()
        {
            ViewBag.essayId = new SelectList(db.Forum_S1MainTopicsBranch1Thread, "id", "replyContent");
            return View();
        }

        // POST: Forum_S1MainTopicBranch11/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,boardNameId,essayId,essayTopic,State")] Forum_S1MainTopicBranch1 forum_S1MainTopicBranch1)
        {
            if (ModelState.IsValid)
            {
                db.Forum_S1MainTopicBranch1.Add(forum_S1MainTopicBranch1);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.essayId = new SelectList(db.Forum_S1MainTopicsBranch1Thread, "id", "replyContent", forum_S1MainTopicBranch1.essayId);
            return View(forum_S1MainTopicBranch1);
        }

        // GET: Forum_S1MainTopicBranch11/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_S1MainTopicBranch1 forum_S1MainTopicBranch1 = await db.Forum_S1MainTopicBranch1.FindAsync(id);
            if (forum_S1MainTopicBranch1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.essayId = new SelectList(db.Forum_S1MainTopicsBranch1Thread, "id", "replyContent", forum_S1MainTopicBranch1.essayId);
            return View(forum_S1MainTopicBranch1);
        }

        // POST: Forum_S1MainTopicBranch11/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,boardNameId,essayId,essayTopic,State")] Forum_S1MainTopicBranch1 forum_S1MainTopicBranch1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum_S1MainTopicBranch1).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.essayId = new SelectList(db.Forum_S1MainTopicsBranch1Thread, "id", "replyContent", forum_S1MainTopicBranch1.essayId);
            return View(forum_S1MainTopicBranch1);
        }

        // GET: Forum_S1MainTopicBranch11/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_S1MainTopicBranch1 forum_S1MainTopicBranch1 = await db.Forum_S1MainTopicBranch1.FindAsync(id);
            if (forum_S1MainTopicBranch1 == null)
            {
                return HttpNotFound();
            }
            return View(forum_S1MainTopicBranch1);
        }

        // POST: Forum_S1MainTopicBranch11/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Forum_S1MainTopicBranch1 forum_S1MainTopicBranch1 = await db.Forum_S1MainTopicBranch1.FindAsync(id);
            db.Forum_S1MainTopicBranch1.Remove(forum_S1MainTopicBranch1);
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
