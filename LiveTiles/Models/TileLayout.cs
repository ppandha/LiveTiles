using System;
using System.ComponentModel.DataAnnotations;

namespace LiveTiles.Models
{
    public class TileLayout
    {
        [Required]
        public int TileLayoutId { get; set; }

        [Required]
        public String Description { get; set; }

        [Required]
        public int NumberOfTiles { get; set; }

    }
}