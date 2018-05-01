using System;
using BankAccounts.Common.Interfaces.BonusCounter;

namespace BankAccounts.Common.Models.EventArg
{
    public class AmountChangedEventArgs<T> : EventArgs where T : BankAccount
    {
        private readonly Func<decimal, int, int> _calcBonus;

        /// <summary>
        /// Initializes a new instance of the <see cref="AmountChangedEventArgs{T}" /> class.
        /// </summary>
        /// <param name="account">The account</param>
        /// <param name="bonusCounter">The bonuscounter</param>
        public AmountChangedEventArgs(BankAccount account, IBonusCounter bonusCounter)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (bonusCounter != null)
            {
                this._calcBonus = bonusCounter.CalcBonus;
            }            
        }

        public Func<decimal, int, int> CalcBonus => this._calcBonus;
    }
}