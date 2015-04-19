using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;


namespace LiveTiles.Models
{
    // Tile parent class holding common tile configuration information.
    public abstract class Tile
    {
        [Key]
        public int TileId { get; set; }

        [Required]
        [HiddenInput(DisplayValue = false)]
        public int TileType { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int RefreshPeriod { get; set; }      
    }
}
