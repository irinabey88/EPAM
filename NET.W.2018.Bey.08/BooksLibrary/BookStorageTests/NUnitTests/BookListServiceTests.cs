namespace BookStorageTests.NUnitTests
{
    using System;
    using System.IO;
    using System.Linq;

    using BuisnesLogic.Services;
    using BuisnessLogic;
    using CustomLogger;
    using DataAccess.Repositories;
    using Models;
    using Models.Comparer;
    using NUnit.Framework;

    [TestFixture]
    public class BookListServiceTests
    {
        private readonly string _fileSource = @"D:\Test\BookStorage.txt";

        private IBookListService<Book> _bookService;

        public BookListServiceTests()
        {
            if (File.Exists(this._fileSource))
            {
                File.Delete(this._fileSource);
            }

            this._bookService = new BookListService(new BookListStorage(this._fileSource));
            _bookService.AddBook(new ScientificBook("978-0735667457", "Richter", "CLR via C#", "O'REILlY", 2013, 896, 176));
            _bookService.AddBook(new ScientificBook("978-5-84592087-4", "Albahary", "C# in nutshell", "O'REILlY", 2017, 1040, 250));
            _bookService.AddBook(new ScientificBook("0-321-12742-0", "Fauler", "Architecture of corporate software applications", "Williams", 2006, 541, 90));
            _bookService.AddBook(new ScientificBook("978-1509304066", "Chambers", "ASP .Net Core application development", "Microsot Press", 2017, 464, 70));

            BookLogger.Debug("Tests");
        }

        [SetUp]
        public void InitialisationsTestMethod()
        {
            BookLogger.Debug("Test run");
        }

        [TearDown]
        public void ClearTest()
        {
            BookLogger.Debug("Test done");
        }

        [Test]
        public void BookListService_GetAllBooks_Test()
        {
            Assert.AreEqual(this._bookService.GetAllBooks().Count(), 5);
        }

        [Test]
        public void BookListService_AddBook_InvalidData_Test()
        {
            Assert.Throws<ArgumentNullException>(() => this._bookService.AddBook(null));
        }

        [Test]
        public void BookListService_AddBook_ValidData_Test()
        {
            Assert.AreNotEqual(
                this._bookService.AddBook(new ScientificBook("1111111", "Test", "Test", "Test", 2013, 896, 176)), null);
        }

        [Test]
        public void BookListService_RemoveBook_InvalidData_Test()
        {
            Assert.Throws<ArgumentNullException>(() => this._bookService.RemoveBook(null));
        }      

        [Test]
        public void BookListService_FindBookByTag_ValidData_Test()
        {
            Assert.AreEqual(1, this._bookService.FindBookByTag(x => x.Author.Equals("Richter")).Count());
        }     

        [Test]
        public void BookListService_SortBookByTag_Test()
        {
            var sortedBookList = this._bookService.SortBookByTag(new YearComparer()).ToArray();

            for (int i = 0; i < sortedBookList.Length - 1; i++)
            {
                Assert.IsTrue(sortedBookList[i].Year <= sortedBookList[i + 1].Year);
            }
        }

        [Test]
        public void BookListService_RemoveBook_ValidData_Test()
        {
            Assert.AreNotEqual(
                this._bookService.RemoveBook(new ScientificBook("1111111", "Test", "Test", "Test", 2013, 896, 176)), null);
        }
    }
}
