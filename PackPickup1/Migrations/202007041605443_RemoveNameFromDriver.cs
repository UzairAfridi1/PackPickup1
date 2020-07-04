namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveNameFromDriver : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drivers", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "Name", c => c.String());
        }
    }
}
