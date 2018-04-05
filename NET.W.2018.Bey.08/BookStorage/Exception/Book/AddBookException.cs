namespace NET.W._2018.Bey._08.Exception
{
    using System;

    /// <summary>
    /// Class provides exception by adding book 
    /// </summary>
    [Serializable]
    public class AddBookException : Exception
    {
        /// <summary>
        /// Create instance of AddBookException
        /// </summary>
        /// <param name="bookName">Book name</param>
        /// <param name="isbn">Book id</param>
        public AddBookException(string bookName, string isbn) : base($"Book {bookName} with ISBN {isbn} already exists in the storage")
        {
        }
    }
}