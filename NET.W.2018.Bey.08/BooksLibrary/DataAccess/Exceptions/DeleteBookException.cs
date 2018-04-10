namespace DataAccess.Exception
{
    using System;

    /// <summary>
    /// Class provides exception by deleting book 
    [Serializable]
    public class DeleteBookException : Exception
    {
        /// <summary>
        /// Create instance of DeleteBookException
        /// </summary>
        /// <param name="bookName">Book name</param>
        /// <param name="isbn">Book id</param>
        public DeleteBookException(string bookName, string isbn) : base($"Book {bookName} with ISBN {isbn} doesn't exist in the storage")
        {
        }
    }
}