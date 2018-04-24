using BLL.Interface.Interfaces;

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