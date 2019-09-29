using Katas.CSharp;
using Xunit;

namespace Tests.CSharp
{
    public class NextBiggerTests
    {
        [Theory]
        [InlineData(12, 21)]
        [InlineData(513, 531)]
        [InlineData(2017, 2071)]
        [InlineData(414, 441)]
        [InlineData(144, 414)]
        [InlineData(9, -1)]
        [InlineData(9876543210, -1)]
        public void Should(long input, long output)
        {
            Assert.Equal(output, NextBigger.NextBiggerNumber(input));
        }
    }
}