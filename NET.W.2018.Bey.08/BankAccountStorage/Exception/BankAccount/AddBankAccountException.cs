namespace NET.W._2018.Bey._08.Exception
{
    using System;

    /// <summary>
    /// Class provides exception by adding new bank account
    /// </summary>
    public class AddBankAccountException : Exception
    {
        /// <summary>
        /// Create instance of AddBankAccountException
        /// </summary>
        /// <param name="id">id bank account</param>
        public AddBankAccountException(string id) : base($"Bank account with id {id} already exists")
        {            
        }
    }
}