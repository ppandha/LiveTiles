using LiveTiles.DAL;
using LiveTiles.Models;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class TileLayoutUserLinksController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();

        // GET: TileLayoutUserLinks
        public ActionResult Index()
        {
            var tileLayoutUserLink = db.TileLayoutUserLink.Include(t => t.UserAccount);
            return View(tileLayoutUserLink.ToList());
        }

        // GET: TileLayoutUserLinks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TileLayoutUserLink tileLayoutUserLink = db.TileLayoutUserLink.Find(id);
            if (tileLayoutUserLink == null)
            {
                return HttpNotFound();
            }
            return View(tileLayoutUserLink);
        }

        // GET: TileLayoutUserLinks/Create
        public ActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            ViewBag.UserAccountId = new SelectList(db.UserAccount, "UserAccountId", "OrgUnit");
            return View();
        }

        // POST: TileLayoutUserLinks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TileLayoutUserLinkId,UserAccountId,TileId")] TileLayoutUserLink tileLayoutUserLink)
        {
            if (ModelState.IsValid)
            {
                db.TileLayoutUserLink.Add(tileLayoutUserLink);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            PopulateDepartmentsDropDownList(tileLayoutUserLink.TileId);
            ViewBag.UserAccountId = new SelectList(db.UserAccount, "UserAccountId", "OrgUnit", tileLayoutUserLink.UserAccountId);
            return View(tileLayoutUserLink);
        }

        // GET: TileLayoutUserLinks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TileLayoutUserLink tileLayoutUserLink = db.TileLayoutUserLink.Find(id);
            if (tileLayoutUserLink == null)
            {
                return HttpNotFound();
            }
            PopulateDepartmentsDropDownList(tileLayoutUserLink.TileId);
            ViewBag.UserAccountId = new SelectList(db.UserAccount, "UserAccountId", "OrgUnit", tileLayoutUserLink.UserAccountId);
            return View(tileLayoutUserLink);
        }

        // POST: TileLayoutUserLinks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TileLayoutUserLinkId,UserAccountId,TileId")] TileLayoutUserLink tileLayoutUserLink)
        {
            //if (ModelState.IsValid)
            //{
            //    db.Entry(tileLayoutUserLink).State = EntityState.Modified;
            //    db.SaveChanges();
            //    return RedirectToAction("Index");
            //}
            if (tileLayoutUserLink == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //var tileLayoutUserLinkToUpdate = db.TileLayoutUserLink.Find(id);
            if (TryUpdateModel(tileLayoutUserLink, "",
               new string[] { "Title", "Credits", "DepartmentID" }))
            {
                try
                {
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }

            PopulateDepartmentsDropDownList(tileLayoutUserLink.TileId);
            ViewBag.UserAccountId = new SelectList(db.UserAccount, "UserAccountId", "OrgUnit", tileLayoutUserLink.UserAccountId);
            return View(tileLayoutUserLink);
        }

        // GET: TileLayoutUserLinks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TileLayoutUserLink tileLayoutUserLink = db.TileLayoutUserLink.Find(id);
            if (tileLayoutUserLink == null)
            {
                return HttpNotFound();
            }
            return View(tileLayoutUserLink);
        }

        // POST: TileLayoutUserLinks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TileLayoutUserLink tileLayoutUserLink = db.TileLayoutUserLink.Find(id);
            db.TileLayoutUserLink.Remove(tileLayoutUserLink);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        private void PopulateDepartmentsDropDownList(object selectedTile = null)
        {
            var tilesQuery = from t in db.Tile
                                   orderby t.TileType
                                   select t;
            ViewBag.TileId = new SelectList(tilesQuery, "TileId", "Title", selectedTile);
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
