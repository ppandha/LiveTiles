using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace LiveTiles.Models
{

    public class Noticeboard : Tile
    {
        // List of noticeboard items to display
        public virtual ICollection<NoticeboardItem> NoticeboardItem { get; set; }

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
