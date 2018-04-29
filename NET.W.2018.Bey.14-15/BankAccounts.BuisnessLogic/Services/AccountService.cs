using System;
using System.Collections.Generic;
using BankAccounts.Common.AccountCreator;
using BankAccounts.Common.Dto;
using BankAccounts.Common.Enumes;
using BankAccounts.Common.Exception;
using BankAccounts.Common.Interfaces.BonusCounter;
using BankAccounts.Common.Interfaces.Repositories;
using BankAccounts.Common.Interfaces.Services;
using BankAccounts.Common.Mappers;

namespace BankAccounts.BusinessLogic.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository;
        private readonly IBonusCounter _bonusCounter;

        public AccountService(IAccountRepository accountRepository, IBonusCounter bonusCounter)
        {
            this._accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            this._bonusCounter = bonusCounter ?? throw new ArgumentNullException(nameof(bonusCounter));
        }

        public Account CreateAccount(string firstName, string lastName, AccountType typeAccount)
        {
            var account = AccountFactory.Create(0, firstName, lastName, typeAccount, this._bonusCounter);
            var addedAccount = this._accountRepository.Add(account.MapBankAccount(this._bonusCounter));

            return addedAccount.MapAccount(this._bonusCounter);
        }

        public Account CloseAccount(int accountId)
        {
            var bankAccount = this._accountRepository.Get(accountId) ?? throw new NotFoundException(accountId);
            bankAccount.IsClosed = false;

            var accountClosed = this._accountRepository.Update(bankAccount);

            return accountClosed.MapAccount(this._bonusCounter);
        }

        public Account GetAccount(int accountId)
        {
            var bankAccount = this._accountRepository.Get(accountId) ?? throw new NotFoundException(accountId);

            return bankAccount.MapAccount(this._bonusCounter);
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            var listBankAccount = this._accountRepository.GetAllElements();
            var accounts = new List<Account>();

            foreach (var bankAccount in listBankAccount)
            {
                accounts.Add(bankAccount.MapAccount(this._bonusCounter));
            }

            return accounts;
        }

        public Account WithdrawMoney(int accountId, decimal amount)
        {
            var bankAccount = this._accountRepository.Get(accountId) ?? throw new NotFoundException(accountId);

            if (bankAccount.Amount < amount)
            {
                throw new WithdrawException(accountId);
            }

            bankAccount.Amount -= amount;

            var account = this._accountRepository.Update(bankAccount);

            return account.MapAccount(this._bonusCounter);
        }

        public Account DepositMoney(int accountId, decimal amount)
        {
            var bankAccount = this._accountRepository.Get(accountId) ?? throw new NotFoundException(accountId);
           
            bankAccount.Amount += amount;

            var account = this._accountRepository.Update(bankAccount);

            return account.MapAccount(this._bonusCounter);
        }     
    }
}