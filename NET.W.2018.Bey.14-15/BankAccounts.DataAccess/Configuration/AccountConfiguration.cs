using System.Data.Entity.ModelConfiguration;
using BankAccounts.Common.Models;

namespace BankAccounts.DataAccess.Configuration
{
    public class AccountConfiguration : EntityTypeConfiguration<BankAccount>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountConfiguration" /> class.
        /// </summary>
        public AccountConfiguration()
        {
            this.HasKey(p => p.Id);

            this.Property(p => p.FirstName).IsRequired().HasMaxLength(30);
            this.Property(p => p.Lastname).IsRequired();
            this.Property(p => p.Type).IsRequired();
            this.Property(p => p.Amount).IsRequired();
            this.Property(p => p.Bonus).IsRequired();
            this.Property(p => p.IsClosed).IsRequired();
        }
    }
}