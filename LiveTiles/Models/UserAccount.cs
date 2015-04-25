using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiveTiles.Models
{
    public class UserAccount
    {
        [Required]
        public int UserAccountId { get; set; }

        [Display(Name = "Location")]
        public string OrgName { get; set; }

        [Required]
        public int TileLayoutId { get; set; }

        public virtual TileLayout TileLayout { get; set; }
        public virtual ICollection<TileLayoutUserLink> TileLayoutUserLink { get; set; }
    }
}