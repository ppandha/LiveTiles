using LiveTiles.DAL;
using LiveTiles.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class TwittersController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();

        // GET: Twitters
        public ActionResult Index()
        {
            return View(db.Twitter.ToList());
        }

        // GET: Twitters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Twitter twitter = db.Twitter.Find(id);
            if (twitter == null)
            {
                return HttpNotFound();
            }
            return View(twitter);
        }

        // GET: Twitters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Twitters/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TileId,SearchCriteria")] Twitter twitter)
        {
            if (ModelState.IsValid)
            {
                db.Tile.Add(twitter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(twitter);
        }

        // GET: Twitters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Twitter twitter = db.Twitter.Find(id);
            if (twitter == null)
            {
                return HttpNotFound();
            }
            return View(twitter);
        }

        // POST: Twitters/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TileId,SearchCriteria")] Twitter twitter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(twitter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(twitter);
        }

        // GET: Twitters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Twitter twitter = db.Twitter.Find(id);
            if (twitter == null)
            {
                return HttpNotFound();
            }
            return View(twitter);
        }

        // POST: Twitters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Twitter twitter = db.Twitter.Find(id);
            db.Tile.Remove(twitter);
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
