using LiveTiles.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace LiveTiles.DAL
{
    public class LiveTilesContext : DbContext
    {
        public LiveTilesContext()
            : base("LiveTilesContext8")
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<LiveTilesContext>());
        }

        public DbSet<Tile> Tile { get; set; }
        public DbSet<Calender> Calendar { get; set; }
        public DbSet<Newsfeed> Newsfeed { get; set; }
        public DbSet<Noticeboard> Noticeboard { get; set; }
        public DbSet<NoticeboardItem> NoticeboardItem { get; set; }
        public DbSet<CalendarItem> CalendarItem { get; set; }
        public DbSet<Twitter> Twitter { get; set; }

        public DbSet<TileLayout> TileLayout { get; set; }
        public DbSet<TileLayoutUserLink> TileLayoutUserLink { get; set; }
        public DbSet<UserAccount> UserAccount { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}