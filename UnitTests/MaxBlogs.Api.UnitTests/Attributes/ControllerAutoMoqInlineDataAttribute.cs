using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Kernel;
using AutoFixture.Xunit2;
using Microsoft.AspNetCore.Mvc;

namespace MaxBlogs.Api.UnitTests.Attributes;
internal class ControllerAutoMoqInlineDataAttribute : InlineAutoDataAttribute
{
    public ControllerAutoMoqInlineDataAttribute(params object[] values) : base(new AutoMoqAttribute(), values)
    {
    }

    private class AutoMoqAttribute : AutoDataAttribute
    {
        public AutoMoqAttribute() : base(FixtureFactory)
        {
        }
        private static IFixture FixtureFactory()
        {
            var fixture = new Fixture();
            fixture.Customize(new CompositeCustomization(
                new AspNetCustomization(),
                new AutoMoqCustomization { ConfigureMembers = true }
                ));
            return fixture;
        }
    }
    private class AspNetCustomization : ICustomization
    {
        public void Customize(IFixture fixture)
        {
            fixture.Customizations.Add(new ControllerBasePropertyOmitter());
        }
    }

    private class ControllerBasePropertyOmitter : Omitter
    {
        internal ControllerBasePropertyOmitter()
            : base(new OrRequestSpecification(GetPropertySpecifications()))
        {
        }

        private static IEnumerable<IRequestSpecification> GetPropertySpecifications()
        {
            return typeof(ControllerBase).GetProperties().Where(x => x.CanWrite)
                .Select(x => new PropertySpecification(x.PropertyType, x.Name));
        }
    }
}

