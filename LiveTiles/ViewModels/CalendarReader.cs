using System.Globalization;
using LiveTiles.DAL;
using LiveTiles.Models;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;

namespace LiveTiles.ViewModels
{
    public class CalendarReader
    {
        public static List<CalendarItem> GetCalendarItems(Calender calender, LiveTilesContext db)
        {
            // Get all the calendar items for this calendar
            var calendarItems = db.CalendarItem.Where(a => a.CalendarId == calender.TileId).Select(a => a).ToList();

            // Now the items for this week

            // TODO SORT WITHIN THE WEEK 

            return calendarItems;
        }

    }
}