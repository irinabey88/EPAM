using BLL.Interface.Enumes;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Provides a base bank account
    /// </summary>
    public sealed class BaseAccount : Account
    {
        private readonly uint _rate = 5;

        /// <summary>
        /// Provides instance <see cref="BaseAccount"/>
        /// </summary>
        /// <param name="lastName">User Last Name</param>
        /// <param name="typeAccount">Type account</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>
        /// <param name="firstName">User first Name</param>
        public BaseAccount(string firstName, string lastName, AccountType typeAccount, decimal amount, int bonus) : base(firstName, lastName, typeAccount, amount, bonus)
        {
        }

        public override uint Rate => this._rate;
    }
}