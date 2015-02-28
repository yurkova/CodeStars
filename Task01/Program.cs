using System.IO;
using System.Numerics;

namespace Task01
{
    static class Program
    {
        const int GirlsCount = 104;
        const int SecondsPerPermutation = 10;
        const int SecondsInHour = 3600;

        static void Main()
        {
            // The number of permutations of n distinct objects is n factorial.
            BigInteger permutationCount = 1;
            for (var i = GirlsCount; i > 0; i--)
            {
                permutationCount *= i;
            }

            BigInteger elapsedHours = permutationCount *
                SecondsPerPermutation / SecondsInHour;

            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.Write(elapsedHours.ToString());
            }
        }
    }
}
