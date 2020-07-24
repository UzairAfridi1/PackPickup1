namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblCountryToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "Id");
            AddForeignKey("dbo.Customers", "Id", "dbo.Countries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "Id", "dbo.Countries");
            DropIndex("dbo.Customers", new[] { "Id" });
            DropColumn("dbo.Customers", "Id");
        }
    }
}
