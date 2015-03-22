using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Task17
{
    internal static class Program
    {
        private static void Main()
        {
            var triangles = new List<List<Point>>();
            var contestantPoint = new Point();
            Console.WriteLine("Please, enter the path to input file:");
            var path = Console.ReadLine();
            if (path != null)
            {
                using (var sr = new StreamReader(path))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        var coordinates = line.Split(new[] {' '},
                            StringSplitOptions.RemoveEmptyEntries);
                        if (coordinates.Length == 6)
                        {
                            var triangle = new List<Point>(3);
                            for (var i = 0; i < 6; i += 2)
                            {
                                triangle.Add(new Point(coordinates[i],
                                    coordinates[i + 1]));
                            }
                            triangles.Add(triangle);
                        }
                        else
                        {
                            contestantPoint = new Point(coordinates[0],
                                coordinates[1]);
                        }
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
                sw.WriteLine(CountContestantMistakes(triangles,
                    contestantPoint));
            }
        }

        private static string CountContestantMistakes(
            List<List<Point>> triangles, Point contestantPoint)
        {
            var contestantMistakes = new StringBuilder();
            for (var i = 0; i < triangles.Count; i++)
            {
                var a = (triangles[i][0].X - contestantPoint.X)
                        * (triangles[i][1].Y - triangles[i][0].Y)
                        - (triangles[i][1].X - triangles[i][0].X)
                        * (triangles[i][0].Y - contestantPoint.Y);

                var b = (triangles[i][1].X - contestantPoint.X)
                        * (triangles[i][2].Y - triangles[i][1].Y)
                        - (triangles[i][2].X - triangles[i][1].X)
                        * (triangles[i][1].Y - contestantPoint.Y);

                var c = (triangles[i][2].X - contestantPoint.X)
                        *(triangles[i][0].Y - triangles[i][2].Y)
                        - (triangles[i][0].X - triangles[i][2].X)
                        *(triangles[i][2].Y - contestantPoint.Y);

                if ((a <= 0 && b <= 0 && c <= 0) ||
                    (a >= 0 && b >= 0 && c >= 0))
                {
                    contestantMistakes.Append((i + 1) + " ");
                }
            }
            if (contestantMistakes.Length == 0)
            {
                contestantMistakes.Append(0);
            }
            return contestantMistakes.ToString();
        }
    }
}