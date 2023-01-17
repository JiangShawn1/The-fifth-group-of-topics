using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using X.PagedList;
using 專題.Models.EFModels;
using 專題.Models.Infrastructures.Extensions;
using 專題.Models.ViewModels;

namespace 專題.Controllers
{
    public class Registration_InformationController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: Registration_Information
        public ActionResult Index(int? contestId, string informationName, int pageNumber = 1)
        {
            pageNumber = pageNumber > 0 ? pageNumber : 1;

            ViewBag.Contest = GetContests(contestId);
            ViewBag.InformationName = informationName;

            ViewBag.Contest2 = contestId;

            IPagedList<Registration_Information> pagedData = GetPagedRegistration_Information(contestId, informationName, pageNumber);

            return View(pagedData);
        }
        private IEnumerable<SelectListItem> GetContests(int? contestId)
        {
            var items = db.Contests
                .Select(c => new SelectListItem
                { Value = c.Id.ToString(), Text = c.Name, Selected = (contestId.HasValue && c.Id == contestId.Value) })
                .ToList()
                .Prepend(new SelectListItem { Value = string.Empty, Text = "請選擇" });

            return items;
        }

        private IPagedList<Registration_Information> GetPagedRegistration_Information(int? contestId, string informationName, int pageNumber)
        {
            int pageSize = 5;

            var query = db.Registration_Information.Include(r => r.Information).Include(r => r.Registration);

            // 若有篩選categoryid
            if (contestId.HasValue) query = query.Where(p => p.Registration.Contest_Category.ContestID == contestId.Value);

            // 若有篩選 productName
            if (string.IsNullOrEmpty(informationName) == false) query = query.Where(p => p.Information.Name.Contains(informationName));

            query = query.OrderBy(x => x.Registration.Contest_Category.ContestID);

            return query.ToPagedList(pageNumber, pageSize);
        }
        //{
        //    var registration_Information = db.Registration_Information.Include(r => r.Information).Include(r => r.Registration);
        //    return View(registration_Information.ToList());
        //}

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
            ViewBag.MemberID = new SelectList(db.Members, "Member_Id", "Name");
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
            Registration registration = db.Registrations.Where(c => c.Id == registration_Information.RegistrationID).FirstOrDefault();
            Information information = db.Information.Where(c => c.Id == registration_Information.InformationID).FirstOrDefault();
            Registration_InformationEditVM edVM = registration_Information.ToRIEditVM(registration, information);

            if (registration_Information == null)
            {
                return HttpNotFound();
            }

            List<SelectListItem> MemberDropDownList = new List<SelectListItem>();
            foreach (var item in db.Members)
            {
                var MemberRow = new SelectListItem
                {
                    Value = item.Member_Id.ToString(),
                    Text = item.Name,
                };
                MemberDropDownList.Add(MemberRow);
            }
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
            ViewBag.MemberID = MemberDropDownList;
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
