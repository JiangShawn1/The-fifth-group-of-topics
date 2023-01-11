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
    public class ForumSection1Controller : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ForumSection1
        public async Task<ActionResult> Index()
        {
            var forumSection1 = db.ForumSection1.Include(f => f.Member);
            return View(await forumSection1.ToListAsync());
        }

        // GET: ForumSection1/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection1 forumSection1 = await db.ForumSection1.FindAsync(id);
            if (forumSection1 == null)
            {
                return HttpNotFound();
            }
            return View(forumSection1);
        }

        // GET: ForumSection1/Create
        public ActionResult Create()
        {
            ViewBag.administratorId = new SelectList(db.Members, "Members_Id", "Name");
            return View();
        }

        // POST: ForumSection1/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,sectionName,mainBoardAdministrator,mainTopicId,administratorId")] ForumSection1 forumSection1)
        {
            if (ModelState.IsValid)
            {
                db.ForumSection1.Add(forumSection1);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.administratorId = new SelectList(db.Members, "Members_Id", "Name", forumSection1.administratorId);
            return View(forumSection1);
        }

        // GET: ForumSection1/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection1 forumSection1 = await db.ForumSection1.FindAsync(id);
            if (forumSection1 == null)
            {
                return HttpNotFound();
            }
            ViewBag.administratorId = new SelectList(db.Members, "Members_Id", "Name", forumSection1.administratorId);
            return View(forumSection1);
        }

        // POST: ForumSection1/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,sectionName,mainBoardAdministrator,mainTopicId,administratorId")] ForumSection1 forumSection1)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumSection1).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.administratorId = new SelectList(db.Members, "Members_Id", "Name", forumSection1.administratorId);
            return View(forumSection1);
        }

        // GET: ForumSection1/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection1 forumSection1 = await db.ForumSection1.FindAsync(id);
            if (forumSection1 == null)
            {
                return HttpNotFound();
            }
            return View(forumSection1);
        }

        // POST: ForumSection1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ForumSection1 forumSection1 = await db.ForumSection1.FindAsync(id);
            db.ForumSection1.Remove(forumSection1);
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
