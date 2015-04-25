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
        [DisplayFormat(DataFormatString = "{0:g}")]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required]
        [DisplayFormat(DataFormatString = "{0:g}")]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
  
        
        public int CalendarId { get; set; }
        public virtual Calender Calendar { get; set; }

        public CalendarItem()
        {
            // Initialise start/end times for use when creating a new CalendarItem
            StartTime = DateTime.Now;
            EndTime = DateTime.Now;
        }
    }
}