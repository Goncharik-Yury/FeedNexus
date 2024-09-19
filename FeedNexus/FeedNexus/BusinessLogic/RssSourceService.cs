using FeedNexus.Common.Enums;
using FeedNexus.Models;

namespace FeedNexus.BusinessLogic
{
    public class RssSourceService
    {
        private readonly List<RssSource> _rssSources;

        public RssSourceService()
        {
            _rssSources = new List<RssSource>
            {
                new RssSource { Name = "BBC News", Url = "https://feeds.bbci.co.uk/news/rss.xml", Category = RssCategory.NewsAndMedia },
                new RssSource { Name = "CNN", Url = "http://rss.cnn.com/rss/edition.rss", Category = RssCategory.NewsAndMedia },
                new RssSource { Name = "TechCrunch", Url = "http://feeds.feedburner.com/TechCrunch/", Category = RssCategory.Technology },
                new RssSource { Name = "The Verge", Url = "https://www.theverge.com/rss/index.xml", Category = RssCategory.Technology },
                new RssSource { Name = "Stack Overflow Blog", Url = "https://stackoverflow.blog/feed/", Category = RssCategory.Development },
                new RssSource { Name = "Smashing Magazine", Url = "https://www.smashingmagazine.com/feed/", Category = RssCategory.Development }
            };
        }

        public List<RssSource> GetRssSources()
        {
            return _rssSources;
        }
    }

}
