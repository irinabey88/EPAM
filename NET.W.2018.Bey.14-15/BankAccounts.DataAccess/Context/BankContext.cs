using System.Data.Entity;
using BankAccounts.Common.Models;
using BankAccounts.DataAccess.Configuration;

namespace BankAccounts.DataAccess.Context
{
    public class BankContext : DbContext
    {
        public BankContext() : base()
        {
            Database.SetInitializer<BankContext>(new DropCreateDatabaseAlways<BankContext>());
        }

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