using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LiveTiles.Models
{
    public class Noticeboard : Tile
    {
        [Required]
        public string Heading { get; set; }

        [Required]
        public string Contents { get; set; }

        public virtual ICollection<TileLayoutUserLink> TileLayoutUserLinks { get; set; }
    }
}
