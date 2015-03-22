using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LiveTiles.Models
{
    public class UserAccount
    {
        [Required]
        public int UserAccountId { get; set; }

        [Required]
        [Display(Name = "Organization Unit")]
        public string OrgUnit { get; set; }

        [Display(Name = "Organization Name")]
        public string OrgName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        public int TileLayoutId { get; set; }

        public virtual TileLayout TileLayout { get; set; }
        public virtual ICollection<TileLayoutUserLink> TileLayoutUserLink { get; set; }
    }
}