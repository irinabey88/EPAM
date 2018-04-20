using System;

namespace DAL.Fake.Exceptions
{
    [Serializable]
    public class AddException : Exception
    {
        public AddException(int accountId) : base($"Account with number {accountId} already exists")
        {
        }
    }
}