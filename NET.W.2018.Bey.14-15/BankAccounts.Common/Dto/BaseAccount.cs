using BankAccounts.Common.Enumes;
using BankAccounts.Common.Interfaces.BonusCounter;

namespace BankAccounts.Common.Dto
{
    /// <summary>
    /// Provides a base bank account
    /// </summary>
    public sealed class BaseAccount : Account
    {
        /// <summary>
        /// Provides instance <see cref="BaseAccount"/>
        /// </summary>
        /// <param name="lastName">User Last Name</param>
        /// <param name="typeAccount">Type account</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>
        /// <param name="number"></param>
        /// <param name="firstName">User first Name</param>
        /// <param name="bonusCounter"></param>
        public BaseAccount(int number, string firstName, string lastName, AccountType typeAccount, decimal amount, int bonus, IBonusCounter bonusCounter) : base(number, firstName, lastName, typeAccount, amount, bonus, bonusCounter)
        {
        }
    }
}