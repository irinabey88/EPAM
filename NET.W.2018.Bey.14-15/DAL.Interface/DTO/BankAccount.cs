namespace DAL.Interface.DTO
{
    public class BankAccount
    {
        public int Number { get; set; }

        public string FirstName { get; set; }

        public string Lastname { get; set; }

        public decimal Amount { get; set; }

        public int Bonus { get; set; }

        public int Type { get; set; }

        public bool IsClosed { get; set; }

    }
}