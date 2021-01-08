using Xunit;

namespace KataBaseXunit.App.Tests
{
    public class Tests
    {
        [Fact]
        public void FooShouldGiveBar()
        {
            Assert.Equal("bar", new Class1().Foo());
        }
    }
}