﻿using System;

namespace Task17
{
    internal class Point
    {
        public Point()
        {
            X = 0;
            Y = 0;
        }

        public Point(string line)
        {
            var coordinates = line.Split(new[] {' '},
                StringSplitOptions.RemoveEmptyEntries);
            X = Convert.ToInt32(coordinates[0]);
            Y = Convert.ToInt32(coordinates[1]);
        }

        public Point(string coord1, string coord2)
        {
            X = Convert.ToInt32(coord1);
            Y = Convert.ToInt32(coord2);
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}