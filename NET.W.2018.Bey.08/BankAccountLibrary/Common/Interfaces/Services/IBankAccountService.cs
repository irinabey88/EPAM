namespace Common.Interfaces.Services
{
    using System.Collections.Generic;
    using Models;
    using Models.Accounts.Base;
    using Models.Enum;

    /// <summary>
    /// Describes bank account service logic
    /// </summary>
    public interface IBankAccountService<TModel> where TModel : BankAccount
    {
        /// <summary>
        /// Closes bank account
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <returns><value>Account if it is closed</value>
        /// <value>null - otherwise</value></returns>
        TModel CloseAccount(string accountId);

        /// <summary>
        /// Create bank account
        /// </summary>
        /// <param name="bankUser">Owner bank account</param>
        /// <param name="typeAccount">Account type</param>
        /// <returns><value>Account if it is created</value>
        /// <value>null - otherwise</value></returns>
        TModel CreateAccount(BankUser bankUser, BankAccountType typeAccount);

        /// <summary>
        /// Gets bank account
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <returns><value>Account if it is existed</value>
        /// <value>null - otherwise</value></returns>
        TModel GetAccount(string accountId);

        /// <summary>
        /// Gets all banks accaunt
        /// </summary>
        /// <returns>Enumeration of account</returns>
        IEnumerable<TModel> GetAllAccounts();

        /// <summary>
        /// Withdraw money from account
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <param name="amount">Withdrawal amount</param>
        /// <returns>Account</returns>
        TModel WithdrawMoney(string accountId, uint amount);

        /// <summary>
        /// Deposits money to account
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <param name="amount">Deposit amount</param>
        /// <returns>Account</returns>
        TModel DepositMoney(string accountId, uint amount);

        /// <summary>
        /// Finds all accounst of user
        /// </summary>
        /// <param name="firstName">Firstname</param>
        /// <param name="lastName">Lastname</param>
        /// <returns>Enumeration of users account</returns>
        IEnumerable<BankAccount> FindUserAccounts(string firstName, string lastName);
    }
}