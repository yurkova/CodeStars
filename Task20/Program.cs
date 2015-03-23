using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task20
{
    internal static class Program
    {
        private static void Main()
        {
            const int threshold = 15;

            var pairsFrequencies = new Dictionary<List<string>, int>(
                new ListComparer<string>());
            var significantPairs = new Dictionary<List<string>, int>();

            Console.WriteLine("Please, enter the path to input file:");
            var path = Console.ReadLine();
            if (path != null)
            {
                using (var sr = new StreamReader(path))
                {
                    var text = sr.ReadToEnd();
                    var words = text.Split(new[] {' '},
                        StringSplitOptions.RemoveEmptyEntries).ToList();

                    for (var i = 0; i < words.Count - 1; i++)
                    {
                        var pair = new List<string> { words[i], words[i + 1] };
                        if (pairsFrequencies.ContainsKey(pair))
                        {
                            pairsFrequencies[pair]++;
                        }
                        else
                        {
                            pairsFrequencies.Add(pair, 1);
                        }
                    }
                    foreach (var pf in pairsFrequencies.Where(pf =>
                        pf.Value >= threshold))
                    {
                        var key = new List<string> { pf.Key[0], pf.Key[1] };
                        significantPairs.Add(key, pf.Value);
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
                {
                    sw.WriteLine(GetAnswerText(significantPairs));
                }
            }
        }

        private static string GetAnswerText(
            Dictionary<List<string>, int> significantPairs)
        {
            var answer = new StringBuilder();

            var sortedSignificantPairs = significantPairs
                .OrderByDescending(p => p.Value);

            var firstWords = new Dictionary<string, int>();
            foreach (var pair in sortedSignificantPairs)
            {
                if (firstWords.ContainsKey(pair.Key[0]))
                {
                    firstWords[pair.Key[0]] += pair.Value;
                }
                else
                {
                    firstWords.Add(pair.Key[0], pair.Value);
                }
            }

            var sortedFirstWords = firstWords
                .OrderByDescending(w => w.Value)
                .Select(w => w.Key).ToArray();

            foreach (var word in sortedFirstWords)
            {
                var firstWord = word;
                var secondWord = "";

                int[] frequency = { 0 };
                foreach (var pair in significantPairs
                    .Where(pair => ((firstWord == pair.Key[0])
                                    && pair.Value > frequency[0])))
                {
                    secondWord = pair.Key[1];
                    frequency[0] = pair.Value;
                }
                answer.Append(word + " " + secondWord + " ");
            }
            return answer.ToString();
        }
    }
}