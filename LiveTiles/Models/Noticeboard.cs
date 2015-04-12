using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace LiveTiles.Models
{

    public class Noticeboard : Tile
    {
        [Required]
        public string Contents { get; set; }

        public virtual ICollection<NoticeboardItem> NoticeboardItem { get; set; }

        private static int _currentItem;

        [NotMapped] 
        public int CurrentItem
        {
            get { return _currentItem; }
            set { _currentItem = value; }
        }
    }
}
