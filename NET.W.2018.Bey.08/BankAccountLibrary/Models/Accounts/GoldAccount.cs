namespace Models.Accounts.Base
{
    using Enum;

    /// <summary>
    /// Provides a gold bank account
    /// </summary>
    public sealed class GoldAccount : BankAccount
    {
        private readonly uint _rate = 10;

        /// <summary>
        /// Provides new instance of bank account
        /// </summary>
        /// <param name="bankUser">Account owner</param>
        public GoldAccount(BankUser bankUser) : base(bankUser)
        {
            this.TypeAccount = BankAccountType.Gold;
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
        public GoldAccount(BankUser bankUser, string accountId, BankAccountType typeAccount, uint amount, uint bonus, bool isClosed) : base(bankUser, accountId, typeAccount, amount, bonus, isClosed)
        {
        }

        public override uint Rate => this._rate;
    }
}