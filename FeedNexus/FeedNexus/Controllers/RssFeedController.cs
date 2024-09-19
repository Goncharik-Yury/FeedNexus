using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using FeedNexus.Models;
using FeedNexus.Data;
using Microsoft.EntityFrameworkCore;
using FeedNexus.DTO;
using FeedNexus.BusinessLogic;

namespace FeedNexus.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RssFeedController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly RssService _rssService;

        public RssFeedController(ApplicationDbContext context, RssService rssService)
        {
            _context = context;
            _rssService = rssService;
        }

        [HttpGet]
        public async Task<IActionResult> GetRssFeeds()
        {
            var rssFeeds = await _context.RssFeeds.ToListAsync();
            return Ok(rssFeeds);
        }

        [HttpGet("{url}")]
        public async Task<ActionResult<List<RssItem>>> GetRssFeed(string url)
        {
            try
            {
                var rssItems = await _rssService.GetRssFeedAsync(url);
                return Ok(rssItems);
            }
            catch (HttpRequestException ex)
            {
                return BadRequest($"Error retrieving RSS feed: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRssFeed([FromBody] RssFeedDto rssFeedDto)
        {
            if (rssFeedDto == null || string.IsNullOrEmpty(rssFeedDto.Url))
                return BadRequest("Invalid data.");

            var rssFeed = new RssFeed
            {
                Title = rssFeedDto.Title,
                Url = rssFeedDto.Url,
                CreatedAt = DateTime.UtcNow
            };

            _context.RssFeeds.Add(rssFeed);
            await _context.SaveChangesAsync();

            return Ok(rssFeed);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRssFeed(int id, [FromBody] RssFeedDto rssFeedDto)
        {
            if (rssFeedDto == null || string.IsNullOrEmpty(rssFeedDto.Url))
                return BadRequest("Invalid data.");

            var rssFeed = await _context.RssFeeds.FindAsync(id);
            if (rssFeed == null)
                return NotFound();

            rssFeed.Title = rssFeedDto.Title;
            rssFeed.Url = rssFeedDto.Url;

            await _context.SaveChangesAsync();

            return Ok(rssFeed);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRssFeed(int id)
        {
            var rssFeed = await _context.RssFeeds.FindAsync(id);
            if (rssFeed == null)
                return NotFound();

            _context.RssFeeds.Remove(rssFeed);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
