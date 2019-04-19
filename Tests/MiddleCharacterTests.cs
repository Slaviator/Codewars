using Katas.CSharp;
using Xunit;

namespace Tests.CSharp
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
