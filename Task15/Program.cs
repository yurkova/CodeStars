using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task15
{
    internal static class Program
    {
        private static void Main()
        {
            var inputData = new List<List<int>>();
            Console.WriteLine("Please, enter the path to input file:");
            var path = Console.ReadLine();
            if (path != null)
            {
                using (var sr = new StreamReader(path))
                {
                    sr.ReadLine();
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        inputData.Add(new List<int>(line.Split(new[] {' '})
                            .Select(i => Convert.ToInt32(i))));
                    }
                }
            }
            else
            {
                Console.WriteLine("Path was not specified.");
                return;
            }
            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.WriteLine(CountMaxSimultaneousPerformers(inputData));
            }
        }

        private static int CountMaxSimultaneousPerformers(
            List<List<int>> inputData)
        {
            var maxPerformersCounts = 0;
            for (var i = 0; i < 24; i++)
            {
                var counter = inputData.Count(data =>
                    data[0] == i || ((data[0] + data[1] > i) && (data[0] < i)));
                if (counter > maxPerformersCounts)
                    maxPerformersCounts = counter;
            }
            return maxPerformersCounts;
        }
    }
}