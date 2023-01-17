
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.Services.Description;
using System.Web.UI.WebControls;
using X.PagedList;
using 專題.Models.EFModels;
using 專題.Models.Infrastructures.Repositories;
using 專題.Models.Services;
using 專題.Models.Services.Interfaces;
using 專題.Models.ViewModels;

namespace 專題.Controllers
{
	public class MembersController : Controller
	{


		private IMemberRepository repository;
		private MemberService service;
		private AppDbContext db = new AppDbContext();
		public MembersController()
		{
			repository = new MemberRepository();
			service = new MemberService(repository);
		}



		public ActionResult Index(string Name, string Account, string Mail, string Phone, int pageNumber = 1)
		{
			pageNumber = pageNumber > 0 ? pageNumber : 1;

			ViewBag.Name = Name;
			ViewBag.Account = Account;
			ViewBag.Mail = Mail;
			ViewBag.Phone = Phone;

			IPagedList<Member> pagedData = GetPagedMembers(Name, Account, Mail, Phone, pageNumber);

			return View(pagedData);

		}

		private IPagedList<Member> GetPagedMembers(string Name, string Account, string Mail, string Phone, int pageNumber)
		{
			int pageSize = 5;
			var query = db.Members.OrderBy(x => x.Member_Id);

			if (string.IsNullOrEmpty(Name) == false) query = (IOrderedQueryable<Member>)query.Where(p => p.Name.Contains(Name));

			if (string.IsNullOrEmpty(Account) == false) query = (IOrderedQueryable<Member>)query.Where(p => p.Account.Contains(Account));

			if (string.IsNullOrEmpty(Mail) == false) query = (IOrderedQueryable<Member>)query.Where(p => p.Mail.Contains(Mail));

			if (string.IsNullOrEmpty(Phone) == false) query = (IOrderedQueryable<Member>)query.Where(p => p.Phone.Contains(Phone));


			return query.ToPagedList(pageNumber, pageSize);
		}
		public ActionResult Register()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Register(RegisterVM model)
		{
			if (!ModelState.IsValid)
			{
				return View(model);
			}

			var service = new MemberService(repository);

			(bool IsSuccess, string ErrorMessage) response =
				service.CreateNewMember(model.ToRequestDto());

			if (response.IsSuccess)
			{
				// 建檔成功 redirect to confirm page
				return View("RegisterConfirm");
			}
			else
			{
				ModelState.AddModelError(string.Empty, response.ErrorMessage);
				return View(model);
			}
		}

		public ActionResult Login()
		{
			return View();
		}

		[HttpPost]
		public ActionResult Login(LoginVM model)
		{
			var service = new MemberService(repository);
			(bool IsSuccess, string ErrorMessage) response =
				service.Login(model.Account, model.Password);

			if (response.IsSuccess)
			{
				// 記住登入成功的會員
				var rememberMe = false;

				string returnUrl = ProcessLogin(model.Account, rememberMe, out HttpCookie cookie);

				Response.Cookies.Add(cookie);

				return Redirect(returnUrl);
			}

			ModelState.AddModelError(string.Empty, response.ErrorMessage);

			return this.View(model);
		}

		public ActionResult Logout()
		{
			Session.Abandon();
			FormsAuthentication.SignOut();
			return Redirect("/Members/Login");
		}

		// GET: Members/Details/5
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Member member = db.Members.Find(id);
			if (member == null)
			{
				return HttpNotFound();
			}
			return View(member);
		}

		// GET: Members/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: Members/Create
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Member_Id,Name,Account,Password,Phone,Mail,State,Subscription,IsConfirmed")] Member member)
		{
			if (ModelState.IsValid)
			{
				db.Members.Add(member);
				db.SaveChanges();
				return RedirectToAction("Index");
			}

			return View(member);
		}

		// GET: Members/Edit/5
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Member member = db.Members.Find(id);
			if (member == null)
			{
				return HttpNotFound();
			}
			return View(member);
		}

		// POST: Members/Edit/5
		// 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
		// 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Member_Id,Name,Account,Password,Phone,Mail,State,Subscription,IsConfirmed")] Member member)
		{
			if (ModelState.IsValid)
			{
				db.Entry(member).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(member);
		}

		// GET: Members/Delete/5
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			Member member = db.Members.Find(id);
			if (member == null)
			{
				return HttpNotFound();
			}
			return View(member);
		}

		// POST: Members/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(int id)
		{
			Member member = db.Members.Find(id);
			db.Members.Remove(member);
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
		private string ProcessLogin(string account, bool rememberMe, out HttpCookie cookie)
		{
			var member = repository.GetByAccount(account);
			string roles = String.Empty; // 在本範例, 沒有用到角色權限,所以存入空白

			// 建立一張認證票
			FormsAuthenticationTicket ticket =
				new FormsAuthenticationTicket(
					1,          // 版本別, 沒特別用處
					account,
					DateTime.Now,   // 發行日
					DateTime.Now.AddDays(2), // 到期日
					rememberMe,     // 是否續存
					roles,          // userdata
					"/" // cookie位置
				);

			// 將它加密
			string value = FormsAuthentication.Encrypt(ticket);

			// 存入cookie
			cookie = new HttpCookie(FormsAuthentication.FormsCookieName, value);

			// 取得return url
			string url = FormsAuthentication.GetRedirectUrl(account, true); //第二個引數沒有用處

			return url;
		}
	}
}
