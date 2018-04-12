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
        /// Provides an instance of BookListService
        /// </summary>
        /// <param name="bookRepository">Books storage</param>
        public BookListService(IBookRepository bookRepository)
        {
            if (bookRepository == null)
            {
                Logger.Fatal($"{nameof(bookRepository)} is null value");
                throw new ArgumentNullException(nameof(bookRepository));
            }

            this._bookRepository = bookRepository;
            Logger.Debug($"{nameof(BookListService)} was created");
        }

        public Book AddBook(Book book)
        {
            if (book == null)
            {
                Logger.Error($"{nameof(book)} is null value");
                throw new ArgumentNullException(nameof(book));
            }

            return this._bookRepository.Add(book);
        }

        public Book RemoveBook(Book book)
        {
            if (book == null)
            {
                Logger.Error($"{nameof(book)} is null value");
                throw new ArgumentNullException(nameof(book));
            }

            return this._bookRepository.Delete(book);
        }

        public IEnumerable<Book> FindBookByTag(Predicate<Book> filter)
        {
            if (filter == null)
            {
                Logger.Error($"{nameof(filter)} is null value");
                throw new ArgumentNullException(nameof(filter));
            }
           

            return this._bookRepository.Find(filter);
        }

        public IEnumerable<Book> SortBookByTag(IComparer<Book> comparer)
        {
            if (comparer == null)
            {
                Logger.Error($"{nameof(comparer)} is null value");
                throw new ArgumentNullException(nameof(comparer));
            }

            return this._bookRepository.SortByTag(comparer);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this._bookRepository.GetAllElements();
        }
    }
}