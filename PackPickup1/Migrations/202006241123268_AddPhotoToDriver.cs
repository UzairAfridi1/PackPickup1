namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddPhotoToDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "PhotoId", c => c.Int(nullable: false));
            CreateIndex("dbo.Drivers", "PhotoId");
            AddForeignKey("dbo.Drivers", "PhotoId", "dbo.Photos", "PhotoId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Drivers", "PhotoId", "dbo.Photos");
            DropIndex("dbo.Drivers", new[] { "PhotoId" });
            DropColumn("dbo.Drivers", "PhotoId");
        }
    }
}
