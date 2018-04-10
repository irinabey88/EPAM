using BuisnesLogic.Exception.BankAccount;
using BuisnesLogic.Exception.User;

namespace BuisnesLogic.Services
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using Common.Interfaces;
    using Common.Interfaces.Repositories;
    using Common.Interfaces.Services;
    using Models;
    using Models.Accounts;
    using Models.Accounts.Base;
    using Models.Enum;

    /// <summary>
    /// Provides business logik of work with bank account
    /// </summary>
    public class BankAccountsService : IBankAccountService<BankAccount>
    {
        /// <summary>
        /// Instance of banks accounts storage
        /// </summary>
        private readonly IBankAccountRepository _accountRepository;

        /// <summary>
        /// Instansce of user storage
        /// </summary>
        private readonly IUserRepository _userRepository;

        /// <summary>
        /// Provides instance of AccountService
        /// </summary>
        /// <param name="accountRepository"></param>
        /// <param name="userRepository"></param>
        public BankAccountsService(IBankAccountRepository accountRepository, IUserRepository userRepository)
        {
            this._accountRepository = accountRepository ?? throw new ArgumentNullException(nameof(accountRepository));
            this._userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        }

        public BankAccount CloseAccount(string accountId)
        {
            var account = this._accountRepository.Get(accountId) ?? throw new GetAccountException(accountId);

            if (account.IsClosed)
            {
                throw new ClosedAccountException(accountId);
            }

            var updatedAccount = UpdateAccounts(account, true);

            return this._accountRepository.Update(updatedAccount);
        }

        public BankAccount CreateAccount(BankUser bankUser, BankAccountType typeAccount)
        {
            if (bankUser == null)
            {
                throw new ArgumentNullException(nameof(bankUser));
            }

            var user = this._userRepository.Add(bankUser);
            var account = CreateAccountByType(user, typeAccount);
            return this._accountRepository.Add(account);
        }

        public BankAccount GetAccount(string accountId)
        {
            if (string.IsNullOrWhiteSpace(accountId))
            {
                throw new ArgumentNullException(nameof(accountId));
            }

            return this._accountRepository.Get(accountId);
        }

        public IEnumerable<BankAccount> GetAllAccounts()
        {
            return this._accountRepository.GetAllElements();
        }

        public BankAccount WithdrawMoney(string accountId, uint amount)
        {
            var account = this._accountRepository.Get(accountId) ?? throw new GetAccountException(accountId);

            if (account.IsClosed)
            {
                throw new ClosedAccountException(accountId);
            }

            if (amount == 0)
            {
                throw new ZeroAmountOperatioException(accountId);
            }

            if (amount > account.Amount)
            {
                throw new WithdrawException(account.AccountId);
            }

            int bonus = (int)((-1) * amount * account.Rate / (100 * 2));
            var updatedAccount = UpdateAccounts(account, false, (int)(-1 * amount), bonus);

            return this._accountRepository.Update(updatedAccount);
        }

        public BankAccount DepositMoney(string accountId, uint amount)
        {
            var account = this._accountRepository.Get(accountId) ?? throw new GetAccountException(accountId);

            if (account.IsClosed)
            {
                throw new ClosedAccountException(accountId);
            }

            if (amount == 0)
            {
                throw new ZeroAmountOperatioException(accountId);
            }

            int bonus = (int)(amount * account.Rate / 100);
            var updatedAccount = UpdateAccounts(account, false, (int)amount, bonus);

            return this._accountRepository.Update(updatedAccount);
        }

        public IEnumerable<BankAccount> FindUserAccounts(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            var user = this._userRepository.FindUserByName(firstName, lastName) ??
                       throw new NotFoundUserException(firstName, lastName);

            List<BankAccount> accountList = new List<BankAccount>();
            var listAccount = this._accountRepository.GetAllElements();

            foreach (var account in listAccount) 
            {
                if (account.User.UserId.Equals(user.UserId))
                {
                    accountList.Add(account);
                    break;
                }
            }

            return accountList;
        }

        #region Private methods

        private BankAccount CreateAccountByType(BankUser bankUser, BankAccountType typeAccount)
        {
            if (bankUser == null)
            {
                throw new ArgumentNullException(nameof(bankUser));
            }

            BankAccount newAccount;

            switch (typeAccount)
            {
                case BankAccountType.Base:
                    newAccount = new BaseAccount(bankUser);
                    break;
                case BankAccountType.Gold:
                    newAccount = new GoldAccount(bankUser);
                    break;
                case BankAccountType.Platinum:
                    newAccount = new PlatinumAccount(bankUser);
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(typeAccount));
            }

            return newAccount;
        }

        private BankAccount UpdateAccounts(BankAccount account, bool isClosed = false, int amount = 0, int bonus = 0)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            BankAccount newAccount;

            switch (account.TypeAccount)
            {
                case BankAccountType.Base:
                    newAccount = new BaseAccount(account.User, account.AccountId, account.TypeAccount, (uint)(account.Amount + amount), (uint)(account.Bonus + bonus), isClosed);
                    break;
                case BankAccountType.Gold:
                    newAccount = new GoldAccount(account.User, account.AccountId, account.TypeAccount, (uint)(account.Amount + amount), (uint)(account.Bonus + bonus), isClosed);
                    break;
                case BankAccountType.Platinum:
                    newAccount = new PlatinumAccount(account.User, account.AccountId, account.TypeAccount, (uint)(account.Amount + amount), (uint)(account.Bonus + bonus), isClosed);
                    break;
                default:
                    throw new InvalidEnumArgumentException(nameof(account.TypeAccount));
            }

            return newAccount;
        }

        #endregion
    }
}