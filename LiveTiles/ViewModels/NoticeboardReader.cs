using LiveTiles.DAL;
using LiveTiles.Models;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;

namespace LiveTiles.ViewModels
{
    public class NoticeboardReader
    {
        public static NoticeboardItem GetNoticeboardItem(Noticeboard noticeBoard, LiveTilesContext db)
        {
            // This is a noticeboard tile. Get the item to display using the current item count. 
            // Searches through all Noticeboard Items for those belonging to this Noticeboard.
            var tileItems = db.NoticeboardItem.Where(a => a.NoticeboardId == noticeBoard.TileId).Select(a => a).ToList();
            var tileItem = tileItems[noticeBoard.CurrentItem];
            // cycle around the items to display
            noticeBoard.CurrentItem++;
            if (noticeBoard.CurrentItem == tileItems.Count) noticeBoard.CurrentItem = 0;
            return tileItem;
        }
    }
}