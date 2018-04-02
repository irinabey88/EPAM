namespace NET.W._2018.Bey._08.Exception
{
    using System;

    /// <summary>
    /// Class provides exception by deposit operation
    /// </summary>
    [Serializable]
    public class ZeroAmountOperatioException : Exception
    {
        /// <summary>
        /// Create instance of ZeroAmountOperatioException
        /// </summary>
        public ZeroAmountOperatioException(string id) : base($"Incorrect account operation with account {id}, amount should be more than 0!")
        {            
        }
    }
}