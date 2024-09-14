using Microsoft.AspNetCore.Mvc;

namespace FeedNexus.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HomeController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello, FeedNexus API is running!");
    }
}
