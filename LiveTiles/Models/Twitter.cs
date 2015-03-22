using System.ComponentModel.DataAnnotations;

namespace LiveTiles.Models
{
    public class Twitter : Tile
    {
        [Required]
        [Display(Name = "Search Criteria")]
        public string SearchCriteria { get; set; }
    }

}