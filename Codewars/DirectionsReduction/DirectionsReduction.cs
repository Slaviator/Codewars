using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public class DirectionsReduction
    {
        public static string[] Reduce(string[] input)
        {
            var inputPath = input
                .Select(direction => new Direction(direction))
                .ToList();

            var shortestPath = inputPath;
            for (;;)
            {
                var currentShortestPath = new List<Direction>();
                foreach (var nextDirection in shortestPath)
                {
                    var lastDirection = currentShortestPath.LastOrDefault();
                    if (nextDirection.IsOpposite(lastDirection))
                        currentShortestPath.RemoveAt(currentShortestPath.Count - 1);
                    else
                        currentShortestPath.Add(nextDirection);
                }

                if (currentShortestPath.Count < shortestPath.Count)
                    shortestPath = currentShortestPath;
                else break;
            }

            var output = shortestPath
                .Select(direction => direction.ToString())
                .ToArray();

            return output;
        }

        internal class Direction
        {
            private DirectionEnum Value { get; }

            public Direction(string direction)
            {
                Value = (DirectionEnum)Enum.Parse(typeof(DirectionEnum), direction);
            }

            public bool IsOpposite(Direction other)
            {
                if (other == null)
                    return false;

                return (int)Value + other.Value == 0;
            }

            public override bool Equals(object obj)
            {
                return obj is Direction other && other.Value == Value;
            }

            public override int GetHashCode()
            {
                return Value.GetHashCode();
            }

            public override string ToString()
            {
                return Value.ToString();
            }

            private enum DirectionEnum
            {
                NORTH = -1,
                SOUTH = 1,
                EAST = 2,
                WEST = -2,
            }
        }
    }
}