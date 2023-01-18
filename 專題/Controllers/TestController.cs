using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using 專題.Models.EFModels;
using X.PagedList;
using Member = 專題.Models.EFModels.Member;

namespace 專題.Controllers
{
    public class TestController : Controller
    {
		private AppDbContext db = new AppDbContext();

		// GET: P110
		public ActionResult Index(int? Member_Id, string Name, int pageNumber = 1)
		{
			pageNumber = pageNumber > 0 ? pageNumber : 1;

			// 將篩選條件放在ViewBag,稍後在 view page取回
			ViewBag.Members= GetPagedMembers(Member_Id);
			ViewBag.Name = Name;
			ViewBag.Member_Id = Member_Id;

			//ViewBag.QueryString = $"CategoryId={categoryId.ToString()}&ProductName={HttpUtility.UrlEncode(productName)}";

			IPagedList<Member> pagedData = GetPagedMembers(Member_Id, Name, pageNumber);

			return View(pagedData);
		}

		private IEnumerable<SelectListItem> GetPagedMembers(int? Member_Id)
		{
			var items = db.Categories
				.Select(c => new SelectListItem
				{ Value = c.Id.ToString(), Text = c.Name, Selected = (Member_Id.HasValue && c.Id == categoryId.Value) })
				.ToList()
				.Prepend(new SelectListItem { Value = string.Empty, Text = "請選擇" });

			return items;
		}

		private IPagedList<Member> GetPagedMembers(int? Member_Id, string Name, int pageNumber)
		{
			int pageSize = 3;

			var query = db.Members.Include(x => x.Category);

			// 若有篩選categoryid
			if (categoryId.HasValue) query = query.Where(p => p.Category.Id == categoryId.Value);

			// 若有篩選 productName
			if (string.IsNullOrEmpty(Name) == false) query = query.Where(p => p.Name.Contains(Name));

			query = query.OrderBy(x => x.Category.DisplayOrder)
				;

			return query.ToPagedList(pageNumber, pageSize);
		}
	}
}