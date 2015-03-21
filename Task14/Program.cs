using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task14
{
    internal static class Program
    {
        private static void Main()
        {
            var river = new List<Point>(2);
            var points = new List<Point>();
            Console.WriteLine("Please, enter the path to input file:");
            var path = Console.ReadLine();
            if (path != null)
            {
                using (var sr = new StreamReader(path))
                {
                    var line = sr.ReadLine();
                    var riverCoordinates = line.Split(new[] {' '},
                        StringSplitOptions.RemoveEmptyEntries);
                    for (var i = 0; i < riverCoordinates.Length; i += 2)
                    {
                        river.Add(new Point(riverCoordinates[i],
                            riverCoordinates[i + 1]));
                    }
                    while ((line = sr.ReadLine()) != null)
                    {
                        points.Add(new Point(line));
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
                sw.WriteLine(GetFansSequence(river, points));
            }
        }

        private static StringBuilder GetFansSequence(List<Point> river,
            IEnumerable<Point> points)
        {
            var sequence = new StringBuilder();
            foreach (var point in points)
            {
                var d = (point.X - river[0].X) * (river[1].Y - river[0].Y)
                        - (point.Y - river[0].Y) * (river[1].X - river[0].X);
                sequence.Append(d < 0 ? 'П' : 'И');
            }
            return sequence;
        }
    }
}