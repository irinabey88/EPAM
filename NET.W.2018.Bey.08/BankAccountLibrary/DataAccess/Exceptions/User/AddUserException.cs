namespace DataAccess.Exceptions.User
{
    using System;

    /// <summary>
    /// Class provides exception by adding user
    /// </summary>
    [Serializable]
    public class AddUserException : System.Exception
    {
        /// <summary>
        /// Create instance of AddUserException
        /// </summary>
        /// <param name="id">User id</param>
        public AddUserException(string id) : base($"User with id {id} already exists")
        {            
        }
    }
}