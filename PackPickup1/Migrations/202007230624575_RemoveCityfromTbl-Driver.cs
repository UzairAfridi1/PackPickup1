namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCityfromTblDriver : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drivers", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "City", c => c.String());
        }
    }
}
