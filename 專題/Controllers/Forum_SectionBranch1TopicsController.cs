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
    public class Forum_SectionBranch1TopicsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Forum_SectionBranch1Topics
        public async Task<ActionResult> Index()
        {
            var forum_SectionBranch1Topics = db.Forum_SectionBranch1Topics.Include(f => f.ForumSectionBranch);
            return View(await forum_SectionBranch1Topics.ToListAsync());
        }

        // GET: Forum_SectionBranch1Topics/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_SectionBranch1Topics forum_SectionBranch1Topics = await db.Forum_SectionBranch1Topics.FindAsync(id);
            if (forum_SectionBranch1Topics == null)
            {
                return HttpNotFound();
            }
            return View(forum_SectionBranch1Topics);
        }

        // GET: Forum_SectionBranch1Topics/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.ForumSectionBranches, "id", "branchName");
            return View();
        }

        // POST: Forum_SectionBranch1Topics/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,BranchId,Topic,State")] Forum_SectionBranch1Topics forum_SectionBranch1Topics)
        {
            if (ModelState.IsValid)
            {
                db.Forum_SectionBranch1Topics.Add(forum_SectionBranch1Topics);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.ForumSectionBranches, "id", "branchName", forum_SectionBranch1Topics.BranchId);
            return View(forum_SectionBranch1Topics);
        }

        // GET: Forum_SectionBranch1Topics/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_SectionBranch1Topics forum_SectionBranch1Topics = await db.Forum_SectionBranch1Topics.FindAsync(id);
            if (forum_SectionBranch1Topics == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.ForumSectionBranches, "id", "branchName", forum_SectionBranch1Topics.BranchId);
            return View(forum_SectionBranch1Topics);
        }

        // POST: Forum_SectionBranch1Topics/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,BranchId,Topic,State")] Forum_SectionBranch1Topics forum_SectionBranch1Topics)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forum_SectionBranch1Topics).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.ForumSectionBranches, "id", "branchName", forum_SectionBranch1Topics.BranchId);
            return View(forum_SectionBranch1Topics);
        }

        // GET: Forum_SectionBranch1Topics/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Forum_SectionBranch1Topics forum_SectionBranch1Topics = await db.Forum_SectionBranch1Topics.FindAsync(id);
            if (forum_SectionBranch1Topics == null)
            {
                return HttpNotFound();
            }
            return View(forum_SectionBranch1Topics);
        }

        // POST: Forum_SectionBranch1Topics/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Forum_SectionBranch1Topics forum_SectionBranch1Topics = await db.Forum_SectionBranch1Topics.FindAsync(id);
            db.Forum_SectionBranch1Topics.Remove(forum_SectionBranch1Topics);
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
