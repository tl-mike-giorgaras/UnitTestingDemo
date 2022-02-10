using System.Collections.Generic;
using AutoFixture;
using AutoFixture.Xunit2;
using FluentAssertions;
using Moq;
using UnitTestingDemo.Controllers;
using UnitTestingDemo.Data;
using Xunit;

namespace UnitTestingDemo.UnitTests;

public class WeatherForecastControllerTests
{
    [Theory, AutoMoqData]
    public void Should_return_five_days(
        List<WeatherForecast> forecasts,
        //frozen to pin AutoFixture to this one instance of the mock
        [Frozen] Mock<IWeatherForecastProvider> providerMock,
        //greedy to use the constructor with the most parameters
        [Greedy] WeatherForecastController sut)
    {
        
        providerMock.Setup(x => x.GetWeatherForecasts(5))
            .Returns(forecasts).Verifiable();

        var result = sut.Get(5);
        
        providerMock.Verify();
        result.Should().BeEquivalentTo(forecasts);
    }
    
    [Theory]
    [InlineAutoMoqData(5)]
    [InlineAutoMoqData(3)]
    public void Should_return_X_days(
        //inline params always come first 
        int days,
        List<WeatherForecast> forecasts,
        [Frozen] Mock<IWeatherForecastProvider> providerMock,
        [Greedy] WeatherForecastController sut)
    {
        providerMock.Setup(x => x.GetWeatherForecasts(days))
            .Returns(forecasts).Verifiable();

        var result = sut.Get(days);
        
        providerMock.Verify();
        result.Should().BeEquivalentTo(forecasts);
    }
    
    [Theory, AutoMoqData]
    public void Should_return_five_days_no_deps(
        //no need to explicitly set mocks
        [Greedy] WeatherForecastController sut)
    {
        var result = sut.Get(5);

        result.Should().NotBeEmpty();
    }
    
    [Theory, AutoMoqData]
    public void Should_return_five_days_no_deps_customize_fixture(
        //can use autofixture to to customise only for this test
        IFixture fixture,
        [Greedy] WeatherForecastController sut)
    {
        fixture.Customize(new WeatherForecastCustomisation{MaxTemp = 10, MinTemp = -10});
        var result = sut.Get(5);

        result.Should().OnlyContain(x => x.TemperatureC <= 10 && x.TemperatureC >= -10);
    }
}