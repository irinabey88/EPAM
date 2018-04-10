namespace DataAccess.Exceptions.BankAccount
{
    using System;

    /// <summary>
    /// Class provides exception by loading bank account
    /// </summary>
    [Serializable]
    public class IncorrectBankAccountTypeException : System.Exception
    {
        /// <summary>
        /// Create instance of IncorrectBankAccountTypeException
        /// </summary>
        /// <param name="type">type of bank account</param>
        public IncorrectBankAccountTypeException(int type) : base($"Incorect type of bank account: {type}")
        {            
        }
    }
}