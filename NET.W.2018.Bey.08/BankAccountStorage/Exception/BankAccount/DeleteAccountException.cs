namespace NET.W._2018.Bey._08.Exception
{
    using System;

    /// <summary>
    /// Class provides exception by deleting bank account
    /// </summary>
    [Serializable]
    public class DeleteAccountException : Exception
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