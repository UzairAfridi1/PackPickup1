namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDriverToDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Drivers",
                c => new
                    {
                        DriverId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        Country = c.String(),
                        City = c.String(),
                        Area = c.String(),
                        Nationality = c.String(),
                        Language = c.String(),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DriverId)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "UserId", "dbo.Users");
            DropIndex("dbo.Drivers", new[] { "UserId" });
            DropTable("dbo.Drivers");
        }
    }
}
