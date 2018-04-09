using System;
using BookFormater;

namespace NET.W._2018.Bey._08.Tests.NUnitTests
{
    using Models.Book;
    using NUnit.Framework;

    [TestFixture]
    public class BookToStringTests
    {
        private Book book = new ScientificBook("978-0735667457", "Richter", "CLR via C#", "O'REILlY", 2013, 896, 176);

        [TestCase("N", ExpectedResult = "CLR via C#")]
        [TestCase("AN", ExpectedResult = "Richter CLR via C#")]
        [TestCase("ANP", ExpectedResult = "Richter CLR via C# O'REILlY")]
        [TestCase("IANP", ExpectedResult = "978-0735667457 Richter CLR via C# O'REILlY")]
        [TestCase("FI", ExpectedResult = "978-0735667457 Richter CLR via C# O'REILlY 2013 896 176")]
        public string Book_ToString_ValidData_Test(string format)
        {           
            return book.ToString(format);
        }

        [TestCase("FFFFFFF")]
        public void Book_ToString_InvalidData_Test(string format)
        {
            Assert.Throws<FormatException>(() => this.book.ToString(format));
        }

        [TestCase("{0:IANP}", ExpectedResult = "978-0735667457 Richter CLR via C# 176")]
        [TestCase("{0:Ianp}", ExpectedResult = "978-0735667457 Richter CLR via C# 176")]
        public string Book_ToString_BookFormatter_ValidData_Test(string format)
        {           
            return string.Format(new BookFormatter(), format, this.book);
        }

        [TestCase("{0:inap}")]
        public void Book_ToString_BookFormatter_InvalidData_Tests(string format)
        {
            Assert.Throws<FormatException>(() => string.Format(new BookFormatter(), format, this.book));
        }
    }
}
