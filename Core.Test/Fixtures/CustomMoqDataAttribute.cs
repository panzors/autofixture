using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.NUnit3;
using Core.Models;
using Core.Service;
using Moq;

namespace Core.Test.Fixtures
{
    internal class CustomMoqDataAttribute: AutoDataAttribute
    {
        public CustomMoqDataAttribute()
            :this(null, false) { }

        public CustomMoqDataAttribute(string? flagName, bool state)
            : base(() => new Fixture()
            .Customize(new AutoMoqCustomization())
            .Customize(new Customizations())
            .Customize(new FeatureFlagCustomizations(flagName, state))
        )
        { 
        
        }
    }

    internal class FeatureFlagCustomizations : ICustomization
    {
        private string? flagName;
        private bool? state;

        public FeatureFlagCustomizations(string flagName, bool state)
        {
            this.flagName = flagName;
            this.state = state;
        }

        public void Customize(IFixture fixture)
        {
            fixture.Register(() =>
            {
                var mockedService = new Mock<IFeatureFlagService>();
                mockedService.Setup(x => x.IsEnabled(It.IsAny<string>())).Returns(false);

                if (flagName != null && state.HasValue)
                {
                    mockedService.Setup(x => x.IsEnabled(flagName)).Returns(state.Value);
                }

                return mockedService.Object;
            });
        }
    }


    internal class Customizations : ICustomization
    {
        public void Customize(IFixture fixture)
        {

            fixture.Register(() => 
            {
                return fixture.Build<Sample2>()
                    .Without(x => x.Items)
                    .Create();
            });

            fixture.Register(() =>
            {
                return fixture.Build<Sample3>()
                    .With(x => x.DescriptionTypes, Sample3.DescriptionType.Complex.ToString())
                    .Create();
            });
        }
    }
}
