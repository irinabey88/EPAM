using System;

namespace BLL.Interface.Exception
{
    [Serializable]
    public class NotFoundException : System.Exception
    {
        public NotFoundException(int accountId) : base($"Account with number {accountId} doesn't exist")
        {
        }
    }
}