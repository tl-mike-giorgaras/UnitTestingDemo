namespace UnitTestingDemo;

public record WeatherForecast
{
    public DateTime Date { get; }
    public int TemperatureC { get; }
    public string? Summary { get; }

    public WeatherForecast(DateTime date, int temperatureC, string? summary)
    {
        if (temperatureC > 60) throw new ArgumentOutOfRangeException(nameof(temperatureC));
        if (temperatureC < -40) throw new ArgumentOutOfRangeException(nameof(temperatureC));

        
        Date = date;
        TemperatureC = temperatureC;
        Summary = summary;
    }
    
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}