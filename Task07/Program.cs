using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Task07
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Please, enter the path to the input file:");
            var path = Console.ReadLine();
            string text;
            if (path != null)
                using (var sr = new StreamReader(path))
                {
                    text = sr.ReadToEnd();
                }
            else
            {
                Console.WriteLine("Path was not specified.");
                return;
            }
            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.WriteLine(GetOwhershipPercent(text));
            }
        }

        private static int GetOwhershipPercent(string text)
        {
            const string firstPattern = @"[^xyzw]*";
            const string secondPattern = @"[^abcd]*";
            var firstMaxLength = Regex.Matches(text, firstPattern,
                RegexOptions.IgnoreCase)
                .Cast<Match>()
                .Aggregate(0,
                    (current, match) =>
                        (match.Length > current)
                            ? match.Length
                            : current);
            var secondMaxLength = Regex.Matches(text, secondPattern,
                RegexOptions.IgnoreCase)
                .Cast<Match>()
                .Aggregate(0,
                    (current, match) =>
                        (match.Length > current)
                            ? match.Length
                            : current);
            return (int)Math.Round((double)secondMaxLength * 100
                                    / (firstMaxLength + secondMaxLength));
        }
    }
}