namespace BookFormater
{
    using System;

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

            switch (format)
            {
                case "AN":
                case "ANP":
                case "FI":
                case "IANP":
                case "N":
                    return $"{arg.ToString()} bookstore Booktown";
                default:
                    throw new FormatException($"Incorrect string format {format}");
            }
        }
    }
}