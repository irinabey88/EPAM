using System;

namespace NET.W._2018.Bey._08.Exception
{
    using System;

    /// <summary>
    /// Class provides exception for operation with closed bank account
    /// </summary>
    [Serializable]
    public class ClosedAccountException : Exception
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