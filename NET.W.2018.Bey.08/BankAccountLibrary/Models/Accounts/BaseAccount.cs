namespace Models.Accounts
{
    using Base;
    using Enum;

    /// <summary>
    /// Provides a base bank account
    /// </summary>
    public sealed class BaseAccount : BankAccount
    {
        private readonly uint _rate = 5;

        /// <summary>
        /// Provides new instance of bank account
        /// </summary>
        /// <param name="bankUser">Account owner</param>
        public BaseAccount(BankUser bankUser) : base(bankUser)
        {
            this.TypeAccount = BankAccountType.Base;
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
        public BaseAccount(BankUser bankUser, string accountId, BankAccountType typeAccount, uint amount, uint bonus, bool isClosed) : base(bankUser, accountId, typeAccount, amount, bonus, isClosed)
        {
        }

        public override uint Rate => this._rate;
    }
}