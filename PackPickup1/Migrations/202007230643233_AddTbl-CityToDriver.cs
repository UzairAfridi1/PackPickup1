namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblCityToDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Drivers", "CityId");
            AddForeignKey("dbo.Drivers", "CityId", "dbo.Cities", "CityId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "CityId", "dbo.Cities");
            DropIndex("dbo.Drivers", new[] { "CityId" });
            DropColumn("dbo.Drivers", "CityId");
        }
    }
}
