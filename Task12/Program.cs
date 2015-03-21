using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task12
{
    internal static class Program
    {
        private static void Main()
        {
            Console.WriteLine("Please, enter the path to input file:");
            var path = Console.ReadLine();
            string sourceCode;
            if (path != null)
            {
                using (var sr = new StreamReader(path))
                {
                    sourceCode = sr.ReadToEnd();
                }
            }
            else
            {
                Console.WriteLine("Path was not specified.");
                return;
            }
            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.WriteLine(GetOutput(sourceCode));
            }
        }

        private static StringBuilder GetOutput(string sourceCode)
        {
            var stack = new Stack<int>();
            var output = new StringBuilder();
            var label = 0;
            for (var i = 0; i < sourceCode.Length; i++)
            {
                switch (sourceCode[i])
                {
                    case 'Z':
                        stack.Push(0);
                        break;
                    case '+':
                        stack.Push(stack.Pop() + stack.Pop());
                        break;
                    case '*':
                        stack.Push(stack.Pop() * stack.Pop());
                        break;
                    case '!':
                        output.Append((char) (stack.Peek() + 'a'));
                        break;
                    case '#':
                        stack.Push(stack.Pop() + 1);
                        break;
                    case '~':
                        output.Append(' ');
                        break;
                    case '$':
                        var a = stack.Pop();
                        var b = stack.Pop();
                        stack.Push(a);
                        stack.Push(b);
                        break;
                    case '@':
                        stack.Push(stack.Peek());
                        break;
                    case '-':
                        stack.Push(stack.Pop() - 1);
                        break;
                    case '[':
                        label = i;
                        break;
                    case '<':
                        if (stack.Pop() != 0)
                        {
                            i = label;
                        }
                        break;
                    case '`':
                        stack.Pop();
                        break;
                }
            }
            return output;
        }
    }
}