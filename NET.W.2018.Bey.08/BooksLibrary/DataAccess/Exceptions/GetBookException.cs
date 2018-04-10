namespace DataAccess.Exception
{
    using System;

    /// <summary>
    /// Class provides exception by getting book 
    /// </summary>
    [Serializable]
    public class GetBookException : Exception
    {
        /// <summary>
        /// Create instance of GetBookException
        /// </summary>
        /// <param name="idBook">Book id</param>
        public GetBookException(string idBook) : base($"Book with ISBN {idBook} doesn't exist")
        {            
        }
    }
}