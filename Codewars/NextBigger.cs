using System;
using System.Collections.Generic;
using System.Linq;

namespace Katas
{
    public static class NextBigger
    {
        public static long NextBiggerNumber(long input)
        {
            if (input < 0)
                throw new ArgumentOutOfRangeException();

            var inputArray = input.ToDigitArray();

            if (inputArray.Length < 2)
                return -1;

            var pivotIndexOrDefault = inputArray.GetPivotIndexOrDefault();

            if (pivotIndexOrDefault == default(int?))
                return -1;

            var pivotIndex = pivotIndexOrDefault.Value;

            var replacementIndex = inputArray.GetReplacementIndex(pivotIndex);

            var outputArray = inputArray.ReplacePivot(pivotIndex, replacementIndex);

            var body = outputArray.TakeBody(pivotIndex);

            var sortedTail = outputArray.SortTail(pivotIndex);

            return long.Parse(string.Concat(body.Concat(sortedTail)));
        }

        private static IEnumerable<char> TakeBody(this IEnumerable<char> inputArray, int pivotIndex)
        {
            return inputArray.Take(pivotIndex + 1);
        }

        private static IEnumerable<char> SortTail(this IEnumerable<char> inputArray, int pivotIndex)
        {
            return inputArray.Skip(pivotIndex + 1).OrderBy(c => c);
        }

        private static IReadOnlyCollection<char> ReplacePivot(this IEnumerable<char> inputArray, int pivotIndex, int replacementIndex)
        {
            var output = new List<char>(inputArray);
            var buf = output[pivotIndex];
            output[pivotIndex] = output[replacementIndex];
            output[replacementIndex] = buf;
            return output;
        }

        private static int GetReplacementIndex(this IReadOnlyList<char> inputArray, int pivotIndex)
        {
            var replacementIndex = inputArray
                .Select((c, i) => new {digit = c, index = i})
                .Skip(pivotIndex + 1)
                .Aggregate((p1, p2) => p2.digit > inputArray[pivotIndex] && p2.digit < p1.digit ? p2 : p1)
                .index;
            return replacementIndex;
        }

        private static int? GetPivotIndexOrDefault(this IReadOnlyList<char> inputArray)
        {
            for (var i = inputArray.Count - 2; i >= 0; i--)
            {
                if (inputArray[i] < inputArray[i + 1])
                {
                    return i;
                }
            }

            return default(int?);
        }

        private static char[] ToDigitArray(this long input)
        {
            return input
                .ToString()
                .ToCharArray();
        }
    }
}