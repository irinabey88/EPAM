namespace NET.W._2018.Bey._08.Models.BankAccount
{
    using System;

    /// <summary>
    /// Provides bank user object
    /// </summary>
    public class BankUser
    {
        /// <summary>
        /// Provides instance of new  user
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        public BankUser(string firstName, string lastName)
        {
            DataValidation(firstName, lastName);

            this.UserId = Guid.NewGuid().ToString();
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// Provides instance of loaded from storage user
        /// </summary>
        /// <param name="userId">User id</param>
        /// <param name="firstName">Firstname</param>
        /// <param name="lastName">Lastname</param>
        public BankUser(string userId, string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                throw new ArgumentNullException(nameof(userId));
            }

            DataValidation(firstName, lastName);

            this.UserId = Guid.NewGuid().ToString();
            this.FirstName = firstName;
            this.LastName = lastName;
        }

        /// <summary>
        /// User id
        /// </summary>
        public string UserId { get; }

        /// <summary>
        /// Firstname
        /// </summary>
        public string FirstName { get; }

        /// <summary>
        /// Lastname
        /// </summary>
        public string LastName { get; }

        public bool Equals(BankUser other)
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

            return this.Equals((BankUser)obj);
        }

        public override int GetHashCode() => base.GetHashCode();

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName}";
        }

        #region Private methods

        private void DataValidation(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }
        }

        private bool CheckEqualityProperty(BankUser user1, BankUser user2)
        {
            if (!user1.UserId.Equals(user2.UserId))
            {
                return false;
            }

            if (!user1.FirstName.Equals(user2.FirstName))
            {
                return false;
            }

            if (!user1.LastName.Equals(user2.LastName))
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}