namespace DataAccess.Exceptions.User
{
    using System;

    /// <summary>
    /// Class provides exception by deleting user
    /// </summary>
    [Serializable]
    public class DeleteUserException : System.Exception
    {
        /// <summary>
        /// Create instance of DeleteUserException
        /// </summary>
        /// <param name="id">User id</param>
        public DeleteUserException(string id) : base($"User with id {id} doesn't exist in the storage")
        {
        }
    }
}