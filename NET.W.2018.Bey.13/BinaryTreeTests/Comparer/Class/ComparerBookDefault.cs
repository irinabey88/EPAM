using BinaryTree.Interfaces;
using BinaryTreeTests.CustomObject;

namespace BinaryTreeTests.Comparer.Class
{
    public class ComparerBookDefault : IBinaryComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.CompareTo(y);
        }
    }
}