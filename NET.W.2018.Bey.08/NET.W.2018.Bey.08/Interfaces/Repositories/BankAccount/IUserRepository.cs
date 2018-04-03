namespace NET.W._2018.Bey._08.Interfaces
{
    using Models.BankAccount;

    /// <summary>
    /// Describes user repository logic
    /// </summary>
    public interface IUserRepository : IRepository<BankUser>
    {
        /// <summary>
        /// Finds user by name
        /// </summary>
        /// <param name="firstName">Firstname</param>
        /// <param name="lastName">Lastname</param>
        /// <returns><value>Bank user if it exists</value>
        /// <value>Null - otherwise</value></returns>
        BankUser FindUserByName(string firstName, string lastName);
    }
}