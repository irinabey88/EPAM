using System.Collections.Generic;
using BinaryTreeTests.CustomObject;

namespace BinaryTreeTests.Comparer.Class
{
    public class CompareBookCustom : IComparer<Book>
    {
        public int Compare(Book x, Book y)
        {
            return x.Year - y.Year;
        }
    }
}