using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task09
{
    internal static class Program
    {
        private static void Main()
        {
            var entries = new List<EvaluationEntry>();
            Console.WriteLine("Please, enter the path to input file:");
            var path = Console.ReadLine();
            if (path != null)
            {
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        entries.Add(new EvaluationEntry(line));
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
                sw.WriteLine(GetResultsOfCompetition(entries));
            }
        }

        private static string GetResultsOfCompetition(
            List<EvaluationEntry> entries)
        {
            var averagePenalty = (int) Math.Ceiling(
                entries.Average(e => e.Penalty));
            var totalScore = entries.Select(e => e.Score).Sum();

            var judgesMistakesCount = new Dictionary<string, int>();
            foreach (var entry in entries)
            {
                if (!entry.MessyEntry) continue;
                if (judgesMistakesCount.ContainsKey(entry.Judge))
                {
                    judgesMistakesCount[entry.Judge]++;
                }
                else
                {
                    judgesMistakesCount.Add(entry.Judge, 0);
                }
            }
            var carelessJudge = judgesMistakesCount.First(x =>
                x.Value == judgesMistakesCount.Values.Max()).Key;

            return averagePenalty + " " + totalScore + " " + carelessJudge;
        }
    }
}