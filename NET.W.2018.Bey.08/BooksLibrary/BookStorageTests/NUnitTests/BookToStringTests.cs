namespace NET.W._2018.Bey._08.Tests.NUnitTests
{
    using System;
    using Models;
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
    }
}
