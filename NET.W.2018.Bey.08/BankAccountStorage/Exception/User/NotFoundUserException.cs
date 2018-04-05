namespace NET.W._2018.Bey._08.Exception.User
{
    using System;

    /// <summary>
    /// Class provides exception if user wasn't found
    /// </summary>
    [Serializable]
    public class NotFoundUserException : Exception
    {
        /// <summary>
        /// Create instance of NotFoundUserException
        /// </summary>
        /// <param name="firstName">Firstname</param>
        /// <param name="lastName">Lastname</param>
        public NotFoundUserException(string firstName, string lastName) : base($"User {firstName} {lastName} wasn't found")
        {            
        }
    }
}