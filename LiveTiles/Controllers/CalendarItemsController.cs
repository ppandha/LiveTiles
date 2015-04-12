using LiveTiles.DAL;
using LiveTiles.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class CalendarItemsController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();

        // GET: CalendarItems
        //public ActionResult Index()
        //{
        //    return View(db.CalendarItem.ToList());
        //}
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var pars = new List<object>() { id, db.CalendarItem.Where(a => a.CalendarId == id).Select(a => a).ToList() };

            return View(pars);
        }

        // GET: CalendarItems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem calendarItem = db.CalendarItem.Find(id);
            if (calendarItem == null)
            {
                return HttpNotFound();
            }
            return View(calendarItem);
        }

        // GET: CalendarItems/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            CalendarItem calendarItem = db.CalendarItem.Create();
            calendarItem.CalendarId = id.GetValueOrDefault();
            return View(calendarItem);
        }
        // POST: CalendarItems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "CalendarItemId,Content,Location,StartTime,EndTime,CalendarId")] CalendarItem calendarItem)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.CalendarItem.Add(calendarItem);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(calendarItem);
        //}
        public ActionResult Create([Bind(Include = "CalendarItemId,CalendarId,Content,Location,StartTime,EndTime")] CalendarItem calendarItem)
        {
            if (ModelState.IsValid)
            {
                db.CalendarItem.Add(calendarItem);
                db.SaveChanges();
                return RedirectToAction("Index", "CalendarItems", new { id = calendarItem.CalendarId });
            }

            return View(calendarItem);
        }

        // GET: CalendarItems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem calendarItem = db.CalendarItem.Find(id);
            if (calendarItem == null)
            {
                return HttpNotFound();
            }
            return View(calendarItem);
        }

        // POST: CalendarItems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CalendarItemId,Content,Location,StartTime,EndTime,CalendarId")] CalendarItem calendarItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calendarItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", "CalendarItems", new { id = calendarItem.CalendarId });
            }
            return View(calendarItem);
        }

        // GET: CalendarItems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CalendarItem calendarItem = db.CalendarItem.Find(id);
            if (calendarItem == null)
            {
                return HttpNotFound();
            }
            return View(calendarItem);
        }

        // POST: CalendarItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CalendarItem calendarItem = db.CalendarItem.Find(id);
            db.CalendarItem.Remove(calendarItem);
            db.SaveChanges();
            return RedirectToAction("Index", "CalendarItems", new { id = calendarItem.CalendarId });
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
