using System;
using System.IO;
using System.Text;

namespace Task02
{
    static class Program
    {
        static void Main()
        {
            string inputText;
            var outputText = new StringBuilder();

            using (var sr = new StreamReader(@"..\..\65.result"))
            {
                inputText = sr.ReadToEnd().ToLower();
            }

            var delimiters = new[] { ' ', '-', ',', '.', '!', '?', ':', ';' };
            var wordsInText = inputText.Split(delimiters,
                StringSplitOptions.RemoveEmptyEntries);

            var wordYoCounter = 0;
            foreach (var word in wordsInText)
            {
                if (word.Equals("yo"))
                    wordYoCounter++;
                else if (word.Equals("nice"))
                {
                    if (wordYoCounter != 0)
                    {
                        var c = Convert.ToChar('a' + wordYoCounter - 1);
                        outputText.Append(c);
                        wordYoCounter = 0;
                    }
                    else
                    {
                        outputText.Append(' ');
                    }
                }
            }

            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.WriteLine(outputText);
            }
        }
    }
}
