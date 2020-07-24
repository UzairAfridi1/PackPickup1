namespace PackPickup1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveCityfromTblCustomer : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "City");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "City", c => c.String());
        }
    }
}
