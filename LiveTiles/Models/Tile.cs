using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace LiveTiles.Models
{

    public abstract class Tile
    {
        [Key]
        public int TileId { get; set; }

        [Required]
        public int TileType { get; set; }

        public virtual ICollection<TileLayoutUserLink> TileLayoutUserLink { get; set; }

    }
}
