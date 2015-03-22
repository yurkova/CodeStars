using System;
using System.IO;

namespace Task16
{
    internal static class Program
    {
        private static int maxFreeArea;

        private static void Main()
        {
            Console.WriteLine("Please, enter the width of the area:");
            var width = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the length of the area:");
            var length = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please, enter the path to input file:");
            var path = Console.ReadLine();

            var area = new bool[width, length];
            if (path != null)
            {
                using (var sr = new StreamReader(path))
                {
                    for (var i = 0; i < width; i++)
                    {
                        for (var j = 0; j < length; j++)
                        {
                            area[i, j] = Convert.ToInt32(sr.Read()) == '1';
                        }
                        // Skip "LF" char.
                        sr.Read();
                        // Skip "CR" char.
                        sr.Read();
                    }
                }
            }
            else
            {
                Console.WriteLine("Path was not specified.");
                return;
            }
            var inaccessiblePlaces = FindInaccessiblePlaces(area,
                width, length);
            FindMaxFreeSpace(inaccessiblePlaces, width, length);
            using (var sw = new StreamWriter(@"..\..\ANSWER.md"))
            {
                sw.WriteLine(maxFreeArea);
            }
        }

        private static void FindMaxFreeSpace(bool[,] inaccessiblePlaces,
            int width, int length)
        {
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    var freeWidth = 0;
                    var freeLength = 0;
                    if (inaccessiblePlaces[i, j]) continue;
                    var k = i;
                    var l = j;
                    for (; l < length; l++)
                    {
                        if (!inaccessiblePlaces[i, l])
                        {
                            freeLength++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    for (; k < width; k++)
                    {
                        if (!inaccessiblePlaces[k, j])
                        {
                            freeWidth++;
                        }
                        else
                        {
                            break;
                        }
                    }
                    CheckIfMax(freeLength);
                    CheckIfMax(freeWidth);

                    if (freeWidth > 1)
                    {
                        k = i + 1;
                    }
                    while (k < i + freeWidth)
                    {
                        for (var m = j; m < j + freeLength; m++)
                        {
                            if (inaccessiblePlaces[k, m])
                            {
                                freeLength = m - j;
                            }
                        }
                        CheckIfMax(freeLength * (k - i + 1));
                        k++;
                    }
                }
            }
        }

        private static void CheckIfMax(int area)
        {
            if (maxFreeArea < area)
            {
                maxFreeArea = area;
            }
        }

        private static bool[,] FindInaccessiblePlaces(bool[,] area,
            int width, int length)
        {
            var inaccessiblePlaces = new bool[width, length];
            for (var i = 0; i < width; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    if (!area[i, j]) continue;

                    inaccessiblePlaces[i, j] = true;
                    if (i > 0)
                    {
                        inaccessiblePlaces[i - 1, j] = true;
                        if (j > 0)
                        {
                            inaccessiblePlaces[i - 1, j - 1] = true;
                        }
                        if (j < width - 1)
                        {
                            inaccessiblePlaces[i - 1, j + 1] = true;
                        }
                    }
                    if (i < length - 1)
                    {
                        inaccessiblePlaces[i + 1, j] = true;
                        if (j > 0)
                        {
                            inaccessiblePlaces[i + 1, j - 1] = true;
                        }
                        if (j < width - 1)
                        {
                            inaccessiblePlaces[i + 1, j + 1] = true;
                        }
                    }
                    if (j > 0)
                    {
                        inaccessiblePlaces[i, j - 1] = true;
                    }
                    if (j < width - 1)
                    {
                        inaccessiblePlaces[i, j + 1] = true;
                    }
                }
            }
            return inaccessiblePlaces;
        }
    }
}