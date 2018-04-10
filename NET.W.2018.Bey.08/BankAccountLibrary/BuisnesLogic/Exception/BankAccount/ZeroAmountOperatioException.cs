namespace BuisnesLogic.Exception.BankAccount
{
    using System;

    /// <summary>
    /// Class provides exception by deposit operation
    /// </summary>
    [Serializable]
    public class ZeroAmountOperatioException : System.Exception
    {
        /// <summary>
        /// Create instance of ZeroAmountOperatioException
        /// </summary>
        public ZeroAmountOperatioException(string id) : base($"Incorrect account operation with account {id}, amount should be more than 0!")
        {            
        }
    }
}