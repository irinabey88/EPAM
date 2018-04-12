namespace ConsoleBook
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    using BuisnesLogic.Services;
    using BuisnessLogic;
    using CustomLogger;
    using DataAccess.Repositories;
    using Models;
    using Models.Comparer;

    public class Program
    {
        public static void Main(string[] args)
        {
            string _fileSource = @"D:\Test\BookStorage.txt";

            if (File.Exists(_fileSource))
            {
                File.Delete(_fileSource);
            }

            IBookListService<Book> _bookService = new BookListService(new BookListStorage(_fileSource));
            _bookService.AddBook(new ScientificBook("978-0735667457", "Richter", "CLR via C#", "O'REILlY", 2013, 896, 176));
            _bookService.AddBook(new ScientificBook("978-5-84592087-4", "Albahary", "C# in nutshell", "O'REILlY", 2017, 1040, 250));
            _bookService.AddBook(new ScientificBook("0-321-12742-0", "Fauler", "Architecture of corporate software applications", "Williams", 2006, 541, 90));
            _bookService.AddBook(new ScientificBook("978-1509304066", "Chambers", "ASP .Net Core application development", "Microsot Press", 2017, 464, 70));

            BookLogger.Debug("Tests");

            var books = _bookService.GetAllBooks();
            PrintArray(books);

            _bookService.AddBook(new ScientificBook("1111111", "Test", "Test", "Test", 2013, 896, 176));
            books = _bookService.GetAllBooks();
            PrintArray(books);

            books = _bookService.SortBookByTag(new YearComparer());
            PrintArray(books);

            _bookService.RemoveBook(new ScientificBook("1111111", "Test", "Test", "Test", 2013, 896, 176));
            books = _bookService.SortBookByTag(new YearComparer());
            PrintArray(books);

            Console.ReadLine();
        }

        private static void PrintArray(IEnumerable<Book> books)
        {
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            Console.WriteLine();
        }
    }
}
