using LiveTiles.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiveTiles.Models
{
    public class TileType
    {
        [Required]
        public int TileTypeId { get; set; }

        [Required]
        public String Type { get; set; }

        public virtual ICollection<TileLayoutUserLink> TileLayoutUserLinks { get; set; }
    }
}