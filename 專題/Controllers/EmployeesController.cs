using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Web.UI.WebControls;
using 專題.Models.DTOs;
using 專題.Models.EFModels;
using 專題.Models.Services;
using 專題.Models.Services.Interfaces;
using 專題.Models.Services.Interfaces.Repositories;
using 專題.Models.ViewModels;

namespace 專題.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeRepository repository;
        private EmployeeService service;

        public EmployeesController()
        {
            repository = new EmployeeRepository();
            service = new EmployeeService(repository);
        }

        // GET: Members/Index
        public ActionResult Index()
        {
            return View();
        }

        // GET: Members/Register
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(EmployeeRegisterVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = new EmployeeService(repository);

            (bool IsSuccess, string ErrorMessage) response =
                service.CreateNewEmployee(model.ToRequestDto());

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
        public ActionResult Login(EmployeeLoginVM model)
        {
            // var service = new MemberService(repository);
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
            return Redirect("/Employees/Login");
        }

        public ActionResult EditProfile()
        {
            string currentUserAccount = User.Identity.Name;

            EmployeeDto entity = repository.GetByAccount(currentUserAccount);
            EditEmployeeProfileVM model = entity.ToEditProfileVM();

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProfile(EditEmployeeProfileVM model)
        {
            string currentUserAccount = User.Identity.Name;

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            EmployeeUpdateProfileDto request = model.ToDto(currentUserAccount);
            try
            {
                service.UpdateProfile(request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (ModelState.IsValid == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        [Authorize]
        public ActionResult EditPassword()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult EditPassword(EmployeeEditPasswordVM model)
        {
            string currentUserAccount = User.Identity.Name;

            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            EmployeeChangePasswordRequest request = model.ToRequest(currentUserAccount);
            try
            {
                service.ChangePassword(request);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }

            if (ModelState.IsValid == true)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return View(model);
            }
        }

        

       

        private string ProcessLogin(string account, bool rememberMe, out HttpCookie cookie)
        {
            var employee = repository.GetByAccount(account);
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
