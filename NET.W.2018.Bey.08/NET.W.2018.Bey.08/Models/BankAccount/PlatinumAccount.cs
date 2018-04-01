namespace NET.W._2018.Bey._08.Models.BankAccount
{
    using Enum;

    /// <summary>
    /// Provides a platinum bank account
    /// </summary>
    public class PlatinumAccount : BankAccount
    {
        /// <summary>
        /// Provides new instance of bank account
        /// </summary>
        /// <param name="bankUser">Account owner</param>
        public PlatinumAccount(BankUser bankUser) : base(bankUser)
        {
            this.TypeAccount = BankAccountType.Platinum;
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
        public PlatinumAccount(BankUser bankUser, string accountId, BankAccountType typeAccount, uint amount, uint bonus, bool isClosed) : base(bankUser, accountId, typeAccount, amount, bonus, isClosed)
        {
        }

        public override uint Rate { get; } = 15;
    }
}