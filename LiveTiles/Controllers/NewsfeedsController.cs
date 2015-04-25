using LiveTiles.DAL;
using LiveTiles.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class NewsfeedsController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();

        // GET: Newsfeeds
        public ActionResult Index()
        {
            return View(db.Newsfeed.ToList());
        }

        // GET: Newsfeeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Newsfeeds/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TileId,TileType,Title,RssUrl,RefreshPeriod")] Newsfeed newsfeed)
        {
            if (ModelState.IsValid)
            {
                db.Tile.Add(newsfeed);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(newsfeed);
        }

        // GET: Newsfeeds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newsfeed newsfeed = db.Newsfeed.Find(id);
            if (newsfeed == null)
            {
                return HttpNotFound();
            }
            return View(newsfeed);
        }

        // POST: Newsfeeds/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TileId,TileType,Title,RssUrl,RefreshPeriod")] Newsfeed newsfeed)
        {
            if (ModelState.IsValid)
            {
                db.Entry(newsfeed).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(newsfeed);
        }

        // GET: Newsfeeds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Newsfeed newsfeed = db.Newsfeed.Find(id);
            if (newsfeed == null)
            {
                return HttpNotFound();
            }
            return View(newsfeed);
        }

        // POST: Newsfeeds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Newsfeed newsfeed = db.Newsfeed.Find(id);
            db.Newsfeed.Remove(newsfeed);
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
