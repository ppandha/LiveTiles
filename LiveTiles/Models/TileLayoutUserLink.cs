﻿using System.ComponentModel.DataAnnotations;

namespace LiveTiles.Models
{
    public class TileLayoutUserLink
    {
        [Display(Name = "Tile Layout")]
        [Required]
        public int TileLayoutUserLinkId { get; set; }

        //The UserAccountId property is a foreign key, and the corresponding navigation property is UserAccount. 
        // A TileLayoutUserLink entity is associated with one UserAccount entity.
        [Required]
        public int UserAccountId { get; set; }

        [Required]
        [Display(Name = "Tile")]
        public int TileId { get; set; }

        public virtual UserAccount UserAccount { get; set; }
        public virtual Tile Tile { get; set; }

        public string TileType
        {
            get
            {
                switch (Tile.TileType)
                {
                    case 1:
                        return "Noticeboard";
                    case 2:
                        return "Calendar";
                    case 3:
                        return "News";
                    case 4:
                        return "Twitter";
                }
                return "Unknown";
            }
        }
    }
}