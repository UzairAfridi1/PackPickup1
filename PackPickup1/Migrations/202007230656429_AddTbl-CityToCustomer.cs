namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblCityToCustomer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "CityId", c => c.Int(nullable: false));
            CreateIndex("dbo.Customers", "CityId");
            AddForeignKey("dbo.Customers", "CityId", "dbo.Cities", "CityId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Customers", "CityId", "dbo.Cities");
            DropIndex("dbo.Customers", new[] { "CityId" });
            DropColumn("dbo.Customers", "CityId");
        }
    }
}
