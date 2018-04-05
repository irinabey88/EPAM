namespace NET.W._2018.Bey._08.Exception
{
    using System;

    /// <summary>
    /// Class provides exception by deposit operation
    /// </summary>
    [Serializable]
    public class WithdrawException : Exception
    {
        /// <summary>
        /// Create instance of WithdrawException
        /// </summary>
        public WithdrawException(string id) : base($"You don't have enough money in the account {id}")
        {
        }
    }
}