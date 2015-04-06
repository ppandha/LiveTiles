﻿using LiveTiles.DAL;
using LiveTiles.Models;
using System.Collections.Generic;
using System.Web.Mvc;
using Tweetinvi;
using Tweetinvi.Core.Interfaces.Credentials;

namespace LiveTiles.Controllers
{
    public class TileMainController : Controller
    {
        private LiveTilesContext db = new LiveTilesContext();

        // These are the keys needed for the twitter api. Obtained by registering on the twitter api website.
        // TweetInvi package is used to access the twitter api
        private const string secret = "LYphTmbmcChE8II99MH6ucGh39QIpcc59F0SCHet98L82apjFk";
        private const string key = "kljv3yj5FtxLEmAOwQ78x4XkG";

        // GET: TileMain
        public ActionResult Index(UserAccount userAccount)
        {
            // get data for this user account
            var userAccount1 = db.UserAccount.Find(userAccount.UserAccountId);

            return View(userAccount1);
        }

        public ActionResult GetView(int tileId)
        {
            var tile = db.Tile.Find(tileId);

            // which tile is it?

            if (tile.TileType == 1)
            {
                return PartialView("_NoticeBoardTilePartialView", tile as Noticeboard);
            }
            if (tile.TileType == 2)
            {
                return PartialView("_CalendarTilePartialView", tile as Calender);
            }
            if (tile.TileType == 3)
            {
                return PartialView("_NewsFeedTilePartialView", tile as Newsfeed);
            }
            if (tile.TileType == 4)
            {
                var twitterTile = tile as Twitter;
                var tweets = GetTweets(twitterTile);

                return PartialView("_TwitterTilePartialView", tweets);
            }

            return PartialView("_TilePartialView");
        }
        
        private List<TweetDisplay> GetTweets(Twitter tile)
        {
            var credentials = CreateApplicationCredentials(key, secret);

            // Setup your credentials
            TwitterCredentials.SetCredentials(credentials.AuthorizationKey, credentials.AuthorizationSecret,
                credentials.ConsumerKey, credentials.ConsumerSecret);

            // Search the tweets containing tweetinvi
            var items = Search.SearchTweets(tile.SearchCriteria);
            var results = new List<TweetDisplay>();

            foreach (var item in items)
            {
                var td = new TweetDisplay {Author = item.Creator.Name, Tweet = item.Text, ImageUrl = item.Creator.ProfileImageUrl};
                results.Add(td);
            }

            return results;
        }

        // This method shows you how to create Application credentials. 
        // This type of credentials do not take a AccessKey or AccessSecret.
        private ITemporaryCredentials CreateApplicationCredentials(string consumerKey, string consumerSecret)
        {
            return CredentialsCreator.GenerateApplicationCredentials(consumerKey, consumerSecret);
        }
    }
}