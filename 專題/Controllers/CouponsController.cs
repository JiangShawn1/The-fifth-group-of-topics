using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 專題.Models.EFModels;
using 專題.Models.Infrastructures.Repositories;
using 專題.Models.Services;
using 專題.Models.ViewModels;

namespace 專題.Controllers
{
    public class CouponsController : Controller
    {

        private CouponRepository repository;
		private CouponService couponService;

		public CouponsController()
		{
			var db = new AppDbContext();
			var repo = new CouponRepository(db);
			this.couponService = new CouponService(repo);
		}
		// GET: Coupons
		public ActionResult Index()
        {
			var data = couponService.Search(null, null)
				.Select(x => x.ToVM());

			return View(data);
		}

        // GET: Coupons/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
				service.CreateCoupon(model);

			if (response.IsSuccess)
			{
				// 建檔成功 redirect to confirm page
				return View("Index");
			}
			else
			{
				ModelState.AddModelError(string.Empty, response.ErrorMessage);
				return View(model);
			}
		}

        // GET: Coupons/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Coupons/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Coupons/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Coupons/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
