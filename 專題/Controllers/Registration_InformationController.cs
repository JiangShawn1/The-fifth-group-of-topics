using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 專題.Models.EFModels;
using 專題.Models.Infrastructures.Extensions;
using 專題.Models.ViewModels;

namespace 專題.Controllers
{
    public class Registration_InformationController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Registration_Information
        public ActionResult Index()
        {
            var registration_Information = db.Registration_Information.Include(r => r.Information).Include(r => r.Registration);
            return View(registration_Information.ToList());
        }

        // GET: Registration_Information/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration_Information registration_Information = db.Registration_Information.Find(id);
            if (registration_Information == null)
            {
                return HttpNotFound();
            }
            return View(registration_Information);
        }

        // GET: Registration_Information/Create
        public ActionResult Create()
        {
            ViewBag.MemberID = new SelectList(db.Members, "Members_Id", "Name");
			List<SelectListItem> CategoryDropDownList = new List<SelectListItem>();
			foreach (var item in db.Contest_Category)
			{
				var categoriesRow = new SelectListItem
				{
					Value = item.Id.ToString(),
					Text = item.Contest.Name + " " + item.Category.Category1 + item.Category.Distance+"K",
				};
				CategoryDropDownList.Add(categoriesRow);
			}
			ViewBag.Contest_CategoryID = CategoryDropDownList;
			ViewBag.InformationID = new SelectList(db.Information, "Id", "Name");
            ViewBag.RegistrationID = new SelectList(db.Registrations, "Id", "Id");
            return View();
        }

        // POST: Registration_Information/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Registration_InformationCreateVM registration_Information)
        {
            if (ModelState.IsValid)
            {
                db.Registration_Information.Add(registration_Information.ToRI());
                db.Registrations.Add(registration_Information.ToRe());
                db.Information.Add(registration_Information.ToIn());
                db.SaveChanges();
                return RedirectToAction("Index");
            }
					
            return View(registration_Information);
        }

        // GET: Registration_Information/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration_Information registration_Information = db.Registration_Information.Find(id);
			Registration registration=db.Registrations.Where(c=>c.Id== registration_Information.RegistrationID).FirstOrDefault();
			Information information=db.Information.Where(c=>c.Id== registration_Information.InformationID).FirstOrDefault();
            Registration_InformationEditVM edVM = registration_Information.ToRIEditVM(registration, information);

			if (registration_Information == null)
            {
                return HttpNotFound();
            }
			ViewBag.MemberID = new SelectList(db.Members, "Members_Id", "Name");
			List<SelectListItem> CategoryDropDownList = new List<SelectListItem>();
			foreach (var item in db.Contest_Category)
			{
				var categoriesRow = new SelectListItem
				{
					Value = item.Id.ToString(),
					Text = item.Contest.Name + " " + item.Category.Category1 + item.Category.Distance + "K",
				};
				CategoryDropDownList.Add(categoriesRow);
			}
			ViewBag.Contest_CategoryID = CategoryDropDownList;
			ViewBag.InformationID = new SelectList(db.Information, "Id", "Name", registration_Information.InformationID);
            ViewBag.RegistrationID = new SelectList(db.Registrations, "Id", "Id", registration_Information.RegistrationID);
            return View(edVM);
        }

        // POST: Registration_Information/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Registration_InformationEditVM registration_Information)
        {
            if (ModelState.IsValid)
            {
                var ri = registration_Information.ToRIE();
                var re = registration_Information.ToReE();
				var inf = registration_Information.ToInE();

				db.Entry(registration_Information.ToRIE()).State = EntityState.Modified;
				db.Entry(registration_Information.ToReE()).State = EntityState.Modified;
				db.Entry(registration_Information.ToInE()).State = EntityState.Modified;


				db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.InformationID = new SelectList(db.Information, "Id", "Name", registration_Information.InformationID);
            //ViewBag.RegistrationID = new SelectList(db.Registrations, "Id", "Id", registration_Information.RegistrationID);
            return View(registration_Information);
        }

        // GET: Registration_Information/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Registration_Information registration_Information = db.Registration_Information.Find(id);
            if (registration_Information == null)
            {
                return HttpNotFound();
            }
            return View(registration_Information);
        }

        // POST: Registration_Information/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Registration_Information registration_Information = db.Registration_Information.Find(id);
            db.Registration_Information.Remove(registration_Information);
            db.SaveChanges();
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
