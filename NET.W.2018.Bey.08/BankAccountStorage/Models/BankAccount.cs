namespace NET.W._2018.Bey._08.Models.BankAccount
{
    using System;
    using Enum;

    /// <summary>
    /// Provides bank account object
    /// </summary>
    public abstract class BankAccount
    {
        /// <summary>
        /// Provides new instance of bank account
        /// </summary>
        /// <param name="bankUser">Account owner</param>
        public BankAccount(BankUser bankUser)
        {
            this.User = bankUser ?? throw new ArgumentNullException(nameof(bankUser));
            this.AccountId = Guid.NewGuid().ToString();
        }

        /// <summary>
        /// Provides loaded from storage instance of bank account
        /// </summary>
        /// <param name="bankUser">Account owner</param>
        /// <param name="accountId">Account id</param>
        /// <param name="typeAccount">Type account</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>
        /// <param name="isClosed">Is account closed</param>
        public BankAccount(BankUser bankUser, string accountId, BankAccountType typeAccount, uint amount, uint bonus, bool isClosed)
        {
            this.User = bankUser ?? throw new ArgumentNullException(nameof(bankUser));
            this.AccountId = accountId;
            this.TypeAccount = typeAccount;
            this.Amount = amount;
            this.Bonus = bonus;
            this.IsClosed = isClosed;
        }

        /// <summary>
        /// Account id
        /// </summary>
        public string AccountId { get; }

        /// <summary>
        /// Account type
        /// </summary>
        public BankAccountType TypeAccount { get; protected set; }

        /// <summary>
        /// Account owner
        /// </summary>
        public BankUser User { get; }

        /// <summary>
        /// Amount
        /// </summary>
        public uint Amount { get; }

        /// <summary>
        /// Bonus
        /// </summary>
        public virtual uint Bonus { get; }

        /// <summary>
        /// Is account closed
        /// </summary>
        public bool IsClosed { get; }

        /// <summary>
        /// Rate for calculating bonuses
        /// </summary>
        public virtual uint Rate { get; }

        public bool Equals(BankAccount other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return CheckEqualityProperty(this, other);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
            {
                return false;
            }

            if (ReferenceEquals(this, obj))
            {
                return true;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }

            return this.Equals((BankAccount)obj);
        }

        public override int GetHashCode() => this.AccountId.GetHashCode();

        public override string ToString()
        {
            return $"{this.User} {this.Amount} {this.Bonus}";
        }

        #region Private methods

        private bool CheckEqualityProperty(BankAccount bankAccount1, BankAccount bankAccount2)
        {
            if (!bankAccount1.User.Equals(bankAccount2.User))
            {
                return false;
            }

            if (bankAccount1.Amount != bankAccount2.Amount)
            {
                return false;
            }

            if (bankAccount1.Bonus != bankAccount2.Bonus)
            {
                return false;
            }

            if (bankAccount1.IsClosed != bankAccount2.IsClosed)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}