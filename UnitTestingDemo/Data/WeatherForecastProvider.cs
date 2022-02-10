namespace UnitTestingDemo.Data;

public interface IWeatherForecastProvider
{
    IEnumerable<WeatherForecast> GetWeatherForecasts(int days);
}

public class WeatherForecastProvider : IWeatherForecastProvider
{
    private static readonly string[] Summaries = {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastProvider> _logger;

    public WeatherForecastProvider(ILogger<WeatherForecastProvider> logger)
    {
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public IEnumerable<WeatherForecast> GetWeatherForecasts(int days)
    {
        _logger.LogInformation("Returning forecast for {ForecastDays} days", days.ToString());

        return Enumerable.Range(1, days).Select(index => new WeatherForecast(DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55), Summaries[Random.Shared.Next(Summaries.Length)]));
    }
}