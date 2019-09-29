using System.Collections.Generic;
using System.Linq;

namespace Katas.CSharp
{
    public class DirectionsReductionV4
    {
        public static string[] Reduce(string[] input)
        {
            var shortestPath = new Stack<string>();
            foreach (var nextDirection in input)
            {
                if (!shortestPath.Any())
                {
                    shortestPath.Push(nextDirection);
                    continue;
                }

                var lastDirection = shortestPath.Peek();
                if (AreOpposite(nextDirection,lastDirection))
                    shortestPath.Pop();
                else
                    shortestPath.Push(nextDirection);
            }

            var output = shortestPath
                .Reverse()
                .ToArray();

            return output;
        }

        private static bool AreOpposite(string first, string second)
        {
            return first.Length == second.Length && !string.Equals(first, second);
        }
    }
}