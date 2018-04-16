using System;

namespace BinaryTreeTests.CustomObject
{
    /// <summary>
    /// Provides book object
    /// </summary>
    public class Book : IEquatable<Book>, IComparable, IComparable<Book>
    {
        private string _isbn;
        private string _author;
        private string _name;
        private int _year;
        private uint _pageCount;
        private decimal _price;

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
        /// Year of publishing
        /// </summary>
        public int Year
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

            return this.ISBN.Equals(other.ISBN);
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

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return 1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            return CompareTo(obj as Book);
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

            return string.CompareOrdinal(this.ISBN, other.ISBN);
        }
    }
}