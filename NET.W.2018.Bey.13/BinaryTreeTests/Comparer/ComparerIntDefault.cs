using System.Collections.Generic;
using BinaryTree.Interfaces;

namespace BinaryTreeTests.Comparer
{
    public class ComparerIntDefault : IBinaryComparer<int>
    {
        public int Compare(int x, int y)
        {
            return x.CompareTo(y);
        }
    }
}