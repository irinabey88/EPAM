using BankAccounts.Common.Enumes;
using BankAccounts.Common.Interfaces.BonusCounter;

namespace BankAccounts.Common.Dto
{
    /// <summary>
    /// Provides a platinum bank account
    /// </summary>
    public sealed class PlatinumAccount : Account
    {
        /// <summary>
        /// Provides instance <see cref="PlatinumAccount"/>
        /// </summary>
        /// <param name="lastName">User Last Name</param>
        /// <param name="typeAccount">Type account</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>
        /// <param name="id">Account id</param>
        /// <param name="firstName">User first Name</param>
        public PlatinumAccount(int id, string firstName, string lastName, AccountType typeAccount, decimal amount, int bonus, IBonusCounter bonusCounter) : base(id, firstName, lastName, typeAccount, amount, bonus, bonusCounter)
        {
        }
    }
}