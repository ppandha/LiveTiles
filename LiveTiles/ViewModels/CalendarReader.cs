using LiveTiles.DAL;
using LiveTiles.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LiveTiles.ViewModels
{
    public class CalendarReader
    {
        public static List<CalendarItem> GetCalendarItems(Calender calender, LiveTilesContext db)
        {
            // Now the items for this week

            var sunday = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek);
            //This subtracting the current Day of week (0 for Sunday, 1 for Monday etc) from today
            var endOfweek = sunday.AddDays(7);
            //This adding 7 days to the date of sunday to get the end of this week.

            // Get all the calendar items for this calendar for this week
            var calendarItems = db.CalendarItem.Where(
                a => a.CalendarId == calender.TileId && a.StartTime > sunday && a.EndTime < endOfweek).Select(a => a).ToList();


            return calendarItems;
        }

    }
}