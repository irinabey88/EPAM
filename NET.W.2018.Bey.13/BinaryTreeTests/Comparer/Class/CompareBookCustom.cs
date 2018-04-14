using BinaryTree.Interfaces;
using BinaryTreeTests.CustomObject;

namespace BinaryTreeTests.Comparer.Class
{
    public class CompareBookCustom : IBinaryComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Year - y.Year;
        }
    }
}