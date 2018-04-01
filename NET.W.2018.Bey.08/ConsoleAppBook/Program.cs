using NET.W._2018.Bey._08.Models.BankAccount;

namespace ConsoleAppBook
{
    using System;
    using System.Collections.Generic;
    using NET.W._2018.Bey._08.Repositories;
    using NET.W._2018.Bey._08.Services;

    public class Program
    {
        public static void Main(string[] args)
        {
            ////var fileBookStorage = @"D:\BookStorage.txt";
            ////if (File.Exists(fileBookStorage))
            ////{
            ////    File.Delete(fileBookStorage);
            ////}

            ////var bookService = new BookListService(new BookListStorage(fileBookStorage));
            ////bookService.AddBook(new FictionBook("978-0735667457", "Richter", "CLR via C#", "O'REILlY", 2013, 896, 176));
            ////bookService.AddBook(new FictionBook("978-5-84592087-4", "Albahary", "C# in nutshell", "O'REILlY", 2017, 1040, 250));
            ////bookService.AddBook(new FictionBook("0-321-12742-0", "Fauler", "Architecture of corporate software applications", "Williams", 2006, 541, 90));
            ////bookService.AddBook(new FictionBook("978-1509304066", "Chambers", "ASP .Net Core application development", "Microsot Press", 2017, 464, 70));
            ////var listObjects = bookService.GetAllBooks();
            ////PrintBookList(listObjects);
            ////Console.ReadLine();

            ////bookService.RemoveBook(new FictionBook("0-321-12742-0", "Fauler", "Architecture of corporate software applications", "Williams", 2006, 541, 90));
            ////listObjects = bookService.GetAllBooks();
            ////PrintBookList(listObjects);
            ////Console.ReadLine();

            ////var sortedBooks = bookService.SortBookByTag(BookTagsName.ISBN);
            ////PrintBookList(sortedBooks);
            ////Console.ReadLine();

            ////PrintBookList(bookService.FindBookByTag(BookTagsName.ISBN, "978-5-84592087-4"));
            ////Console.ReadLine();

            var fileAccountStorage = @"D:\AccountStorage.txt";
            var fileUserStorage = @"D:\UserStorage.txt";

            ////if (File.Exists(fileAccountStorage))
            ////{
            ////    File.Delete(fileAccountStorage);
            ////}

            ////var user1 = new BankUser("Iryna", "Bey");
            ////var user2 = new BankUser("Alexey", "Bey");
            ////var user3 = new BankUser("Aleksandr", "Bey");

            var accountService = new BankAccountsService(new BankAccountsStorage(fileAccountStorage), new UserStorage(fileUserStorage));
            
            ////accountService.CreateAccount(user2, BankAccountType.Base);
            ////accountService.CreateAccount(user3, BankAccountType.Gold);
            ////accountService.CreateAccount(user1, BankAccountType.Platinum);

            PrintBookList(accountService.GetAllAccounts());

            Console.ReadLine();

            ////accountService.DepositMoney("1621108a-fc83-4a67-a76f-20c4827b72b9", 10000);
            ////accountService.DepositMoney("b3adc3de-61d5-46c0-9c05-a0c532ddeeca", 6000);
            ////accountService.DepositMoney("a5207b57-2b07-41f7-98c7-48b4d995f6d4", 1000);
            ////accountService.WithdrawMoney("1621108a-fc83-4a67-a76f-20c4827b72b9", 70);

            PrintBookList(accountService.GetAllAccounts());

            Console.ReadLine();
        }

        private static void PrintBookList(IEnumerable<object> listObjects)
        {
            var i = 1;

            foreach (var element in listObjects)
            {
                Console.WriteLine($"{i}. {element}");
                i++;
            }
        }
    }
}
