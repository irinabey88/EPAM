namespace NET.W._2018.Bey._08.Models.Book
{
    /// <summary>
    /// Provides object fiction book
    /// </summary>
    public sealed class ScientificBook : Book
    {
        /// <summary>
        /// Provides instance of fiction book
        /// </summary>
        /// <param name="isbn">Book id</param>
        /// <param name="author">Author</param>
        /// <param name="name">Book name</param>
        /// <param name="publishing">Publishing</param>
        /// <param name="year">Year of publishing</param>
        /// <param name="pageCount">Page count</param>
        /// <param name="price">Price</param>
        public ScientificBook(string isbn, string author, string name, string publishing, uint year, uint pageCount, decimal price) : base(isbn, author, name, publishing, year, pageCount, price)
        {
        }
    }
}