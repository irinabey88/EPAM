namespace BuisnesLogic.Exception.BankAccount
{
    using System;

    /// <summary>
    /// Class provides exception by deposit operation
    /// </summary>
    [Serializable]
    public class WithdrawException : System.Exception
    {
        /// <summary>
        /// Create instance of WithdrawException
        /// </summary>
        public WithdrawException(string id) : base($"You don't have enough money in the account {id}")
        {
        }
    }
}