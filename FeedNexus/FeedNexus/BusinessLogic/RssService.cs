using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections.Generic;
using System.Linq;
using FeedNexus.Models;

namespace FeedNexus.BusinessLogic;

public class RssService
{
    private readonly HttpClient _httpClient;

    public RssService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<RssItem>> GetRssFeedAsync(string url)
    {
        var response = await _httpClient.GetStringAsync(url);

        var rssXml = XDocument.Parse(response);

        var items = rssXml.Descendants("item")
            .Select(x => new RssItem
            {
                Title = (string)x.Element("title"),
                Link = (string)x.Element("link"),
                Description = (string)x.Element("description"),
                PubDate = DateTime.Parse((string)x.Element("pubDate"))
            })
            .ToList();

        return items;
    }
}

