using System;
using BankAccounts.Common.Interfaces.Services;

namespace BankAccounts.BusinessLogic.Services
{
    public class NumberCreatorService : INumberCreatorService
    {
        public int Create(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            return $"{firstName} {lastName}".GetHashCode();
        }
    }
}