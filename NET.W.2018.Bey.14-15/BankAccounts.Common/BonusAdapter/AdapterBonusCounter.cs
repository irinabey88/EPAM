using System;
using BankAccounts.Common.Interfaces.BonusCounter;

namespace BankAccounts.Common.BonusAdapter
{
    public class AdapterBonusCounter : IBonusCounter
    {
        private readonly Func<decimal, int, int> _calcFunc;

        public AdapterBonusCounter(Func<decimal, int, int> calcFunc)
        {
            this._calcFunc = calcFunc ?? throw new ArgumentNullException(nameof(calcFunc));
        }

        public int CalcBonus(decimal amount, int type)
        {
            return this._calcFunc(amount, type);
        }
    }
}