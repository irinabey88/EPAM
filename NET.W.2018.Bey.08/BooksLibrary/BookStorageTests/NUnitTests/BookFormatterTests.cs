using System;
using BookFormater;
using Models;
using NUnit.Framework;

namespace BookStorageTests.NUnitTests
{
    [TestFixture]
    public class BookFormatterTests
    {
        private Book book = new ScientificBook("978-0735667457", "Richter", "CLR via C#", "O'REILlY", 2013, 896, 176);

        [TestCase("{0:IAN}", ExpectedResult = "/978-0735667457 /Richter /CLR via C#")]
        [TestCase("{0:G}", ExpectedResult = "Richter CLR via C#")]
        [TestCase("{0:I}", ExpectedResult = "/978-0735667457")]
        public string Book_ToString_BookFormatter_ValidData_Test(string format)
        {
            var t = string.Format(new BookFormatter(), format, this.book);
            return t;
        }


        [TestCase("{0:K}")]
        public void Book_ToString_BookFormatter_InvalidData_Tests(string format)
        {
            Assert.Throws<FormatException>(() => string.Format(new BookFormatter(), format, this.book));
        }

    }
}
