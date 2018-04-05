using NET.W._2018.Bey._08.Repositories.Comparer;

namespace NET.W._2018.Bey._08.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Enum;
    using Exception;
    using Interfaces;
    using Models.Book;

    /// <summary>
    /// Provides book storage
    /// </summary>
    public class BookListStorage : IBookRepository
    {
        /// <summary>
        /// Source file name
        /// </summary>
        private readonly string _fileStorage;

        /// <summary>
        /// Enumeration of books
        /// </summary>
        private IEnumerable<Book> _listBooks;

        /// <summary>
        /// Gets instance of books storage
        /// </summary>
        /// <param name="fileStorage">Source file name</param>
        public BookListStorage(string fileStorage)
        {
            if (string.IsNullOrWhiteSpace(fileStorage))
            {
                throw new ArgumentNullException($"{nameof(fileStorage)}");
            }

            this._fileStorage = fileStorage;
            this._listBooks = this.Load() ?? throw new ArgumentNullException(nameof(_listBooks));
        }

        public Book this[string id]
        {
            get
            {
                if (string.IsNullOrWhiteSpace(id))
                {
                    throw new ArgumentNullException(nameof(id));
                }

                var book = this.Find(BookTagsName.ISBN, id);

                if (book?.Count() == 0)
                {
                    return null;
                }

                if (book.Count() > 1)
                {
                    throw new ArgumentException(nameof(id));
                }

                return book.ToArray()[0];
            }
        }

        public Book Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            return this[id] ?? throw new GetBookException(id);
        }

        public Book Get(Book model)
        {
            var findElement = this[model.ISBN] ?? throw new GetBookException(model.ISBN);

            return findElement;
        }

        public Book Add(Book model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (this._listBooks.ToList().Contains(model))
            {
                throw new AddBookException(model.Name, model.ISBN);
            }

            using (var fs = new FileStream(this._fileStorage, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {                  
                    SaveBook(writer, model);
                }
            }

            this._listBooks = this._listBooks.Concat(new[] { model });

            return model;
        }

        public Book Delete(Book model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var deletedBook = this[model.ISBN] ?? throw new DeleteBookException(model.Name, model.ISBN);
            this._listBooks = this._listBooks.Except(new List<Book> { deletedBook });

            if (this._listBooks.Count() == 0)
            {
                File.Delete(this._fileStorage);
                return model;
            }

            SaveBookList();
            return model;
        }

        public Book Update(Book model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            if (this._listBooks.ToList().Contains(model))
            {
                throw new AddBookException(model.Name, model.ISBN);
            }

            var deletedBook = this[model.ISBN] ?? throw new DeleteBookException(model.Name, model.ISBN);
            this._listBooks = this._listBooks.Except(new List<Book> { deletedBook });
            this._listBooks = this._listBooks.Concat(new[] { model });

            SaveBookList();
            return model;
        }

        public IEnumerable<Book> Find(BookTagsName filter, string tagsValue)
        {
            if (string.IsNullOrWhiteSpace(tagsValue))
            {
                throw new ArgumentNullException(nameof(filter));
            }

            bool result;
            List<Book> books = new List<Book>();        
            switch (filter)
            {
                case BookTagsName.ISBN:
                    foreach (var book in this._listBooks)
                    {
                        if (book.ISBN.Equals(tagsValue))
                        {
                            books.Add(book);
                        }
                    }

                    if (books.Count > 1)
                    {
                        throw new DuplicateIdException(books[0].ISBN);
                    }

                    break;
                case BookTagsName.Author:
                    foreach (var book in this._listBooks)
                    {
                        if (book.Author.Equals(tagsValue))
                        {
                            books.Add(book);
                        }
                    }

                    break;
                case BookTagsName.Name:
                    foreach (var book in this._listBooks)
                    {
                        if (book.Name.Equals(tagsValue))
                        {
                            books.Add(book);
                        }
                    }

                    break;
                case BookTagsName.Publishing:
                    foreach (var book in this._listBooks)
                    {
                        if (book.Publishig.Equals(tagsValue))
                        {
                            books.Add(book);
                        }
                    }

                    break;
                case BookTagsName.PageCount:
                    uint pageCout;
                    result = uint.TryParse(tagsValue, out pageCout);

                    if (!result)
                    {
                        throw new InvalidCastException(nameof(tagsValue));
                    }

                    foreach (var book in this._listBooks)
                    {
                        if (book.PageCount == pageCout)
                        {
                            books.Add(book);
                        }
                    }

                    break;
                case BookTagsName.Year:
                    uint year;
                    result = uint.TryParse(tagsValue, out year);

                    if (!result)
                    {
                        throw new InvalidCastException(nameof(tagsValue));
                    }

                    foreach (var book in this._listBooks)
                    {
                        if (book.Year == year)
                        {
                            books.Add(book);
                        }
                    }

                    break;
                case BookTagsName.Price:
                    decimal price;
                    result = decimal.TryParse(tagsValue, out price);

                    if (!result)
                    {
                        throw new InvalidCastException(nameof(tagsValue));
                    }

                    foreach (var book in this._listBooks)
                    {
                        if (book.Price == price)
                        {
                            books.Add(book);
                        }
                    }

                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(filter));
            }

            return books.Count == 0 ? null : books;
        }

        public IEnumerable<Book> GetAllElements()
        {
            return this._listBooks;
        }

        public IEnumerable<Book> Load()
        {
            List<Book> bookList = new List<Book>();

            using (var fs = new FileStream(this._fileStorage, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (BinaryReader reader = new BinaryReader(fs))
                {
                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        var readedBook = LoadData(reader);

                        if (readedBook == null)
                        {
                            throw new ArgumentNullException(nameof(readedBook));
                        }

                        bookList.Add(readedBook);
                    }
                }
            }
            
            return bookList;
        }

        public IEnumerable<Book> SortByTag(BookTagsName tag)
        {
            IComparer<Book> comparer;

            switch (tag)
            {
                case BookTagsName.ISBN:
                    comparer = new IsbnComparer();
                    break;
                case BookTagsName.Author:
                    comparer = new AuthorComparer();
                    break;
                case BookTagsName.Name:
                    comparer = new NameComparer();
                    break;
                case BookTagsName.Publishing:
                    comparer = new PublishingComparer();
                    break;
                case BookTagsName.Year:
                    comparer = new YearComparer();
                    break;
                case BookTagsName.PageCount:
                    comparer = new PageCountComparer();
                    break;
                case BookTagsName.Price:
                    comparer = new PriceComparer();
                    break;
                default:
                    throw new ArgumentException(nameof(tag));
            }

            var sortedList = this._listBooks.ToList();
            sortedList.Sort(comparer);

            return sortedList;
        }

        #region Private methods

        private Book LoadData(BinaryReader reader)
        {
            var isbn = reader.ReadString();
            var author = reader.ReadString();
            var name = reader.ReadString();
            var publishing = reader.ReadString();
            var year = reader.ReadUInt32();
            var pageCount = reader.ReadUInt32();
            var price = reader.ReadDecimal();

            return new ScientificBook(isbn, author, name, publishing, year, pageCount, price);
        }

        private void SaveBook(BinaryWriter writer, Book book)
        {
            writer.Write(book.ISBN);
            writer.Write(book.Author);
            writer.Write(book.Name);
            writer.Write(book.Publishig);
            writer.Write(book.Year);
            writer.Write(book.PageCount);
            writer.Write(book.Price);   
            writer.Flush();
        }

        private void SaveBookList()
        {
            using (var fs = new FileStream(this._fileStorage, FileMode.Create, FileAccess.Write, FileShare.Read))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {
                    foreach (var book in this._listBooks)
                    {
                        SaveBook(writer, book);
                    }
                }
            }
        }
      
        #endregion
    }
}