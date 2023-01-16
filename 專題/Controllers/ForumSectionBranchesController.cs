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
    public class ForumSectionBranchesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ForumSectionBranches
        public async Task<ActionResult> Index()
        {
            var forumSectionBranches = db.ForumSectionBranches.Include(f => f.ForumSection).Include(f => f.Member);
            return View(await forumSectionBranches.ToListAsync());
        }

        // GET: ForumSectionBranches/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSectionBranch forumSectionBranch = await db.ForumSectionBranches.FindAsync(id);
            if (forumSectionBranch == null)
            {
                return HttpNotFound();
            }
            return View(forumSectionBranch);
        }

        // GET: ForumSectionBranches/Create
        public ActionResult Create()
        {
            ViewBag.sectionNameId = new SelectList(db.ForumSections, "id", "sectionName");
            ViewBag.administratorId = new SelectList(db.Members, "Members_Id", "Name");
            return View();
        }

		// POST: ForumSectionBranches/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[Authorize]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,sectionNameId,branchName,sectionAdministrator,administratorId")] ForumSectionBranch forumSectionBranch)
        {
            if (ModelState.IsValid)
            {
                db.ForumSectionBranches.Add(forumSectionBranch);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.sectionNameId = new SelectList(db.ForumSections, "id", "sectionName", forumSectionBranch.sectionNameId);
            ViewBag.administratorId = new SelectList(db.Members, "Members_Id", "Name", forumSectionBranch.administratorId);
            return View(forumSectionBranch);
        }

        // GET: ForumSectionBranches/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSectionBranch forumSectionBranch = await db.ForumSectionBranches.FindAsync(id);
            if (forumSectionBranch == null)
            {
                return HttpNotFound();
            }
            ViewBag.sectionNameId = new SelectList(db.ForumSections, "id", "sectionName", forumSectionBranch.sectionNameId);
            ViewBag.administratorId = new SelectList(db.Members, "Members_Id", "Name", forumSectionBranch.administratorId);
            return View(forumSectionBranch);
        }

		// POST: ForumSectionBranches/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。

		[Authorize]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,sectionNameId,branchName,sectionAdministrator,administratorId")] ForumSectionBranch forumSectionBranch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumSectionBranch).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.sectionNameId = new SelectList(db.ForumSections, "id", "sectionName", forumSectionBranch.sectionNameId);
            ViewBag.administratorId = new SelectList(db.Members, "Members_Id", "Name", forumSectionBranch.administratorId);
            return View(forumSectionBranch);
        }

        // GET: ForumSectionBranches/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSectionBranch forumSectionBranch = await db.ForumSectionBranches.FindAsync(id);
            if (forumSectionBranch == null)
            {
                return HttpNotFound();
            }
            return View(forumSectionBranch);
        }

		// POST: ForumSectionBranches/Delete/5
		[Authorize]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ForumSectionBranch forumSectionBranch = await db.ForumSectionBranches.FindAsync(id);
            db.ForumSectionBranches.Remove(forumSectionBranch);
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
