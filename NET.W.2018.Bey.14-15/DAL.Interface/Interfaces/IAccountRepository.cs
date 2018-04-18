using DAL.Interface.DTO;

namespace DAL.Interface.Interfaces
{
    /// <summary>
    /// Describes bank account repository logic
    /// </summary>
    public interface IAccountRepository : IRepository<BankAccount>
    {       
    }
}