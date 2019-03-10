using Katas;
using Xunit;

namespace Tests
{
    public class MiddleCharacterTests
    {
        [Theory]
        [InlineData("1234", "23")]
        [InlineData("ABC", "B")]
        public void Should(string input, string output)
        {
            Assert.Equal(output, MiddleCharacter.GetMiddle(input));
        }
    }
}
