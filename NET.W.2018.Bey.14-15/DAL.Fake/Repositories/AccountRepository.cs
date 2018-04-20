using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Fake.Exceptions;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Fake.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        private IList<BankAccount> _accounts;

        public AccountRepository()
        {
            this._accounts = new List<BankAccount>();
        }

        public BankAccount Get(int id)
        {
            return this._accounts.FirstOrDefault(x => x.Number == id);
        }

        public BankAccount Get(BankAccount model)
        {
            if (model == null)
            {
                throw new ArgumentNullException(nameof(model));
            }

            return Get(model.Number);
        }

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

        public IEnumerable<BankAccount> GetAllElements()
        {
            return this._accounts;
        }
    }
}