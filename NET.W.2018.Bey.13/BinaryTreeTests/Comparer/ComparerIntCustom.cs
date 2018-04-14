using System.Collections.Generic;
using BinaryTree.Interfaces;

namespace BinaryTreeTests.Comparer
{
    public class ComparerIntCustom : IBinaryComparer<int>
    {
        public int Compare(int x, int y)
        {
            return y - x;
        }
    }
}