using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using 專題.Models.EFModels;

namespace 專題.Controllers
{
    public class CommonQuestionController : Controller
    {
		private AppDbContext db = new AppDbContext();
		// GET: CommonQuestion
		public ActionResult CommonQuestions()
        {
            return View();
        }
		public ActionResult CommonAnswers()
		{
			return View();
		}
		public ActionResult QuestionTypes(int? QuestionId, string questiontypes)
		{
			ViewBag.QuestionTypes = GetQuestionTypes(QuestionId);
			ViewBag.QuestionType1 = questiontypes;
			var data = db.QuestionTypes.Include(x => x.Category);
			if (QuestionId.HasValue) data = data.Where(p => p.Category.Id == categoryId.Value);
			if (string.IsNullOrEmpty(productName) == false) data = data.Where(p => p.Name.Contains(productName));
			return View(data.ToList());
		}
		private IEnumerable<SelectListItem> GetQuestionTypes(int? QuestionId)
		{
			var items = db.QuestionTypes
				.Select(c => new SelectListItem
				{ Value = c.Id.ToString(), Text = c.QuestionType1, Selected = (QuestionId.HasValue && c.Id == QuestionId.Value) })
				.ToList()
				.Prepend(new SelectListItem { Value = string.Empty, Text = "請選擇" });

			return items;
		}
	}
}