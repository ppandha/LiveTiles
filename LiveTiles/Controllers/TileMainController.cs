using System.Globalization;
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
                // this is a noticeboard tile.
                var noticeBoard = tile as Noticeboard;
                // get Noticeboard Items ViewModel. 
                var noticeboardItem = NoticeboardReader.GetNoticeboardItem(noticeBoard, db);
                // pass ViewModel to the view.
                return PartialView("_NoticeBoardTilePartialView", noticeboardItem);
            }
            if (tile.TileType == 2)
            {
                // this is a calendar tile.
                var calender = tile as Calender;
                // get Calendar Items ViewModel.
                var calendarItems = CalendarReader.GetCalendarItems(calender, db);
                // pass ViewModel to the view.
                return PartialView("_CalendarTilePartialView", calendarItems);
            }
            if (tile.TileType == 3)
            {
                // this is a newsfeed tile.
                var newstile = tile as Newsfeed;
                // get Newsfeed Items ViewModel.    
                var newsItems = RssReader.Read(newstile.RssUrl);
                // pass ViewModel to the view.
                return PartialView("_NewsFeedTilePartialView", newsItems);
            }
            if (tile.TileType == 4)
            {
                // this is the a Twitter tile.
                var twitterTile = tile as Twitter;
                // get Twitter Items ViewModel.
                var tweets = TwitterReader.GetTweets(twitterTile.SearchCriteria);
                // pass ViewModel to the view. 
                return PartialView("_TwitterTilePartialView", tweets);
            }

            return PartialView("_TilePartialView");
        }
    
    }
}
