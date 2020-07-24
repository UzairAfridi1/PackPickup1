namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCountryfromTblDriver : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Drivers", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Drivers", "Country", c => c.String());
        }
    }
}
