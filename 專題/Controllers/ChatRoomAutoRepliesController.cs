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
    public class ChatRoomAutoRepliesController : Controller
    {
        private AppDbContext db = new AppDbContext();

        // GET: ChatRoomAutoReplies
        public ActionResult Index()
        {
            var chatRoomAutoReplies = db.ChatRoomAutoReplies.Include(c => c.AutoReply).Include(c => c.ChatRoom);
            return View(chatRoomAutoReplies.ToList());
        }

        // GET: ChatRoomAutoReplies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatRoomAutoReply chatRoomAutoReply = db.ChatRoomAutoReplies.Find(id);
            if (chatRoomAutoReply == null)
            {
                return HttpNotFound();
            }
            return View(chatRoomAutoReply);
        }

        // GET: ChatRoomAutoReplies/Create
        public ActionResult Create()
        {
            ViewBag.AutoReplyId = new SelectList(db.AutoReplies, "Id", "AutoReplyContent");
            ViewBag.ChatRoomId = new SelectList(db.ChatRooms, "Id", "Id");
            return View();
        }

        // POST: ChatRoomAutoReplies/Create
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,SentTime,AutoReplyId,ChatRoomId")] ChatRoomAutoReply chatRoomAutoReply)
        {
            if (ModelState.IsValid)
            {
                db.ChatRoomAutoReplies.Add(chatRoomAutoReply);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AutoReplyId = new SelectList(db.AutoReplies, "Id", "AutoReplyContent", chatRoomAutoReply.AutoReplyId);
            ViewBag.ChatRoomId = new SelectList(db.ChatRooms, "Id", "Id", chatRoomAutoReply.ChatRoomId);
            return View(chatRoomAutoReply);
        }

        // GET: ChatRoomAutoReplies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatRoomAutoReply chatRoomAutoReply = db.ChatRoomAutoReplies.Find(id);
            if (chatRoomAutoReply == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutoReplyId = new SelectList(db.AutoReplies, "Id", "AutoReplyContent", chatRoomAutoReply.AutoReplyId);
            ViewBag.ChatRoomId = new SelectList(db.ChatRooms, "Id", "Id", chatRoomAutoReply.ChatRoomId);
            return View(chatRoomAutoReply);
        }

        // POST: ChatRoomAutoReplies/Edit/5
        // 若要避免過量張貼攻擊，請啟用您要繫結的特定屬性。
        // 如需詳細資料，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,SentTime,AutoReplyId,ChatRoomId")] ChatRoomAutoReply chatRoomAutoReply)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chatRoomAutoReply).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutoReplyId = new SelectList(db.AutoReplies, "Id", "AutoReplyContent", chatRoomAutoReply.AutoReplyId);
            ViewBag.ChatRoomId = new SelectList(db.ChatRooms, "Id", "Id", chatRoomAutoReply.ChatRoomId);
            return View(chatRoomAutoReply);
        }

        // GET: ChatRoomAutoReplies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChatRoomAutoReply chatRoomAutoReply = db.ChatRoomAutoReplies.Find(id);
            if (chatRoomAutoReply == null)
            {
                return HttpNotFound();
            }
            return View(chatRoomAutoReply);
        }

        // POST: ChatRoomAutoReplies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChatRoomAutoReply chatRoomAutoReply = db.ChatRoomAutoReplies.Find(id);
            db.ChatRoomAutoReplies.Remove(chatRoomAutoReply);
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
