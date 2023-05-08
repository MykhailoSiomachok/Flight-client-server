using Microsoft.AspNetCore.Mvc;

namespace Flight_client_server.Controllers
{
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }
    }
}