using System;
using System.ComponentModel.DataAnnotations;


namespace LiveTiles.Models
{
    public class Calender : Tile
    {
        [Required]
        public string Contents { get; set; }

        public string Location { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

    }
}