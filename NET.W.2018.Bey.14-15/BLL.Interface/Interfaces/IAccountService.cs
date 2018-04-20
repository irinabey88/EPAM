using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using BLL.Interface.Entities;
using BLL.Interface.Enumes;

namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Describes bank account service logic
    /// </summary>
    public interface IAccountService<out TModel> where TModel : Account
    {
        /// <summary>
        /// Create bank account
        /// </summary>
        /// <param name="firstName">User first name</param>
        /// <param name="lastName">User last name</param>
        /// <param name="typeAccount">Account type</param>
        /// <returns><value>Account if it is created</value>
        /// <value>null - otherwise</value></returns>
        TModel CreateAccount(string firstName, string lastName, AccountType typeAccount);

        /// <summary>
        /// Close account
        /// </summary>
        /// <param name="accountId">Account number</param>
        /// <returns><value>Account if it is closed</value>
        /// <value>null - otherwise</value></returns>
        TModel CloseAccount(int accountId);

        /// <summary>
        /// Gets bank account
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <returns><value>Account if it is existed</value>
        /// <value>null - otherwise</value></returns>
        TModel GetAccount(int accountId);

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
        TModel WithdrawMoney(int accountId, decimal amount);

        /// <summary>
        /// Deposits money to account
        /// </summary>
        /// <param name="accountId">Account id</param>
        /// <param name="amount">Deposit amount</param>
        /// <returns>Account</returns>
        TModel DepositMoney(int accountId, decimal amount);     
    }
}