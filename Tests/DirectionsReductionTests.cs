using System;
using System.Collections.Generic;
using Katas.CSharp;
using Xunit;

namespace Tests.CSharp
{
    public class DirectionsReductionTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Should(string[] input, string[] expected)
            => AssertAll(input, expected);

        private static void AssertAll(string[] input, string[] expected)
        {
            foreach (var reduce in new List<Func<string[], string[]>>
            {
                DirectionsReduction.Reduce,
                DirectionsReductionV2.Reduce,
                DirectionsReductionV3.Reduce,
                DirectionsReductionV4.Reduce,
            }) Assert.Equal(expected, reduce(input));
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    new[] {"NORTH", "WEST", "SOUTH", "EAST"},
                    new[] {"NORTH", "WEST", "SOUTH", "EAST"},
                },
                new object[]
                {
                    new[] { "NORTH", "SOUTH", "SOUTH", "EAST", "WEST", "NORTH", "WEST" },
                    new[] { "WEST" },
                },
            };
    }
}
