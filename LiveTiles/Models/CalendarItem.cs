using System;
using System.ComponentModel.DataAnnotations;

namespace LiveTiles.Models
{
    public class CalendarItem
    {
        public int CalendarItemId { get; set; }

        [Required]
        public string Content { get; set; }

        public string Location { get; set; }

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
  
        
        public int CalendarId { get; set; }
        public virtual Calender Calendar { get; set; }
    }
}