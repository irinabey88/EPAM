using BinaryTree.Interfaces;
using BinaryTreeTests.CustomObject;

namespace BinaryTreeTests.Comparer.Struct
{
    public class ComparerStruct : IBinaryComparer<Point>
    {
        public int Compare(Point x, Point y)
        {
            return x.X - y.X;
        }
    }
}