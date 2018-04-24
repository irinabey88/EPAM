using System;
using System.Collections.Generic;
using System.Linq;
using BLL.AccountCreator;
using BLL.Interface.Entities;
using BLL.Interface.Enumes;
using BLL.Interface.Interfaces;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.Mappers
{
    /// <summary>
    /// Map account and bank account, that represents account on diffrent layers
    /// </summary>
    internal static class AccountMapper
    {
        /// <summary>
        /// Get bank account from account
        /// </summary>
        /// <param name="account">Account</param>
        /// <param name="bonusCounter"></param>
        /// <returns>Bank account</returns>
        public static BankAccount MapBankAccount(this Account account, IBonusCounter bonusCounter) => new BankAccount (bonusCounter)
        {            
            Type = (int)account.TypeAccount,
            Amount = account.Amount,
            Bonus = account.Bonus,
            FirstName = account.FirstName,
            Lastname = account.LastName,
            Number = account.Number,
            IsClosed = account.IsClosed
        };

        /// <summary>
        /// Get account from bank account
        /// </summary>
        /// <param name="account">Bank account</param>
        /// <returns>Account</returns>
        public static Account MapAccount(this BankAccount account, IBonusCounter bonusCounter)
        {
            if (bonusCounter == null)
            {
                throw new ArgumentNullException(nameof(bonusCounter));
            }

            if (!Enum.TryParse(account.Type.ToString(), out AccountType accountType))
            {
                throw new InvalidCastException(nameof(account.Type));
            }

            var accountMapped = AccountFactory.Create(0, account.FirstName, account.Lastname, accountType, bonusCounter);
            accountMapped.Number = account.Number;
            accountMapped.Amount = account.Amount;
            accountMapped.Bonus = account.Bonus;
            accountMapped.IsClosed = account.IsClosed;

            return accountMapped;
        }
    }
}
