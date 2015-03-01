using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task04
{
    static class Program
    {
        private static string languageFrom;
        private static string languageTo;
        private static List<List<string>> languagePairs;
        private static int translatorsCounter;

        static void Main()
        {
            Console.WriteLine("Please, enter the path to the input file:");
            var path = Console.ReadLine();
            CreatePairs(path);

            Console.WriteLine("Enter the language from which to translate:");
            languageFrom = Console.ReadLine();
            Console.WriteLine("Enter the language into which to translate:");
            languageTo = Console.ReadLine();

            FindMinSequence();

            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.WriteLine(translatorsCounter);
            }
        }

        private static void CreatePairs(string path)
        {
            languagePairs = new List<List<string>>();
            using (var sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Skip the first element in line (Translator's name)
                    // to create language pairs.
                    var pair = new List<string>(line.Split(' ').Skip(1));
                    languagePairs.Add(pair);
                }
            }
        }

        private static void FindMinSequence()
        {
            // Using queue for breadth-first search.
            var languagesQueue = new Queue<string>();
            languagesQueue.Enqueue(languageFrom);
            translatorsCounter = 0;
            while (true)
            {
                foreach (var pair in languagePairs.Where(pair => 
                    languagesQueue.Peek().Equals(pair[0])))
                {
                    if (pair[1].Equals(languageTo))
                    {
                        translatorsCounter++;
                        break;
                    }
                    if (languagesQueue.Contains(pair[1])) continue;
                    languagesQueue.Enqueue(pair[1]);
                    translatorsCounter++;
                }
                languagesQueue.Dequeue();
                if (languagesQueue.Count == 0) break;
            }
        }
    }
}
