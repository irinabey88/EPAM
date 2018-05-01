using System.Data.Entity;
using BankAccounts.Common.Models;
using BankAccounts.DataAccess.Configuration;

namespace BankAccounts.DataAccess.Context
{
    public class BankContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BankContext" /> class.
        /// </summary>
        public BankContext() : base()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<BankContext>());
        }

        /// <summary>
        /// Accounts list
        /// </summary>
        public DbSet<BankAccount> Accounts { get; set; }

        /// <summary>
        /// Method configuration tables
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new AccountConfiguration());
        }
    }
}