using AutoFixture;
using AutoFixture.AutoMoq;
using AutoFixture.Xunit2;

namespace Common.UnitTestsC;

public class AutoMoqInlineDataAttribute : InlineAutoDataAttribute
{
    public AutoMoqInlineDataAttribute(params object[] values) : base(new AutoMoqAttribute(), values)
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
            fixture.Customize(new AutoMoqCustomization { ConfigureMembers = true });
            return fixture;
        }
    }
}
