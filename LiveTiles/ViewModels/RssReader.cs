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
            var webClient = new WebClient();

            var result = webClient.DownloadString(url);

            var document = XDocument.Parse(result);

            // turn the XML results into a list of news items, take only the first 5 items
            return (from descendant in document.Descendants("item")
                    select new RssNews()
                    {
                        Description = descendant.Element("description").Value,
                        Title = descendant.Element("title").Value,
                        PublicationDate = descendant.Element("pubDate").Value
                    }).Take(5).ToList();
        }
    }
}

