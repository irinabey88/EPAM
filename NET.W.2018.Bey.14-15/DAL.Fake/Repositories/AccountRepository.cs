using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Fake.Exceptions;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    /// <summary>
    /// Provides repository of account
    /// </summary>
    public class AccountRepository : IAccountRepository
    {
        private readonly IList<BankAccount> _accounts;

        /// <summary>
        /// Get instance of <see cref="AccountRepository"/>
        /// </summary>
        public AccountRepository()
        {
            this._accounts = new List<BankAccount>();
        }

        /// <summary>
        /// Get account from repository
        /// </summary>
        /// <param name="id">Account number</param>
        /// <returns>Account</returns>
        public BankAccount Get(int id)
        {
            return this._accounts.FirstOrDefault(x => x.Number == id);
        }

        /// <summary>
        /// Get account from repository
        /// </summary>
        /// <param name="model">Account</param>
        /// <returns>Account</returns>
        /// <exception cref="ArgumentNullException">Null data</exception>
        public BankAccount Get(BankAccount model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return Get(model.Number);
        }

        /// <summary>
        /// Add account to repository
        /// </summary>
        /// <param name="model">Account to add</param>
        /// <returns>Added account or null</returns>
        /// <exception cref="ArgumentNullException">Null data</exception>
        public BankAccount Add(BankAccount model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var account = Get(model.Number);
            if (account != null)
            {
                throw new AddException(model.Number);
            }

            this._accounts.Add(model);

            return model;
        }

        /// <summary>
        ///Update account in repository
        /// </summary>
        /// <param name="model">Updated account</param>
        /// <returns>Updated account or null</returns>
        /// <exception cref="ArgumentNullException">Null data</exception>
        public BankAccount Update(BankAccount model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            var account = Get(model.Number) ?? throw new NotFoundException(model.Number);
            this._accounts.Remove(account);
            this._accounts.Add(model);

            return model;
        }

        /// <summary>
        /// Get all accounts in repository
        /// </summary>
        /// <returns>Accountslist</returns>
        public IEnumerable<BankAccount> GetAllElements()
        {
            return this._accounts;
        }
    }
}