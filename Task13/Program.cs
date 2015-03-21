using System;
using System.IO;

namespace Task13
{
    internal static class Program
    {
        private static void Main()
        {
            var bricksCount = 0;
            Console.WriteLine("Please, enter the number of stairs:");
            var stairsCount = Convert.ToInt32(Console.ReadLine());
            for (var i = 1; i <= stairsCount; i++)
            {
                bricksCount += i;
            }
            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.WriteLine(bricksCount);
            }
        }
    }
}