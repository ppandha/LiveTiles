using System.ComponentModel.DataAnnotations;


namespace LiveTiles.Models
{
    public class Noticeboard : Tile
    {
        [Required]
        public string Contents { get; set; }
    }
}
