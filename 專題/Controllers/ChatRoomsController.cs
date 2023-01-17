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
    public class ChatRoomsController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ChatRooms
        public ActionResult Index()
        {
            return View(db.ChatRooms.ToList());
        }

        // GET: ChatRooms/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatRoom chatRoom = db.ChatRooms.Find(id);
            if (chatRoom == null)
            {
                return HttpNotFound();
            }
            return View(chatRoom);
        }

        // GET: ChatRooms/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ChatRooms/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,StartTime,EndTime")] ChatRoom chatRoom)
        {
            if (ModelState.IsValid)
            {
                db.ChatRooms.Add(chatRoom);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(chatRoom);
        }

        // GET: ChatRooms/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatRoom chatRoom = db.ChatRooms.Find(id);
            if (chatRoom == null)
            {
                return HttpNotFound();
            }
            return View(chatRoom);
        }

        // POST: ChatRooms/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartTime,EndTime")] ChatRoom chatRoom)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatRoom).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(chatRoom);
        }

        // GET: ChatRooms/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatRoom chatRoom = db.ChatRooms.Find(id);
            if (chatRoom == null)
            {
                return HttpNotFound();
            }
            return View(chatRoom);
        }

        // POST: ChatRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChatRoom chatRoom = db.ChatRooms.Find(id);
            db.ChatRooms.Remove(chatRoom);
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
