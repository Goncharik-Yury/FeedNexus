using FeedNexus.Models;
using Microsoft.EntityFrameworkCore;

namespace FeedNexus.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<RssFeed> RssFeeds { get; set; }
}
