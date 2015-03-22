using System.ComponentModel.DataAnnotations;


namespace LiveTiles.Models
{
    public class Newsfeed : Tile
    {
        [Required]
        [Display(Name = "RSS Source URL")]
        public string RssUrl { get; set; }
    }
}