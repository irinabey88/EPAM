using System.Collections.Generic;
using BinaryTreeTests.CustomObject;

namespace BinaryTreeTests.Comparer.Struct
{
    public class ComparerStruct : IComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return x.X - y.X;
        }
    }
}