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

        // GET: Noticeboards/Details/5
        public ActionResult Details(int? id)
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

        // GET: Noticeboards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Noticeboards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TileId,Title,Contents")] Noticeboard noticeboard)
        {
            if (ModelState.IsValid)
            {
                noticeboard.TileType = 1;
                db.Noticeboard.Add(noticeboard);
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TileId,Title,Contents")] Noticeboard noticeboard)
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
            db.Noticeboard.Remove(noticeboard);
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
