namespace NET.W._2018.Bey._08.Repositories.Comparer
{
    using System;
    using System.Collections.Generic;
    using Models.Book;

    internal class IsbnComparer : IComparer<Book>
    {
        public int Compare(Book obj1, Book obj2)
        {
            if (obj1 == null)
            {
                throw new ArgumentNullException(nameof(obj1));
            }

            if (obj2 == null)
            {
                throw new ArgumentNullException(nameof(obj2));
            }

            return string.Compare(obj1.ISBN, obj2.ISBN, StringComparison.Ordinal);
        }
    }
}