using System;
using DAL.Interface.DTO;
using DAL.Interface.Interfaces;

namespace DAL.Interface.EventArg
{
    public class AmountChangedEventArgs<T> : EventArgs where T : BankAccount
    {
        private readonly Func<decimal, int, int> _calcBonus;

        public AmountChangedEventArgs(BankAccount account, IBonusCounter bonusCounter)
        {
            if (account == null)
            {
                throw new ArgumentNullException(nameof(account));
            }

            if (bonusCounter == null)
            {
                throw new ArgumentNullException(nameof(bonusCounter));
            }


            this._calcBonus = bonusCounter.CalcBonus;
        }

        public Func<decimal, int, int> CalcBonus => this._calcBonus;
    }
}