namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AllowNullPhotoId : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Drivers", "PhotoId", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Drivers", "PhotoId", c => c.Int(nullable: false));
        }
    }
}
