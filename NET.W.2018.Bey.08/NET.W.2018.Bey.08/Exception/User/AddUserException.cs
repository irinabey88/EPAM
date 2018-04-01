namespace NET.W._2018.Bey._08.Exception.User
{
    using System;

    /// <summary>
    /// Class provides exception by adding user
    /// </summary>
    [Serializable]
    public class AddUserException : Exception
    {
        /// <summary>
        /// Create instance of AddUserException
        /// </summary>
        /// <param name="id">User id</param>
        public AddUserException(string id) : base($"BankUser with id {id} already exists")
        {            
        }
    }
}