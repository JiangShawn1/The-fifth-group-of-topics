using System;
using System.Collections.Generic;
using System.IO;
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
using static System.Net.WebRequestMethods;

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
        public ActionResult Create(CouponVM model, HttpPostedFileBase file)
        {

			if (!ModelState.IsValid)
			{
				return View(model);
			}


			if (file == null || file.ContentLength == 0)
			{
				model.CouponImage = string.Empty;
			}
			else
			{

				// 儲存圖片到伺服器上
				string path = Server.MapPath("~/Uploads");
				string fileName = Path.GetFileName(file.FileName);

				string newFileName = GetNewFileName(path, fileName);
				
				string fullPath = Path.Combine(path, newFileName);
				try
				{
					file.SaveAs(fullPath);
					model.CouponImage = newFileName;
				}
				catch(Exception ex)
				{
					ModelState.AddModelError(string.Empty, "上傳檔案失敗: " + ex.Message);
					return View(model);
				}


				//var fileName = Path.GetFileName(file.FileName);
				//var path = Path.Combine(Server.MapPath("~/Uploads"), fileName);
				//file.SaveAs(path);
				//model.CouponImage = path;
			}

			

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

		private string GetNewFileName(string path, string fileName)
		{
			string ext = Path.GetExtension(fileName);
			string newFileName = string.Empty;
			string fullPath = string.Empty;

			do
			{
				newFileName = Guid.NewGuid().ToString("N") + ext;
				fullPath = Path.Combine(path, newFileName);

			} while (System.IO.File.Exists(fullPath)==true);
			return newFileName;
		}

		// GET: Coupons/Edit/5
		public ActionResult Edit(int? id)
        {
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
            var coupon = repository.Find((int)id);

			ViewBag.ImageUrl = coupon.CouponImage;
			return View(coupon.ToVM());
		}

        // POST: Coupons/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CouponVM model, HttpPostedFileBase file)
        {
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			if (file != null || file.ContentLength > 0)
			{
				// 儲存圖片到伺服器上
				string path = Server.MapPath("~/Uploads");
				string fileName = Path.GetFileName(file.FileName);
				string newFileName = GetNewFileName(path, fileName);
				string fullPath = Path.Combine(path, newFileName);
				try
				{
					file.SaveAs(fullPath);
					model.CouponImage = newFileName;
				}
				catch (Exception ex)
				{
					ModelState.AddModelError(string.Empty, "上傳檔案失敗: " + ex.Message);
					return View(model);
				}
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
