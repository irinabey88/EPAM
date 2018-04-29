using System;
using BankAccounts.Common.AccountCreator;
using BankAccounts.Common.Dto;
using BankAccounts.Common.Enumes;
using BankAccounts.Common.Interfaces.BonusCounter;
using BankAccounts.Common.Models;

namespace BankAccounts.Common.Mappers
{
    /// <summary>
    /// Map account and bank account, that represents account on diffrent layers
    /// </summary>
    public static class AccountMapper
    {
        /// <summary>
        /// Get bank account from account
        /// </summary>
        /// <param name="account">Account</param>
        /// <param name="bonusCounter"></param>
        /// <returns>Bank account</returns>
        public static BankAccount MapBankAccount(this Account account, IBonusCounter bonusCounter) => new BankAccount(bonusCounter)
        {                      
            Type = (int)account.TypeAccount,
            Amount = account.Amount,
            Bonus = account.Bonus,
            FirstName = account.FirstName,
            Lastname = account.LastName,
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
            accountMapped.Id = account.Id;
            accountMapped.Amount = account.Amount;
            accountMapped.Bonus = account.Bonus;
            accountMapped.IsClosed = account.IsClosed;

            return accountMapped;
        }
    }
}
