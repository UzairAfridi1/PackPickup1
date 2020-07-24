namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTblReviewtoDb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Reviews",
                c => new
                    {
                        ReviewId = c.Int(nullable: false, identity: true),
                        Comment = c.String(),
                        Stars = c.String(),
                        CommentType = c.String(),
                        CustomerId = c.Int(nullable: false),
                        DriverId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewId)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: false)
                .ForeignKey("dbo.Drivers", t => t.DriverId, cascadeDelete: true)
                .Index(t => t.CustomerId)
                .Index(t => t.DriverId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Reviews", "DriverId", "dbo.Drivers");
            DropForeignKey("dbo.Reviews", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Reviews", new[] { "DriverId" });
            DropIndex("dbo.Reviews", new[] { "CustomerId" });
            DropTable("dbo.Reviews");
        }
    }
}
