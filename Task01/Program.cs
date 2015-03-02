using System;
using System.IO;
using System.Numerics;

namespace Task01
{
    static class Program
    {
        const int SecondsInHour = 3600;

        static void Main()
        {
            Console.WriteLine("Please, enter the number of girls:");
            var girlsCount = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the time in seconds for one arrangement:");
            var secondsPerPermutation = Convert.ToInt32(Console.ReadLine());

            // The number of permutations of n distinct objects is n factorial.
            BigInteger permutationCount = 1;
            for (var i = girlsCount; i > 0; i--)
            {
                permutationCount *= i;
            }

            BigInteger elapsedHours = permutationCount *
                secondsPerPermutation / SecondsInHour;

            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.Write(elapsedHours.ToString());
            }
        }
    }
}
