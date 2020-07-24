namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblStateToDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "StateId", c => c.Int(nullable: false));
            CreateIndex("dbo.Drivers", "StateId");
            AddForeignKey("dbo.Drivers", "StateId", "dbo.States", "StateId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "StateId", "dbo.States");
            DropIndex("dbo.Drivers", new[] { "StateId" });
            DropColumn("dbo.Drivers", "StateId");
        }
    }
}
