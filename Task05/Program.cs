using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task05
{
    static class Program
    {
        private static int ticketLength;
        private static int numSystemBase;

        static void Main()
        {
            Console.WriteLine("Please, enter even length of ticket number:");
            ticketLength = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the base of numeral system " +
                "(amount of unique digits):");
            numSystemBase = Convert.ToInt32(Console.ReadLine());

            using (var sw = new StreamWriter(@"..\\..\\ANSWER.md"))
            {
                sw.WriteLine(CountLuckyTickets());
            }
        }

        private static int CountLuckyTickets()
        {
            // Amounts of all possible numbers of 1..ticketLength/2 digits
            // with sum of digits equal 0..maxSumOfDigits.
            var amounts = new List<List<int>>();
            var maxDigit = numSystemBase - 1;
            for (var n = 0; n < ticketLength / 2; n++)
            {
                var maxSumOfDigits = (n + 1) * maxDigit;
                if (n == 0)
                {
                    // Initialize amounts for numbers of 1 digit.
                    var oneDigitNumbers = new List<int>(
                        new int[numSystemBase]).Select(i => 1).ToList();
                    amounts.Add(oneDigitNumbers);
                }
                else
                {
                    // Count amounts for numbers of n digits.
                    amounts.Add(new List<int>());
                    var sum = 0;
                    for (var k = 0; k <= maxSumOfDigits; k++)
                    {
                        if (k < amounts[n - 1].Count)
                        {
                            sum += amounts[n - 1][k];
                        }
                        if (k >= numSystemBase)
                        {
                            sum -= amounts[n - 1][k - numSystemBase];
                        }
                        amounts[n].Add(sum);
                    }
                }
            }
            return amounts.Last().Sum(item => item * item);
        }
    }
}
