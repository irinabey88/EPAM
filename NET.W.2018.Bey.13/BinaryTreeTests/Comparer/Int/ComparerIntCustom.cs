using System.Collections.Generic;

namespace BinaryTreeTests.Comparer
{
    public class ComparerIntCustom : IComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }
}