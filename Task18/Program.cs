using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task18
{
    internal static class Program
    {
        private static void Main()
        {
            var circles = new List<List<int>>();
            var contestantPoint = new List<int>();
            Console.WriteLine("Please, enter the path to input file:");
            var path = Console.ReadLine();
            if (path != null)
            {
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var coordinates = line.Split(new[] {' '},
                            StringSplitOptions.RemoveEmptyEntries);
                        if (coordinates.Length == 3)
                        {
                            var circle = new List<int>(3);
                            circle.AddRange(coordinates.Select(c =>
                                Convert.ToInt32(c)));
                            circles.Add(circle);
                        }
                        else
                        {
                            contestantPoint.AddRange(coordinates.Select(c =>
                                Convert.ToInt32(c)));
                        }
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
                sw.WriteLine(FindHitsAndPenalty(circles,
                    contestantPoint));
            }
        }

        private static string FindHitsAndPenalty(List<List<int>> circles,
            List<int> contestantPoint)
        {
            var hitsAndPenalty = new StringBuilder();
            var penalty = 0;
            for (var i = 0; i < circles.Count; i++)
            {
                var distance = Math.Sqrt(
                    (circles[i][0] - contestantPoint[0])
                    *(circles[i][0] - contestantPoint[0])
                    + (circles[i][1] - contestantPoint[1])
                    *(circles[i][1] - contestantPoint[1]));

                if (!(distance < circles[i][2])) continue;
                hitsAndPenalty.Append((i + 1) + " ");
                penalty += 499;
            }
            hitsAndPenalty.Append(hitsAndPenalty.Length == 0 ? 0 : penalty);
            return hitsAndPenalty.ToString();
        }
    }
}