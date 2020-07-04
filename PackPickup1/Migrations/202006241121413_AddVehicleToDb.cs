namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddVehicleToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Vehicles",
                c => new
                    {
                        VehicleId = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                        Capacity = c.String(),
                        Size = c.String(),
                        Weight = c.String(),
                        PhotoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.VehicleId)
                .ForeignKey("dbo.Photos", t => t.PhotoId, cascadeDelete: true)
                .Index(t => t.PhotoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Vehicles", "PhotoId", "dbo.Photos");
            DropIndex("dbo.Vehicles", new[] { "PhotoId" });
            DropTable("dbo.Vehicles");
        }
    }
}
