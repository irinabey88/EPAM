namespace BuisnessLogic
{
    using System;
    using System.Collections.Generic;
    using BuisnesLogic.Services;
    using Common.Interfaces;
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
        /// <param name="bookRepository"></param>
        public BookListService(IBookRepository bookRepository)
        {
            this._bookRepository = bookRepository ?? throw new ArgumentNullException(nameof(bookRepository));
        }

        public Book AddBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            return this._bookRepository.Add(book);
        }

        public Book RemoveBook(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            return this._bookRepository.Delete(book);
        }

        public IEnumerable<Book> FindBookByTag(BookTagsName tag, string tagsValue)
        {
            if (string.IsNullOrWhiteSpace(tagsValue))
            {
                throw new ArgumentNullException(nameof(tag));
            }

            return this._bookRepository.Find(tag, tagsValue);
        }

        public IEnumerable<Book> SortBookByTag(BookTagsName name)
        {
            return this._bookRepository.SortByTag(name);
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return this._bookRepository.GetAllElements();
        }
    }
}