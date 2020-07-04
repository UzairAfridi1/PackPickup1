namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemovePhotoIdFromDriver : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Drivers", "PhotoId", "dbo.Photos");
            DropIndex("dbo.Drivers", new[] { "PhotoId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Drivers", "PhotoId");
            AddForeignKey("dbo.Drivers", "PhotoId", "dbo.Photos", "PhotoId", cascadeDelete: true);
        }
    }
}
