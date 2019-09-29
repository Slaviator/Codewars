using System.Collections.Generic;
using System.Linq;

namespace Katas.CSharp
{
    public class Mumbling
    {
        public static string Accum(string input)
        {
            IEnumerable<char> characters = Preprocess(input);
            IEnumerable<string> characterGroups = characters.Select(ProcessCharacter);
            string output = CombineCharacterGroups(characterGroups);
            return output;
        }

        private static IEnumerable<char> Preprocess(string input)
        {
            return input.ToLowerInvariant().ToCharArray();
        }

        private static string ProcessCharacter(char character, int arrayPosition)
        {
            var realPosition = arrayPosition + 1;
            var charGroup = new List<char>(realPosition);
            for (var i = 0; i < realPosition; i++)
                charGroup.Add(i == 0 ? char.ToUpperInvariant(character) : character);
            return string.Concat(charGroup);
        }

        private static string CombineCharacterGroups(IEnumerable<string> charGroups)
        {
            return string.Join("-", charGroups);
        }
    }
}
