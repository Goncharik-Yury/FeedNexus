using FeedNexus.BusinessLogic;
using FeedNexus.Common.Enums;
using Microsoft.AspNetCore.Mvc;

namespace FeedNexus.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RssSourceController : ControllerBase
    {
        private readonly RssSourceService _rssSourceService;

        public RssSourceController(RssSourceService rssSourceService)
        {
            _rssSourceService = rssSourceService;
        }

        [HttpGet]
        public IActionResult GetRssSources()
        {
            var sources = _rssSourceService.GetRssSources();
            return Ok(sources);
        }

        [HttpGet("category/{category}")]
        public IActionResult GetRssSourcesByCategory(RssCategory category)
        {
            var sources = _rssSourceService.GetRssSources()
                            .Where(s => s.Category == category)
                            .ToList();
            return Ok(sources);
        }
    }

}
