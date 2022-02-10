using System.Linq;
using FluentAssertions;
using UnitTestingDemo.Data;
using Xunit;

namespace UnitTestingDemo.UnitTests;

public class WeatherForecastProviderTests
{
    [Theory, AutoMoqData]
    public void Should_return_the_right_number_of_forecasts(
        int days,
        WeatherForecastProvider sut)
    {
        var result = sut.GetWeatherForecasts(days);

        result.Count().Should().Be(days);
    }
}