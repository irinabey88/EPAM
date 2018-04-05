namespace NET.W._2018.Bey._08.Models.Book
{
    using System;
    using System.Globalization;
    using BookFormater;
    using Enum;

    /// <summary>
    /// Provides bank book object
    /// </summary>
    public abstract class Book : IComparable, IFormattable
    {
        /// <summary>
        /// Provides new instance of book
        /// </summary>
        /// <param name="isbn">Book id</param>
        /// <param name="author">Author</param>
        /// <param name="name">Book name</param>
        /// <param name="publishing">Publishing</param>
        /// <param name="year">Year of publishing</param>
        /// <param name="pageCount">Page count</param>
        /// <param name="price">Price</param>
        public Book(string isbn, string author, string name, string publishing, uint year, uint pageCount, decimal price)
        {
            DataValidation(isbn, author, name, publishing, year, pageCount, price);
            
            this.ISBN = isbn;
            this.Author = author;
            this.Name = name;
            this.Publishig = publishing;
            this.Year = year;
            this.PageCount = pageCount;
            this.Price = price;
        }

        /// <summary>
        /// Book id
        /// </summary>
        public string ISBN { get; }

        /// <summary>
        /// Author
        /// </summary>
        public string Author { get; }

        /// <summary>
        /// Book Name
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Publishing
        /// </summary>
        public string Publishig { get; }

        /// <summary>
        /// Year of publishing
        /// </summary>
        public uint Year { get; }

        /// <summary>
        /// Page count
        /// </summary>
        public uint PageCount { get; }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price { get; }

        public bool Equals(Book other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }
            
            return CheckEqualityProperty(this, other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((Book)obj);
        }

        public override int GetHashCode() => this.ISBN.GetHashCode();

        public override string ToString()
        {
            return this.ToString(BookFormat.AN.ToString(), new BookFormatter());
        }

        public string ToString(string format)
        {
            return this.ToString(format, new BookFormatter());
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            if (string.IsNullOrWhiteSpace(format))
            {
                format = BookFormat.AN.ToString();
            }

            if (formatProvider == null)
            {
                formatProvider = CultureInfo.CurrentCulture;
            }

            if (!Enum.TryParse<BookFormat>(format, out var bookFormat))
            {
                throw new FormatException($"Incorrect string format {format}");
            }

            switch (bookFormat)
            {
                case BookFormat.AN:
                    return $"{this.Author} {this.Name}".ToString(formatProvider);
                case BookFormat.ANP:
                    return $"{this.Author} {this.Name} {this.Publishig}".ToString(formatProvider);
                case BookFormat.FI:
                    return $"{this.ISBN} {this.Author} {this.Name} {this.Publishig} {this.Year} {this.PageCount} {this.Price}".ToString(formatProvider);
                case BookFormat.IANP:
                    return $"{this.ISBN} {this.Author} {this.Name} {this.Publishig}".ToString(formatProvider);
                case BookFormat.N:
                    return $"{this.Name}".ToString(formatProvider);
                default:
                    throw new FormatException($"Incorrect string format {bookFormat}");
            }
        }

        public int CompareTo(object other)
        {
            if (other == null)
            {
                return 1;
            }

            var otherBook = other as Book;

            if (otherBook == null)
            {
                throw new ArgumentException($"{nameof(other)}");
            }

            if (string.Compare(this.ISBN, otherBook.ISBN, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.ISBN, otherBook.ISBN, StringComparison.Ordinal);
            }

            if (string.Compare(this.Author, otherBook.Author, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.Author, otherBook.Author, StringComparison.Ordinal);
            }

            if (string.Compare(this.Name, otherBook.Name, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.Name, otherBook.Name, StringComparison.Ordinal);
            }

            if (string.Compare(this.Publishig, otherBook.Publishig, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.Publishig, otherBook.Publishig, StringComparison.Ordinal);
            }

            if (this.Year.CompareTo(otherBook.Year) != 0)
            {
                return this.Year.CompareTo(otherBook.Year);
            }

            if (this.Price.CompareTo(otherBook.Price) != 0)
            {
                return this.Price.CompareTo(otherBook.Price);
            }

            if (this.PageCount.CompareTo(otherBook.PageCount) != 0)
            {
                return this.PageCount.CompareTo(otherBook.PageCount);
            }

            return 0;
        }

        #region Private methods

        private bool CheckEqualityProperty(Book book1, Book book2)
        {
            if (book1.ISBN != book2.ISBN)
            {
                return false;
            }

            if (book1.Author != book2.Author)
            {
                return false;
            }

            if (book1.Name != book2.Name)
            {
                return false;
            }

            if (book1.Publishig != book2.Publishig)
            {
                return false;
            }

            if (book1.Year != book2.Year)
            {
                return false;
            }

            if (book1.Author != book2.Author)
            {
                return false;
            }

            if (book1.PageCount != book2.PageCount)
            {
                return false;
            }

            if (book1.Price != book2.Price)
            {
                return false;
            }

            return true;
        }

        private void DataValidation(string isbn, string author, string name, string publishing, uint year, uint pageCount, decimal price)
        {
            if (string.IsNullOrWhiteSpace(isbn))
            {
                throw new ArgumentNullException(nameof(isbn));
            }

            if (string.IsNullOrWhiteSpace(author))
            {
                throw new ArgumentNullException(nameof(author));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            if (string.IsNullOrWhiteSpace(publishing))
            {
                throw new ArgumentNullException(nameof(publishing));
            }

            if (year > DateTime.Now.Year || year == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(year));
            }

            if (pageCount == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(pageCount));
            }

            if (price <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(price));
            }
        }
        #endregion
    }
}