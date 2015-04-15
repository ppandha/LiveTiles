using LiveTiles.DAL;
using LiveTiles.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class NoticeboardItemsController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();

        // GET: NoticeboardItem
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            } 
            // Finding the notices for this Noticeboard
            // Build parameter list for Noticeboard Items view, tileID is required in the view for creating new Noticeboard Items 
            var pars =  new List<object>() {id, db.NoticeboardItem.Where(a => a.NoticeboardId == id).Select(a=>a).ToList()};
         
            return View(pars);
        }

        // GET: NoticeboardItem/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoticeboardItem noticeboardItem = db.NoticeboardItem.Find(id);
            if (noticeboardItem == null)
            {
                return HttpNotFound();
            }
            return View(noticeboardItem);
        }

        // GET: NoticeboardItem/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            // create a new Noticeboard item to use in the form and set its Noticeboard ID to the current Noticeboard
            // The Noticeboard ID is part of the Create form and will be passed back when the user clicks the save button.
            NoticeboardItem noticeboardItem = db.NoticeboardItem.Create();
            noticeboardItem.NoticeboardId = id.GetValueOrDefault();
            return View(noticeboardItem);
        }

        // POST: NoticeboardItem/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NoticeboardItemId,NoticeboardId,Content")] NoticeboardItem noticeboardItem)
        {
            if (ModelState.IsValid)
            {
                // New Noticeboard item is added to the list of Noticeboard Items
                db.NoticeboardItem.Add(noticeboardItem);
                db.SaveChanges();
                return RedirectToAction("Index", "NoticeboardItems", new { id = noticeboardItem.NoticeboardId });
            }

            return View(noticeboardItem);
        }

        // GET: NoticeboardItem/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoticeboardItem noticeboardItem = db.NoticeboardItem.Find(id);
            if (noticeboardItem == null)
            {
                return HttpNotFound();
            }
            return View(noticeboardItem);
        }

        // POST: NoticeboardItem/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NoticeboardItemId,NoticeboardId,Content")] NoticeboardItem noticeboardItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticeboardItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "NoticeboardItems", new {id = noticeboardItem.NoticeboardId});
            }
            return View(noticeboardItem);
        }

        // GET: NoticeboardItem/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoticeboardItem noticeboardItem = db.NoticeboardItem.Find(id);
            if (noticeboardItem == null)
            {
                return HttpNotFound();
            }
            return View(noticeboardItem);
        }

        // POST: NoticeboardItem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NoticeboardItem noticeboardItem = db.NoticeboardItem.Find(id);
            db.NoticeboardItem.Remove(noticeboardItem);
            db.SaveChanges();
            return RedirectToAction("Index", "NoticeboardItems", new { id = noticeboardItem.NoticeboardId });
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
