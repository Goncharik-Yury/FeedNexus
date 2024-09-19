using FeedNexus.Common.Enums;

namespace FeedNexus.Models;

public class RssSource
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Url { get; set; }
    public RssCategory Category { get; set; }
}

