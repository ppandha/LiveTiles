using LiveTiles.Models;
using System.Collections.Generic;
using System.Linq;
using Tweetinvi;

namespace LiveTiles.ViewModels
{
    public class TwitterReader
    {
        // These are the keys needed for the twitter api. Obtained by registering on the twitter api website.
        // TweetInvi package is used to access the twitter api
        private const string consumerSecret = "LYphTmbmcChE8II99MH6ucGh39QIpcc59F0SCHet98L82apjFk";
        private const string consumerKey = "kljv3yj5FtxLEmAOwQ78x4XkG";

        public static List<TweetDisplay> GetTweets(string searchCriteria)
        {
            // initialise a Credentials object with the keys supplied by the twitter api registration
            var credentials = CredentialsCreator.GenerateApplicationCredentials(consumerKey, consumerSecret);

            // tell twitter our credentials
            TwitterCredentials.SetCredentials(credentials.AuthorizationKey, credentials.AuthorizationSecret,
                credentials.ConsumerKey, credentials.ConsumerSecret);

            // Search the tweets containing the search criteria and create a list to display in the view, only use top 4
            var items = Search.SearchTweets(searchCriteria).OrderByDescending( a => a.CreatedAt ).ToList().Take(4);

            // create an empty list
            var results = new List<TweetDisplay>();

            // Make a list of tweet items for using in the view
            foreach(var item in items)  
            {
                var td = new TweetDisplay
                {
                    CreatedAt = item.CreatedAt,
                    Author = item.Creator.Name,
                    Tweet = item.Text,
                    ImageUrl = item.Creator.ProfileImageUrl
                };

                results.Add(td);
            }

            return results;
        }
    }
}