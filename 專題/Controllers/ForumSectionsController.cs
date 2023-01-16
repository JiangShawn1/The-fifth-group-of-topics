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
    public class ForumSectionsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ForumSections
        public async Task<ActionResult> Index()
        {
            return View(await db.ForumSections.ToListAsync());
        }

        // GET: ForumSections/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection forumSection = await db.ForumSections.FindAsync(id);
            if (forumSection == null)
            {
                return HttpNotFound();
            }
            return View(forumSection);
        }

        // GET: ForumSections/Create
        public ActionResult Create()
        {
            return View();
        }

		// POST: ForumSections/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[Authorize]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id,sectionName")] ForumSection forumSection)
        {
            if (ModelState.IsValid)
            {
                db.ForumSections.Add(forumSection);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(forumSection);
        }

        // GET: ForumSections/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection forumSection = await db.ForumSections.FindAsync(id);
            if (forumSection == null)
            {
                return HttpNotFound();
            }
            return View(forumSection);
        }

		// POST: ForumSections/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[Authorize]
		[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id,sectionName")] ForumSection forumSection)
        {
            if (ModelState.IsValid)
            {
                db.Entry(forumSection).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(forumSection);
        }

        // GET: ForumSections/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ForumSection forumSection = await db.ForumSections.FindAsync(id);
            if (forumSection == null)
            {
                return HttpNotFound();
            }
            return View(forumSection);
        }

		// POST: ForumSections/Delete/5

		[Authorize]
		[HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ForumSection forumSection = await db.ForumSections.FindAsync(id);
            db.ForumSections.Remove(forumSection);
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
