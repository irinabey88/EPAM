namespace BuisnesLogic.Exception.BankAccount
{
    using System;

    /// <summary>
    /// Class provides exception for operation with closed bank account
    /// </summary>
    [Serializable]
    public class ClosedAccountException : System.Exception
    {
        /// <summary>
        /// Create instance of ClosedAccountException
        /// </summary>
        /// <param name="id">Account id</param>
        public ClosedAccountException(string id) : base($"Bank account with id {id} is closed")
        {            
        }
    }
}