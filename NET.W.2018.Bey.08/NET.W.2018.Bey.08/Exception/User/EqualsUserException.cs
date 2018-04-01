﻿namespace NET.W._2018.Bey._08.Exception.User
{
    using System;

    /// <summary>
    /// Class provides exception creating user
    /// </summary>
    [Serializable]
    public class EqualsUserException : Exception
    {
        /// <summary>
        ///  Create instance of EqualsUserException
        /// </summary>
        /// <param name="firstName">User firstname</param>
        /// <param name="lastName">User lastname</param>
        public EqualsUserException(string firstName, string lastName) : base($"User with name {firstName} {lastName} already exists")
        {            
        }
    }
}