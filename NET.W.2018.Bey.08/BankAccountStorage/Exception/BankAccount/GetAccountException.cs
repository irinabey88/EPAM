namespace NET.W._2018.Bey._08.Exception
{
    using System;

    /// <summary>
    /// Class provides exception by getting bank account
    /// </summary>
    [Serializable]
    public class GetAccountException : Exception
    {
        /// <summary>
        /// Create instance of GetAccountException
        /// </summary>
        /// <param name="id">id account</param>
        public GetAccountException(string id) : base($"Account with id {id} doesn't exists")
        {            
        }
    }
}