using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace LiveTiles.Models
{
    public class Calender : Tile
    {

        // List of calendar items to display
        public virtual ICollection<CalendarItem> CalendarItem { get; set; }

        // Keep record of Item being displayed so we can cycle through them continuously
        private static int _currentItem;

        [NotMapped]
        public int CurrentItem
        {
            get { return _currentItem; }
            set { _currentItem = value; }
        }
    }
}