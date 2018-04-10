namespace Models
{
    using System;
    using System.Globalization;

    /// <summary>
    /// Provides bank book object
    /// </summary>
    public abstract class Book : IEquatable<Book>, IComparable, IComparable<Book>, IFormattable
    {
        private string _isbn;
        private string _author;
        private string _name;
        private string _publishing;
        private uint _year;
        private uint _pageCount;
        private decimal _price;

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
        public string ISBN
        {
            get => this._isbn;
            set
            {                
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"String is empty or null");
                }

                _isbn = value;
            }
        }

        /// <summary>
        /// Author
        /// </summary>
        public string Author
        {
            get => this._author;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"String is empty or null");
                }

                this._author = value;
            }
        }

        /// <summary>
        /// Book Name
        /// </summary>
        public string Name
        {
            get => this._name;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"String is empty or null");
                }

                this._name = value;
            }
        }

        /// <summary>
        /// Publishing
        /// </summary>
        public string Publishig
        {
            get => this._publishing;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException($"String is empty or null");
                }

                this._publishing = value;
            }
        }

        /// <summary>
        /// Year of publishing
        /// </summary>
        public uint Year
        {
            get => this._year;
            set => this._year = value;
        }

        /// <summary>
        /// Page count
        /// </summary>
        public uint PageCount
        {
            get => this._pageCount;
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException($"The count of pages should be more than 0!");
                }

                this._pageCount = value;
            }
        }

        /// <summary>
        /// Price
        /// </summary>
        public decimal Price
        {
            get => this._price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException($"Price should be  positive value");
                }

                this._price = value;
            }
        }

        #region overrides operation

        public static bool operator ==(Book lhs, Book rgs)
        {
            if (ReferenceEquals(lhs, rgs))
            {
                return true;
            }

            if (ReferenceEquals(null, lhs))
            {
                return false;
            }

            return lhs.Equals(rgs);
        }

        public static bool operator !=(Book lhs, Book rhs)
        {
            return !(lhs == rhs);
        }

        #endregion

        #region Equals

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
            
            return CheckEqualityBook(this, other);
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

        #endregion

        #region ToString

        public override string ToString()
        {
            return this.ToString(BookFormat.AN.ToString());
        }

        public string ToString(string format)
        {
            return this.ToString(format, CultureInfo.CurrentCulture);
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

        #endregion

        #region Comparer
        
        public int CompareTo(object other)
        {
            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            return CompareTo(other as Book);
        }

        public int CompareTo(Book other)
        {
            if (ReferenceEquals(null, other))
            {
                return 1;
            }

            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            if (string.Compare(this.ISBN, other.ISBN, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.ISBN, other.ISBN, StringComparison.Ordinal);
            }

            if (string.Compare(this.Author, other.Author, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.Author, other.Author, StringComparison.Ordinal);
            }

            if (string.Compare(this.Name, other.Name, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.Name, other.Name, StringComparison.Ordinal);
            }

            if (string.Compare(this.Publishig, other.Publishig, StringComparison.Ordinal) != 0)
            {
                return string.Compare(this.Publishig, other.Publishig, StringComparison.Ordinal);
            }

            if (this.Year.CompareTo(other.Year) != 0)
            {
                return this.Year.CompareTo(other.Year);
            }

            if (this.Price.CompareTo(other.Price) != 0)
            {
                return this.Price.CompareTo(other.Price);
            }

            if (this.PageCount.CompareTo(other.PageCount) != 0)
            {
                return this.PageCount.CompareTo(other.PageCount);
            }

            return 0;
        }

        #endregion        

        #region Private methods

        private bool CheckEqualityBook(Book book1, Book book2)
        {
            return string.Equals(book1.ISBN, book2.ISBN);
        }        
        #endregion
    }
}