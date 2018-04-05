namespace NET.W._2018.Bey._08.Exception
{
    using System;

    /// <summary>
    /// Class provides exception by loading bank account
    /// </summary>
    [Serializable]
    public class IncorrectBankAccountTypeException : Exception
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