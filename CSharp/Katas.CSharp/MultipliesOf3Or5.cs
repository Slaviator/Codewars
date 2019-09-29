using System.Collections.Generic;
using System.Linq;

namespace Katas.CSharp
{
    public class MultipliesOf3Or5
    {
        public static int Solution(int value)
        {
            var multipliers = new HashSet<int>();

            for (var i = 1; i < value; i++)
            {
                if (i % 3 == 0)
                    multipliers.Add(i);
                if (i % 5 == 0)
                    multipliers.Add(i);
            }

            return multipliers.Sum();
        }
    }
}