using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 專題.Models.EFModels;
using 專題.Models.Infrastructures.Repositories;
using 專題.Models.Services.Interfaces;
using 專題.Models.Services;
using 專題.Models.ViewModels;

namespace 專題.Controllers
{
    public class OrdersController : Controller
    {
		private IOrderRepository repository;
		private OrderService service;

		public OrdersController()
		{
			repository = new OrderRepository();
			service = new OrderService(repository);
		}
		private AppDbContext db = new AppDbContext();

        // GET: Orders
        public ActionResult Index()
        {
            //var orders = db.Orders.Include(o => o.Coupon);
            //return View(orders.ToList());
             
            var data = service.Search(null, null)
                .Select(x => x.ToVM());

            return View(data);
        }

		// GET: Orders/Details/5
		public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Order order = db.Orders.Find(id);
            if (order == null)
            {
                return HttpNotFound();
            }
            return View(order);
        }

        // GET: Orders/Create
        public ActionResult Create()
        {
            ViewBag.UseCoupon = repository.BindCouponSelectList();

			return View();
        }

        // POST: Orders/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        public ActionResult Create(OrderVM model)
        {
			if (!ModelState.IsValid)
			{
				ViewBag.UseCoupon = repository.BindCouponSelectList(model.UseCoupon);
				return View(model);
			}

			(bool IsSuccess, string ErrorMessage) response =
				service.CreateOrder(model.ToRequestDto());

			if (response.IsSuccess)
			{
				// 建檔成功
				return RedirectToAction("Index");
			}
			else
			{
				ModelState.AddModelError(string.Empty, response.ErrorMessage);
				ViewBag.UseCoupon = repository.BindCouponSelectList(model.UseCoupon);
				return View(model);
			}
		}

        // GET: Orders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var order = repository.Find((int)id);
			ViewBag.UseCoupon = repository.BindCouponSelectList(order.UseCoupon);
			return View(order.ToVM());
        }

        // POST: Orders/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,MemberId,OrderStatus,TradeStatus,UseCoupon,Amount,ShippingMethod,OrderAddress,OrderContent")] int id, OrderVM model)
        {
            if (ModelState.IsValid)
            {
				(bool IsSuccess, string ErrorMessage) response =
				service.EditOrder(id, model.ToRequestDto());

				if (response.IsSuccess)
				{
					// 修改成功
					return RedirectToAction("Index");
				}
				else
				{
					ModelState.AddModelError(string.Empty, response.ErrorMessage);
				}

				//db.Entry(model).State = EntityState.Modified;
				//db.SaveChanges();
				//return RedirectToAction("Index");
			}
            ViewBag.UseCoupon = repository.BindCouponSelectList(model.UseCoupon);
			return View(model);
		}

        // GET: Orders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
			var order = repository.Find((int)id);
			if (order == null)
            {
                return HttpNotFound();
            }
			return View(order.ToVM());
        }

        // POST: Orders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
			repository.Delete(id);
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
