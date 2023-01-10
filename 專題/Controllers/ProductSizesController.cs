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
    public class ProductSizesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ProductSizes
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductSizes.ToListAsync());
        }

        // GET: ProductSizes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = await db.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // GET: ProductSizes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductSizes/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Size")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                db.ProductSizes.Add(productSize);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productSize);
        }

        // GET: ProductSizes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = await db.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // POST: ProductSizes/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Size")] ProductSize productSize)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productSize).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productSize);
        }

        // GET: ProductSizes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductSize productSize = await db.ProductSizes.FindAsync(id);
            if (productSize == null)
            {
                return HttpNotFound();
            }
            return View(productSize);
        }

        // POST: ProductSizes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductSize productSize = await db.ProductSizes.FindAsync(id);
            db.ProductSizes.Remove(productSize);
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
