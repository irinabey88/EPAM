using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.AccountCreator;
using BLL.Interface.Entities;
using BLL.Interface.Enumes;
using DAL.Interface.DTO;

namespace BLL.Mappers
{
    internal static class AccountMapper
    {
        public static BankAccount MapBankAccount(this Account account) => new BankAccount
        {
            Type = (int)account.TypeAccount,
            Amount = account.Amount,
            Bonus = account.Bonus,
            FirstName = account.FirstName,
            Lastname = account.LastName,
            Number = account.Number,
            IsClosed = account.IsClosed
        };

        public static Account MapAccount(this BankAccount account)
        {
            AccountType accountType;

            if (!Enum.TryParse(account.Type.ToString(), out accountType))
            {
                throw new InvalidCastException(nameof(account.Type));
            }

            var accountMapped = AccountFactory.Create(0, account.FirstName, account.Lastname, accountType);
            accountMapped.Number = account.Number;
            accountMapped.Amount = account.Amount;
            accountMapped.Bonus = account.Bonus;
            accountMapped.IsClosed = account.IsClosed;

            return accountMapped;
        }
    }
}
