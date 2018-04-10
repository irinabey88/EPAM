namespace Models.Accounts.Base
{
    using System;
    using Enum;

    /// <summary>
    /// Provides bank account object
    /// </summary>
    public abstract class BankAccount : IEquatable<BankAccount>, IComparable, IComparable<BankAccount>
    {
        private BankUser _user;
        private string _id;

        /// <summary>
        /// Provides new instance of bank account
        /// </summary>
        /// <param name="bankUser">Account owner</param>
        public BankAccount(BankUser bankUser)
        {
            this.User = bankUser;
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
            this.User = bankUser;
            this.AccountId = accountId;
            this.TypeAccount = typeAccount;
            this.Amount = amount;
            this.Bonus = bonus;
            this.IsClosed = isClosed;
        }

        /// <summary>
        /// Account id
        /// </summary>
        public string AccountId
        {
            get
            {
                return this._id;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(nameof(this._id));
                }

                this._id = value;
            }
        }

        /// <summary>
        /// Account type
        /// </summary>
        public BankAccountType TypeAccount { get; protected set; }

        /// <summary>
        /// Account owner
        /// </summary>
        public BankUser User
        {
            get
            {
                return this._user;
            }

            set
            {
                this._user = value ?? throw new ArgumentNullException(nameof(value));
            }
        }

        /// <summary>
        /// Amount
        /// </summary>
        public uint Amount { get; set; }

        /// <summary>
        /// Bonus
        /// </summary>
        public uint Bonus { get; set; }

        /// <summary>
        /// Is account closed
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Rate for calculating bonuses
        /// </summary>
        public virtual uint Rate { get; set; }

        #region Operations

        public static bool operator ==(BankAccount lhs, BankAccount rgs)
        {
            if (ReferenceEquals(lhs, rgs))
            {
                return true;
            }

            if (ReferenceEquals(null, lhs))
            {
                return false;
            }

            return lhs.Equals(rgs);
        }

        public static bool operator !=(BankAccount lhs, BankAccount rhs)
        {
            return !(lhs == rhs);
        }

        #endregion

        #region IEquatable

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

            return string.Equals(other.AccountId, this.AccountId);
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

        #endregion

        #region IComparable

        public int CompareTo(object obj)
        {
            if (ReferenceEquals(obj, null))
            {
                return 1;
            }

            if (ReferenceEquals(this, obj))
            {
                return 0;
            }

            return CompareTo(obj as BankAccount);
        }

        public int CompareTo(BankAccount other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            return string.Compare(AccountId, other.AccountId, StringComparison.Ordinal);
        }

        #endregion

        public override string ToString()
        {
            return $"{this.User} {this.Amount} {this.Bonus}";
        }
    }
}