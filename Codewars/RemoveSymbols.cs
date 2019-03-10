using System.Text;

namespace Katas
{
    public class RemoveSymbols
    {
        public static string Remove(string input, int count, char symbol)
        {
            var outputSb = new StringBuilder(input.Length);
            var removed = 0;

            foreach (var currentSymbol in input)
            {
                if (currentSymbol == symbol && removed < count)
                {
                    removed++;
                    continue;
                }

                outputSb.Append(currentSymbol);
            }

            return outputSb.ToString();
        }
    }
}