using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class HomeController : Controller
    {
        //main home screen view.
        public ActionResult Index()
        {
            return View();
        }
     
    }
}