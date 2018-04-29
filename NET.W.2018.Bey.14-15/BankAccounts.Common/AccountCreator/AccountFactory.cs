using System;
using BankAccounts.Common.Dto;
using BankAccounts.Common.Enumes;
using BankAccounts.Common.Interfaces.BonusCounter;

namespace BankAccounts.Common.AccountCreator
{
    public static class AccountFactory
    {
        public static Account Create(int id, string firstName, string lastName, AccountType typeAccount, IBonusCounter bonusCounter)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            if (bonusCounter == null)
            {
                throw new ArgumentNullException(nameof(bonusCounter));
            }

            switch (typeAccount)
            {
                case AccountType.Base:
                    return new BaseAccount(id, firstName, lastName, typeAccount, 0, 0, bonusCounter);
                case AccountType.Gold:
                    return new GoldAccount(id, firstName, lastName, typeAccount, 0, 0, bonusCounter);
                case AccountType.Platinum:
                    return new PlatinumAccount(id, firstName, lastName, typeAccount, 0, 0, bonusCounter);
                default:
                    throw new InvalidOperationException($"Type account isn't supported");
            }
        }
    }
}