using Katas;
using Xunit;

namespace Tests
{
    public class DirectionsReductionTests
    {
        [Fact]
        public void Test1()
        {
            string[] input = { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" };
            string[] expected = { "WEST" };
            var actual = DirectionsReductionV3.Reduce(input);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Test2()
        {
            string[] input = { "NORTH", "WEST", "SOUTH", "EAST" };
            string[] expected = { "NORTH", "WEST", "SOUTH", "EAST" };
            var actual = DirectionsReductionV3.Reduce(input);
            Assert.Equal(expected, actual);
        }
    }
}
