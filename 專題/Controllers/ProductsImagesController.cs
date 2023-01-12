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
    public class ProductsImagesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ProductsImages
        public async Task<ActionResult> Index()
        {
            return View(await db.ProductsImages.ToListAsync());
        }

        // GET: ProductsImages/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsImage productsImage = await db.ProductsImages.FindAsync(id);
            if (productsImage == null)
            {
                return HttpNotFound();
            }
            return View(productsImage);
        }

        // GET: ProductsImages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductsImages/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,ImageUrl")] ProductsImage productsImage)
        {
            if (ModelState.IsValid)
            {
                db.ProductsImages.Add(productsImage);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(productsImage);
        }

        // GET: ProductsImages/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsImage productsImage = await db.ProductsImages.FindAsync(id);
            if (productsImage == null)
            {
                return HttpNotFound();
            }
            return View(productsImage);
        }

        // POST: ProductsImages/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,ImageUrl")] ProductsImage productsImage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productsImage).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(productsImage);
        }

        // GET: ProductsImages/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProductsImage productsImage = await db.ProductsImages.FindAsync(id);
            if (productsImage == null)
            {
                return HttpNotFound();
            }
            return View(productsImage);
        }

        // POST: ProductsImages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ProductsImage productsImage = await db.ProductsImages.FindAsync(id);
            db.ProductsImages.Remove(productsImage);
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
