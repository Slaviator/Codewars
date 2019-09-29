using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas.CSharp
{
    public class TicTacToe
    {
        public const int NotFinished = -1;
        public const int XWin = 1;
        public const int OWin = 2;
        public const int Draw = 0;

        public const int X = 1;
        public const int O = 2;
        public const int E = 0;

        // main kata
        public TicTacToe() { }

        public int IsSolved(int[,] board) => new TicTacToe(board, 3).State;
        //

        // any size, any length
        public TicTacToe(int[,] board, int winningLength)
        {
            WinningLength = winningLength;
            Board = board ?? throw new ArgumentNullException(nameof(board));
        }

        public int WinningLength { get; }
        public int[,] Board { get; }

        public int RowCount => Board.GetLength(0);
        public int ColumnCount => Board.GetLength(1);

        public int State
        {
            get
            {
                for (var row = 0; row < RowCount; row++)
                for (var column = 0; column < ColumnCount; column++)
                {
                    var winner = WinnerOrDefault(row, column);
                    if (winner != default(int?))
                        return winner.Value;
                }

                return HasEmptyCells ? NotFinished : Draw;
            }
        }

        private bool HasEmptyCells
            => Board.Cast<int>().Any(value => value == E);

        private int? WinnerOrDefault(int row, int column)
            => WinnerOrDefault(HorizontalOrDefault(row, column))
               ?? WinnerOrDefault(VerticalOrDefault(row, column))
               ?? WinnerOrDefault(ForwardDiagonalOrDefault(row, column))
               ?? WinnerOrDefault(BackDiagonalOrDefault(row, column));

        private IReadOnlyCollection<int> BackDiagonalOrDefault(int row, int column)
        {
            if (row + WinningLength > RowCount
                || WinningLength - 1 > column)
                return null;

            var values = new List<int>(WinningLength);
            for (var i = 0; i < WinningLength; i++)
                values.Add(Board[row + i, column - i]);

            return values;
        }

        private IReadOnlyCollection<int> ForwardDiagonalOrDefault(int row, int column)
        {
            if (row + WinningLength > RowCount
                || column + WinningLength > ColumnCount)
                return null;

            var values = new List<int>(WinningLength);
            for (var i = 0; i < WinningLength; i++)
                values.Add(Board[row + i, column + i]);

            return values;
        }

        private IReadOnlyCollection<int> VerticalOrDefault(int row, int column)
        {
            if (column + WinningLength > ColumnCount)
                return null;

            var values = new List<int>(WinningLength);
            for (var k = 0; k < WinningLength; k++)
                values.Add(Board[row, column + k]);

            return values;
        }

        private IReadOnlyCollection<int> HorizontalOrDefault(int row, int column)
        {
            if (row + WinningLength > RowCount)
                return null;

            var values = new List<int>(WinningLength);
            for (var i = 0; i < WinningLength; i++)
                values.Add(Board[row + i, column]);

            return values;
        }

        private int? WinnerOrDefault(IReadOnlyCollection<int> values)
        {
            var first = values?.FirstOrDefault();
            return !first.HasValue || first == E
                ? default(int?)
                : values.All(value => value == first)
                    ? first
                    : default(int?);
        }
    }
}