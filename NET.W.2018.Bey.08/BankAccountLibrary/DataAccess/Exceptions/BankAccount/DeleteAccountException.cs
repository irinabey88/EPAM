namespace DataAccess.Exceptions.BankAccount
{
    using System;

    /// <summary>
    /// Class provides exception by deleting bank account
    /// </summary>
    [Serializable]
    public class DeleteAccountException : System.Exception
    {
        /// <summary>
        /// Create instance of DeleteAccountException
        /// </summary>
        /// <param name="id">id bank account</param>
        public DeleteAccountException(string id) : base($"Account with id {id} doesn't exist in the storage")
        {            
        }
    }
}