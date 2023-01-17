using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using 專題.Models.EFModels;

namespace 專題.Controllers
{
    public class ChatContentsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ChatContents
        public ActionResult Index()
        {
            var chatContents = db.ChatContents.Include(c => c.ChatRoom).Include(c => c.Employee).Include(c => c.Member);
            return View(chatContents.ToList());
        }

        // GET: ChatContents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatContent chatContent = db.ChatContents.Find(id);
            if (chatContent == null)
            {
                return HttpNotFound();
            }
            return View(chatContent);
        }

        // GET: ChatContents/Create
        public ActionResult Create()
        {
            ViewBag.ChatRoomId = new SelectList(db.ChatRooms, "Id", "Id");
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Account");
            ViewBag.MemberId = new SelectList(db.Members, "Members_Id", "Name");
            return View();
        }

        // POST: ChatContents/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SentTime,ChatContent1,MemberId,ChatRoomId,EmployeeId")] ChatContent chatContent)
        {
            if (ModelState.IsValid)
            {
                db.ChatContents.Add(chatContent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChatRoomId = new SelectList(db.ChatRooms, "Id", "Id", chatContent.ChatRoomId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Account", chatContent.EmployeeId);
            ViewBag.MemberId = new SelectList(db.Members, "Members_Id", "Name", chatContent.MemberId);
            return View(chatContent);
        }

        // GET: ChatContents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatContent chatContent = db.ChatContents.Find(id);
            if (chatContent == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChatRoomId = new SelectList(db.ChatRooms, "Id", "Id", chatContent.ChatRoomId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Account", chatContent.EmployeeId);
            ViewBag.MemberId = new SelectList(db.Members, "Members_Id", "Name", chatContent.MemberId);
            return View(chatContent);
        }

        // POST: ChatContents/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SentTime,ChatContent1,MemberId,ChatRoomId,EmployeeId")] ChatContent chatContent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatContent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChatRoomId = new SelectList(db.ChatRooms, "Id", "Id", chatContent.ChatRoomId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "Id", "Account", chatContent.EmployeeId);
            ViewBag.MemberId = new SelectList(db.Members, "Members_Id", "Name", chatContent.MemberId);
            return View(chatContent);
        }

        // GET: ChatContents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatContent chatContent = db.ChatContents.Find(id);
            if (chatContent == null)
            {
                return HttpNotFound();
            }
            return View(chatContent);
        }

        // POST: ChatContents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChatContent chatContent = db.ChatContents.Find(id);
            db.ChatContents.Remove(chatContent);
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
