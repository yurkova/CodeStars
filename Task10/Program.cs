using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task10
{
    internal static class Program
    {
        private static void Main()
        {
            string frequencyDict;
            string encodedText;
            Console.WriteLine("Please, enter the path to input file:");
            var path = Console.ReadLine();
            if (path != null)
            {
                using (var sr = new StreamReader(path))
                {
                    frequencyDict = sr.ReadLine();
                    encodedText = sr.ReadToEnd();
                }
            }
            else
            {
                Console.WriteLine("Path was not specified.");
                return;
            }
            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.WriteLine(DecodeText(frequencyDict, encodedText));
            }
        }

        private static StringBuilder DecodeText(string frequencyDict,
            string encodedText)
        {
            var charsCount = new Dictionary<char, int>();
            foreach (var c in encodedText.Where(c => c >= 'a' && c <= 'z'))
            {
                if (charsCount.ContainsKey(c))
                {
                    charsCount[c]++;
                }
                else
                {
                    charsCount.Add(c, 1);
                }
            }

            var decodedText = new StringBuilder(encodedText);
            var charsMapping = new Dictionary<char, char>();
            var dictIndex = 0;
            foreach (var item in charsCount.OrderByDescending(i => i.Value))
            {
                charsMapping.Add(item.Key, frequencyDict[dictIndex]);
                dictIndex++;
            }
            for (var i = 0; i < decodedText.Length; i++)
            {
                if (charsMapping.ContainsKey(decodedText[i]))
                {
                    decodedText[i] = charsMapping[decodedText[i]];
                }
            }
            return decodedText;
        }
    }
}