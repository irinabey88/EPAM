using BLL.Interface.Enumes;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Provides a gold bank account
    /// </summary>
    public sealed class GoldAccount : Account
    {
        private readonly uint _rate = 10;

        /// <summary>
        /// Provides instance <see cref="GoldAccount"/>
        /// </summary>
        /// <param name="lastName">User Last Name</param>
        /// <param name="typeAccount">Type account</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>
        /// <param name="number">Account number</param>
        /// <param name="firstName">User first Name</param>
        public GoldAccount(int number, string firstName, string lastName, AccountType typeAccount, decimal amount, int bonus) : base(number, firstName, lastName, typeAccount, amount, bonus)
        {
        }

        public override uint Rate => this._rate;
    }
}