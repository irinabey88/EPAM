using System;

namespace BankAccounts.Common.Exception
{
    [Serializable]
    public class WithdrawException : System.Exception
    {
        public WithdrawException(int accountId) : base($"Not enough money on your account {accountId}")
        {
        }
    }
}