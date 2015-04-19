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

            // Search the tweets containing the user id and create a list to display in the view
            var items = Search.SearchTweets(searchCriteria).OrderBy( a => a.CreatedAt ).ToList();
            var results = new List<TweetDisplay>();

            // Make a list of tweet items for using in the view
            for (int i = 0; i < items.Count(); i++)
            {
                // only use the first 5 items
                if (i > 4) break;

                var item = items[i];
                var td = new TweetDisplay
                {
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