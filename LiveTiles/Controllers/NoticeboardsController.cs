using LiveTiles.DAL;
using LiveTiles.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class NoticeboardsController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();

        // GET: Noticeboards
        public ActionResult Index()
        {
            return View(db.Noticeboard.ToList());
        }

        // GET: Noticeboards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Noticeboards/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TileId,TileType,Title,RefreshPeriod")] Noticeboard noticeboard)
        {
            if (ModelState.IsValid)
            {
                db.Tile.Add(noticeboard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(noticeboard);
        }

        // GET: Noticeboards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticeboard noticeboard = db.Noticeboard.Find(id);
            if (noticeboard == null)
            {
                return HttpNotFound();
            }
            return View(noticeboard);
        }

        // POST: Noticeboards/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TileId,TileType,Title,RefreshPeriod")] Noticeboard noticeboard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noticeboard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(noticeboard);
        }

        // GET: Noticeboards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Noticeboard noticeboard = db.Noticeboard.Find(id);
            if (noticeboard == null)
            {
                return HttpNotFound();
            }
            return View(noticeboard);
        }

        // POST: Noticeboards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Noticeboard noticeboard = db.Noticeboard.Find(id);
            db.Tile.Remove(noticeboard);
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
