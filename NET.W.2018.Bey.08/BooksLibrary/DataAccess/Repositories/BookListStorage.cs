namespace DataAccess.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Common.Interfaces;
    using CustomLogger;
    using Exception;
    using Models;

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
            this._listBooks = this.Load();
            if (_listBooks == null)
            {
                Logger.Fatal($"{nameof(BookListStorage)} wasn't created");        
                throw new ArgumentNullException(nameof(_listBooks));
            }

            Logger.Debug($"{nameof(BookListStorage)} was created");
        }    

        public Book Get(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                throw new ArgumentNullException(nameof(id));
            }

            var findElement = this.Find(x => x.ISBN == id);

            if (!findElement.Any() || findElement.Count() > 1)
            {
                throw new GetBookException(id);
            }

            return findElement.ToArray()[0];
        }

        public Book Get(Book model)
        {            
            var findElement = this.Find(x => x.ISBN == model.ISBN);

            if (!findElement.Any())
            {
                Logger.Warn($"{nameof(findElement)} with ISBN {model.ISBN} doesn't exists in the storage");
                return null;
            }

            if (findElement.Count() > 1)
            {
                Logger.Error($"{nameof(findElement)} with ISBN {model.ISBN} shoud be one");
                throw new GetBookException(model.ISBN);
            }

            return findElement.ToArray()[0];
        }

        public Book Add(Book model)
        {
            if (model == null)
            {
                Logger.Error($"{nameof(model)}is null");
                throw new ArgumentNullException(nameof(model));
            }

            if (this._listBooks.ToList().Contains(model))
            {
                Logger.Error($"Book with ISBN {model.ISBN} is alredy exists");
                throw new AddBookException(model.Name, model.ISBN);
            }

            using (var fs = new FileStream(this._fileStorage, FileMode.Append, FileAccess.Write, FileShare.Read))
            {
                using (BinaryWriter writer = new BinaryWriter(fs))
                {                  
                    SaveBook(writer, model);
                    Logger.Info($"Book with ISBN {model.ISBN} was added to storage");
                }
            }

            this._listBooks = this._listBooks.Concat(new[] { model });

            return model;
        }

        public Book Delete(Book model)
        {
            if (model == null)
            {
                Logger.Error($"{nameof(model)} is null");
                throw new ArgumentNullException(nameof(model));
            }

            var deletedBook = Get(model.ISBN);
            if (deletedBook == null)
            {
                Logger.Error($"Book with ISBN {model.ISBN} doesn't exists in the storage");
                throw new DeleteBookException(model.Name, model.ISBN);
            }

            this._listBooks = this._listBooks.Except(new List<Book> { deletedBook });

            if (!this._listBooks.Any())
            {
                File.Delete(this._fileStorage);
                Logger.Info($"Book with ISBN {model.ISBN} was deleted");
                return model;
            }

            SaveBookList();
            Logger.Info($"Book with ISBN {model.ISBN} was deleted");
            return model;
        }

        public Book Update(Book model)
        {
            if (model == null)
            {
                Logger.Error($"{nameof(model)} is null");
                throw new ArgumentNullException(nameof(model));
            }

            var deletedBook = Get(model.ISBN);
            if (deletedBook == null)
            {
                Logger.Error($"Book with ISBN {model.ISBN} doesn't exists in the storage");
                throw new DeleteBookException(model.Name, model.ISBN);
            }

            this._listBooks = this._listBooks.Except(new List<Book> { deletedBook });
            this._listBooks = this._listBooks.Concat(new[] { model });

            SaveBookList();
            Logger.Info($"Book with ISBN {model.ISBN} was updated");
            return model;
        }

        public IEnumerable<Book> Find(Predicate<Book> filter)
        {          
            var books = this.GetAllElements().ToList().FindAll(filter);

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
                            Logger.Error($"{nameof(readedBook)} is null");
                            throw new ArgumentNullException(nameof(readedBook));
                        }

                        bookList.Add(readedBook);
                    }
                }
            }

            Logger.Info($"List books was loaded");
            return bookList;
        }

        public IEnumerable<Book> SortByTag(IComparer<Book> comparer)
        {
            if (comparer == null)
            {
                Logger.Error($"{nameof(comparer)} is null");
                throw new ArgumentNullException(nameof(comparer));
            }
         
            var sortedList = this._listBooks.ToList();
            sortedList.Sort(comparer);

            Logger.Info($"Books list was sorted");
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

            Logger.Info($"Book with {isbn} was loaded");
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

            Logger.Info($"Book with {book.ISBN} was saved");
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

                    Logger.Info($"Books list was saved");
                }
            }
        }
      
        #endregion
    }
}