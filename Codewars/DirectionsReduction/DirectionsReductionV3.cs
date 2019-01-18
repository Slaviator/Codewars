using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public class DirectionsReductionV3
    {
        public static string[] Reduce(string[] input)
        {
            var inputPath = input
                .Select(direction => new Direction(direction))
                .ToList();

            var shortestPath = new Stack<Direction>();
            foreach (var nextDirection in inputPath)
            {
                if (!shortestPath.Any())
                {
                    shortestPath.Push(nextDirection);
                    continue;
                }

                var lastDirection = shortestPath.Peek();
                if (nextDirection.IsOpposite(lastDirection))
                    shortestPath.Pop();
                else
                    shortestPath.Push(nextDirection);
            }

            var output = shortestPath
                .Select(direction => direction.ToString())
                .Reverse()
                .ToArray();

            return output;
        }

        private class Direction
        {
            private static readonly Direction North = new Direction("NORTH");
            private static readonly Direction South = new Direction("SOUTH");
            private static readonly Direction East = new Direction("EAST");
            private static readonly Direction West = new Direction("WEST");

            private static readonly Dictionary<Direction, Direction> OppositeDirectionsMap =
                new Dictionary<Direction, Direction>
                {
                    {North, South},
                    {South, North},
                    {East, West},
                    {West, East},
                };

            private static readonly HashSet<string> ValidDirectionStrings =
                new HashSet<string>(new List<Direction> {North, South, East, West}.Select(d => d.DirectionString));

            public Direction(string direction)
            {
                if (ValidDirectionStrings != null && !ValidDirectionStrings.Contains(direction))
                    throw new ArgumentOutOfRangeException(nameof(direction), direction, "Unknown direction");

                DirectionString = direction;
            }

            private string DirectionString { get; }

            public bool IsOpposite(Direction other)
            {
                return OppositeDirectionsMap[this].Equals(other);
            }

            public override bool Equals(object obj)
            {
                return obj is Direction other && Equals(other);
            }

            public bool Equals(Direction other)
            {
                return other.DirectionString == DirectionString;
            }

            public override int GetHashCode()
            {
                return DirectionString.GetHashCode();
            }

            public override string ToString()
            {
                return DirectionString;
            }
        }
    }
}