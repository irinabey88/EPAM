using System;
using BinaryTree.Interfaces;

namespace BinaryTreeTests.Comparer.StringComparer
{
    public class ComparerStringDefault : IBinaryComparer<string>
    {
        public int Compare(string x, string y)
        {
            return string.Compare(x, y, StringComparison.Ordinal);
        }
    }
}