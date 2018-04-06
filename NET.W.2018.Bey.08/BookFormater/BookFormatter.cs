namespace BookFormater
{
    using System;
    using NET.W._2018.Bey._08.Models.Book;
    using static System.Globalization.CultureInfo;

    public class BookFormatter : IFormatProvider, ICustomFormatter
    {
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

            switch (format.ToUpper())
            {
                case "IANP":
                    return $"{book.ISBN} {book.Author} {book.Name} {string.Format(book.Price.ToString(CurrentCulture))}";
                default:
                    throw new FormatException($"Incorrect string format {format}");
            }
        }
    }
}