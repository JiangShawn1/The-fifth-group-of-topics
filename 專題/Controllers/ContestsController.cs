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
	public class ContestsController : Controller
	{
		private AppDbContext db = new AppDbContext();

		// GET: Contests
		public ActionResult Index(int? supplierId, string contestName, int pageNumber = 1)
		{
			pageNumber = pageNumber > 0 ? pageNumber : 1;
			
			ViewBag.Supplier = GetCategories(supplierId);
			ViewBag.ContestName = contestName;

			ViewBag.Supplier2 = supplierId;

			IPagedList<Contest> pagedData = GetPagedContests(supplierId, contestName, pageNumber);

			return View(pagedData);
		}
		private IEnumerable<SelectListItem> GetCategories(int? supplierId)
		{
			var items = db.Suppliers
				.Select(c => new SelectListItem
				{ Value = c.SupplierId.ToString(), Text = c.SupplierName, Selected = (supplierId.HasValue && c.SupplierId == supplierId.Value) })
				.ToList()
				.Prepend(new SelectListItem { Value = string.Empty, Text = "請選擇" });

			return items;
		}

		private IPagedList<Contest> GetPagedContests(int? supplierId, string contestName, int pageNumber)
		{
			int pageSize = 5;

			var query = db.Contests.Include(x => x.Supplier);

			// 若有篩選supplierId
			if (supplierId.HasValue) query = query.Where(p => p.Supplier.SupplierId == supplierId.Value);

			// 若有篩選 productName
			if (string.IsNullOrEmpty(contestName) == false) query = query.Where(p => p.Name.Contains(contestName));

			query = query.OrderBy(x => x.Supplier.SupplierId);

			return query.ToPagedList(pageNumber, pageSize);
		}

		// GET: Contests/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Contest contest = db.Contests.Find(id);
			List<Contest_Category> contest_Category=db.Contest_Category.Where(x=>x.ContestID==id).ToList();
			ContestDetailVM editVM = contest.ToContestDetailVM(contest_Category);


			if (editVM == null)
			{
				return HttpNotFound();
			}
			return View(editVM);
		}

		// GET: Contests/Create
		public ActionResult Create()
		{
			ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierId", "SupplierName");

			List<SelectListItem> CategoryDropDownList = new List<SelectListItem>();
			foreach (var item in db.Categories)
			{
				var categoriesRow = new SelectListItem
				{
					Value = item.Id.ToString(),
					Text = item.Category1 + " " + item.Distance + "K",
				};
				CategoryDropDownList.Add(categoriesRow);
			}
			ViewBag.CategoryIDList = CategoryDropDownList;
			return View();
		}

		// POST: Contests/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create(ContestCreateVM contestCreateRow)
		{
			if (ModelState.IsValid)
			{
				db.Contests.Add(contestCreateRow.ToContest());
				var data = contestCreateRow.ToContest_Category();
				foreach (var item in data)
				{
					db.Contest_Category.Add(item);
				}				
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierId", "SupplierName", contestCreateRow.SupplierID);
			return View(contestCreateRow);
		}

		// GET: Contests/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			ContestEditVM contest = db.Contests.Include("Contest_Category").
				Select(x => new ContestEditVM
				{
					Id = x.Id,
					Name = x.Name,
					SupplierID = x.SupplierID,
					CreateDateTime= x.CreateDateTime,
					ContestDate = x.ContestDate,
					RegistrationDeadline = x.RegistrationDeadline,
					Area = x.Area,
					Location = x.Location,
					MapURL = x.MapURL,
					Contest_CategoryIDList = x.Contest_Category.Where(c => c.ContestID == id).Select(c=>c.Id).ToList(),
					CategoryIDList = x.Contest_Category.Where(c=>c.ContestID == id).Select(c=> c.CategoryID).ToList(),
					QuotaList = x.Contest_Category.Where(c => c.ContestID == id).Select(c => 
					c.Quota).ToList(),
					EnterFeeList = x.Contest_Category.Where(c => c.ContestID == id).Select(c => c.EnterFee).ToList(),
					RegistrationURL = x.RegistrationURL,
					Detail = x.Detail,
					Review = x.Review,
				}).FirstOrDefault(x => x.Id == id);
			List<SelectListItem> CategoryDropDownList = new List<SelectListItem>();
			foreach (var item in db.Categories)
			{
				var categoriesRow = new SelectListItem
				{
					Value = item.Id.ToString(),
					Text = item.Category1 + " " + item.Distance + "K",				
								
				};
			   CategoryDropDownList.Add(categoriesRow);
			}
			ViewBag.CategoryIDList = CategoryDropDownList;					
			if (contest == null)
			{
				return HttpNotFound();
			}			
			return View(contest);
		}

		// POST: Contests/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit(ContestEditVM contestEditRow)
		{
			if (ModelState.IsValid)
			{
				var contest = contestEditRow.ToContestE();
				db.Entry(contest).State = EntityState.Modified;
				var data = contestEditRow.ToContest_CategoryE();
				foreach (var item in data)
				{
					db.Entry(item).State = EntityState.Modified;
				}				
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			ViewBag.SupplierID = new SelectList(db.Suppliers, "SupplierId", "SupplierName", contestEditRow.SupplierID);
			return View(contestEditRow);
		}

		// GET: Contests/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Contest contest = db.Contests.Find(id);
			if (contest == null)
			{
				return HttpNotFound();
			}
			return View(contest);
		}

		// POST: Contests/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Contest contest = db.Contests.Find(id);
			db.Contests.Remove(contest);
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
