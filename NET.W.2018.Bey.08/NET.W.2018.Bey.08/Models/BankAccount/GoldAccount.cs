namespace NET.W._2018.Bey._08.Models.BankAccount
{
    using Enum;

    /// <summary>
    /// Provides a gold bank account
    /// </summary>
    public class GoldAccount : BankAccount
    {
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

        public override uint Rate { get; } = 10;
    }
}