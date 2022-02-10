using System;
using AutoFixture;

namespace UnitTestingDemo.UnitTests;

public class WeatherForecastCustomisation : ICustomization
{
    public int MinTemp { get; init; } = -40;
    public int MaxTemp { get; init; } = 60;

    //hook you can use to customise your fixture
    public void Customize(IFixture fixture)
    {
        //for any object of type WeatherForecast this creator method will be used
        fixture.Register(() =>
            new WeatherForecast(fixture.Create<DateTime>(), Random.Shared.Next(MinTemp, MaxTemp), fixture.Create<string>()));
    }
}