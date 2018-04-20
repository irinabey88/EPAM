using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using BLL.AccountCreator;
using BLL.Interface.Entities;
using BLL.Interface.Enumes;
using BLL.Interface.Exception;
using BLL.Interface.Interfaces;
using BLL.Mappers;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class AccountService : IAccountService<Account>
    {
        private IAccountRepository _accountRepository;

        public AccountService(IAccountRepository accountRepository)
        {
            this._accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
        }

        public Account CreateAccount(string firstName, string lastName, AccountType typeAccount)
        {
            var account = AccountFactory.Create(firstName, lastName, typeAccount);
            var addedAccount = this._accountRepository.Add(account.MapBankAccount());

            return addedAccount.MapAccount();
        }

        public Account CloseAccount(int accountId)
        {
            var bankAccount = this._accountRepository.Get(accountId) ?? throw new NotFoundException(accountId);
            bankAccount.IsClosed = false;

            var accountClosed = this._accountRepository.Update(bankAccount);

            return accountClosed.MapAccount();
        }

        public Account GetAccount(int accountId)
        {
            var  bankAccount = this._accountRepository.Get(accountId) ?? throw new NotFoundException(accountId);

            return bankAccount.MapAccount();
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            var listBankAccount = this._accountRepository.GetAllElements();
            var accounts = new List<Account>();

            foreach (var bankAccount in listBankAccount)
            {
                accounts.Add(bankAccount.MapAccount());
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

            var accountClosed = this._accountRepository.Update(bankAccount);

            return accountClosed.MapAccount();

        }

        public Account DepositMoney(int accountId, decimal amount)
        {
            var bankAccount = this._accountRepository.Get(accountId) ?? throw new NotFoundException(accountId);
           
            bankAccount.Amount += amount;

            var accountClosed = this._accountRepository.Update(bankAccount);

            return accountClosed.MapAccount();
        }     
    }
}