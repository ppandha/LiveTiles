using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Xml.Linq;

namespace LiveTiles.ViewModels
{
    public class RssNews
    {
        public string Title;
        public string PublicationDate;
        public string Description;
    }

    public class RssReader
    {
        public static List<RssNews> Read(string url)
        {
            // use webClient (.NET library) to make request 
            var webClient = new WebClient();
            // get the news feed in an XML string.
            var result = webClient.DownloadString(url);

            // use .NET XML library to parse the resulting XML string.
            var document = XDocument.Parse(result);

            // turn the XML results into a list of news items, take only the most recent 5 items
            return (from descendant in document.Descendants("item")
                    select new RssNews()
                    {
                        Description = descendant.Element("description").Value,
                        Title = descendant.Element("title").Value,
                        PublicationDate = descendant.Element("pubDate").Value
                    }).OrderByDescending(a=>a.PublicationDate).Take(5).ToList();
        }
    }
}

