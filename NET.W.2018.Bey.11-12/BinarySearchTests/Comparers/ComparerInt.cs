using System.Collections.Generic;

namespace BinarySearchTests.Comparers
{
    public class ComparerInt : IComparer<int>
    {
        public int Compare(int lhs, int rhs)
        {
            return lhs.CompareTo(rhs);
        }
    }
}