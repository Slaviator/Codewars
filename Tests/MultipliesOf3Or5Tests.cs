using Katas;
using Xunit;

namespace Tests
{
    public class MultipliesOf3Or5Tests
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(10, 23)]
        public void Should(int input, int expected)
        {
            var actual = MultipliesOf3Or5.Solution(input);
            Assert.Equal(expected, actual);
        }
    }
}
