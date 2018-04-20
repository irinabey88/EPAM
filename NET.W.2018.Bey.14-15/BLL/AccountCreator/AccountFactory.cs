using System;
using BLL.Interface.Entities;
using BLL.Interface.Enumes;

namespace BLL.AccountCreator
{
    public static class AccountFactory
    {
        public static Account Create(string firstName, string lastName, AccountType typeAccount)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            switch (typeAccount)
            {
                case AccountType.Base:
                    return new BaseAccount(firstName, lastName, typeAccount, 0, 0);
                case AccountType.Gold:
                    return new GoldAccount(firstName, lastName, typeAccount, 0, 0);
                case AccountType.Platinum:
                    return new PlatinumAccount(firstName, lastName, typeAccount, 0, 0);
                default:
                    throw new InvalidOperationException($"Type account isn't supported");
            }
        }
    }
}