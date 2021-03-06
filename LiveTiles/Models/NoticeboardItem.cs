﻿using System.ComponentModel.DataAnnotations;

namespace LiveTiles.Models
{
    public class NoticeboardItem
    {
        public int NoticeboardItemId { get; set; }

        [Required]
        public string Content { get; set; }

        public int NoticeboardId { get; set; }
        public virtual Noticeboard Noticeboard { get; set; }
    }
}