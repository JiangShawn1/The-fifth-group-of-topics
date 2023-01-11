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
    public class Forum_S1MainTopicController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Forum_S1MainTopic
        public async Task<ActionResult> Index()
        {
            var forum_S1MainTopic = db.Forum_S1MainTopic.Include(f => f.Member);
            return View(await forum_S1MainTopic.ToListAsync());
        }

        // GET: Forum_S1MainTopic/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_S1MainTopic forum_S1MainTopic = await db.Forum_S1MainTopic.FindAsync(id);
            if (forum_S1MainTopic == null)
            {
                return HttpNotFound();
            }
            return View(forum_S1MainTopic);
        }

        // GET: Forum_S1MainTopic/Create
        public ActionResult Create()
        {
            ViewBag.boardAdministratorId = new SelectList(db.Members, "Members_Id", "Name");
            return View();
        }

        // POST: Forum_S1MainTopic/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,boardId,boardName,boardAdministrator,boardAdministratorId")] Forum_S1MainTopic forum_S1MainTopic)
        {
            if (ModelState.IsValid)
            {
                db.Forum_S1MainTopic.Add(forum_S1MainTopic);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.boardAdministratorId = new SelectList(db.Members, "Members_Id", "Name", forum_S1MainTopic.boardAdministratorId);
            return View(forum_S1MainTopic);
        }

        // GET: Forum_S1MainTopic/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_S1MainTopic forum_S1MainTopic = await db.Forum_S1MainTopic.FindAsync(id);
            if (forum_S1MainTopic == null)
            {
                return HttpNotFound();
            }
            ViewBag.boardAdministratorId = new SelectList(db.Members, "Members_Id", "Name", forum_S1MainTopic.boardAdministratorId);
            return View(forum_S1MainTopic);
        }

        // POST: Forum_S1MainTopic/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,boardId,boardName,boardAdministrator,boardAdministratorId")] Forum_S1MainTopic forum_S1MainTopic)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum_S1MainTopic).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.boardAdministratorId = new SelectList(db.Members, "Members_Id", "Name", forum_S1MainTopic.boardAdministratorId);
            return View(forum_S1MainTopic);
        }

        // GET: Forum_S1MainTopic/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_S1MainTopic forum_S1MainTopic = await db.Forum_S1MainTopic.FindAsync(id);
            if (forum_S1MainTopic == null)
            {
                return HttpNotFound();
            }
            return View(forum_S1MainTopic);
        }

        // POST: Forum_S1MainTopic/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Forum_S1MainTopic forum_S1MainTopic = await db.Forum_S1MainTopic.FindAsync(id);
            db.Forum_S1MainTopic.Remove(forum_S1MainTopic);
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
