using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task19
{
    internal static class Program
    {
        private static void Main()
        {
            var singers = new Dictionary<string, int>();
            Console.WriteLine("Please, enter the path to input file:");
            var path = Console.ReadLine();
            if (path != null)
            {
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (singers.ContainsKey(line))
                        {
                            singers[line]++;
                        }
                        else
                        {
                            singers.Add(line, 1);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("Path was not specified.");
                return;
            }

            var topBadSingers = singers.OrderByDescending(s => s.Value)
                .TakeWhile(s => s.Value == singers.Max(i => i.Value))
                .OrderBy(s => s.Key).Select(s => s.Key).ToList();
            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                for (var i = 0; i < topBadSingers.Count; i++)
                {
                    sw.Write(topBadSingers[i]);
                    if (i != topBadSingers.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
            }
        }
    }
}