namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleNameTotblVehicle : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicles", "VehicleName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicles", "VehicleName");
        }
    }
}
