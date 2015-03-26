using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LiveTiles.DAL;
using LiveTiles.Models;

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

        // GET: Newsfeeds/Details/5
        public ActionResult Details(int? id)
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

        // GET: Newsfeeds/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Newsfeeds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TileId,TileType,RssUrl")] Newsfeed newsfeed)
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
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TileId,TileType,RssUrl")] Newsfeed newsfeed)
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
            db.Tile.Remove(newsfeed);
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
