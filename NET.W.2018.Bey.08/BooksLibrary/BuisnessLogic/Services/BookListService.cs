namespace BuisnessLogic
{
    using System;
    using System.Collections.Generic;

    using BuisnesLogic.Services;
    using Common.Interfaces;
    using CustomLogger;
    using Models;

    /// <summary>
    /// Provides business logik of work with book
    /// </summary>
    public class BookListService : IBookListService<Book>
    {
        /// <summary>
        /// Instance of books storage
        /// </summary>
        private readonly IBookRepository _bookRepository;

        /// <summary>
        /// Initialize a new instance of <see cref="BookListService"/>
        /// </summary>
        /// <param name="bookRepository">Books storage</param>
        public BookListService(IBookRepository bookRepository)
        {
            if (bookRepository == null)
            {
                BookLogger.Fatal($"{nameof(bookRepository)} is null value");
                throw new ArgumentNullException(nameof(bookRepository));
            }

            this._bookRepository = bookRepository;
            BookLogger.Debug($"{nameof(BookListService)} was created");
        }

        /// <summary>
        /// Adds book 
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns><value>Book if it is added</value>
        /// <value>null -otherwise</value></returns>
        public Book AddBook(Book book)
        {
            if (book == null)
            {
                BookLogger.Error($"{nameof(book)} is null value");
                throw new ArgumentNullException(nameof(book));
            }

            return this._bookRepository.Add(book);
        }

        /// <summary>
        /// Removes book 
        /// </summary>
        /// <param name="book">Book</param>
        /// <returns><value>Book if it is removed</value>
        /// <value>null -otherwise</value></returns>
        public Book RemoveBook(Book book)
        {
            if (book == null)
            {
                BookLogger.Error($"{nameof(book)} is null value");
                throw new ArgumentNullException(nameof(book));
            }

            return this._bookRepository.Delete(book);
        }

        /// <summary>
        /// Finds book by tags name and value
        /// </summary>
        /// <param name="filter">Filter</param>
        /// <returns>Enumeration of found books</returns>
        public IEnumerable<Book> FindBookByTag(Predicate<Book> filter)
        {
            if (filter == null)
            {
                BookLogger.Error($"{nameof(filter)} is null value");
                throw new ArgumentNullException(nameof(filter));
            }
           
            return this._bookRepository.Find(filter);
        }

        /// <summary>
        /// Sorts book by tags name
        /// </summary>
        /// <param name="comparer">Tags name</param>
        /// <returns>Enumeration of books</returns>
        public IEnumerable<Book> SortBookByTag(IComparer<Book> comparer)
        {
            if (comparer == null)
            {
                BookLogger.Error($"{nameof(comparer)} is null value");
                throw new ArgumentNullException(nameof(comparer));
            }

            return this._bookRepository.SortByTag(comparer);
        }

        /// <summary>
        /// Gets all books in storage
        /// </summary>
        /// <returns>Enumeration of books</returns>
        public IEnumerable<Book> GetAllBooks()
        {
            return this._bookRepository.GetAllElements();
        }
    }
}