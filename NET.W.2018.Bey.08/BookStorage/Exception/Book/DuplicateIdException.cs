namespace NET.W._2018.Bey._08.Exception
{
    using System;

    /// <summary>
    /// Class provides exception by finding duplicate book value
    /// </summary>
    [Serializable]
    public class DuplicateIdException : Exception
    {
        /// <summary>
        ///  Create instance of DuplicateIdException
        /// </summary>
        /// <param name="id">Book id</param>
        public DuplicateIdException(string id) : base($"Duplicate id {id}")
        {            
        }
    }
}