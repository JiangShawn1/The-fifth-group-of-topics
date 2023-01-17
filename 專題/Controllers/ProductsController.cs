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
using 專題.Models.EFModels.ViewModels;
using System.IO;
using X.PagedList;

namespace 專題.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Products
        public async Task<ActionResult> Index(int? Brand_Id, string ProductName, int pageNumber = 1)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;
            ViewBag.Brands = GetBrands(Brand_Id);
            ViewBag.ProductName = ProductName;
            ViewBag.Brand_Id = Brand_Id;

            IPagedList<Product> pagedData = GetPagedProducts(Brand_Id, ProductName, pageNumber);

            var products = db.Products.Include(p => p.Brand).Include(p => p.Color);
            return View(pagedData);
        }

        private IEnumerable<SelectListItem> GetBrands(int? Brand_Id)
        {
            var items = db.Brands
                .Select(c => new SelectListItem
                { Value = c.Id.ToString(), Text = c.Brand1, Selected = (Brand_Id.HasValue && c.Id == Brand_Id.Value) })
                .ToList()
                .Prepend(new SelectListItem { Value = string.Empty, Text = "請選擇" });

            return items;
        }

        private IPagedList<Product> GetPagedProducts(int? Brand_Id, string ProductName, int pageNumber)
        {
            int pageSize = 10;

            var query = db.Products.Include(x => x.Brand);

            // 若有篩選categoryid
            if (Brand_Id.HasValue) query = query.Where(p => p.Brand.Id == Brand_Id.Value);

            // 若有篩選 productName
            if (string.IsNullOrEmpty(ProductName) == false) query = query.Where(p => p.ProductName.Contains(ProductName));

            query = query.OrderBy(x => x.Id)
                ;

            return query.ToPagedList(pageNumber, pageSize);
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "Brand1");
            ViewBag.Color_Id = new SelectList(db.Colors, "Id", "Color1");
            return View();
        }

        // POST: Products/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Brand_Id,ProductName,ProductIntroduce,Color_Id,Price,ImageUrl")] Product product, HttpPostedFileBase ImageUrl)
        {
            //todo 將圖存到資料夾中

            //todo 將資料寫進資料庫中
            string path = Server.MapPath("/Images/ProductImages");
            string fileName = System.IO.Path.GetFileName(ImageUrl.FileName);
            string fullPath = System.IO.Path.Combine(path, fileName);
            product.ImageUrl = Path.Combine("/Images/ProductImages/", ImageUrl.FileName);

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                await db.SaveChangesAsync();
                ImageUrl.SaveAs(fullPath);
                return RedirectToAction("Index");
            }
            //product.ImageUrl = Path.Combine("Images/ProductImages/", ImageUrl.FileName);
            //if (ModelState.IsValid)
            //{
            //    db.Products.Add(product);
            //    await db.SaveChangesAsync();
            //    return RedirectToAction("Index");
            //}

            ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "Brand1", product.Brand_Id);
            ViewBag.Color_Id = new SelectList(db.Colors, "Id", "Color1", product.Color_Id);
            return View(product);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "Brand1", product.Brand_Id);
            ViewBag.Color_Id = new SelectList(db.Colors, "Id", "Color1", product.Color_Id);
            return View(product);
        }

        // POST: Products/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, HttpPostedFileBase ImageUrl)
        {
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            string oldImagePath = product.ImageUrl;
            if (ImageUrl != null)
            {
                string path = Server.MapPath("/Images/ProductImages");
                string fileName = System.IO.Path.GetFileName(ImageUrl.FileName);
                string fullPath = System.IO.Path.Combine(path, fileName);
                product.ImageUrl = Path.Combine("/Images/ProductImages/", ImageUrl.FileName);
                System.IO.File.Delete(Server.MapPath(oldImagePath));
                if (fullPath != null)
                {
                    db.Entry(product).State = EntityState.Modified;
                    await db.SaveChangesAsync();
                    ImageUrl.SaveAs(fullPath);
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "Brand1", product.Brand_Id);
            ViewBag.Color_Id = new SelectList(db.Colors, "Id", "Color1", product.Color_Id);
            return View(product);
        }
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Brand_Id,ProductName,ProductIntroduce,Color_Id,Price,ImageUrl")] Product product, HttpPostedFileBase ImageUrl)
        //{
        //    string path = Server.MapPath("/Images/ProductImages");
        //    string fileName = System.IO.Path.GetFileName(ImageUrl.FileName);
        //    string fullPath = System.IO.Path.Combine(path, fileName);
        //    product.ImageUrl = Path.Combine("/Images/ProductImages/", ImageUrl.FileName);

        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(product).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        ImageUrl.SaveAs(fullPath);
        //        return RedirectToAction("Index");
        //    }
        //    ViewBag.Brand_Id = new SelectList(db.Brands, "Id", "Brand1", product.Brand_Id);
        //    ViewBag.Color_Id = new SelectList(db.Colors, "Id", "Color1", product.Color_Id);
        //    return View(product);
        //}

        // GET: Products/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = await db.Products.FindAsync(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Product product = await db.Products.FindAsync(id);
            db.Products.Remove(product);
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
