using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace 專題.Controllers
{
    public class CommonQuestionController : Controller
    {
        // GET: CommonQuestion
        public ActionResult CommonQuestions()
        {
            return View();
        }
		public ActionResult CommonAnswers()
		{
			return View();
		}
		public ActionResult QuestionTypes()
		{
			return View();
		}
	}
}