using System.Collections.Generic;
using System.Linq;

namespace Task20
{
    internal class ListComparer<T> : IEqualityComparer<List<T>>
    {
        public bool Equals(List<T> x, List<T> y)
        {
            return x.SequenceEqual(y);
        }

        public int GetHashCode(List<T> list)
        {
            return list.Aggregate(0, (current, item) =>
                current ^ item.GetHashCode());
        }
    }
}