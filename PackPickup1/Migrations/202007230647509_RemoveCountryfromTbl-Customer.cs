namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCountryfromTblCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "Country");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Country", c => c.String());
        }
    }
}
