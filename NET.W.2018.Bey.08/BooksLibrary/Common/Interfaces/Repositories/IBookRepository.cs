namespace Common.Interfaces
{
    using System;
    using System.Collections.Generic;

    using Models;

    /// <summary>
    /// Describes book repository logic
    /// </summary>
    public interface IBookRepository : IRepository<Book>
    {
        /// <summary>
        /// Finds elements in repository by filter
        /// </summary>
        /// <param name="filter">Filter name</param>
        /// <returns>Enumeration of filtered elements</returns>
        IEnumerable<Book> Find(Predicate<Book> filter);

        /// <summary>
        /// Gets sorted by comparer name enumeration of elements
        /// </summary>
        /// <param name="comparer">Comparer</param>
        /// <returns>Enumeration of elements</returns>
        IEnumerable<Book> SortByTag(IComparer<Book> comparer);
    }
}