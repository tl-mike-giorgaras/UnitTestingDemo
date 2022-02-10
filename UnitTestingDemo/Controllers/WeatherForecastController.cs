using Microsoft.AspNetCore.Mvc;
using UnitTestingDemo.Data;

namespace UnitTestingDemo.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{

    private readonly IWeatherForecastProvider _forecast;
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger, 
        IWeatherForecastProvider forecast, IHttpContextAccessor httpContextAccessor)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        _forecast = forecast ?? throw new ArgumentNullException(nameof(forecast));
        _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get(int days)
    {
        _logger.LogInformation("Forecast days hit");

        return _forecast.GetWeatherForecasts(days);
    }
}