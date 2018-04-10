namespace Common.Interfaces
{
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
        /// <param name="tagsValue">Filtered value</param>
        /// <returns>Enumeration of filtered elements</returns>
        IEnumerable<Book> Find(BookTagsName filter, string tagsValue);

        /// <summary>
        /// Gets sorted by tag name enumeration of elements
        /// </summary>
        /// <param name="tag">Tag name</param>
        /// <returns>Enumeration of elements</returns>
        IEnumerable<Book> SortByTag(BookTagsName tag);
    }
}