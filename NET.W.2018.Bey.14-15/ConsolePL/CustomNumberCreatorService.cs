using BankAccounts.Common.Interfaces.Services;

namespace ConsolePL
{
    public class CustomNumberCreatorService : INumberCreatorService
    {
        public int Create(string firstName, string lastName)
        {
            return $"{firstName} {lastName}".GetHashCode();
        }
    }
}