using System;
using BLL.Interface.Entities;
using BLL.Interface.Enumes;
using BLL.Interface.Interfaces;
using DAL.Interface.Interfaces;

namespace BLL.AccountCreator
{
    public static class AccountFactory
    {
        public static Account Create(int number,string firstName, string lastName, AccountType typeAccount, IBonusCounter bonusCounter)
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
                    return new BaseAccount(number, firstName, lastName, typeAccount, 0, 0, bonusCounter);
                case AccountType.Gold:
                    return new GoldAccount(number, firstName, lastName, typeAccount, 0, 0, bonusCounter);
                case AccountType.Platinum:
                    return new PlatinumAccount(number, firstName, lastName, typeAccount, 0, 0, bonusCounter);
                default:
                    throw new InvalidOperationException($"Type account isn't supported");
            }
        }
    }
}