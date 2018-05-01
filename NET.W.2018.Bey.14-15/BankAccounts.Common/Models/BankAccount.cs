using System;
using BankAccounts.Common.BonusAdapter;
using BankAccounts.Common.Interfaces.BonusCounter;
using BankAccounts.Common.Models.EventArg;

namespace BankAccounts.Common.Models
{
    /// <summary>
    /// Describes account on data access layer
    /// </summary>
    public class BankAccount
    {
        private decimal _amount;
        private IBonusCounter _bonusCounter;

        public BankAccount()
        {            
        }

        public BankAccount(IBonusCounter bonusCounter)
        {
            _bonusCounter = bonusCounter ?? throw new ArgumentNullException(nameof(bonusCounter));
            this.AmountChanged += this.BonusChanged;
        }

        public event EventHandler<AmountChangedEventArgs<BankAccount>> AmountChanged;

        public int Id { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public int Bonus { get; set; }

        public int Type { get; set; }

        public bool IsClosed { get; set; }

        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount
        {
            get => this._amount;
            set
            {
                this._amount = value;
                OnAmountChanged(new AmountChangedEventArgs<BankAccount>(this, this._bonusCounter));
            }
        }   

        /// <summary>
        /// Executes when event  <see cref="AmountChanged"/> arises
        /// </summary>
        /// <param name="chanedEventArgs">Object EventArgs for event <see cref="AmountChanged"/></param>
        protected void OnAmountChanged(AmountChangedEventArgs<BankAccount> chanedEventArgs)
        {
            if (chanedEventArgs == null)
            {
                throw new ArgumentNullException(nameof(chanedEventArgs));
            }

            AmountChanged?.Invoke(this, chanedEventArgs);
        }

        protected void BonusChanged(object sender, AmountChangedEventArgs<BankAccount> eventArgs)
        {
            this.Bonus += eventArgs.CalcBonus(this.Amount, this.Type);
        }
    }
}