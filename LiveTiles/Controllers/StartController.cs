using LiveTiles.DAL;
using LiveTiles.Models;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class StartController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();

        // GET: Start
        public ActionResult Index()
        {
            var userAccount = db.UserAccount.Include(u => u.TileLayout);
            return View(userAccount.ToList());
        }

        // GET: Start/Start/5
        public ActionResult Start(int? id)
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
            return RedirectToAction("Index", "TileMain", userAccount);
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
