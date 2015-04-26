using LiveTiles.DAL;
using LiveTiles.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class CalendersController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();

        // GET: Calenders.
        public ActionResult Index()
        {
            return View(db.Calendar.ToList());
        }

        // GET: Calenders/Create. 
        public ActionResult Create()
        {
            return View();
        }

        // POST: Calenders/Create
         [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TileId,Title,RefreshPeriod")] Calender calender)
        {
            if (ModelState.IsValid)
            {
                calender.TileType = 2;
                db.Tile.Add(calender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(calender);
        }

        // GET: Calenders/Edit/5.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calender calender = db.Calendar.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            return View(calender);
        }

        // POST: Calenders/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TileId,TileType,Title,RefreshPeriod")] Calender calender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(calender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(calender);
        }

        // GET: Calenders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Calender calender = db.Calendar.Find(id);
            if (calender == null)
            {
                return HttpNotFound();
            }
            return View(calender);
        }

        // POST: Calenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Calender calender = db.Calendar.Find(id);
            db.Calendar.Remove(calender);
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
