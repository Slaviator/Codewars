namespace Katas
{
    public class MiddleCharacter
    {
        public static string GetMiddle(string input)
        {
            var middleIndex = input.Length / 2;
            return input.Length % 2 == 0
                ? $"{input[middleIndex - 1]}{input[middleIndex]}"
                : $"{input[middleIndex]}";
        }
    }
}