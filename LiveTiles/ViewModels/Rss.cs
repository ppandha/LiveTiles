using System.Xml.Linq;

namespace LiveTiles.ViewModels
{
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Net;

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

            string result = webClient.DownloadString(url);

            XDocument document = XDocument.Parse(result);

            return (from descendant in document.Descendants("item")
                    select new RssNews()
                    {
                        Description = descendant.Element("description").Value,
                        Title = descendant.Element("title").Value,
                        PublicationDate = descendant.Element("pubDate").Value
                    }).ToList();
        }

        public static List<RssNews> Read1(string url)
        {
            var webResponse = WebRequest.Create(url).GetResponse();

            if (webResponse == null)
                return null;

            var ds = new DataSet();
            ds.ReadXml(webResponse.GetResponseStream());

            var news = (from row in ds.Tables["item"].AsEnumerable()
                        select new RssNews
                        {
                            Title = row.Field<string>("title"),
                            PublicationDate = row.Field<string>("pubDate"),
                            Description = row.Field<string>("description")
                        }).ToList();
            return news;
        }
    }
}

