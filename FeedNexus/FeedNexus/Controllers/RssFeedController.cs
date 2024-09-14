using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FeedNexus.Models;
using FeedNexus.Data;
using Microsoft.EntityFrameworkCore;

namespace FeedNexus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssFeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public RssFeedController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> AddRssFeed([FromBody] RssFeed rssFeed)
        {
            if (rssFeed == null || string.IsNullOrEmpty(rssFeed.Url))
                return BadRequest("Invalid data.");

            rssFeed.CreatedAt = DateTime.UtcNow;

            _context.RssFeeds.Add(rssFeed);
            await _context.SaveChangesAsync();

            return Ok(rssFeed);
        }

        [HttpGet]
        public async Task<IActionResult> GetRssFeeds()
        {
            var rssFeeds = await _context.RssFeeds.ToListAsync();
            return Ok(rssFeeds);
        }
    }
}
