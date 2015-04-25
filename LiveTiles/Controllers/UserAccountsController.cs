using LiveTiles.DAL;
using LiveTiles.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class UserAccountsController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();
        private int savedNumberOfTiles;

        // GET: UserAccounts
        public ActionResult Index()
        {
            var userAccount = db.UserAccount.Include(u => u.TileLayout);
            return View(userAccount.ToList());
        }

        // GET: UserAccounts/Create
        public ActionResult Create()
        {
            ViewBag.TileLayoutId = new SelectList(db.TileLayout, "TileLayoutId", "Description");
            return View();
        }

        // POST: UserAccounts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserAccountId,OrgName,TileLayoutId")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.UserAccount.Add(userAccount);
                db.SaveChanges();

                // Add tile entries for the tile type for this user account
                var num = db.TileLayout.Find(userAccount.TileLayoutId).NumberOfTiles;
                // Find a valid tile to use for initializing the new tiles
                var tile = db.TileLayoutUserLink.FirstOrDefault(d => d.TileId != 0);

                if (tile != null)
                {
                    //add new tiles for this user
                    for (var i = 0; i < num; i++)
                    {
                        db.TileLayoutUserLink.Add(new TileLayoutUserLink
                        {
                            TileId = tile.TileId, // The Tile to display 
                            UserAccountId = userAccount.UserAccountId
                        });
                    }
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            ViewBag.TileLayoutId = new SelectList(db.TileLayout, "TileLayoutId", "Description", userAccount.TileLayoutId);
            return View(userAccount);
        }

        // GET: UserAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }

            savedNumberOfTiles = db.TileLayout.Find(userAccount.TileLayoutId).NumberOfTiles;
            ViewBag.TileLayoutId = new SelectList(db.TileLayout, "TileLayoutId", "Description", userAccount.TileLayoutId);
            return View(userAccount);
        }

        // POST: UserAccounts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserAccountId,OrgName,TileLayoutId")] UserAccount userAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userAccount).State = EntityState.Modified;
                db.SaveChanges();


                // Check if number of tiles has changed in this edit, if so remove the old tiles for this user and
                // add the right number of new ones.
                var num = db.TileLayout.Find(userAccount.TileLayoutId).NumberOfTiles;
                if (num != savedNumberOfTiles)
                {
                    var todelete = db.TileLayoutUserLink.Where(d => d.UserAccountId == userAccount.UserAccountId);

                    foreach (var u in todelete)
                    {
                        db.TileLayoutUserLink.Remove(u);
                    }
                    db.SaveChanges();
                }

                // Find a valid tile to use for initializing the new tiles
                var tile = db.TileLayoutUserLink.FirstOrDefault(d => d.TileId != 0);

                if (tile != null)
                {
                    //add new tiles for this user
                    for (var i = 0; i < num; i++)
                    {
                        db.TileLayoutUserLink.Add(new TileLayoutUserLink
                        {
                            TileId = tile.TileId, // The Tile to display 
                            UserAccountId = userAccount.UserAccountId
                        });
                    }
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            ViewBag.TileLayoutId = new SelectList(db.TileLayout, "TileLayoutId", "Description", userAccount.TileLayoutId);
            return View(userAccount);
        }

        // GET: UserAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserAccount userAccount = db.UserAccount.Find(id);
            if (userAccount == null)
            {
                return HttpNotFound();
            }
            return View(userAccount);
        }

        // POST: UserAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserAccount userAccount = db.UserAccount.Find(id);
            db.UserAccount.Remove(userAccount);
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
