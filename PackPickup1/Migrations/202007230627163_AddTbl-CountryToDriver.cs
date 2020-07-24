namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblCountryToDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Id", c => c.Int(nullable: false));
            CreateIndex("dbo.Drivers", "Id");
            AddForeignKey("dbo.Drivers", "Id", "dbo.Countries", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "Id", "dbo.Countries");
            DropIndex("dbo.Drivers", new[] { "Id" });
            DropColumn("dbo.Drivers", "Id");
        }
    }
}
