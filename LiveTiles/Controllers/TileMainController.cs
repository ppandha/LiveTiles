using LiveTiles.DAL;
using LiveTiles.Models;
using LiveTiles.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace LiveTiles.Controllers
{
    public class TileMainController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();

        // GET: TileMain
        public ActionResult Index(UserAccount userAccount)
        {
            // get data for this user account
            var userAccount1 = db.UserAccount.Find(userAccount.UserAccountId);

            return View(userAccount1);
        }

        public ActionResult GetView(int tileId)
        {
            var tile = db.Tile.Find(tileId);

            // which tile is it?

            if (tile.TileType == 1)
            {
                // This is a noticeboard tile. Get the item to display using the current item count. 
                // Searches through all Noticeboard Items for those belonging to this Noticeboard.
                var noticeBoard = tile as Noticeboard;
                var tileItems = db.NoticeboardItem.Where(a => a.NoticeboardId == tileId).Select(a => a).ToList();
                var tileItem = tileItems[noticeBoard.CurrentItem];
                // cycle around the items to display
                noticeBoard.CurrentItem ++;
                if (noticeBoard.CurrentItem == tileItems.Count) noticeBoard.CurrentItem = 0;
                return PartialView("_NoticeBoardTilePartialView", tileItem );
            }
            if (tile.TileType == 2)
            {
                // Get all the calendar items for this calendar
                var calendarItems = db.CalendarItem.Where(a => a.CalendarId == tileId).Select(a => a).ToList();

                // Now the items for this week

                // TODO
                
                return PartialView("_CalendarTilePartialView", calendarItems);
            }
            if (tile.TileType == 3)
            {
                var newstile = tile as Newsfeed;

                var newsItems = RssReader.Read(newstile.RssUrl);

                return PartialView("_NewsFeedTilePartialView", newsItems);
            }
            if (tile.TileType == 4)
            {
                var twitterTile = tile as Twitter;

                var tweets = TwitterReader.GetTweets(twitterTile.SearchCriteria);

                return PartialView("_TwitterTilePartialView", tweets);
            }

            return PartialView("_TilePartialView");
        }
    
    }
}
