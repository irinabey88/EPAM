using System;
using BLL.Interface.Enumes;

namespace BLL.Interface.Entities
{
    /// <summary>
    /// Provides bank account object
    /// </summary>
    public abstract class Account : IEquatable<Account>, IComparable, IComparable<Account>
    {
        private int _number;

        /// <summary>
        /// Provides loaded from storage instance of bank account
        /// </summary>
        /// <param name="lastName">User Last Name</param>
        /// <param name="typeAccount">Type account</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>
        /// <param name="firstName">User first Name</param>
        public Account(string firstName, string lastName, AccountType typeAccount, decimal amount, int bonus)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Number = $"{firstName}{lastName}".GetHashCode();
            this.TypeAccount = typeAccount;
            this.Amount = amount;
            this.Bonus = bonus;
        }

        /// <summary>
        /// Account id
        /// </summary>
        public int Number
        {
            get => this._number;

            private set => this._number = value;
        }

        /// <summary>
        /// User First name
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// User Last name
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Account type
        /// </summary>
        public AccountType TypeAccount { get; protected set; }

      
        /// <summary>
        /// Amount
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Bonus
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// Is account closed
        /// </summary>
        public bool IsClosed { get; set; }

        /// <summary>
        /// Rate for calculating bonuses
        /// </summary>
        public virtual uint Rate { get; set; }

        #region Operations

        public static bool operator ==(Account lhs, Account rgs)
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

        public static bool operator !=(Account lhs, Account rhs)
        {
            return !(lhs == rhs);
        }

        #endregion

        #region IEquatable

        public bool Equals(Account other)
        {
            if (ReferenceEquals(null, other))
            {
                return false;
            }

            if (ReferenceEquals(this, other))
            {
                return true;
            }

            return string.Equals(other.Number, this.Number);
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

            return this.Equals((Account)obj);
        }

        public override int GetHashCode() => this.Number.GetHashCode();

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

            return CompareTo(obj as Account);
        }

        public int CompareTo(Account other)
        {
            if (ReferenceEquals(other, null))
            {
                return 1;
            }

            if (ReferenceEquals(this, other))
            {
                return 0;
            }

            return this.Number.CompareTo(other.Number);
        }

        #endregion

        public override string ToString()
        {
            return $"{this.Number} {this.FirstName} {this.LastName} {this.Amount} {this.Bonus}";
        }
    }
}