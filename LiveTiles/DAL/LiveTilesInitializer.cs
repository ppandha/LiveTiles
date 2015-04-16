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
            new Calender{ TileId = 1, TileType = 2, Title = "test calender 1", RefreshPeriod = 0},
            new Calender{ TileId = 2, TileType = 2, Title = "test calender 2", RefreshPeriod = 0},
            };

            calenders.ForEach(s => context.Calendar.Add(s));
            context.SaveChanges();

            var calenderItems = new List<CalendarItem>
            {
            new CalendarItem{ CalendarItemId = 1, CalendarId = 1, Content = "test calender contents 1", Location = "Home", StartTime = new DateTime(2015,6,21), EndTime = new DateTime(2015,6,21)},
            new CalendarItem{ CalendarItemId = 1, CalendarId = 1, Content = "test calender contents 2", Location = "Away", StartTime = new DateTime(2015,1,21), EndTime = new DateTime(2015,2,2)},
            };

            calenderItems.ForEach(s => context.CalendarItem.Add(s));
            context.SaveChanges();


            var noticeboard = new List<Noticeboard>
            {
            new Noticeboard{ TileId = 3, TileType = 1, Title = "noticeboard heading 1", RefreshPeriod = 5},
            new Noticeboard{ TileId = 4, TileType = 1, Title = "noticeboard heading 2", RefreshPeriod = 5},
            };

            noticeboard.ForEach(s => context.Noticeboard.Add(s));
            context.SaveChanges();

            var noticeboarditems = new List<NoticeboardItem>
            {
                new NoticeboardItem{ NoticeboardId = 3, NoticeboardItemId = 1, Content = "<h1>Notice 1<h1><h2>content<h2>"},
                new NoticeboardItem{ NoticeboardId = 3, NoticeboardItemId = 2, Content = "<h1>Notice 2<h1><h2>more content<h2>"}
            };
            noticeboarditems.ForEach(s => context.NoticeboardItem.Add(s));
            context.SaveChanges();

            var newsfeed = new List<Newsfeed>
            {
            new Newsfeed{ TileId = 5, TileType = 3, Title = "newsfeed 1", RefreshPeriod = 0, RssUrl = "http://news.google.com/?output=rss"},
            new Newsfeed{ TileId = 6, TileType = 3, Title = "newsfeed 1", RefreshPeriod = 0, RssUrl = "http://news.google.com/?output=rss"},
            };

            newsfeed.ForEach(s => context.Newsfeed.Add(s));
            context.SaveChanges();

            var twitter = new List<Twitter>
            {
            new Twitter{ TileId = 7, TileType = 4, Title = "twitter feed 1", RefreshPeriod = 0, SearchCriteria = "lord sugar"},
            new Twitter{ TileId = 8, TileType = 4, Title = "twitter feed 2", RefreshPeriod = 0, SearchCriteria = "piers morgan"},
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

            var userAccount = new List<UserAccount>
            {
            new UserAccount{ UserAccountId = 1, OrgName = "Org1", OrgUnit = "OrgUnit1", TileLayoutId = 1},
            new UserAccount{ UserAccountId = 2, OrgName = "Org2", OrgUnit = "OrgUnit2", TileLayoutId = 2}
            };

            userAccount.ForEach(s => context.UserAccount.Add(s));
            context.SaveChanges();

            var tileLayoutUserLink = new List<TileLayoutUserLink>
            {
            new TileLayoutUserLink{ UserAccountId = 1, TileId = 1},
            new TileLayoutUserLink{ UserAccountId = 1, TileId = 3},
            new TileLayoutUserLink{ UserAccountId = 1, TileId = 5},
            new TileLayoutUserLink{ UserAccountId = 1, TileId = 7},
            new TileLayoutUserLink{ UserAccountId = 2, TileId = 1},
            new TileLayoutUserLink{ UserAccountId = 2, TileId = 3},
            new TileLayoutUserLink{ UserAccountId = 2, TileId = 5}
            };

            tileLayoutUserLink.ForEach(s => context.TileLayoutUserLink.Add(s));
            context.SaveChanges();
        }
    }
}