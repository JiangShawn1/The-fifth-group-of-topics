using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using 專題.Models.DTOs;
using 專題.Models.EFModels;
using 專題.Models.Infrastructures.Repositories;
using 專題.Models.Services;
using 專題.Models.Services.Interfaces;
using 專題.Models.ViewModels;

namespace 專題.Controllers
{
    public class CouponsController : Controller
    {
        private ICouponRepository repository;
		private CouponService service;

		public CouponsController()
		{
            repository = new CouponRepository();
			service = new CouponService(repository);
		}
		// GET: Coupons
		public ActionResult Index()
        {
			var data = service.Search(null, null, null)
				.Select(x => x.ToVM());

			return View(data);
		}

        // GET: Coupons/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Coupons/Create
        [HttpPost]
        public ActionResult Create(CouponVM model)
        {
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var service = new CouponService(repository);

			(bool IsSuccess, string ErrorMessage) response =
				service.CreateCoupon(model.ToRequestDto());

			if (response.IsSuccess)
			{
				// 建檔成功
				return RedirectToAction("Index");
			}
			else
			{
				ModelState.AddModelError(string.Empty, response.ErrorMessage);
				return View(model);
			}
		}

        // GET: Coupons/Edit/5
        public ActionResult Edit(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
            var coupon = repository.Find((int)id);

			return View(coupon.ToVM());
		}

        // POST: Coupons/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CouponVM model)
        {
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			(bool IsSuccess, string ErrorMessage) response =
				service.EditCoupon(id, model.ToRequestDto());

			if (response.IsSuccess)
			{
				// 修改成功
				return RedirectToAction("Index");
			}
			else
			{
				ModelState.AddModelError(string.Empty, response.ErrorMessage);
				return View(model);
			}
		}

        // GET: Coupons/Delete/5
        public ActionResult Delete(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var coupon = repository.Find((int)id);

			return View(coupon.ToVM());
		}

        // POST: Coupons/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			repository.Delete(id);
			return RedirectToAction("Index");
		}
	}
}
