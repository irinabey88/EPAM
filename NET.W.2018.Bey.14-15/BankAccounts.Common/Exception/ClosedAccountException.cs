using System;

namespace BankAccounts.Common.Exception
{
    [Serializable]
    public class ClosedAccountException : System.Exception
    {
        public ClosedAccountException(int accountId) : base($"Account {accountId} is closed")
        {
        }
    }
}