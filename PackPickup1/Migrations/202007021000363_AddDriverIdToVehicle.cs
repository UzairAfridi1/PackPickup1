namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDriverIdToVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "DriverId", c => c.Int(nullable: false));
            CreateIndex("dbo.Vehicles", "DriverId");
            AddForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers", "DriverId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "DriverId", "dbo.Drivers");
            DropIndex("dbo.Vehicles", new[] { "DriverId" });
            DropColumn("dbo.Vehicles", "DriverId");
        }
    }
}
