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
            var fileAccountStorage = @"D:\AccountStorage.txt";
            var fileUserStorage = @"D:\UserStorage.txt";

            var accountService = new BankAccountsService(new BankAccountsStorage(fileAccountStorage), new UserStorage(fileUserStorage));
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
