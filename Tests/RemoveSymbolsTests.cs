using Katas;
using Xunit;

namespace Tests
{
    public class RemoveSymbolsTests
    {
        [Theory]
        [InlineData("Hi!", 1, '!', "Hi")]
        [InlineData("Hi!", 100, '!', "Hi")]
        [InlineData("Hi!!!", 1, '!', "Hi!!")]
        [InlineData("Hi!!!", 100, '!', "Hi")]
        [InlineData("!Hi", 1, '!', "Hi")]
        [InlineData("!Hi!", 1, '!', "Hi!")]
        [InlineData("!Hi!", 100, '!', "Hi")]
        [InlineData("!!!Hi !!hi!!! !hi", 1, '!', "!!Hi !!hi!!! !hi")]
        [InlineData("!!!Hi !!hi!!! !hi", 3, '!', "Hi !!hi!!! !hi")]
        [InlineData("!!!Hi !!hi!!! !hi", 5, '!', "Hi hi!!! !hi")]
        [InlineData("!!!Hi !!hi!!! !hi", 100, '!', "Hi hi hi")]
        public void Should(string input, int count, char symbol, string output)
        {
            Assert.Equal(output, RemoveSymbols.Remove(input, count, symbol));
        }
    }
}