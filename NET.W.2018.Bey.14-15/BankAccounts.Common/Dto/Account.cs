using System;
using BankAccounts.Common.Enumes;
using BankAccounts.Common.Interfaces.BonusCounter;

namespace BankAccounts.Common.Dto
{
    /// <summary>
    /// Provides bank account object
    /// </summary>
    public abstract class Account : IEquatable<Account>, IComparable, IComparable<Account>
    {
        private IBonusCounter _bonusCounter;

        /// <summary>
        /// Provides loaded from storage instance of bank account
        /// </summary>
        /// <param name="lastName">User Last Name</param>
        /// <param name="typeAccount">Type account</param>
        /// <param name="amount">Amount</param>
        /// <param name="bonus">Bonus</param>
        /// <param name="id">Account id</param>
        /// <param name="firstName">User first Name</param>
        /// <param name="bonusCounter">Bonus counter</param>
        public Account(int id, string firstName, string lastName, AccountType typeAccount, decimal amount, int bonus, IBonusCounter bonusCounter)
        {
            this._bonusCounter = bonusCounter ?? throw new ArgumentNullException(nameof(bonusCounter));
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Id = id;
            this.TypeAccount = typeAccount;
            this.Amount = amount;
            this.Bonus = bonus;            
        }

        /// <summary>
        /// Account id
        /// </summary>
        public int Id { get; set; }

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

        public decimal Amount { get; set; }

        /// <summary>
        /// Bonus
        /// </summary>
        public int Bonus { get; set; }

        /// <summary>
        /// Is account closed
        /// </summary>
        public bool IsClosed { get; set; }        

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

            return string.Equals(other.Id, this.Id);
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

        public override int GetHashCode() => this.Id.GetHashCode();

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

            return this.Id.CompareTo(other.Id);
        }

        #endregion

        public override string ToString()
        {
            return $"{this.Id} {this.FirstName} {this.LastName} {this.Amount} {this.Bonus}";
        }      
    }
}