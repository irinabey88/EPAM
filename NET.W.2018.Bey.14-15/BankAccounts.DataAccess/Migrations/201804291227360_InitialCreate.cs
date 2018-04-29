namespace BankAccounts.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BankAccounts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        Lastname = c.String(nullable: false),
                        Bonus = c.Int(nullable: false),
                        Type = c.Int(nullable: false),
                        IsClosed = c.Boolean(nullable: false),
                        Amount = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);            
        }
        
        public override void Down()
        {
            this.DropTable("dbo.BankAccounts");
        }
    }
}
