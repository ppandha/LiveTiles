﻿using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace LiveTiles.Models
{
    // Tile parent class holding common tile configuration information.
    public abstract class Tile
    {
        [Display(Name = "Tile Name")]
        [Key]
        public int TileId { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int TileType { get; set; }

        [Required]
        public string Title { get; set; }

        [Display(Name = "Refresh Period (seconds)")]
        [Required]
        public int RefreshPeriod { get; set; }      
    }
}
