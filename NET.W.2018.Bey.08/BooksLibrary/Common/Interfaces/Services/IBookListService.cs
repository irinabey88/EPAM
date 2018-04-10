namespace BuisnesLogic.Services
{
    using System.Collections.Generic;
    using Models;

    /// <summary>
    /// Describes book service logic
    /// </summary>
    public interface IBookListService<TModel> where TModel : Book
    {
        /// <summary>
        /// Adds book 
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns><value>Book if it is added</value>
        /// <value>null -otherwise</value></returns>
        TModel AddBook(TModel book);

        /// <summary>
        /// Removes book 
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns><value>Book if it is removed</value>
        /// <value>null -otherwise</value></returns>
        TModel RemoveBook(TModel book);

        /// <summary>
        /// Finds book by tags name and value
        /// </summary>
        /// <param name="tag">Tags name</param>
        /// <param name="tagsValue">Value</param>
        /// <returns>Enumeration of found books</returns>
        IEnumerable<TModel> FindBookByTag(BookTagsName tag, string tagsValue);

        /// <summary>
        /// Sorts book by tags name
        /// </summary>
        /// <param name="tag">Tags name</param>
        /// <returns>Enumeration of books</returns>
        IEnumerable<TModel> SortBookByTag(BookTagsName tag);

        /// <summary>
        /// Gets all books in storage
        /// </summary>
        /// <returns>Enumeration of books</returns>
        IEnumerable<TModel> GetAllBooks();
    }
}