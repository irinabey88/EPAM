using BankAccounts.Common.Models;

namespace BankAccounts.Common.Interfaces.Repositories
{
    /// <summary>
    /// Describes bank account repository logic
    /// </summary>
    public interface IAccountRepository : IRepository<BankAccount>
    {       
    }
}