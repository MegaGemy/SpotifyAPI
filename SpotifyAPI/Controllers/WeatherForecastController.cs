using Microsoft.AspNetCore.Mvc;
using SpotifyAPI.Models;
namespace SpotifyAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SpotifyController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<SpotifyController> _logger;

        public SpotifyController(ILogger<SpotifyController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSpotifyConcerts")]
        public Task<List<EventsDto>> GetAllConcerts()
        {
            return SpotifyApiAppService.GetAllConcerts();
        }
    }
}