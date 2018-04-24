namespace BLL.Interface.Interfaces
{
    /// <summary>
    /// Interface of number creator
    /// </summary>
    public interface INumberCreatorService
    {
        /// <summary>
        /// Create number by owners name
        /// </summary>
        /// <param name="firstName">First name</param>
        /// <param name="lastName">Last name</param>
        /// <returns>Number</returns>
        int Create(string firstName, string lastName);
    }
}