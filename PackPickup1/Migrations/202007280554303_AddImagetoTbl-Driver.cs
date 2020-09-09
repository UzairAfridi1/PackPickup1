namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddImagetoTblDriver : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Drivers", "Image", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Drivers", "Image");
        }
    }
}
