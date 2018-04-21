using System;
using BLL.Interface.Interfaces;

namespace BLL.ServiceImplementation
{
    public class NumberCreatorService : INumberCreatorService
    {
        public int Create(string firstName, string lastName)
        {
            if (string.IsNullOrWhiteSpace(firstName))
            {
                throw new ArgumentNullException(nameof(firstName));
            }

            if (string.IsNullOrWhiteSpace(lastName))
            {
                throw new ArgumentNullException(nameof(lastName));
            }

            return $"{firstName} {lastName}".GetHashCode();
        }
    }
}