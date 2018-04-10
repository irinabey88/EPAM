namespace DataAccess.Exceptions.BankAccount
{
    /// <summary>
    /// Class provides exception by adding new bank account
    /// </summary>
    public class AddBankAccountException : System.Exception
    {
        /// <summary>
        /// Create instance of AddBankAccountException
        /// </summary>
        /// <param name="id">id bank account</param>
        public AddBankAccountException(string id) : base($"Bank account with id {id} already exists")
        {            
        }
    }
}