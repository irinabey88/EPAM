namespace BookFormater
{
    using System;
    using System.Globalization;
    using Models;

    /// <summary>
    /// Inialize class of custom format <see cref="Book"/>
    /// </summary>
    public class BookFormatter : IFormatProvider, ICustomFormatter
    {
        private IFormatProvider root;

        public BookFormatter() : this(CultureInfo.CurrentCulture) { }

        public BookFormatter(IFormatProvider provider)
        {
            this.root = provider;
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
            {
                return this;
            }

            return null;
        }

        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!this.Equals(formatProvider))
            {
                return null;
            }

            if (string.IsNullOrEmpty(format))
            {
                format = "AN";                
            }

            Book book = arg as Book;
            if (ReferenceEquals(book, null))
            {
                throw new InvalidCastException($"Input argument {nameof(arg)} isn't a book");
            }

            switch (format.ToUpperInvariant())
            {
                case "G":
                    return book.ToString();
                case "IAN":
                    return $"/{book.ISBN} /{book.Author} /{book.Name}";
                case "I":
                    return $"/{book.ISBN}";
                default:
                    throw new FormatException($"Incorrect string format {format}");
            }
        }
    }
}