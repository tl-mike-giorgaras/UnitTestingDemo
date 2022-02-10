using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace UnitTestingDemo.UnitTests;

public class AutoMoqDataAttribute : AutoDataAttribute
{
    
        public AutoMoqDataAttribute()
            : base(new Fixture()
                //your own customisations if your objects have more complex constructors 
                .Customize(new WeatherForecastCustomisation {MinTemp = -30, MaxTemp = 55})
                //AutoMoqCustomization to autogenerate mock and substitute them for interfaces
                //ConfigureMembers = true to auto-setup the methods of the mock 
                .Customize(new AutoMoqCustomization{ConfigureMembers = true})
            )
        {
        }
}

public class InlineAutoMoqDataAttribute : InlineAutoDataAttribute
{
    
    public InlineAutoMoqDataAttribute(params object[] objects) : base(new AutoMoqDataAttribute(), objects)
    {

    } 
}