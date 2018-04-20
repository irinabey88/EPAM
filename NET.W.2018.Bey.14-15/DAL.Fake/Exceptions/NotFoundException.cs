using System;

namespace DAL.Fake.Exceptions
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException(int accountId) : base($"Account with number {accountId} doesn't exist")
        {
        }
    }
}