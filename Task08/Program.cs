using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task08
{
    internal static class Program
    {
        private static void Main()
        {
            var musePairs = new List<List<int>>();

            Console.WriteLine("Please, enter the path to the input file.");
            var path = Console.ReadLine();
            if (path != null)
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var pair = new List<int>(line.Split(' ').Select(s =>
                            Convert.ToInt32(s)));
                        musePairs.Add(pair);
                    }
                }
            else
            {
                Console.WriteLine("Path was not specified.");
                return;
            }
            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.WriteLine(CountMuses(musePairs));
            }
        }

        private static int CountMuses(List<List<int>> musePairs)
        {
            var maxAssociatedMusesCount = 0;
            while (musePairs.Count > 0)
            {
                var associatedMuses = new HashSet<int>();
                associatedMuses.UnionWith(musePairs[0]);
                musePairs.RemoveAt(0);

                for (var i = 0; i < musePairs.Count;)
                {
                    if (associatedMuses.Contains(musePairs[i][0]) ||
                        associatedMuses.Contains(musePairs[i][1]))
                    {
                        associatedMuses.UnionWith(musePairs[i]);
                        musePairs.RemoveAt(i);
                        i = 0;
                    }
                    else
                    {
                        i++;
                    }
                }
                maxAssociatedMusesCount =
                    associatedMuses.Count > maxAssociatedMusesCount
                        ? associatedMuses.Count
                        : maxAssociatedMusesCount;
            }
            return maxAssociatedMusesCount;
        }
    }
}