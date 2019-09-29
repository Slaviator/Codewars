using System.Collections.Generic;
using Katas.CSharp;
using Xunit;
using static Katas.CSharp.TicTacToe;

namespace Tests.CSharp
{
    public class TicTacToeTests
    {
        [Theory]
        [MemberData(nameof(Data))]
        public void Should(int expectedState, int winningLength, int[,] board)
        {
            var ticTacToe = new TicTacToe(board, winningLength);

            var actualState = ticTacToe.State;

            Assert.Equal(expectedState, actualState);
        }

        public static IEnumerable<object[]> Data =>
            new List<object[]>
            {
                new object[]
                {
                    XWin, 5, new[,]
                    {
                        {X},
                        {X},
                        {X},
                        {X},
                        {X},
                    }
                },
                new object[]
                {
                    XWin, 3, new[,]
                    {
                        {X, X},
                        {X, O},
                        {X, E}
                    }
                },
                new object[]
                {
                    XWin, 2, new[,]
                    {
                        {E, X},
                        {X, O},
                        {E, E}
                    }
                },
                new object[]
                {
                    OWin, 3, new[,]
                    {
                        {O, X, O},
                        {X, O, E},
                        {E, E, O}
                    }
                },
                new object[]
                {
                    OWin, 3, new[,]
                    {
                        {O, X, O},
                        {X, E, O},
                        {E, E, O}
                    }
                },
                new object[]
                {
                    NotFinished, 0, new[,]
                    {
                        {O, X, O},
                        {X, E, O},
                        {E, E, O}
                    }
                },
                new object[]
                {
                    Draw, 0, new[,]
                    {
                        {O, X, O},
                        {X, X, O},
                        {O, X, O}
                    }
                },
            };
    }
}