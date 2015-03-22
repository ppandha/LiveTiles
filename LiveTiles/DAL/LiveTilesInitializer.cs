using LiveTiles.Models;
using System;
using System.Collections.Generic;


namespace LiveTiles.DAL
{
    public class LiveTilesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<LiveTilesContext>
    {
        protected override void Seed(LiveTilesContext context)
        {
            var calenders = new List<Calender>
            {
            new Calender{ TileId = 1, Title = "test calander", Contents = "test calender contents", StartTime = new DateTime(2015,6,21), EndTime = new DateTime(2015,6,21)},
            new Calender{ TileId = 2, Title = "test calander 2", Contents = "test calender contents 2", StartTime = new DateTime(2015,7,21), EndTime = new DateTime(2015,8,21)},
            };

            calenders.ForEach(s => context.Calendar.Add(s));
            context.SaveChanges();

            var noticeboard = new List<Noticeboard>
            {
            new Noticeboard{ TileId = 3, Heading = "noticeboard heading 1", Contents = "noticeboard contents 1"},
            new Noticeboard{ TileId = 4, Heading = "noticeboard heading 2", Contents = "noticeboard contents 2"},
            };

            noticeboard.ForEach(s => context.Noticeboard.Add(s));
            context.SaveChanges();

            var newsfeed = new List<Newsfeed>
            {
            new Newsfeed{ TileId = 5, RssUrl = "rss1"},
            new Newsfeed{ TileId = 6, RssUrl = "rss2"},
            };

            newsfeed.ForEach(s => context.Newsfeed.Add(s));
            context.SaveChanges();

            var twitter = new List<Twitter>
            {
            new Twitter{ TileId = 7, SearchCriteria = "lord sugar"},
            new Twitter{ TileId = 8, SearchCriteria = "piers morgan"},
            };

            twitter.ForEach(s => context.Twitter.Add(s));
            context.SaveChanges();




            var tileLayout = new List<TileLayout>
            {
            new TileLayout{ TileLayoutId = 1, Description = "2 x 2", NumberOfTiles = 4},
            new TileLayout{ TileLayoutId = 2, Description = "2 x 1", NumberOfTiles = 3},
            new TileLayout{ TileLayoutId = 3, Description = "1 x 2", NumberOfTiles = 3}
            };

            tileLayout.ForEach(s => context.TileLayout.Add(s));
            context.SaveChanges();

            //var tileType = new List<TileType>
            //{
            //new TileType{ TileTypeId = 1, Type = "Noticeboard" },
            //new TileType{ TileTypeId = 2, Type = "Calendar" },
            //new TileType{ TileTypeId = 3, Type = "News" },
            //new TileType{ TileTypeId = 4, Type = "Twitter" }
            //};

            //tileType.ForEach(s => context.TileType.Add(s));
            //context.SaveChanges();

            var userAccount = new List<UserAccount>
            {
            new UserAccount{ UserAccountId = 1, OrgName = "Org1", OrgUnit = "OrgUnit1", Password = "abc", TileLayoutId = 1}
            };

            userAccount.ForEach(s => context.UserAccount.Add(s));
            context.SaveChanges();

            var tileLayoutUserLink = new List<TileLayoutUserLink>
            {
            new TileLayoutUserLink{ UserAccountId = 1, TileId = 1},
            new TileLayoutUserLink{ UserAccountId = 1, TileId = 3},
            new TileLayoutUserLink{ UserAccountId = 1, TileId = 5},
            new TileLayoutUserLink{ UserAccountId = 1, TileId = 7},
            };

            tileLayoutUserLink.ForEach(s => context.TileLayoutUserLink.Add(s));
            context.SaveChanges();


        }
    }
}