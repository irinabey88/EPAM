namespace Models.Comparer
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Provides compararor for <see cref="Book"/> by property publishing
    /// </summary>
    public class PublishingComparer : IComparer<Book>
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

            return string.Compare(obj1.Publishig, obj2.Publishig, StringComparison.Ordinal);
        }
    }
}