namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblStateToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "StateId");
            AddForeignKey("dbo.Customers", "StateId", "dbo.States", "StateId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "StateId", "dbo.States");
            DropIndex("dbo.Customers", new[] { "StateId" });
            DropColumn("dbo.Customers", "StateId");
        }
    }
}
